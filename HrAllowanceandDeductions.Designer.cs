namespace FlavorFlowIT13
{
    partial class HrAllowanceandDeductions
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panel1 = new Panel();
            dataallowanceanddeductions = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataallowanceanddeductions).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(dataallowanceanddeductions);
            panel1.ForeColor = Color.Black;
            panel1.Location = new Point(0, 68);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1414, 533);
            panel1.TabIndex = 52;
            // 
            // dataallowanceanddeductions
            // 
            dataallowanceanddeductions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataallowanceanddeductions.Location = new Point(3, 0);
            dataallowanceanddeductions.Name = "dataallowanceanddeductions";
            dataallowanceanddeductions.RowHeadersWidth = 51;
            dataallowanceanddeductions.Size = new Size(1411, 533);
            dataallowanceanddeductions.TabIndex = 0;
            dataallowanceanddeductions.CellContentClick += dataallowanceanddeductions_CellContentClick;
            // 
            // HrAllowanceandDeductions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(1419, 769);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "HrAllowanceandDeductions";
            Text = "HrAllowanceandDeductions";
            Load += HrAllowanceandDeductions_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataallowanceanddeductions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataallowanceanddeductions;
    }
}
