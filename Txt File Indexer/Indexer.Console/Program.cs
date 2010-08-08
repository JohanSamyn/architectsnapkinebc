using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Indexer.Console
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
                    System.Console.WriteLine("Successfully indexed {0} words.", stats.WordCount);
                    returnCode = 0;
                    finishedProcessing.Set();
                };

            index.Out_ValidationError += err =>
                {
                    System.Console.WriteLine("*** Aborted indexing! Validation error: {0}", err);
                    returnCode = 1;
                    finishedProcessing.Set();
                };

            index.Out_UnhandledException += ex =>
                {
                    System.Console.WriteLine("*** Aborted indexing! Unexpected exception: {0}. See log for details.", ex.Message);
                    returnCode = 99;
                    finishedProcessing.Set();
                };

            System.Console.WriteLine("Indexing files in {0} [Thread {1}]", args[0], Thread.CurrentThread.GetHashCode());

            index.Index(args[0], args[1]);

            finishedProcessing.WaitOne();
            return returnCode;
        }
    }
}
