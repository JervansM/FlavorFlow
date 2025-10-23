using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;


namespace FlavorFlowIT13
{
    public partial class AdminDashboard : Form
    {
        private readonly string cloudConnectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
        private readonly string localConnectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        private string activeConnectionString;

        public AdminDashboard()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            activeConnectionString = GetAvailableConnection();

            if (!string.IsNullOrEmpty(activeConnectionString))
            {
                this.Text = $"Admin Dashboard - {(activeConnectionString == cloudConnectionString ? "Cloud" : "Local")} DB";
            }

            Refresh();

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
        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            this.Text = "Admin Dashboard";
            Refresh();

            dashaddate.Text = DateTime.Now.ToString("d");
            dashadtime.Text = DateTime.Now.ToString("t");








            RoundButton(dashbtn, 19);
            RoundButton(adsalesbtn, 19);
            RoundButton(adinventorybtn, 19);
            RoundButton(admenubtn, 19);
            RoundButton(adstaffbtn, 19);
            RoundButton(adfinancebtn, 19);
            RoundButton(adsystembtn, 19);
            RoundButton(adlogsbtn, 19);
            RoundButton(adsuppliersbtn, 19);
            RoundButton(adpurchaseordersbtn, 19);
            RoundPanel(panelTop, 30);
            RoundPanel(panelNav, 25);
            RoundPanel(panelContent, 25);
            RoundPanel(dashtotalsales, 25);
            RoundPanel(dashactive, 25);
            RoundPanel(dashnetprofit, 25);
            RoundPanel(dashinventorystatus, 25);
            RoundPanel(dashtotalexpense, 25);
            RoundPanel(dashinventoryusage, 25);
            RoundPanel(dashnotif, 25);
            RoundPanel(dashvisuals, 25);



            dashtotalsales.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            dashactive.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            dashnetprofit.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            dashinventorystatus.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            dashtotalexpense.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            dashinventoryusage.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            dashactive.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            dashnotif.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            dashvisuals.BackColor = ColorTranslator.FromHtml("#2f2f2f");





            dashbtn.UseVisualStyleBackColor = false;
            dashbtn.FlatStyle = FlatStyle.Flat;
            dashbtn.FlatAppearance.BorderSize = 0;
            dashbtn.ForeColor = ColorTranslator.FromHtml("#2f2f2f");





            adsalesbtn.UseVisualStyleBackColor = false;
            adsalesbtn.FlatStyle = FlatStyle.Flat;
            adsalesbtn.FlatAppearance.BorderSize = 0;
            adsalesbtn.ForeColor = ColorTranslator.FromHtml("#2f2f2f");


            adinventorybtn.UseVisualStyleBackColor = false;
            adinventorybtn.FlatStyle = FlatStyle.Flat;
            adinventorybtn.FlatAppearance.BorderSize = 0;
            adinventorybtn.ForeColor = ColorTranslator.FromHtml("#2f2f2f");


            admenubtn.UseVisualStyleBackColor = false;
            admenubtn.FlatStyle = FlatStyle.Flat;
            admenubtn.FlatAppearance.BorderSize = 0;
            admenubtn.ForeColor = ColorTranslator.FromHtml("#2f2f2f");


            adstaffbtn.UseVisualStyleBackColor = false;
            adstaffbtn.FlatStyle = FlatStyle.Flat;
            adstaffbtn.FlatAppearance.BorderSize = 0;
            adstaffbtn.ForeColor = ColorTranslator.FromHtml("#2f2f2f");

            adsuppliersbtn.UseVisualStyleBackColor = false;
            adsuppliersbtn.FlatStyle = FlatStyle.Flat;
            adsuppliersbtn.FlatAppearance.BorderSize = 0;
            adsuppliersbtn.ForeColor = ColorTranslator.FromHtml("#2f2f2f");

            adpurchaseordersbtn.UseVisualStyleBackColor = false;
            adpurchaseordersbtn.FlatStyle = FlatStyle.Flat;
            adpurchaseordersbtn.FlatAppearance.BorderSize = 0;
            adpurchaseordersbtn.ForeColor = ColorTranslator.FromHtml("#2f2f2f");





            adfinancebtn.UseVisualStyleBackColor = false;
            adfinancebtn.FlatStyle = FlatStyle.Flat;
            adfinancebtn.FlatAppearance.BorderSize = 0;
            adfinancebtn.ForeColor = ColorTranslator.FromHtml("#2f2f2f");


            adsystembtn.UseVisualStyleBackColor = false;
            adsystembtn.FlatStyle = FlatStyle.Flat;
            adsystembtn.FlatAppearance.BorderSize = 0;
            adsystembtn.ForeColor = ColorTranslator.FromHtml("#2f2f2f");


            adlogsbtn.UseVisualStyleBackColor = false;
            adlogsbtn.FlatStyle = FlatStyle.Flat;
            adlogsbtn.FlatAppearance.BorderSize = 0;
            adlogsbtn.ForeColor = ColorTranslator.FromHtml("#2f2f2f");




            LoadDashboardTotals();
            LoadTopSellingMenu();
        }
        private void SetActiveButton(Button activeButton)
        {
            foreach (Control ctrl in panelNav.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.Font = new Font("Segoe UI", 18, FontStyle.Regular);
                    btn.Padding = new Padding(0);
                    btn.ForeColor = ColorTranslator.FromHtml("#2f2f2f");
                    btn.BackColor = Color.Transparent;


                    btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
                    btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.UseVisualStyleBackColor = false;
                }
            }

