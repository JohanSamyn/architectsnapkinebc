using System;
using System.Diagnostics;
using Indexer.ProcessModel.WordExtractor;

namespace Indexer.ProcessModel.Composites
{
    public class Extract_words
    {
        private readonly Action<string> in_Process;


        public Extract_words(Read_words readWords, Filter_words filterWords)
        {
            this.in_Process = _ => readWords.In_Process(_);
            readWords.Out_WordsRead += filterWords.In_Process;
            filterWords.Out_FilteredWords += _ => this.Out_WordsExtracted(_);
        }


        public void In_Process(string filename)
        {
            Trace.TraceInformation("Extract words({0})", filename);
            this.in_Process(filename);
        }


        public event Action<Tuple<string, string[]>>  Out_WordsExtracted;
    }
}