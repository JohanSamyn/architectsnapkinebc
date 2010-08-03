using System;
using System.Diagnostics;
using Indexer.ProcessModel.FilesystemAdapter;
using Indexer.ProcessModel.WordExtractor;

namespace Indexer.ProcessModel.Composites
{
    public class Read_words
    {
        public Read_words(Read_text_lines readLines, Split_lines_into_words splitLinesIntoWords)
        {
            //throw new NotImplementedException();
        }


        public void In_Process(string filename)
        {
            Trace.TraceInformation("Read words({0})", filename);
            this.Out_WordsRead(new Tuple<string, string[]>("test.txt", new[] { "w1", "stop", "w3" }));
            this.Out_WordsRead(null);
        }


        public event Action<Tuple<string, string[]>> Out_WordsRead;
    }
}