using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToggleColorClient
{
    public partial class WinMain : Form
    {
        public WinMain()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Out_Start();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Out_ToggleColor();
        }


        public void In_CurrentColor(Color color)
        {
            this.pictureBox1.BackColor = color;
        }


        public event Action Out_Start;
        public event Action Out_ToggleColor;
    }
}
