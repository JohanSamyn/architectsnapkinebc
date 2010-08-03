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
        }


        public event Action<Tuple<string, string[]>>  Out_WordsExtracted;
    }
}