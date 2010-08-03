using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Indexer.ProcessModel.FilesystemAdapter
{
    public class Read_text_lines
    {
        public void In_Process(string filename)
        {
            if (filename == null)
            {
                this.Out_LinesRead(null);
            }
            else
            {
                Trace.TraceInformation("Read text lines({0})", filename);

                this.Out_LinesRead(new Tuple<string, string[]>(
                    filename,
                    File.ReadLines(filename).ToArray()
                    ));
            }
            
        }

        public event Action<Tuple<string, string[]>> Out_LinesRead;
    }
}