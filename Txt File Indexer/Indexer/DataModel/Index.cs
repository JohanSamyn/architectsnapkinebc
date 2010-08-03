using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indexer.DataModel
{
    [Serializable]
    public class Index
    {
        private readonly Dictionary<string, List<string>> wordsInFiles = new Dictionary<string, List<string>>();


        public IEnumerable<KeyValuePair<string, List<string>>> WordsInFiles
        {
            get
            {
                return wordsInFiles.OrderBy(kvp => kvp.Key);
            }
        }


        public int WordCount
        {
            get { return this.wordsInFiles.Count; }
        }


        public void Add(string word, string filename)
        {
            if (!this.wordsInFiles.ContainsKey(word))
                this.wordsInFiles.Add(word, new List<string>());
            this.wordsInFiles[word].Add(filename);
        }
    }
}
