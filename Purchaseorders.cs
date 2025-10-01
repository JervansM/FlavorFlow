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
using System.Globalization;


namespace FlavorFlowIT13
{
    public partial class Purchaseorders : Form
    {
        private readonly string cloudConnectionString =
            "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        private readonly string localConnectionString =
            "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        private string activeConnectionString;

        public Purchaseorders()
        {
            InitializeComponent();
            RoundPanel(panelContent, 25);
            RoundPanel(supplierpanelcontents, 25);
            RoundButton(createneworderbtn, 20);
            RoundButton(viewpendingbtn, 20);
            RoundPanel(systemsearchbarpanel, 25);
            RoundButton(paybtn, 20);
            RoundButton(viewordersbtn, 20);

            activeConnectionString = GetAvailableConnection();
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


        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Purchaseorders_Load(object sender, EventArgs e)
        {
            createneworderbtn.UseVisualStyleBackColor = false;
            createneworderbtn.FlatStyle = FlatStyle.Flat;
            createneworderbtn.FlatAppearance.BorderSize = 0;
            createneworderbtn.BackColor = ColorTranslator.FromHtml("#5CC536");
            createneworderbtn.ForeColor = Color.White;
            createneworderbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#51A135");
            createneworderbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#51A135");

            viewpendingbtn.UseVisualStyleBackColor = false;
            viewpendingbtn.FlatStyle = FlatStyle.Flat;
            viewpendingbtn.FlatAppearance.BorderSize = 0;
            viewpendingbtn.BackColor = ColorTranslator.FromHtml("#E49629");
            viewpendingbtn.ForeColor = Color.White;
            viewpendingbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#A86F1F");
            viewpendingbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#A86F1F");



            paybtn.UseVisualStyleBackColor = false;
            paybtn.FlatStyle = FlatStyle.Flat;
            paybtn.FlatAppearance.BorderSize = 0;
            paybtn.BackColor = ColorTranslator.FromHtml("#2823B1");
            paybtn.ForeColor = Color.White;
            paybtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#312E94");
            paybtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#312E94");

            viewordersbtn.UseVisualStyleBackColor = false;
            viewordersbtn.FlatStyle = FlatStyle.Flat;
            viewordersbtn.FlatAppearance.BorderSize = 0;
            viewordersbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            viewordersbtn.ForeColor = Color.White;
            viewordersbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            viewordersbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            LoadPurchaseOrders();
            LoadPurchaseOrder();


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

        private void createneworderbtn_Click(object sender, EventArgs e)
        {
            SupplierCreateOrder createorder = new SupplierCreateOrder();
            createorder.Show();
            LoadPurchaseOrders();
        }

        private void viewpendingbtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(activeConnectionString))
            {
                string query = "SELECT PurchaseOrderID, SupplierID, OrderDate, Status, TotalAmount " +
                               "FROM PurchaseOrder WHERE Status = 'Pending'";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                supplierdatagrid.DataSource = dt;
            }
        }

        private void receivedordersbtn_Click(object sender, EventArgs e)
        {

        }

        private void supplierpanelcontents_Paint(object sender, PaintEventArgs e)
        {

        }

