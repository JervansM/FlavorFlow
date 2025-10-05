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
            panel3 = new Panel();
            netsalestxtbox = new TextBox();
            label9 = new Label();
            panel4 = new Panel();
            totaldiscountstxtbox = new TextBox();
            label8 = new Label();
            panel2 = new Panel();
            totalsalestxtbox = new TextBox();
            label7 = new Label();
            systempanelcontents = new Panel();
            dgvAttendance = new DataGridView();
            hrattendanceschedulebtn = new Button();
            hrattendancedailyttendancebtn = new Button();
            panelContent.SuspendLayout();
            systemsearchbarpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)systemsearchbaricon).BeginInit();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            systempanelcontents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).BeginInit();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.Silver;
            panelContent.Controls.Add(hrattendanceadd);
            panelContent.Controls.Add(systemsearchbarpanel);
            panelContent.Controls.Add(panel5);
            panelContent.Controls.Add(panel3);
            panelContent.Controls.Add(panel4);
            panelContent.Controls.Add(panel2);
            panelContent.Controls.Add(systempanelcontents);
            panelContent.Controls.Add(hrattendanceschedulebtn);
            panelContent.Controls.Add(hrattendancedailyttendancebtn);
            panelContent.Location = new Point(-84, -136);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1358, 771);
            panelContent.TabIndex = 4;
            panelContent.Paint += panelContent_Paint;
            // 
            // hrattendanceadd
            // 
            hrattendanceadd.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            hrattendanceadd.Location = new Point(564, 732);
            hrattendanceadd.Margin = new Padding(3, 2, 3, 2);
            hrattendanceadd.Name = "hrattendanceadd";
            hrattendanceadd.Size = new Size(362, 37);
            hrattendanceadd.TabIndex = 51;
            hrattendanceadd.Text = "Add New Attendance";
            hrattendanceadd.UseVisualStyleBackColor = true;
            // 
            // systemsearchbarpanel
            // 
            systemsearchbarpanel.BackColor = Color.White;
            systemsearchbarpanel.Controls.Add(systemsearchbaricon);
            systemsearchbarpanel.Controls.Add(systemsearchbar);
            systemsearchbarpanel.Location = new Point(46, 26);
            systemsearchbarpanel.Name = "systemsearchbarpanel";
            systemsearchbarpanel.Size = new Size(1447, 59);
            systemsearchbarpanel.TabIndex = 23;
            // 
            // systemsearchbaricon
            // 
            systemsearchbaricon.BackColor = Color.Transparent;
            systemsearchbaricon.BackgroundImageLayout = ImageLayout.None;
            systemsearchbaricon.Image = Properties.Resources.searchbar_removebg_preview;
            systemsearchbaricon.Location = new Point(1363, 6);
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
            systemsearchbar.Location = new Point(633, -16);
            systemsearchbar.Multiline = true;
            systemsearchbar.Name = "systemsearchbar";
            systemsearchbar.PlaceholderText = "Search";
            systemsearchbar.Size = new Size(124, 47);
            systemsearchbar.TabIndex = 22;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Black;
            panel5.Controls.Add(label10);
            panel5.Controls.Add(hrattendancesdatetxt);
            panel5.Location = new Point(94, 248);
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
            hrattendancesdatetxt.Location = new Point(88, 12);
            hrattendancesdatetxt.Multiline = true;
            hrattendancesdatetxt.Name = "hrattendancesdatetxt";
            hrattendancesdatetxt.Size = new Size(205, 41);
            hrattendancesdatetxt.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Black;
            panel3.Controls.Add(netsalestxtbox);
            panel3.Controls.Add(label9);
            panel3.Location = new Point(1057, 928);
            panel3.Name = "panel3";
            panel3.Size = new Size(301, 57);
            panel3.TabIndex = 50;
            // 
            // netsalestxtbox
            // 
            netsalestxtbox.Location = new Point(129, 4);
            netsalestxtbox.Multiline = true;
            netsalestxtbox.Name = "netsalestxtbox";
            netsalestxtbox.Size = new Size(169, 50);
            netsalestxtbox.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(17, 13);
            label9.Name = "label9";
            label9.Size = new Size(106, 30);
            label9.TabIndex = 2;
            label9.Text = "Net Sales:";
            // 
            // panel4
            // 
            panel4.BackColor = Color.Black;
            panel4.Controls.Add(totaldiscountstxtbox);
            panel4.Controls.Add(label8);
            panel4.Location = new Point(634, 928);
            panel4.Name = "panel4";
            panel4.Size = new Size(359, 57);
            panel4.TabIndex = 50;
            // 
            // totaldiscountstxtbox
            // 
            totaldiscountstxtbox.Location = new Point(185, 3);
            totaldiscountstxtbox.Multiline = true;
            totaldiscountstxtbox.Name = "totaldiscountstxtbox";
            totaldiscountstxtbox.Size = new Size(169, 50);
            totaldiscountstxtbox.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(15, 13);
            label8.Name = "label8";
            label8.Size = new Size(164, 30);
            label8.TabIndex = 1;
            label8.Text = "Total Discounts:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Controls.Add(totalsalestxtbox);
            panel2.Controls.Add(label7);
            panel2.Location = new Point(203, 928);
            panel2.Name = "panel2";
            panel2.Size = new Size(308, 57);
            panel2.TabIndex = 49;
            // 
            // totalsalestxtbox
            // 
            totalsalestxtbox.Location = new Point(135, 3);
            totalsalestxtbox.Multiline = true;
            totalsalestxtbox.Name = "totalsalestxtbox";
            totalsalestxtbox.Size = new Size(169, 50);
            totalsalestxtbox.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(12, 13);
            label7.Name = "label7";
            label7.Size = new Size(118, 30);
            label7.TabIndex = 0;
            label7.Text = "Total Sales:";
            // 
            // systempanelcontents
            // 
            systempanelcontents.BackColor = Color.White;
            systempanelcontents.Controls.Add(dgvAttendance);
            systempanelcontents.Location = new Point(97, 334);
            systempanelcontents.Name = "systempanelcontents";
            systempanelcontents.Size = new Size(1231, 386);
            systempanelcontents.TabIndex = 46;
            // 
            // dgvAttendance
            // 
            dgvAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAttendance.Location = new Point(0, 0);
            dgvAttendance.Margin = new Padding(3, 2, 3, 2);
            dgvAttendance.Name = "dgvAttendance";
            dgvAttendance.RowHeadersWidth = 51;
            dgvAttendance.Size = new Size(1229, 385);
            dgvAttendance.TabIndex = 0;
            // 
            // hrattendanceschedulebtn
            // 
            hrattendanceschedulebtn.BackColor = Color.Black;
            hrattendanceschedulebtn.BackgroundImageLayout = ImageLayout.None;
            hrattendanceschedulebtn.Cursor = Cursors.Hand;
            hrattendanceschedulebtn.FlatStyle = FlatStyle.Flat;
            hrattendanceschedulebtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hrattendanceschedulebtn.ForeColor = Color.White;
            hrattendanceschedulebtn.Location = new Point(463, 164);
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
            hrattendancedailyttendancebtn.Location = new Point(96, 164);
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
            ClientSize = new Size(1253, 641);
            Controls.Add(panelContent);
            Name = "HrAttendance";
            Text = "HrAttendance";
            Load += HrAttendance_Load_1;
            panelContent.ResumeLayout(false);
            systemsearchbarpanel.ResumeLayout(false);
            systemsearchbarpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)systemsearchbaricon).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private Panel panel3;
        private TextBox netsalestxtbox;
        private Label label9;
        private Panel panel4;
        private TextBox totaldiscountstxtbox;
        private Label label8;
        private Panel panel2;
        private TextBox totalsalestxtbox;
        private Label label7;
        private Panel systempanelcontents;
        private Button hrattendanceschedulebtn;
        private Button hrattendancedailyttendancebtn;
        private Label label10;
        private DataGridView dgvAttendance;
        private Button hrattendanceadd;
    }
}