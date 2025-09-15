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
    public partial class MenuManagement : Form
    {
        private int? _selectedMenuId = null;

        public MenuManagement()
        {
            InitializeComponent();



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

        private void addmenuitembtn_Click(object sender, EventArgs e)
        {
            using (var addMenuForm = new MenuManagementAddMenuForm())
            {
                var result = addMenuForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadMenuData();


                    MessageBox.Show("New menu item added!");
                }
            }
        }
        private void menuedititembtn_Click(object sender, EventArgs e)
        {
            if (_selectedMenuId == null)
            {
                MessageBox.Show("Please select a menu item to edit.");
                return;
            }

            using (var editForm = new MenuManagementAddMenuForm(_selectedMenuId.Value))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadMenuData(); // refresh after edit
                }
            }
        }

        private void MenuManagement_Load(object sender, EventArgs e)
        {
            LoadMenuData();





            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                RoundPanel(panelContent, 25);
                RoundPanel(systemsearchbarpanel, 25);
                RoundButton(addmenuitembtn, 20);
                RoundPanel(salespospanelcontents, 25);
                RoundButton(menumanagementrecipebtn, 20);
                RoundButton(menuedititembtn, 20);

                

                menumanagementrecipebtn.UseVisualStyleBackColor = false;
                menumanagementrecipebtn.FlatStyle = FlatStyle.Flat;
                menumanagementrecipebtn.FlatAppearance.BorderSize = 0;
                menumanagementrecipebtn.BackColor = ColorTranslator.FromHtml("#2823B1");
                menumanagementrecipebtn.ForeColor = Color.White;
                menumanagementrecipebtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#221E8D");
                menumanagementrecipebtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#221E8D");

                addmenuitembtn.UseVisualStyleBackColor = false;
                addmenuitembtn.FlatStyle = FlatStyle.Flat;
                addmenuitembtn.FlatAppearance.BorderSize = 0;
                addmenuitembtn.BackColor = ColorTranslator.FromHtml("#5CC536");
                addmenuitembtn.ForeColor = Color.White;
                addmenuitembtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#449925");
                addmenuitembtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#449925");

                menuedititembtn.UseVisualStyleBackColor = false;
                menuedititembtn.FlatStyle = FlatStyle.Flat;
                menuedititembtn.FlatAppearance.BorderSize = 0;
                menuedititembtn.BackColor = ColorTranslator.FromHtml("#E49629");
                menuedititembtn.ForeColor = Color.White;
                menuedititembtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#B47E32");
                menuedititembtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#B47E32");
            }
        }
        public void AddMenuIngredients(int menuId, List<(int InventoryId, decimal QuantityUsed)> ingredients)
        {
            string connectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";


            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in ingredients)
                {
                    using (var cmd = new SqlCommand(
                        "INSERT INTO MenuInventory (MenuID, InventoryID, QuantityUsed) VALUES (@MenuID, @InventoryID, @QuantityUsed)", conn))
                    {
                        cmd.Parameters.AddWithValue("@MenuID", menuId);
                        cmd.Parameters.AddWithValue("@InventoryID", item.InventoryId);
                        cmd.Parameters.AddWithValue("@QuantityUsed", item.QuantityUsed);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        public DataTable GetMenuIngredients(int menuId)
        {
            string connectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
            SELECT MI.InventoryID, I.Name, MI.QuantityUsed
            FROM MenuInventory MI
            JOIN Inventory I ON MI.InventoryID = I.InventoryID
            WHERE MI.MenuID = @MenuID", conn);
                cmd.Parameters.AddWithValue("@MenuID", menuId);

                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
        }
        public bool PlaceOrder(int menuId, int quantity)
        {
            string connectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Get ingredients for this menu
                        var cmd = new SqlCommand(@"
                    SELECT InventoryID, QuantityUsed
                    FROM MenuInventory
                    WHERE MenuID = @MenuID", conn, transaction);
                        cmd.Parameters.AddWithValue("@MenuID", menuId);

                        var reader = cmd.ExecuteReader();
                        var ingredients = new List<(int InventoryId, decimal QuantityUsed)>();
                        while (reader.Read())
                        {
                            ingredients.Add((reader.GetInt32(0), reader.GetDecimal(1)));
                        }
                        reader.Close();

                        // 2. Check stock
                        foreach (var item in ingredients)
                        {
                            var checkCmd = new SqlCommand(
                                "SELECT Quantity FROM Inventory WHERE InventoryID=@InventoryID", conn, transaction);
                            checkCmd.Parameters.AddWithValue("@InventoryID", item.InventoryId);
                            decimal stock = (decimal)checkCmd.ExecuteScalar();

                            if (stock < item.QuantityUsed * quantity)
                                throw new Exception($"Out of stock: InventoryID {item.InventoryId}");
                        }

                        // 3. Deduct stock
                        foreach (var item in ingredients)
                        {
                            var updateCmd = new SqlCommand(@"
                        UPDATE Inventory
                        SET Quantity = Quantity - @Qty,
                            UpdatedAt = GETDATE()
                        WHERE InventoryID=@InventoryID", conn, transaction);
                            updateCmd.Parameters.AddWithValue("@Qty", item.QuantityUsed * quantity);
                            updateCmd.Parameters.AddWithValue("@InventoryID", item.InventoryId);
                            updateCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void salespanelsalespospanelcontentsheader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void salespospanelcontents_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menudatacontents_Paint(object sender, PaintEventArgs e)
        {



        }

        private void LoadMenuData()
        {

            flowLayoutMenuCard.Controls.Clear();

            string connectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
            string query = "SELECT MenuID, Name, Description, Category, Price, IsAvailable, ImagePath FROM Menu";


            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Panel card = new Panel();
                            card.Width = 290;
                            card.Height = 375;
                            card.Margin = new Padding(10);
                            card.BackColor = Color.White;
                            card.BorderStyle = BorderStyle.FixedSingle;


                            flowLayoutMenuCard.Controls.Add(CreateMenuCard(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading menu: " + ex.Message);
            }
        }

        private Panel CreateMenuCard(SqlDataReader reader)
        {
            Panel card = new Panel();
            card.Width = 290;
            card.Height = 375;
            card.Margin = new Padding(5);
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;

            int menuId = (int)reader["MenuID"]; // capture ID for this card

            card.Click += (s, e) =>
            {
                _selectedMenuId = menuId;
                foreach (Control ctrl in flowLayoutMenuCard.Controls)
                    ctrl.BackColor = Color.White; // reset
                card.BackColor = Color.LightBlue; // highlight selected
            };

            card.DoubleClick += (s, e) =>
            {
                using (var editForm = new MenuManagementAddMenuForm(menuId))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadMenuData(); // reload after saving
                    }
                }
            };


            // Picture
            PictureBox pic = new PictureBox();

            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.MinimumSize = new Size(320, 200);
            pic.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            if (reader["ImagePath"] != DBNull.Value)
            {
                try { pic.Image = Image.FromFile(reader["ImagePath"].ToString()); }
                catch { pic.Image = SystemIcons.Warning.ToBitmap(); }
            }
            card.Controls.Add(pic);

            int y = pic.Bottom + 10;

            Label lblID = new Label();
            lblID.Text = "MenuID: " + reader["MenuID"].ToString();
            lblID.SetBounds(10, y, 220, 15);
            lblID.ForeColor = Color.Gray;
            lblID.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            card.Controls.Add(lblID);
            y += lblID.Height + 5;

            Label lblName = new Label();
            lblName.Text = reader["Name"].ToString();
            lblName.SetBounds(10, y, 220, 29);
            lblName.ForeColor = Color.Black;
            lblName.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            card.Controls.Add(lblName);
            y += lblName.Height + 5;

            Label lblDesc = new Label();
            lblDesc.Text = reader["Description"].ToString();
            lblDesc.SetBounds(10, y, 220, 20);
            lblDesc.ForeColor = Color.DimGray;
            lblDesc.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            lblDesc.AutoEllipsis = true;
            card.Controls.Add(lblDesc);
            y += lblDesc.Height + 5;


            Label lblCategory = new Label();
            lblCategory.Text = reader["Category"].ToString();
            lblCategory.SetBounds(10, y, 220, 20);
            lblCategory.ForeColor = ColorTranslator.FromHtml("#2823B1");
            lblCategory.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            card.Controls.Add(lblCategory);
            y += lblDesc.Height + 5;

            Label lblPrice = new Label();
            lblPrice.Text = "₱" + Convert.ToDecimal(reader["Price"]).ToString("N2");
            lblPrice.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblPrice.SetBounds(10, y, 220, 27);
            lblPrice.ForeColor = Color.Green;
            card.Controls.Add(lblPrice);
            y += lblCategory.Height + 5;
            lblPrice.TextAlign = ContentAlignment.BottomRight;



            Label lblStatus = new Label();
            bool isAvailable = (bool)reader["IsAvailable"];
            lblStatus.Text = isAvailable ? "Available" : "Not Available";
            lblStatus.SetBounds(10, y, 220, 23);
            lblStatus.ForeColor = isAvailable ? Color.Green : Color.Red;
            card.Controls.Add(lblStatus);
            lblStatus.TextAlign = ContentAlignment.BottomRight;





            return card;

        }





        private void flowLayoutMenuCard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menumanagementrecipebtn_Click(object sender, EventArgs e)
        {
            MenuRecipeForm recipeForm = new MenuRecipeForm();
            recipeForm.Show();

        }
    }

}

