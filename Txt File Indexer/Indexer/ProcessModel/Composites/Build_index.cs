using System;
using System.Diagnostics;
using Indexer.DataModel;
using Indexer.ProcessModel.IndexAdapter;
using Indexer.ProcessModel.IndexBuilder;

namespace Indexer.ProcessModel.Composites
{
    public class Build_index
    {
        public Build_index(Compile_words compileWords, Write_index_to_file writeIndexToFile)
        {
            //throw new NotImplementedException();
        }


        public void In_Process(Tuple<string, string[]> wordsInFile)
        {
            Trace.TraceInformation("Build index({0}, {1} words)", wordsInFile.Item1, wordsInFile.Item2.Length);
        }


        public event Action<IndexStats> Out_Statistics;
    }
}