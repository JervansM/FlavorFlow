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
            this.panelContent = new System.Windows.Forms.Panel();
            this.systemsearchbarpanel = new System.Windows.Forms.Panel();
            this.systemsearchbaricon = new System.Windows.Forms.PictureBox();
            this.systemsearchbar = new System.Windows.Forms.TextBox();
            this.systempanelcontents = new System.Windows.Forms.Panel();
            this.scheduleGrid = new System.Windows.Forms.DataGridView();
            this.hrscheduleschedulebtn = new System.Windows.Forms.Button();
            this.hrscheduledailyttendancebtn = new System.Windows.Forms.Button();

            this.panelContent.SuspendLayout();
            this.systemsearchbarpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.systemsearchbaricon)).BeginInit();
            this.systempanelcontents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleGrid)).BeginInit();
            this.SuspendLayout();

            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.Silver;
            this.panelContent.Controls.Add(this.systemsearchbarpanel);
            this.panelContent.Controls.Add(this.systempanelcontents);
            this.panelContent.Controls.Add(this.hrscheduleschedulebtn);
            this.panelContent.Controls.Add(this.hrscheduledailyttendancebtn);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1200, 700);
            this.panelContent.TabIndex = 0;

            // 
            // systemsearchbarpanel
            // 
            this.systemsearchbarpanel.BackColor = System.Drawing.Color.White;
            this.systemsearchbarpanel.Controls.Add(this.systemsearchbaricon);
            this.systemsearchbarpanel.Controls.Add(this.systemsearchbar);
            this.systemsearchbarpanel.Location = new System.Drawing.Point(20, 220);
            this.systemsearchbarpanel.Location = new System.Drawing.Point(20, 220);
            this.systemsearchbarpanel.Name = "systemsearchbarpanel";
            this.systemsearchbarpanel.Size = new System.Drawing.Size(1150, 50);
            this.systemsearchbarpanel.TabIndex = 1;

            // 
            // systemsearchbaricon
            // 
            this.systemsearchbaricon.Image = global::FlavorFlowIT13.Properties.Resources.searchbar_removebg_preview;
            this.systemsearchbaricon.Location = new System.Drawing.Point(1090, 5);
            this.systemsearchbaricon.Size = new System.Drawing.Size(45, 40);
            this.systemsearchbaricon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.systemsearchbaricon.TabStop = false;

            // 
            // systemsearchbar
            // 
            this.systemsearchbar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.systemsearchbar.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.systemsearchbar.ForeColor = System.Drawing.Color.Black;
            this.systemsearchbar.PlaceholderText = "Search...";
            this.systemsearchbar.Location = new System.Drawing.Point(10, 10);
            this.systemsearchbar.Size = new System.Drawing.Size(1070, 32);
            this.systemsearchbar.TabIndex = 0;

            // 
            // systempanelcontents
            // 
            this.systempanelcontents.BackColor = System.Drawing.Color.White;
            this.systempanelcontents.Controls.Add(this.scheduleGrid);
            this.systempanelcontents.Location = new System.Drawing.Point(20, 150);
            this.systempanelcontents.Name = "systempanelcontents";
            this.systempanelcontents.Size = new System.Drawing.Size(1150, 500);
            this.systempanelcontents.TabIndex = 2;

            // 
            // scheduleGrid
            // 
            this.scheduleGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scheduleGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduleGrid.Location = new System.Drawing.Point(0, 0);
            this.scheduleGrid.Name = "scheduleGrid";
            this.scheduleGrid.RowHeadersWidth = 51;
            this.scheduleGrid.Size = new System.Drawing.Size(1150, 500);
            this.scheduleGrid.TabIndex = 0;

            // 
            // hrscheduleschedulebtn
            // 
            this.hrscheduleschedulebtn.BackColor = System.Drawing.Color.Black;
            this.hrscheduleschedulebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hrscheduleschedulebtn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.hrscheduleschedulebtn.ForeColor = System.Drawing.Color.White;
            this.hrscheduleschedulebtn.Location = new System.Drawing.Point(630, 80);
            this.hrscheduleschedulebtn.Name = "hrscheduleschedulebtn";
            this.hrscheduleschedulebtn.Size = new System.Drawing.Size(250, 50);
            this.hrscheduleschedulebtn.TabIndex = 3;
            this.hrscheduleschedulebtn.Text = "Schedule";
            this.hrscheduleschedulebtn.UseVisualStyleBackColor = false;
            this.hrscheduleschedulebtn.Click += new System.EventHandler(this.hrscheduleschedulebtn_Click);

            // 
            // hrscheduledailyttendancebtn
            // 
            this.hrscheduledailyttendancebtn.BackColor = System.Drawing.Color.Black;
            this.hrscheduledailyttendancebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hrscheduledailyttendancebtn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.hrscheduledailyttendancebtn.ForeColor = System.Drawing.Color.White;
            this.hrscheduledailyttendancebtn.Location = new System.Drawing.Point(350, 80);
            this.hrscheduledailyttendancebtn.Name = "hrscheduledailyttendancebtn";
            this.hrscheduledailyttendancebtn.Size = new System.Drawing.Size(250, 50);
            this.hrscheduledailyttendancebtn.TabIndex = 4;
            this.hrscheduledailyttendancebtn.Text = "Daily Attendance";
            this.hrscheduledailyttendancebtn.UseVisualStyleBackColor = false;
            this.hrscheduledailyttendancebtn.Click += new System.EventHandler(this.hrscheduledailyttendancebtn_Click);

            // 
            // HrSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HrSchedule";
            this.Text = "HR Schedule";
            this.Load += new System.EventHandler(this.HrSchedule_Load); // ✅ ADD THIS HERE

            this.panelContent.ResumeLayout(false);
            this.systemsearchbarpanel.ResumeLayout(false);
            this.systemsearchbarpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.systemsearchbaricon)).EndInit();
            this.systempanelcontents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scheduleGrid)).EndInit();
            this.ResumeLayout(false);
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
