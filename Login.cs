using Microsoft.Data.SqlClient; 
using System;
using System.Data;
using System.Data.SqlClient; 
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlavorFlowIT13
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        private void Login_Load(object sender, EventArgs e)
        {




            loginbtn.FlatStyle = FlatStyle.Flat;
            loginbtn.UseVisualStyleBackColor = false;
            loginbtn.FlatAppearance.BorderSize = 0;

            loginbtn.BackColor = ColorTranslator.FromHtml("Coral");

            loginbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("Green");
            loginbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("Green");


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginbtn_Click(object sender, EventArgs e)
        {

            string connectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";


            string query = "SELECT Role FROM [User] WHERE Username=@username AND Password=@password";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@username", usertxt.Text.Trim());
                cmd.Parameters.AddWithValue("@password", passwordtxt.Text.Trim());

                conn.Open();
                var role = cmd.ExecuteScalar();

                if (role != null)
                {
                    string userRole = role.ToString();

                    if (userRole == "Admin")
                    {
                        AdminDashboard adminForm = new AdminDashboard();
                        adminForm.Show();
                        this.Hide();
                        Refresh();
                    }
                    else if (userRole == "Manager")
                    {
                        ManagerDashboard managerForm = new ManagerDashboard();
                        managerForm.Show();
                        this.Hide();
                    }
                    else if (userRole == "Staff")
                    {
                        StaffDashboard staffForm = new StaffDashboard();
                        staffForm.Show();
                        this.Hide();
                    }
                    else if (userRole == "HR")
                    {
                        HrDashboard hrForm = new HrDashboard();
                        hrForm.Show();
                        this.Hide();
                    }
                    else if (userRole == "Customer")
                    {
                        CustomerDashboard flavlorflowcustomer = new CustomerDashboard();
                        flavlorflowcustomer.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid username or password", "Login Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }


        private void usertxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginpanelinput_Paint(object sender, PaintEventArgs e)
        {

        }

        private void loginsignupbtn_Click(object sender, EventArgs e)
        {
            WebAppSignUp webAppSignUp = new WebAppSignUp();
            webAppSignUp.Show();
            this.Hide();
        }
    }
}
