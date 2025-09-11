namespace FlavorFlowIT13
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            passlbl = new Label();
            passwordtxt = new TextBox();
            userlbl = new Label();
            loginbtn = new Button();
            usertxt = new TextBox();
            loginsignupbtn = new Button();
            SuspendLayout();
            // 
            // passlbl
            // 
            passlbl.Anchor = AnchorStyles.None;
            passlbl.AutoSize = true;
            passlbl.BackColor = Color.Transparent;
            passlbl.Font = new Font("Segoe UI", 45F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passlbl.ForeColor = Color.Coral;
            passlbl.Location = new Point(203, 552);
            passlbl.Name = "passlbl";
            passlbl.Size = new Size(351, 81);
            passlbl.TabIndex = 1;
            passlbl.Text = "Password : ";
            passlbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // passwordtxt
            // 
            passwordtxt.Anchor = AnchorStyles.None;
            passwordtxt.BackColor = Color.White;
            passwordtxt.BorderStyle = BorderStyle.None;
            passwordtxt.Cursor = Cursors.IBeam;
            passwordtxt.Font = new Font("Sitka Display", 42F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordtxt.Location = new Point(560, 553);
            passwordtxt.Multiline = true;
            passwordtxt.Name = "passwordtxt";
            passwordtxt.PasswordChar = '*';
            passwordtxt.Size = new Size(415, 81);
            passwordtxt.TabIndex = 3;
            passwordtxt.WordWrap = false;
            passwordtxt.TextChanged += passwordtxt_TextChanged;
            // 
            // userlbl
            // 
            userlbl.Anchor = AnchorStyles.None;
            userlbl.AutoSize = true;
            userlbl.BackColor = Color.Transparent;
            userlbl.Font = new Font("Segoe UI", 45F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userlbl.ForeColor = Color.Coral;
            userlbl.Location = new Point(189, 426);
            userlbl.Name = "userlbl";
            userlbl.Size = new Size(348, 81);
            userlbl.TabIndex = 0;
            userlbl.Text = "Username :";
            userlbl.TextAlign = ContentAlignment.MiddleRight;
            userlbl.Click += label1_Click;
            // 
            // loginbtn
            // 
            loginbtn.Anchor = AnchorStyles.None;
            loginbtn.BackColor = Color.Coral;
            loginbtn.BackgroundImageLayout = ImageLayout.None;
            loginbtn.Cursor = Cursors.Hand;
            loginbtn.FlatStyle = FlatStyle.Flat;
            loginbtn.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginbtn.ForeColor = SystemColors.Window;
            loginbtn.Location = new Point(560, 669);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(415, 63);
            loginbtn.TabIndex = 4;
            loginbtn.Text = "Log in";
            loginbtn.UseVisualStyleBackColor = false;
            loginbtn.Click += loginbtn_Click;
            // 
            // usertxt
            // 
            usertxt.Anchor = AnchorStyles.None;
            usertxt.BackColor = Color.White;
            usertxt.BorderStyle = BorderStyle.None;
            usertxt.Cursor = Cursors.IBeam;
            usertxt.Font = new Font("Sitka Display", 42F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usertxt.Location = new Point(560, 426);
            usertxt.Multiline = true;
            usertxt.Name = "usertxt";
            usertxt.Size = new Size(415, 81);
            usertxt.TabIndex = 2;
            usertxt.WordWrap = false;
            usertxt.TextChanged += usertxt_TextChanged;
            // 
            // loginsignupbtn
            // 
            loginsignupbtn.Anchor = AnchorStyles.None;
            loginsignupbtn.BackColor = Color.Coral;
            loginsignupbtn.BackgroundImageLayout = ImageLayout.None;
            loginsignupbtn.Cursor = Cursors.Hand;
            loginsignupbtn.FlatStyle = FlatStyle.Flat;
            loginsignupbtn.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginsignupbtn.ForeColor = SystemColors.Window;
            loginsignupbtn.Location = new Point(560, 766);
            loginsignupbtn.Name = "loginsignupbtn";
            loginsignupbtn.Size = new Size(415, 63);
            loginsignupbtn.TabIndex = 5;
            loginsignupbtn.Text = "Sign up";
            loginsignupbtn.UseVisualStyleBackColor = false;
            loginsignupbtn.Click += loginsignupbtn_Click;
            // 
            // Login
            // 
            AcceptButton = loginbtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1161, 860);
            Controls.Add(loginsignupbtn);
            Controls.Add(usertxt);
            Controls.Add(loginbtn);
            Controls.Add(userlbl);
            Controls.Add(passlbl);
            Controls.Add(passwordtxt);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            WindowState = FormWindowState.Maximized;
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label passlbl;
        private TextBox passwordtxt;
        private Label userlbl;
        private Button loginbtn;
        private TextBox usertxt;
        private Button loginsignupbtn;
    }
}
