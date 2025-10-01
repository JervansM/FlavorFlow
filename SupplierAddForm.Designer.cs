namespace FlavorFlowIT13
{
    partial class SupplierAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierAddForm));
            panelForm = new Panel();
            suppliercontacttxt = new TextBox();
            suppliersavebtn = new Button();
            suppliercontactlbl = new Label();
            supplliernametxt = new TextBox();
            supplieraddresslbl = new Label();
            supplieraddresstxt = new TextBox();
            suplliernamelbl = new Label();
            panelFormHeader = new Panel();
            addmenuitemtxt = new Label();
            panelForm.SuspendLayout();
            panelFormHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.BackgroundImageLayout = ImageLayout.Zoom;
            panelForm.Controls.Add(suppliercontacttxt);
            panelForm.Controls.Add(suppliersavebtn);
            panelForm.Controls.Add(suppliercontactlbl);
            panelForm.Controls.Add(supplliernametxt);
            panelForm.Controls.Add(supplieraddresslbl);
            panelForm.Controls.Add(supplieraddresstxt);
            panelForm.Controls.Add(suplliernamelbl);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(0, 0);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(995, 574);
            panelForm.TabIndex = 2;
            // 
            // suppliercontacttxt
            // 
            suppliercontacttxt.Anchor = AnchorStyles.None;
            suppliercontacttxt.BackColor = Color.White;
            suppliercontacttxt.Cursor = Cursors.IBeam;
            suppliercontacttxt.Font = new Font("Sitka Display", 42F, FontStyle.Regular, GraphicsUnit.Point, 0);
            suppliercontacttxt.Location = new Point(356, 173);
            suppliercontacttxt.Multiline = true;
            suppliercontacttxt.Name = "suppliercontacttxt";
            suppliercontacttxt.Size = new Size(480, 81);
            suppliercontacttxt.TabIndex = 33;
            suppliercontacttxt.WordWrap = false;
            // 
            // suppliersavebtn
            // 
            suppliersavebtn.BackColor = Color.LimeGreen;
            suppliersavebtn.FlatStyle = FlatStyle.Flat;
            suppliersavebtn.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            suppliersavebtn.ForeColor = Color.White;
            suppliersavebtn.Location = new Point(356, 392);
            suppliersavebtn.Name = "suppliersavebtn";
            suppliersavebtn.Size = new Size(480, 53);
            suppliersavebtn.TabIndex = 32;
            suppliersavebtn.Text = "SAVE";
            suppliersavebtn.UseVisualStyleBackColor = false;
            suppliersavebtn.Click += suppliersavebtn_Click;
            // 
            // suppliercontactlbl
            // 
            suppliercontactlbl.AutoSize = true;
            suppliercontactlbl.BackColor = Color.Transparent;
            suppliercontactlbl.FlatStyle = FlatStyle.Flat;
            suppliercontactlbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            suppliercontactlbl.ForeColor = Color.DimGray;
            suppliercontactlbl.Location = new Point(148, 197);
            suppliercontactlbl.Name = "suppliercontactlbl";
            suppliercontactlbl.Size = new Size(191, 54);
            suppliercontactlbl.TabIndex = 31;
            suppliercontactlbl.Text = "Contact :";
            // 
            // supplliernametxt
            // 
            supplliernametxt.Anchor = AnchorStyles.None;
            supplliernametxt.BackColor = Color.White;
            supplliernametxt.Cursor = Cursors.IBeam;
            supplliernametxt.Font = new Font("Sitka Display", 42F, FontStyle.Regular, GraphicsUnit.Point, 0);
            supplliernametxt.Location = new Point(356, 55);
            supplliernametxt.Multiline = true;
            supplliernametxt.Name = "supplliernametxt";
            supplliernametxt.Size = new Size(480, 81);
            supplliernametxt.TabIndex = 27;
            supplliernametxt.WordWrap = false;
            // 
            // supplieraddresslbl
            // 
            supplieraddresslbl.AutoSize = true;
            supplieraddresslbl.BackColor = Color.Transparent;
            supplieraddresslbl.FlatStyle = FlatStyle.Flat;
            supplieraddresslbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            supplieraddresslbl.ForeColor = Color.DimGray;
            supplieraddresslbl.Location = new Point(142, 323);
            supplieraddresslbl.Name = "supplieraddresslbl";
            supplieraddresslbl.Size = new Size(197, 54);
            supplieraddresslbl.TabIndex = 26;
            supplieraddresslbl.Text = "Address :";
            // 
            // supplieraddresstxt
            // 
            supplieraddresstxt.Anchor = AnchorStyles.None;
            supplieraddresstxt.BackColor = Color.White;
            supplieraddresstxt.Cursor = Cursors.IBeam;
            supplieraddresstxt.Font = new Font("Sitka Display", 42F, FontStyle.Regular, GraphicsUnit.Point, 0);
            supplieraddresstxt.Location = new Point(356, 285);
            supplieraddresstxt.Multiline = true;
            supplieraddresstxt.Name = "supplieraddresstxt";
            supplieraddresstxt.Size = new Size(480, 81);
            supplieraddresstxt.TabIndex = 21;
            supplieraddresstxt.WordWrap = false;
            // 
            // suplliernamelbl
            // 
            suplliernamelbl.AutoSize = true;
            suplliernamelbl.BackColor = Color.Transparent;
            suplliernamelbl.FlatStyle = FlatStyle.Flat;
            suplliernamelbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            suplliernamelbl.ForeColor = Color.DimGray;
            suplliernamelbl.Location = new Point(182, 67);
            suplliernamelbl.Name = "suplliernamelbl";
            suplliernamelbl.Size = new Size(169, 54);
            suplliernamelbl.TabIndex = 20;
            suplliernamelbl.Text = "Name : ";
            // 
            // panelFormHeader
            // 
            panelFormHeader.BackColor = Color.Coral;
            panelFormHeader.Controls.Add(addmenuitemtxt);
            panelFormHeader.Location = new Point(15, 15);
            panelFormHeader.Name = "panelFormHeader";
            panelFormHeader.Size = new Size(1180, 63);
            panelFormHeader.TabIndex = 3;
            // 
            // addmenuitemtxt
            // 
            addmenuitemtxt.AutoSize = true;
            addmenuitemtxt.BackColor = Color.Transparent;
            addmenuitemtxt.FlatStyle = FlatStyle.Flat;
            addmenuitemtxt.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            addmenuitemtxt.ForeColor = Color.White;
            addmenuitemtxt.Location = new Point(15, 15);
            addmenuitemtxt.Name = "addmenuitemtxt";
            addmenuitemtxt.Size = new Size(233, 37);
            addmenuitemtxt.TabIndex = 19;
            addmenuitemtxt.Text = "Input Menu Item";
            // 
            // SupplierAddForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(995, 574);
            Controls.Add(panelForm);
            Controls.Add(panelFormHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SupplierAddForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SupplierAddForm";
            Load += SupplierAddForm_Load;
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            panelFormHeader.ResumeLayout(false);
            panelFormHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelForm;
        private TextBox suppliercontacttxt;
        private Button suppliersavebtn;
        private Label suppliercontactlbl;
        private TextBox supplliernametxt;
        private Label supplieraddresslbl;
        private TextBox supplieraddresstxt;
        private Label suplliernamelbl;
        private Panel panelFormHeader;
        private Label addmenuitemtxt;
    }
}