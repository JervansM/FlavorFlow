namespace FlavorFlowIT13
{
    partial class HrPayrollPeriods
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
            Addperiod = new Button();
            datapayrollperiod = new DataGridView();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)datapayrollperiod).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Addperiod
            // 
            Addperiod.Font = new Font("Segoe UI", 20F);
            Addperiod.Location = new Point(431, 574);
            Addperiod.Name = "Addperiod";
            Addperiod.Size = new Size(235, 70);
            Addperiod.TabIndex = 50;
            Addperiod.Text = "Add";
            Addperiod.UseVisualStyleBackColor = true;
            Addperiod.Click += Addperiod_Click;
            // 
            // datapayrollperiod
            // 
            datapayrollperiod.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datapayrollperiod.Location = new Point(0, 0);
            datapayrollperiod.Name = "datapayrollperiod";
            datapayrollperiod.RowHeadersWidth = 51;
            datapayrollperiod.Size = new Size(1407, 533);
            datapayrollperiod.TabIndex = 0;
            datapayrollperiod.CellContentClick += datapayrollperiod_CellContentClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(datapayrollperiod);
            panel1.ForeColor = Color.Black;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1407, 533);
            panel1.TabIndex = 48;
            panel1.Paint += panel1_Paint;
            // 
            // HrPayrollPeriods
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(1419, 769);
            Controls.Add(Addperiod);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "HrPayrollPeriods";
            Text = "HrPayrollPeriods";
            Load += HrPayrollPeriods_Load;
            ((System.ComponentModel.ISupportInitialize)datapayrollperiod).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button Addperiod;
        private DataGridView datapayrollperiod;
    }
}