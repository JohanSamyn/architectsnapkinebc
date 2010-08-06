using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ebc.patterns;
using ebc.patterns.aspects;
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
            var logStats = new Log<IndexStats>(stats => string.Format("{0} words indexed", stats.WordCount));
            var logFileWords = new Log<Tuple<string, string[]>>(fileWords => 
                                        fileWords != null ? string.Format("{0}, {1} words", fileWords.Item1, fileWords.Item2.Count())
                                                          : "EOD of words to index");

            this.in_Process = _ => logFileWords.In_Process(_);
            logFileWords.Out_Data += compileWords.In_Process;

            compileWords.Out_Statistics += logStats.In_Process;
            logStats.Out_Data += _ => this.Out_Statistics(_);

            compileWords.Out_IndexCompiled += joinIndexAndFilename.Input0;
            this.in_IndexFilename = joinIndexAndFilename.Input1;

            joinIndexAndFilename.Output += writeIndexToFile.In_Process;
        }


        public void In_Process(Tuple<string, string[]> wordsInFile)
        {
            this.in_Process(wordsInFile);
        }


        public void In_IndexFilename(string indexFilename)
        {
            this.in_IndexFilename(indexFilename);
        }


        public event Action<IndexStats> Out_Statistics;
    }
}