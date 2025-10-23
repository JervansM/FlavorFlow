using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using iTextSharp.text;

namespace FlavorFlowIT13
{
    public partial class SalesPOS : Form
    {
        private readonly string cloudConnectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
        private readonly string localConnectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        private Chart salesTrendChart;

        private string activeConnectionString;
        private bool isInitializing = true;
        public SalesPOS()
        {
            InitializeComponent();



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
            calendardatepicker.Font = new System.Drawing.Font("Segoe UI", 19F, FontStyle.Regular);
            calendardatepicker.CalendarMonthBackground = Color.Maroon;
        }

        private (DateTime start, DateTime end) GetDateRangeFromPickers()
        {
            DateTime start = calendardatepicker.Value.Date;
            DateTime end = calendardatepicker2.Value.Date.AddDays(1); // include the full end day
            return (start, end);
        }

        private void LoadSalesMetrics()
        {
            decimal netSales = 0m;

            // Use new range pickers
            var range = GetDateRangeFromPickers();

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
            ISNULL(SUM(o.TotalAmount), 0) AS GrossRevenue,            
            ISNULL(SUM(o.TotalAmount - ISNULL(o.DiscountAmount,0)), 0) AS NetSales, 
            ISNULL(SUM(p.PaidAmount), 0) AS TotalPayments              
        FROM dbo.Orders o
        LEFT JOIN PaymentAgg p ON p.OrderID = o.OrderID
        WHERE o.Date >= @StartDate AND o.Date < @EndDate;
    ";

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
                            netSales = rdr.IsDBNull(4) ? 0m : rdr.GetDecimal(4);
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

            UpdateSalesUi(grossRevenue, totalSales, totalDiscount, totalOrders, averageOrderValue, netSales);
        }


        private void UpdateSalesUi(decimal grossRevenue, decimal totalSales, decimal totalDiscount, int totalOrders, decimal averageOrderValue, decimal netSales)
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
                salespostotalnetsalestxtdata.Text = "₱" + netSales.ToString("N2");
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

            RoundPanel(salesposaverageordervaluetxt, 25);
            RoundPanel(salespospanelcontents, 25);
            RoundPanel(salespostotalsalesdatapanel, 25);
            RoundPanel(salespostotalordersdatapanel, 25);
            RoundPanel(averageordervaluepanel, 25);
            RoundPanel(salesposgrossrevenuepanel, 25);
            RoundPanel(salesposdiscountappliedpanel, 25);
            RoundPanel(salespostotalsalespanel, 25);
            RoundButton(generatereportbtn, 19);

            averageordervaluepanel.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            salespospanelcontents.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            salespostotalsalesdatapanel.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            averageordervaluepanel.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            salesposgrossrevenuepanel.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            salesposdiscountappliedpanel.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            salespostotalsalespanel.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            salespostotalordersdatapanel.BackColor = ColorTranslator.FromHtml("#2f2f2f");

            generatereportbtn.UseVisualStyleBackColor = false;
            generatereportbtn.FlatStyle = FlatStyle.Flat;
            generatereportbtn.FlatAppearance.BorderSize = 0;
            generatereportbtn.BackColor = ColorTranslator.FromHtml("#2823B1");
            generatereportbtn.ForeColor = Color.White;


            EnsureUiDefaults();




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
                    BackColor = ColorTranslator.FromHtml("#2f2f2f"),
                    Dock = DockStyle.Fill
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

            ChartArea chartArea = new ChartArea("Main")
            {
                BackColor = ColorTranslator.FromHtml("#2f2f2f"),
                BorderColor = ColorTranslator.FromHtml("#555555"),
                BorderWidth = 1
            };

            // Configure X-axis
            chartArea.AxisX.Title = "Date";
            chartArea.AxisX.TitleForeColor = Color.White;
            chartArea.AxisX.TitleFont = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            chartArea.AxisX.LabelStyle.ForeColor = Color.White;
            chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            chartArea.AxisX.LabelStyle.Format = "MMM dd";
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisX.MajorTickMark.Enabled = true;
            chartArea.AxisX.MajorTickMark.LineColor = ColorTranslator.FromHtml("#666666");
            chartArea.AxisX.MinorTickMark.Enabled = false;
            chartArea.AxisX.LineColor = ColorTranslator.FromHtml("#666666");

            // Configure Y-axis
            chartArea.AxisY.Title = "Net Sales (₱)";
            chartArea.AxisY.TitleForeColor = Color.White;
            chartArea.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            chartArea.AxisY.LabelStyle.ForeColor = Color.White;
            chartArea.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            chartArea.AxisY.LabelStyle.Format = "₱#,0";
            chartArea.AxisY.IsStartedFromZero = true;
            chartArea.AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#444444");
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartArea.AxisY.MajorTickMark.Enabled = true;
            chartArea.AxisY.MajorTickMark.LineColor = ColorTranslator.FromHtml("#666666");
            chartArea.AxisY.MinorTickMark.Enabled = false;
            chartArea.AxisY.LineColor = ColorTranslator.FromHtml("#666666");

            chartArea.Position.X = 8;
            chartArea.Position.Y = 12;
            chartArea.Position.Width = 88;
            chartArea.Position.Height = 80;

            chartArea.InnerPlotPosition.X = 10;
            chartArea.InnerPlotPosition.Y = 2;
            chartArea.InnerPlotPosition.Width = 85;
            chartArea.InnerPlotPosition.Height = 90;

