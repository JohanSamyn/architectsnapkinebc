using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Indexer.ProcessModel.FilesystemAdapter
{
    public class Crawl_directory_tree
    {
        public void In_Process(string path)
        {
            Trace.TraceInformation("Crawl dir tree({0})", path);

            this.Out_FileFound(Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories));
        }

        public event Action<IEnumerable<string>> Out_FileFound;
    }
}