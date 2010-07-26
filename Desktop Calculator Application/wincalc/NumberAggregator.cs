using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wincalc
{
    class NumberAggregator
    {
        private double currentNumber;
        private double numberFactor;
        private double digitFactor;


        public NumberAggregator()
        {
            Reset();
        }


        public void ExtendNumber(char c, Action<double> out_currentNumber)
        {
            if (c == '.')
            {
                if (this.digitFactor >= 1.0)
                {
                    this.numberFactor = 1.0;
                    this.digitFactor = 0.1;
                }
            }
            else
            {
                this.currentNumber = this.currentNumber*this.numberFactor;
                this.currentNumber += int.Parse(c.ToString()) * this.digitFactor;
                if (this.digitFactor < 1.0) this.digitFactor *= 0.1;
            }

            out_currentNumber(this.currentNumber);
        }


        public void DiscardNumber(Action<double> out_currentNumber)
        {
            Reset();
            out_currentNumber(this.currentNumber);
        }

        
        private void Reset()
        {
            this.currentNumber = 0.0;
            this.numberFactor = 10.0;
            this.digitFactor = 1.0;
        }
    }
}
