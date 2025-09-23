namespace FlavorFlowIT13
{
    partial class StaffDashboardDiscountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffDashboardDiscountForm));
            panelForm = new Panel();
            cardStatuspic = new PictureBox();
            discountnetamounttxt = new TextBox();
            discountnetamountlbl = new Label();
            discountcardnumbertxt = new TextBox();
            discountregisterbn = new Button();
            discountsumamounttxt = new TextBox();
            discountsumamountlbl = new Label();
            discountpercentagetxt = new TextBox();
            discountpercentagelbl = new Label();
            discountpersoncounttxt = new TextBox();
            discountpersoncountlbl = new Label();
            discountclosebtn = new Button();
            discountcardnumberlbl = new Label();
            panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cardStatuspic).BeginInit();
            SuspendLayout();
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.Transparent;
            panelForm.BackgroundImageLayout = ImageLayout.Center;
            panelForm.Controls.Add(cardStatuspic);
            panelForm.Controls.Add(discountnetamounttxt);
            panelForm.Controls.Add(discountnetamountlbl);
            panelForm.Controls.Add(discountcardnumbertxt);
            panelForm.Controls.Add(discountregisterbn);
            panelForm.Controls.Add(discountsumamounttxt);
            panelForm.Controls.Add(discountsumamountlbl);
            panelForm.Controls.Add(discountpercentagetxt);
            panelForm.Controls.Add(discountpercentagelbl);
            panelForm.Controls.Add(discountpersoncounttxt);
            panelForm.Controls.Add(discountpersoncountlbl);
            panelForm.Controls.Add(discountclosebtn);
            panelForm.Controls.Add(discountcardnumberlbl);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(0, 0);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(1117, 861);
            panelForm.TabIndex = 1;
            // 
            // cardStatuspic
            // 
            cardStatuspic.BackColor = Color.White;
            cardStatuspic.Cursor = Cursors.Hand;
            cardStatuspic.Image = (Image)resources.GetObject("cardStatuspic.Image");
            cardStatuspic.Location = new Point(819, 45);
            cardStatuspic.Name = "cardStatuspic";
            cardStatuspic.Size = new Size(72, 50);
            cardStatuspic.SizeMode = PictureBoxSizeMode.Zoom;
            cardStatuspic.TabIndex = 43;
            cardStatuspic.TabStop = false;
            cardStatuspic.Click += cardStatuspic_Click;
            // 
            // discountnetamounttxt
            // 
            discountnetamounttxt.Anchor = AnchorStyles.None;
            discountnetamounttxt.BackColor = Color.White;
            discountnetamounttxt.Cursor = Cursors.IBeam;
            discountnetamounttxt.Font = new Font("Segoe UI", 42F);
            discountnetamounttxt.Location = new Point(414, 418);
            discountnetamounttxt.Multiline = true;
            discountnetamounttxt.Name = "discountnetamounttxt";
            discountnetamounttxt.Size = new Size(480, 81);
            discountnetamounttxt.TabIndex = 44;
            discountnetamounttxt.WordWrap = false;
            discountnetamounttxt.TextChanged += discountnetamounttxt_TextChanged;
            // 
            // discountnetamountlbl
            // 
            discountnetamountlbl.AutoSize = true;
            discountnetamountlbl.BackColor = Color.Transparent;
            discountnetamountlbl.FlatStyle = FlatStyle.Flat;
            discountnetamountlbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            discountnetamountlbl.ForeColor = Color.DimGray;
            discountnetamountlbl.Location = new Point(115, 445);
            discountnetamountlbl.Name = "discountnetamountlbl";
            discountnetamountlbl.Size = new Size(279, 54);
            discountnetamountlbl.TabIndex = 43;
            discountnetamountlbl.Text = "Net Amount :";
            // 
            // discountcardnumbertxt
            // 
            discountcardnumbertxt.AcceptsReturn = true;
            discountcardnumbertxt.Anchor = AnchorStyles.None;
            discountcardnumbertxt.BackColor = Color.White;
            discountcardnumbertxt.Cursor = Cursors.IBeam;
            discountcardnumbertxt.Font = new Font("Segoe UI", 42F);
            discountcardnumbertxt.Location = new Point(414, 30);
            discountcardnumbertxt.Multiline = true;
            discountcardnumbertxt.Name = "discountcardnumbertxt";
            discountcardnumbertxt.Size = new Size(480, 81);
            discountcardnumbertxt.TabIndex = 40;
            discountcardnumbertxt.WordWrap = false;
            discountcardnumbertxt.TextChanged += discountcardnumbertxt_TextChanged;
            // 
            // discountregisterbn
            // 
            discountregisterbn.BackColor = Color.Coral;
            discountregisterbn.Cursor = Cursors.Hand;
            discountregisterbn.FlatStyle = FlatStyle.Flat;
            discountregisterbn.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            discountregisterbn.ForeColor = Color.White;
            discountregisterbn.Location = new Point(414, 729);
            discountregisterbn.Name = "discountregisterbn";
            discountregisterbn.Size = new Size(480, 57);
            discountregisterbn.TabIndex = 39;
            discountregisterbn.Text = "REGISTER CARD";
            discountregisterbn.UseVisualStyleBackColor = false;
            discountregisterbn.Click += discountregisterbn_Click;
            // 
            // discountsumamounttxt
            // 
            discountsumamounttxt.Anchor = AnchorStyles.None;
            discountsumamounttxt.BackColor = Color.White;
            discountsumamounttxt.Cursor = Cursors.IBeam;
            discountsumamounttxt.Font = new Font("Segoe UI", 42F);
            discountsumamounttxt.Location = new Point(414, 545);
            discountsumamounttxt.Multiline = true;
            discountsumamounttxt.Name = "discountsumamounttxt";
            discountsumamounttxt.Size = new Size(480, 81);
            discountsumamounttxt.TabIndex = 38;
            discountsumamounttxt.WordWrap = false;
            discountsumamounttxt.TextChanged += discountsumamounttxt_TextChanged;
            // 
            // discountsumamountlbl
            // 
            discountsumamountlbl.AutoSize = true;
            discountsumamountlbl.BackColor = Color.Transparent;
            discountsumamountlbl.FlatStyle = FlatStyle.Flat;
            discountsumamountlbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            discountsumamountlbl.ForeColor = Color.DimGray;
            discountsumamountlbl.Location = new Point(22, 572);
            discountsumamountlbl.Name = "discountsumamountlbl";
            discountsumamountlbl.Size = new Size(386, 54);
            discountsumamountlbl.TabIndex = 37;
            discountsumamountlbl.Text = "Discount Amount : ";
            // 
            // discountpercentagetxt
            // 
            discountpercentagetxt.Anchor = AnchorStyles.None;
            discountpercentagetxt.BackColor = Color.White;
            discountpercentagetxt.Cursor = Cursors.IBeam;
            discountpercentagetxt.Font = new Font("Segoe UI", 42F);
            discountpercentagetxt.Location = new Point(414, 287);
            discountpercentagetxt.Multiline = true;
            discountpercentagetxt.Name = "discountpercentagetxt";
            discountpercentagetxt.Size = new Size(480, 81);
            discountpercentagetxt.TabIndex = 36;
            discountpercentagetxt.WordWrap = false;
            discountpercentagetxt.TextChanged += discountpercentagetxt_TextChanged;
            // 
            // discountpercentagelbl
            // 
            discountpercentagelbl.AutoSize = true;
            discountpercentagelbl.BackColor = Color.Transparent;
            discountpercentagelbl.FlatStyle = FlatStyle.Flat;
            discountpercentagelbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            discountpercentagelbl.ForeColor = Color.DimGray;
            discountpercentagelbl.Location = new Point(32, 311);
            discountpercentagelbl.Name = "discountpercentagelbl";
            discountpercentagelbl.Size = new Size(376, 54);
            discountpercentagelbl.TabIndex = 35;
            discountpercentagelbl.Text = "Discount Percent : ";
            // 
            // discountpersoncounttxt
            // 
            discountpersoncounttxt.Anchor = AnchorStyles.None;
            discountpersoncounttxt.BackColor = Color.White;
            discountpersoncounttxt.Cursor = Cursors.IBeam;
            discountpersoncounttxt.Font = new Font("Segoe UI", 42F);
            discountpersoncounttxt.Location = new Point(414, 158);
            discountpersoncounttxt.Multiline = true;
            discountpersoncounttxt.Name = "discountpersoncounttxt";
            discountpersoncounttxt.Size = new Size(480, 81);
            discountpersoncounttxt.TabIndex = 34;
            discountpersoncounttxt.WordWrap = false;
            discountpersoncounttxt.TextChanged += discountpersoncounttxt_TextChanged;
            // 
            // discountpersoncountlbl
            // 
            discountpersoncountlbl.AutoSize = true;
            discountpersoncountlbl.BackColor = Color.Transparent;
            discountpersoncountlbl.FlatStyle = FlatStyle.Flat;
            discountpersoncountlbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            discountpersoncountlbl.ForeColor = Color.DimGray;
            discountpersoncountlbl.Location = new Point(100, 182);
            discountpersoncountlbl.Name = "discountpersoncountlbl";
            discountpersoncountlbl.Size = new Size(308, 54);
            discountpersoncountlbl.TabIndex = 33;
            discountpersoncountlbl.Text = "Person Count : ";
            // 
            // discountclosebtn
            // 
            discountclosebtn.BackColor = Color.Silver;
            discountclosebtn.Cursor = Cursors.Hand;
            discountclosebtn.FlatStyle = FlatStyle.Flat;
            discountclosebtn.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            discountclosebtn.ForeColor = Color.White;
            discountclosebtn.Location = new Point(414, 657);
            discountclosebtn.Name = "discountclosebtn";
            discountclosebtn.Size = new Size(480, 57);
            discountclosebtn.TabIndex = 32;
            discountclosebtn.Text = "CLOSE";
            discountclosebtn.UseVisualStyleBackColor = false;
            discountclosebtn.Click += discountclosebtn_Click;
            // 
            // discountcardnumberlbl
            // 
            discountcardnumberlbl.AutoSize = true;
            discountcardnumberlbl.BackColor = Color.Transparent;
            discountcardnumberlbl.FlatStyle = FlatStyle.Flat;
            discountcardnumberlbl.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            discountcardnumberlbl.ForeColor = Color.DimGray;
            discountcardnumberlbl.Location = new Point(100, 57);
            discountcardnumberlbl.Name = "discountcardnumberlbl";
            discountcardnumberlbl.Size = new Size(311, 54);
            discountcardnumberlbl.TabIndex = 20;
            discountcardnumberlbl.Text = "Card Number : ";
            // 
            // StaffDashboardDiscountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1117, 861);
            Controls.Add(panelForm);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Location = new Point(800, 0);
            MaximizeBox = false;
            Name = "StaffDashboardDiscountForm";
            StartPosition = FormStartPosition.Manual;
            Text = "StaffDashboardDiscountForm";
            Load += StaffDashboardDiscountForm_Load;
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cardStatuspic).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelForm;
        private Button discountclosebtn;
        private Label menuformcategorylbl;
        private TextBox menuformpricetxt;
        private Label menuformpricelbl;
        private TextBox menuformdesctxt;
        private Label menuformdesclbl;
        private Label discountcardnumberlbl;
        private Label discountpersoncountlbl;
        private TextBox discountpersoncounttxt;
        private TextBox discountsumamounttxt;
        private Label discountsumamountlbl;
        private TextBox discountpercentagetxt;
        private Label discountpercentagelbl;
        private Button discountregisterbn;
        private TextBox discountcardnumbertxt;
        private TextBox discountnetamounttxt;
        private Label discountnetamountlbl;
        private PictureBox cardStatuspic;
    }
}