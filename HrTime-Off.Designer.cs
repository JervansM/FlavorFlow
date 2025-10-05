namespace FlavorFlowIT13
{
    partial class HrTime_Off
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            panelContent = new Panel();
            hrleaveviewbalancebtn = new Button();
            hraddnewtimeoffbtn = new Button();
            datatimeoff = new DataGridView();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)datatimeoff).BeginInit();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.Silver;
            panelContent.Controls.Add(hrleaveviewbalancebtn);
            panelContent.Controls.Add(hraddnewtimeoffbtn);
            panelContent.Controls.Add(datatimeoff);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Margin = new Padding(3, 2, 3, 2);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(0, 4, 0, 0);
            panelContent.Size = new Size(1318, 641);
            panelContent.TabIndex = 5;
            panelContent.Paint += panelContent_Paint;
            // 
            // hrleaveviewbalancebtn
            // 
            hrleaveviewbalancebtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            hrleaveviewbalancebtn.Location = new Point(720, 500);
            hrleaveviewbalancebtn.Margin = new Padding(3, 2, 3, 2);
            hrleaveviewbalancebtn.Name = "hrleaveviewbalancebtn";
            hrleaveviewbalancebtn.Size = new Size(234, 50);
            hrleaveviewbalancebtn.TabIndex = 2;
            hrleaveviewbalancebtn.Text = "View Balance";
            hrleaveviewbalancebtn.UseVisualStyleBackColor = true;
            hrleaveviewbalancebtn.Click += hrleaveviewbalancebtn_Click;
            // 
            // hraddnewtimeoffbtn
            // 
            hraddnewtimeoffbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            hraddnewtimeoffbtn.Location = new Point(350, 500);
            hraddnewtimeoffbtn.Margin = new Padding(3, 2, 3, 2);
            hraddnewtimeoffbtn.Name = "hraddnewtimeoffbtn";
            hraddnewtimeoffbtn.Size = new Size(243, 50);
            hraddnewtimeoffbtn.TabIndex = 1;
            hraddnewtimeoffbtn.Text = "Add Time-Off";
            hraddnewtimeoffbtn.UseVisualStyleBackColor = true;
            hraddnewtimeoffbtn.Click += hrleaveaddnewtimeoffbtn_Click;
            // 
            // datatimeoff
            // 
            datatimeoff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datatimeoff.Location = new Point(10, 77);
            datatimeoff.Margin = new Padding(3, 2, 3, 2);
            datatimeoff.Name = "datatimeoff";
            datatimeoff.RowHeadersWidth = 51;
            datatimeoff.Size = new Size(1229, 385);
            datatimeoff.TabIndex = 0;
            datatimeoff.CellContentClick += dataGridView1_CellContentClick;
            // 
            // HrTime_Off
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelContent);
            Margin = new Padding(3, 2, 3, 2);
            Name = "HrTime_Off";
            Size = new Size(1318, 641);
            Load += HrTime_Off_Load;
            panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)datatimeoff).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContent;
        private DataGridView datatimeoff;
        private Button hrleaveviewbalancebtn;
        private Button hraddnewtimeoffbtn;
    }
}
