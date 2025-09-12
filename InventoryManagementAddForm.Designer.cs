namespace FlavorFlowIT13
{
    partial class InventoryManagementAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryManagementAddForm));
            panelForm = new Panel();
            inventoryformminstocktxt = new TextBox();
            inventoryformminstocklbl = new Label();
            inventoryformsupplertxt = new ComboBox();
            inventoryformsupplierlbl = new Label();
            inventoryformdatepicker = new DateTimePicker();
            inventoryformexpirylbl = new Label();
            inventoryformcosttxt = new TextBox();
            inventoryformcostlbl = new Label();
            inventoryormpquantitytxt = new TextBox();
            panelFormHeader = new Panel();
            addmenuitemtxt = new Label();
            menuformsavebtn = new Button();
            inventoryformunitbox = new ComboBox();
            menuformstatuscheckbox = new CheckBox();
            inventoryformpquantitylbl = new Label();
            inventorynametxt = new TextBox();
            inventorynamelbl = new Label();
            unitformunitlbl = new Label();
            panelForm.SuspendLayout();
            panelFormHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.BackgroundImageLayout = ImageLayout.Zoom;
            panelForm.BorderStyle = BorderStyle.FixedSingle;
            panelForm.Controls.Add(inventoryformminstocktxt);
            panelForm.Controls.Add(inventoryformminstocklbl);
            panelForm.Controls.Add(inventoryformsupplertxt);
            panelForm.Controls.Add(inventoryformsupplierlbl);
            panelForm.Controls.Add(inventoryformdatepicker);
            panelForm.Controls.Add(inventoryformexpirylbl);
            panelForm.Controls.Add(inventoryformcosttxt);
            panelForm.Controls.Add(inventoryformcostlbl);
            panelForm.Controls.Add(inventoryormpquantitytxt);
            panelForm.Controls.Add(panelFormHeader);
            panelForm.Controls.Add(menuformsavebtn);
            panelForm.Controls.Add(inventoryformunitbox);
            panelForm.Controls.Add(menuformstatuscheckbox);
            panelForm.Controls.Add(inventoryformpquantitylbl);
            panelForm.Controls.Add(inventorynametxt);
            panelForm.Controls.Add(inventorynamelbl);
            panelForm.Controls.Add(unitformunitlbl);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(0, 0);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(1034, 869);
            panelForm.TabIndex = 2;
            panelForm.Paint += panelForm_Paint;
            // 
            // inventoryformminstocktxt
            // 
            inventoryformminstocktxt.Anchor = AnchorStyles.None;
            inventoryformminstocktxt.BackColor = Color.White;
            inventoryformminstocktxt.Cursor = Cursors.IBeam;
            inventoryformminstocktxt.Font = new Font("Sitka Display", 42F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inventoryformminstocktxt.Location = new Point(335, 688);
            inventoryformminstocktxt.Multiline = true;
            inventoryformminstocktxt.Name = "inventoryformminstocktxt";
            inventoryformminstocktxt.Size = new Size(480, 81);
            inventoryformminstocktxt.TabIndex = 42;
            inventoryformminstocktxt.WordWrap = false;
            inventoryformminstocktxt.TextChanged += inventoryformminstocktxt_TextChanged;
            // 
            // inventoryformminstocklbl
            // 
            inventoryformminstocklbl.AutoSize = true;
            inventoryformminstocklbl.BackColor = Color.Transparent;
            inventoryformminstocklbl.FlatStyle = FlatStyle.Flat;
            inventoryformminstocklbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            inventoryformminstocklbl.ForeColor = Color.DimGray;
            inventoryformminstocklbl.Location = new Point(98, 712);
            inventoryformminstocklbl.Name = "inventoryformminstocklbl";
            inventoryformminstocklbl.Size = new Size(231, 54);
            inventoryformminstocklbl.TabIndex = 41;
            inventoryformminstocklbl.Text = "MinStock : ";
            inventoryformminstocklbl.Click += inventoryformminstocklbl_Click;
            // 
            // inventoryformsupplertxt
            // 
            inventoryformsupplertxt.Font = new Font("Segoe UI", 35F);
            inventoryformsupplertxt.FormattingEnabled = true;
            inventoryformsupplertxt.Items.AddRange(new object[] { "ABC Food Supplies" });
            inventoryformsupplertxt.Location = new Point(335, 596);
            inventoryformsupplertxt.Name = "inventoryformsupplertxt";
            inventoryformsupplertxt.Size = new Size(480, 70);
            inventoryformsupplertxt.TabIndex = 40;
            inventoryformsupplertxt.SelectedIndexChanged += inventoryformsupplertxt_SelectedIndexChanged;
            // 
            // inventoryformsupplierlbl
            // 
            inventoryformsupplierlbl.AutoSize = true;
            inventoryformsupplierlbl.BackColor = Color.Transparent;
            inventoryformsupplierlbl.FlatStyle = FlatStyle.Flat;
            inventoryformsupplierlbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            inventoryformsupplierlbl.ForeColor = Color.DimGray;
            inventoryformsupplierlbl.Location = new Point(117, 609);
            inventoryformsupplierlbl.Name = "inventoryformsupplierlbl";
            inventoryformsupplierlbl.Size = new Size(212, 54);
            inventoryformsupplierlbl.TabIndex = 39;
            inventoryformsupplierlbl.Text = "Supplier : ";
            // 
            // inventoryformdatepicker
            // 
            inventoryformdatepicker.Font = new Font("Segoe UI", 35F);
            inventoryformdatepicker.Format = DateTimePickerFormat.Custom;
            inventoryformdatepicker.Location = new Point(335, 496);
            inventoryformdatepicker.Name = "inventoryformdatepicker";
            inventoryformdatepicker.Size = new Size(480, 70);
            inventoryformdatepicker.TabIndex = 38;
            inventoryformdatepicker.ValueChanged += inventoryformdatepicker_ValueChanged;
            // 
            // inventoryformexpirylbl
            // 
            inventoryformexpirylbl.AutoSize = true;
            inventoryformexpirylbl.BackColor = Color.Transparent;
            inventoryformexpirylbl.FlatStyle = FlatStyle.Flat;
            inventoryformexpirylbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            inventoryformexpirylbl.ForeColor = Color.DimGray;
            inventoryformexpirylbl.Location = new Point(64, 506);
            inventoryformexpirylbl.Name = "inventoryformexpirylbl";
            inventoryformexpirylbl.Size = new Size(265, 54);
            inventoryformexpirylbl.TabIndex = 36;
            inventoryformexpirylbl.Text = "ExpiryDate : ";
            // 
            // inventoryformcosttxt
            // 
            inventoryformcosttxt.Anchor = AnchorStyles.None;
            inventoryformcosttxt.BackColor = Color.White;
            inventoryformcosttxt.Cursor = Cursors.IBeam;
            inventoryformcosttxt.Font = new Font("Sitka Display", 42F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inventoryformcosttxt.Location = new Point(335, 395);
            inventoryformcosttxt.Multiline = true;
            inventoryformcosttxt.Name = "inventoryformcosttxt";
            inventoryformcosttxt.Size = new Size(480, 81);
            inventoryformcosttxt.TabIndex = 35;
            inventoryformcosttxt.WordWrap = false;
            inventoryformcosttxt.TextChanged += inventoryformcosttxt_TextChanged;
            // 
            // inventoryformcostlbl
            // 
            inventoryformcostlbl.AutoSize = true;
            inventoryformcostlbl.BackColor = Color.Transparent;
            inventoryformcostlbl.FlatStyle = FlatStyle.Flat;
            inventoryformcostlbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            inventoryformcostlbl.ForeColor = Color.DimGray;
            inventoryformcostlbl.Location = new Point(193, 416);
            inventoryformcostlbl.Name = "inventoryformcostlbl";
            inventoryformcostlbl.Size = new Size(139, 54);
            inventoryformcostlbl.TabIndex = 34;
            inventoryformcostlbl.Text = "Cost : ";
            // 
            // inventoryormpquantitytxt
            // 
            inventoryormpquantitytxt.Anchor = AnchorStyles.None;
            inventoryormpquantitytxt.BackColor = Color.White;
            inventoryormpquantitytxt.Cursor = Cursors.IBeam;
            inventoryormpquantitytxt.Font = new Font("Sitka Display", 42F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inventoryormpquantitytxt.Location = new Point(335, 205);
            inventoryormpquantitytxt.Multiline = true;
            inventoryormpquantitytxt.Name = "inventoryormpquantitytxt";
            inventoryormpquantitytxt.Size = new Size(480, 81);
            inventoryormpquantitytxt.TabIndex = 33;
            inventoryormpquantitytxt.WordWrap = false;
            inventoryormpquantitytxt.TextChanged += inventoryormpquantitytxt_TextChanged;
            // 
            // panelFormHeader
            // 
            panelFormHeader.BackColor = Color.Coral;
            panelFormHeader.Controls.Add(addmenuitemtxt);
            panelFormHeader.Location = new Point(0, 0);
            panelFormHeader.Name = "panelFormHeader";
            panelFormHeader.Size = new Size(1280, 63);
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
            addmenuitemtxt.Location = new Point(14, 13);
            addmenuitemtxt.Name = "addmenuitemtxt";
            addmenuitemtxt.Size = new Size(286, 37);
            addmenuitemtxt.TabIndex = 19;
            addmenuitemtxt.Text = "Input Inventory Item";
            // 
            // menuformsavebtn
            // 
            menuformsavebtn.BackColor = Color.LimeGreen;
            menuformsavebtn.FlatStyle = FlatStyle.Flat;
            menuformsavebtn.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuformsavebtn.ForeColor = Color.White;
            menuformsavebtn.Location = new Point(675, 788);
            menuformsavebtn.Name = "menuformsavebtn";
            menuformsavebtn.Size = new Size(140, 41);
            menuformsavebtn.TabIndex = 32;
            menuformsavebtn.Text = "Save";
            menuformsavebtn.UseVisualStyleBackColor = false;
            menuformsavebtn.Click += menuformsavebtn_Click;
            // 
            // inventoryformunitbox
            // 
            inventoryformunitbox.Font = new Font("Segoe UI Light", 35.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inventoryformunitbox.FormattingEnabled = true;
            inventoryformunitbox.Items.AddRange(new object[] { "kg", "grams", "pcs", "liters" });
            inventoryformunitbox.Location = new Point(335, 305);
            inventoryformunitbox.Name = "inventoryformunitbox";
            inventoryformunitbox.Size = new Size(480, 70);
            inventoryformunitbox.TabIndex = 30;
            inventoryformunitbox.SelectedIndexChanged += inventoryformunitbox_SelectedIndexChanged;
            // 
            // menuformstatuscheckbox
            // 
            menuformstatuscheckbox.AutoSize = true;
            menuformstatuscheckbox.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            menuformstatuscheckbox.ForeColor = Color.LimeGreen;
            menuformstatuscheckbox.Location = new Point(335, 788);
            menuformstatuscheckbox.Name = "menuformstatuscheckbox";
            menuformstatuscheckbox.Size = new Size(155, 41);
            menuformstatuscheckbox.TabIndex = 28;
            menuformstatuscheckbox.Text = "Available";
            menuformstatuscheckbox.UseVisualStyleBackColor = true;
            menuformstatuscheckbox.CheckedChanged += menuformstatuscheckbox_CheckedChanged;
            // 
            // inventoryformpquantitylbl
            // 
            inventoryformpquantitylbl.AutoSize = true;
            inventoryformpquantitylbl.BackColor = Color.Transparent;
            inventoryformpquantitylbl.FlatStyle = FlatStyle.Flat;
            inventoryformpquantitylbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            inventoryformpquantitylbl.ForeColor = Color.DimGray;
            inventoryformpquantitylbl.Location = new Point(108, 228);
            inventoryformpquantitylbl.Name = "inventoryformpquantitylbl";
            inventoryformpquantitylbl.Size = new Size(221, 54);
            inventoryformpquantitylbl.TabIndex = 26;
            inventoryformpquantitylbl.Text = "Quantity : ";
            // 
            // inventorynametxt
            // 
            inventorynametxt.Anchor = AnchorStyles.None;
            inventorynametxt.BackColor = Color.White;
            inventorynametxt.Cursor = Cursors.IBeam;
            inventorynametxt.Font = new Font("Sitka Display", 42F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inventorynametxt.Location = new Point(335, 102);
            inventorynametxt.Multiline = true;
            inventorynametxt.Name = "inventorynametxt";
            inventorynametxt.Size = new Size(480, 81);
            inventorynametxt.TabIndex = 21;
            inventorynametxt.WordWrap = false;
            inventorynametxt.TextChanged += inventorynametxt_TextChanged;
            // 
            // inventorynamelbl
            // 
            inventorynamelbl.AutoSize = true;
            inventorynamelbl.BackColor = Color.Transparent;
            inventorynamelbl.FlatStyle = FlatStyle.Flat;
            inventorynamelbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            inventorynamelbl.ForeColor = Color.DimGray;
            inventorynamelbl.Location = new Point(160, 126);
            inventorynamelbl.Name = "inventorynamelbl";
            inventorynamelbl.Size = new Size(169, 54);
            inventorynamelbl.TabIndex = 20;
            inventorynamelbl.Text = "Name : ";
            // 
            // unitformunitlbl
            // 
            unitformunitlbl.AutoSize = true;
            unitformunitlbl.BackColor = Color.Transparent;
            unitformunitlbl.FlatStyle = FlatStyle.Flat;
            unitformunitlbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            unitformunitlbl.ForeColor = Color.DimGray;
            unitformunitlbl.Location = new Point(193, 318);
            unitformunitlbl.Name = "unitformunitlbl";
            unitformunitlbl.Size = new Size(136, 54);
            unitformunitlbl.TabIndex = 31;
            unitformunitlbl.Text = "Unit : ";
            // 
            // InventoryManagementAddForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 869);
            Controls.Add(panelForm);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(900, 750);
            Name = "InventoryManagementAddForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InventoryManagementAddForm";
            Load += InventoryManagementAddForm_Load;
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            panelFormHeader.ResumeLayout(false);
            panelFormHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelForm;
        private Button menuformsavebtn;
        private Label unitformunitlbl;
        private ComboBox inventoryformunitbox;
        private CheckBox menuformstatuscheckbox;
        private Label inventoryformpquantitylbl;
        private Label inventorynamelbl;
        private Panel panelFormHeader;
        private Label addmenuitemtxt;
        private TextBox inventorynametxt;
        private TextBox inventoryormpquantitytxt;
        private TextBox inventoryformcosttxt;
        private Label inventoryformcostlbl;
        private Label inventoryformexpirylbl;
        private DateTimePicker inventoryformdatepicker;
        private Label inventoryformsupplierlbl;
        private ComboBox inventoryformsupplertxt;
        private TextBox inventoryformminstocktxt;
        private Label inventoryformminstocklbl;
    }
}