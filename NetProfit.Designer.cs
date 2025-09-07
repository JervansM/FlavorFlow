namespace FlavorFlowIT13
{
    partial class NetProfit
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
            panel1 = new Panel();
            netprofitbtn = new Button();
            expensesreportbtn = new Button();
            salesreportsbtn = new Button();
            systemsearchbaricon = new PictureBox();
            systemsearchbar = new TextBox();
            systempanelcontents = new Panel();
            generatereportbtn = new Button();
            systempanelheadercoral = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)systemsearchbaricon).BeginInit();
            systempanelheadercoral.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.Controls.Add(generatereportbtn);
            panel1.Controls.Add(netprofitbtn);
            panel1.Controls.Add(systempanelheadercoral);
            panel1.Controls.Add(expensesreportbtn);
            panel1.Controls.Add(salesreportsbtn);
            panel1.Controls.Add(systemsearchbaricon);
            panel1.Controls.Add(systemsearchbar);
            panel1.Controls.Add(systempanelcontents);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1538, 1021);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // netprofitbtn
            // 
            netprofitbtn.BackColor = Color.Black;
            netprofitbtn.BackgroundImageLayout = ImageLayout.None;
            netprofitbtn.Cursor = Cursors.Hand;
            netprofitbtn.FlatStyle = FlatStyle.Flat;
            netprofitbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            netprofitbtn.ForeColor = Color.White;
            netprofitbtn.Location = new Point(744, 120);
            netprofitbtn.Name = "netprofitbtn";
            netprofitbtn.Size = new Size(309, 58);
            netprofitbtn.TabIndex = 37;
            netprofitbtn.Text = "Net Profit Summary";
            netprofitbtn.UseVisualStyleBackColor = false;
            netprofitbtn.Click += systemappconfigure_Click;
            // 
            // expensesreportbtn
            // 
            expensesreportbtn.BackColor = Color.Black;
            expensesreportbtn.BackgroundImageLayout = ImageLayout.None;
            expensesreportbtn.Cursor = Cursors.Hand;
            expensesreportbtn.FlatStyle = FlatStyle.Flat;
            expensesreportbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            expensesreportbtn.ForeColor = Color.White;
            expensesreportbtn.Location = new Point(390, 120);
            expensesreportbtn.Name = "expensesreportbtn";
            expensesreportbtn.Size = new Size(309, 58);
            expensesreportbtn.TabIndex = 36;
            expensesreportbtn.Text = "Expenses Report";
            expensesreportbtn.UseVisualStyleBackColor = false;
            // 
            // salesreportsbtn
            // 
            salesreportsbtn.BackColor = Color.Black;
            salesreportsbtn.BackgroundImageLayout = ImageLayout.None;
            salesreportsbtn.Cursor = Cursors.Hand;
            salesreportsbtn.FlatStyle = FlatStyle.Flat;
            salesreportsbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            salesreportsbtn.ForeColor = Color.White;
            salesreportsbtn.Location = new Point(36, 120);
            salesreportsbtn.Name = "salesreportsbtn";
            salesreportsbtn.Size = new Size(309, 58);
            salesreportsbtn.TabIndex = 35;
            salesreportsbtn.Text = "Sales Reports";
            salesreportsbtn.UseVisualStyleBackColor = false;
            salesreportsbtn.Click += systemgeneralsettings_Click;
            // 
            // systemsearchbaricon
            // 
            systemsearchbaricon.BackColor = Color.Transparent;
            systemsearchbaricon.BackgroundImageLayout = ImageLayout.None;
            systemsearchbaricon.Image = Properties.Resources.searchbar_removebg_preview;
            systemsearchbaricon.Location = new Point(917, 29);
            systemsearchbaricon.Name = "systemsearchbaricon";
            systemsearchbaricon.Size = new Size(136, 46);
            systemsearchbaricon.SizeMode = PictureBoxSizeMode.Zoom;
            systemsearchbaricon.TabIndex = 33;
            systemsearchbaricon.TabStop = false;
            systemsearchbaricon.Click += systemsearchbaricon_Click;
            // 
            // systemsearchbar
            // 
            systemsearchbar.Anchor = AnchorStyles.None;
            systemsearchbar.BorderStyle = BorderStyle.None;
            systemsearchbar.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            systemsearchbar.ForeColor = Color.Black;
            systemsearchbar.Location = new Point(37, 29);
            systemsearchbar.Multiline = true;
            systemsearchbar.Name = "systemsearchbar";
            systemsearchbar.PlaceholderText = "Search";
            systemsearchbar.Size = new Size(1016, 47);
            systemsearchbar.TabIndex = 32;
            systemsearchbar.TextChanged += systemsearchbar_TextChanged;
            // 
            // systempanelcontents
            // 
            systempanelcontents.BackColor = Color.White;
            systempanelcontents.Location = new Point(36, 301);
            systempanelcontents.Name = "systempanelcontents";
            systempanelcontents.Size = new Size(1447, 547);
            systempanelcontents.TabIndex = 34;
            // 
            // generatereportbtn
            // 
            generatereportbtn.BackColor = Color.Black;
            generatereportbtn.BackgroundImageLayout = ImageLayout.None;
            generatereportbtn.Cursor = Cursors.Hand;
            generatereportbtn.FlatStyle = FlatStyle.Flat;
            generatereportbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            generatereportbtn.ForeColor = Color.White;
            generatereportbtn.Location = new Point(629, 881);
            generatereportbtn.Name = "generatereportbtn";
            generatereportbtn.Size = new Size(309, 58);
            generatereportbtn.TabIndex = 32;
            generatereportbtn.Text = "Generate Report";
            generatereportbtn.UseVisualStyleBackColor = false;
            generatereportbtn.Click += systemsettingssavebtn_Click;
            // 
            // systempanelheadercoral
            // 
            systempanelheadercoral.BackColor = Color.Coral;
            systempanelheadercoral.Controls.Add(label4);
            systempanelheadercoral.Controls.Add(label3);
            systempanelheadercoral.Controls.Add(label2);
            systempanelheadercoral.Controls.Add(label1);
            systempanelheadercoral.Location = new Point(36, 220);
            systempanelheadercoral.Name = "systempanelheadercoral";
            systempanelheadercoral.Size = new Size(1447, 82);
            systempanelheadercoral.TabIndex = 25;
            systempanelheadercoral.Paint += systempanelheadercoral_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(82, 28);
            label1.Name = "label1";
            label1.Size = new Size(88, 32);
            label1.TabIndex = 0;
            label1.Text = "Period";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label2.Location = new Point(825, 28);
            label2.Name = "label2";
            label2.Size = new Size(181, 32);
            label2.TabIndex = 1;
            label2.Text = "Total Expenses";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label3.Location = new Point(1212, 28);
            label3.Name = "label3";
            label3.Size = new Size(127, 32);
            label3.TabIndex = 2;
            label3.Text = "Net Profit";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label4.Location = new Point(420, 28);
            label4.Name = "label4";
            label4.Size = new Size(134, 32);
            label4.TabIndex = 3;
            label4.Text = "Total Sales";
            // 
            // NetProfit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1633, 1058);
            Controls.Add(panel1);
            Name = "NetProfit";
            Text = "NetProfit";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)systemsearchbaricon).EndInit();
            systempanelheadercoral.ResumeLayout(false);
            systempanelheadercoral.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button netprofitbtn;
        private Button expensesreportbtn;
        private Button salesreportsbtn;
        private PictureBox systemsearchbaricon;
        private TextBox systemsearchbar;
        private Panel systempanelcontents;
        private Button generatereportbtn;
        private Panel systempanelheadercoral;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}