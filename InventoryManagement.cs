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
    public partial class InventoryManagement : Form
    {
        public InventoryManagement()
        {
            InitializeComponent();
            RoundPanel(panelContent, 25);
            RoundPanel(systemsearchbarpanel, 25);
            RoundButton(addinventoryitembtn, 25);
            RoundPanel(inventorymanagementpanelcontents, 25);

            addinventoryitembtn.UseVisualStyleBackColor = false;
            addinventoryitembtn.FlatStyle = FlatStyle.Flat;
            addinventoryitembtn.FlatAppearance.BorderSize = 0;
            addinventoryitembtn.BackColor = ColorTranslator.FromHtml("LimeGreen");
            addinventoryitembtn.ForeColor = Color.White;
            addinventoryitembtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("Green");
            addinventoryitembtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("Green");


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
        private void RoundButton(System.Windows.Forms.Button button, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(button.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(button.Width - radius, button.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, button.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            button.Region = new System.Drawing.Region(path);
        }



        private void InventoryManagement_Load(object sender, EventArgs e)
        {
            LoadInventoryData();

        }


        private void addinventoryitembtn_Click(object sender, EventArgs e)
        {
            using (var addForm = new InventoryManagementAddForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadInventoryData(); // refresh your main list
                }
            }

        }

        private void inventorymanagementpanelcontents_Paint(object sender, PaintEventArgs e)
        {

        }
        // Add this method to InventoryManagement class to fix CS0103
        private void LoadInventoryData()
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT i.InventoryID, i.ItemName, i.Quantity, i.Unit, i.Cost, 
                       i.ExpiryDate, s.Name AS Supplier, 
                       CASE WHEN i.IsAvailable = 1 THEN 'Available' ELSE 'Not Available' END AS Status,
                       i.MinStock, i.CreatedAt, i.UpdatedAt
                FROM Inventory i
                INNER JOIN Supplier s ON i.SupplierID = s.SupplierID";

                    using (var cmd = new SqlCommand(query, conn))
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        inventorydatapanel.SuspendLayout();
                        inventorydatapanel.Controls.Clear();

                        foreach (DataRow row in dt.Rows)
                        {
                            int inventoryId = Convert.ToInt32(row["InventoryID"]);

                            Panel card = new Panel
                            {
                                Width = inventorydatapanel.Width - 40,
                                Height = 100,
                                BackColor = Color.White,
                                Margin = new Padding(10),
                                Padding = new Padding(10),
                                BorderStyle = BorderStyle.FixedSingle,
                                Tag = inventoryId
                            };

                            Label nameLabel = new Label
                            {
                                Text = $"{row["ItemName"]} ({row["Quantity"]} {row["Unit"]})",
                                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                                AutoSize = true,
                                ForeColor = Color.Black,
                                Location = new Point(10, 10)
                            };

                            Label supplierLabel = new Label
                            {
                                Text = $"Cost: ₱{row["Cost"]} | Supplier: {row["Supplier"]}",
                                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                                AutoSize = true,
                                ForeColor = Color.DimGray,
                                Location = new Point(10, 35)
                            };

                            Label statusLabel = new Label
                            {
                                Text = $"Expiry: {Convert.ToDateTime(row["ExpiryDate"]).ToShortDateString()} | Status: {row["Status"]}",
                                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                                AutoSize = true,
                                ForeColor = (row["Status"].ToString() == "Available") ? Color.Green : Color.Red,
                                Location = new Point(10, 60)
                            };

                            Label minStockLabel = new Label
                            {
                                Text = $"Min Stock: {row["MinStock"]}",
                                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                                AutoSize = true,
                                ForeColor = Color.DarkOrange,
                                Location = new Point(10, 80)
                            };

                            card.Controls.Add(nameLabel);
                            card.Controls.Add(supplierLabel);
                            card.Controls.Add(statusLabel);
                            card.Controls.Add(minStockLabel);

                            // Double click = edit
                            card.DoubleClick += (s, e) =>
                            {
                                int id = (int)((Panel)s).Tag;
                                using (var editForm = new InventoryManagementAddForm(id))
                                {
                                    if (editForm.ShowDialog() == DialogResult.OK)
                                    {
                                        LoadInventoryData(); 
                                    }
                                }
                            };

                            inventorydatapanel.Controls.Add(card);
                        }

                        inventorydatapanel.ResumeLayout();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void inventorydatapanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuedititembtn_Click(object sender, EventArgs e)
        {

        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void viewrecipebtn_Click(object sender, EventArgs e)
        {

        }
    }
}
   