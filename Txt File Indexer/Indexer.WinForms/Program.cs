using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ebc.patterns.aspects;
using Indexer.DataModel;

namespace Indexer.WinForms
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


            var dlg = new WinIndex();
            var indexer = new IndexFiles();


            dlg.Out_Index += indexer.In_Process;

            indexer.Out_FileFoundToIndex += SwitchBackToSyncContext<string>.Wrap(dlg.In_FileFound);
            indexer.Out_Statistics += SwitchBackToSyncContext<IndexStats>.Wrap(dlg.In_IndexStats);
            indexer.Out_ValidationError += SwitchBackToSyncContext<string>.Wrap(dlg.In_ValidationError);
            indexer.Out_UnhandledException += SwitchBackToSyncContext<Exception>.Wrap(dlg.In_Exception);


            Application.Run(dlg);
        }
    }
}
