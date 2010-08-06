using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace Indexer.ProcessModel.FilesystemAdapter
{
    public class Read_text_lines
    {
        public void In_Process(string filename)
        {
            Trace.TraceInformation("Read text lines({0}) [Thread {1}]", filename, Thread.CurrentThread.GetHashCode());

            this.Out_LinesRead(new Tuple<string, string[]>(
                                       filename,
                                       File.ReadLines(filename).ToArray()));
        }


        public event Action<Tuple<string, string[]>> Out_LinesRead;
    }
}