using System;
using System.Diagnostics;
using Indexer.ProcessModel.WordExtractor;

namespace Indexer.ProcessModel.Composites
{
    public class Extract_words
    {
        public Extract_words(Read_words readWords, Filter_words filterWords)
        {
            //throw new NotImplementedException();
        }


        public void In_Process(string filename)
        {
            Trace.TraceInformation("Extract words({0})", filename);
            this.Out_WordsExtracted(new Tuple<string, string[]>("test.txt", new[]{"w1", "stop", "w3"}));
            this.Out_WordsExtracted(null);
        }


        public event Action<Tuple<string, string[]>>  Out_WordsExtracted;
    }
}