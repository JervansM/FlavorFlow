namespace FlavorFlowIT13
{
    partial class HrSchedule
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
            panelContent = new Panel();
            systemsearchbarpanel = new Panel();
            pictureBox1 = new PictureBox();
            systemsearchbar = new TextBox();
            systempanelcontents = new Panel();
            scheduleGrid = new DataGridView();
            hrscheduleschedulebtn = new Button();
            hrscheduledailyttendancebtn = new Button();
            panelContent.SuspendLayout();
            systemsearchbarpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            systempanelcontents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scheduleGrid).BeginInit();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.AutoScroll = true;
            panelContent.BackColor = Color.Silver;
            panelContent.Controls.Add(systemsearchbarpanel);
            panelContent.Controls.Add(systempanelcontents);
            panelContent.Controls.Add(hrscheduleschedulebtn);
            panelContent.Controls.Add(hrscheduledailyttendancebtn);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Margin = new Padding(3, 2, 3, 2);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1940, 1047);
            panelContent.TabIndex = 0;
            panelContent.Paint += panelContent_Paint_1;
            // 
            // systemsearchbarpanel
            // 
            systemsearchbarpanel.BackColor = Color.White;
            systemsearchbarpanel.Controls.Add(pictureBox1);
            systemsearchbarpanel.Controls.Add(systemsearchbar);
            systemsearchbarpanel.Location = new Point(12, 14);
            systemsearchbarpanel.Name = "systemsearchbarpanel";
            systemsearchbarpanel.Size = new Size(1520, 59);
            systemsearchbarpanel.TabIndex = 24;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = Properties.Resources.searchbar_removebg_preview;
            pictureBox1.Location = new Point(1436, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(81, 46);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // systemsearchbar
            // 
            systemsearchbar.Anchor = AnchorStyles.None;
            systemsearchbar.BorderStyle = BorderStyle.None;
            systemsearchbar.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            systemsearchbar.ForeColor = Color.Black;
            systemsearchbar.Location = new Point(19, 6);
            systemsearchbar.Multiline = true;
            systemsearchbar.Name = "systemsearchbar";
            systemsearchbar.PlaceholderText = "Search";
            systemsearchbar.Size = new Size(1476, 47);
            systemsearchbar.TabIndex = 22;
            systemsearchbar.TextChanged += systemsearchbar_TextChanged_1;
            // 
            // systempanelcontents
            // 
            systempanelcontents.BackColor = Color.White;
            systempanelcontents.Controls.Add(scheduleGrid);
            systempanelcontents.Location = new Point(12, 180);
            systempanelcontents.Margin = new Padding(3, 2, 3, 2);
            systempanelcontents.Name = "systempanelcontents";
            systempanelcontents.Size = new Size(1520, 799);
            systempanelcontents.TabIndex = 2;
            // 
            // scheduleGrid
            // 
            scheduleGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            scheduleGrid.Dock = DockStyle.Fill;
            scheduleGrid.Location = new Point(0, 0);
            scheduleGrid.Margin = new Padding(3, 2, 3, 2);
            scheduleGrid.Name = "scheduleGrid";
            scheduleGrid.RowHeadersWidth = 51;
            scheduleGrid.Size = new Size(1520, 799);
            scheduleGrid.TabIndex = 0;
            scheduleGrid.CellContentClick += scheduleGrid_CellContentClick_1;
            // 
            // hrscheduleschedulebtn
            // 
            hrscheduleschedulebtn.BackColor = Color.Black;
            hrscheduleschedulebtn.Cursor = Cursors.Hand;
            hrscheduleschedulebtn.FlatStyle = FlatStyle.Flat;
            hrscheduleschedulebtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            hrscheduleschedulebtn.ForeColor = Color.White;
            hrscheduleschedulebtn.Location = new Point(391, 89);
            hrscheduleschedulebtn.Margin = new Padding(3, 2, 3, 2);
            hrscheduleschedulebtn.Name = "hrscheduleschedulebtn";
            hrscheduleschedulebtn.Size = new Size(340, 58);
            hrscheduleschedulebtn.TabIndex = 3;
            hrscheduleschedulebtn.Text = "Schedule";
            hrscheduleschedulebtn.UseVisualStyleBackColor = false;
            hrscheduleschedulebtn.Click += hrscheduleschedulebtn_Click;
            // 
            // hrscheduledailyttendancebtn
            // 
            hrscheduledailyttendancebtn.BackColor = Color.Black;
            hrscheduledailyttendancebtn.Cursor = Cursors.Hand;
            hrscheduledailyttendancebtn.FlatStyle = FlatStyle.Flat;
            hrscheduledailyttendancebtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            hrscheduledailyttendancebtn.ForeColor = Color.White;
            hrscheduledailyttendancebtn.Location = new Point(12, 89);
            hrscheduledailyttendancebtn.Margin = new Padding(3, 2, 3, 2);
            hrscheduledailyttendancebtn.Name = "hrscheduledailyttendancebtn";
            hrscheduledailyttendancebtn.Size = new Size(340, 58);
            hrscheduledailyttendancebtn.TabIndex = 4;
            hrscheduledailyttendancebtn.Text = "Daily Attendance";
            hrscheduledailyttendancebtn.UseVisualStyleBackColor = false;
            hrscheduledailyttendancebtn.Click += hrscheduledailyttendancebtn_Click;
            // 
            // HrSchedule
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1940, 1047);
            Controls.Add(panelContent);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "HrSchedule";
            Text = "HR Schedule";
            Load += HrSchedule_Load;
            panelContent.ResumeLayout(false);
            systemsearchbarpanel.ResumeLayout(false);
            systemsearchbarpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            systempanelcontents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scheduleGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel systempanelcontents;
        private System.Windows.Forms.DataGridView scheduleGrid;
        private System.Windows.Forms.Button hrscheduleschedulebtn;
        private System.Windows.Forms.Button hrscheduledailyttendancebtn;
        private Panel systemsearchbarpanel;
        private PictureBox pictureBox1;
        private TextBox systemsearchbar;
    }
}
