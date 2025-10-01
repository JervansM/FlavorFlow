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
using Microsoft.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace FlavorFlowIT13
{
    public partial class SalesPOS : Form
    {
        private readonly string cloudConnectionString = "Data Source=db28059.public.databaseasp.net;Initial Catalog=db28059;Persist Security Info=True;User ID=db28059;Password=***********;Trust Server Certificate=True";
        private readonly string localConnectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        private Chart salesTrendChart;

        private string activeConnectionString;
        private bool isInitializing = true;
        public SalesPOS()
        {
            InitializeComponent();

            RoundPanel(salesposaverageordervaluetxt, 25);
            RoundPanel(salespostotalsalessummarytxt, 25);
            RoundPanel(salespospanelcontents, 25);
            RoundPanel(salespostotalsalesdatapanel, 25);
            RoundPanel(salespostotalordersdatapanel, 25);
            RoundPanel(averageordervaluepanel, 25);
            RoundPanel(salesposgrossrevenuepanel, 25);
            RoundPanel(salesposdiscountappliedpanel, 25);
            RoundPanel(salespostotalsalespanel, 25);

            averageordervaluepanel.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            salespostotalsalessummarytxt.BackColor = ColorTranslator.FromHtml("#2823B1");
            salespospanelcontents.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            salespostotalsalesdatapanel.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            averageordervaluepanel.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            salesposgrossrevenuepanel.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            salesposdiscountappliedpanel.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            salespostotalsalespanel.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            salespostotalordersdatapanel.BackColor = ColorTranslator.FromHtml("#1e1e1e");

            EnsureUiDefaults();




            salespostotalsalessummarytxt.ForeColor = Color.White;

            activeConnectionString = GetAvailableConnection();
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

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EnsureUiDefaults()
        {
            if (salesposreporttype.Items.Count == 0)
            {
                salesposreporttype.Items.AddRange(new object[] { "Daily", "Weekly", "Monthly", "Yearly" });
            }
            if (salesposreporttype.SelectedIndex < 0 && salesposreporttype.Items.Count > 0)
            {
                salesposreporttype.SelectedIndex = 0;
            }

            calendardatepicker.Format = DateTimePickerFormat.Custom;
            calendardatepicker.CustomFormat = "MMM dd, yyyy";
            calendardatepicker.Font = new Font("Segoe UI", 19F, FontStyle.Regular);
            calendardatepicker.CalendarMonthBackground = Color.Maroon;
        }

        private (DateTime start, DateTime end) GetDateRange(DateTime anchorDate, string period)
        {
            period = (period ?? "Daily").Trim();
            if (period.Equals("Daily", StringComparison.OrdinalIgnoreCase))
            {
                DateTime start = anchorDate.Date;
                DateTime end = start.AddDays(1);
                return (start, end);
            }
            if (period.Equals("Weekly", StringComparison.OrdinalIgnoreCase))
            {
                // Week starts Monday
                int diff = (7 + (int)anchorDate.Date.DayOfWeek - (int)DayOfWeek.Monday) % 7;
                DateTime start = anchorDate.Date.AddDays(-diff);
                DateTime end = start.AddDays(7);
                return (start, end);
            }
            if (period.Equals("Monthly", StringComparison.OrdinalIgnoreCase))
            {
                DateTime start = new DateTime(anchorDate.Year, anchorDate.Month, 1);
                DateTime end = start.AddMonths(1);
                return (start, end);
            }
            if (period.Equals("Yearly", StringComparison.OrdinalIgnoreCase))
            {
                DateTime start = new DateTime(anchorDate.Year, 1, 1);
                DateTime end = start.AddYears(1);
                return (start, end);
            }
            return (anchorDate.Date, anchorDate.Date.AddDays(1));
        }

        private void LoadSalesMetrics()
        {
            string period = (salesposreporttype.SelectedItem as string) ?? "Daily";
            DateTime anchor = calendardatepicker.Value;
            var range = GetDateRange(anchor, period);

            decimal totalSales = 0m;
            decimal totalDiscount = 0m;
            int totalOrders = 0;
            decimal grossRevenue = 0m;

            string sql = @"
                WITH PaymentAgg AS (
                    SELECT OrderID, SUM(ISNULL(AmountPaid,0)) AS PaidAmount
                    FROM dbo.Payments
                    WHERE PaymentDate >= @StartDate AND PaymentDate < @EndDate
                    GROUP BY OrderID
                )
                SELECT
                    ISNULL(SUM(o.TotalAmount), 0) AS TotalAmount,
                    ISNULL(SUM(o.DiscountAmount), 0) AS DiscountAmount,
                    COUNT(DISTINCT o.OrderID) AS OrderCount,
                    ISNULL(SUM(COALESCE(p.PaidAmount, o.TotalAmount - ISNULL(o.DiscountAmount,0))), 0) AS GrossRevenue
                FROM dbo.Orders o
                LEFT JOIN PaymentAgg p ON p.OrderID = o.OrderID
                WHERE o.Date >= @StartDate AND o.Date < @EndDate;";

            try
            {
                if (string.IsNullOrWhiteSpace(activeConnectionString))
                {
                    activeConnectionString = GetAvailableConnection();
                    if (string.IsNullOrWhiteSpace(activeConnectionString)) return;
                }
                using (var conn = new SqlConnection(activeConnectionString))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", range.start);
                    cmd.Parameters.AddWithValue("@EndDate", range.end);
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            totalSales = rdr.IsDBNull(0) ? 0m : rdr.GetDecimal(0);
                            totalDiscount = rdr.IsDBNull(1) ? 0m : rdr.GetDecimal(1);
                            totalOrders = rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2);
                            grossRevenue = rdr.IsDBNull(3) ? 0m : rdr.GetDecimal(3);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (grossRevenue <= 0m)
            {
                grossRevenue = Math.Max(0m, totalSales - totalDiscount);
            }
            decimal averageOrderValue = totalOrders > 0 ? grossRevenue / totalOrders : 0m;

            UpdateSalesUi(grossRevenue, totalSales, totalDiscount, totalOrders, averageOrderValue);
        }


        private void UpdateSalesUi(decimal grossRevenue, decimal totalSales, decimal totalDiscount, int totalOrders, decimal averageOrderValue)
        {
            if (salesposgrossrevenuedata != null)
                salesposgrossrevenuedata.Text = "₱" + grossRevenue.ToString("N2");
            if (salespostotalsalesdatapaneltxtdata != null)
                salespostotalsalesdatapaneltxtdata.Text = "₱" + totalSales.ToString("N2");
            if (salesposdiscountappliedtxtdata != null)
                salesposdiscountappliedtxtdata.Text = "₱" + totalDiscount.ToString("N2");
            if (salespostotalordersdata != null)
                salespostotalordersdata.Text = totalOrders.ToString();
            if (salesposaverageordervaluetxtdata != null)
                salesposaverageordervaluetxtdata.Text = "₱" + averageOrderValue.ToString("N2");
            if (salespostotalnetsalestxtdata != null)
                salespostotalnetsalestxtdata.Text = "₱" + grossRevenue.ToString("N2");
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

        private void SalesPOS_Load(object sender, EventArgs e)
        {
            InitializeSalesTrendChart();
            EnsureUiDefaults();
            LoadSalesMetrics();
            LoadSalesTrend();
            isInitializing = false;
        }

        private void systemsearchbarpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void salespospanelcontents_Paint(object sender, PaintEventArgs e)
        {

        }

        private void salespanelsalespospanelcontentsheader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void salespostotalsalessummarytxt_Click(object sender, EventArgs e)
        {

        }

        private void panelContent_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void salespostotalsalesdatapaneltxt_Click(object sender, EventArgs e)
        {

        }

        private void salespostotalordersdatapanel_Paint(object sender, PaintEventArgs e)
        {

        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void salespostotalsalesdatapaneltxt_Click_1(object sender, EventArgs e)
        {

        }

        private void salespostotalsalesdatapaneltxtdata_Click(object sender, EventArgs e)
        {

        }

        private void salespostotalordersdatapaneltxt_Click(object sender, EventArgs e)
        {

        }

        private void salesposaverageordervaluetxtdata_Click(object sender, EventArgs e)
        {

        }

        private void salespostotalsalesdatapanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void averageordervaluepanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void salesposgrossrevenuepanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void salespostotalsalestxtdata_Click(object sender, EventArgs e)
        {
            LoadSalesMetrics();
        }

        private void salesposdiscountappliedtxtdata_Click(object sender, EventArgs e)
        {

        }

        private void salesposgrossrevenuedata_Click(object sender, EventArgs e)
        {

        }

        private void salespostotalordersdata_Click(object sender, EventArgs e)
        {

        }

        private void salesposreporttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitializing) return;
            LoadSalesMetrics();
            LoadSalesTrend();
        }

        private void calendardatepicker_ValueChanged(object sender, EventArgs e)
        {
            if (isInitializing) return;
            LoadSalesMetrics();
            EnsureUiDefaults();
            LoadSalesTrend();
        }
        private void InitializeSalesTrendChart()
        {
            // Reuse existing chart if already added
            foreach (Control c in salespospanelcontents.Controls)
            {
                if (c is Chart existing)
                {
                    salesTrendChart = existing;
                    break;
                }
            }

            if (salesTrendChart == null)
            {
                salesTrendChart = new Chart
                {
                    BackColor = ColorTranslator.FromHtml("#FFFFFF")
                };
                salespospanelcontents.Controls.Add(salesTrendChart);
            }

            salesTrendChart.Titles.Clear();
            salesTrendChart.Series.Clear();
            salesTrendChart.ChartAreas.Clear();
            salesTrendChart.Legends.Clear();
        
            // Smooth rendering
            salesTrendChart.AntiAliasing = AntiAliasingStyles.All;
            salesTrendChart.TextAntiAliasingQuality = TextAntiAliasingQuality.High;

            ChartArea chartArea = new ChartArea("Main");
            chartArea.BackColor = ColorTranslator.FromHtml("#1E1E1E");
            chartArea.AxisX.LabelStyle.ForeColor = Color.White;
            chartArea.AxisY.LabelStyle.ForeColor = Color.White;
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 19F, FontStyle.Bold);

            chartArea.AxisX.Title = "Date";
            chartArea.AxisX.TitleFont = new Font("Segoe UI", 14F, FontStyle.Bold);
            chartArea.AxisX.TitleForeColor = Color.White;
            chartArea.AxisY.Title = "Net Sales (₱)";
            chartArea.AxisY.TitleFont = new Font("Segoe UI", 14F, FontStyle.Bold);
            chartArea.AxisY.TitleForeColor = Color.White;
            chartArea.AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#FFFFFF");
            chartArea.AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#FFFFFF");
            chartArea.AxisX.LabelStyle.Format = "MMM dd";
            chartArea.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chartArea.AxisY.IsStartedFromZero = true;
            chartArea.AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chartArea.AxisY.LabelStyle.Format = "₱#,0";
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = true;
            salesTrendChart.ChartAreas.Add(chartArea);

            Legend legend = new Legend("Legend")
            {
                Docking = Docking.Top,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold)
            };
            salesTrendChart.Legends.Add(legend);

            // Title
            salesTrendChart.Titles.Add(new Title("Sales Trend")
            {
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 17F, FontStyle.Bold)
            });

            Series series = new Series("Net Sales")
            {
                ChartType = SeriesChartType.Column,
                Color = ColorTranslator.FromHtml("#5FBE6A"),
                IsValueShownAsLabel = true,
                LabelForeColor = Color.White,
                Font = new Font("Segoe UI", 19F, FontStyle.Bold),
                XValueType = ChartValueType.DateTime,
                YValueType = ChartValueType.Double,
                IsXValueIndexed = true,
                ChartArea = "Main",
                Legend = "Legend",
                BorderWidth = 0
            };
            series.SmartLabelStyle.Enabled = true;
            series.ToolTip = "#VALX: ₱#VAL{N2}";
            salesTrendChart.Series.Add(series);
        }

        private void salestrendchart_Click(object sender, EventArgs e)
        {
        }
        private DataTable GetSalesTrendData(DateTime startDate, DateTime endDate, string period)
        {
            // Build query based on selected period granularity
            string sql;
            if (period.Equals("Monthly", StringComparison.OrdinalIgnoreCase))
            {
                sql = @"
        SELECT 
            CAST(DATEFROMPARTS(YEAR(o.Date), MONTH(o.Date), 1) AS DATE) AS SalesDate,
            SUM(o.TotalAmount - ISNULL(o.DiscountAmount,0)) AS NetSales
        FROM dbo.Orders o
        WHERE o.Date >= @StartDate AND o.Date < @EndDate
        GROUP BY DATEFROMPARTS(YEAR(o.Date), MONTH(o.Date), 1)
        ORDER BY SalesDate;";
            }
            else if (period.Equals("Yearly", StringComparison.OrdinalIgnoreCase))
            {
                sql = @"
        SELECT 
            CAST(DATEFROMPARTS(YEAR(o.Date), 1, 1) AS DATE) AS SalesDate,
            SUM(o.TotalAmount - ISNULL(o.DiscountAmount,0)) AS NetSales
        FROM dbo.Orders o
        WHERE o.Date >= @StartDate AND o.Date < @EndDate
        GROUP BY DATEFROMPARTS(YEAR(o.Date), 1, 1)
        ORDER BY SalesDate;";
            }
            else
            {
                // Daily (default) and Weekly (still plot daily buckets in the selected week)
                sql = @"
        SELECT 
            CAST(o.Date AS DATE) AS SalesDate,
            SUM(o.TotalAmount - ISNULL(o.DiscountAmount,0)) AS NetSales
        FROM dbo.Orders o
        WHERE o.Date >= @StartDate AND o.Date < @EndDate
        GROUP BY CAST(o.Date AS DATE)
        ORDER BY SalesDate;";
            }

            DataTable dt = new DataTable();

            try
            {
                if (string.IsNullOrWhiteSpace(activeConnectionString))
                {
                    activeConnectionString = GetAvailableConnection();
                    if (string.IsNullOrWhiteSpace(activeConnectionString)) return dt;
                }
                using (var conn = new SqlConnection(activeConnectionString))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    conn.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading trend data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }
        private void LoadSalesTrend()
        {
            if (salesTrendChart == null)
            {
                InitializeSalesTrendChart();
            }

            string period = (salesposreporttype.SelectedItem as string) ?? "Daily";
            DateTime anchor = calendardatepicker.Value;
            var range = GetDateRange(anchor, period);

            DataTable dt = GetSalesTrendData(range.start, range.end, period);

            Series series = salesTrendChart.Series.IndexOf("Net Sales") >= 0
                ? salesTrendChart.Series["Net Sales"]
                : salesTrendChart.Series.Add("Net Sales");

            series.Points.Clear();
            series.XValueType = ChartValueType.DateTime;
            series.YValueType = ChartValueType.Double;
            series.IsXValueIndexed = true;

            foreach (DataRow row in dt.Rows)
            {
                DateTime date = Convert.ToDateTime(row["SalesDate"]);
                double sales = Convert.ToDouble(row["NetSales"]);
                series.Points.AddXY(date, sales);
            }

            if (series.Points.Count == 0)
            {
                series.Points.AddXY(DateTime.Today, 0);
            }

            // Axis label format depending on period
            var ca = salesTrendChart.ChartAreas["Main"];
            if (period.Equals("Monthly", StringComparison.OrdinalIgnoreCase))
            {
                ca.AxisX.LabelStyle.Format = "MMM yyyy";
            }
            else if (period.Equals("Yearly", StringComparison.OrdinalIgnoreCase))
            {
                ca.AxisX.LabelStyle.Format = "yyyy";
            }
            else
            {
                ca.AxisX.LabelStyle.Format = "MMM dd";
            }

            // Recalculate scale to fit data nicely
            ca.RecalculateAxesScale();
        }


    }
}
