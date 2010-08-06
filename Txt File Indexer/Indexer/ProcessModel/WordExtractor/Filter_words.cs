using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Indexer.ProcessModel.WordExtractor
{
    public class Filter_words
    {
        public void In_Process(Tuple<string, string[]> input)
        {
            Trace.TraceInformation("Filter words({0}, {1} words) [Thread {2}]", input.Item1, input.Item2.Length, Thread.CurrentThread.GetHashCode());

            var filteredWords = input.Item2.Where(word => word.Length > 3);
            this.Out_FilteredWords(new Tuple<string, string[]>(
                                                input.Item1,
                                                filteredWords.ToArray()));
        }


        public event Action<Tuple<string, string[]>> Out_FilteredWords;
    }
}