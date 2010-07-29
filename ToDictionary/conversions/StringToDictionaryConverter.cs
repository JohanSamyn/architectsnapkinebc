using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace conversions
{
    public partial class StringToDictionaryConverter
    {
        private readonly Action<string, Action<Dictionary<string, string>>>  Convert_to_dictionary;


        public Dictionary<string, string> Convert(string configuration)
        {
            Dictionary<string, string> dict=null;
            this.Convert_to_dictionary(configuration, result => dict = result);
            return dict;
        }
    }
}
