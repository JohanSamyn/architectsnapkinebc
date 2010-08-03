using System;
using System.Diagnostics;
using Indexer.ProcessModel.FilesystemAdapter;
using Indexer.ProcessModel.WordExtractor;

namespace Indexer.ProcessModel.Composites
{
    public class Read_words
    {
        private readonly Action<string> in_Process;


        public Read_words(Read_text_lines readLines, Split_lines_into_words splitLinesIntoWords)
        {
            this.in_Process = _ => readLines.In_Process(_);
            readLines.Out_LinesRead += splitLinesIntoWords.In_Process;
            splitLinesIntoWords.Out_WordsFound += _ => this.Out_WordsRead(_);
        }


        public void In_Process(string filename)
        {
            Trace.TraceInformation("Read words({0})", filename);
            this.in_Process(filename);
        }


        public event Action<Tuple<string, string[]>> Out_WordsRead;
    }
}