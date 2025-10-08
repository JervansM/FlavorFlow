namespace FlavorFlowIT13
{
    partial class HrLeave
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
            panel1 = new Panel();
            label10 = new Label();
            hrleaveaddnewleavebtn = new Button();
            systemsearchbarpanel = new Panel();
            systemsearchbaricon = new PictureBox();
            systemsearchbar = new TextBox();
            systempanelcontents = new Panel();
            hrleavetimeoffbtn = new Button();
            hrleaveleaverequestbtn = new Button();
            panelContent.SuspendLayout();
            systemsearchbarpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)systemsearchbaricon).BeginInit();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.Silver;
            panelContent.Controls.Add(panel1);
            panelContent.Controls.Add(label10);
            panelContent.Controls.Add(hrleaveaddnewleavebtn);
            panelContent.Controls.Add(systemsearchbarpanel);
            panelContent.Controls.Add(systempanelcontents);
            panelContent.Controls.Add(hrleavetimeoffbtn);
            panelContent.Controls.Add(hrleaveleaverequestbtn);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1600, 1000);
            panelContent.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Location = new Point(12, 525);
            panel1.Name = "panel1";
            panel1.Size = new Size(1400, 160);
            panel1.TabIndex = 56;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label10.Location = new Point(12, 481);
            label10.Name = "label10";
            label10.Size = new Size(213, 41);
            label10.TabIndex = 55;
            label10.Text = "Leave Balance";
            // 
            // hrleaveaddnewleavebtn
            // 
            hrleaveaddnewleavebtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            hrleaveaddnewleavebtn.Location = new Point(528, 736);
            hrleaveaddnewleavebtn.Name = "hrleaveaddnewleavebtn";
            hrleaveaddnewleavebtn.Size = new Size(300, 70);
            hrleaveaddnewleavebtn.TabIndex = 52;
            hrleaveaddnewleavebtn.Text = "Add New Leave";
            hrleaveaddnewleavebtn.UseVisualStyleBackColor = true;
            hrleaveaddnewleavebtn.Click += hrleaveaddnewleavebtn_Click;
            // 
            // systemsearchbarpanel
            // 
            systemsearchbarpanel.BackColor = Color.White;
            systemsearchbarpanel.Controls.Add(systemsearchbaricon);
            systemsearchbarpanel.Controls.Add(systemsearchbar);
            systemsearchbarpanel.Location = new Point(12, 12);
            systemsearchbarpanel.Name = "systemsearchbarpanel";
            systemsearchbarpanel.Size = new Size(1400, 60);
            systemsearchbarpanel.TabIndex = 23;
            // 
            // systemsearchbaricon
            // 
            systemsearchbaricon.BackColor = Color.Transparent;
            systemsearchbaricon.Dock = DockStyle.Right;
            systemsearchbaricon.Image = Properties.Resources.searchbar_removebg_preview;
            systemsearchbaricon.Location = new Point(1350, 0);
            systemsearchbaricon.Name = "systemsearchbaricon";
            systemsearchbaricon.Size = new Size(50, 60);
            systemsearchbaricon.SizeMode = PictureBoxSizeMode.Zoom;
            systemsearchbaricon.TabIndex = 0;
            systemsearchbaricon.TabStop = false;
            // 
            // systemsearchbar
            // 
            systemsearchbar.BorderStyle = BorderStyle.None;
            systemsearchbar.Dock = DockStyle.Fill;
            systemsearchbar.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            systemsearchbar.ForeColor = Color.Black;
            systemsearchbar.Location = new Point(0, 0);
            systemsearchbar.Name = "systemsearchbar";
            systemsearchbar.PlaceholderText = "Search";
            systemsearchbar.Size = new Size(1400, 32);
            systemsearchbar.TabIndex = 1;
            // 
            // systempanelcontents
            // 
            systempanelcontents.BackColor = Color.White;
            systempanelcontents.Location = new Point(12, 153);
            systempanelcontents.Name = "systempanelcontents";
            systempanelcontents.Size = new Size(1400, 325);
            systempanelcontents.TabIndex = 46;
            // 
            // hrleavetimeoffbtn
            // 
            hrleavetimeoffbtn.BackColor = Color.Black;
            hrleavetimeoffbtn.FlatStyle = FlatStyle.Flat;
            hrleavetimeoffbtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            hrleavetimeoffbtn.ForeColor = Color.White;
            hrleavetimeoffbtn.Location = new Point(420, 78);
            hrleavetimeoffbtn.Name = "hrleavetimeoffbtn";
            hrleavetimeoffbtn.Size = new Size(250, 60);
            hrleavetimeoffbtn.TabIndex = 47;
            hrleavetimeoffbtn.Text = "Time-Off";
            hrleavetimeoffbtn.UseVisualStyleBackColor = false;
            hrleavetimeoffbtn.Click += hrleavetimeoffbtn_Click;
            // 
            // hrleaveleaverequestbtn
            // 
            hrleaveleaverequestbtn.BackColor = Color.Black;
            hrleaveleaverequestbtn.FlatStyle = FlatStyle.Flat;
            hrleaveleaverequestbtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            hrleaveleaverequestbtn.ForeColor = Color.White;
            hrleaveleaverequestbtn.Location = new Point(81, 78);
            hrleaveleaverequestbtn.Name = "hrleaveleaverequestbtn";
            hrleaveleaverequestbtn.Size = new Size(250, 60);
            hrleaveleaverequestbtn.TabIndex = 48;
            hrleaveleaverequestbtn.Text = "Leave Request";
            hrleaveleaverequestbtn.UseVisualStyleBackColor = false;
            hrleaveleaverequestbtn.Click += hrleaveleaverequestbtn_Click;
            // 
            // HrLeave
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 1000);
            Controls.Add(panelContent);
            Name = "HrLeave";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HrLeave";
            WindowState = FormWindowState.Maximized;
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            systemsearchbarpanel.ResumeLayout(false);
            systemsearchbarpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)systemsearchbaricon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContent;
        private Panel systemsearchbarpanel;
        private PictureBox systemsearchbaricon;
        private TextBox systemsearchbar;
        private Panel systempanelcontents;
        private Button hrleavetimeoffbtn;
        private Button hrleaveleaverequestbtn;
        private Button hrleaveviewbalancebtn;
        private Button hrleaveaddnewleavebtn;
        private Panel panel1;
        private Label label10;
    }
}
