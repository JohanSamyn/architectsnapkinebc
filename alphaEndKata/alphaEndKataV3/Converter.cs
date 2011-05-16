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
            string nBased = "";

            int basePower = Determine_basePower(n10);

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

        private string Map_factor_to_digit(int factor)
        {
            return "5";
        }

        private void Calc_factor_and_remainder(int n10, int basePower, out int factor, out int remainder)
        {
            factor = 5;
            remainder = 0;
        }

        private int Determine_basePower(int n10)
        {
            return 0;
        }
    }
}
