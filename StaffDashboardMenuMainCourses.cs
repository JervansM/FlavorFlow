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
    public partial class StaffDashboardMenuMainCourses : Form
    {
        public StaffDashboardMenuMainCourses()
        {
            InitializeComponent();
        }

        private void flowLayoutMenuCard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StaffDashboardMenuMainCourses_Load(object sender, EventArgs e)
        {
            LoadMenuData("Main Courses");

        }
        private void LoadMenuData(string category = null)
        {
            flowLayoutMenuCard.Controls.Clear();

            string connectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
            string query = @"SELECT MenuID, Name, Description, LTRIM(RTRIM(Category)) AS Category, 
                                    Price, IsAvailable, ImagePath 
                             FROM Menu ";

            if (!string.IsNullOrEmpty(category))
            {
                query += "WHERE LTRIM(RTRIM(Category)) = @Category ";
            }

            query += "ORDER BY Name;";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (!string.IsNullOrEmpty(category))
                    {
                        cmd.Parameters.AddWithValue("@Category", category);
                    }

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        bool found = false;
                        while (reader.Read())
                        {
                            flowLayoutMenuCard.Controls.Add(CreateMenuCard(reader));
                            found = true;
                        }
                        if (!found)
                        {
                            MessageBox.Show($"No menu items found for category: {category}", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            PictureBox pic = new PictureBox();
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.MinimumSize = new Size(320, 200);
            if (reader["ImagePath"] != DBNull.Value)
            {
                try { pic.Image = Image.FromFile(reader["ImagePath"].ToString()); }
                catch { pic.Image = SystemIcons.Warning.ToBitmap(); }
            }
            card.Controls.Add(pic);

            int y = pic.Bottom + 10;

            Label lblName = new Label();
            lblName.Text = reader["Name"].ToString();
            lblName.SetBounds(10, y, 220, 29);
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
            y += lblCategory.Height + 5;

            Label lblPrice = new Label();
            lblPrice.Text = "₱" + Convert.ToDecimal(reader["Price"]).ToString("N2");
            lblPrice.SetBounds(10, y, 220, 27);
            lblPrice.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblPrice.ForeColor = Color.Green;
            card.Controls.Add(lblPrice);
            y += lblPrice.Height + 5;

            Label lblStatus = new Label();
            bool isAvailable = (bool)reader["IsAvailable"];
            lblStatus.Text = isAvailable ? "Available" : "Not Available";
            lblStatus.SetBounds(10, y, 220, 23);
            lblStatus.ForeColor = isAvailable ? Color.Green : Color.Red;
            card.Controls.Add(lblStatus);

            return card;
        }
    }
}
