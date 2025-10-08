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
            addnewschedulebtn = new Button();
            systemsearchbarpanel = new Panel();
            systemsearchbaricon = new PictureBox();
            systemsearchbar = new TextBox();
            systempanelcontents = new Panel();
            scheduleGrid = new DataGridView();
            hrscheduledailyttendancebtn = new Button();
            hrscheduleschedulebtn = new Button();
            panelContent.SuspendLayout();
            systemsearchbarpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)systemsearchbaricon).BeginInit();
            systempanelcontents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scheduleGrid).BeginInit();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.AutoScroll = true;
            panelContent.BackColor = Color.Silver;
            panelContent.Controls.Add(addnewschedulebtn);
            panelContent.Controls.Add(systemsearchbarpanel);
            panelContent.Controls.Add(systempanelcontents);
            panelContent.Controls.Add(hrscheduledailyttendancebtn);
            panelContent.Controls.Add(hrscheduleschedulebtn);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1942, 1102);
            panelContent.TabIndex = 0;
            // 
            // addnewschedulebtn
            // 
            addnewschedulebtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            addnewschedulebtn.Location = new Point(590, 747);
            addnewschedulebtn.Name = "addnewschedulebtn";
            addnewschedulebtn.Size = new Size(317, 74);
            addnewschedulebtn.TabIndex = 25;
            addnewschedulebtn.Text = "Add New Schedule";
            addnewschedulebtn.UseVisualStyleBackColor = true;
            addnewschedulebtn.Click += addnewschedulebtn_Click_2;
            // 
            // systemsearchbarpanel
            // 
            systemsearchbarpanel.BackColor = Color.White;
            systemsearchbarpanel.Controls.Add(systemsearchbaricon);
            systemsearchbarpanel.Controls.Add(systemsearchbar);
            systemsearchbarpanel.Location = new Point(14, 19);
            systemsearchbarpanel.Name = "systemsearchbarpanel";
            systemsearchbarpanel.Size = new Size(1737, 79);
            systemsearchbarpanel.TabIndex = 24;
            // 
            // systemsearchbaricon
            // 
            systemsearchbaricon.Image = Properties.Resources.searchbar_removebg_preview;
            systemsearchbaricon.Location = new Point(1641, 9);
            systemsearchbaricon.Name = "systemsearchbaricon";
            systemsearchbaricon.Size = new Size(93, 61);
            systemsearchbaricon.SizeMode = PictureBoxSizeMode.Zoom;
            systemsearchbaricon.TabIndex = 0;
            systemsearchbaricon.TabStop = false;
            // 
            // systemsearchbar
            // 
            systemsearchbar.BorderStyle = BorderStyle.None;
            systemsearchbar.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            systemsearchbar.ForeColor = Color.Black;
            systemsearchbar.Location = new Point(34, 12);
            systemsearchbar.Multiline = true;
            systemsearchbar.Name = "systemsearchbar";
            systemsearchbar.PlaceholderText = "Search";
            systemsearchbar.Size = new Size(1600, 63);
            systemsearchbar.TabIndex = 22;
            // 
            // systempanelcontents
            // 
            systempanelcontents.BackColor = Color.White;
            systempanelcontents.Controls.Add(scheduleGrid);
            systempanelcontents.Location = new Point(14, 205);
            systempanelcontents.Name = "systempanelcontents";
            systempanelcontents.Size = new Size(1737, 500);
            systempanelcontents.TabIndex = 2;
            // 
            // scheduleGrid
            // 
            scheduleGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            scheduleGrid.Dock = DockStyle.Fill;
            scheduleGrid.Location = new Point(0, 0);
            scheduleGrid.Name = "scheduleGrid";
            scheduleGrid.RowHeadersWidth = 51;
            scheduleGrid.Size = new Size(1737, 500);
            scheduleGrid.TabIndex = 0;
            scheduleGrid.CellContentClick += scheduleGrid_CellContentClick;
            // 
            // hrscheduledailyttendancebtn
            // 
            hrscheduledailyttendancebtn.BackColor = Color.Black;
            hrscheduledailyttendancebtn.FlatStyle = FlatStyle.Flat;
            hrscheduledailyttendancebtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            hrscheduledailyttendancebtn.ForeColor = Color.White;
            hrscheduledailyttendancebtn.Location = new Point(38, 105);
            hrscheduledailyttendancebtn.Name = "hrscheduledailyttendancebtn";
            hrscheduledailyttendancebtn.Size = new Size(389, 77);
            hrscheduledailyttendancebtn.TabIndex = 4;
            hrscheduledailyttendancebtn.Text = "Daily Attendance";
            hrscheduledailyttendancebtn.UseVisualStyleBackColor = false;
            hrscheduledailyttendancebtn.Click += hrscheduledailyttendancebtn_Click_1;
            // 
            // hrscheduleschedulebtn
            // 
            hrscheduleschedulebtn.BackColor = Color.Black;
            hrscheduleschedulebtn.FlatStyle = FlatStyle.Flat;
            hrscheduleschedulebtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            hrscheduleschedulebtn.ForeColor = Color.White;
            hrscheduleschedulebtn.Location = new Point(492, 105);
            hrscheduleschedulebtn.Name = "hrscheduleschedulebtn";
            hrscheduleschedulebtn.Size = new Size(389, 77);
            hrscheduleschedulebtn.TabIndex = 3;
            hrscheduleschedulebtn.Text = "Schedule";
            hrscheduleschedulebtn.UseVisualStyleBackColor = false;
            hrscheduleschedulebtn.Click += hrscheduleschedulebtn_Click;
            // 
            // HrSchedule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1942, 1102);
            Controls.Add(panelContent);
            FormBorderStyle = FormBorderStyle.None;
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
        private System.Windows.Forms.Button addnewschedulebtn;
    }
}
