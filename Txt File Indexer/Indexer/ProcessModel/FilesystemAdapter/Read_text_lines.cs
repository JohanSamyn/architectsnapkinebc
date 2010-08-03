using System;
using System.Diagnostics;

namespace Indexer.ProcessModel.FilesystemAdapter
{
    public class Read_text_lines
    {
        public void In_Process(string filename)
        {
            Trace.TraceInformation("Read text lines({0})", filename);
            this.Out_LinesRead(new Tuple<string, string[]>("test.txt", new[]{"w1 stop", "w2"}));
        }

        public event Action<Tuple<string, string[]>> Out_LinesRead;
    }
}