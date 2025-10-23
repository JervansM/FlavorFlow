using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FlavorFlowIT13
{
    public partial class NetProfit : Form
    {
        private readonly string cloudConnectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
        private readonly string localConnectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        private string activeConnectionString;
        private Chart netProfitChart;
        private DateTime currentDate;
        private string currentReportType = "Daily";

        public NetProfit()
        {
            InitializeComponent();
            activeConnectionString = GetAvailableConnection();

            // Set default values
            currentDate = DateTime.Today;
            currentReportType = "Daily";

            // Attach event handlers
            expensesposreporttype.SelectedIndexChanged += expensesposreporttype_SelectedIndexChanged;
            calendardatepicker.ValueChanged += calendardatepicker_ValueChanged;
        }
        private string GetAvailableConnection()
        {
            if (TestConnection(cloudConnectionString))
            {
                return cloudConnectionString;
            }
            else if (TestConnection(localConnectionString))
            {
                return localConnectionString;
            }
            else
            {
                MessageBox.Show("No available database connection.", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private bool TestConnection(string connectionString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false; // Connection failed
            }
        }
        private void InitializeNetProfitChart()
        {
            if (netProfitChart == null)
            {
                netProfitChart = new Chart { Dock = DockStyle.Fill, BackColor = ColorTranslator.FromHtml("#2f2f2f") };
                financeexpensespanel.Controls.Clear();
                financeexpensespanel.Controls.Add(netProfitChart);
            }

            netProfitChart.Series.Clear();
            netProfitChart.ChartAreas.Clear();
            netProfitChart.Titles.Clear();
            netProfitChart.Legends.Clear();

            // Smooth rendering
            netProfitChart.AntiAliasing = AntiAliasingStyles.All;
            netProfitChart.TextAntiAliasingQuality = TextAntiAliasingQuality.High;

            ChartArea area = new ChartArea("Main")
            {
                BackColor = ColorTranslator.FromHtml("#2f2f2f"),
                BorderColor = ColorTranslator.FromHtml("#555555"),
                BorderWidth = 1
            };

            // Configure X-axis
            area.AxisX.Title = "Date";
            area.AxisX.TitleForeColor = Color.White;
            area.AxisX.TitleFont = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            area.AxisX.LabelStyle.ForeColor = Color.White;
            area.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            area.AxisX.LabelStyle.Format = "MMM dd";
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.MajorTickMark.Enabled = true;
            area.AxisX.MajorTickMark.LineColor = ColorTranslator.FromHtml("#666666");
            area.AxisX.MinorTickMark.Enabled = false;
            area.AxisX.LineColor = ColorTranslator.FromHtml("#666666");

            // Configure Y-axis
            area.AxisY.Title = "Amount (₱)";
            area.AxisY.TitleForeColor = Color.White;
            area.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            area.AxisY.LabelStyle.ForeColor = Color.White;
            area.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            area.AxisY.LabelStyle.Format = "₱#,0";
            area.AxisY.IsStartedFromZero = true;
            area.AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#444444");
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisY.MajorTickMark.Enabled = true;
            area.AxisY.MajorTickMark.LineColor = ColorTranslator.FromHtml("#666666");
            area.AxisY.MinorTickMark.Enabled = false;
            area.AxisY.LineColor = ColorTranslator.FromHtml("#666666");

            // Add padding for better appearance and prevent label overlap
            area.Position.X = 8;
            area.Position.Y = 12;
            area.Position.Width = 88;
            area.Position.Height = 80;

            // Add margins to prevent label cutoff
            area.InnerPlotPosition.X = 10;
            area.InnerPlotPosition.Y = 2;
            area.InnerPlotPosition.Width = 85;
            area.InnerPlotPosition.Height = 90;

            netProfitChart.ChartAreas.Add(area);

            Legend legend = new Legend("Legend")
            {
                Docking = Docking.Top,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold)
            };
            netProfitChart.Legends.Add(legend);

            // Title
            netProfitChart.Titles.Add(new Title("Net Profit Trend")
            {
                ForeColor = Color.White,
                Font = new System.Drawing.Font("Segoe UI", 16F, FontStyle.Bold),
                Docking = Docking.Top
            });

            // Series
            Series salesSeries = new Series("Sales")
            {
                ChartType = SeriesChartType.Line,
                Color = ColorTranslator.FromHtml("#5FBE6A"),
                IsValueShownAsLabel = true,
                LabelForeColor = Color.White,
                LabelFormat = "₱{0:N0}",
                Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold),
                XValueType = ChartValueType.DateTime,
                YValueType = ChartValueType.Double,
                ChartArea = "Main",
                Legend = "Legend",
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8,
                MarkerColor = ColorTranslator.FromHtml("#4A9B55"),
                MarkerBorderColor = ColorTranslator.FromHtml("#2E7D32"),
                MarkerBorderWidth = 2
            };
            salesSeries.SmartLabelStyle.Enabled = true;
            salesSeries.ToolTip = "#VALX: Sales ₱#VAL{N2}";

            Series expensesSeries = new Series("Expenses")
            {
                ChartType = SeriesChartType.Line,
                Color = ColorTranslator.FromHtml("IndianRed"),
                IsValueShownAsLabel = true,
                LabelForeColor = Color.White,
                LabelFormat = "₱{0:N0}",
                Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold),
                XValueType = ChartValueType.DateTime,
                YValueType = ChartValueType.Double,
                ChartArea = "Main",
                Legend = "Legend",
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8,
                MarkerColor = ColorTranslator.FromHtml("IndianRed"),
                MarkerBorderColor = ColorTranslator.FromHtml("IndianRed"),
                MarkerBorderWidth = 2
            };
            expensesSeries.SmartLabelStyle.Enabled = true;
            expensesSeries.ToolTip = "#VALX: Expenses ₱#VAL{N2}";

            Series profitSeries = new Series("Net Profit")
            {
                ChartType = SeriesChartType.Line,
                Color = ColorTranslator.FromHtml("#3498DB"),
                IsValueShownAsLabel = true,
                LabelFormat = "₱{0:N0}",
                Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold),
                XValueType = ChartValueType.DateTime,
                YValueType = ChartValueType.Double,
                ChartArea = "Main",
                Legend = "Legend",
                BorderWidth = 4,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 10,
                MarkerColor = ColorTranslator.FromHtml("#2980B9"),
                MarkerBorderColor = ColorTranslator.FromHtml("#1F618D"),
                MarkerBorderWidth = 2
            };
            profitSeries.SmartLabelStyle.Enabled = true;
            profitSeries.ToolTip = "#VALX: Net Profit ₱#VAL{N2}";

            netProfitChart.Series.Add(salesSeries);
            netProfitChart.Series.Add(expensesSeries);
            netProfitChart.Series.Add(profitSeries);
        }
        private DataTable GetSalesData(DateTime startDate, DateTime endDate, string reportType = "Daily")
        {
            DataTable dt = new DataTable();
            string sql;

            // Build query based on selected period granularity
            if (reportType.Equals("Monthly", StringComparison.OrdinalIgnoreCase))
            {
                sql = @"
            SELECT 
                CAST(DATEFROMPARTS(YEAR(Date), MONTH(Date), 1) AS DATE) AS SalesDate,
                SUM(TotalAmount - ISNULL(DiscountAmount,0)) AS NetSales
            FROM dbo.Orders
            WHERE Date >= @StartDate AND Date < @EndDate
            GROUP BY DATEFROMPARTS(YEAR(Date), MONTH(Date), 1)
            ORDER BY SalesDate;";
            }
            else if (reportType.Equals("Yearly", StringComparison.OrdinalIgnoreCase))
            {
                sql = @"
            SELECT 
                CAST(DATEFROMPARTS(YEAR(Date), 1, 1) AS DATE) AS SalesDate,
                SUM(TotalAmount - ISNULL(DiscountAmount,0)) AS NetSales
            FROM dbo.Orders
            WHERE Date >= @StartDate AND Date < @EndDate
            GROUP BY DATEFROMPARTS(YEAR(Date), 1, 1)
            ORDER BY SalesDate;";
            }
            else
            {
                // Daily (default) and Weekly (still plot daily buckets in the selected week)
                sql = @"
            SELECT CAST(Date AS DATE) AS SalesDate,
                   SUM(TotalAmount - ISNULL(DiscountAmount,0)) AS NetSales
            FROM dbo.Orders
            WHERE Date >= @StartDate AND Date < @EndDate
            GROUP BY CAST(Date AS DATE)
            ORDER BY SalesDate;";
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(activeConnectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales data: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }
        private DataTable GetExpensesData(DateTime startDate, DateTime endDate, string reportType = "Daily")
        {
            DataTable dt = new DataTable();
            string sql;

            // Build query based on selected period granularity
            if (reportType.Equals("Monthly", StringComparison.OrdinalIgnoreCase))
            {
                sql = @"
            SELECT 
                CAST(DATEFROMPARTS(YEAR(Date), MONTH(Date), 1) AS DATE) AS ExpenseDate,
                SUM(Amount) AS TotalExpense
            FROM dbo.Expenses
            WHERE Date >= @StartDate AND Date < @EndDate
            GROUP BY DATEFROMPARTS(YEAR(Date), MONTH(Date), 1)
            ORDER BY ExpenseDate;";
            }
            else if (reportType.Equals("Yearly", StringComparison.OrdinalIgnoreCase))
            {
                sql = @"
            SELECT 
                CAST(DATEFROMPARTS(YEAR(Date), 1, 1) AS DATE) AS ExpenseDate,
                SUM(Amount) AS TotalExpense
            FROM dbo.Expenses
            WHERE Date >= @StartDate AND Date < @EndDate
            GROUP BY DATEFROMPARTS(YEAR(Date), 1, 1)
            ORDER BY ExpenseDate;";
            }
            else
            {
                // Daily (default) and Weekly (still plot daily buckets in the selected week)
                sql = @"
            SELECT CAST(Date AS DATE) AS ExpenseDate,
                   SUM(Amount) AS TotalExpense
            FROM dbo.Expenses
            WHERE Date >= @StartDate AND Date < @EndDate
            GROUP BY CAST(Date AS DATE)
            ORDER BY ExpenseDate;";
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(activeConnectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading expenses data: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        private void LoadNetProfitData(string reportType, DateTime selectedDate)
        {
            if (netProfitChart == null) InitializeNetProfitChart();

            // Fix: pass parameters to GetDateRange
            (DateTime start, DateTime end) = GetDateRange(selectedDate, selectedDate, reportType);

            var chartArea = netProfitChart.ChartAreas["Main"];
            ConfigureNetProfitXAxis(chartArea, reportType, start, end);

            // Fetch Sales
            DataTable salesDt = GetSalesData(start, end, reportType);
            // Fetch Expenses
            DataTable expensesDt = GetExpensesData(start, end, reportType);

            // Clear old points
            netProfitChart.Series["Sales"].Points.Clear();
            netProfitChart.Series["Expenses"].Points.Clear();
            netProfitChart.Series["Net Profit"].Points.Clear();

            // Collect all dates for alignment
            var allDates = salesDt.AsEnumerable().Select(r => r.Field<DateTime>("SalesDate"))
                .Union(expensesDt.AsEnumerable().Select(r => r.Field<DateTime>("ExpenseDate")))
                .Distinct()
                .OrderBy(d => d);

            foreach (var date in allDates)
            {
                double sales = salesDt.AsEnumerable()
                    .Where(r => r.Field<DateTime>("SalesDate") == date)
                    .Select(r => Convert.ToDouble(r.Field<decimal>("NetSales")))
                    .FirstOrDefault();

                double expenses = expensesDt.AsEnumerable()
                    .Where(r => r.Field<DateTime>("ExpenseDate") == date)
                    .Select(r => Convert.ToDouble(r.Field<decimal>("TotalExpense")))
                    .FirstOrDefault();

                double netProfit = sales - expenses;

                // Add points to series
                netProfitChart.Series["Sales"].Points.AddXY(date, sales);
                netProfitChart.Series["Expenses"].Points.AddXY(date, expenses);

                int profitPointIndex = netProfitChart.Series["Net Profit"].Points.AddXY(date, netProfit);
                var profitPoint = netProfitChart.Series["Net Profit"].Points[profitPointIndex];
                profitPoint.LabelForeColor = netProfit >= 0 ? ColorTranslator.FromHtml("#27AE60") : ColorTranslator.FromHtml("#E74C3C");
            }

            chartArea.RecalculateAxesScale();
            UpdateTotalNetProfit();
        }

        private void ConfigureNetProfitXAxis(ChartArea chartArea, string reportType, DateTime startDate, DateTime endDate)
        {
            // Reset axis properties
            chartArea.AxisX.LabelStyle.Format = "";
            chartArea.AxisX.LabelStyle.Interval = 0;
            chartArea.AxisX.LabelStyle.IntervalOffset = 0;
            chartArea.AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Auto;
            chartArea.AxisX.LabelStyle.Angle = 0;
            chartArea.AxisX.MajorTickMark.Enabled = true;
            chartArea.AxisX.MajorTickMark.Interval = 0;
            chartArea.AxisX.MajorTickMark.IntervalType = DateTimeIntervalType.Auto;

            // Calculate data density to determine optimal interval
            int dataPoints = (int)(endDate - startDate).TotalDays;
            int optimalInterval = Math.Max(1, dataPoints / 8); // Max 8 labels for readability

            switch (reportType)
            {
                case "Daily":
                    chartArea.AxisX.LabelStyle.Format = "MMM dd";
                    chartArea.AxisX.LabelStyle.Interval = optimalInterval;
                    chartArea.AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Days;
                    chartArea.AxisX.LabelStyle.Angle = -60;
                    chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8F);
                    chartArea.AxisX.MajorTickMark.Interval = optimalInterval;
                    chartArea.AxisX.MajorTickMark.IntervalType = DateTimeIntervalType.Days;
                    break;

                case "Weekly":
                    chartArea.AxisX.LabelStyle.Format = "MMM dd";
                    chartArea.AxisX.LabelStyle.Interval = Math.Max(1, optimalInterval / 2);
                    chartArea.AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Days;
                    chartArea.AxisX.LabelStyle.Angle = -60;
                    chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8F);
                    chartArea.AxisX.MajorTickMark.Interval = Math.Max(1, optimalInterval / 2);
                    chartArea.AxisX.MajorTickMark.IntervalType = DateTimeIntervalType.Days;
                    break;

                case "Monthly":
                    chartArea.AxisX.LabelStyle.Format = "MMM yyyy";
                    chartArea.AxisX.LabelStyle.Interval = 1;
                    chartArea.AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Months;
                    chartArea.AxisX.LabelStyle.Angle = -45;
                    chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
                    chartArea.AxisX.MajorTickMark.Interval = 1;
                    chartArea.AxisX.MajorTickMark.IntervalType = DateTimeIntervalType.Months;
                    break;

                case "Yearly":
                    chartArea.AxisX.LabelStyle.Format = "yyyy";
                    chartArea.AxisX.LabelStyle.Interval = 1;
                    chartArea.AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Years;
                    chartArea.AxisX.LabelStyle.Angle = 0;
                    chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
                    chartArea.AxisX.MajorTickMark.Interval = 1;
                    chartArea.AxisX.MajorTickMark.IntervalType = DateTimeIntervalType.Years;
                    break;

                default:
                    chartArea.AxisX.LabelStyle.Format = "MMM dd";
                    chartArea.AxisX.LabelStyle.Interval = optimalInterval;
                    chartArea.AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Days;
                    chartArea.AxisX.LabelStyle.Angle = -60;
                    chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8F);
                    break;
            }

            // Set axis range with padding to prevent edge overlap
            double padding = (endDate.ToOADate() - startDate.ToOADate()) * 0.05; // 5% padding
            chartArea.AxisX.Minimum = startDate.ToOADate() - padding;
            chartArea.AxisX.Maximum = endDate.ToOADate() + padding;
            chartArea.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;

            // Add extra margin for labels
            chartArea.AxisX.ScaleView.Zoomable = false;
            chartArea.AxisX.ScrollBar.IsPositionedInside = false;
        }

        private (DateTime start, DateTime end) GetDateRange(DateTime startDate, DateTime endDate, string period)
        {
            return (startDate.Date, endDate.Date.AddDays(1)); // end is exclusive

        }
        private void expensesposreporttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentReportType = expensesposreporttype.SelectedItem?.ToString() ?? "Daily";
            LoadNetProfitData(currentReportType, currentDate);
            UpdateTotalNetProfit();
        }

        private void calendardatepicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime start = calendardatepicker.Value;
            DateTime end = calendardatepicker2.Value;

            if (end < start)
            {
                MessageBox.Show("End date cannot be earlier than start date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                calendardatepicker2.Value = start;
                return;
            }

            LoadNetProfitDataByRange(start, end);
        }



        private void RoundButton(Button button, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(button.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(button.Width - radius, button.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, button.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            button.Region = new System.Drawing.Region(path);
        }

        private void RoundPanel(Panel pnl, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(pnl.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(pnl.Width - radius, pnl.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, pnl.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            pnl.Region = new Region(path);
        }
        private void LoadContent(Form form)
        {
            foreach (Control ctrl in panelContent.Controls)
            {
                ctrl.Dispose();
            }

            panelContent.Controls.Clear();

            // Prepare the new form
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Add to panel
            panelContent.Controls.Add(form);
            form.Show();

        }
        private void systemsearchbaricon_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void systemgeneralsettings_Click(object sender, EventArgs e)
        {

        }

        private void systemappconfigure_Click(object sender, EventArgs e)
        {

        }

        private void systempanelheadercoral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void systemsettingssavebtn_Click(object sender, EventArgs e)
        {

        }

        private void systemsearchbar_TextChanged(object sender, EventArgs e)
        {

        }

        private void expensesreportbtn_Click(object sender, EventArgs e)
        {

        }

        private void NetProfit_Load(object sender, EventArgs e)
        {
            RoundPanel(panelContent, 25);
            RoundPanel(financeexpensespanel, 25);
            RoundButton(netsalessumbtn, 20);
            RoundButton(expensereportsbtn, 20);
            RoundButton(netprofitsummarybtn, 20);
            RoundPanel(totalnetprofitpanel, 25);
            RoundButton(generatereportbtn, 20);

            generatereportbtn.UseVisualStyleBackColor = false;
            generatereportbtn.FlatStyle = FlatStyle.Flat;
            generatereportbtn.FlatAppearance.BorderSize = 0;
            generatereportbtn.BackColor = ColorTranslator.FromHtml("#2823B1");
            generatereportbtn.ForeColor = Color.White;

            // Default Daily
            if (expensesposreporttype.Items.Count == 0)
            {
                expensesposreporttype.Items.AddRange(new object[] { "Daily", "Weekly", "Monthly", "Yearly" });
            }
            expensesposreporttype.SelectedIndex = 0;
            currentReportType = "Daily";

            calendardatepicker.Value = DateTime.Today;
            currentDate = DateTime.Today;

            InitializeNetProfitChart();
            LoadNetProfitData(currentReportType, currentDate);

            financeexpensespanel.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            totalnetprofitpanel.BackColor = ColorTranslator.FromHtml("#2f2f2f");


            netsalessumbtn.UseVisualStyleBackColor = false;
            netsalessumbtn.FlatStyle = FlatStyle.Flat;
            netsalessumbtn.FlatAppearance.BorderSize = 0;
            netsalessumbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            netsalessumbtn.ForeColor = Color.White;
            netsalessumbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            netsalessumbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            expensereportsbtn.UseVisualStyleBackColor = false;
            expensereportsbtn.FlatStyle = FlatStyle.Flat;
            expensereportsbtn.FlatAppearance.BorderSize = 0;
            expensereportsbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            expensereportsbtn.ForeColor = Color.White;
            expensereportsbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            expensereportsbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            netprofitsummarybtn.UseVisualStyleBackColor = false;
            netprofitsummarybtn.FlatStyle = FlatStyle.Flat;
            netprofitsummarybtn.FlatAppearance.BorderSize = 0;
            netprofitsummarybtn.BackColor = ColorTranslator.FromHtml("#6C6868");
            netprofitsummarybtn.ForeColor = Color.White;
            netprofitsummarybtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            netprofitsummarybtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            UpdateTotalNetProfit();

        }

        private void expensereportsbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new Expenses());
        }

        private void netprofitsummarybtn_Click(object sender, EventArgs e)
        {
            LoadContent(new NetProfit());
        }

        private void netsalessumbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new FinanceExpenses());
        }

        private void netprofitchart_Click(object sender, EventArgs e)
        {

        }

        private void financeexpensespanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void totalnetprofttxt_Click(object sender, EventArgs e)
        {

        }

        private void totalnetprofitpanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void UpdateTotalNetProfit()
        {
            try
            {
                // Get current values from UI
                DateTime currentDate = calendardatepicker.Value;
                string currentReportType = expensesposreporttype.SelectedItem?.ToString() ?? "Daily";

                // Fix: Pass proper parameters to GetDateRange
                (DateTime start, DateTime end) = GetDateRange(currentDate, currentDate, currentReportType);

                decimal totalSales = 0m;
                decimal totalExpenses = 0m;

                string salesQuery = @"SELECT ISNULL(SUM(TotalAmount - ISNULL(DiscountAmount,0)),0)
                              FROM dbo.Orders
                              WHERE Date >= @StartDate AND Date < @EndDate
                                AND Status='Completed' AND PaymentStatus='Paid'";

                string expensesQuery = @"SELECT ISNULL(SUM(Amount),0)
                                 FROM dbo.Expenses
                                 WHERE Date >= @StartDate AND Date < @EndDate";

                using (SqlConnection conn = new SqlConnection(activeConnectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(salesQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", start);
                        cmd.Parameters.AddWithValue("@EndDate", end);
                        totalSales = Convert.ToDecimal(cmd.ExecuteScalar());
                    }

                    using (SqlCommand cmd = new SqlCommand(expensesQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", start);
                        cmd.Parameters.AddWithValue("@EndDate", end);
                        totalExpenses = Convert.ToDecimal(cmd.ExecuteScalar());
                    }
                }

                decimal netProfit = totalSales - totalExpenses;

                totalnetprofttxt.Text = $"₱{Math.Abs(netProfit):N2}";
                totalnetprofttxt.ForeColor = netProfit >= 0
                    ? ColorTranslator.FromHtml("#27AE60")
                    : ColorTranslator.FromHtml("#E74C3C");
                totalnetprofitlbl.Text = netProfit >= 0 ? "Net Profit :" : "Net Loss :";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating net profit: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void generatereportbtn_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime currentDate = calendardatepicker.Value;
                string currentReportType = expensesposreporttype.SelectedItem?.ToString() ?? "Daily";

                // Fix: Pass 3 parameters (startDate, endDate, reportType)
                (DateTime start, DateTime end) = GetDateRange(currentDate, currentDate, currentReportType);

                // Fetch sales and expenses
                DataTable salesDt = GetSalesData(start, end, currentReportType);
                DataTable expensesDt = GetExpensesData(start, end, currentReportType);

                if (salesDt.Rows.Count == 0 && expensesDt.Rows.Count == 0)
                {
                    MessageBox.Show("No data available for the selected period.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Merge into a single report table
                DataTable reportTable = new DataTable();
                reportTable.Columns.Add("Date", typeof(DateTime));
                reportTable.Columns.Add("Sales", typeof(decimal));
                reportTable.Columns.Add("Expenses", typeof(decimal));
                reportTable.Columns.Add("Net Profit", typeof(decimal));

                var allDates = salesDt.AsEnumerable()
                                      .Select(r => r.Field<DateTime>("SalesDate"))
                                      .Union(expensesDt.AsEnumerable().Select(r => r.Field<DateTime>("ExpenseDate")))
                                      .Distinct()
                                      .OrderBy(d => d);

                foreach (var date in allDates)
                {
                    decimal sales = salesDt.AsEnumerable()
                                           .Where(r => r.Field<DateTime>("SalesDate") == date)
                                           .Select(r => Convert.ToDecimal(r.Field<decimal>("NetSales")))
                                           .FirstOrDefault();

                    decimal expenses = expensesDt.AsEnumerable()
                                                 .Where(r => r.Field<DateTime>("ExpenseDate") == date)
                                                 .Select(r => Convert.ToDecimal(r.Field<decimal>("TotalExpense")))
                                                 .FirstOrDefault();

                    decimal netProfit = sales - expenses;
                    reportTable.Rows.Add(date, sales, expenses, netProfit);
                }

                // Save file dialog
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF files (*.pdf)|*.pdf";
                    sfd.FileName = $"NetProfitReport_{currentReportType}_{DateTime.Now:yyyyMMdd}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                            doc.Open();

                            // Title
                            Paragraph title = new Paragraph($"Net Profit Report ({currentReportType})",
                                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD, BaseColor.BLACK))
                            { Alignment = Element.ALIGN_CENTER, SpacingAfter = 20f };
                            doc.Add(title);

                            // Date range
                            Paragraph dateRange = new Paragraph($"Period: {start:MMM dd, yyyy} - {end.AddDays(-1):MMM dd, yyyy}",
                                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK))
                            { Alignment = Element.ALIGN_CENTER, SpacingAfter = 20f };
                            doc.Add(dateRange);

                            // Chart image
                            if (netProfitChart != null && netProfitChart.Series.Count > 0)
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    netProfitChart.SaveImage(ms, ChartImageFormat.Png);
                                    iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(ms.ToArray());
                                    chartImage.ScaleToFit(500f, 400f);
                                    chartImage.Alignment = Element.ALIGN_CENTER;
                                    chartImage.SpacingAfter = 20f;
                                    doc.Add(chartImage);
                                }
                            }

                            // Table
                            PdfPTable table = new PdfPTable(reportTable.Columns.Count) { WidthPercentage = 100 };
                            foreach (DataColumn column in reportTable.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName,
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD)))
                                { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER };
                                table.AddCell(cell);
                            }

                            foreach (DataRow row in reportTable.Rows)
                            {
                                foreach (var item in row.ItemArray)
                                {
                                    PdfPCell cell = new PdfPCell(new Phrase(item is DateTime dt ? dt.ToString("MMM dd, yyyy") : item.ToString(),
                                        new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12)))
                                    { HorizontalAlignment = Element.ALIGN_CENTER };
                                    table.AddCell(cell);
                                }
                            }

                            doc.Add(table);

                            // Total Net Profit
                            decimal totalSales = reportTable.AsEnumerable().Sum(r => Convert.ToDecimal(r["Sales"]));
                            decimal totalExpenses = reportTable.AsEnumerable().Sum(r => Convert.ToDecimal(r["Expenses"]));
                            decimal totalNetProfit = totalSales - totalExpenses;

                            Paragraph total = new Paragraph($"\nTotal Sales: ₱{totalSales:N2}\nTotal Expenses: ₱{totalExpenses:N2}\nNet Profit: ₱{totalNetProfit:N2}",
                                                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK))
                            { Alignment = Element.ALIGN_RIGHT };
                            doc.Add(total);

                            doc.Close();
                            writer.Close();
                        }

                        MessageBox.Show("PDF report generated successfully!", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating PDF report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void calendardatepicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime start = calendardatepicker.Value;
            DateTime end = calendardatepicker2.Value;

            if (end < start)
            {
                MessageBox.Show("End date cannot be earlier than start date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                calendardatepicker2.Value = start;
                return;
            }

            LoadNetProfitDataByRange(start, end);
        }

        private void LoadNetProfitDataByRange(DateTime startDate, DateTime endDate)
        {
            if (netProfitChart == null) InitializeNetProfitChart();

            // Reuse chart configuration
            var chartArea = netProfitChart.ChartAreas["Main"];
            ConfigureNetProfitXAxis(chartArea, currentReportType, startDate, endDate);

            DataTable salesDt = GetSalesData(startDate, endDate, currentReportType);
            DataTable expensesDt = GetExpensesData(startDate, endDate, currentReportType);

            netProfitChart.Series["Sales"].Points.Clear();
            netProfitChart.Series["Expenses"].Points.Clear();
            netProfitChart.Series["Net Profit"].Points.Clear();

            var allDates = salesDt.AsEnumerable().Select(r => r.Field<DateTime>("SalesDate"))
                .Union(expensesDt.AsEnumerable().Select(r => r.Field<DateTime>("ExpenseDate")))
                .Distinct()
                .OrderBy(d => d);

            foreach (var date in allDates)
            {
                double sales = salesDt.AsEnumerable()
                    .Where(r => r.Field<DateTime>("SalesDate") == date)
                    .Select(r => Convert.ToDouble(r.Field<decimal>("NetSales")))
                    .FirstOrDefault();

                double expenses = expensesDt.AsEnumerable()
                    .Where(r => r.Field<DateTime>("ExpenseDate") == date)
                    .Select(r => Convert.ToDouble(r.Field<decimal>("TotalExpense")))
                    .FirstOrDefault();

                double netProfit = sales - expenses;

                netProfitChart.Series["Sales"].Points.AddXY(date, sales);
                netProfitChart.Series["Expenses"].Points.AddXY(date, expenses);

                int profitPointIndex = netProfitChart.Series["Net Profit"].Points.AddXY(date, netProfit);
                var profitPoint = netProfitChart.Series["Net Profit"].Points[profitPointIndex];
                profitPoint.LabelForeColor = netProfit >= 0 ? ColorTranslator.FromHtml("#27AE60") : ColorTranslator.FromHtml("#E74C3C");
            }

            chartArea.RecalculateAxesScale();

            // Update total net profit
            UpdateTotalNetProfitByRange(startDate, endDate);
        }
        private void UpdateTotalNetProfitByRange(DateTime startDate, DateTime endDate)
        {
            decimal totalSales = 0;
            decimal totalExpenses = 0;

            string salesQuery = @"SELECT ISNULL(SUM(TotalAmount - ISNULL(DiscountAmount,0)), 0)
                          FROM dbo.Orders
                          WHERE Date >= @StartDate AND Date < @EndDate
                          AND Status='Completed' AND PaymentStatus='Paid'";

            string expensesQuery = @"SELECT ISNULL(SUM(Amount), 0)
                             FROM dbo.Expenses
                             WHERE Date >= @StartDate AND Date < @EndDate";

            try
            {
                using (SqlConnection conn = new SqlConnection(activeConnectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(salesQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", startDate);
                        cmd.Parameters.AddWithValue("@EndDate", endDate);
                        totalSales = Convert.ToDecimal(cmd.ExecuteScalar());
                    }

                    using (SqlCommand cmd = new SqlCommand(expensesQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", startDate);
                        cmd.Parameters.AddWithValue("@EndDate", endDate);
                        totalExpenses = Convert.ToDecimal(cmd.ExecuteScalar());
                    }
                }

                decimal netProfit = totalSales - totalExpenses;
                totalnetprofttxt.Text = $"₱{Math.Abs(netProfit):N2}";
                totalnetprofttxt.ForeColor = netProfit >= 0 ? ColorTranslator.FromHtml("#27AE60") : ColorTranslator.FromHtml("#E74C3C");
                totalnetprofitlbl.Text = netProfit >= 0 ? "Net Profit :" : "Net Loss :";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating net profit: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}