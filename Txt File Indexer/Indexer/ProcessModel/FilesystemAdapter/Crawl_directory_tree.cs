using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Indexer.ProcessModel.FilesystemAdapter
{
    public class Crawl_directory_tree
    {
        public void In_Process(string path)
        {
            Trace.TraceInformation("Crawl dir tree({0}) [Thread {1}]", path, Thread.CurrentThread.GetHashCode());

            foreach (var filename in Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories))
                this.Out_FileFound(filename);
            this.Out_FileFound(null);
        }

        public event Action<string> Out_FileFound;
    }
}