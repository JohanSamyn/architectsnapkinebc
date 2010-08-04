using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Indexer.ProcessModel.FilesystemAdapter
{
    public class Read_text_lines
    {
        public void In_Process(IEnumerable<string> filenames)
        {
            var linesInFiles = filenames.Select(filename =>
            {
                Trace.TraceInformation("Read text lines({0})", filename);

                return new Tuple<string, string[]>(
                    filename,
                    File.ReadLines(filename).ToArray());
                                                        
            });
            this.Out_LinesRead(linesInFiles);
        }


        public event Action<IEnumerable<Tuple<string, string[]>>> Out_LinesRead;
    }
}