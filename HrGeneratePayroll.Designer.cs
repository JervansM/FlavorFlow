namespace FlavorFlowIT13
{
    partial class HrGeneratePayroll
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
            salarytxt = new TextBox();
            salarylbl = new Label();
            createpayrollbtn = new Button();
            overtimetxt = new TextBox();
            overtimelbl = new Label();
            deductionstxt = new TextBox();
            dedeuctionslbl = new Label();
            nettxt = new TextBox();
            netlbl = new Label();
            ratetxt = new TextBox();
            ratelbl = new Label();
            daystxt = new TextBox();
            dayslbl = new Label();
            positiontxt = new ComboBox();
            positionlbl = new Label();
            payrollperiodidtxt = new TextBox();
            payrollperiodidlbl = new Label();
            employeenametxt = new ComboBox();
            employeenamelbl = new Label();
            datageneratepayroll = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)datageneratepayroll).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(salarytxt);
            panel1.Controls.Add(salarylbl);
            panel1.Controls.Add(createpayrollbtn);
            panel1.Controls.Add(overtimetxt);
            panel1.Controls.Add(overtimelbl);
            panel1.Controls.Add(deductionstxt);
            panel1.Controls.Add(dedeuctionslbl);
            panel1.Controls.Add(nettxt);
            panel1.Controls.Add(netlbl);
            panel1.Controls.Add(ratetxt);
            panel1.Controls.Add(ratelbl);
            panel1.Controls.Add(daystxt);
            panel1.Controls.Add(dayslbl);
            panel1.Controls.Add(positiontxt);
            panel1.Controls.Add(positionlbl);
            panel1.Controls.Add(payrollperiodidtxt);
            panel1.Controls.Add(payrollperiodidlbl);
            panel1.Controls.Add(employeenametxt);
            panel1.Controls.Add(employeenamelbl);
            panel1.Controls.Add(datageneratepayroll);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1587, 1500);
            panel1.TabIndex = 52;
            // 
            // salarytxt
            // 
            salarytxt.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            salarytxt.Location = new Point(949, 75);
            salarytxt.Name = "salarytxt";
            salarytxt.Size = new Size(190, 39);
            salarytxt.TabIndex = 46;
            salarytxt.TextChanged += salarytxt_TextChanged;
            // 
            // salarylbl
            // 
            salarylbl.AutoSize = true;
            salarylbl.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            salarylbl.ForeColor = Color.Black;
            salarylbl.Location = new Point(852, 84);
            salarylbl.Name = "salarylbl";
            salarylbl.Size = new Size(91, 30);
            salarylbl.TabIndex = 45;
            salarylbl.Text = "Salary : ";
            // 
            // createpayrollbtn
            // 
            createpayrollbtn.BackColor = Color.Black;
            createpayrollbtn.BackgroundImageLayout = ImageLayout.None;
            createpayrollbtn.Cursor = Cursors.Hand;
            createpayrollbtn.FlatStyle = FlatStyle.Flat;
            createpayrollbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createpayrollbtn.ForeColor = Color.White;
            createpayrollbtn.Location = new Point(1242, 139);
            createpayrollbtn.Name = "createpayrollbtn";
            createpayrollbtn.Size = new Size(219, 47);
            createpayrollbtn.TabIndex = 44;
            createpayrollbtn.Text = "Create Payroll";
            createpayrollbtn.UseVisualStyleBackColor = false;
            createpayrollbtn.Click += createpayrollbtn_Click;
            // 
            // overtimetxt
            // 
            overtimetxt.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            overtimetxt.Location = new Point(949, 12);
            overtimetxt.Name = "overtimetxt";
            overtimetxt.Size = new Size(190, 39);
            overtimetxt.TabIndex = 16;
            overtimetxt.TextChanged += overtimetxt_TextChanged;
            // 
            // overtimelbl
            // 
            overtimelbl.AutoSize = true;
            overtimelbl.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            overtimelbl.ForeColor = Color.Black;
            overtimelbl.Location = new Point(821, 17);
            overtimelbl.Name = "overtimelbl";
            overtimelbl.Size = new Size(122, 30);
            overtimelbl.TabIndex = 15;
            overtimelbl.Text = "Overtime : ";
            // 
            // deductionstxt
            // 
            deductionstxt.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            deductionstxt.Location = new Point(600, 129);
            deductionstxt.Name = "deductionstxt";
            deductionstxt.Size = new Size(190, 39);
            deductionstxt.TabIndex = 14;
            deductionstxt.TextChanged += deductionstxt_TextChanged;
            // 
            // dedeuctionslbl
            // 
            dedeuctionslbl.AutoSize = true;
            dedeuctionslbl.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dedeuctionslbl.ForeColor = Color.Black;
            dedeuctionslbl.Location = new Point(452, 138);
            dedeuctionslbl.Name = "dedeuctionslbl";
            dedeuctionslbl.Size = new Size(142, 30);
            dedeuctionslbl.TabIndex = 13;
            dedeuctionslbl.Text = "Deductions : ";
            // 
            // nettxt
            // 
            nettxt.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nettxt.Location = new Point(949, 139);
            nettxt.Name = "nettxt";
            nettxt.Size = new Size(190, 39);
            nettxt.TabIndex = 12;
            nettxt.TextChanged += nettxt_TextChanged;
            // 
            // netlbl
            // 
            netlbl.AutoSize = true;
            netlbl.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            netlbl.ForeColor = Color.Black;
            netlbl.Location = new Point(876, 144);
            netlbl.Name = "netlbl";
            netlbl.Size = new Size(67, 30);
            netlbl.TabIndex = 11;
            netlbl.Text = "Net : ";
            netlbl.Click += netlbl_Click;
            // 
            // ratetxt
            // 
            ratetxt.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ratetxt.Location = new Point(600, 70);
            ratetxt.Name = "ratetxt";
            ratetxt.ReadOnly = true;
            ratetxt.Size = new Size(190, 39);
            ratetxt.TabIndex = 10;
            ratetxt.TextChanged += ratetxt_TextChanged;
            // 
            // ratelbl
            // 
            ratelbl.AutoSize = true;
            ratelbl.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ratelbl.ForeColor = Color.Black;
            ratelbl.Location = new Point(519, 75);
            ratelbl.Name = "ratelbl";
            ratelbl.Size = new Size(75, 30);
            ratelbl.TabIndex = 9;
            ratelbl.Text = "Rate : ";
            // 
            // daystxt
            // 
            daystxt.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            daystxt.Location = new Point(600, 12);
            daystxt.Name = "daystxt";
            daystxt.Size = new Size(190, 39);
            daystxt.TabIndex = 8;
            daystxt.TextChanged += daystxt_TextChanged;
            // 
            // dayslbl
            // 
            dayslbl.AutoSize = true;
            dayslbl.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dayslbl.ForeColor = Color.Black;
            dayslbl.Location = new Point(517, 21);
            dayslbl.Name = "dayslbl";
            dayslbl.Size = new Size(77, 30);
            dayslbl.TabIndex = 7;
            dayslbl.Text = "Days : ";
            // 
            // positiontxt
            // 
            positiontxt.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            positiontxt.FormattingEnabled = true;
            positiontxt.Location = new Point(205, 129);
            positiontxt.Name = "positiontxt";
            positiontxt.Size = new Size(190, 40);
            positiontxt.TabIndex = 6;
            positiontxt.SelectedIndexChanged += positiontxt_SelectedIndexChanged;
            // 
            // positionlbl
            // 
            positionlbl.AutoSize = true;
            positionlbl.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            positionlbl.ForeColor = Color.Black;
            positionlbl.Location = new Point(96, 139);
            positionlbl.Name = "positionlbl";
            positionlbl.Size = new Size(111, 30);
            positionlbl.TabIndex = 5;
            positionlbl.Text = "Position : ";
            // 
            // payrollperiodidtxt
            // 
            payrollperiodidtxt.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            payrollperiodidtxt.Location = new Point(205, 12);
            payrollperiodidtxt.Name = "payrollperiodidtxt";
            payrollperiodidtxt.Size = new Size(190, 39);
            payrollperiodidtxt.TabIndex = 4;
            payrollperiodidtxt.TextChanged += payrollperiodidtxt_TextChanged;
            // 
            // payrollperiodidlbl
            // 
            payrollperiodidlbl.AutoSize = true;
            payrollperiodidlbl.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            payrollperiodidlbl.ForeColor = Color.Black;
            payrollperiodidlbl.Location = new Point(12, 17);
            payrollperiodidlbl.Name = "payrollperiodidlbl";
            payrollperiodidlbl.Size = new Size(195, 30);
            payrollperiodidlbl.TabIndex = 3;
            payrollperiodidlbl.Text = "Payroll Period ID : ";
            // 
            // employeenametxt
            // 
            employeenametxt.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            employeenametxt.FormattingEnabled = true;
            employeenametxt.Location = new Point(205, 70);
            employeenametxt.Name = "employeenametxt";
            employeenametxt.Size = new Size(190, 40);
            employeenametxt.TabIndex = 2;
            employeenametxt.SelectedIndexChanged += employeenametxt_SelectedIndexChanged;
            // 
            // employeenamelbl
            // 
            employeenamelbl.AutoSize = true;
            employeenamelbl.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            employeenamelbl.ForeColor = Color.Black;
            employeenamelbl.Location = new Point(17, 80);
            employeenamelbl.Name = "employeenamelbl";
            employeenamelbl.Size = new Size(190, 30);
            employeenamelbl.TabIndex = 1;
            employeenamelbl.Text = "Employee Name : ";
            // 
            // datageneratepayroll
            // 
            datageneratepayroll.AllowUserToAddRows = false;
            datageneratepayroll.AllowUserToDeleteRows = false;
            datageneratepayroll.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datageneratepayroll.Location = new Point(0, 205);
            datageneratepayroll.Margin = new Padding(3, 2, 3, 2);
            datageneratepayroll.Name = "datageneratepayroll";
            datageneratepayroll.ReadOnly = true;
            datageneratepayroll.RowHeadersWidth = 51;
            datageneratepayroll.Size = new Size(1587, 1022);
            datageneratepayroll.TabIndex = 0;
            datageneratepayroll.CellContentClick += datageneratepayroll_CellContentClick;
            // 
            // HrGeneratePayroll
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(1915, 1061);
            Controls.Add(panel1);
            Name = "HrGeneratePayroll";
            Text = "HrGeneratePayroll";
            Load += HrGeneratePayroll_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)datageneratepayroll).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private DataGridView datageneratepayroll;
        private Label employeenamelbl;
        private ComboBox employeenametxt;
        private Label payrollperiodidlbl;
        private TextBox payrollperiodidtxt;
        private ComboBox positiontxt;
        private Label positionlbl;
        private TextBox ratetxt;
        private Label ratelbl;
        private TextBox daystxt;
        private Label dayslbl;
        private TextBox nettxt;
        private Label netlbl;
        private TextBox deductionstxt;
        private Label dedeuctionslbl;
        private TextBox overtimetxt;
        private Label overtimelbl;
        private Button createpayrollbtn;
        private TextBox salarytxt;
        private Label salarylbl;
    }
}