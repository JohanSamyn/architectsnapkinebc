using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using Indexer.DataModel;

namespace Indexer.ProcessModel.IndexAdapter
{
    public class Write_index_to_file
    {
        public void In_Process(Tuple<Index, string> input)
        {
            Trace.TraceInformation("Write index to file({0}) [Thread {1}]", input.Item2, Thread.CurrentThread.GetHashCode());

            using (var sw = new StreamWriter(input.Item2, false, Encoding.Default))
            {
                foreach (var wordInFiles in input.Item1.WordsInFiles)
                {
                    sw.WriteLine(wordInFiles.Key);
                    foreach(var filename in wordInFiles.Value)
                        sw.WriteLine("\t{0}", filename);
                }
            }
        }
    }
}