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
            userlbl = new Label();
            passlbl = new Label();
            usertxt = new TextBox();
            passwordtxt = new TextBox();
            loginbtn = new Button();
            loginpanelinput = new Panel();
            loginpanelinput.SuspendLayout();
            SuspendLayout();
            // 
            // userlbl
            // 
            userlbl.Anchor = AnchorStyles.None;
            userlbl.AutoSize = true;
            userlbl.BackColor = Color.Transparent;
            userlbl.Font = new Font("Segoe UI", 45F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userlbl.ForeColor = Color.Coral;
            userlbl.Location = new Point(21, 52);
            userlbl.Name = "userlbl";
            userlbl.Size = new Size(348, 81);
            userlbl.TabIndex = 0;
            userlbl.Text = "Username :";
            userlbl.TextAlign = ContentAlignment.MiddleRight;
            userlbl.Click += label1_Click;
            // 
            // passlbl
            // 
            passlbl.Anchor = AnchorStyles.None;
            passlbl.AutoSize = true;
            passlbl.BackColor = Color.Transparent;
            passlbl.Font = new Font("Segoe UI", 45F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passlbl.ForeColor = Color.Coral;
            passlbl.Location = new Point(39, 165);
            passlbl.Name = "passlbl";
            passlbl.Size = new Size(351, 81);
            passlbl.TabIndex = 1;
            passlbl.Text = "Password : ";
            passlbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // usertxt
            // 
            usertxt.Anchor = AnchorStyles.None;
            usertxt.BackColor = Color.White;
            usertxt.BorderStyle = BorderStyle.None;
            usertxt.Cursor = Cursors.IBeam;
            usertxt.Font = new Font("Sitka Display", 42F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usertxt.Location = new Point(359, 63);
            usertxt.Multiline = true;
            usertxt.Name = "usertxt";
            usertxt.Size = new Size(415, 81);
            usertxt.TabIndex = 2;
            usertxt.TextChanged += usertxt_TextChanged;
            // 
            // passwordtxt
            // 
            passwordtxt.Anchor = AnchorStyles.None;
            passwordtxt.BackColor = Color.White;
            passwordtxt.BorderStyle = BorderStyle.None;
            passwordtxt.Cursor = Cursors.IBeam;
            passwordtxt.Font = new Font("Sitka Display", 42F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordtxt.Location = new Point(359, 176);
            passwordtxt.Multiline = true;
            passwordtxt.Name = "passwordtxt";
            passwordtxt.PasswordChar = '*';
            passwordtxt.Size = new Size(415, 81);
            passwordtxt.TabIndex = 3;
            passwordtxt.TextChanged += passwordtxt_TextChanged;
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
            loginbtn.Location = new Point(359, 291);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(415, 63);
            loginbtn.TabIndex = 4;
            loginbtn.Text = "Log in";
            loginbtn.UseVisualStyleBackColor = false;
            loginbtn.Click += loginbtn_Click;
            // 
            // loginpanelinput
            // 
            loginpanelinput.Anchor = AnchorStyles.None;
            loginpanelinput.BackColor = Color.Transparent;
            loginpanelinput.BackgroundImageLayout = ImageLayout.None;
            loginpanelinput.Controls.Add(usertxt);
            loginpanelinput.Controls.Add(loginbtn);
            loginpanelinput.Controls.Add(userlbl);
            loginpanelinput.Controls.Add(passwordtxt);
            loginpanelinput.Controls.Add(passlbl);
            loginpanelinput.Location = new Point(191, 404);
            loginpanelinput.Name = "loginpanelinput";
            loginpanelinput.Size = new Size(849, 407);
            loginpanelinput.TabIndex = 5;
            loginpanelinput.Paint += loginpanelinput_Paint;
            // 
            // Login
            // 
            AcceptButton = loginbtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.loginback;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1161, 860);
            Controls.Add(loginpanelinput);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            WindowState = FormWindowState.Maximized;
            Load += Login_Load;
            loginpanelinput.ResumeLayout(false);
            loginpanelinput.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label userlbl;
        private Label passlbl;
        private TextBox usertxt;
        private TextBox passwordtxt;
        private Button loginbtn;
        private Panel loginpanelinput;
    }
}
