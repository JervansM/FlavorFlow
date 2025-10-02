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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            panelContent = new Panel();
            expensesposreporttype = new ComboBox();
            calendardatepicker = new DateTimePicker();
            netprofitsummarybtn = new Button();
            expensereportsbtn = new Button();
            netsalessumbtn = new Button();
            dashnetprofit = new Panel();
            dashnetprofittxt = new Label();
            dashinventoryusage = new Panel();
            label2 = new Label();
            dashtotalexpense = new Panel();
            dashtotalexptxt = new Label();
            panel4 = new Panel();
            label7 = new Label();
            panel5 = new Panel();
            label8 = new Label();
            panel6 = new Panel();
            label9 = new Label();
            financeexpensespanel = new Panel();
            netprofitchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panelContent.SuspendLayout();
            dashnetprofit.SuspendLayout();
            dashinventoryusage.SuspendLayout();
            dashtotalexpense.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            financeexpensespanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)netprofitchart).BeginInit();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.Silver;
            panelContent.BackgroundImageLayout = ImageLayout.None;
            panelContent.Controls.Add(expensesposreporttype);
            panelContent.Controls.Add(calendardatepicker);
            panelContent.Controls.Add(netprofitsummarybtn);
            panelContent.Controls.Add(expensereportsbtn);
            panelContent.Controls.Add(netsalessumbtn);
            panelContent.Controls.Add(dashnetprofit);
            panelContent.Controls.Add(dashinventoryusage);
            panelContent.Controls.Add(dashtotalexpense);
            panelContent.Controls.Add(panel4);
            panelContent.Controls.Add(panel5);
            panelContent.Controls.Add(panel6);
            panelContent.Controls.Add(financeexpensespanel);
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1531, 997);
            panelContent.TabIndex = 19;
            // 
            // expensesposreporttype
            // 
            expensesposreporttype.BackColor = Color.Coral;
            expensesposreporttype.FlatStyle = FlatStyle.Flat;
            expensesposreporttype.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            expensesposreporttype.ForeColor = Color.White;
            expensesposreporttype.FormattingEnabled = true;
            expensesposreporttype.Items.AddRange(new object[] { "Daily", "Weekly", "Monthly", "Yearly" });
            expensesposreporttype.Location = new Point(12, 105);
            expensesposreporttype.Name = "expensesposreporttype";
            expensesposreporttype.Size = new Size(231, 43);
            expensesposreporttype.TabIndex = 57;
            expensesposreporttype.Text = "  Report Type : ";
            // 
            // calendardatepicker
            // 
            calendardatepicker.CalendarMonthBackground = Color.IndianRed;
            calendardatepicker.CalendarTrailingForeColor = SystemColors.ControlText;
            calendardatepicker.Font = new Font("Segoe UI", 19F);
            calendardatepicker.Location = new Point(265, 107);
            calendardatepicker.Name = "calendardatepicker";
            calendardatepicker.Size = new Size(380, 41);
            calendardatepicker.TabIndex = 58;
            // 
            // netprofitsummarybtn
            // 
            netprofitsummarybtn.BackColor = Color.Black;
            netprofitsummarybtn.Cursor = Cursors.Hand;
            netprofitsummarybtn.FlatStyle = FlatStyle.Popup;
            netprofitsummarybtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            netprofitsummarybtn.ForeColor = Color.Honeydew;
            netprofitsummarybtn.Location = new Point(588, 24);
            netprofitsummarybtn.Name = "netprofitsummarybtn";
            netprofitsummarybtn.Size = new Size(270, 62);
            netprofitsummarybtn.TabIndex = 59;
            netprofitsummarybtn.Text = "Net Profit Summary";
            netprofitsummarybtn.UseVisualStyleBackColor = false;
            netprofitsummarybtn.Click += netprofitsummarybtn_Click;
            // 
            // expensereportsbtn
            // 
            expensereportsbtn.BackColor = Color.Black;
            expensereportsbtn.Cursor = Cursors.Hand;
            expensereportsbtn.FlatStyle = FlatStyle.Popup;
            expensereportsbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            expensereportsbtn.ForeColor = Color.Honeydew;
            expensereportsbtn.Location = new Point(301, 24);
            expensereportsbtn.Name = "expensereportsbtn";
            expensereportsbtn.Size = new Size(270, 62);
            expensereportsbtn.TabIndex = 58;
            expensereportsbtn.Text = "Expense Reports";
            expensereportsbtn.UseVisualStyleBackColor = false;
            expensereportsbtn.Click += expensereportsbtn_Click;
            // 
            // netsalessumbtn
            // 
            netsalessumbtn.BackColor = Color.Black;
            netsalessumbtn.Cursor = Cursors.Hand;
            netsalessumbtn.FlatStyle = FlatStyle.Popup;
            netsalessumbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            netsalessumbtn.ForeColor = Color.Honeydew;
            netsalessumbtn.Location = new Point(12, 24);
            netsalessumbtn.Name = "netsalessumbtn";
            netsalessumbtn.Size = new Size(270, 62);
            netsalessumbtn.TabIndex = 57;
            netsalessumbtn.Text = "Net Sales";
            netsalessumbtn.UseVisualStyleBackColor = false;
            netsalessumbtn.Click += netsalessumbtn_Click;
            // 
            // dashnetprofit
            // 
            dashnetprofit.Anchor = AnchorStyles.Bottom;
            dashnetprofit.BackColor = Color.Black;
            dashnetprofit.Controls.Add(dashnetprofittxt);
            dashnetprofit.Location = new Point(3043, 3873);
            dashnetprofit.Name = "dashnetprofit";
            dashnetprofit.Size = new Size(468, 169);
            dashnetprofit.TabIndex = 20;
            // 
            // dashnetprofittxt
            // 
            dashnetprofittxt.AutoSize = true;
            dashnetprofittxt.BackColor = Color.Transparent;
            dashnetprofittxt.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dashnetprofittxt.ForeColor = Color.White;
            dashnetprofittxt.Location = new Point(28, 0);
            dashnetprofittxt.Name = "dashnetprofittxt";
            dashnetprofittxt.Size = new Size(321, 45);
            dashnetprofittxt.TabIndex = 5;
            dashnetprofittxt.Text = "Net Profit Summary";
            // 
            // dashinventoryusage
            // 
            dashinventoryusage.Anchor = AnchorStyles.None;
            dashinventoryusage.BackColor = Color.Black;
            dashinventoryusage.Controls.Add(label2);
            dashinventoryusage.Location = new Point(3043, 2012);
            dashinventoryusage.Name = "dashinventoryusage";
            dashinventoryusage.Size = new Size(468, 226);
            dashinventoryusage.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(28, 0);
            label2.Name = "label2";
            label2.Size = new Size(265, 45);
            label2.TabIndex = 4;
            label2.Text = "Inventory Usage";
            // 
            // dashtotalexpense
            // 
            dashtotalexpense.Anchor = AnchorStyles.Top;
            dashtotalexpense.BackColor = Color.Black;
            dashtotalexpense.Controls.Add(dashtotalexptxt);
            dashtotalexpense.Location = new Point(3043, 206);
            dashtotalexpense.Name = "dashtotalexpense";
            dashtotalexpense.Size = new Size(468, 170);
            dashtotalexpense.TabIndex = 19;
            // 
            // dashtotalexptxt
            // 
            dashtotalexptxt.AutoSize = true;
            dashtotalexptxt.BackColor = Color.Transparent;
            dashtotalexptxt.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            dashtotalexptxt.ForeColor = Color.White;
            dashtotalexptxt.Location = new Point(28, 0);
            dashtotalexptxt.Name = "dashtotalexptxt";
            dashtotalexptxt.Size = new Size(225, 45);
            dashtotalexptxt.TabIndex = 3;
            dashtotalexptxt.Text = "Total Expense";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Bottom;
            panel4.BackColor = Color.Black;
            panel4.Controls.Add(label7);
            panel4.Location = new Point(3717, 4370);
            panel4.Name = "panel4";
            panel4.Size = new Size(468, 169);
            panel4.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(28, 0);
            label7.Name = "label7";
            label7.Size = new Size(321, 45);
            label7.TabIndex = 5;
            label7.Text = "Net Profit Summary";
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.None;
            panel5.BackColor = Color.Black;
            panel5.Controls.Add(label8);
            panel5.Location = new Point(3717, 2260);
            panel5.Name = "panel5";
            panel5.Size = new Size(468, 226);
            panel5.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(28, 0);
            label8.Name = "label8";
            label8.Size = new Size(265, 45);
            label8.TabIndex = 4;
            label8.Text = "Inventory Usage";
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top;
            panel6.BackColor = Color.Black;
            panel6.Controls.Add(label9);
            panel6.Location = new Point(3717, 206);
            panel6.Name = "panel6";
            panel6.Size = new Size(468, 170);
            panel6.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(28, 0);
            label9.Name = "label9";
            label9.Size = new Size(225, 45);
            label9.TabIndex = 3;
            label9.Text = "Total Expense";
            // 
            // financeexpensespanel
            // 
            financeexpensespanel.BackColor = Color.Black;
            financeexpensespanel.Controls.Add(netprofitchart);
            financeexpensespanel.Location = new Point(12, 170);
            financeexpensespanel.Name = "financeexpensespanel";
            financeexpensespanel.Size = new Size(1486, 855);
            financeexpensespanel.TabIndex = 60;
            financeexpensespanel.Paint += financeexpensespanel_Paint;
            // 
            // netprofitchart
            // 
            netprofitchart.BackColor = Color.Transparent;
            netprofitchart.BackgroundImageLayout = ImageLayout.None;
            netprofitchart.BackSecondaryColor = Color.Transparent;
            netprofitchart.BorderlineColor = Color.Transparent;
            chartArea2.Name = "ChartArea1";
            netprofitchart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            netprofitchart.Legends.Add(legend2);
            netprofitchart.Location = new Point(125, 59);
            netprofitchart.Name = "netprofitchart";
            netprofitchart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = Color.Blue;
            series4.Legend = "Legend1";
            series4.Name = "Net Profit Summary";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = Color.LimeGreen;
            series5.Legend = "Legend1";
            series5.Name = "Sales ";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = Color.FromArgb(192, 0, 0);
            series6.Legend = "Legend1";
            series6.Name = "Expenses";
            netprofitchart.Series.Add(series4);
            netprofitchart.Series.Add(series5);
            netprofitchart.Series.Add(series6);
            netprofitchart.Size = new Size(1239, 714);
            netprofitchart.TabIndex = 1;
            netprofitchart.Text = "Net Profit Summary";
            title2.ForeColor = Color.White;
            title2.Name = "Sales";
            netprofitchart.Titles.Add(title2);
            netprofitchart.Click += netprofitchart_Click;
            // 
            // NetProfit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1633, 1058);
            Controls.Add(panelContent);
            Name = "NetProfit";
            Text = "NetProfit";
            Load += NetProfit_Load;
            panelContent.ResumeLayout(false);
            dashnetprofit.ResumeLayout(false);
            dashnetprofit.PerformLayout();
            dashinventoryusage.ResumeLayout(false);
            dashinventoryusage.PerformLayout();
            dashtotalexpense.ResumeLayout(false);
            dashtotalexpense.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            financeexpensespanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)netprofitchart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContent;
        private ComboBox expensesposreporttype;
        private DateTimePicker calendardatepicker;
        private Button netprofitsummarybtn;
        private Button expensereportsbtn;
        private Button netsalessumbtn;
        private Panel dashnetprofit;
        private Label dashnetprofittxt;
        private Panel dashinventoryusage;
        private Label label2;
        private Panel dashtotalexpense;
        private Label dashtotalexptxt;
        private Panel panel4;
        private Label label7;
        private Panel panel5;
        private Label label8;
        private Panel panel6;
        private Label label9;
        private Panel financeexpensespanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart netprofitchart;
    }
}