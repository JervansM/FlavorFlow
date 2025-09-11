namespace FlavorFlowIT13
{
    partial class Expenses
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
            button1 = new Button();
            systempanelcontents = new Panel();
            netprofitbtn = new Button();
            systempanelheadercoral = new Panel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            expensesreportbtn = new Button();
            salesreportsbtn = new Button();
            systemsearchbaricon = new PictureBox();
            systemsearchbar = new TextBox();
            generatereportbtn = new Button();
            panel1.SuspendLayout();
            systempanelheadercoral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)systemsearchbaricon).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(systempanelcontents);
            panel1.Controls.Add(netprofitbtn);
            panel1.Controls.Add(systempanelheadercoral);
            panel1.Controls.Add(expensesreportbtn);
            panel1.Controls.Add(salesreportsbtn);
            panel1.Controls.Add(systemsearchbaricon);
            panel1.Controls.Add(systemsearchbar);
            panel1.Controls.Add(generatereportbtn);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1538, 1021);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(296, 907);
            button1.Name = "button1";
            button1.Size = new Size(309, 58);
            button1.TabIndex = 46;
            button1.Text = "Add Expense";
            button1.UseVisualStyleBackColor = false;
            // 
            // systempanelcontents
            // 
            systempanelcontents.BackColor = Color.White;
            systempanelcontents.Location = new Point(46, 325);
            systempanelcontents.Name = "systempanelcontents";
            systempanelcontents.Size = new Size(1447, 547);
            systempanelcontents.TabIndex = 45;
            systempanelcontents.Paint += systempanelcontents_Paint;
            // 
            // netprofitbtn
            // 
            netprofitbtn.BackColor = Color.Black;
            netprofitbtn.BackgroundImageLayout = ImageLayout.None;
            netprofitbtn.Cursor = Cursors.Hand;
            netprofitbtn.FlatStyle = FlatStyle.Flat;
            netprofitbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            netprofitbtn.ForeColor = Color.White;
            netprofitbtn.Location = new Point(754, 146);
            netprofitbtn.Name = "netprofitbtn";
            netprofitbtn.Size = new Size(309, 58);
            netprofitbtn.TabIndex = 44;
            netprofitbtn.Text = "Net Profit Summary";
            netprofitbtn.UseVisualStyleBackColor = false;
            netprofitbtn.Click += netprofitbtn_Click;
            // 
            // systempanelheadercoral
            // 
            systempanelheadercoral.BackColor = Color.Coral;
            systempanelheadercoral.Controls.Add(label4);
            systempanelheadercoral.Controls.Add(label3);
            systempanelheadercoral.Controls.Add(label2);
            systempanelheadercoral.Controls.Add(label1);
            systempanelheadercoral.Location = new Point(46, 246);
            systempanelheadercoral.Name = "systempanelheadercoral";
            systempanelheadercoral.Size = new Size(1447, 82);
            systempanelheadercoral.TabIndex = 38;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label4.Location = new Point(420, 28);
            label4.Name = "label4";
            label4.Size = new Size(168, 32);
            label4.TabIndex = 3;
            label4.Text = "Expense Type";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label3.Location = new Point(1212, 28);
            label3.Name = "label3";
            label3.Size = new Size(107, 32);
            label3.TabIndex = 2;
            label3.Text = "Amount";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label2.Location = new Point(825, 28);
            label2.Name = "label2";
            label2.Size = new Size(146, 32);
            label2.TabIndex = 1;
            label2.Text = "Description";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(82, 28);
            label1.Name = "label1";
            label1.Size = new Size(67, 32);
            label1.TabIndex = 0;
            label1.Text = "Date";
            // 
            // expensesreportbtn
            // 
            expensesreportbtn.BackColor = Color.Black;
            expensesreportbtn.BackgroundImageLayout = ImageLayout.None;
            expensesreportbtn.Cursor = Cursors.Hand;
            expensesreportbtn.FlatStyle = FlatStyle.Flat;
            expensesreportbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            expensesreportbtn.ForeColor = Color.White;
            expensesreportbtn.Location = new Point(400, 146);
            expensesreportbtn.Name = "expensesreportbtn";
            expensesreportbtn.Size = new Size(309, 58);
            expensesreportbtn.TabIndex = 43;
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
            salesreportsbtn.Location = new Point(46, 146);
            salesreportsbtn.Name = "salesreportsbtn";
            salesreportsbtn.Size = new Size(309, 58);
            salesreportsbtn.TabIndex = 42;
            salesreportsbtn.Text = "Sales Reports";
            salesreportsbtn.UseVisualStyleBackColor = false;
            // 
            // systemsearchbaricon
            // 
            systemsearchbaricon.BackColor = Color.Transparent;
            systemsearchbaricon.BackgroundImageLayout = ImageLayout.None;
            systemsearchbaricon.Image = Properties.Resources.searchbar_removebg_preview;
            systemsearchbaricon.Location = new Point(927, 55);
            systemsearchbaricon.Name = "systemsearchbaricon";
            systemsearchbaricon.Size = new Size(136, 46);
            systemsearchbaricon.SizeMode = PictureBoxSizeMode.Zoom;
            systemsearchbaricon.TabIndex = 41;
            systemsearchbaricon.TabStop = false;
            // 
            // systemsearchbar
            // 
            systemsearchbar.Anchor = AnchorStyles.None;
            systemsearchbar.BorderStyle = BorderStyle.None;
            systemsearchbar.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            systemsearchbar.ForeColor = Color.Black;
            systemsearchbar.Location = new Point(47, 55);
            systemsearchbar.Multiline = true;
            systemsearchbar.Name = "systemsearchbar";
            systemsearchbar.PlaceholderText = "Search";
            systemsearchbar.Size = new Size(1016, 47);
            systemsearchbar.TabIndex = 39;
            // 
            // generatereportbtn
            // 
            generatereportbtn.BackColor = Color.Black;
            generatereportbtn.BackgroundImageLayout = ImageLayout.None;
            generatereportbtn.Cursor = Cursors.Hand;
            generatereportbtn.FlatStyle = FlatStyle.Flat;
            generatereportbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            generatereportbtn.ForeColor = Color.White;
            generatereportbtn.Location = new Point(839, 907);
            generatereportbtn.Name = "generatereportbtn";
            generatereportbtn.Size = new Size(309, 58);
            generatereportbtn.TabIndex = 40;
            generatereportbtn.Text = "Export";
            generatereportbtn.UseVisualStyleBackColor = false;
            // 
            // Expenses
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(panel1);
            Name = "Expenses";
            Text = "Expenses";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            systempanelheadercoral.ResumeLayout(false);
            systempanelheadercoral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)systemsearchbaricon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button netprofitbtn;
        private Panel systempanelheadercoral;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button expensesreportbtn;
        private Button salesreportsbtn;
        private PictureBox systemsearchbaricon;
        private TextBox systemsearchbar;
        private Button generatereportbtn;
        private Panel systempanelcontents;
        private Button button1;
    }
}