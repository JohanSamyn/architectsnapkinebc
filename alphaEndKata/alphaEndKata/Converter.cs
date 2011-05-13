using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace alphaEndKata
{
    public class Converter
    {
        private const int BASE = 13;
        private readonly char[] BASE_DIGITS = new[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'x', 'y', 'z'};


        public string Convert(int n10)
        {
            var basePower = Determine_base_power(n10);
            var digits = Calculate_targetSystem_digits(n10, basePower);
            return Assemble_converted_number_from_digits(digits);
        }


        internal int Determine_base_power(int n10)
        {
            var nLogBase = Math.Log10(n10)/Math.Log10(BASE);
            return (int)Math.Truncate(nLogBase);
        }


        internal string Assemble_converted_number_from_digits(IEnumerable<char> digitOfTargetSystem)
        {
            return new string(digitOfTargetSystem.ToArray());
        }


        internal Tuple<int, int> Calculate_base_power_factor_and_remainder(int n10, int basePower)
        {
            int remainder;
            int factor = Math.DivRem(n10, (int)Math.Pow(BASE, basePower), out remainder);
            return new Tuple<int, int>(factor, remainder);
        }


        internal char Map_factor_to_targetSystem(int factor)
        {
            return BASE_DIGITS[factor];
        }


        internal IEnumerable<char> Calculate_targetSystem_digits(int n10, int basePower)
        {
            while (basePower >= 0)
            {
                var t = Calculate_base_power_factor_and_remainder(n10, basePower);
                var digitOfTargetSystem = Map_factor_to_targetSystem(t.Item1);

                yield return digitOfTargetSystem;

                n10 = t.Item2;
                basePower--;
            }
        }
    }
}