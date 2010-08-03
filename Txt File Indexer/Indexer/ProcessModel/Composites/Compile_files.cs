using System;
using System.Diagnostics;
using Indexer.ProcessModel.FilesystemAdapter;

namespace Indexer.ProcessModel.Composites
{
    public class Compile_files
    {
        public Compile_files(Crawl_directory_tree crawlDirTree)
        {
            //throw new NotImplementedException();
        }


        public void In_Process(Tuple<string, string> args)
        {
            Trace.TraceInformation("Compile_files.In_Process({0}, {1})", args.Item1, args.Item2);
        }


        public event Action<string> Out_FileFound;
    }
}