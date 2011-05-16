using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace alphaEndKataV3
{
    public class Converter
    {
        public string Convert(int n10)
        {
            int basePower = Determine_basePower(n10);

            return Builder_nBase_number(n10, basePower);
        }

        private string Builder_nBase_number(int n10, int basePower)
        {
            string nBased = "";

            while (basePower >= 0)
            {
                int factor, remainder;
                Calc_factor_and_remainder(n10, basePower, out factor, out remainder);
                nBased += Map_factor_to_digit(factor);

                n10 = remainder;
                basePower--;
            }
            return nBased;
        }

        private char Map_factor_to_digit(int factor)
        {
            return "0123456789xyz"[factor];
        }

        private void Calc_factor_and_remainder(int n10, int basePower, out int factor, out int remainder)
        {
            factor = Math.DivRem(n10, (int)Math.Pow(13, basePower), out remainder);
        }

        private int Determine_basePower(int n10)
        {
            return (int)Math.Truncate(Math.Log10(n10)/Math.Log10(13));
        }
    }
}
