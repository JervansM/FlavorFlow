namespace FlavorFlowIT13
{
    partial class HrAttendance
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
            panelContent = new Panel();
            hrattendanceadd = new Button();
            systemsearchbarpanel = new Panel();
            systemsearchbaricon = new PictureBox();
            systemsearchbar = new TextBox();
            panel5 = new Panel();
            label10 = new Label();
            hrattendancesdatetxt = new TextBox();
            systempanelcontents = new Panel();
            dgvAttendance = new DataGridView();
            hrattendanceschedulebtn = new Button();
            hrattendancedailyttendancebtn = new Button();
            panelContent.SuspendLayout();
            systemsearchbarpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)systemsearchbaricon).BeginInit();
            panel5.SuspendLayout();
            systempanelcontents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).BeginInit();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.AutoScroll = true;
            panelContent.BackColor = Color.Silver;
            panelContent.Controls.Add(hrattendanceadd);
            panelContent.Controls.Add(systemsearchbarpanel);
            panelContent.Controls.Add(panel5);
            panelContent.Controls.Add(systempanelcontents);
            panelContent.Controls.Add(hrattendanceschedulebtn);
            panelContent.Controls.Add(hrattendancedailyttendancebtn);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1924, 1061);
            panelContent.TabIndex = 4;
            panelContent.Paint += panelContent_Paint;
            // 
            // hrattendanceadd
            // 
            hrattendanceadd.BackColor = Color.Black;
            hrattendanceadd.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            hrattendanceadd.ForeColor = Color.White;
            hrattendanceadd.Location = new Point(1032, 90);
            hrattendanceadd.Margin = new Padding(3, 2, 3, 2);
            hrattendanceadd.Name = "hrattendanceadd";
            hrattendanceadd.Size = new Size(309, 58);
            hrattendanceadd.TabIndex = 51;
            hrattendanceadd.Text = "Add New Attendance";
            hrattendanceadd.UseVisualStyleBackColor = false;
            hrattendanceadd.Click += hrattendanceadd_Click;
            // 
            // systemsearchbarpanel
            // 
            systemsearchbarpanel.BackColor = Color.White;
            systemsearchbarpanel.Controls.Add(systemsearchbaricon);
            systemsearchbarpanel.Controls.Add(systemsearchbar);
            systemsearchbarpanel.Location = new Point(12, 13);
            systemsearchbarpanel.Name = "systemsearchbarpanel";
            systemsearchbarpanel.Size = new Size(1510, 59);
            systemsearchbarpanel.TabIndex = 23;
            // 
            // systemsearchbaricon
            // 
            systemsearchbaricon.BackColor = Color.Transparent;
            systemsearchbaricon.BackgroundImageLayout = ImageLayout.None;
            systemsearchbaricon.Image = Properties.Resources.searchbar_removebg_preview;
            systemsearchbaricon.Location = new Point(1436, 7);
            systemsearchbaricon.Name = "systemsearchbaricon";
            systemsearchbaricon.Size = new Size(81, 46);
            systemsearchbaricon.SizeMode = PictureBoxSizeMode.Zoom;
            systemsearchbaricon.TabIndex = 23;
            systemsearchbaricon.TabStop = false;
            // 
            // systemsearchbar
            // 
            systemsearchbar.Anchor = AnchorStyles.None;
            systemsearchbar.BorderStyle = BorderStyle.None;
            systemsearchbar.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            systemsearchbar.ForeColor = Color.Black;
            systemsearchbar.Location = new Point(35, 6);
            systemsearchbar.Multiline = true;
            systemsearchbar.Name = "systemsearchbar";
            systemsearchbar.PlaceholderText = "Search";
            systemsearchbar.Size = new Size(1476, 47);
            systemsearchbar.TabIndex = 22;
            systemsearchbar.TextChanged += systemsearchbar_TextChanged;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Black;
            panel5.Controls.Add(label10);
            panel5.Controls.Add(hrattendancesdatetxt);
            panel5.Location = new Point(699, 91);
            panel5.Name = "panel5";
            panel5.Size = new Size(308, 57);
            panel5.TabIndex = 50;
            panel5.Paint += panel5_Paint;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(2, 12);
            label10.Name = "label10";
            label10.Size = new Size(74, 32);
            label10.TabIndex = 6;
            label10.Text = "Date:";
            // 
            // hrattendancesdatetxt
            // 
            hrattendancesdatetxt.Location = new Point(82, 10);
            hrattendancesdatetxt.Multiline = true;
            hrattendancesdatetxt.Name = "hrattendancesdatetxt";
            hrattendancesdatetxt.Size = new Size(205, 41);
            hrattendancesdatetxt.TabIndex = 1;
            // 
            // systempanelcontents
            // 
            systempanelcontents.BackColor = Color.White;
            systempanelcontents.Controls.Add(dgvAttendance);
            systempanelcontents.Location = new Point(12, 180);
            systempanelcontents.Name = "systempanelcontents";
            systempanelcontents.Size = new Size(1510, 879);
            systempanelcontents.TabIndex = 46;
            // 
            // dgvAttendance
            // 
            dgvAttendance.AllowUserToDeleteRows = false;
            dgvAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAttendance.Dock = DockStyle.Fill;
            dgvAttendance.Location = new Point(0, 0);
            dgvAttendance.Margin = new Padding(3, 2, 3, 2);
            dgvAttendance.Name = "dgvAttendance";
            dgvAttendance.RowHeadersWidth = 51;
            dgvAttendance.Size = new Size(1510, 879);
            dgvAttendance.TabIndex = 0;
            dgvAttendance.CellContentClick += dgvAttendance_CellContentClick;
            // 
            // hrattendanceschedulebtn
            // 
            hrattendanceschedulebtn.BackColor = Color.Black;
            hrattendanceschedulebtn.BackgroundImageLayout = ImageLayout.None;
            hrattendanceschedulebtn.Cursor = Cursors.Hand;
            hrattendanceschedulebtn.FlatStyle = FlatStyle.Flat;
            hrattendanceschedulebtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hrattendanceschedulebtn.ForeColor = Color.White;
            hrattendanceschedulebtn.Location = new Point(371, 91);
            hrattendanceschedulebtn.Name = "hrattendanceschedulebtn";
            hrattendanceschedulebtn.Size = new Size(309, 58);
            hrattendanceschedulebtn.TabIndex = 43;
            hrattendanceschedulebtn.Text = "Schedule";
            hrattendanceschedulebtn.UseVisualStyleBackColor = false;
            hrattendanceschedulebtn.Click += hrattendanceschedulebtn_Click;
            // 
            // hrattendancedailyttendancebtn
            // 
            hrattendancedailyttendancebtn.BackColor = Color.Black;
            hrattendancedailyttendancebtn.BackgroundImageLayout = ImageLayout.None;
            hrattendancedailyttendancebtn.Cursor = Cursors.Hand;
            hrattendancedailyttendancebtn.FlatStyle = FlatStyle.Flat;
            hrattendancedailyttendancebtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hrattendancedailyttendancebtn.ForeColor = Color.White;
            hrattendancedailyttendancebtn.Location = new Point(12, 91);
            hrattendancedailyttendancebtn.Name = "hrattendancedailyttendancebtn";
            hrattendancedailyttendancebtn.Size = new Size(340, 58);
            hrattendancedailyttendancebtn.TabIndex = 42;
            hrattendancedailyttendancebtn.Text = "Daily Attendance";
            hrattendancedailyttendancebtn.UseVisualStyleBackColor = false;
            hrattendancedailyttendancebtn.Click += hrattendancedailyttendancebtn_Click;
            // 
            // HrAttendance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1924, 1061);
            Controls.Add(panelContent);
            Name = "HrAttendance";
            Text = "HrAttendance";
            Load += HrAttendance_Load;
            panelContent.ResumeLayout(false);
            systemsearchbarpanel.ResumeLayout(false);
            systemsearchbarpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)systemsearchbaricon).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            systempanelcontents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContent;
        private Panel systemsearchbarpanel;
        private PictureBox systemsearchbaricon;
        private TextBox systemsearchbar;
        private Panel panel5;
        private TextBox hrattendancesdatetxt;
        private Panel systempanelcontents;
        private Button hrattendanceschedulebtn;
        private Button hrattendancedailyttendancebtn;
        private Label label10;
        private DataGridView dgvAttendance;
        private Button hrattendanceadd;
    }
}