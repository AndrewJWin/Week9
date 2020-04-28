namespace QuarterBill
{
    partial class Form1
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
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txbQtrOne = new System.Windows.Forms.TextBox();
            this.txbQtrTwo = new System.Windows.Forms.TextBox();
            this.txbQtrFour = new System.Windows.Forms.TextBox();
            this.txbQtrThree = new System.Windows.Forms.TextBox();
            this.txbAverage = new System.Windows.Forms.TextBox();
            this.txbTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(142, 240);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(100, 28);
            this.btnCalculate.TabIndex = 0;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txbQtrOne
            // 
            this.txbQtrOne.Location = new System.Drawing.Point(142, 38);
            this.txbQtrOne.Name = "txbQtrOne";
            this.txbQtrOne.Size = new System.Drawing.Size(100, 22);
            this.txbQtrOne.TabIndex = 1;
            // 
            // txbQtrTwo
            // 
            this.txbQtrTwo.Location = new System.Drawing.Point(142, 85);
            this.txbQtrTwo.Name = "txbQtrTwo";
            this.txbQtrTwo.Size = new System.Drawing.Size(100, 22);
            this.txbQtrTwo.TabIndex = 2;
            // 
            // txbQtrFour
            // 
            this.txbQtrFour.Location = new System.Drawing.Point(142, 177);
            this.txbQtrFour.Name = "txbQtrFour";
            this.txbQtrFour.Size = new System.Drawing.Size(100, 22);
            this.txbQtrFour.TabIndex = 4;
            // 
            // txbQtrThree
            // 
            this.txbQtrThree.Location = new System.Drawing.Point(142, 130);
            this.txbQtrThree.Name = "txbQtrThree";
            this.txbQtrThree.Size = new System.Drawing.Size(100, 22);
            this.txbQtrThree.TabIndex = 3;
            // 
            // txbAverage
            // 
            this.txbAverage.Location = new System.Drawing.Point(371, 177);
            this.txbAverage.Name = "txbAverage";
            this.txbAverage.ReadOnly = true;
            this.txbAverage.Size = new System.Drawing.Size(100, 22);
            this.txbAverage.TabIndex = 6;
            // 
            // txbTotal
            // 
            this.txbTotal.Location = new System.Drawing.Point(371, 130);
            this.txbTotal.Name = "txbTotal";
            this.txbTotal.ReadOnly = true;
            this.txbTotal.Size = new System.Drawing.Size(100, 22);
            this.txbTotal.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "First Quarter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Second Quarter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Third Quarter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fourth Quarter";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Total";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(304, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Average";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 309);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbAverage);
            this.Controls.Add(this.txbTotal);
            this.Controls.Add(this.txbQtrFour);
            this.Controls.Add(this.txbQtrThree);
            this.Controls.Add(this.txbQtrTwo);
            this.Controls.Add(this.txbQtrOne);
            this.Controls.Add(this.btnCalculate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Average Quarterly Bill";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txbQtrOne;
        private System.Windows.Forms.TextBox txbQtrTwo;
        private System.Windows.Forms.TextBox txbQtrFour;
        private System.Windows.Forms.TextBox txbQtrThree;
        private System.Windows.Forms.TextBox txbAverage;
        private System.Windows.Forms.TextBox txbTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