            salesTrendChart.ChartAreas.Add(chartArea);

            Legend legend = new Legend("Legend")
            {
                Docking = Docking.Top,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold)
            };
            salesTrendChart.Legends.Add(legend);

            // Title
            salesTrendChart.Titles.Add(new Title("Sales Trend")
            {
                ForeColor = Color.White,
                Font = new System.Drawing.Font("Segoe UI", 16F, FontStyle.Bold),
                Docking = Docking.Top
            });

            Series series = new Series("Net Sales")
            {
                ChartType = SeriesChartType.Column,
                Color = ColorTranslator.FromHtml("#5FBE6A"),
                IsValueShownAsLabel = true,
                LabelForeColor = Color.White,
                LabelFormat = "₱{0:N0}",
                Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold),
                XValueType = ChartValueType.DateTime,
                YValueType = ChartValueType.Double,
                ChartArea = "Main",
                Legend = "Legend",
                BorderColor = ColorTranslator.FromHtml("#4A9B55"),
                BorderWidth = 1
            };
            series.SmartLabelStyle.Enabled = true;
            series.ToolTip = "#VALX: ₱#VAL{N2}";
            series["PointWidth"] = "0.35";

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
                InitializeSalesTrendChart();

            var range = GetDateRangeFromPickers();
            string period = (salesposreporttype.SelectedItem as string) ?? "Daily";

            var chartArea = salesTrendChart.ChartAreas["Main"];
            ConfigureSalesXAxis(chartArea, period, range.start, range.end);

            DataTable dt = GetSalesTrendData(range.start, range.end, period);

            Series series = salesTrendChart.Series.IndexOf("Net Sales") >= 0
                ? salesTrendChart.Series["Net Sales"]
                : salesTrendChart.Series.Add("Net Sales");

            series.Points.Clear();
            series.XValueType = ChartValueType.DateTime;
            series.YValueType = ChartValueType.Double;

            foreach (DataRow row in dt.Rows)
            {
                DateTime date = Convert.ToDateTime(row["SalesDate"]);
                double sales = Convert.ToDouble(row["NetSales"]);
                series.Points.AddXY(date, sales);
            }

            if (series.Points.Count == 0)
                series.Points.AddXY(DateTime.Today, 0);

            chartArea.RecalculateAxesScale();
        }

        private void ConfigureSalesXAxis(ChartArea chartArea, string reportType, DateTime startDate, DateTime endDate)
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

            double padding = (endDate.ToOADate() - startDate.ToOADate()) * 0.05;
            chartArea.AxisX.Minimum = startDate.ToOADate() - padding;
            chartArea.AxisX.Maximum = endDate.ToOADate() + padding;
            chartArea.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;

            chartArea.AxisX.ScaleView.Zoomable = false;
            chartArea.AxisX.ScrollBar.IsPositionedInside = false;
        }

        private void generatereportbtn_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime currentDate = calendardatepicker.Value;
                string currentReportType = (salesposreporttype.SelectedItem as string) ?? "Daily";

                (DateTime start, DateTime end) = GetDateRangeFromPickers();

                DataTable dt = GetSalesTrendData(start, end, currentReportType);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No sales data available for the selected period.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF files (*.pdf)|*.pdf";
                    sfd.FileName = $"SalesReport_{currentReportType}_{DateTime.Now:yyyyMMdd}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                            doc.Open();

                            // Title
                            Paragraph title = new Paragraph($"Sales Report ({currentReportType})",
                                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD, BaseColor.BLACK))
                            { Alignment = Element.ALIGN_CENTER, SpacingAfter = 20f };
                            doc.Add(title);

                            // Date range
                            Paragraph dateRange = new Paragraph($"Period: {start:MMM dd, yyyy} - {end.AddDays(-1):MMM dd, yyyy}",
                                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK))
                            { Alignment = Element.ALIGN_CENTER, SpacingAfter = 20f };
                            doc.Add(dateRange);

                            // Chart image
                            if (salesTrendChart != null && salesTrendChart.Series.Count > 0)
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    salesTrendChart.SaveImage(ms, ChartImageFormat.Png);
                                    iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(ms.ToArray());
                                    chartImage.ScaleToFit(500f, 400f);
                                    chartImage.Alignment = Element.ALIGN_CENTER;
                                    chartImage.SpacingAfter = 20f;
                                    doc.Add(chartImage);
                                }
                            }

                            // Table
                            PdfPTable table = new PdfPTable(dt.Columns.Count) { WidthPercentage = 100 };
                            foreach (DataColumn column in dt.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD)))
                                { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER };
                                table.AddCell(cell);
                            }
                            foreach (DataRow row in dt.Rows)
                            {
                                foreach (var item in row.ItemArray)
                                {
                                    PdfPCell cell = new PdfPCell(new Phrase(item.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12)))
                                    { HorizontalAlignment = Element.ALIGN_CENTER };
                                    table.AddCell(cell);
                                }
                            }
                            doc.Add(table);

                            // Total sales
                            decimal totalSales = dt.AsEnumerable().Sum(r => Convert.ToDecimal(r["NetSales"]));
                            Paragraph total = new Paragraph($"\nTotal Sales: ₱{totalSales:N2}",
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
            if (isInitializing) return;
            LoadSalesMetrics();
            LoadSalesTrend();
        }
    }

}

