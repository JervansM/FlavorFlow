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
            usertxt = new TextBox();
            loginsignupbtn = new Button();
            loginpanel = new Panel();
            loginlbl = new Label();
            forgotpass = new Label();
            loginbtn = new Button();
            loginpanel.SuspendLayout();
            SuspendLayout();
            // 
            // passlbl
            // 
            passlbl.Anchor = AnchorStyles.None;
            passlbl.AutoSize = true;
            passlbl.BackColor = Color.Transparent;
            passlbl.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passlbl.ForeColor = Color.Black;
            passlbl.Location = new Point(19, 202);
            passlbl.Name = "passlbl";
            passlbl.Size = new Size(93, 28);
            passlbl.TabIndex = 1;
            passlbl.Text = "Password";
            passlbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // passwordtxt
            // 
            passwordtxt.Anchor = AnchorStyles.None;
            passwordtxt.BackColor = SystemColors.Control;
            passwordtxt.BorderStyle = BorderStyle.None;
            passwordtxt.Cursor = Cursors.IBeam;
            passwordtxt.Font = new Font("Segoe UI", 25F);
            passwordtxt.Location = new Point(19, 244);
            passwordtxt.Multiline = true;
            passwordtxt.Name = "passwordtxt";
            passwordtxt.PasswordChar = '*';
            passwordtxt.Size = new Size(456, 54);
            passwordtxt.TabIndex = 3;
            passwordtxt.WordWrap = false;
            // 
            // userlbl
            // 
            userlbl.Anchor = AnchorStyles.None;
            userlbl.AutoSize = true;
            userlbl.BackColor = Color.Transparent;
            userlbl.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userlbl.ForeColor = Color.Black;
            userlbl.Location = new Point(19, 78);
            userlbl.Name = "userlbl";
            userlbl.Size = new Size(99, 28);
            userlbl.TabIndex = 0;
            userlbl.Text = "Username";
            userlbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // usertxt
            // 
            usertxt.Anchor = AnchorStyles.None;
            usertxt.BackColor = SystemColors.Control;
            usertxt.BorderStyle = BorderStyle.None;
            usertxt.Cursor = Cursors.IBeam;
            usertxt.Font = new Font("Segoe UI", 25F);
            usertxt.Location = new Point(19, 120);
            usertxt.Multiline = true;
            usertxt.Name = "usertxt";
            usertxt.Size = new Size(456, 54);
            usertxt.TabIndex = 2;
            usertxt.WordWrap = false;
            // 
            // loginsignupbtn
            // 
            loginsignupbtn.Anchor = AnchorStyles.None;
            loginsignupbtn.BackColor = Color.Coral;
            loginsignupbtn.BackgroundImageLayout = ImageLayout.None;
            loginsignupbtn.Cursor = Cursors.Hand;
            loginsignupbtn.FlatStyle = FlatStyle.Flat;
            loginsignupbtn.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            loginsignupbtn.ForeColor = SystemColors.Window;
            loginsignupbtn.Location = new Point(19, 406);
            loginsignupbtn.Name = "loginsignupbtn";
            loginsignupbtn.Size = new Size(456, 51);
            loginsignupbtn.TabIndex = 5;
            loginsignupbtn.Text = "Sign up";
            loginsignupbtn.UseVisualStyleBackColor = false;
            // 
            // loginpanel
            // 
            loginpanel.Anchor = AnchorStyles.None;
            loginpanel.BackColor = Color.Silver;
            loginpanel.Controls.Add(loginlbl);
            loginpanel.Controls.Add(forgotpass);
            loginpanel.Controls.Add(loginbtn);
            loginpanel.Controls.Add(loginsignupbtn);
            loginpanel.Controls.Add(usertxt);
            loginpanel.Controls.Add(userlbl);
            loginpanel.Controls.Add(passlbl);
            loginpanel.Controls.Add(passwordtxt);
            loginpanel.Location = new Point(496, 358);
            loginpanel.Name = "loginpanel";
            loginpanel.Size = new Size(491, 493);
            loginpanel.TabIndex = 6;
            loginpanel.Paint += loginpanel_Paint;
            // 
            // loginlbl
            // 
            loginlbl.Anchor = AnchorStyles.None;
            loginlbl.AutoSize = true;
            loginlbl.BackColor = Color.Transparent;
            loginlbl.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            loginlbl.ForeColor = Color.Coral;
            loginlbl.Location = new Point(194, 17);
            loginlbl.Name = "loginlbl";
            loginlbl.Size = new Size(110, 46);
            loginlbl.TabIndex = 8;
            loginlbl.Text = "Login";
            loginlbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // forgotpass
            // 
            forgotpass.Anchor = AnchorStyles.None;
            forgotpass.AutoSize = true;
            forgotpass.BackColor = Color.Transparent;
            forgotpass.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            forgotpass.ForeColor = Color.MediumBlue;
            forgotpass.Location = new Point(19, 316);
            forgotpass.Name = "forgotpass";
            forgotpass.Size = new Size(143, 21);
            forgotpass.TabIndex = 7;
            forgotpass.Text = "Forgot password?";
            forgotpass.TextAlign = ContentAlignment.MiddleRight;
            // 
            // loginbtn
            // 
            loginbtn.Anchor = AnchorStyles.None;
            loginbtn.BackColor = Color.Coral;
            loginbtn.BackgroundImageLayout = ImageLayout.None;
            loginbtn.Cursor = Cursors.Hand;
            loginbtn.FlatStyle = FlatStyle.Flat;
            loginbtn.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            loginbtn.ForeColor = SystemColors.Window;
            loginbtn.Location = new Point(19, 349);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(456, 51);
            loginbtn.TabIndex = 4;
            loginbtn.Text = "Log In";
            loginbtn.UseVisualStyleBackColor = false;
            loginbtn.Click += loginbtn_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1478, 867);
            Controls.Add(loginpanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            WindowState = FormWindowState.Maximized;
            Load += Login_Load;
            loginpanel.ResumeLayout(false);
            loginpanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label passlbl;
        private TextBox passwordtxt;
        private Label userlbl;
        private TextBox usertxt;
        private Button loginsignupbtn;
        private Panel loginpanel;
        private Button loginbtn;
        private Label forgotpass;
        private Label loginlbl;
    }
}
