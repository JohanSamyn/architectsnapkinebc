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

            var index = new IndexFiles();
            index.Out_Statistics += stats =>
                                        {
                                            Console.WriteLine("Successfully indexed {0} words.", stats.WordCount);
                                            returnCode = 0;
                                            finishedProcessing.Set();
                                        };

            index.Out_ValidationError += err =>
                                             {
                                                 Console.WriteLine("*** Aborted indexing! Validation error: {0}", err);
                                                 returnCode = 1;
                                                 finishedProcessing.Set();
                                             };

            index.Out_UnhandledException += ex =>
                                                {
                                                    Console.WriteLine("*** Aborted indexing! Unexpected exception: {0}. See log for details.", ex.Message);
                                                    returnCode = 99;
                                                    finishedProcessing.Set();
                                                };

            index.In_Process(args[0], args[1]);

            finishedProcessing.WaitOne();
            return returnCode;
        }
    }
}
