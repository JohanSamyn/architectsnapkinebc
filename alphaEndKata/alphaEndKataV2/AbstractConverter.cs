using System;

namespace CanUDoIt
{
    public abstract class AbstractConverter
    {
        private readonly char[] _digits;
        private readonly int _base;


        protected AbstractConverter(char[] digits)
        {
            _digits = digits;
            _base = digits.Length;
        }


        public string Convert(int n10)
        {
            string nBased = "";

            int basePower = Determine_basePower(n10);

            while (basePower >= 0)
            {
                int factor, remainder;
                Divide_by_base_raised_to_basePower(n10, basePower, out factor, out remainder);
                char digit = Map_factor_to_digit(factor);
                nBased += digit;

                n10 = remainder;
                basePower--;
            }

            return nBased;
        }

        private char Map_factor_to_digit(int factor)
        {
            return _digits[factor];
        }

        private void Divide_by_base_raised_to_basePower(int n10, int basePower, out int factor, out int remainder)
        {
            factor = Math.DivRem(n10, (int)Math.Pow(_base, basePower), out remainder);
        }

        private int Determine_basePower(int n10)
        {
            return (int)Math.Truncate(Math.Log10(n10)/Math.Log10(_base));
        }

    }
}