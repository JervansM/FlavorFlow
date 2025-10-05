namespace FlavorFlowIT13
{
    partial class HrGeneratePayroll
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
            panel1 = new Panel();
            datageneratepayroll = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)datageneratepayroll).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(datageneratepayroll);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(2, 46);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1412, 533);
            panel1.TabIndex = 52;
            // 
            // datageneratepayroll
            // 
            datageneratepayroll.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datageneratepayroll.Location = new Point(-2, 0);
            datageneratepayroll.Name = "datageneratepayroll";
            datageneratepayroll.RowHeadersWidth = 51;
            datageneratepayroll.Size = new Size(1414, 533);
            datageneratepayroll.TabIndex = 0;
            datageneratepayroll.CellContentClick += datageneratepayroll_CellContentClick;
            // 
            // HrGeneratePayroll
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(1419, 769);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "HrGeneratePayroll";
            Text = "HrGeneratePayroll";
            Load += HrGeneratePayroll_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)datageneratepayroll).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private DataGridView datageneratepayroll;
    }
}