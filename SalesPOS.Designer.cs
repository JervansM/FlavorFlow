namespace FlavorFlowIT13
{
    partial class SalesPOS
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            salespospanelcontents = new Panel();
            salestrendchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            salespostotalsalessummarytxt = new Panel();
            dashsalestxsalespostotalsalessummarytxt2 = new Label();
            salesposaverageordervaluetxt = new Panel();
            calendardatepicker = new DateTimePicker();
            salespostotalsalespanel = new Panel();
            salespostotalnetsalestxtdata = new Label();
            salesposnetsalestxt = new Label();
            salesposdiscountappliedpanel = new Panel();
            salesposdiscountappliedtxtdata = new Label();
            salesposdiscountappliedtxt = new Label();
            salesposgrossrevenuepanel = new Panel();
            salesposgrossrevenuedata = new Label();
            salesposgrossrevenuetxt = new Label();
            averageordervaluepanel = new Panel();
            salesposaverageordervaluetxtdata = new Label();
            salesposaverageordervalue = new Label();
            salespostotalordersdatapanel = new Panel();
            salespostotalordersdata = new Label();
            label2 = new Label();
            salespostotalordersdatapaneltxt = new Label();
            salespostotalsalesdatapanel = new Panel();
            salespostotalsalesdatapaneltxtdata = new Label();
            salespostotalsalesdatapaneltxt = new Label();
            salesposreporttype = new ComboBox();
            salespospanelcontents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)salestrendchart).BeginInit();
            salespostotalsalessummarytxt.SuspendLayout();
            salesposaverageordervaluetxt.SuspendLayout();
            salespostotalsalespanel.SuspendLayout();
            salesposdiscountappliedpanel.SuspendLayout();
            salesposgrossrevenuepanel.SuspendLayout();
            averageordervaluepanel.SuspendLayout();
            salespostotalordersdatapanel.SuspendLayout();
            salespostotalsalesdatapanel.SuspendLayout();
            SuspendLayout();
            // 
            // salespospanelcontents
            // 
            salespospanelcontents.BackColor = Color.White;
            salespospanelcontents.Controls.Add(salestrendchart);
            salespospanelcontents.Location = new Point(13, 368);
            salespospanelcontents.Name = "salespospanelcontents";
            salespospanelcontents.Size = new Size(1507, 690);
            salespospanelcontents.TabIndex = 46;
            salespospanelcontents.Paint += salespospanelcontents_Paint;
            // 
            // salestrendchart
            // 
            salestrendchart.BackColor = Color.Transparent;
            salestrendchart.BackgroundImageLayout = ImageLayout.None;
            salestrendchart.BackSecondaryColor = Color.Transparent;
            salestrendchart.BorderlineColor = Color.Transparent;
            chartArea1.Name = "ChartArea1";
            salestrendchart.ChartAreas.Add(chartArea1);
            salestrendchart.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            salestrendchart.Legends.Add(legend1);
            salestrendchart.Location = new Point(0, 0);
            salestrendchart.Name = "salestrendchart";
            salestrendchart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Sales Trend";
            salestrendchart.Series.Add(series1);
            salestrendchart.Size = new Size(1507, 690);
            salestrendchart.TabIndex = 0;
            salestrendchart.Text = "Sales Trend";
            title1.Name = "Sales";
            salestrendchart.Titles.Add(title1);
            salestrendchart.Click += salestrendchart_Click;
            // 
            // salespostotalsalessummarytxt
            // 
            salespostotalsalessummarytxt.BackColor = Color.Black;
            salespostotalsalessummarytxt.Controls.Add(dashsalestxsalespostotalsalessummarytxt2);
            salespostotalsalessummarytxt.Location = new Point(13, 23);
            salespostotalsalessummarytxt.Name = "salespostotalsalessummarytxt";
            salespostotalsalessummarytxt.Size = new Size(259, 63);
            salespostotalsalessummarytxt.TabIndex = 51;
            // 
            // dashsalestxsalespostotalsalessummarytxt2
            // 
            dashsalestxsalespostotalsalessummarytxt2.AutoSize = true;
            dashsalestxsalespostotalsalessummarytxt2.BackColor = Color.Transparent;
            dashsalestxsalespostotalsalessummarytxt2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            dashsalestxsalespostotalsalessummarytxt2.ForeColor = Color.White;
            dashsalestxsalespostotalsalessummarytxt2.Location = new Point(20, 14);
            dashsalestxsalespostotalsalessummarytxt2.Name = "dashsalestxsalespostotalsalessummarytxt2";
            dashsalestxsalespostotalsalessummarytxt2.Size = new Size(227, 30);
            dashsalestxsalespostotalsalessummarytxt2.TabIndex = 0;
            dashsalestxsalespostotalsalessummarytxt2.Text = "Total Sales Summary";
            // 
            // salesposaverageordervaluetxt
            // 
            salesposaverageordervaluetxt.AutoScroll = true;
            salesposaverageordervaluetxt.BackColor = Color.Silver;
            salesposaverageordervaluetxt.Controls.Add(calendardatepicker);
            salesposaverageordervaluetxt.Controls.Add(salespostotalsalespanel);
            salesposaverageordervaluetxt.Controls.Add(salesposdiscountappliedpanel);
            salesposaverageordervaluetxt.Controls.Add(salesposgrossrevenuepanel);
            salesposaverageordervaluetxt.Controls.Add(averageordervaluepanel);
            salesposaverageordervaluetxt.Controls.Add(salespostotalordersdatapanel);
            salesposaverageordervaluetxt.Controls.Add(salespostotalsalesdatapanel);
            salesposaverageordervaluetxt.Controls.Add(salesposreporttype);
            salesposaverageordervaluetxt.Controls.Add(salespostotalsalessummarytxt);
            salesposaverageordervaluetxt.Controls.Add(salespospanelcontents);
            salesposaverageordervaluetxt.Location = new Point(0, 0);
            salesposaverageordervaluetxt.Name = "salesposaverageordervaluetxt";
            salesposaverageordervaluetxt.Size = new Size(1528, 1090);
            salesposaverageordervaluetxt.TabIndex = 2;
            salesposaverageordervaluetxt.Paint += panelContent_Paint_1;
            // 
            // calendardatepicker
            // 
            calendardatepicker.CalendarMonthBackground = Color.IndianRed;
            calendardatepicker.CalendarTrailingForeColor = SystemColors.ControlText;
            calendardatepicker.Font = new Font("Segoe UI", 19F);
            calendardatepicker.Location = new Point(366, 111);
            calendardatepicker.Name = "calendardatepicker";
            calendardatepicker.Size = new Size(418, 41);
            calendardatepicker.TabIndex = 56;
            calendardatepicker.ValueChanged += calendardatepicker_ValueChanged;
            // 
            // salespostotalsalespanel
            // 
            salespostotalsalespanel.BackColor = Color.Black;
            salespostotalsalespanel.Controls.Add(salespostotalnetsalestxtdata);
            salespostotalsalespanel.Controls.Add(salesposnetsalestxt);
            salespostotalsalespanel.Location = new Point(1276, 181);
            salespostotalsalespanel.Name = "salespostotalsalespanel";
            salespostotalsalespanel.Size = new Size(244, 158);
            salespostotalsalespanel.TabIndex = 53;
            // 
            // salespostotalnetsalestxtdata
            // 
            salespostotalnetsalestxtdata.AutoSize = true;
            salespostotalnetsalestxtdata.BackColor = Color.Transparent;
            salespostotalnetsalestxtdata.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            salespostotalnetsalestxtdata.ForeColor = Color.LimeGreen;
            salespostotalnetsalestxtdata.Location = new Point(11, 52);
            salespostotalnetsalestxtdata.Name = "salespostotalnetsalestxtdata";
            salespostotalnetsalestxtdata.Size = new Size(42, 46);
            salespostotalnetsalestxtdata.TabIndex = 1;
            salespostotalnetsalestxtdata.Text = "₱";
            salespostotalnetsalestxtdata.Click += salespostotalsalestxtdata_Click;
            // 
            // salesposnetsalestxt
            // 
            salesposnetsalestxt.AutoSize = true;
            salesposnetsalestxt.BackColor = Color.Transparent;
            salesposnetsalestxt.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            salesposnetsalestxt.ForeColor = Color.White;
            salesposnetsalestxt.Location = new Point(59, 22);
            salesposnetsalestxt.Name = "salesposnetsalestxt";
            salesposnetsalestxt.Size = new Size(122, 30);
            salesposnetsalestxt.TabIndex = 0;
            salesposnetsalestxt.Text = "Net Sales : ";
            // 
            // salesposdiscountappliedpanel
            // 
            salesposdiscountappliedpanel.BackColor = Color.Black;
            salesposdiscountappliedpanel.Controls.Add(salesposdiscountappliedtxtdata);
            salesposdiscountappliedpanel.Controls.Add(salesposdiscountappliedtxt);
            salesposdiscountappliedpanel.Location = new Point(1016, 181);
            salesposdiscountappliedpanel.Name = "salesposdiscountappliedpanel";
            salesposdiscountappliedpanel.Size = new Size(254, 158);
            salesposdiscountappliedpanel.TabIndex = 55;
            // 
            // salesposdiscountappliedtxtdata
            // 
            salesposdiscountappliedtxtdata.AutoSize = true;
            salesposdiscountappliedtxtdata.BackColor = Color.Transparent;
            salesposdiscountappliedtxtdata.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            salesposdiscountappliedtxtdata.ForeColor = Color.LimeGreen;
            salesposdiscountappliedtxtdata.Location = new Point(26, 52);
            salesposdiscountappliedtxtdata.Name = "salesposdiscountappliedtxtdata";
            salesposdiscountappliedtxtdata.Size = new Size(42, 46);
            salesposdiscountappliedtxtdata.TabIndex = 1;
            salesposdiscountappliedtxtdata.Text = "₱";
            salesposdiscountappliedtxtdata.Click += salesposdiscountappliedtxtdata_Click;
            // 
            // salesposdiscountappliedtxt
            // 
            salesposdiscountappliedtxt.AutoSize = true;
            salesposdiscountappliedtxt.BackColor = Color.Transparent;
            salesposdiscountappliedtxt.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            salesposdiscountappliedtxt.ForeColor = Color.White;
            salesposdiscountappliedtxt.Location = new Point(26, 22);
            salesposdiscountappliedtxt.Name = "salesposdiscountappliedtxt";
            salesposdiscountappliedtxt.Size = new Size(189, 30);
            salesposdiscountappliedtxt.TabIndex = 0;
            salesposdiscountappliedtxt.Text = "Discount Applied:";
            // 
            // salesposgrossrevenuepanel
            // 
            salesposgrossrevenuepanel.BackColor = Color.Black;
            salesposgrossrevenuepanel.Controls.Add(salesposgrossrevenuedata);
            salesposgrossrevenuepanel.Controls.Add(salesposgrossrevenuetxt);
            salesposgrossrevenuepanel.Location = new Point(756, 181);
            salesposgrossrevenuepanel.Name = "salesposgrossrevenuepanel";
            salesposgrossrevenuepanel.Size = new Size(254, 158);
            salesposgrossrevenuepanel.TabIndex = 54;
            salesposgrossrevenuepanel.Paint += salesposgrossrevenuepanel_Paint;
            // 
            // salesposgrossrevenuedata
            // 
            salesposgrossrevenuedata.AutoSize = true;
            salesposgrossrevenuedata.BackColor = Color.Transparent;
            salesposgrossrevenuedata.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            salesposgrossrevenuedata.ForeColor = Color.LimeGreen;
            salesposgrossrevenuedata.Location = new Point(18, 52);
            salesposgrossrevenuedata.Name = "salesposgrossrevenuedata";
            salesposgrossrevenuedata.Size = new Size(42, 46);
            salesposgrossrevenuedata.TabIndex = 1;
            salesposgrossrevenuedata.Text = "₱";
            salesposgrossrevenuedata.Click += salesposgrossrevenuedata_Click;
            // 
            // salesposgrossrevenuetxt
            // 
            salesposgrossrevenuetxt.AutoSize = true;
            salesposgrossrevenuetxt.BackColor = Color.Transparent;
            salesposgrossrevenuetxt.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            salesposgrossrevenuetxt.ForeColor = Color.White;
            salesposgrossrevenuetxt.Location = new Point(41, 22);
            salesposgrossrevenuetxt.Name = "salesposgrossrevenuetxt";
            salesposgrossrevenuetxt.Size = new Size(168, 30);
            salesposgrossrevenuetxt.TabIndex = 0;
            salesposgrossrevenuetxt.Text = "Gross Revenue :";
            // 
            // averageordervaluepanel
            // 
            averageordervaluepanel.BackColor = Color.Black;
            averageordervaluepanel.Controls.Add(salesposaverageordervaluetxtdata);
            averageordervaluepanel.Controls.Add(salesposaverageordervalue);
            averageordervaluepanel.Location = new Point(496, 181);
            averageordervaluepanel.Name = "averageordervaluepanel";
            averageordervaluepanel.Size = new Size(254, 158);
            averageordervaluepanel.TabIndex = 53;
            averageordervaluepanel.Paint += averageordervaluepanel_Paint;
            // 
            // salesposaverageordervaluetxtdata
            // 
            salesposaverageordervaluetxtdata.AutoSize = true;
            salesposaverageordervaluetxtdata.BackColor = Color.Transparent;
            salesposaverageordervaluetxtdata.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            salesposaverageordervaluetxtdata.ForeColor = Color.LimeGreen;
            salesposaverageordervaluetxtdata.Location = new Point(32, 52);
            salesposaverageordervaluetxtdata.Name = "salesposaverageordervaluetxtdata";
            salesposaverageordervaluetxtdata.Size = new Size(42, 46);
            salesposaverageordervaluetxtdata.TabIndex = 1;
            salesposaverageordervaluetxtdata.Text = "₱";
            salesposaverageordervaluetxtdata.Click += salesposaverageordervaluetxtdata_Click;
            // 
            // salesposaverageordervalue
            // 
            salesposaverageordervalue.AutoSize = true;
            salesposaverageordervalue.BackColor = Color.Transparent;
            salesposaverageordervalue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            salesposaverageordervalue.ForeColor = Color.White;
            salesposaverageordervalue.Location = new Point(3, 22);
            salesposaverageordervalue.Name = "salesposaverageordervalue";
            salesposaverageordervalue.Size = new Size(232, 30);
            salesposaverageordervalue.TabIndex = 0;
            salesposaverageordervalue.Text = "  Average Order Value:";
            salesposaverageordervalue.Click += label4_Click;
            // 
            // salespostotalordersdatapanel
            // 
            salespostotalordersdatapanel.BackColor = Color.Black;
            salespostotalordersdatapanel.Controls.Add(salespostotalordersdata);
            salespostotalordersdatapanel.Controls.Add(label2);
            salespostotalordersdatapanel.Controls.Add(salespostotalordersdatapaneltxt);
            salespostotalordersdatapanel.Location = new Point(12, 181);
            salespostotalordersdatapanel.Name = "salespostotalordersdatapanel";
            salespostotalordersdatapanel.Size = new Size(230, 158);
            salespostotalordersdatapanel.TabIndex = 53;
            salespostotalordersdatapanel.Paint += salespostotalordersdatapanel_Paint;
            // 
            // salespostotalordersdata
            // 
            salespostotalordersdata.AutoSize = true;
            salespostotalordersdata.BackColor = Color.Transparent;
            salespostotalordersdata.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            salespostotalordersdata.ForeColor = Color.SandyBrown;
            salespostotalordersdata.Location = new Point(87, 56);
            salespostotalordersdata.Name = "salespostotalordersdata";
            salespostotalordersdata.Size = new Size(40, 46);
            salespostotalordersdata.TabIndex = 2;
            salespostotalordersdata.Text = "0";
            salespostotalordersdata.Click += salespostotalordersdata_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label2.ForeColor = Color.LimeGreen;
            label2.Location = new Point(59, 62);
            label2.Name = "label2";
            label2.Size = new Size(0, 37);
            label2.TabIndex = 1;
            // 
            // salespostotalordersdatapaneltxt
            // 
            salespostotalordersdatapaneltxt.AutoSize = true;
            salespostotalordersdatapaneltxt.BackColor = Color.Transparent;
            salespostotalordersdatapaneltxt.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            salespostotalordersdatapaneltxt.ForeColor = Color.White;
            salespostotalordersdatapaneltxt.Location = new Point(41, 22);
            salespostotalordersdatapaneltxt.Name = "salespostotalordersdatapaneltxt";
            salespostotalordersdatapaneltxt.Size = new Size(144, 30);
            salespostotalordersdatapaneltxt.TabIndex = 0;
            salespostotalordersdatapaneltxt.Text = "Total Orders: ";
            salespostotalordersdatapaneltxt.Click += salespostotalordersdatapaneltxt_Click;
            // 
            // salespostotalsalesdatapanel
            // 
            salespostotalsalesdatapanel.BackColor = Color.Black;
            salespostotalsalesdatapanel.Controls.Add(salespostotalsalesdatapaneltxtdata);
            salespostotalsalesdatapanel.Controls.Add(salespostotalsalesdatapaneltxt);
            salespostotalsalesdatapanel.Location = new Point(248, 181);
            salespostotalsalesdatapanel.Name = "salespostotalsalesdatapanel";
            salespostotalsalesdatapanel.Size = new Size(242, 158);
            salespostotalsalesdatapanel.TabIndex = 52;
            salespostotalsalesdatapanel.Paint += salespostotalsalesdatapanel_Paint;
            // 
            // salespostotalsalesdatapaneltxtdata
            // 
            salespostotalsalesdatapaneltxtdata.AutoSize = true;
            salespostotalsalesdatapaneltxtdata.BackColor = Color.Transparent;
            salespostotalsalesdatapaneltxtdata.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            salespostotalsalesdatapaneltxtdata.ForeColor = Color.LimeGreen;
            salespostotalsalesdatapaneltxtdata.Location = new Point(32, 52);
            salespostotalsalesdatapaneltxtdata.Name = "salespostotalsalesdatapaneltxtdata";
            salespostotalsalesdatapaneltxtdata.Size = new Size(42, 46);
            salespostotalsalesdatapaneltxtdata.TabIndex = 1;
            salespostotalsalesdatapaneltxtdata.Text = "₱";
            salespostotalsalesdatapaneltxtdata.Click += salespostotalsalesdatapaneltxtdata_Click;
            // 
            // salespostotalsalesdatapaneltxt
            // 
            salespostotalsalesdatapaneltxt.AutoSize = true;
            salespostotalsalesdatapaneltxt.BackColor = Color.Transparent;
            salespostotalsalesdatapaneltxt.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            salespostotalsalesdatapaneltxt.ForeColor = Color.White;
            salespostotalsalesdatapaneltxt.Location = new Point(54, 22);
            salespostotalsalesdatapaneltxt.Name = "salespostotalsalesdatapaneltxt";
            salespostotalsalesdatapaneltxt.Size = new Size(134, 30);
            salespostotalsalesdatapaneltxt.TabIndex = 0;
            salespostotalsalesdatapaneltxt.Text = "Total Sales : ";
            salespostotalsalesdatapaneltxt.Click += salespostotalsalesdatapaneltxt_Click_1;
            // 
            // salesposreporttype
            // 
            salesposreporttype.BackColor = Color.Coral;
            salesposreporttype.FlatStyle = FlatStyle.Flat;
            salesposreporttype.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            salesposreporttype.ForeColor = Color.White;
            salesposreporttype.FormattingEnabled = true;
            salesposreporttype.Items.AddRange(new object[] { "Daily", "Weekly", "Monthly", "Yearly" });
            salesposreporttype.Location = new Point(13, 109);
            salesposreporttype.Name = "salesposreporttype";
            salesposreporttype.Size = new Size(309, 43);
            salesposreporttype.TabIndex = 52;
            salesposreporttype.Text = "  Report Type : ";
            salesposreporttype.SelectedIndexChanged += salesposreporttype_SelectedIndexChanged;
            // 
            // SalesPOS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1560, 1061);
            Controls.Add(salesposaverageordervaluetxt);
            Name = "SalesPOS";
            Text = "SalesPOS";
            Load += SalesPOS_Load;
            salespospanelcontents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)salestrendchart).EndInit();
            salespostotalsalessummarytxt.ResumeLayout(false);
            salespostotalsalessummarytxt.PerformLayout();
            salesposaverageordervaluetxt.ResumeLayout(false);
            salespostotalsalespanel.ResumeLayout(false);
            salespostotalsalespanel.PerformLayout();
            salesposdiscountappliedpanel.ResumeLayout(false);
            salesposdiscountappliedpanel.PerformLayout();
            salesposgrossrevenuepanel.ResumeLayout(false);
            salesposgrossrevenuepanel.PerformLayout();
            averageordervaluepanel.ResumeLayout(false);
            averageordervaluepanel.PerformLayout();
            salespostotalordersdatapanel.ResumeLayout(false);
            salespostotalordersdatapanel.PerformLayout();
            salespostotalsalesdatapanel.ResumeLayout(false);
            salespostotalsalesdatapanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel salespospanelcontents;
        private Panel salespostotalsalessummarytxt;
        private Label dashsalestxsalespostotalsalessummarytxt2;
        private Panel salesposaverageordervaluetxt;
        private ComboBox salesposreporttype;
        private Panel salespostotalsalesdatapanel;
        private Label salespostotalsalesdatapaneltxt;
        private Label salespostotalsalesdatapaneltxtdata;
        private Panel salespostotalordersdatapanel;
        private Label label2;
        private Label salespostotalordersdatapaneltxt;
        private Label salespostotalordersdata;
        private Panel averageordervaluepanel;
        private Label salesposaverageordervaluetxtdata;
        private Label salesposaverageordervalue;
        private Panel salesposgrossrevenuepanel;
        private Label salesposgrossrevenuedata;
        private Label salesposgrossrevenuetxt;
        private Panel salesposdiscountappliedpanel;
        private Label salesposdiscountappliedtxtdata;
        private Label salesposdiscountappliedtxt;
        private Panel salespostotalsalespanel;
        private Label salespostotalnetsalestxtdata;
        private Label salesposnetsalestxt;
        private DateTimePicker calendardatepicker;
        private System.Windows.Forms.DataVisualization.Charting.Chart salestrendchart;
    }
}