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

            var wm = new WinMain();
            var cm = new ColorManager();

            wm.Out_Start += cm.In_GetInitialColor;
            wm.Out_ToggleColor += cm.In_ToggleColor;

            cm.Out_CurrentColor += wm.In_CurrentColor;

            Application.Run(wm);
        }
    }
}
