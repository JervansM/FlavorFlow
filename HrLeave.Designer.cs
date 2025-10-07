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
            systempanelcontents = new Panel();
            dataleave = new DataGridView();
            hrleavetimeoffbtn = new Button();
            hrleaveleaverequestbtn = new Button();
            systemsearchbarpanel = new Panel();
            systemsearchbaricon = new PictureBox();
            systemsearchbar = new TextBox();
            panelContent.SuspendLayout();
            systempanelcontents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataleave).BeginInit();
            systemsearchbarpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)systemsearchbaricon).BeginInit();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.Silver;
            panelContent.Controls.Add(systemsearchbarpanel);
            panelContent.Controls.Add(systempanelcontents);
            panelContent.Controls.Add(hrleavetimeoffbtn);
            panelContent.Controls.Add(hrleaveleaverequestbtn);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Margin = new Padding(3, 2, 3, 2);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1582, 918);
            panelContent.TabIndex = 5;
            panelContent.Paint += panelContent_Paint;
            // 
            // hrleaveaddnewleavebtn
            // 
            hrleaveaddnewleavebtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            hrleaveaddnewleavebtn.Location = new Point(386, 634);
            hrleaveaddnewleavebtn.Margin = new Padding(3, 2, 3, 2);
            hrleaveaddnewleavebtn.Name = "hrleaveaddnewleavebtn";
            hrleaveaddnewleavebtn.Size = new Size(236, 54);
            hrleaveaddnewleavebtn.TabIndex = 0;
            hrleaveaddnewleavebtn.Text = "Add New Leave";
            hrleaveaddnewleavebtn.UseVisualStyleBackColor = true;
            hrleaveaddnewleavebtn.Click += button1_Click;
            // 
            // hrleaveviewbalancebtn
            // 
            hrleaveviewbalancebtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            hrleaveviewbalancebtn.Location = new Point(800, 634);
            hrleaveviewbalancebtn.Margin = new Padding(3, 2, 3, 2);
            hrleaveviewbalancebtn.Name = "hrleaveviewbalancebtn";
            hrleaveviewbalancebtn.Size = new Size(233, 54);
            hrleaveviewbalancebtn.TabIndex = 1;
            hrleaveviewbalancebtn.Text = "View Balance";
            hrleaveviewbalancebtn.UseVisualStyleBackColor = true;
            hrleaveviewbalancebtn.Click += hrleaveviewbalancebtn_Click;
            // 
            // systempanelcontents
            // 
            systempanelcontents.BackColor = SystemColors.ControlDarkDark;
            systempanelcontents.Controls.Add(hrleaveviewbalancebtn);
            systempanelcontents.Controls.Add(hrleaveaddnewleavebtn);
            systempanelcontents.Controls.Add(dataleave);
            systempanelcontents.Location = new Point(27, 155);
            systempanelcontents.Margin = new Padding(3, 2, 3, 2);
            systempanelcontents.Name = "systempanelcontents";
            systempanelcontents.Size = new Size(1522, 728);
            systempanelcontents.TabIndex = 46;
            // 
            // dataleave
            // 
            dataleave.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataleave.Location = new Point(0, 2);
            dataleave.Margin = new Padding(3, 2, 3, 2);
            dataleave.Name = "dataleave";
            dataleave.RowHeadersWidth = 51;
            dataleave.Size = new Size(1519, 616);
            dataleave.TabIndex = 0;
            dataleave.CellContentClick += dataleave_CellContentClick;
            // 
            // hrleavetimeoffbtn
            // 
            hrleavetimeoffbtn.BackColor = Color.Black;
            hrleavetimeoffbtn.FlatStyle = FlatStyle.Flat;
            hrleavetimeoffbtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            hrleavetimeoffbtn.ForeColor = Color.White;
            hrleavetimeoffbtn.Location = new Point(362, 85);
            hrleavetimeoffbtn.Margin = new Padding(3, 2, 3, 2);
            hrleavetimeoffbtn.Name = "hrleavetimeoffbtn";
            hrleavetimeoffbtn.Size = new Size(234, 54);
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
            hrleaveleaverequestbtn.Location = new Point(93, 85);
            hrleaveleaverequestbtn.Margin = new Padding(3, 2, 3, 2);
            hrleaveleaverequestbtn.Name = "hrleaveleaverequestbtn";
            hrleaveleaverequestbtn.Size = new Size(214, 54);
            hrleaveleaverequestbtn.TabIndex = 48;
            hrleaveleaverequestbtn.Text = "Leave Request";
            hrleaveleaverequestbtn.UseVisualStyleBackColor = false;
            hrleaveleaverequestbtn.Click += hrleaveleaverequestbtn_Click;
            // 
            // systemsearchbarpanel
            // 
            systemsearchbarpanel.BackColor = Color.White;
            systemsearchbarpanel.Controls.Add(systemsearchbaricon);
            systemsearchbarpanel.Controls.Add(systemsearchbar);
            systemsearchbarpanel.Location = new Point(27, 12);
            systemsearchbarpanel.Name = "systemsearchbarpanel";
            systemsearchbarpanel.Size = new Size(1510, 59);
            systemsearchbarpanel.TabIndex = 49;
            // 
            // systemsearchbaricon
            // 
            systemsearchbaricon.BackColor = Color.Transparent;
            systemsearchbaricon.BackgroundImageLayout = ImageLayout.None;
            systemsearchbaricon.Image = Properties.Resources.searchbar_removebg_preview;
            systemsearchbaricon.Location = new Point(1426, 7);
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
            systemsearchbar.Location = new Point(12, 6);
            systemsearchbar.Multiline = true;
            systemsearchbar.Name = "systemsearchbar";
            systemsearchbar.PlaceholderText = "Search";
            systemsearchbar.Size = new Size(1476, 47);
            systemsearchbar.TabIndex = 22;
            // 
            // HrLeave
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1582, 918);
            Controls.Add(panelContent);
            Margin = new Padding(3, 2, 3, 2);
            Name = "HrLeave";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HrLeave";
            WindowState = FormWindowState.Maximized;
            Load += HrLeave_Load;
            panelContent.ResumeLayout(false);
            systempanelcontents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataleave).EndInit();
            systemsearchbarpanel.ResumeLayout(false);
            systemsearchbarpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)systemsearchbaricon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContent;
        private Panel systempanelcontents;
        private Button hrleavetimeoffbtn;
        private Button hrleaveleaverequestbtn;
        private Button hrleaveviewbalancebtn;
        private Button hrleaveaddnewleavebtn;
        private DataGridView dataleave;
        private Panel systemsearchbarpanel;
        private PictureBox systemsearchbaricon;
        private TextBox systemsearchbar;
    }
}
