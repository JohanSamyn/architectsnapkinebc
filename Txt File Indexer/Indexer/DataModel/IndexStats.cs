using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indexer.DataModel
{
    [Serializable]
    public class IndexStats
    {
        private readonly int wordCount;


        public IndexStats(int wordCount)
        {
            this.wordCount = wordCount;
        }


        public int WordCount { get { return this.wordCount; } }
    }
}
