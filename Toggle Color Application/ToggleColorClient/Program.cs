using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ToggleColorClient
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

            var f = new Form1();
            var cm = new ColorManager();

            f.Out_Start += cm.In_GetInitialColor;
            f.Out_ToggleColor += cm.In_ToggleColor;

            cm.Out_CurrentColor += f.In_CurrentColor;

            Application.Run(f);
        }
    }
}
