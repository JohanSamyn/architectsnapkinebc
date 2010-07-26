using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace wincalc.calculationengine
{
    class CalculationEngine
    {
        private Stack<double> operands = new Stack<double>();
        private char operation;


        public void In_ApplyOperation(Tuple<char, double?> input, Action<double> out_result)
        {
            double result = 0.0;

            if (input.Item2 != null)
            {
                if (this.operation == '=') this.operands.Clear();
                this.operands.Push(input.Item2.Value);
                result = Calculate();
            }
            else
                if (this.operands.Count > 0)
                    result = this.operands.Peek();
            this.operation = input.Item1;

            out_result(result);
        }


        public void In_Clear()
        {
            this.operands = new Stack<double>();
        }


        private double Calculate()
        {
            if (this.operands.Count == 2)
            {
                var operand1 = this.operands.Pop();
                var operand0 = this.operands.Pop();

                    Func<double, double, double> op = (a, b) => 0;

                    switch (operation)
                    {
                        case '+':
                            op = (a, b) => a + b;
                            break;
                        case '-':
                            op = (a, b) => a - b;
                            break;
                        case '*':
                            op = (a, b) => a * b;
                            break;
                        case '/':
                            op = (a, b) => a / b;
                            break;
                        case '^':
                            op = (a, b) => Math.Pow(a, b);
                            break;
                    }

                    var result = op(operand0, operand1);
                    this.operands.Push(result);

                    return result;
            }

            return this.operands.Peek();
        }
    }
}
