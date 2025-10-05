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
            systemsearchbaricon = new PictureBox();
            systemsearchbar = new TextBox();
            systempanelcontents = new Panel();
            scheduleGrid = new DataGridView();
            hrscheduleschedulebtn = new Button();
            hrscheduledailyttendancebtn = new Button();
            panelContent.SuspendLayout();
            systemsearchbarpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)systemsearchbaricon).BeginInit();
            systempanelcontents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scheduleGrid).BeginInit();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.Silver;
            panelContent.Controls.Add(systemsearchbarpanel);
            panelContent.Controls.Add(systempanelcontents);
            panelContent.Controls.Add(hrscheduleschedulebtn);
            panelContent.Controls.Add(hrscheduledailyttendancebtn);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Margin = new Padding(3, 2, 3, 2);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1050, 525);
            panelContent.TabIndex = 0;
            panelContent.Paint += panelContent_Paint_1;
            // 
            // systemsearchbarpanel
            // 
            systemsearchbarpanel.BackColor = Color.White;
            systemsearchbarpanel.Controls.Add(systemsearchbaricon);
            systemsearchbarpanel.Controls.Add(systemsearchbar);
            systemsearchbarpanel.Location = new Point(18, 165);
            systemsearchbarpanel.Margin = new Padding(3, 2, 3, 2);
            systemsearchbarpanel.Name = "systemsearchbarpanel";
            systemsearchbarpanel.Size = new Size(1006, 38);
            systemsearchbarpanel.TabIndex = 1;
            // 
            // systemsearchbaricon
            // 
            systemsearchbaricon.Image = Properties.Resources.searchbar_removebg_preview;
            systemsearchbaricon.Location = new Point(954, 4);
            systemsearchbaricon.Margin = new Padding(3, 2, 3, 2);
            systemsearchbaricon.Name = "systemsearchbaricon";
            systemsearchbaricon.Size = new Size(39, 30);
            systemsearchbaricon.SizeMode = PictureBoxSizeMode.Zoom;
            systemsearchbaricon.TabIndex = 0;
            systemsearchbaricon.TabStop = false;
            // 
            // systemsearchbar
            // 
            systemsearchbar.BorderStyle = BorderStyle.None;
            systemsearchbar.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            systemsearchbar.ForeColor = Color.Black;
            systemsearchbar.Location = new Point(9, 8);
            systemsearchbar.Margin = new Padding(3, 2, 3, 2);
            systemsearchbar.Name = "systemsearchbar";
            systemsearchbar.PlaceholderText = "Search...";
            systemsearchbar.Size = new Size(936, 25);
            systemsearchbar.TabIndex = 0;
            // 
            // systempanelcontents
            // 
            systempanelcontents.BackColor = Color.White;
            systempanelcontents.Controls.Add(scheduleGrid);
            systempanelcontents.Location = new Point(18, 112);
            systempanelcontents.Margin = new Padding(3, 2, 3, 2);
            systempanelcontents.Name = "systempanelcontents";
            systempanelcontents.Size = new Size(1006, 375);
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
            scheduleGrid.Size = new Size(1006, 375);
            scheduleGrid.TabIndex = 0;
            // 
            // hrscheduleschedulebtn
            // 
            hrscheduleschedulebtn.BackColor = Color.Black;
            hrscheduleschedulebtn.FlatStyle = FlatStyle.Flat;
            hrscheduleschedulebtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            hrscheduleschedulebtn.ForeColor = Color.White;
            hrscheduleschedulebtn.Location = new Point(551, 60);
            hrscheduleschedulebtn.Margin = new Padding(3, 2, 3, 2);
            hrscheduleschedulebtn.Name = "hrscheduleschedulebtn";
            hrscheduleschedulebtn.Size = new Size(219, 38);
            hrscheduleschedulebtn.TabIndex = 3;
            hrscheduleschedulebtn.Text = "Schedule";
            hrscheduleschedulebtn.UseVisualStyleBackColor = false;
            hrscheduleschedulebtn.Click += hrscheduleschedulebtn_Click;
            // 
            // hrscheduledailyttendancebtn
            // 
            hrscheduledailyttendancebtn.BackColor = Color.Black;
            hrscheduledailyttendancebtn.FlatStyle = FlatStyle.Flat;
            hrscheduledailyttendancebtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            hrscheduledailyttendancebtn.ForeColor = Color.White;
            hrscheduledailyttendancebtn.Location = new Point(306, 60);
            hrscheduledailyttendancebtn.Margin = new Padding(3, 2, 3, 2);
            hrscheduledailyttendancebtn.Name = "hrscheduledailyttendancebtn";
            hrscheduledailyttendancebtn.Size = new Size(219, 38);
            hrscheduledailyttendancebtn.TabIndex = 4;
            hrscheduledailyttendancebtn.Text = "Daily Attendance";
            hrscheduledailyttendancebtn.UseVisualStyleBackColor = false;
            hrscheduledailyttendancebtn.Click += hrscheduledailyttendancebtn_Click;
            // 
            // HrSchedule
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 525);
            Controls.Add(panelContent);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "HrSchedule";
            Text = "HR Schedule";
            Load += HrSchedule_Load;
            panelContent.ResumeLayout(false);
            systemsearchbarpanel.ResumeLayout(false);
            systemsearchbarpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)systemsearchbaricon).EndInit();
            systempanelcontents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scheduleGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel systemsearchbarpanel;
        private System.Windows.Forms.PictureBox systemsearchbaricon;
        private System.Windows.Forms.TextBox systemsearchbar;
        private System.Windows.Forms.Panel systempanelcontents;
        private System.Windows.Forms.DataGridView scheduleGrid;
        private System.Windows.Forms.Button hrscheduleschedulebtn;
        private System.Windows.Forms.Button hrscheduledailyttendancebtn;
    }
}
