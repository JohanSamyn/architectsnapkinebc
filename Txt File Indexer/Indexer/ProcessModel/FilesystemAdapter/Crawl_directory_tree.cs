using System;
using System.Diagnostics;

namespace Indexer.ProcessModel.FilesystemAdapter
{
    public class Crawl_directory_tree
    {
        public void In_Process(string path)
        {
            Trace.TraceInformation("Crawl dir tree({0})", path);
            this.Out_FileFound("test.txt");

        }

        public event Action<string> Out_FileFound;
    }
}