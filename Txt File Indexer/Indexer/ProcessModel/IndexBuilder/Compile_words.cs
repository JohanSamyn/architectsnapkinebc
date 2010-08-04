using System;
using System.Collections.Generic;
using System.Diagnostics;
using Indexer.DataModel;
using System.Linq;

namespace Indexer.ProcessModel.IndexBuilder
{
    public class Compile_words
    {
        private Index index = new Index();


        public void In_Process(IEnumerable<Tuple<string, string[]>> input)
        {
            foreach (var wordsInFiles in input)
            {
                Trace.TraceInformation("Compile words({0}, {1} words)", wordsInFiles.Item1, wordsInFiles.Item2.Length);

                foreach (var word in wordsInFiles.Item2)
                    this.index.Add(word, wordsInFiles.Item1);
            }

            this.Out_IndexCompiled(this.index);
            this.Out_Statistics(new IndexStats(this.index.WordCount));

            this.index = new Index();
        }


        public event Action<IndexStats> Out_Statistics;
        public event Action<Index> Out_IndexCompiled;
    }
}