        private void supplierdataflowpanel_Paint(object sender, PaintEventArgs e)
        {

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

        private void supplierdatagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadPurchaseOrders()
        {
            StyleUserGrid();
            string sql = @"
        SELECT 
            po.PurchaseOrderID,
            s.Name,
            po.OrderDate,
       
            poi.Quantity,
            poi.UnitCost,
            (poi.Quantity * poi.UnitCost) AS TotalCost,
            po.Status
        FROM PurchaseOrder po
        INNER JOIN PurchaseOrderItem poi ON po.PurchaseOrderID = poi.PurchaseOrderID
        INNER JOIN Supplier s ON po.SupplierID = s.SupplierID
        ORDER BY po.OrderDate DESC";

            try
            {
                using (var conn = new SqlConnection(activeConnectionString))
                using (var cmd = new SqlCommand(sql, conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    supplierdatagrid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading purchase orders: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void StyleUserGrid()
        {
            supplierdatagrid.EnableHeadersVisualStyles = false;
            supplierdatagrid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            supplierdatagrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            supplierdatagrid.DefaultCellStyle.BackColor = Color.White;
            supplierdatagrid.DefaultCellStyle.ForeColor = Color.Black;
            supplierdatagrid.DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            supplierdatagrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            supplierdatagrid.RowHeadersVisible = false;
            supplierdatagrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            supplierdatagrid.MultiSelect = false;
            supplierdatagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            supplierdatagrid.BorderStyle = BorderStyle.FixedSingle;
            supplierdatagrid.GridColor = Color.LightGray;
            supplierdatagrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            supplierdatagrid.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            supplierdatagrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            supplierdatagrid.BackgroundColor = Color.WhiteSmoke;
        }

        private void paybtn_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Ask for PurchaseOrderID
                string input = Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter Purchase Order ID to pay:",
                    "Pay Purchase Order",
                    ""
                );

                if (string.IsNullOrEmpty(input)) return; // user cancelled
                if (!int.TryParse(input, out int purchaseOrderId))
                {
                    MessageBox.Show("Invalid Purchase Order ID.");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(activeConnectionString))
                {
                    conn.Open();

                    // 2. Check if PurchaseOrder exists & unpaid
                    string checkOrder = @"SELECT TotalAmount, Status 
                                  FROM PurchaseOrder
                                  WHERE PurchaseOrderID = @PurchaseOrderID";
                    decimal totalAmount = 0;
                    string status = "";

                    using (SqlCommand cmd = new SqlCommand(checkOrder, conn))
                    {
                        cmd.Parameters.AddWithValue("@PurchaseOrderID", purchaseOrderId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show("Purchase Order not found!");
                                return;
                            }

                            totalAmount = reader.GetDecimal(0);
                            status = reader.GetString(1);
                        }
                    }

                    if (status == "Paid")
                    {
                        MessageBox.Show("This Purchase Order is already paid.");
                        return;
                    }
                    CultureInfo ph = new CultureInfo("en-PH");

                    // 3. Confirm payment
                    DialogResult confirm = MessageBox.Show(
                        $"Purchase Order #{purchaseOrderId}\nAmount: {totalAmount.ToString("C2", ph)}\n\nConfirm payment?",
                        "Confirm Payment",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (confirm != DialogResult.Yes) return;

                    // 4. Update PurchaseOrders as Paid
                    string updateOrder = @"UPDATE PurchaseOrder
                                   SET Status = 'Paid', UpdatedAt = GETDATE()
                                   WHERE PurchaseOrderID = @PurchaseOrderID";
                    using (SqlCommand cmdUpdate = new SqlCommand(updateOrder, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@PurchaseOrderID", purchaseOrderId);
                        cmdUpdate.Parameters.AddWithValue("@Date", DateTime.Now);

                        cmdUpdate.ExecuteNonQuery();
                    }

                    // 5. Insert into Expenses
                    string insertExpense = @"INSERT INTO Expenses (Category, Amount, Date, Notes)
                         VALUES (@Category, @Amount, @Date, @Notes)";
                    using (SqlCommand cmdExpense = new SqlCommand(insertExpense, conn))
                    {
                        cmdExpense.Parameters.AddWithValue("@Category", "Purchase Order Payment");
                        cmdExpense.Parameters.AddWithValue("@Amount", totalAmount);
                        cmdExpense.Parameters.AddWithValue("@Notes", "Payment for Purchase Order #" + purchaseOrderId);
                        cmdExpense.Parameters.AddWithValue("@Date", DateTime.Now);
                        cmdExpense.ExecuteNonQuery();
                    }

                    MessageBox.Show("Payment successful! Expense recorded.",
                                    "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    LoadPurchaseOrder();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void LoadPurchaseOrder()
        {
            using (SqlConnection conn = new SqlConnection(activeConnectionString))
            {
                string query = "SELECT PurchaseOrderID, SupplierID, OrderDate, Status, TotalAmount FROM PurchaseOrder";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                supplierdatagrid.DataSource = dt;
            }
        }

        private void viewordersbtn_Click(object sender, EventArgs e)
        {
            LoadPurchaseOrders();
        }
    }

}
