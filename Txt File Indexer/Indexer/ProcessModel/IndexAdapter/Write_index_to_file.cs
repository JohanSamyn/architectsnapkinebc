using System;
using System.Diagnostics;
using Indexer.DataModel;

namespace Indexer.ProcessModel.IndexAdapter
{
    public class Write_index_to_file
    {
        public void In_Process(Tuple<string, Index> input)
        {
            Trace.TraceInformation("Write index to file({0})", input.Item1);
        }
    }
}