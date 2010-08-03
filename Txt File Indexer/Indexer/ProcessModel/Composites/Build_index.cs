using System;
using System.Diagnostics;
using ebc.patterns;
using Indexer.DataModel;
using Indexer.ProcessModel.IndexAdapter;
using Indexer.ProcessModel.IndexBuilder;

namespace Indexer.ProcessModel.Composites
{
    public class Build_index
    {
        private readonly Action<Tuple<string, string[]>> in_Process;
        private readonly Action<string> in_IndexFilename;


        public Build_index(Compile_words compileWords, Write_index_to_file writeIndexToFile)
        {
            var joinIndexAndFilename = new Join<Index, string>();

            this.in_Process = _ => compileWords.In_Process(_);

            compileWords.Out_Statistics += _ => this.Out_Statistics(_);
            compileWords.Out_IndexCompiled += joinIndexAndFilename.Input0;
            this.in_IndexFilename = joinIndexAndFilename.Input1;

            joinIndexAndFilename.Output += writeIndexToFile.In_Process;
        }


        public void In_Process(Tuple<string, string[]> wordsInFile)
        {
            Trace.TraceInformation("Build index({0}, {1} words)", wordsInFile.Item1, wordsInFile.Item2.Length);
            this.in_Process(wordsInFile);
        }


        public void In_IndexFilename(string indexFilename)
        {
            Trace.TraceInformation("Build index received index filename({0})", indexFilename);
            this.in_IndexFilename(indexFilename);
        }


        public event Action<IndexStats> Out_Statistics;
    }
}