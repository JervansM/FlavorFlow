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
        }

        private void Login_Load(object sender, EventArgs e)
        {
            RoundTextBox(loginpanelinput,usertxt ,20);
            RoundTextBox(loginpanelinput, passwordtxt, 20);
           


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

            string connectionString = "Data Source=MONTERO-JV;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";


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
        private void RoundTextBox(Panel pnl, TextBox txt, int radius)
        {
         
            txt.BorderStyle = BorderStyle.None;
            
            txt.ForeColor = ColorTranslator.FromHtml("Black");

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(pnl.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(pnl.Width - radius, pnl.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, pnl.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            pnl.Region = new Region(path);
            pnl.BackColor = ColorTranslator.FromHtml("Transparent");
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
    }
}
