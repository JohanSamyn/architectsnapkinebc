using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace conversions
{
    partial class StringToDictionaryConverter
    {
        public StringToDictionaryConverter()
        {
            this.Convert_to_dictionary = (configuration, out_dictionary) =>
                    {
                        Split_into_assignments(configuration, assignments =>
                        Split_assignments(assignments, keyValuePairs =>
                        Build_dictionary(keyValuePairs, out_dictionary)));
                    };
        }


        internal void Split_into_assignments(string configuration, Action<string[]> out_assignments)
        {
            var assignments = configuration.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            out_assignments(assignments);
        }


        internal void Split_assignments(string[] assigments, Action<KeyValuePair<string, string>[]> out_keyValuePairs)
        {
            var keyValuePairs = assigments.Select(assignment => assignment.Split('='))
                                            .Select(parts => new KeyValuePair<string, string>(parts[0].Trim(), parts[1]))
                                            .ToArray();
            out_keyValuePairs(keyValuePairs);
        }


        internal void Build_dictionary(KeyValuePair<string, string>[] keyValuePairs, Action<Dictionary<string, string>> out_dictionary)
        {
            out_dictionary(keyValuePairs.Aggregate(new Dictionary<string, string>(), (dict, kvp) =>
            {
                dict.Add(kvp.Key, kvp.Value);
                return dict;
            }));
        }
    }
}
