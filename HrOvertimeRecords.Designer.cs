namespace FlavorFlowIT13
{
    partial class HrOvertimeRecords
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
            dataovertimerecords = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataovertimerecords).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(dataovertimerecords);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(12, 30);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1398, 533);
            panel1.TabIndex = 52;
            // 
            // dataovertimerecords
            // 
            dataovertimerecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataovertimerecords.Location = new Point(0, 0);
            dataovertimerecords.Name = "dataovertimerecords";
            dataovertimerecords.RowHeadersWidth = 51;
            dataovertimerecords.Size = new Size(1395, 533);
            dataovertimerecords.TabIndex = 0;
            // 
            // HrOvertimeRecords
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(1419, 769);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "HrOvertimeRecords";
            Text = "HrOvertimeRecords";
            Load += HrOvertimeRecords_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataovertimerecords).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button hrovertimerecordsovertimerecordstxt;
        private Button hrovertimerecordsallowanceanddeductionstxt;
        private Button hrovertimerecordsgeneratepayrolltxt;
        private Button hrovertimerecordspayrollperiodstxt;
        private Panel panel1;
        private Panel panel2;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label4;
        private Label label1;
        private Label label6;
        private DataGridView dataovertimerecords;
    }
}