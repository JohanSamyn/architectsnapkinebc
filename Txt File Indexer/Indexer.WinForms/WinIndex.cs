using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Indexer.DataModel;

namespace Indexer.WinForms
{
    public partial class WinIndex : Form
    {
        public WinIndex()
        {
            InitializeComponent();
        }


        private void btnIndex_Click(object sender, EventArgs e)
        {
            this.Out_Index(new Tuple<string, string>(this.txtPath.Text, this.txtIndexFilename.Text));
        }


        public void In_FileFound(string filename)
        {
            this.lstProgress.Items.Insert(0, string.Format("Indexing {0}", Path.GetFileName(filename)));
        }

        public void In_IndexStats(IndexStats stats)
        {
            this.lstProgress.Items.Insert(0, string.Format("{0} words indexed", stats.WordCount));
        }

        public void In_ValidationError(string error)
        {
            this.lstProgress.Items.Insert(0, string.Format("+++ Validation error: {0}", error));
        }

        public void In_Exception(Exception ex)
        {
            this.lstProgress.Items.Insert(0, string.Format("*** Severe error: {0}", ex.Message));
        }

        
        public event Action<Tuple<string, string>> Out_Index;
    }
}
