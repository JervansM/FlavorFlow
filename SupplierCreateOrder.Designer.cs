namespace FlavorFlowIT13
{
    partial class SupplierCreateOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierCreateOrder));
            supplierselectlbl = new Label();
            supplierquantitytxt = new TextBox();
            supplierquantitylbl = new Label();
            itemselectlbl = new Label();
            supplierselecttxt = new ComboBox();
            supplierbillamountlbl = new Label();
            supplierorderbtn = new Button();
            panelForm = new Panel();
            suppliercostlbl = new Label();
            suppliercosttxt = new TextBox();
            closebtn = new Button();
            supplierbillamounttxt = new TextBox();
            itemselecttxt = new ComboBox();
            panelForm.SuspendLayout();
            SuspendLayout();
            // 
            // supplierselectlbl
            // 
            supplierselectlbl.AutoSize = true;
            supplierselectlbl.BackColor = Color.Transparent;
            supplierselectlbl.FlatStyle = FlatStyle.Flat;
            supplierselectlbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            supplierselectlbl.ForeColor = Color.DimGray;
            supplierselectlbl.Location = new Point(168, 77);
            supplierselectlbl.Name = "supplierselectlbl";
            supplierselectlbl.Size = new Size(212, 54);
            supplierselectlbl.TabIndex = 20;
            supplierselectlbl.Text = "Supplier : ";
            // 
            // supplierquantitytxt
            // 
            supplierquantitytxt.Anchor = AnchorStyles.None;
            supplierquantitytxt.BackColor = Color.White;
            supplierquantitytxt.Cursor = Cursors.IBeam;
            supplierquantitytxt.Font = new Font("Segoe UI", 42F);
            supplierquantitytxt.Location = new Point(418, 410);
            supplierquantitytxt.Multiline = true;
            supplierquantitytxt.Name = "supplierquantitytxt";
            supplierquantitytxt.Size = new Size(480, 81);
            supplierquantitytxt.TabIndex = 21;
            supplierquantitytxt.WordWrap = false;
            supplierquantitytxt.TextChanged += supplierquantitytxt_TextChanged;
            // 
            // supplierquantitylbl
            // 
            supplierquantitylbl.AutoSize = true;
            supplierquantitylbl.BackColor = Color.Transparent;
            supplierquantitylbl.FlatStyle = FlatStyle.Flat;
            supplierquantitylbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            supplierquantitylbl.ForeColor = Color.DimGray;
            supplierquantitylbl.Location = new Point(159, 434);
            supplierquantitylbl.Name = "supplierquantitylbl";
            supplierquantitylbl.Size = new Size(221, 54);
            supplierquantitylbl.TabIndex = 22;
            supplierquantitylbl.Text = "Quantity : ";
            // 
            // itemselectlbl
            // 
            itemselectlbl.AutoSize = true;
            itemselectlbl.BackColor = Color.Transparent;
            itemselectlbl.FlatStyle = FlatStyle.Flat;
            itemselectlbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            itemselectlbl.ForeColor = Color.DimGray;
            itemselectlbl.Location = new Point(113, 187);
            itemselectlbl.Name = "itemselectlbl";
            itemselectlbl.Size = new Size(256, 54);
            itemselectlbl.TabIndex = 26;
            itemselectlbl.Text = "Select Item :";
            // 
            // supplierselecttxt
            // 
            supplierselecttxt.Font = new Font("Segoe UI Light", 35.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            supplierselecttxt.FormattingEnabled = true;
            supplierselecttxt.Location = new Point(418, 61);
            supplierselecttxt.Name = "supplierselecttxt";
            supplierselecttxt.Size = new Size(480, 70);
            supplierselecttxt.TabIndex = 30;
            supplierselecttxt.SelectedIndexChanged += supplierselecttxt_SelectedIndexChanged;
            // 
            // supplierbillamountlbl
            // 
            supplierbillamountlbl.AutoSize = true;
            supplierbillamountlbl.BackColor = Color.Transparent;
            supplierbillamountlbl.FlatStyle = FlatStyle.Flat;
            supplierbillamountlbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            supplierbillamountlbl.ForeColor = Color.DimGray;
            supplierbillamountlbl.Location = new Point(68, 557);
            supplierbillamountlbl.Name = "supplierbillamountlbl";
            supplierbillamountlbl.Size = new Size(301, 54);
            supplierbillamountlbl.TabIndex = 31;
            supplierbillamountlbl.Text = "Total Amount :";
            // 
            // supplierorderbtn
            // 
            supplierorderbtn.BackColor = Color.LimeGreen;
            supplierorderbtn.Cursor = Cursors.Hand;
            supplierorderbtn.FlatStyle = FlatStyle.Flat;
            supplierorderbtn.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            supplierorderbtn.ForeColor = Color.White;
            supplierorderbtn.Location = new Point(418, 627);
            supplierorderbtn.Name = "supplierorderbtn";
            supplierorderbtn.Size = new Size(480, 57);
            supplierorderbtn.TabIndex = 32;
            supplierorderbtn.Text = "ORDER NOW";
            supplierorderbtn.UseVisualStyleBackColor = false;
            supplierorderbtn.Click += supplierorderbtn_Click;
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.BackgroundImageLayout = ImageLayout.Zoom;
            panelForm.Controls.Add(suppliercostlbl);
            panelForm.Controls.Add(suppliercosttxt);
            panelForm.Controls.Add(closebtn);
            panelForm.Controls.Add(supplierbillamounttxt);
            panelForm.Controls.Add(itemselecttxt);
            panelForm.Controls.Add(supplierorderbtn);
            panelForm.Controls.Add(supplierbillamountlbl);
            panelForm.Controls.Add(supplierselecttxt);
            panelForm.Controls.Add(itemselectlbl);
            panelForm.Controls.Add(supplierquantitylbl);
            panelForm.Controls.Add(supplierquantitytxt);
            panelForm.Controls.Add(supplierselectlbl);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(0, 0);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(1093, 817);
            panelForm.TabIndex = 1;
            // 
            // suppliercostlbl
            // 
            suppliercostlbl.AutoSize = true;
            suppliercostlbl.BackColor = Color.Transparent;
            suppliercostlbl.FlatStyle = FlatStyle.Flat;
            suppliercostlbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            suppliercostlbl.ForeColor = Color.DimGray;
            suppliercostlbl.Location = new Point(241, 316);
            suppliercostlbl.Name = "suppliercostlbl";
            suppliercostlbl.Size = new Size(139, 54);
            suppliercostlbl.TabIndex = 37;
            suppliercostlbl.Text = "Cost : ";
            // 
            // suppliercosttxt
            // 
            suppliercosttxt.Anchor = AnchorStyles.None;
            suppliercosttxt.BackColor = Color.White;
            suppliercosttxt.Cursor = Cursors.IBeam;
            suppliercosttxt.Font = new Font("Segoe UI", 42F);
            suppliercosttxt.Location = new Point(418, 289);
            suppliercosttxt.Multiline = true;
            suppliercosttxt.Name = "suppliercosttxt";
            suppliercosttxt.ReadOnly = true;
            suppliercosttxt.Size = new Size(480, 81);
            suppliercosttxt.TabIndex = 36;
            suppliercosttxt.WordWrap = false;
            suppliercosttxt.TextChanged += suppliercosttxt_TextChanged;
            // 
            // closebtn
            // 
            closebtn.BackColor = Color.Silver;
            closebtn.Cursor = Cursors.Hand;
            closebtn.FlatStyle = FlatStyle.Flat;
            closebtn.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            closebtn.ForeColor = Color.White;
            closebtn.Location = new Point(418, 699);
            closebtn.Name = "closebtn";
            closebtn.Size = new Size(480, 57);
            closebtn.TabIndex = 35;
            closebtn.Text = "CLOSE";
            closebtn.UseVisualStyleBackColor = false;
            closebtn.Click += closebtn_Click;
            // 
            // supplierbillamounttxt
            // 
            supplierbillamounttxt.Anchor = AnchorStyles.None;
            supplierbillamounttxt.BackColor = Color.White;
            supplierbillamounttxt.Cursor = Cursors.IBeam;
            supplierbillamounttxt.Font = new Font("Segoe UI", 42F);
            supplierbillamounttxt.Location = new Point(418, 530);
            supplierbillamounttxt.Multiline = true;
            supplierbillamounttxt.Name = "supplierbillamounttxt";
            supplierbillamounttxt.ReadOnly = true;
            supplierbillamounttxt.Size = new Size(480, 81);
            supplierbillamounttxt.TabIndex = 34;
            supplierbillamounttxt.WordWrap = false;
            supplierbillamounttxt.TextChanged += supplierbillamounttxt_TextChanged;
            // 
            // itemselecttxt
            // 
            itemselecttxt.Font = new Font("Segoe UI Light", 35.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            itemselecttxt.FormattingEnabled = true;
            itemselecttxt.Location = new Point(418, 171);
            itemselecttxt.Name = "itemselecttxt";
            itemselecttxt.Size = new Size(480, 70);
            itemselecttxt.TabIndex = 33;
            itemselecttxt.SelectedIndexChanged += itemselecttxt_SelectedIndexChanged;
            // 
            // SupplierCreateOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1093, 817);
            Controls.Add(panelForm);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "SupplierCreateOrder";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SupplierCreateOrder";
            Load += SupplierCreateOrder_Load;
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label supplierselectlbl;
        private TextBox supplierquantitytxt;
        private Label supplierquantitylbl;
        private Label itemselectlbl;
        private ComboBox supplierselecttxt;
        private Label supplierbillamountlbl;
        private Button supplierorderbtn;
        private Panel panelForm;
        private ComboBox itemselecttxt;
        private TextBox supplierbillamounttxt;
        private Button closebtn;
        private Label suppliercostlbl;
        private TextBox suppliercosttxt;
    }
}