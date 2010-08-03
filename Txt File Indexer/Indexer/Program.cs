using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Indexer.ProcessModel.Composites;
using Indexer.ProcessModel.FilesystemAdapter;
using Indexer.ProcessModel.IndexAdapter;
using Indexer.ProcessModel.IndexBuilder;
using Indexer.ProcessModel.WordExtractor;

namespace Indexer
{
    class Program
    {
        static void Main(string[] args)
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

            // Bind
            compileFiles.Out_FileFound += extractWords.In_Process;
            extractWords.Out_WordsExtracted += buildIndex.In_Process;

            compileFiles.Out_IndexFilename += buildIndex.In_IndexFilename;


            // Run
        }
    }
}
