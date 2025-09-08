namespace FlavorFlowIT13
{
    partial class MenuManagementAddMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuManagementAddMenuForm));
            panelForm = new Panel();
            menuformimagepreviewtxt = new Label();
            pictoreBoxMenu = new PictureBox();
            menuformsavebtn = new Button();
            menuformcategorylbl = new Label();
            menuformcategory = new ComboBox();
            menuformselectimagebtn = new Button();
            menuformstatuscheckbox = new CheckBox();
            menuformpricetxt = new TextBox();
            menuformpricelbl = new Label();
            menuformdesctxt = new TextBox();
            menuformdesclbl = new Label();
            menunametxt = new TextBox();
            menunamelbl = new Label();
            panelFormHeader = new Panel();
            addmenuitemtxt = new Label();
            panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictoreBoxMenu).BeginInit();
            panelFormHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.BackgroundImage = Properties.Resources.logo;
            panelForm.BackgroundImageLayout = ImageLayout.Zoom;
            panelForm.Controls.Add(menuformimagepreviewtxt);
            panelForm.Controls.Add(pictoreBoxMenu);
            panelForm.Controls.Add(menuformsavebtn);
            panelForm.Controls.Add(menuformcategorylbl);
            panelForm.Controls.Add(menuformcategory);
            panelForm.Controls.Add(menuformselectimagebtn);
            panelForm.Controls.Add(menuformstatuscheckbox);
            panelForm.Controls.Add(menuformpricetxt);
            panelForm.Controls.Add(menuformpricelbl);
            panelForm.Controls.Add(menuformdesctxt);
            panelForm.Controls.Add(menuformdesclbl);
            panelForm.Controls.Add(menunametxt);
            panelForm.Controls.Add(menunamelbl);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(0, 0);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(1180, 707);
            panelForm.TabIndex = 0;
            panelForm.Paint += panelForm_Paint;
            // 
            // menuformimagepreviewtxt
            // 
            menuformimagepreviewtxt.AutoSize = true;
            menuformimagepreviewtxt.BackColor = Color.Transparent;
            menuformimagepreviewtxt.FlatStyle = FlatStyle.Flat;
            menuformimagepreviewtxt.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            menuformimagepreviewtxt.ForeColor = Color.DimGray;
            menuformimagepreviewtxt.Location = new Point(861, 436);
            menuformimagepreviewtxt.Name = "menuformimagepreviewtxt";
            menuformimagepreviewtxt.Size = new Size(254, 46);
            menuformimagepreviewtxt.TabIndex = 34;
            menuformimagepreviewtxt.Text = "Image Preview";
            // 
            // pictoreBoxMenu
            // 
            pictoreBoxMenu.BackColor = Color.Transparent;
            pictoreBoxMenu.BorderStyle = BorderStyle.FixedSingle;
            pictoreBoxMenu.Location = new Point(798, 105);
            pictoreBoxMenu.Name = "pictoreBoxMenu";
            pictoreBoxMenu.Size = new Size(362, 328);
            pictoreBoxMenu.SizeMode = PictureBoxSizeMode.AutoSize;
            pictoreBoxMenu.TabIndex = 33;
            pictoreBoxMenu.TabStop = false;
            pictoreBoxMenu.Click += pictoreBoxMenu_Click;
            // 
            // menuformsavebtn
            // 
            menuformsavebtn.BackColor = Color.LimeGreen;
            menuformsavebtn.FlatStyle = FlatStyle.Flat;
            menuformsavebtn.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuformsavebtn.ForeColor = Color.White;
            menuformsavebtn.Location = new Point(636, 615);
            menuformsavebtn.Name = "menuformsavebtn";
            menuformsavebtn.Size = new Size(140, 41);
            menuformsavebtn.TabIndex = 32;
            menuformsavebtn.Text = "Save";
            menuformsavebtn.UseVisualStyleBackColor = false;
            menuformsavebtn.Click += menuformsavebtn_Click;
            // 
            // menuformcategorylbl
            // 
            menuformcategorylbl.AutoSize = true;
            menuformcategorylbl.BackColor = Color.Transparent;
            menuformcategorylbl.FlatStyle = FlatStyle.Flat;
            menuformcategorylbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            menuformcategorylbl.ForeColor = Color.DimGray;
            menuformcategorylbl.Location = new Point(60, 379);
            menuformcategorylbl.Name = "menuformcategorylbl";
            menuformcategorylbl.Size = new Size(230, 54);
            menuformcategorylbl.TabIndex = 31;
            menuformcategorylbl.Text = "Category : ";
            // 
            // menuformcategory
            // 
            menuformcategory.Font = new Font("Segoe UI Light", 35.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuformcategory.FormattingEnabled = true;
            menuformcategory.Items.AddRange(new object[] { " Appetizers", " Main Courses", " Beverages", " Desserts" });
            menuformcategory.Location = new Point(296, 363);
            menuformcategory.Name = "menuformcategory";
            menuformcategory.Size = new Size(480, 70);
            menuformcategory.TabIndex = 30;
            menuformcategory.SelectedIndexChanged += menuformcategory_SelectedIndexChanged;
            // 
            // menuformselectimagebtn
            // 
            menuformselectimagebtn.BackColor = Color.Gray;
            menuformselectimagebtn.FlatStyle = FlatStyle.Flat;
            menuformselectimagebtn.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuformselectimagebtn.ForeColor = Color.White;
            menuformselectimagebtn.Location = new Point(489, 615);
            menuformselectimagebtn.Name = "menuformselectimagebtn";
            menuformselectimagebtn.Size = new Size(140, 41);
            menuformselectimagebtn.TabIndex = 29;
            menuformselectimagebtn.Text = "Select Image";
            menuformselectimagebtn.UseVisualStyleBackColor = false;
            menuformselectimagebtn.Click += menuformselectimagebtn_Click;
            // 
            // menuformstatuscheckbox
            // 
            menuformstatuscheckbox.AutoSize = true;
            menuformstatuscheckbox.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            menuformstatuscheckbox.ForeColor = Color.LimeGreen;
            menuformstatuscheckbox.Location = new Point(296, 615);
            menuformstatuscheckbox.Name = "menuformstatuscheckbox";
            menuformstatuscheckbox.Size = new Size(155, 41);
            menuformstatuscheckbox.TabIndex = 28;
            menuformstatuscheckbox.Text = "Available";
            menuformstatuscheckbox.UseVisualStyleBackColor = true;
            menuformstatuscheckbox.CheckedChanged += menuformstatuscheckbox_CheckedChanged;
            // 
            // menuformpricetxt
            // 
            menuformpricetxt.Anchor = AnchorStyles.None;
            menuformpricetxt.BackColor = Color.White;
            menuformpricetxt.Cursor = Cursors.IBeam;
            menuformpricetxt.Font = new Font("Sitka Display", 42F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuformpricetxt.Location = new Point(296, 229);
            menuformpricetxt.Multiline = true;
            menuformpricetxt.Name = "menuformpricetxt";
            menuformpricetxt.Size = new Size(480, 81);
            menuformpricetxt.TabIndex = 27;
            // 
            // menuformpricelbl
            // 
            menuformpricelbl.AutoSize = true;
            menuformpricelbl.BackColor = Color.Transparent;
            menuformpricelbl.FlatStyle = FlatStyle.Flat;
            menuformpricelbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            menuformpricelbl.ForeColor = Color.DimGray;
            menuformpricelbl.Location = new Point(141, 256);
            menuformpricelbl.Name = "menuformpricelbl";
            menuformpricelbl.Size = new Size(149, 54);
            menuformpricelbl.TabIndex = 26;
            menuformpricelbl.Text = "Price : ";
            // 
            // menuformdesctxt
            // 
            menuformdesctxt.Anchor = AnchorStyles.None;
            menuformdesctxt.BackColor = Color.White;
            menuformdesctxt.Cursor = Cursors.IBeam;
            menuformdesctxt.Font = new Font("Sitka Display", 25F);
            menuformdesctxt.Location = new Point(296, 478);
            menuformdesctxt.Multiline = true;
            menuformdesctxt.Name = "menuformdesctxt";
            menuformdesctxt.Size = new Size(480, 110);
            menuformdesctxt.TabIndex = 23;
            // 
            // menuformdesclbl
            // 
            menuformdesclbl.AutoSize = true;
            menuformdesclbl.BackColor = Color.Transparent;
            menuformdesclbl.FlatStyle = FlatStyle.Flat;
            menuformdesclbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            menuformdesclbl.ForeColor = Color.DimGray;
            menuformdesclbl.Location = new Point(18, 534);
            menuformdesclbl.Name = "menuformdesclbl";
            menuformdesclbl.Size = new Size(272, 54);
            menuformdesclbl.TabIndex = 22;
            menuformdesclbl.Text = "Description : ";
            // 
            // menunametxt
            // 
            menunametxt.Anchor = AnchorStyles.None;
            menunametxt.BackColor = Color.White;
            menunametxt.Cursor = Cursors.IBeam;
            menunametxt.Font = new Font("Sitka Display", 42F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menunametxt.Location = new Point(296, 105);
            menunametxt.Multiline = true;
            menunametxt.Name = "menunametxt";
            menunametxt.Size = new Size(480, 81);
            menunametxt.TabIndex = 21;
            // 
            // menunamelbl
            // 
            menunamelbl.AutoSize = true;
            menunamelbl.BackColor = Color.Transparent;
            menunamelbl.FlatStyle = FlatStyle.Flat;
            menunamelbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            menunamelbl.ForeColor = Color.DimGray;
            menunamelbl.Location = new Point(121, 129);
            menunamelbl.Name = "menunamelbl";
            menunamelbl.Size = new Size(169, 54);
            menunamelbl.TabIndex = 20;
            menunamelbl.Text = "Name : ";
            menunamelbl.Click += menunamelbl_Click;
            // 
            // panelFormHeader
            // 
            panelFormHeader.BackColor = Color.Coral;
            panelFormHeader.Controls.Add(addmenuitemtxt);
            panelFormHeader.Location = new Point(0, 0);
            panelFormHeader.Name = "panelFormHeader";
            panelFormHeader.Size = new Size(1180, 63);
            panelFormHeader.TabIndex = 1;
            panelFormHeader.Paint += panelFormHeader_Paint;
            // 
            // addmenuitemtxt
            // 
            addmenuitemtxt.AutoSize = true;
            addmenuitemtxt.BackColor = Color.Transparent;
            addmenuitemtxt.FlatStyle = FlatStyle.Flat;
            addmenuitemtxt.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            addmenuitemtxt.ForeColor = Color.White;
            addmenuitemtxt.Location = new Point(14, 13);
            addmenuitemtxt.Name = "addmenuitemtxt";
            addmenuitemtxt.Size = new Size(282, 37);
            addmenuitemtxt.TabIndex = 19;
            addmenuitemtxt.Text = "Add New Menu Item";
            // 
            // MenuManagementAddMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.loginback;
            ClientSize = new Size(1180, 707);
            Controls.Add(panelFormHeader);
            Controls.Add(panelForm);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(900, 750);
            Name = "MenuManagementAddMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu Form";
            Load += MenuManagementAddMenuForm_Load;
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictoreBoxMenu).EndInit();
            panelFormHeader.ResumeLayout(false);
            panelFormHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelForm;
        private Panel panelFormHeader;
        private Label addmenuitemtxt;
        private Label menunamelbl;
        private TextBox menunametxt;
        private TextBox menuformdesctxt;
        private Label menuformdesclbl;
        private TextBox menuformpricetxt;
        private Label menuformpricelbl;
        private CheckBox menuformstatuscheckbox;
        private Button menuformselectimagebtn;
        private ComboBox menuformcategory;
        private Label menuformcategorylbl;
        private Button menuformsavebtn;
        private PictureBox pictoreBoxMenu;
        private Label menuformimagepreviewtxt;
    }
}