            // HIGHLIGHT ACTIVE BUTTON
            activeButton.Font = new Font("Segoe UI", 18, FontStyle.Bold);
          
            activeButton.Padding = new Padding(0, 0, 0, 5);
            activeButton.ForeColor = ColorTranslator.FromHtml("#2f2f2f");

            activeButton.BackColor = Color.FromArgb(245, 245, 245);
        }

        private void RefreshIcon_Click(object sender, EventArgs e)
        {
            RefreshUI();
        }
        private void RefreshUI()
        {

            this.Hide();
            AdminDashboard newForm = new AdminDashboard();
            newForm.Show();
            this.Close();

        }


        private void adminicon_Click(object sender, EventArgs e)
        {

        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("DarkSlateGray");
            this.ForeColor = Color.White;

        }

        private void adlogoutbtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
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


        private void dashbtn_Click(object sender, EventArgs e)
        {
            SetActiveButton(dashbtn);
            LoadContent(new DashboardContentForm());

        }

        private void panelNav_Paint(object sender, PaintEventArgs e)
        {
            panelNav.BackColor = ColorTranslator.FromHtml("Silver");


        }

        private void adsalesbtn_Click(object sender, EventArgs e)
        {
            SetActiveButton(adsalesbtn);

            LoadContent(new SalesPOS());
        }

        private void adinventorybtn_Click(object sender, EventArgs e)
        {
            SetActiveButton(adinventorybtn);
            LoadContent(new InventoryManagement());
        }

        private void admenubtn_Click(object sender, EventArgs e)
        {
            SetActiveButton(admenubtn);
            LoadContent(new MenuManagement());
        }

        private void adstaffbtn_Click(object sender, EventArgs e)
        {
            SetActiveButton(adstaffbtn);
            LoadContent(new StaffManagement());
        }



        private void adfinancebtn_Click(object sender, EventArgs e)
        {
            SetActiveButton(adfinancebtn);
            LoadContent(new FinanceExpenses());
        }

        private void adsystembtn_Click(object sender, EventArgs e)
        {
            SetActiveButton(adsystembtn);
            LoadContent(new SystemSettings());
        }

        private void adlogsbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new AuditsLogsSecurity());
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

        private void userwelcome_Click(object sender, EventArgs e)
        {

        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashnetprofit_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashtotalsales_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashactive_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashnotif_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dashaddate_Click(object sender, EventArgs e)
        {

        }

        private void dashsalestxt_Click(object sender, EventArgs e)
        {

        }

        private void dashrefreshicon_Click(object sender, EventArgs e)
        {

        }

        private void dashadrefreshicon_Click(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void dashadtime_Click(object sender, EventArgs e)
        {

        }




        private bool isToggled = true;
        private void dashactiveon_Click_(object sender, EventArgs e)
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
                        @"SELECT ISNULL(SUM(TotalAmount - ISNULL(DiscountAmount, 0)), 0) 
      FROM dbo.Orders 
      WHERE Status = 'Completed' AND PaymentStatus = 'Paid'", conn)
                        .ExecuteScalar());

                    decimal totalSalesToday = Convert.ToDecimal(new SqlCommand(
                       @" SELECT 
            ISNULL(SUM(TotalAmount - ISNULL(DiscountAmount, 0)), 0) AS TotalSalesToday
        FROM dbo.Orders
        WHERE 
            Status = 'Completed'
            AND PaymentStatus = 'Paid'
            AND CAST([Date] AS DATE) = CAST(GETDATE() AS DATE);", conn)
                       .ExecuteScalar());



                    dashsalescontenttxt.Text = "₱" + totalSalesToday.ToString("N2");

                    // TOTAL EXPENSES
                    decimal totalExpenses = Convert.ToDecimal(new SqlCommand(
                        @"SELECT ISNULL(SUM(Amount),0) FROM dbo.Expenses", conn)
                        .ExecuteScalar());
                    totalexpensetxt.Text = "₱" + totalExpenses.ToString("N2");

               // NET PROFIT / LOSS CALCULATION
                    decimal netProfit = totalSales - totalExpenses;

                    // ✅ Change label + color based on profit/loss
                    if (netProfit < 0)
                    {
                        dashnetprofittxt.Text = "Net Loss Summary";
                        netprofittxt.ForeColor = Color.IndianRed;
                    }
                    else
                    {
                        dashnetprofittxt.Text = "Net Profit Summary";
                        netprofittxt.ForeColor = Color.DeepSkyBlue; // modern green
                    }

                    netprofittxt.Text = "₱" + Math.Abs(netProfit).ToString("N2");

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
                            totalordersmenu.Text = totalQty.ToString(); // 
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



        private void dashsalescontent_Click(object sender, EventArgs e)
        {



        }

        private void totalexpensetxt_Click(object sender, EventArgs e)
        {

        }

        private void netprofittxt_Click(object sender, EventArgs e)
        {

        }

        private void totalsalesmenu_Click(object sender, EventArgs e)
        {

        }

        private void totalordersmenu_Click(object sender, EventArgs e)
        {

        }

        private void topsellingmenupic_Click(object sender, EventArgs e)
        {

        }

        private void adsuppliersbtn_Click(object sender, EventArgs e)
        {
            SetActiveButton(adsuppliersbtn);
            LoadContent(new Suppliers());
        }

        private void adpurchaseordersbtn_Click(object sender, EventArgs e)
        {
            SetActiveButton(adpurchaseordersbtn);
            LoadContent(new Purchaseorders());

        }

       
    }
}


