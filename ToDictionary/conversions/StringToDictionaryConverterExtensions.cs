using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace conversions
{
    public static class StringToDictionaryConverterExtensions
    {
        public static Dictionary<string, string> ToDictionary(this string configuration)
        {
            return new StringToDictionaryConverter().Convert(configuration);
        }


        public static Dictionary<string, string> Parse(this Dictionary<string, string> dictionary, string configuration)
        {
            var _ = configuration.ToDictionary();
            foreach(var entry in _)
                dictionary.Add(entry.Key, entry.Value);
            return dictionary;
        }
    }
}