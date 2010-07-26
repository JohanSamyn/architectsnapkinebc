using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace wincalc
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var wc = new WinCalculator();
            var na = new NumberAggregator();
            var calcEng = new calculationengine.CalculationEngine();
            var calc = new calculationengine.Calculate(na.EjectNumber, calcEng.In_ApplyOperation);

            wc.Out_NumberCharacter += c => na.ExtendNumber(c, n => wc.In_CurrentNumber(n ?? 0.0));
            
            wc.Out_OperationCharacter += c => calc.In_Process(c);
            calc.Out_Result += wc.In_CurrentNumber;

            wc.Out_ClearNumber += () => na.Clear(n => wc.In_CurrentNumber(n ?? 0.0));

            wc.Out_ClearAll += () => na.Clear(n => wc.In_CurrentNumber(n ?? 0.0));
            wc.Out_ClearAll += calcEng.In_Clear;

            Application.Run(wc);
        }
    }
}
