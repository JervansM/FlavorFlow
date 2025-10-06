using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FlavorFlowIT13
{

    public partial class StaffManagementAddForm : Form
    {
        private readonly string cloudConnectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public StaffManagementAddForm()
        {
            InitializeComponent();
        }

        private void suppliercosttxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StaffManagementAddForm_Load(object sender, EventArgs e)
        {
            RoundButton(addstaffbtn, 20);
            RoundButton(closebtn, 20);

            addstaffbtn.FlatStyle = FlatStyle.Flat;
            addstaffbtn.FlatAppearance.BorderSize = 0;

            closebtn.FlatStyle = FlatStyle.Flat;
            closebtn.FlatAppearance.BorderSize = 0;
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

        private void stafftxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void roleselecttxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = roleselecttxt.SelectedItem?.ToString() ?? "";

            switch (selected)
            {
                case "Manager":
                    break;
                case "HR":
                    break;
                case "Staff":
                    break;
                case "Cook":
                    break;
                case "Delivery Rider":
                    break;
                case "Waiter":
                    break;
                case "Cashier":
                    break;
                
              
            }

        }

        private void addstaffbtn_Click(object sender, EventArgs e)
        {
            string name = stafftxt.Text.Trim();
            string role = roleselecttxt.SelectedItem?.ToString();
            string contact = contacttxt.Text.Trim();

            // Basic validation
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please enter Name and select a Role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(cloudConnectionString))
                {
                    conn.Open();

                    string query = @"
                INSERT INTO Staff (Name, Role, Contact, HireDate)
                VALUES (@Name, @Role, @Contact, @HireDate)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Role", role);
                        cmd.Parameters.AddWithValue("@Contact", string.IsNullOrEmpty(contact) ? (object)DBNull.Value : contact);
                        cmd.Parameters.AddWithValue("@HireDate", DateTime.Now); // Automatically insert current date

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Staff added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add staff.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            stafftxt.Clear();
            contacttxt.Clear();
            roleselecttxt.SelectedIndex = 0;
        }


        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
