using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ebc.patterns.aspects;
using Indexer.ProcessModel.Composites;
using Indexer.ProcessModel.FilesystemAdapter;
using Indexer.ProcessModel.IndexAdapter;
using Indexer.ProcessModel.IndexBuilder;
using Indexer.ProcessModel.WordExtractor;

namespace Indexer
{
    class Program
    {
        static int Main(string[] args)
        {
            var finishedProcessing = new AutoResetEvent(false);
            int returnCode = 0;

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
            handleEx.Out_Process += compileFiles.In_Process;
            handleEx.Out_Exception += logException.In_Process;

            logException.Out_Data += _ =>
                                        {
                                            Console.WriteLine("Aborted indexing due to exception!");
                                            returnCode = 1;
                                            finishedProcessing.Set();
                                        };

            compileFiles.Out_FileFound += extractWords.In_Process;
            extractWords.Out_WordsExtracted += async.In_Process;
            async.Out_ProcessSequentially += buildIndex.In_Process;

            compileFiles.Out_IndexFilename += buildIndex.In_IndexFilename;
            
            compileFiles.Out_ValidationError += logValidationError.In_Process;
            logValidationError.Out_Data += _ =>
                                                {
                                                    Console.WriteLine("Aborted indexing due to validation error!");
                                                    returnCode = 2;
                                                    finishedProcessing.Set();
                                                };

            buildIndex.Out_Statistics += stats =>
                                             {
                                                 Console.WriteLine("{0} words indexed", stats.WordCount);
                                                 finishedProcessing.Set();
                                             };


            // Run
            handleEx.In_Process(new Tuple<string, string>(args[0], args[1]));

            finishedProcessing.WaitOne();
            return returnCode;
        }
    }
}
