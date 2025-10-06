using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FlavorFlowIT13
{
    public partial class Login : Form
    {
        private readonly string cloudConnectionString = "Server = db28059.public.databaseasp.net; Database=db28059; User Id = db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
        private readonly string localConnectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";


        private string activeConnectionString;

        public Login()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            activeConnectionString = GetAvailableConnection();
        }

        private string GetAvailableConnection()
        {
            if (TestConnection(cloudConnectionString))
            {
                return cloudConnectionString;
            }
            else if (TestConnection(localConnectionString))
            {
                return localConnectionString;
            }
            else
            {
                MessageBox.Show("No available database connection.", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private bool TestConnection(string connectionString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false; // Connection failed
            }
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(activeConnectionString))
            {
                MessageBox.Show("No database connection available.", "Login Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "SELECT Role FROM [User] WHERE Username=@username AND Password=@password";

            try
            {
                using (SqlConnection conn = new SqlConnection(activeConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", usertxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", passwordtxt.Text.Trim());

                    conn.Open();
                    var role = cmd.ExecuteScalar();

                    if (role != null)
                    {
                        string userRole = role.ToString();

                        AuditLogger.Log(activeConnectionString, $"Login as {userRole}", usertxt.Text.Trim());

                        switch (userRole)
                        {
                            case "Admin":
                                new AdminDashboard().Show();
                                this.Hide();
                                break;

                            case "Manager":
                                new ManagerDashboard().Show();
                                this.Hide();
                                break;

                            case "Staff":
                                HandleStaffLogin(usertxt.Text.Trim(), passwordtxt.Text.Trim());
                                break;

                            case "HR":
                                new HrDashboard().Show();
                                this.Hide();
                                break;
                            case "DeliveryRider":
                                new DeliveryDashboard().Show();
                                this.Hide();
                                break;

                            case "Customer":
                                new WebAppMenu().Show();
                                this.Hide();
                                break;
                            case "Finance":
                                new FinanceDashboard().Show();
                                this.Hide();
                                break;

                            default:
                                MessageBox.Show("Invalid role assigned to user.", "Login Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Login Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while logging in: " + ex.Message, "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleStaffLogin(string username, string password)
        {
            string queryStaffId = @"
                SELECT s.StaffID 
                FROM dbo.Staff s 
                INNER JOIN dbo.[User] u ON s.UserID = u.UserID 
                WHERE u.Username = @username AND u.Password = @password;";

            try
            {
                using (var Staffconn = new SqlConnection(activeConnectionString))
                using (var Staffcmd = new SqlCommand(queryStaffId, Staffconn))
                {
                    Staffcmd.Parameters.AddWithValue("@username", username);
                    Staffcmd.Parameters.AddWithValue("@password", password);

                    Staffconn.Open();
                    var result = Staffcmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int staffId))
                    {
                        var dashboard = new StaffDashboard(staffId);
                        dashboard.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid staff credentials or role mismatch.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Staff Login: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

    }
}
