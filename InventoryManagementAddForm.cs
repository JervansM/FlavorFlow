using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlavorFlowIT13
{
    public partial class InventoryManagementAddForm : Form
    {
        public InventoryManagementAddForm()
        {
            InitializeComponent();
            LoadSuppliers();

        }

        private void panelFormHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuformsavebtn_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(inventorynametxt.Text))
            {
                MessageBox.Show("Item Name is required.");
                return;
            }

            if (!int.TryParse(inventoryormpquantitytxt.Text, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Quantity must be a valid number and cannot be negative.");
                return;
            }

            if (!int.TryParse(inventoryformminstocktxt.Text, out int minStock) || minStock < 0)
            {
                MessageBox.Show("Minimum stock must be a valid non-negative number.");
                return;
            }

            if (!decimal.TryParse(inventoryformcosttxt.Text, out decimal cost) || cost < 0)
            {
                MessageBox.Show("Cost must be a valid number ≥ 0.");
                return;
            }

            if (string.IsNullOrWhiteSpace(inventoryformunitbox.Text))
            {
                MessageBox.Show("Unit is required.");
                return;
            }

            if (inventoryformsupplertxt.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a supplier.");
                return;
            }
            int supplierId = Convert.ToInt32(inventoryformsupplertxt.SelectedValue);

            try
            {
                string connectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

                using (var conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
                {
                    conn.Open();
                    if (_inventoryId.HasValue)
                    {
                        // Update existing inventory item
                        string updateQuery = @"
                    UPDATE Inventory SET
                        ItemName = @ItemName,
                        Quantity = @Quantity,
                        Unit = @Unit,
                        Cost = @Cost,
                        ExpiryDate = @ExpiryDate,
                        SupplierID = @SupplierID,
                        IsAvailable = @IsAvailable,
                        MinStock = @MinStock,
                        UpdatedAt = GETDATE()
                    WHERE InventoryID = @InventoryID";

                        using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@ItemName", inventorynametxt.Text);
                            cmd.Parameters.AddWithValue("@Quantity", quantity);
                            cmd.Parameters.AddWithValue("@Unit", inventoryformunitbox.Text);
                            cmd.Parameters.AddWithValue("@Cost", cost);
                            cmd.Parameters.AddWithValue("@ExpiryDate", inventoryformdatepicker.Value);
                            cmd.Parameters.AddWithValue("@SupplierID", supplierId);
                            cmd.Parameters.AddWithValue("@IsAvailable", menuformstatuscheckbox.Checked);
                            cmd.Parameters.AddWithValue("@MinStock", minStock);
                            cmd.Parameters.AddWithValue("@InventoryID", _inventoryId.Value);

                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Inventory item updated successfully!");
                    }
                    else
                    {
                        // Insert new inventory item
                        string insertQuery = @"
                    INSERT INTO Inventory
                    (ItemName, Quantity, Unit, Cost, ExpiryDate, SupplierID, IsAvailable, MinStock, CreatedAt, UpdatedAt)
                    VALUES
                    (@ItemName, @Quantity, @Unit, @Cost, @ExpiryDate, @SupplierID, @IsAvailable, @MinStock, GETDATE(), GETDATE())";

                        using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@ItemName", inventorynametxt.Text);
                            cmd.Parameters.AddWithValue("@Quantity", quantity);
                            cmd.Parameters.AddWithValue("@Unit", inventoryformunitbox.Text);
                            cmd.Parameters.AddWithValue("@Cost", cost);
                            cmd.Parameters.AddWithValue("@ExpiryDate", inventoryformdatepicker.Value);
                            cmd.Parameters.AddWithValue("@SupplierID", supplierId);
                            cmd.Parameters.AddWithValue("@IsAvailable", menuformstatuscheckbox.Checked);
                            cmd.Parameters.AddWithValue("@MinStock", minStock);

                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Inventory item saved successfully!");
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving inventory: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private int? _inventoryId = null;

        public InventoryManagementAddForm(int inventoryId)
        {
            InitializeComponent();
            _inventoryId = inventoryId;
            LoadInventoryItem(inventoryId);
            LoadSuppliers();
        }

        private void LoadInventoryItem(int id)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT InventoryID, ItemName, Quantity, Unit, Cost, ExpiryDate, SupplierID, IsAvailable, MinStock
                FROM Inventory
                WHERE InventoryID = @InventoryID";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@InventoryID", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate fields
                                inventorynametxt.Text = reader["ItemName"].ToString();
                                inventoryormpquantitytxt.Text = reader["Quantity"].ToString();
                                inventoryformunitbox.Text = reader["Unit"].ToString();
                                inventoryformcosttxt.Text = reader["Cost"].ToString();
                                inventoryformdatepicker.Value = Convert.ToDateTime(reader["ExpiryDate"]);
                                inventoryformsupplertxt.SelectedValue = Convert.ToInt32(reader["SupplierID"]);
                                menuformstatuscheckbox.Checked = Convert.ToBoolean(reader["IsAvailable"]);
                                inventoryformminstocktxt.Text = reader["MinStock"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void menuformstatuscheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void inventorynametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void inventoryormpquantitytxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void inventoryformunitbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void inventoryformcosttxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void inventoryformdatepicker_ValueChanged(object sender, EventArgs e)
        {

        }
        private void LoadSuppliers()
        {
            string connectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
            using (var conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT SupplierID, Name FROM Supplier";
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    var dt = new DataTable();
                    dt.Load(reader);

                    inventoryformsupplertxt.DataSource = dt;
                    inventoryformsupplertxt.DisplayMember = "Name";     // what user sees
                    inventoryformsupplertxt.ValueMember = "SupplierID"; // actual value used in SQL
                    inventoryformsupplertxt.SelectedIndex = -1;

                }
            }
        }

        private void inventoryformsupplertxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = inventoryformsupplertxt.SelectedItem?.ToString() ?? "None";

        }

        private void inventoryformminstocktxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void inventoryformminstocklbl_Click(object sender, EventArgs e)
        {

        }

        private void InventoryManagementAddForm_Load(object sender, EventArgs e)
        {

        }
    }
}
