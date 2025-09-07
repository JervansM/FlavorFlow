namespace FlavorFlowIT13
{
    partial class CreateUserAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateUserAdmin));
            createuserpanel = new Panel();
            backbtn = new Button();
            rolecombobox = new ComboBox();
            rolelbl = new Label();
            createusertxt = new TextBox();
            savebtn = new Button();
            usernamelbl = new Label();
            createpasswordtxt = new TextBox();
            passwordlbl = new Label();
            createuserpanel.SuspendLayout();
            SuspendLayout();
            // 
            // createuserpanel
            // 
            createuserpanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            createuserpanel.BackColor = Color.Transparent;
            createuserpanel.BackgroundImageLayout = ImageLayout.None;
            createuserpanel.Controls.Add(backbtn);
            createuserpanel.Controls.Add(rolecombobox);
            createuserpanel.Controls.Add(rolelbl);
            createuserpanel.Controls.Add(createusertxt);
            createuserpanel.Controls.Add(savebtn);
            createuserpanel.Controls.Add(usernamelbl);
            createuserpanel.Controls.Add(createpasswordtxt);
            createuserpanel.Controls.Add(passwordlbl);
            createuserpanel.Location = new Point(417, 416);
            createuserpanel.Name = "createuserpanel";
            createuserpanel.Size = new Size(864, 587);
            createuserpanel.TabIndex = 6;
            // 
            // backbtn
            // 
            backbtn.Anchor = AnchorStyles.None;
            backbtn.BackColor = Color.Coral;
            backbtn.BackgroundImageLayout = ImageLayout.None;
            backbtn.Cursor = Cursors.Hand;
            backbtn.FlatStyle = FlatStyle.Flat;
            backbtn.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            backbtn.ForeColor = SystemColors.Window;
            backbtn.Location = new Point(379, 462);
            backbtn.Name = "backbtn";
            backbtn.Size = new Size(415, 63);
            backbtn.TabIndex = 7;
            backbtn.Text = "Back";
            backbtn.UseVisualStyleBackColor = false;
            backbtn.Click += backbtn_Click;
            // 
            // rolecombobox
            // 
            rolecombobox.Anchor = AnchorStyles.None;
            rolecombobox.Font = new Font("Sitka Display", 42F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rolecombobox.FormattingEnabled = true;
            rolecombobox.Items.AddRange(new object[] { "Admin", "Manager", "Staff", "HR", "Customer" });
            rolecombobox.Location = new Point(379, 247);
            rolecombobox.Name = "rolecombobox";
            rolecombobox.Size = new Size(415, 89);
            rolecombobox.TabIndex = 6;
            rolecombobox.SelectedIndexChanged += rolecombobox_SelectedIndexChanged;
            // 
            // rolelbl
            // 
            rolelbl.Anchor = AnchorStyles.None;
            rolelbl.AutoSize = true;
            rolelbl.BackColor = Color.Transparent;
            rolelbl.Font = new Font("Segoe UI", 45F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rolelbl.ForeColor = Color.Coral;
            rolelbl.Location = new Point(197, 245);
            rolelbl.Name = "rolelbl";
            rolelbl.Size = new Size(209, 81);
            rolelbl.TabIndex = 5;
            rolelbl.Text = "Role : ";
            rolelbl.TextAlign = ContentAlignment.MiddleRight;
            rolelbl.Click += rolelbl_Click;
            // 
            // createusertxt
            // 
            createusertxt.Anchor = AnchorStyles.None;
            createusertxt.BackColor = Color.White;
            createusertxt.BorderStyle = BorderStyle.None;
            createusertxt.Cursor = Cursors.IBeam;
            createusertxt.Font = new Font("Sitka Display", 42F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createusertxt.Location = new Point(379, 29);
            createusertxt.Multiline = true;
            createusertxt.Name = "createusertxt";
            createusertxt.Size = new Size(415, 81);
            createusertxt.TabIndex = 2;
            createusertxt.TextChanged += createusertxt_TextChanged;
            // 
            // savebtn
            // 
            savebtn.Anchor = AnchorStyles.None;
            savebtn.BackColor = Color.Green;
            savebtn.BackgroundImageLayout = ImageLayout.None;
            savebtn.Cursor = Cursors.Hand;
            savebtn.FlatStyle = FlatStyle.Flat;
            savebtn.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            savebtn.ForeColor = SystemColors.Window;
            savebtn.Location = new Point(379, 368);
            savebtn.Name = "savebtn";
            savebtn.Size = new Size(415, 63);
            savebtn.TabIndex = 4;
            savebtn.Text = "Save";
            savebtn.UseVisualStyleBackColor = false;
            savebtn.Click += savebtn_Click;
            // 
            // usernamelbl
            // 
            usernamelbl.Anchor = AnchorStyles.None;
            usernamelbl.AutoSize = true;
            usernamelbl.BackColor = Color.Transparent;
            usernamelbl.Font = new Font("Segoe UI", 45F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernamelbl.ForeColor = Color.Coral;
            usernamelbl.Location = new Point(40, 28);
            usernamelbl.Name = "usernamelbl";
            usernamelbl.Size = new Size(348, 81);
            usernamelbl.TabIndex = 0;
            usernamelbl.Text = "Username :";
            usernamelbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // createpasswordtxt
            // 
            createpasswordtxt.Anchor = AnchorStyles.None;
            createpasswordtxt.BackColor = Color.White;
            createpasswordtxt.BorderStyle = BorderStyle.None;
            createpasswordtxt.Cursor = Cursors.IBeam;
            createpasswordtxt.Font = new Font("Sitka Display", 42F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createpasswordtxt.Location = new Point(379, 139);
            createpasswordtxt.Multiline = true;
            createpasswordtxt.Name = "createpasswordtxt";
            createpasswordtxt.PasswordChar = '*';
            createpasswordtxt.Size = new Size(415, 81);
            createpasswordtxt.TabIndex = 3;
            createpasswordtxt.TextChanged += createpasswordtxt_TextChanged;
            // 
            // passwordlbl
            // 
            passwordlbl.Anchor = AnchorStyles.None;
            passwordlbl.AutoSize = true;
            passwordlbl.BackColor = Color.Transparent;
            passwordlbl.Font = new Font("Segoe UI", 45F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passwordlbl.ForeColor = Color.Coral;
            passwordlbl.Location = new Point(55, 138);
            passwordlbl.Name = "passwordlbl";
            passwordlbl.Size = new Size(351, 81);
            passwordlbl.TabIndex = 1;
            passwordlbl.Text = "Password : ";
            passwordlbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // CreateUserAdmin
            // 
            AcceptButton = savebtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.loginback;
            ClientSize = new Size(1698, 1061);
            Controls.Add(createuserpanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CreateUserAdmin";
            Text = "CreateUser";
            WindowState = FormWindowState.Maximized;
            Load += CreateUserAdmin_Load;
            createuserpanel.ResumeLayout(false);
            createuserpanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel createuserpanel;
        private TextBox createusertxt;
        private Label usernamelbl;
        private TextBox createpasswordtxt;
        private Label passwordlbl;
        private Label rolelbl;
        private Button savebtn;
        private ComboBox rolecombobox;
        private Button backbtn;
    }
}