namespace wincalc
{
    partial class WinCalculator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnClearNumber = new System.Windows.Forms.Button();
            this.btnNum = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(117, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnClearNumber
            // 
            this.btnClearNumber.Location = new System.Drawing.Point(94, 52);
            this.btnClearNumber.Name = "btnClearNumber";
            this.btnClearNumber.Size = new System.Drawing.Size(35, 23);
            this.btnClearNumber.TabIndex = 1;
            this.btnClearNumber.Text = "C";
            this.btnClearNumber.UseVisualStyleBackColor = true;
            this.btnClearNumber.Click += new System.EventHandler(this.btnClearNumber_Click);
            // 
            // btnNum
            // 
            this.btnNum.Location = new System.Drawing.Point(12, 81);
            this.btnNum.Name = "btnNum";
            this.btnNum.Size = new System.Drawing.Size(35, 23);
            this.btnNum.TabIndex = 3;
            this.btnNum.Text = "7";
            this.btnNum.UseVisualStyleBackColor = true;
            this.btnNum.Click += new System.EventHandler(this.btnNum_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(53, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "8";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnNum_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(94, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "9";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnNum_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(94, 110);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(35, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "6";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnNum_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(53, 110);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(35, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "5";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnNum_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 110);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(35, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "4";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnNum_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(94, 139);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(35, 23);
            this.button6.TabIndex = 11;
            this.button6.Text = "3";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btnNum_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(53, 139);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(35, 23);
            this.button7.TabIndex = 10;
            this.button7.Text = "2";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.btnNum_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(12, 139);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(35, 23);
            this.button8.TabIndex = 9;
            this.button8.Text = "1";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.btnNum_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(12, 168);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(76, 23);
            this.button9.TabIndex = 12;
            this.button9.Text = "0";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.btnNum_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(94, 168);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(35, 23);
            this.button10.TabIndex = 13;
            this.button10.Text = ".";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.btnNum_Click);
            // 
            // WinCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(144, 201);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnNum);
            this.Controls.Add(this.btnClearNumber);
            this.Controls.Add(this.textBox1);
            this.Name = "WinCalculator";
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnClearNumber;
        private System.Windows.Forms.Button btnNum;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
    }
}

