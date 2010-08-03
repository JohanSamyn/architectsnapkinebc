using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Indexer.ProcessModel.WordExtractor
{
    public class Split_lines_into_words
    {
        public void In_Process(Tuple<string, string[]> input)
        {
            if (input == null)
            {
                this.Out_WordsFound(null);
            }
            else
            {
                Trace.TraceInformation("Split lines into words({0}, {1} lines)", input.Item1, input.Item2.Length);

                var words = new List<string>();
                foreach (var line in input.Item2)
                    words.AddRange(line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries));
                this.Out_WordsFound(new Tuple<string, string[]>(input.Item1, 
                                                                words.Distinct().ToArray()));
            }
        }


        public event Action<Tuple<string, string[]>> Out_WordsFound;
    }
}