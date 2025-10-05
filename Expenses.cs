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
using Microsoft.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace FlavorFlowIT13
{
    public partial class Expenses : Form
    {
        private Chart expensesChart;
        private string cloudConnectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
        private string localConnectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        private DateTime currentDate;
        private string currentReportType = "Daily";
        private string activeConnectionString;

        public Expenses()
        {
            InitializeComponent();
            activeConnectionString = GetAvailableConnection();

            currentDate = DateTime.Today;
            currentReportType = "Daily";

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
        private void InitializeExpensesChart()
        {
            if (expensesChart == null)
            {
                expensesChart = new Chart { Dock = DockStyle.Fill, BackColor = ColorTranslator.FromHtml("#2f2f2f") };
                financeexpensespanel.Controls.Clear();
                financeexpensespanel.Controls.Add(expensesChart);
            }

            expensesChart.Series.Clear();
            expensesChart.ChartAreas.Clear();
            expensesChart.Titles.Clear();
            expensesChart.Legends.Clear();

            // Smooth rendering
            expensesChart.AntiAliasing = AntiAliasingStyles.All;
            expensesChart.TextAntiAliasingQuality = TextAntiAliasingQuality.High;

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
            area.AxisY.Title = "Expenses (₱)";
            area.AxisY.TitleForeColor = Color.White;
            area.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            area.AxisY.LabelStyle.ForeColor = Color.White;
            area.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
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

            expensesChart.ChartAreas.Add(area);

            Legend legend = new Legend("Legend")
            {
                Docking = Docking.Top,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold)
            };
            expensesChart.Legends.Add(legend);

            Series series = new Series("Expenses")
            {
                ChartType = SeriesChartType.Column,
                Color = ColorTranslator.FromHtml("IndianRed"),
                IsValueShownAsLabel = true,
                LabelForeColor = Color.White,
                LabelFormat = "₱{0:N0}",
                Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold),
                XValueType = ChartValueType.DateTime,
                YValueType = ChartValueType.Double,
                ChartArea = "Main",
                Legend = "Legend",
                BorderColor = ColorTranslator.FromHtml("IndianRed"),
                BorderWidth = 1
            };
            series.SmartLabelStyle.Enabled = true;
            series.ToolTip = "#VALX: ₱#VAL{N2}";
            expensesChart.Series.Add(series);

            expensesChart.Titles.Add(new Title("Expenses Trend")
            {
                ForeColor = Color.White,
                Font = new System.Drawing.Font("Segoe UI", 16F, FontStyle.Bold),
                Docking = Docking.Top
            });
        }
        private DataTable GetExpensesData(DateTime startDate, DateTime endDate)
        {
            DataTable dt = new DataTable();
            string sql = @"
                SELECT CAST(Date AS DATE) AS ExpenseDate, SUM(Amount) AS TotalExpense
                FROM dbo.Expenses
                WHERE Date >= @StartDate AND Date < @EndDate
                GROUP BY CAST(Date AS DATE)
                ORDER BY ExpenseDate";

            try
            {
                using SqlConnection conn = new SqlConnection(activeConnectionString);
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading expenses: " + ex.Message);
            }

            return dt;
        }

        private void LoadExpensesTrend(string reportType, DateTime selectedDate)
        {
            if (expensesChart == null) return;

            var chartArea = expensesChart.ChartAreas["Main"];
            var series = expensesChart.Series["Expenses"];
            if (chartArea == null || series == null) return;

            // Calculate start/end based on report type
            (DateTime start, DateTime end) = GetDateRange(selectedDate, reportType);

            // Configure X-axis based on report type
            ConfigureXAxis(chartArea, reportType, start, end);

            DataTable dt = GetExpensesData(start, end);
            series.Points.Clear();

            foreach (DataRow row in dt.Rows)
            {
                if (DateTime.TryParse(row["ExpenseDate"]?.ToString(), out DateTime date) &&
                    double.TryParse(row["TotalExpense"]?.ToString(), out double amount))
                {
                    series.Points.AddXY(date, amount);
                }
            }

            if (series.Points.Count == 0)
                series.Points.AddXY(DateTime.Today, 0);
        }

        private void ConfigureXAxis(ChartArea chartArea, string reportType, DateTime startDate, DateTime endDate)
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
        private (DateTime start, DateTime end) GetDateRange(DateTime anchorDate, string period)
        {
            switch (period)
            {
                case "Daily":
                    return (anchorDate.Date, anchorDate.Date.AddDays(1));
                case "Weekly":
                    int diff = (7 + (int)anchorDate.DayOfWeek - (int)DayOfWeek.Monday) % 7;
                    DateTime weekStart = anchorDate.AddDays(-diff).Date;
                    return (weekStart, weekStart.AddDays(7));
                case "Monthly":
                    DateTime yearStart = new DateTime(anchorDate.Year, 1, 1);  // Start of the year
                    return (yearStart, yearStart.AddYears(1));                 // End of the year
                case "Yearly":
                    DateTime yearStart1 = new DateTime(anchorDate.Year, 1, 1);
                    return (yearStart1, yearStart1.AddYears(1));
                default:
                    return (anchorDate.Date, anchorDate.Date.AddDays(1));
            }
        }
        private void expensesposreporttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentReportType = expensesposreporttype.SelectedItem?.ToString() ?? "Daily";
            LoadExpensesTrend(currentReportType, currentDate);
            UpdateTotalExpense(sender, e);
        }

        private void calendardatepicker_ValueChanged(object sender, EventArgs e)
        {
            currentDate = calendardatepicker.Value;
            LoadExpensesTrend(currentReportType, currentDate);
            UpdateTotalExpense(sender, e);
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void systempanelcontents_Paint(object sender, PaintEventArgs e)
        {

        }

        private void netprofitbtn_Click(object sender, EventArgs e)
        {

        }

        private void netsalessumbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new FinanceExpenses());
        }

        private void Expenses_Load(object sender, EventArgs e)
        {
            RoundButton(netsalessumbtn, 20);
            RoundButton(expensereportsbtn, 20);
            RoundButton(netprofitsummarybtn, 20);
            RoundPanel(panelContent, 25);
            RoundPanel(financeexpensespanel, 25);
            RoundPanel(totalexpensepanel, 25);
            RoundButton(generatereportbtn, 20);

            generatereportbtn.UseVisualStyleBackColor = false;
            generatereportbtn.FlatStyle = FlatStyle.Flat;
            generatereportbtn.FlatAppearance.BorderSize = 0;
            generatereportbtn.BackColor = ColorTranslator.FromHtml("#2823B1");
            generatereportbtn.ForeColor = Color.White;


            // Set default report type to Daily
            if (expensesposreporttype.Items.Count == 0)
            {
                expensesposreporttype.Items.AddRange(new object[] { "Daily", "Weekly", "Monthly", "Yearly" });
            }
            expensesposreporttype.SelectedIndex = 0; // Set to Daily (first item)
            currentReportType = "Daily";

            // Set date to today
            calendardatepicker.Value = DateTime.Today;
            currentDate = DateTime.Today;

            InitializeExpensesChart();
            LoadExpensesTrend(currentReportType, currentDate);

            financeexpensespanel.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            totalexpensepanel.BackColor = ColorTranslator.FromHtml("#2f2f2f");

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
            expensereportsbtn.BackColor = ColorTranslator.FromHtml("#6C6868");
            expensereportsbtn.ForeColor = Color.White;
            expensereportsbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#6C6868");
            expensereportsbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            netprofitsummarybtn.UseVisualStyleBackColor = false;
            netprofitsummarybtn.FlatStyle = FlatStyle.Flat;
            netprofitsummarybtn.FlatAppearance.BorderSize = 0;
            netprofitsummarybtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            netprofitsummarybtn.ForeColor = Color.White;
            netprofitsummarybtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#6C6868");
            netprofitsummarybtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            UpdateTotalExpense(this, EventArgs.Empty);

        }

        private void financeexpensespanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void expensereportsbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new Expenses());
            InitializeExpensesChart();
            LoadExpensesTrend(currentReportType, currentDate);

        }

        private void expensesdata_Click(object sender, EventArgs e)
        {

        }

        private void netprofitsummarybtn_Click(object sender, EventArgs e)
        {
            LoadContent(new NetProfit());
        }

        private void salespostotalsalespanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void totalexpensetxt_Click(object sender, EventArgs e)
        {

        }

        private void UpdateTotalExpense(object sender, EventArgs e)
        {
            try
            {
                // Get the selected date range
                DateTime start, end;
                (start, end) = GetDateRange(currentDate, currentReportType);

                decimal totalExpense = 0;

                using (SqlConnection con = new SqlConnection(activeConnectionString))
                {
                    con.Open();
                    string query = @"
                SELECT ISNULL(SUM(Amount), 0) AS TotalExpense
                FROM Expenses
                WHERE Date >= @StartDate AND Date <= @EndDate";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", start);
                        cmd.Parameters.AddWithValue("@EndDate", end);
                        object result = cmd.ExecuteScalar();
                        totalExpense = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }

                totalexpensetxt.Text = $"₱{totalExpense:N2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating total expense: {ex.Message}",
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void generatereportbtn_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime currentDate = calendardatepicker.Value;
                string currentReportType = (expensesposreporttype.SelectedItem as string) ?? "Daily";

                // Get date range
                (DateTime start, DateTime end) = GetDateRange(currentDate, currentReportType);

                // Get expense trend data
                DataTable dt = GetExpensesData(start, end);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No expense data available for the selected period.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF files (*.pdf)|*.pdf";
                    sfd.FileName = $"ExpenseReport_{currentReportType}_{DateTime.Now:yyyyMMdd}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                            doc.Open();

                            // Title
                            Paragraph title = new Paragraph($"Expense Report ({currentReportType})",
                                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD, BaseColor.BLACK))
                            { Alignment = Element.ALIGN_CENTER, SpacingAfter = 20f };
                            doc.Add(title);

                            // Date range
                            Paragraph dateRange = new Paragraph($"Period: {start:MMM dd, yyyy} - {end.AddDays(-1):MMM dd, yyyy}",
                                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK))
                            { Alignment = Element.ALIGN_CENTER, SpacingAfter = 20f };
                            doc.Add(dateRange);

                            // Chart image
                            if (expensesChart != null && expensesChart.Series.Count > 0)
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    expensesChart.SaveImage(ms, ChartImageFormat.Png);
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
                                PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName,
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD)))
                                { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER };
                                table.AddCell(cell);
                            }
                            foreach (DataRow row in dt.Rows)
                            {
                                foreach (var item in row.ItemArray)
                                {
                                    PdfPCell cell = new PdfPCell(new Phrase(item.ToString(),
                                        new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12)))
                                    { HorizontalAlignment = Element.ALIGN_CENTER };
                                    table.AddCell(cell);
                                }
                            }
                            doc.Add(table);

                            // Total expenses
                            decimal totalExpenses = dt.AsEnumerable().Sum(r => Convert.ToDecimal(r["TotalExpense"]));
                            Paragraph total = new Paragraph($"\nTotal Expenses: ₱{totalExpenses:N2}",
                                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK))
                            { Alignment = Element.ALIGN_RIGHT };
                            doc.Add(total);

                            doc.Close();
                            writer.Close();
                        }

                        MessageBox.Show("PDF expense report generated successfully!", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating PDF report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
    }
}