namespace FlavorFlowIT13
{
    partial class FinanceDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinanceDashboard));
            panel2 = new Panel();
            refreshicon = new PictureBox();
            userwelcome = new Label();
            panelNav = new Panel();
            generatereportbtn = new Button();
            adlogoutbtn = new Button();
            processpaymentbtn = new Button();
            fficonadmin = new PictureBox();
            adminicon = new PictureBox();
            dashtimetxt = new Label();
            dashaddate = new Label();
            panel1 = new Panel();
            dgvpayroll = new DataGridView();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)refreshicon).BeginInit();
            panelNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fficonadmin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)adminicon).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvpayroll).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(refreshicon);
            panel2.Controls.Add(userwelcome);
            panel2.Controls.Add(panelNav);
            panel2.Controls.Add(fficonadmin);
            panel2.Controls.Add(adminicon);
            panel2.Controls.Add(dashtimetxt);
            panel2.Controls.Add(dashaddate);
            panel2.Controls.Add(panel1);
            panel2.Location = new Point(38, 31);
            panel2.Name = "panel2";
            panel2.Size = new Size(1855, 1007);
            panel2.TabIndex = 24;
            // 
            // refreshicon
            // 
            refreshicon.BackColor = Color.Transparent;
            refreshicon.Image = Properties.Resources.refreshicon;
            refreshicon.Location = new Point(1698, 80);
            refreshicon.Name = "refreshicon";
            refreshicon.Size = new Size(100, 50);
            refreshicon.SizeMode = PictureBoxSizeMode.Zoom;
            refreshicon.TabIndex = 23;
            refreshicon.TabStop = false;
            refreshicon.Click += refreshicon_Click;
            // 
            // userwelcome
            // 
            userwelcome.AutoSize = true;
            userwelcome.BackColor = Color.Transparent;
            userwelcome.FlatStyle = FlatStyle.Flat;
            userwelcome.Font = new Font("Segoe UI", 30.25F, FontStyle.Bold);
            userwelcome.ForeColor = Color.Coral;
            userwelcome.Location = new Point(245, 83);
            userwelcome.Name = "userwelcome";
            userwelcome.Size = new Size(372, 55);
            userwelcome.TabIndex = 19;
            userwelcome.Text = "Welcome, Finance";
            // 
            // panelNav
            // 
            panelNav.BackColor = Color.Silver;
            panelNav.Controls.Add(generatereportbtn);
            panelNav.Controls.Add(adlogoutbtn);
            panelNav.Controls.Add(processpaymentbtn);
            panelNav.Location = new Point(33, 141);
            panelNav.Name = "panelNav";
            panelNav.Size = new Size(321, 831);
            panelNav.TabIndex = 6;
            // 
            // generatereportbtn
            // 
            generatereportbtn.BackColor = Color.Black;
            generatereportbtn.Cursor = Cursors.Hand;
            generatereportbtn.FlatStyle = FlatStyle.Popup;
            generatereportbtn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            generatereportbtn.ForeColor = Color.Honeydew;
            generatereportbtn.Location = new Point(18, 105);
            generatereportbtn.Name = "generatereportbtn";
            generatereportbtn.Size = new Size(278, 62);
            generatereportbtn.TabIndex = 15;
            generatereportbtn.Text = "Generate Report";
            generatereportbtn.UseVisualStyleBackColor = false;
            generatereportbtn.Click += generatereportbtn_Click;
            // 
            // adlogoutbtn
            // 
            adlogoutbtn.Anchor = AnchorStyles.None;
            adlogoutbtn.BackColor = Color.Coral;
            adlogoutbtn.BackgroundImageLayout = ImageLayout.None;
            adlogoutbtn.Cursor = Cursors.Hand;
            adlogoutbtn.FlatStyle = FlatStyle.Flat;
            adlogoutbtn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            adlogoutbtn.ForeColor = Color.Honeydew;
            adlogoutbtn.Location = new Point(18, 728);
            adlogoutbtn.Name = "adlogoutbtn";
            adlogoutbtn.Size = new Size(282, 62);
            adlogoutbtn.TabIndex = 12;
            adlogoutbtn.Text = "Log out";
            adlogoutbtn.UseVisualStyleBackColor = false;
            adlogoutbtn.Click += adlogoutbtn_Click;
            // 
            // processpaymentbtn
            // 
            processpaymentbtn.BackColor = Color.Black;
            processpaymentbtn.Cursor = Cursors.Hand;
            processpaymentbtn.FlatStyle = FlatStyle.Popup;
            processpaymentbtn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            processpaymentbtn.ForeColor = Color.Honeydew;
            processpaymentbtn.Location = new Point(22, 18);
            processpaymentbtn.Name = "processpaymentbtn";
            processpaymentbtn.Size = new Size(278, 62);
            processpaymentbtn.TabIndex = 16;
            processpaymentbtn.Text = "Process Payment";
            processpaymentbtn.UseVisualStyleBackColor = false;
            processpaymentbtn.Click += processpaymentbtn_Click;
            // 
            // fficonadmin
            // 
            fficonadmin.BackColor = Color.Transparent;
            fficonadmin.BackgroundImageLayout = ImageLayout.None;
            fficonadmin.Image = Properties.Resources.logotransparent;
            fficonadmin.Location = new Point(-3, -30);
            fficonadmin.Name = "fficonadmin";
            fficonadmin.Size = new Size(332, 229);
            fficonadmin.SizeMode = PictureBoxSizeMode.StretchImage;
            fficonadmin.TabIndex = 5;
            fficonadmin.TabStop = false;
            // 
            // adminicon
            // 
            adminicon.BackColor = Color.Transparent;
            adminicon.BackgroundImageLayout = ImageLayout.None;
            adminicon.Image = Properties.Resources.adminicon;
            adminicon.Location = new Point(610, 46);
            adminicon.Name = "adminicon";
            adminicon.Size = new Size(87, 89);
            adminicon.SizeMode = PictureBoxSizeMode.Zoom;
            adminicon.TabIndex = 20;
            adminicon.TabStop = false;
            // 
            // dashtimetxt
            // 
            dashtimetxt.AutoSize = true;
            dashtimetxt.BackColor = Color.Transparent;
            dashtimetxt.FlatStyle = FlatStyle.Flat;
            dashtimetxt.Font = new Font("Segoe UI", 30.25F, FontStyle.Bold);
            dashtimetxt.ForeColor = Color.Coral;
            dashtimetxt.Location = new Point(1392, 80);
            dashtimetxt.Name = "dashtimetxt";
            dashtimetxt.Size = new Size(120, 55);
            dashtimetxt.TabIndex = 22;
            dashtimetxt.Text = "Time";
            // 
            // dashaddate
            // 
            dashaddate.AutoSize = true;
            dashaddate.BackColor = Color.Transparent;
            dashaddate.FlatStyle = FlatStyle.Flat;
            dashaddate.Font = new Font("Segoe UI", 30.25F, FontStyle.Bold);
            dashaddate.ForeColor = Color.Coral;
            dashaddate.Location = new Point(1048, 80);
            dashaddate.Name = "dashaddate";
            dashaddate.Size = new Size(114, 55);
            dashaddate.TabIndex = 21;
            dashaddate.Text = "Date";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.Silver;
            panel1.Controls.Add(dgvpayroll);
            panel1.Location = new Point(376, 141);
            panel1.Name = "panel1";
            panel1.Size = new Size(1451, 831);
            panel1.TabIndex = 18;
            // 
            // dgvpayroll
            // 
            dgvpayroll.AllowUserToAddRows = false;
            dgvpayroll.AllowUserToDeleteRows = false;
            dgvpayroll.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvpayroll.Dock = DockStyle.Fill;
            dgvpayroll.Location = new Point(0, 0);
            dgvpayroll.Name = "dgvpayroll";
            dgvpayroll.ReadOnly = true;
            dgvpayroll.Size = new Size(1451, 831);
            dgvpayroll.TabIndex = 0;
            dgvpayroll.CellContentClick += dgvpayroll_CellContentClick;
            // 
            // FinanceDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(1924, 1061);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FinanceDashboard";
            Text = "FinanceDashboard";
            WindowState = FormWindowState.Maximized;
            Load += FinanceDashboard_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)refreshicon).EndInit();
            panelNav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)fficonadmin).EndInit();
            ((System.ComponentModel.ISupportInitialize)adminicon).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvpayroll).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label userwelcome;
        private Panel panelNav;
        private Button logoutbtn;
        private Button employeesbtn;
        private Button adlogoutbtn;
        private Button customerandfeedbackbtn;
        private Button inventoryandstockbtn;
        private Button ordersanddeliveriesbtn;
        private PictureBox fficonadmin;
        private Panel panel1;
        private PictureBox adminicon;
        private Label dashtimetxt;
        private Label dashaddate;
        private Button generatereportbtn;
        private PictureBox refreshicon;
        private Panel dashtotalsales;
        private DataGridView dgvpayroll;
        private Button processpaymentbtn;
    }
}