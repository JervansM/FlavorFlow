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
            hrleaveaddnewleavebtn = new Button();
            hrleaveviewbalancebtn = new Button();
            systemsearchbarpanel = new Panel();
            systemsearchbaricon = new PictureBox();
            systemsearchbar = new TextBox();
            systempanelcontents = new Panel();
            dataleave = new DataGridView();
            hrleavetimeoffbtn = new Button();
            hrleaveleaverequestbtn = new Button();
            panelContent.SuspendLayout();
            systemsearchbarpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)systemsearchbaricon).BeginInit();
            systempanelcontents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataleave).BeginInit();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.Silver;
            panelContent.Controls.Add(hrleaveaddnewleavebtn);
            panelContent.Controls.Add(hrleaveviewbalancebtn);
            panelContent.Controls.Add(systemsearchbarpanel);
            panelContent.Controls.Add(systempanelcontents);
            panelContent.Controls.Add(hrleavetimeoffbtn);
            panelContent.Controls.Add(hrleaveleaverequestbtn);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1436, 855);
            panelContent.TabIndex = 5;
            panelContent.Paint += panelContent_Paint;
            // 
            // hrleaveaddnewleavebtn
            // 
            hrleaveaddnewleavebtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            hrleaveaddnewleavebtn.Location = new Point(315, 760);
            hrleaveaddnewleavebtn.Name = "hrleaveaddnewleavebtn";
            hrleaveaddnewleavebtn.Size = new Size(250, 60);
            hrleaveaddnewleavebtn.TabIndex = 0;
            hrleaveaddnewleavebtn.Text = "Add New Leave";
            hrleaveaddnewleavebtn.UseVisualStyleBackColor = true;
            hrleaveaddnewleavebtn.Click += button1_Click;
            // 
            // hrleaveviewbalancebtn
            // 
            hrleaveviewbalancebtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            hrleaveviewbalancebtn.Location = new Point(600, 760);
            hrleaveviewbalancebtn.Name = "hrleaveviewbalancebtn";
            hrleaveviewbalancebtn.Size = new Size(250, 60);
            hrleaveviewbalancebtn.TabIndex = 1;
            hrleaveviewbalancebtn.Text = "View Balance";
            hrleaveviewbalancebtn.UseVisualStyleBackColor = true;
            // 
            // systemsearchbarpanel
            // 
            systemsearchbarpanel.BackColor = Color.White;
            systemsearchbarpanel.Controls.Add(systemsearchbaricon);
            systemsearchbarpanel.Controls.Add(systemsearchbar);
            systemsearchbarpanel.Location = new Point(50, 30);
            systemsearchbarpanel.Name = "systemsearchbarpanel";
            systemsearchbarpanel.Size = new Size(1200, 50);
            systemsearchbarpanel.TabIndex = 23;
            // 
            // systemsearchbaricon
            // 
            systemsearchbaricon.BackColor = Color.Transparent;
            systemsearchbaricon.Dock = DockStyle.Right;
            systemsearchbaricon.Image = Properties.Resources.searchbar_removebg_preview;
            systemsearchbaricon.Location = new Point(1160, 0);
            systemsearchbaricon.Name = "systemsearchbaricon";
            systemsearchbaricon.Size = new Size(40, 50);
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
            systemsearchbar.Size = new Size(1200, 32);
            systemsearchbar.TabIndex = 1;
            // 
            // systempanelcontents
            // 
            systempanelcontents.BackColor = Color.White;
            systempanelcontents.Controls.Add(dataleave);
            systempanelcontents.Location = new Point(12, 173);
            systempanelcontents.Name = "systempanelcontents";
            systempanelcontents.Size = new Size(1405, 513);
            systempanelcontents.TabIndex = 46;
            // 
            // dataleave
            // 
            dataleave.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataleave.Dock = DockStyle.Fill;
            dataleave.Location = new Point(0, 0);
            dataleave.Name = "dataleave";
            dataleave.RowHeadersWidth = 51;
            dataleave.Size = new Size(1405, 513);
            dataleave.TabIndex = 0;
            // 
            // hrleavetimeoffbtn
            // 
            hrleavetimeoffbtn.BackColor = Color.Black;
            hrleavetimeoffbtn.FlatStyle = FlatStyle.Flat;
            hrleavetimeoffbtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            hrleavetimeoffbtn.ForeColor = Color.White;
            hrleavetimeoffbtn.Location = new Point(450, 100);
            hrleavetimeoffbtn.Name = "hrleavetimeoffbtn";
            hrleavetimeoffbtn.Size = new Size(200, 50);
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
            hrleaveleaverequestbtn.Location = new Point(200, 100);
            hrleaveleaverequestbtn.Name = "hrleaveleaverequestbtn";
            hrleaveleaverequestbtn.Size = new Size(200, 50);
            hrleaveleaverequestbtn.TabIndex = 48;
            hrleaveleaverequestbtn.Text = "Leave Request";
            hrleaveleaverequestbtn.UseVisualStyleBackColor = false;
            hrleaveleaverequestbtn.Click += hrleaveleaverequestbtn_Click;
            // 
            // HrLeave
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1436, 855);
            Controls.Add(panelContent);
            Name = "HrLeave";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HrLeave";
            WindowState = FormWindowState.Maximized;
            panelContent.ResumeLayout(false);
            systemsearchbarpanel.ResumeLayout(false);
            systemsearchbarpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)systemsearchbaricon).EndInit();
            systempanelcontents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataleave).EndInit();
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
        private DataGridView dataleave;
    }
}
