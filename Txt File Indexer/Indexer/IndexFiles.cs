using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ebc.patterns.aspects;
using Indexer.DataModel;
using Indexer.ProcessModel.Composites;
using Indexer.ProcessModel.FilesystemAdapter;
using Indexer.ProcessModel.IndexAdapter;
using Indexer.ProcessModel.IndexBuilder;
using Indexer.ProcessModel.WordExtractor;

namespace Indexer
{
    public class IndexFiles
    {
        private readonly Action<Tuple<string, string>> in_Process;


        public IndexFiles()
        {
            // Build
            var crawlDirTree = new Crawl_directory_tree();
            var compileFiles = new Compile_files(crawlDirTree);

            var readLines = new Read_text_lines();
            var splitLinesIntoWords = new Split_lines_into_words();
            var readWords = new Read_words(readLines, splitLinesIntoWords);

            var filterWords = new Filter_words();
            var extractWords = new Extract_words(readWords, filterWords);

            var compileWords = new Compile_words();
            var writeIndexToFile = new Write_index_to_file();
            var buildIndex = new Build_index(compileWords, writeIndexToFile);

            var logValidationError = new Log<string>(errMsg => "*** " + errMsg);
            var logException = new Log<Exception>(ex => "*** " + ex.Message + '\n' + ex.StackTrace);

            var handleEx = new HandleException<Tuple<string, string>>();

            var async = new Asynchronize<Tuple<string, string[]>>();


            // Bind
            this.in_Process = _ => handleEx.In_Process(_);

            handleEx.Out_Process += compileFiles.In_Process;
            handleEx.Out_Exception += logException.In_Process;

            logException.Out_Data += _ => this.Out_UnhandledException(_);

            compileFiles.Out_FileFound += extractWords.In_Process;
            extractWords.Out_WordsExtracted += async.In_Process;
            async.Out_ProcessSequentially += buildIndex.In_Process;

            compileFiles.Out_IndexFilename += buildIndex.In_IndexFilename;

            compileFiles.Out_ValidationError += logValidationError.In_Process;
            logValidationError.Out_Data += _ => this.Out_ValidationError(_);

            buildIndex.Out_Statistics += _ => this.Out_Statistics(_);
        }


        public void In_Process(string path, string indexFilename)
        {
            this.in_Process(new Tuple<string, string>(path, indexFilename));   
        }


        public event Action<IndexStats> Out_Statistics;

        public event Action<string> Out_ValidationError;
        public event Action<Exception> Out_UnhandledException;
    }
}
