using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace FlavorFlowIT13
{
    public partial class WebAppMenu : Form
    {

        private readonly string cloudConnectionString =
           "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public WebAppMenu()
        {
            InitializeComponent();
        }



        private void WebAppMenu_Load(object sender, EventArgs e)
        {
            LoadMenuData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Assuming button1 is for checking out
            LoadContent(new WebAppCheckout());
        }


        private void maincoursebtn_Click(object sender, EventArgs e)
        {

        }

        private void LoadContent(Form form)
        {
            try
            {
                // Clear previous content
                this.Controls.Clear();
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                this.Controls.Add(form);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading content: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadMenuData()
        {

            flowLayoutMenuCard.Controls.Clear();


            string query = "SELECT MenuID, Name, Description, Category, Price, IsAvailable, ImagePath FROM Menu ORDER BY Name;";


            try
            {
                using (SqlConnection con = new SqlConnection(cloudConnectionString))
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





            // Picture
            PictureBox pic = new PictureBox();

            pic.SizeMode = PictureBoxSizeMode.StretchImage;
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


        private void allitemsbtn_Click(object sender, EventArgs e)
        {

        }
    }
}