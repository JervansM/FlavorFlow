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

namespace FlavorFlowIT13
{
    public partial class DashboardContentForm : Form
    {
        private readonly string cloudConnectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
        private readonly string localConnectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        private string activeConnectionString;
        public DashboardContentForm()
        {
            InitializeComponent();
            activeConnectionString = GetAvailableConnection();
            RoundPanel(panelContent, 25);
            RoundPanel(dashtotalsales, 25);
            RoundPanel(dashactive, 25);
            RoundPanel(dashnetprofit, 25);
            RoundPanel(dashinventorystatus, 25);
            RoundPanel(dashtotalexpense, 25);
            RoundPanel(dashinventoryusage, 25);
            RoundPanel(dashnotif, 25);
            RoundPanel(dashvisuals, 25);



            dashtotalsales.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            dashactive.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            dashnetprofit.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            dashinventorystatus.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            dashtotalexpense.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            dashinventoryusage.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            dashactive.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            dashnotif.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            dashvisuals.BackColor = ColorTranslator.FromHtml("#1e1e1e");
        }


        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashtotalsales_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadContent(Form form)
        {
            // Dispose old form(s) before clearing
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
        private bool isToggled = true;


        private void dashactiveon_Click(object sender, EventArgs e)
        {
            isToggled = !isToggled;
            dashactiveon.Image = isToggled
                ? Properties.Resources.toggleon_removebg_preview
                : Properties.Resources.toggleoff_removebg_preview;

            if (isToggled)
            {
                // toggle on

            }
            else
            {
                // toggle off

            }
        }

        private void panelContent_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void DashboardContentForm_Load(object sender, EventArgs e)
        {
            LoadDashboardTotals();
            LoadTopSellingMenu();
        }
        private string GetAvailableConnection()
        {
            if (TestConnection(cloudConnectionString))
                return cloudConnectionString;

            if (TestConnection(localConnectionString))
                return localConnectionString;

            MessageBox.Show("No available database connection.", "Database Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
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
                return false;
            }
        }
        private void LoadDashboardTotals()
        {
            if (string.IsNullOrWhiteSpace(activeConnectionString))
            {
                activeConnectionString = GetAvailableConnection();
                if (string.IsNullOrWhiteSpace(activeConnectionString)) return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(activeConnectionString))
                {
                    conn.Open();

                    // TOTAL SALES
                    decimal totalSales = Convert.ToDecimal(new SqlCommand(
                        @"SELECT ISNULL(SUM(TotalAmount),0) FROM dbo.Orders WHERE Status='Completed' AND PaymentStatus='Paid'", conn)
                        .ExecuteScalar());
                    dashsalescontenttxt.Text = "₱" + totalSales.ToString("N2");

                    // TOTAL EXPENSES
                    decimal totalExpenses = Convert.ToDecimal(new SqlCommand(
                        @"SELECT ISNULL(SUM(Amount),0) FROM dbo.Expenses", conn)
                        .ExecuteScalar());
                    totalexpensetxt.Text = "₱" + totalExpenses.ToString("N2");

                    // NET PROFIT
                    decimal netProfit = totalSales - totalExpenses;
                    netprofittxt.Text = "₱" + netProfit.ToString("N2");

                    // INVENTORY STATUS
                    decimal totalItems = Convert.ToDecimal(new SqlCommand(
                        "SELECT ISNULL(SUM(Quantity),0) FROM Inventory WHERE IsAvailable = 1", conn)
                        .ExecuteScalar());
                    int lowStockItems = Convert.ToInt32(new SqlCommand(
                        "SELECT COUNT(*) FROM Inventory WHERE Quantity <= MinStock AND IsAvailable = 1", conn)
                        .ExecuteScalar());
                    int outOfStockItems = Convert.ToInt32(new SqlCommand(
                        "SELECT COUNT(*) FROM Inventory WHERE Quantity = 0 AND IsAvailable = 1", conn)
                        .ExecuteScalar());

                    dashTotalItems_txt.Text = totalItems.ToString("N0");


                    // INVENTORY USAGE
                    decimal totalUsedThisMonth = Convert.ToDecimal(new SqlCommand(
                        @"SELECT ISNULL(SUM(QtyUsed),0) 
                  FROM InventoryUsage 
                  WHERE Date >= DATEADD(MONTH,-1,GETDATE())", conn)
                        .ExecuteScalar());
                    dashInventoryUsed_txt.Text = totalUsedThisMonth.ToString("N0");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard totals: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadTopSellingMenu()
        {
            if (string.IsNullOrWhiteSpace(activeConnectionString))
                activeConnectionString = GetAvailableConnection();

            try
            {
                using (SqlConnection conn = new SqlConnection(activeConnectionString))
                {
                    conn.Open();

                    string sql = @"
               SELECT TOP 1 
                 m.Name, 
                 m.ImagePath, 
                  SUM(od.Qty) AS TotalQuantity, 
                   SUM(od.Qty * od.Price) AS TotalSales
                     FROM OrderItems od
                     INNER JOIN Menu m ON od.MenuID = m.MenuID
                        INNER JOIN Orders o ON od.OrderID = o.OrderID
                         WHERE o.Status = 'Completed' AND o.PaymentStatus = 'Paid'
                      GROUP BY m.Name, m.ImagePath
                     ORDER BY SUM(od.Qty) DESC";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string menuName = reader["Name"].ToString();
                            string imgPath = reader["ImagePath"].ToString();
                            int totalQty = Convert.ToInt32(reader["TotalQuantity"]);   // ✅ use new alias
                            decimal totalSales = Convert.ToDecimal(reader["TotalSales"]);

                            if (!string.IsNullOrEmpty(imgPath) && System.IO.File.Exists(imgPath))
                            {
                                topsellingmenupic.Image = Image.FromFile(imgPath);
                                topsellingmenupic.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                            else
                            {
                                topsellingmenupic.Image = Properties.Resources.lasagna;
                                topsellingmenupic.SizeMode = PictureBoxSizeMode.StretchImage;
                            }

                            totalsalesmenu.Text = "₱" + totalSales.ToString("N2");
                            totalordersmenu.Text = totalQty.ToString(); // 🔑 now shows quantity ordered
                        }
                    
                        else
                        {
                            // No menu found
                            topsellingmenupic.Image = Properties.Resources.lasagna;
                            totalsalesmenu.Text = "₱0.00";
                            totalordersmenu.Text = "0";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading top-selling menu: " + ex.Message);
            }
        }

        private void totalsalesmenu_Click(object sender, EventArgs e)
        {

        }

        private void totalordersmenu_Click(object sender, EventArgs e)
        {

        }
    }
}

