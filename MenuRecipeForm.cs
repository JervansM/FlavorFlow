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
    public partial class MenuRecipeForm : Form
    {
        private int? _editMenuInventoryId = null;
        private int? _editMenuId = null;
        private int? _editInventoryId = null;

        public MenuRecipeForm()
        {
            InitializeComponent();
        }

        private void menunamelbl_Click(object sender, EventArgs e)
        {

        }

        private void panelFormHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuRecipeForm_Load(object sender, EventArgs e)
        {
            LoadMenus();
            LoadInventoryItems();
            LoadUnits();
            LoadAllRecipes();

        }

        private void LoadMenus()
        {
            string connectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT MenuID, Name FROM Menu";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                menuitemsdata.DataSource = dt;
                menuitemsdata.DisplayMember = "Name";
                menuitemsdata.ValueMember = "MenuID";
            }
        }
        private void LoadInventoryItems()
        {
            string connectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT InventoryID, ItemName FROM Inventory";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                inventoryitemdata.DataSource = dt;
                inventoryitemdata.DisplayMember = "ItemName";
                inventoryitemdata.ValueMember = "InventoryID";
            }
        }
        private void LoadUnits()
        {
            manageunitrecipetxt.Items.Clear();
            manageunitrecipetxt.Items.Add("pcs");
            manageunitrecipetxt.Items.Add("kg");
            manageunitrecipetxt.Items.Add("grams");
            manageunitrecipetxt.Items.Add("liters");
        }


        private void menuitemsdata_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (menuitemsdata.SelectedValue != null && menuitemsdata.SelectedValue is int)
            {
                int menuId = (int)menuitemsdata.SelectedValue;
                LoadRecipe(menuId);
            }
        }
        private void LoadAllRecipes()
        {
            string connectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = @"SELECT m.Name AS MenuName, i.ItemName, mi.QuantityUsed, mi.Unit, mi.CreatedAt
                         FROM MenuInventory mi
                         INNER JOIN Inventory i ON mi.InventoryID = i.InventoryID
                         INNER JOIN Menu m ON mi.MenuID = m.MenuID
                         ORDER BY m.Name"; 

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                recipeGrid.DataSource = dt;
                StyleRecipeGrid();
            }
        }
    
        private void LoadRecipe(int menuId)
        {
            string connectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT mi.MenuInventoryID, i.ItemName, mi.QuantityUsed, mi.Unit
            FROM MenuInventory mi
            INNER JOIN Inventory i ON mi.InventoryID = i.InventoryID
            WHERE mi.MenuID = @MenuID";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MenuID", menuId);
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        recipeGrid.DataSource = dt;
                        StyleRecipeGrid();
                    }
                }
            }
        }


        private void inventoryitemdata_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void manageunitrecipetxt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void quantitydata_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuformsavebtn_Click(object sender, EventArgs e)
        {
            if (menuitemsdata.SelectedValue == null || inventoryitemdata.SelectedValue == null)
            {
                MessageBox.Show("Please select both a menu and an ingredient.");
                return;
            }

            int menuId = Convert.ToInt32(menuitemsdata.SelectedValue);
            int inventoryId = Convert.ToInt32(inventoryitemdata.SelectedValue);
            decimal qty = Convert.ToDecimal(quantitydata.Text);
            string unit = manageunitrecipetxt.Text;

            string connectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (_editMenuInventoryId.HasValue)
                {
                    // Update existing recipe
                    string updateQuery = @"
                UPDATE MenuInventory
                SET QuantityUsed = @Qty, Unit = @Unit, UpdatedAt = GETDATE(), InventoryID = @InventoryID
                WHERE MenuInventoryID = @MenuInventoryID";
                    using (var cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Qty", qty);
                        cmd.Parameters.AddWithValue("@Unit", unit);
                        cmd.Parameters.AddWithValue("@InventoryID", inventoryId);
                        cmd.Parameters.AddWithValue("@MenuInventoryID", _editMenuInventoryId.Value);
                        cmd.ExecuteNonQuery();
                    }
                    _editMenuInventoryId = null;
                    _editInventoryId = null;
                }
                else
                {
                    // Insert new recipe
                    string insertQuery = @"
                INSERT INTO MenuInventory (MenuID, InventoryID, QuantityUsed, Unit, CreatedAt, UpdatedAt)
                VALUES (@MenuID, @InventoryID, @Qty, @Unit, GETDATE(), GETDATE())";
                    using (var cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MenuID", menuId);
                        cmd.Parameters.AddWithValue("@InventoryID", inventoryId);
                        cmd.Parameters.AddWithValue("@Qty", qty);
                        cmd.Parameters.AddWithValue("@Unit", unit);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            LoadRecipe(menuId);
            inventoryitemdata.SelectedIndex = -1;
            manageunitrecipetxt.SelectedIndex = -1;
            quantitydata.Clear();
        }

        private void recipeGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            recipeGrid.CellDoubleClick += recipeGrid_CellDoubleClick;
        }

        private void recipeGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = recipeGrid.Rows[e.RowIndex];
                int menuInventoryId = Convert.ToInt32(row.Cells[0].Value); 
                string itemName = row.Cells[1].Value.ToString(); 
                decimal quantityUsed = Convert.ToDecimal(row.Cells[2].Value); 
                string unit = row.Cells[3].Value.ToString(); 

                _editMenuInventoryId = menuInventoryId;

                // Find and select the correct inventory item in ComboBox
                foreach (DataRowView drv in inventoryitemdata.Items)
                {
                    if (drv["ItemName"].ToString() == itemName)
                    {
                        inventoryitemdata.SelectedValue = drv["InventoryID"];
                        _editInventoryId = Convert.ToInt32(drv["InventoryID"]);
                        break;
                    }
                }
                quantitydata.Text = quantityUsed.ToString();
                manageunitrecipetxt.Text = unit;
            }
        }

        private void StyleRecipeGrid()
        {
            recipeGrid.EnableHeadersVisualStyles = false;
            recipeGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            recipeGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            recipeGrid.DefaultCellStyle.BackColor = Color.White;
            recipeGrid.DefaultCellStyle.ForeColor = Color.Black;
            recipeGrid.DefaultCellStyle.Font = new Font("Segoe UI", 13F, FontStyle.Regular);
            recipeGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            recipeGrid.RowHeadersVisible = false;
            recipeGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            recipeGrid.MultiSelect = false;
            recipeGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            recipeGrid.BorderStyle = BorderStyle.FixedSingle;
            recipeGrid.GridColor = Color.LightGray;
            recipeGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            recipeGrid.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            recipeGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            recipeGrid.BackgroundColor = Color.WhiteSmoke;
        }
    }
}