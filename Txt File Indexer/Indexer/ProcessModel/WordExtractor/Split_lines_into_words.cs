using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Indexer.ProcessModel.WordExtractor
{
    public class Split_lines_into_words
    {
        public void In_Process(Tuple<string, string[]> input)
        {
            Trace.TraceInformation("Split lines into words({0}, {1} lines)", input.Item1, input.Item2.Length);
            this.Out_WordsFound(new Tuple<string, string[]>("test.txt", new[]{"w1", "stop", "w2"}));
        }


        public event Action<Tuple<string, string[]>> Out_WordsFound;
    }
}