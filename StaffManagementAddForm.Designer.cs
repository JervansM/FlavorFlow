namespace FlavorFlowIT13
{
    partial class StaffManagementAddForm
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
            panelForm = new Panel();
            stafftxt = new TextBox();
            contactlbl = new Label();
            contacttxt = new TextBox();
            closebtn = new Button();
            roleselecttxt = new ComboBox();
            addstaffbtn = new Button();
            rolelbl = new Label();
            stafflbl = new Label();
            panelForm.SuspendLayout();
            SuspendLayout();
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.BackgroundImageLayout = ImageLayout.Zoom;
            panelForm.Controls.Add(stafftxt);
            panelForm.Controls.Add(contactlbl);
            panelForm.Controls.Add(contacttxt);
            panelForm.Controls.Add(closebtn);
            panelForm.Controls.Add(roleselecttxt);
            panelForm.Controls.Add(addstaffbtn);
            panelForm.Controls.Add(rolelbl);
            panelForm.Controls.Add(stafflbl);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(0, 0);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(1077, 778);
            panelForm.TabIndex = 2;
            panelForm.Paint += panelForm_Paint;
            // 
            // stafftxt
            // 
            stafftxt.Anchor = AnchorStyles.None;
            stafftxt.BackColor = Color.White;
            stafftxt.Cursor = Cursors.IBeam;
            stafftxt.Font = new Font("Segoe UI", 42F);
            stafftxt.Location = new Point(376, 102);
            stafftxt.Multiline = true;
            stafftxt.Name = "stafftxt";
            stafftxt.Size = new Size(480, 81);
            stafftxt.TabIndex = 38;
            stafftxt.WordWrap = false;
            stafftxt.TextChanged += stafftxt_TextChanged;
            // 
            // contactlbl
            // 
            contactlbl.AutoSize = true;
            contactlbl.BackColor = Color.Transparent;
            contactlbl.FlatStyle = FlatStyle.Flat;
            contactlbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            contactlbl.ForeColor = Color.DimGray;
            contactlbl.Location = new Point(136, 361);
            contactlbl.Name = "contactlbl";
            contactlbl.Size = new Size(191, 54);
            contactlbl.TabIndex = 37;
            contactlbl.Text = "Contact :";
            // 
            // contacttxt
            // 
            contacttxt.Anchor = AnchorStyles.None;
            contacttxt.BackColor = Color.White;
            contacttxt.Cursor = Cursors.IBeam;
            contacttxt.Font = new Font("Segoe UI", 42F);
            contacttxt.Location = new Point(376, 334);
            contacttxt.Multiline = true;
            contacttxt.Name = "contacttxt";
            contacttxt.Size = new Size(480, 81);
            contacttxt.TabIndex = 36;
            contacttxt.WordWrap = false;
            contacttxt.TextChanged += suppliercosttxt_TextChanged;
            // 
            // closebtn
            // 
            closebtn.BackColor = Color.Silver;
            closebtn.Cursor = Cursors.Hand;
            closebtn.FlatStyle = FlatStyle.Flat;
            closebtn.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            closebtn.ForeColor = Color.White;
            closebtn.Location = new Point(376, 527);
            closebtn.Name = "closebtn";
            closebtn.Size = new Size(480, 57);
            closebtn.TabIndex = 35;
            closebtn.Text = "CLOSE";
            closebtn.UseVisualStyleBackColor = false;
            closebtn.Click += closebtn_Click;
            // 
            // roleselecttxt
            // 
            roleselecttxt.Font = new Font("Segoe UI Light", 35.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            roleselecttxt.FormattingEnabled = true;
            roleselecttxt.Items.AddRange(new object[] { "Manager", "Cashier", "HR", "Cook", "Staff", "Waiter", "Delivery Rider" });
            roleselecttxt.Location = new Point(376, 216);
            roleselecttxt.Name = "roleselecttxt";
            roleselecttxt.Size = new Size(480, 70);
            roleselecttxt.TabIndex = 33;
            roleselecttxt.SelectedIndexChanged += roleselecttxt_SelectedIndexChanged;
            // 
            // addstaffbtn
            // 
            addstaffbtn.BackColor = Color.LimeGreen;
            addstaffbtn.Cursor = Cursors.Hand;
            addstaffbtn.FlatStyle = FlatStyle.Flat;
            addstaffbtn.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addstaffbtn.ForeColor = Color.White;
            addstaffbtn.Location = new Point(376, 455);
            addstaffbtn.Name = "addstaffbtn";
            addstaffbtn.Size = new Size(480, 57);
            addstaffbtn.TabIndex = 32;
            addstaffbtn.Text = "ADD STAFF";
            addstaffbtn.UseVisualStyleBackColor = false;
            addstaffbtn.Click += addstaffbtn_Click;
            // 
            // rolelbl
            // 
            rolelbl.AutoSize = true;
            rolelbl.BackColor = Color.Transparent;
            rolelbl.FlatStyle = FlatStyle.Flat;
            rolelbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            rolelbl.ForeColor = Color.DimGray;
            rolelbl.Location = new Point(199, 232);
            rolelbl.Name = "rolelbl";
            rolelbl.Size = new Size(138, 54);
            rolelbl.TabIndex = 26;
            rolelbl.Text = "Role : ";
            // 
            // stafflbl
            // 
            stafflbl.AutoSize = true;
            stafflbl.BackColor = Color.Transparent;
            stafflbl.FlatStyle = FlatStyle.Flat;
            stafflbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            stafflbl.ForeColor = Color.DimGray;
            stafflbl.Location = new Point(169, 122);
            stafflbl.Name = "stafflbl";
            stafflbl.Size = new Size(158, 54);
            stafflbl.TabIndex = 20;
            stafflbl.Text = "Name :";
            // 
            // StaffManagementAddForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1077, 778);
            Controls.Add(panelForm);
            Name = "StaffManagementAddForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StaffManagementAddForm";
            Load += StaffManagementAddForm_Load;
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelForm;
        private Label contactlbl;
        private TextBox contacttxt;
        private Button closebtn;
        private TextBox supplierbillamounttxt;
        private ComboBox roleselecttxt;
        private Button addstaffbtn;
        private Label supplierbillamountlbl;
        private ComboBox supplierselecttxt;
        private Label rolelbl;
        private Label supplierquantitylbl;
        private TextBox supplierquantitytxt;
        private Label stafflbl;
        private TextBox stafftxt;
    }
}