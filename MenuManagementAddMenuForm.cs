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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlavorFlowIT13
{
    public partial class MenuManagementAddMenuForm : Form
    {
        public MenuManagementAddMenuForm()
        {
            InitializeComponent();


            panelFormHeader.BackColor = ColorTranslator.FromHtml("Coral");







        }

        private void MenuManagementAddMenuForm_Load(object sender, EventArgs e)
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

        private void panelForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menunamelbl_Click(object sender, EventArgs e)
        {

        }

        private void menuformstatuscheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panelFormHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuformselectimagebtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Verify file really contains an image
                        using (var fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (var testImage = Image.FromStream(fs, false, false))
                            {
                                // Make a resized copy (keeps original safe)
                                Image resized = new Bitmap(testImage, pictoreBoxMenu.Size);

                                if (pictoreBoxMenu.Image != null)
                                    pictoreBoxMenu.Image.Dispose();

                                pictoreBoxMenu.Image = resized;
                            }
                        }

                        // Save valid path
                        SelectedImagePath = ofd.FileName;
                    }
                    catch (OutOfMemoryException)
                    {
                        MessageBox.Show("This file is not a valid image or it’s too large.",
                                        "Invalid Image",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message,
                                        "Image Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
        }


        private string SelectedImagePath;


        private void pictoreBoxMenu_Click(object sender, EventArgs e)
        {

        }

        private void menuformsavebtn_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(menunametxt.Text))
            {
                MessageBox.Show("Menu name is required.");
                return;
            }

            if (!decimal.TryParse(menuformpricetxt.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            string name = menunametxt.Text.Trim();
            string description = menuformdesctxt.Text.Trim();
            string category = menuformcategory.Text.Trim();
            bool isAvailable = menuformstatuscheckbox.Checked;
            DateTime dateCreated = DateTime.Now;
            string imagePath = string.IsNullOrEmpty(SelectedImagePath) ? null : SelectedImagePath;

            // Insert into database
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=MONTERO-JV;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"))
                {
                    conn.Open();
                    string query = @"INSERT INTO Menu (Name, Description, Category, Price, IsAvailable, DateCreated, ImagePath)
                             VALUES (@Name, @Description, @Category, @Price, @IsAvailable, @DateCreated, @ImagePath)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(description) ? DBNull.Value : (object)description);
                        cmd.Parameters.AddWithValue("@Category", string.IsNullOrEmpty(category) ? DBNull.Value : (object)category);
                        cmd.Parameters.Add("@Price", System.Data.SqlDbType.Decimal).Value = price;
                        cmd.Parameters.AddWithValue("@IsAvailable", isAvailable);
                        cmd.Parameters.AddWithValue("@DateCreated", dateCreated);
                        cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(imagePath) ? DBNull.Value : (object)imagePath);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Menu item saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving menu item: " + ex.Message);
                return; // Stop here if DB fails
            }

            // Clear form safely
            try
            {
                menunametxt.Clear();
                menuformdesctxt.Clear();
                menuformpricetxt.Clear();

                if (menuformcategory.Items.Count > 0)
                    menuformcategory.SelectedIndex = -1;

                menuformstatuscheckbox.Checked = false;

                // Dispose the image safely
                if (pictoreBoxMenu.Image != null)
                {
                    pictoreBoxMenu.Image.Dispose();
                    pictoreBoxMenu.Image = null;
                }

                SelectedImagePath = null;
            }
            catch (Exception ex)
            {
                // Log error but don't show to user to avoid double-message
                Console.WriteLine("Form clear error: " + ex.Message);
            }
        }


        private void menuformcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = menuformcategory.SelectedItem.ToString();

            switch (selected)
            {


                case "Appetizer":
                    break;
                case "Main Course":
                    break;
                case "Dessert":
                    break;
                case "Beverages":
                    break;
                default:
                    break;

            }
        }
    }
}

