using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Indexer.ProcessModel.WordExtractor
{
    public class Filter_words
    {
        public void In_Process(IEnumerable<Tuple<string, string[]>> input)
        {
            var filteredWordsInFiles = input.Select(wordsInFile =>
            {
                Trace.TraceInformation("Filter words({0}, {1} words)", wordsInFile.Item1, wordsInFile.Item2.Length);

                var filteredWords = wordsInFile.Item2.Where(word => word.Length > 3);
                return new Tuple<string, string[]>(wordsInFile.Item1,
                                                    filteredWords.ToArray());
                                                            
            });
            foreach(var filteredWordsInFile in filteredWordsInFiles)
                this.Out_FilteredWords(filteredWordsInFile);
            this.Out_FilteredWords(null);
        }


        public event Action<Tuple<string, string[]>> Out_FilteredWords;
    }
}