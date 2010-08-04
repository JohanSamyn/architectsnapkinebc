using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Indexer.ProcessModel.WordExtractor
{
    public class Split_lines_into_words
    {
        public void In_Process(IEnumerable<Tuple<string, string[]>> input)
        {
            var wordsInFiles = input.Select(linesInFile =>
            {
                Trace.TraceInformation("Split lines into words({0}, {1} lines)", linesInFile.Item1, linesInFile.Item2.Length);

                var words = new List<string>();
                foreach (var line in linesInFile.Item2)
                    words.AddRange(line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries));
                return new Tuple<string, string[]>(linesInFile.Item1, words.Distinct().ToArray());
                                                    
            });
            this.Out_WordsFound(wordsInFiles);
        }


        public event Action<IEnumerable<Tuple<string, string[]>>> Out_WordsFound;
    }
}