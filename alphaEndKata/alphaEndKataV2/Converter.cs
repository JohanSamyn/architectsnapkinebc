using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CanUDoIt
{
    public class Converter
    {
        public string Convert(int n10)
        {
            int basePower = Determine_basePower(n10);

            int factor, remainder;
            Divide_by_base_raised_to_basePower(n10, basePower, out factor, out remainder);


            return "5";
        }

        private void Divide_by_base_raised_to_basePower(int n10, int basePower, out int factor, out int remainder)
        {
            factor = Math.DivRem(n10, (int)Math.Pow(13, basePower), out remainder);
        }

        private int Determine_basePower(int n10)
        {
            return (int)Math.Truncate(Math.Log10(n10)/Math.Log10(n10));
        }
    }
}