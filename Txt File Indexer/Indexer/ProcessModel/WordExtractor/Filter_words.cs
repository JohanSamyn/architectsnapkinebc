using System;
using System.Diagnostics;

namespace Indexer.ProcessModel.WordExtractor
{
    public class Filter_words
    {
        public void In_Process(Tuple<string, string[]> input)
        {
            if (input == null) return;

            Trace.TraceInformation("Filter words({0}, {1} words)", input.Item1, input.Item2.Length);
            this.Out_FilteredWords(new Tuple<string, string[]>("test.txt", new[]{"w1", "w2"}));
        }


        public event Action<Tuple<string, string[]>> Out_FilteredWords;
    }
}