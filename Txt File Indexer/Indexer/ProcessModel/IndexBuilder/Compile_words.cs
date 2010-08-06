using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Indexer.DataModel;
using System.Linq;

namespace Indexer.ProcessModel.IndexBuilder
{
    public class Compile_words
    {
        private Index index = new Index();


        public void In_Process(Tuple<string, string[]> input)
        {
            if(input != null)
            {
                Trace.TraceInformation("Compile words({0}, {1} words) [Thread {2}]", input.Item1, input.Item2.Length, Thread.CurrentThread.GetHashCode());

                foreach (var word in input.Item2)
                    this.index.Add(word, input.Item1);
            }
            else
            {
                this.Out_IndexCompiled(this.index);
                this.Out_Statistics(new IndexStats(this.index.WordCount));

                this.index = new Index();
            }
        }


        public event Action<Index> Out_IndexCompiled;
        public event Action<IndexStats> Out_Statistics;
    }
}