using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace wincalc
{
    public partial class WinCalculator : Form
    {
        public WinCalculator()
        {
            InitializeComponent();
        }


        private void btnNum_Click(object sender, EventArgs e)
        {
            var c = ((Button) sender).Text[0];
            this.Out_NumberCharacter(c);
        }

        private void btnOp_Click(object sender, EventArgs e)
        {
            var c = ((Button)sender).Text[0];
            this.Out_OperationCharacter(c);
        }



        private void btnClearNumber_Click(object sender, EventArgs e)
        {
            this.Out_Clear();
        }


        public void In_CurrentNumber(double number)
        {
            this.textBox1.Text = number.ToString();
        }

        
        public event Action<char> Out_NumberCharacter;
        public event Action<char> Out_OperationCharacter;
        public event Action Out_Clear;
    }
}
