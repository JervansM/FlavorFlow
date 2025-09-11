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
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FlavorFlowIT13
{
    public partial class MenuManagementAddMenuForm : Form
    {
        private bool _isEditMode = false;
        private int _editMenuID = -1;

        private int? _menuId;
        public MenuManagementAddMenuForm()
        {
            InitializeComponent();
        }

        public MenuManagementAddMenuForm(int menuId) : this()
        {
            _isEditMode = true;
           _editMenuID = menuId;

        
            _menuId = menuId;


            panelFormHeader.BackColor = ColorTranslator.FromHtml("Coral");







        }


        private void MenuManagementAddMenuForm_Load(object sender, EventArgs e)
        {
            if (_isEditMode && _editMenuID > 0)
            {
                string query = "SELECT * FROM Menu WHERE MenuID = @MenuID";

                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@MenuID", _editMenuID);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            menunametxt.Text = reader["Name"].ToString();
                            menuformdesctxt.Text = reader["Description"].ToString();
                            menuformcategory.Text = reader["Category"].ToString();
                            menuformpricetxt.Text = reader["Price"].ToString();
                            menuformstatuscheckbox.Checked = (bool)reader["IsAvailable"];

                            // Load image
                            if (reader["ImagePath"] != DBNull.Value)
                            {
                                string path = reader["ImagePath"].ToString();
                                if (File.Exists(path))
                                {
                                    pictoreBoxMenu.Image = Image.FromFile(path);
                                    pictoreBoxMenu.SizeMode = PictureBoxSizeMode.Zoom;
                                    SelectedImagePath = path;
                                }
                                else
                                {
                                    pictoreBoxMenu.Image = SystemIcons.Warning.ToBitmap();
                                    pictoreBoxMenu.SizeMode = PictureBoxSizeMode.CenterImage;
                                }
                            }
                        }

                        this.Text = "Edit Menu Item"; // change title for clarity
                        menuformsavebtn.Text = "Update";
                    }
                }
            }
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

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"))
                {
                    con.Open();
                    SqlCommand cmd;

                    if (_isEditMode)
                    {
                        // UPDATE
                        cmd = new SqlCommand(@"UPDATE Menu 
                           SET Name=@Name, Description=@Description, Category=@Category, 
                               Price=@Price, IsAvailable=@IsAvailable, ImagePath=@ImagePath 
                           WHERE MenuID=@MenuID", con);
                        cmd.Parameters.AddWithValue("@MenuID", _editMenuID);
                    }
                    else
                    {
                        // INSERT
                        cmd = new SqlCommand(@"INSERT INTO Menu (Name, Description, Category, Price, IsAvailable, ImagePath) 
                           VALUES (@Name, @Description, @Category, @Price, @IsAvailable, @ImagePath)", con);
                    }

                    cmd.Parameters.AddWithValue("@Name", menunametxt.Text);
                    cmd.Parameters.AddWithValue("@Description", menuformdesctxt.Text);
                    cmd.Parameters.AddWithValue("@Category", menuformcategory.Text);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@IsAvailable", menuformstatuscheckbox.Checked);
                    cmd.Parameters.AddWithValue("@ImagePath", (object)SelectedImagePath ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
                MessageBox.Show("Menu item saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving menu item: " + ex.Message);
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

