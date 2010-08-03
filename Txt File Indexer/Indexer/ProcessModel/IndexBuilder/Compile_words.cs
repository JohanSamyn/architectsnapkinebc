using System;
using System.Diagnostics;
using Indexer.DataModel;

namespace Indexer.ProcessModel.IndexBuilder
{
    public class Compile_words
    {
        private Index index = new Index();


        public void In_Process(Tuple<string, string[]> input)
        {
            if (input == null)
            {
                this.Out_IndexCompiled(this.index);
                this.Out_Statistics(new IndexStats(this.index.WordCount));

                this.index = new Index();
            }
            else
            {
                Trace.TraceInformation("Compile words({0}, {1} words)", input.Item1, input.Item2.Length);

                foreach (var word in input.Item2)
                    this.index.Add(word, input.Item1);
            }
        }


        public event Action<IndexStats> Out_Statistics;
        public event Action<Index> Out_IndexCompiled;
    }
}