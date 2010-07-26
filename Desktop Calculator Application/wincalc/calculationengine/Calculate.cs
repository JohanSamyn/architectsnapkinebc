using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wincalc.ebc.patterns;

namespace wincalc.calculationengine
{
    class Calculate
    {
        public Calculate(Action<Action<double>> ejectNumber,
                         Action<Tuple<char, double>, Action<double>> applyOperation)
        {
            var opToSignal = new DropData<char>();
            var joinOpAndNumber = new Join<char, double>();

            this.In_Process = (c) =>
                {
                    opToSignal.In_Drop(c);
                    joinOpAndNumber.Input0(c);
                };

            opToSignal.Out_Signal += () => ejectNumber(joinOpAndNumber.Input1);
            joinOpAndNumber.Output += _ => applyOperation(_, this.Out_Result);
        }


        public Action<char> In_Process;

        public event Action<double> Out_Result;
    }
}
