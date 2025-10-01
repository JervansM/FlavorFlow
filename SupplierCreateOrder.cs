using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlavorFlowIT13
{
    public partial class SupplierCreateOrder : Form
    {
        private readonly string cloudConnectionString =
         "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        private readonly string localConnectionString =
            "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        private string activeConnectionString;
        public SupplierCreateOrder()
        {
            InitializeComponent();

            activeConnectionString = GetAvailableConnection();
        }

        private void SupplierCreateOrder_Load(object sender, EventArgs e)
        {
            RoundButton(supplierorderbtn, 19);
            RoundButton(closebtn, 19);

            supplierorderbtn.UseVisualStyleBackColor = false;
            supplierorderbtn.FlatStyle = FlatStyle.Flat;
            supplierorderbtn.FlatAppearance.BorderSize = 0;
            supplierorderbtn.BackColor = ColorTranslator.FromHtml("#5CC536");
            supplierorderbtn.ForeColor = Color.White;


            closebtn.UseVisualStyleBackColor = false;
            closebtn.FlatStyle = FlatStyle.Flat;
            closebtn.FlatAppearance.BorderSize = 0;
            closebtn.BackColor = ColorTranslator.FromHtml("Silver");
            closebtn.ForeColor = Color.White;

            supplierquantitytxt.Text = "1";
            LoadSuppliers();
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
        private void LoadSuppliers()
        {
            using (SqlConnection con = new SqlConnection(activeConnectionString))
            {
                con.Open();
                string query = "SELECT SupplierID, Name FROM Supplier";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                supplierselecttxt.DataSource = dt;
                supplierselecttxt.DisplayMember = "Name";
                supplierselecttxt.ValueMember = "SupplierID";
            }
        }

        private void LoadItems()
        {
            using (SqlConnection con = new SqlConnection(activeConnectionString))
            {
                con.Open();
                string query = "SELECT InventoryID, ItemName, Cost FROM Inventory";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                itemselecttxt.DataSource = dt;
                itemselecttxt.DisplayMember = "ItemName";
                itemselecttxt.ValueMember = "InventoryID";

                // Save the full table so we can look up UnitPrice
                itemselecttxt.Tag = dt;
            }
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

        private void supplierselecttxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (supplierselecttxt.SelectedValue != null
        && int.TryParse(supplierselecttxt.SelectedValue.ToString(), out int supplierId))
            {
                LoadItemsForSupplier(supplierId);
            }
        }

        private void itemselecttxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemselecttxt.SelectedValue != null && itemselecttxt.Tag is DataTable dt)
            {
                DataRow[] rows = dt.Select("InventoryID = " + itemselecttxt.SelectedValue);
                if (rows.Length > 0)
                {
                    decimal price = Convert.ToDecimal(rows[0]["Cost"]);

                    // ✅ Show unit price in suppliercosttxt
                    suppliercosttxt.Text = price.ToString("0.00");

                    // ✅ Recalculate line total
                    CalculateLineTotal();
                }
            }
        }

        private void CalculateLineTotal()
        {
            if (decimal.TryParse(suppliercosttxt.Text, out decimal unitPrice) &&
        decimal.TryParse(supplierquantitytxt.Text, out decimal qty))
            {
                decimal lineTotal = qty * unitPrice;
                supplierbillamounttxt.Text = lineTotal.ToString("0.00");
            }
            else
            {
                supplierbillamounttxt.Text = "0.00";
            }
        }
        private void LoadItemsForSupplier(int supplierId)
        {
            using (SqlConnection con = new SqlConnection(activeConnectionString))
            {
                con.Open();
                string query = @"SELECT InventoryID, ItemName, Cost 
                         FROM Inventory 
                         WHERE SupplierID = @SupplierID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SupplierID", supplierId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                itemselecttxt.DataSource = dt;
                itemselecttxt.DisplayMember = "ItemName";
                itemselecttxt.ValueMember = "InventoryID";
                itemselecttxt.Tag = dt;
            }
        }

        private void supplierquantitytxt_TextChanged(object sender, EventArgs e)
        {
            CalculateLineTotal();
        }

        private void supplierbillamounttxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void supplierorderbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (supplierselecttxt.SelectedValue == null || itemselecttxt.SelectedValue == null)
                {
                    MessageBox.Show("Please select a supplier and an item.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(supplierquantitytxt.Text, out int qty) || qty <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(suppliercosttxt.Text, out decimal unitCost))
                {
                    MessageBox.Show("Invalid unit cost.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(supplierbillamounttxt.Text, out decimal totalCost))
                {
                    MessageBox.Show("Invalid total amount.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int supplierId = Convert.ToInt32(supplierselecttxt.SelectedValue);
                int itemId = Convert.ToInt32(itemselecttxt.SelectedValue);

                using (SqlConnection con = new SqlConnection(activeConnectionString))
                {
                    con.Open();
                    SqlTransaction transaction = con.BeginTransaction();

                    try
                    {
                        //  PURCHASEORDER
                        string insertOrderQuery = @"
                    INSERT INTO PurchaseOrder (SupplierID, OrderDate, Status, TotalAmount, CreatedAt)
                    OUTPUT INSERTED.PurchaseOrderID
                    VALUES (@SupplierID, @OrderDate, @Status, @TotalAmount, @CreatedAt);";

                        int purchaseOrderId;

                        using (SqlCommand cmd = new SqlCommand(insertOrderQuery, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@SupplierID", supplierId);
                            cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@Status", "Pending");  // default
                            cmd.Parameters.AddWithValue("@TotalAmount", totalCost);
                            cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                            purchaseOrderId = (int)cmd.ExecuteScalar();
                        }
                        //PURCHASEEORDERITEMS
                        string insertItemQuery = @"
                    INSERT INTO PurchaseOrderItem (PurchaseOrderID, ItemID, Quantity, UnitCost)
                    VALUES (@PurchaseOrderID, @ItemID, @Quantity, @UnitCost);";

                        using (SqlCommand cmd = new SqlCommand(insertItemQuery, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@PurchaseOrderID", purchaseOrderId);
                            cmd.Parameters.AddWithValue("@ItemID", itemId);
                            cmd.Parameters.AddWithValue("@Quantity", qty);
                            cmd.Parameters.AddWithValue("@UnitCost", unitCost);

                            cmd.ExecuteNonQuery();
                        }
                        //UPDATESTOCKS
                        string updateInventoryQuery = @"
                    UPDATE Inventory
                    SET Quantity = ISNULL(Quantity, 0) + @AddedQty
                    WHERE InventoryID = @ItemID;";

                        using (SqlCommand cmd = new SqlCommand(updateInventoryQuery, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@AddedQty", qty);
                            cmd.Parameters.AddWithValue("@ItemID", itemId);

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        MessageBox.Show("Purchase order saved and inventory updated!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reset fields
                        supplierquantitytxt.Text = "1";
                        suppliercosttxt.Text = "0.00";
                        supplierbillamounttxt.Text = "0.00";
                    }
                    catch (Exception ex2)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error saving order: " + ex2.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void suppliercosttxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
