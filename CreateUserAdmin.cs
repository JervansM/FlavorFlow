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
using System.Data.SqlClient;

namespace FlavorFlowIT13
{
    public partial class CreateUserAdmin : Form
    {
        string connectionString = "Data Source=MONTERO-JV;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public CreateUserAdmin()
        {
            InitializeComponent();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            string username = createpasswordtxt.Text.Trim();
            string password = createpasswordtxt.Text.Trim();
            string role = rolecombobox.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("⚠️ Please fill up the form.");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("⚠️ Please fill up the form.");
                return;
            }

            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("⚠️ Please fill up the form.");
                return;
            }
            connectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Trust Server Certificate=True";
            string query = "INSERT INTO [User] (Username, Password, Role) VALUES (@Username, @Password, @Role)";


            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", createusertxt.Text);
                cmd.Parameters.AddWithValue("@Password", createpasswordtxt.Text);
                cmd.Parameters.AddWithValue("@Role", rolecombobox.SelectedItem?.ToString() ?? "Customer");

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("✅ User added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Error: " + ex.Message);
                }

            }
        }

        private void CreateUserAdmin_Load(object sender, EventArgs e)
        {

        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createusertxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void createpasswordtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void rolecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRole = rolecombobox.SelectedItem.ToString();

            switch (selectedRole)
            {
                case "Admin":
                    break;
                case "Manager":
                    break;
                case "Staff":
                    break;
                case "Customer":
                    break;
                default:
                    break;
            }
        }

        private void rolelbl_Click(object sender, EventArgs e)
        {

        }
    }
}
