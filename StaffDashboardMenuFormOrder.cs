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
    public partial class StaffDashboardMenuFormOrder : Form
    {
        private string _tableName;
        private StaffDashboardMenuFormOrder orderForm;
        private string connectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public event Action<OrderItem> MenuItemClicked;


        public StaffDashboardMenuFormOrder(string tableName)
        {
            InitializeComponent();
            _tableName = tableName;
        }

        private void StaffDashboardMenuFormOrder_Load(object sender, EventArgs e)
        {
            LoadMenuData();

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
        public class OrderItem
        {
            public int MenuId { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Qty { get; set; }
            public decimal Subtotal => Qty * Price;
        }
        private void LoadMenuData()
        {

            flowLayoutMenuCard.Controls.Clear();

            string connectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

            string query = "SELECT MenuID, Name, Description, Category, Price, IsAvailable, ImagePath FROM Menu ORDER BY Name;";


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
                            card.Width = 300;
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
            card.Width = 300;
            card.Height = 375;
            card.Margin = new Padding(5);
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;

            // Read values now
            int menuId = (int)reader["MenuID"];
            string name = reader["Name"].ToString();
            string description = reader["Description"].ToString();
            string category = reader["Category"].ToString();
            decimal price = Convert.ToDecimal(reader["Price"]);
            bool isAvailable = (bool)reader["IsAvailable"];
            string imagePath = reader["ImagePath"] != DBNull.Value ? reader["ImagePath"].ToString() : null;

            // Picture
            PictureBox pic = new PictureBox();
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.MinimumSize = new Size(320, 200);
            pic.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            if (!string.IsNullOrEmpty(imagePath))
            {
                try { pic.Image = Image.FromFile(imagePath); }
                catch { pic.Image = SystemIcons.Warning.ToBitmap(); }
            }
            card.Controls.Add(pic);

            int y = pic.Bottom + 10;

      

            Label lblName = new Label { Text = name, ForeColor = Color.Black, Font = new Font("Segoe UI", 15, FontStyle.Bold) };
            lblName.SetBounds(10, y, 220, 29);
            card.Controls.Add(lblName);
            y += lblName.Height + 5;

            Label lblDesc = new Label { Text = description, ForeColor = Color.DimGray, Font = new Font("Segoe UI", 10, FontStyle.Italic), AutoEllipsis = true };
            lblDesc.SetBounds(10, y, 220, 20);
            card.Controls.Add(lblDesc);
            y += lblDesc.Height + 5;

            Label lblCategory = new Label { Text = category, ForeColor = ColorTranslator.FromHtml("#2823B1"), Font = new Font("Segoe UI", 12, FontStyle.Bold) };
            lblCategory.SetBounds(10, y, 220, 20);
            card.Controls.Add(lblCategory);
            y += lblCategory.Height + 5;

            Label lblPrice = new Label { Text = "₱" + price.ToString("N2"), Font = new Font("Segoe UI", 18), ForeColor = Color.Black };
            lblPrice.SetBounds(45, y, 220, 27);
            lblPrice.TextAlign = ContentAlignment.BottomRight;
            card.Controls.Add(lblPrice);
            y += lblPrice.Height + 5;

            Label lblStatus = new Label { Text = isAvailable ? "Available" : "Not Available", ForeColor = isAvailable ? Color.Green : Color.Red };
            lblStatus.SetBounds(40, y, 220, 23);
            lblStatus.TextAlign = ContentAlignment.BottomRight;
            card.Controls.Add(lblStatus);

            if (isAvailable)
            {
                card.Click += (s, e) =>
                {
                    int qty = 1; // default quantity
                    OrderItem item = new OrderItem
                    {
                        MenuId = menuId,
                        Name = name,  // use local variable, not reader
                        Price = price,
                        Qty = qty
                    };

                    MenuItemClicked?.Invoke(item); // raise event
                };
            }

            return card;
        }

        
        private void InsertOrderItem(SqlConnection con, int orderId, int menuId, int menuInventoryId, int qty)
        {
            string insertQuery = @"INSERT INTO OrderItems (OrderID, MenuID, MenuInventoryID, Qty, Price, Subtotal)
                                   VALUES (@OrderID, @MenuID, @MenuInventoryID, @Qty,
                                           (SELECT Price FROM Menu WHERE MenuID = @MenuID),
                                           (SELECT Price FROM Menu WHERE MenuID = @MenuID) * @Qty)";

            using (SqlCommand cmd = new SqlCommand(insertQuery, con))
            {
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                cmd.Parameters.AddWithValue("@MenuID", menuId);
                cmd.Parameters.AddWithValue("@MenuInventoryID", menuInventoryId);
                cmd.Parameters.AddWithValue("@Qty", qty);
                cmd.ExecuteNonQuery();
            }
        }

        private void DeductInventory(SqlConnection con, int inventoryId, int qtyToDeduct)
        {
            string updateQuery = @"UPDATE Inventory
                                   SET Quantity = Quantity - @QtyToDeduct
                                   WHERE InventoryID = @InventoryID";

            using (SqlCommand cmd = new SqlCommand(updateQuery, con))
            {
                cmd.Parameters.AddWithValue("@QtyToDeduct", qtyToDeduct);
                cmd.Parameters.AddWithValue("@InventoryID", inventoryId);
                cmd.ExecuteNonQuery();
            }
        }



        private void menusearchbarpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menusearchbar_TextChanged(object sender, EventArgs e)
        {
            string searchText = menusearchbar.Text.Trim();

            // If empty, load all menu
            if (string.IsNullOrEmpty(searchText))
            {
                LoadMenuData();
                return;
            }

            // Clear current cards
            flowLayoutMenuCard.Controls.Clear();

            string query = @"SELECT MenuID, Name, Description, Category, Price, IsAvailable, ImagePath
                     FROM Menu
                     WHERE Name LIKE @search OR Category LIKE @search
                     ORDER BY Name;";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Add card for each result
                            flowLayoutMenuCard.Controls.Add(CreateMenuCard(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching menu: " + ex.Message);
            }
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutMenuCard_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
