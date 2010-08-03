using System;
using System.Diagnostics;
using Indexer.ProcessModel.FilesystemAdapter;
using Indexer.ProcessModel.WordExtractor;

namespace Indexer.ProcessModel.Composites
{
    public class Read_words
    {
        public Read_words(Read_text_lines readLines, Split_lines_into_words splitLinesIntoWords)
        {
            //throw new NotImplementedException();
        }


        public void In_Process(string filename)
        {
            Trace.TraceInformation("Read words({0})", filename);
        }


        public event Action<Tuple<string, string[]>> Out_WordsRead;
    }
}