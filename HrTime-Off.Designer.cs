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
            hrtimeoffviewbalancebtn = new Button();
            hraddnewtimeoffbtn = new Button();
            datatimeoff = new DataGridView();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)datatimeoff).BeginInit();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.Silver;
            panelContent.Controls.Add(hrtimeoffviewbalancebtn);
            panelContent.Controls.Add(hraddnewtimeoffbtn);
            panelContent.Controls.Add(datatimeoff);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1506, 855);
            panelContent.TabIndex = 5;
            // 
            // hrtimeoffviewbalancebtn
            // 
            hrtimeoffviewbalancebtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            hrtimeoffviewbalancebtn.Location = new Point(817, 592);
            hrtimeoffviewbalancebtn.Name = "hrtimeoffviewbalancebtn";
            hrtimeoffviewbalancebtn.Size = new Size(267, 66);
            hrtimeoffviewbalancebtn.TabIndex = 2;
            hrtimeoffviewbalancebtn.Text = "View Balance";
            hrtimeoffviewbalancebtn.UseVisualStyleBackColor = true;
            hrtimeoffviewbalancebtn.Click += hrtimeoffviewbalancebtn_Click;
            // 
            // hraddnewtimeoffbtn
            // 
            hraddnewtimeoffbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            hraddnewtimeoffbtn.Location = new Point(472, 592);
            hraddnewtimeoffbtn.Name = "hraddnewtimeoffbtn";
            hraddnewtimeoffbtn.Size = new Size(278, 66);
            hraddnewtimeoffbtn.TabIndex = 1;
            hraddnewtimeoffbtn.Text = "Add Time-Off";
            hraddnewtimeoffbtn.UseVisualStyleBackColor = true;
            hraddnewtimeoffbtn.Click += hraddnewtimeoffbtn_Click;
            // 
            // datatimeoff
            // 
            datatimeoff.BackgroundColor = Color.White;
            datatimeoff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datatimeoff.Location = new Point(3, 15);
            datatimeoff.Name = "datatimeoff";
            datatimeoff.RowHeadersWidth = 51;
            datatimeoff.Size = new Size(1482, 513);
            datatimeoff.TabIndex = 0;
            datatimeoff.CellContentClick += datatimeoff_CellContentClick;
            // 
            // HrTime_Off
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelContent);
            Name = "HrTime_Off";
            Size = new Size(1506, 855);
            Load += HrTime_Off_Load;
            panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)datatimeoff).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContent;
        private DataGridView datatimeoff;
        private Button hrtimeoffviewbalancebtn;
        private Button hraddnewtimeoffbtn;
    }
}
