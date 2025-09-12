namespace FlavorFlowIT13
{
    partial class MenuRecipeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuRecipeForm));
            panelForm = new Panel();
            recipeGrid = new DataGridView();
            manageunitrecipetxt = new ComboBox();
            label2 = new Label();
            inventoryitemdata = new ComboBox();
            panelFormHeader = new Panel();
            addmenuitemtxt = new Label();
            menuformsavebtn = new Button();
            menuitemsdata = new ComboBox();
            quantitydata = new TextBox();
            menunamelbl = new Label();
            inventoryitemlbl = new Label();
            quantitylbl = new Label();
            panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)recipeGrid).BeginInit();
            panelFormHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.BackgroundImageLayout = ImageLayout.Zoom;
            panelForm.Controls.Add(recipeGrid);
            panelForm.Controls.Add(manageunitrecipetxt);
            panelForm.Controls.Add(label2);
            panelForm.Controls.Add(inventoryitemdata);
            panelForm.Controls.Add(panelFormHeader);
            panelForm.Controls.Add(menuformsavebtn);
            panelForm.Controls.Add(menuitemsdata);
            panelForm.Controls.Add(quantitydata);
            panelForm.Controls.Add(menunamelbl);
            panelForm.Controls.Add(inventoryitemlbl);
            panelForm.Controls.Add(quantitylbl);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(0, 0);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(1207, 999);
            panelForm.TabIndex = 2;
            panelForm.Paint += panelForm_Paint;
            // 
            // recipeGrid
            // 
            recipeGrid.AllowUserToAddRows = false;
            recipeGrid.AllowUserToDeleteRows = false;
            recipeGrid.BackgroundColor = Color.White;
            recipeGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            recipeGrid.Location = new Point(0, 609);
            recipeGrid.Name = "recipeGrid";
            recipeGrid.ReadOnly = true;
            recipeGrid.Size = new Size(1207, 390);
            recipeGrid.TabIndex = 38;
            recipeGrid.CellContentClick += recipeGrid_CellContentClick;
            // 
            // manageunitrecipetxt
            // 
            manageunitrecipetxt.Font = new Font("Segoe UI Light", 35.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            manageunitrecipetxt.FormattingEnabled = true;
            manageunitrecipetxt.Location = new Point(430, 336);
            manageunitrecipetxt.Name = "manageunitrecipetxt";
            manageunitrecipetxt.Size = new Size(545, 70);
            manageunitrecipetxt.TabIndex = 36;
            manageunitrecipetxt.SelectedIndexChanged += manageunitrecipetxt_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(298, 346);
            label2.Name = "label2";
            label2.Size = new Size(136, 54);
            label2.TabIndex = 35;
            label2.Text = "Unit : ";
            // 
            // inventoryitemdata
            // 
            inventoryitemdata.Font = new Font("Segoe UI Light", 35.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inventoryitemdata.FormattingEnabled = true;
            inventoryitemdata.Location = new Point(430, 229);
            inventoryitemdata.Name = "inventoryitemdata";
            inventoryitemdata.Size = new Size(545, 70);
            inventoryitemdata.TabIndex = 34;
            inventoryitemdata.SelectedIndexChanged += inventoryitemdata_SelectedIndexChanged;
            // 
            // panelFormHeader
            // 
            panelFormHeader.BackColor = Color.Coral;
            panelFormHeader.Controls.Add(addmenuitemtxt);
            panelFormHeader.Location = new Point(0, 0);
            panelFormHeader.Name = "panelFormHeader";
            panelFormHeader.Size = new Size(1207, 74);
            panelFormHeader.TabIndex = 3;
            panelFormHeader.Paint += panelFormHeader_Paint;
            // 
            // addmenuitemtxt
            // 
            addmenuitemtxt.AutoSize = true;
            addmenuitemtxt.BackColor = Color.Transparent;
            addmenuitemtxt.FlatStyle = FlatStyle.Flat;
            addmenuitemtxt.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            addmenuitemtxt.ForeColor = Color.White;
            addmenuitemtxt.Location = new Point(12, 19);
            addmenuitemtxt.Name = "addmenuitemtxt";
            addmenuitemtxt.Size = new Size(213, 37);
            addmenuitemtxt.TabIndex = 19;
            addmenuitemtxt.Text = "Manage Recipe";
            // 
            // menuformsavebtn
            // 
            menuformsavebtn.BackColor = Color.LimeGreen;
            menuformsavebtn.FlatStyle = FlatStyle.Flat;
            menuformsavebtn.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuformsavebtn.ForeColor = Color.White;
            menuformsavebtn.Location = new Point(770, 540);
            menuformsavebtn.Name = "menuformsavebtn";
            menuformsavebtn.Size = new Size(205, 51);
            menuformsavebtn.TabIndex = 32;
            menuformsavebtn.Text = "Save";
            menuformsavebtn.UseVisualStyleBackColor = false;
            menuformsavebtn.Click += menuformsavebtn_Click;
            // 
            // menuitemsdata
            // 
            menuitemsdata.Font = new Font("Segoe UI Light", 35.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuitemsdata.FormattingEnabled = true;
            menuitemsdata.Location = new Point(430, 105);
            menuitemsdata.Name = "menuitemsdata";
            menuitemsdata.Size = new Size(545, 70);
            menuitemsdata.TabIndex = 30;
            menuitemsdata.SelectedIndexChanged += menuitemsdata_SelectedIndexChanged;
            // 
            // quantitydata
            // 
            quantitydata.Anchor = AnchorStyles.None;
            quantitydata.BackColor = Color.White;
            quantitydata.Cursor = Cursors.IBeam;
            quantitydata.Font = new Font("Sitka Display", 42F, FontStyle.Regular, GraphicsUnit.Point, 0);
            quantitydata.Location = new Point(430, 446);
            quantitydata.Multiline = true;
            quantitydata.Name = "quantitydata";
            quantitydata.Size = new Size(545, 78);
            quantitydata.TabIndex = 21;
            quantitydata.WordWrap = false;
            quantitydata.TextChanged += quantitydata_TextChanged;
            // 
            // menunamelbl
            // 
            menunamelbl.AutoSize = true;
            menunamelbl.BackColor = Color.Transparent;
            menunamelbl.FlatStyle = FlatStyle.Flat;
            menunamelbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            menunamelbl.ForeColor = Color.DimGray;
            menunamelbl.Location = new Point(172, 115);
            menunamelbl.Name = "menunamelbl";
            menunamelbl.Size = new Size(252, 54);
            menunamelbl.TabIndex = 20;
            menunamelbl.Text = "Menu Item :";
            menunamelbl.Click += menunamelbl_Click;
            // 
            // inventoryitemlbl
            // 
            inventoryitemlbl.AutoSize = true;
            inventoryitemlbl.BackColor = Color.Transparent;
            inventoryitemlbl.FlatStyle = FlatStyle.Flat;
            inventoryitemlbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            inventoryitemlbl.ForeColor = Color.DimGray;
            inventoryitemlbl.Location = new Point(94, 239);
            inventoryitemlbl.Name = "inventoryitemlbl";
            inventoryitemlbl.Size = new Size(340, 54);
            inventoryitemlbl.TabIndex = 33;
            inventoryitemlbl.Text = "Inventory Item : ";
            // 
            // quantitylbl
            // 
            quantitylbl.AutoSize = true;
            quantitylbl.BackColor = Color.Transparent;
            quantitylbl.FlatStyle = FlatStyle.Flat;
            quantitylbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            quantitylbl.ForeColor = Color.DimGray;
            quantitylbl.Location = new Point(213, 470);
            quantitylbl.Name = "quantitylbl";
            quantitylbl.Size = new Size(221, 54);
            quantitylbl.TabIndex = 37;
            quantitylbl.Text = "Quantity : ";
            // 
            // MenuRecipeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1207, 999);
            Controls.Add(panelForm);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(700, 1038);
            Name = "MenuRecipeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MenuRecipeForm";
            Load += MenuRecipeForm_Load;
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)recipeGrid).EndInit();
            panelFormHeader.ResumeLayout(false);
            panelFormHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelForm;
        private Panel panelFormHeader;
        private Label addmenuitemtxt;
        private Button menuformsavebtn;
        private ComboBox menuitemsdata;
        private TextBox quantitydata;
        private Label menunamelbl;
        private ComboBox inventoryitemdata;
        private Label inventoryitemlbl;
        private ComboBox manageunitrecipetxt;
        private Label label2;
        private Label quantitylbl;
        private DataGridView recipeGrid;
    }
}