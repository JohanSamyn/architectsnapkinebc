using System;
using System.Diagnostics;
using Indexer.DataModel;

namespace Indexer.ProcessModel.IndexBuilder
{
    public class Compile_words
    {
        public void In_Process(Tuple<string, string[]> input)
        {
            Trace.TraceInformation("Compile words({0}, {1} words)", input.Item1, input.Item2.Length);
            this.Out_IndexCompiled(new Index());
            this.Out_Statistics(new IndexStats());
        }

        public event Action<IndexStats> Out_Statistics;
        public event Action<Index> Out_IndexCompiled;
    }
}