using System;
using System.Diagnostics;
using ebc.patterns;
using Indexer.ProcessModel.FilesystemAdapter;

namespace Indexer.ProcessModel.Composites
{
    public class Compile_files
    {
        private readonly Action<Tuple<string, string>> in_Process;


        public Compile_files(Crawl_directory_tree crawlDirTree)
        {
            var split = new Split<Tuple<string, string>, string, string>(
                t => t.Item1,
                t => t.Item2
                );

            this.in_Process = _ => split.Input(_);
            split.Output0 += crawlDirTree.In_Process;
            split.Output1 += _ => this.Out_IndexFilename(_);

            crawlDirTree.Out_FileFound += _ => this.Out_FileFound(_);
        }


        public void In_Process(Tuple<string, string> args)
        {
            Trace.TraceInformation("Compile files({0}, {1})", args.Item1, args.Item2);
            this.in_Process(args);
        }


        public event Action<string> Out_FileFound;
        public event Action<string> Out_IndexFilename;
    }
}