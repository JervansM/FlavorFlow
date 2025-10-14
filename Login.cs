using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Text;
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
                                new AdminDashboard().Show();
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
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
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
            RoundPanel(loginpanel, 35);
            RoundButton(loginbtn, 20);
            RoundButton(loginsignupbtn, 20);
            RoundTextBox(usertxt, 15);
            RoundTextBox(passwordtxt, 15);

            loginpanel.BackColor = Color.FromArgb(180, 240, 240, 240);
            loginpanel.Padding = new Padding(30);



            usertxt.BorderStyle = BorderStyle.None;
            usertxt.BackColor = Color.White;
            usertxt.ForeColor = Color.FromArgb(64, 64, 64);

            passwordtxt.BorderStyle = BorderStyle.None;
            passwordtxt.BackColor = Color.White;
            passwordtxt.ForeColor = Color.FromArgb(64, 64, 64);


            StyleButton(loginbtn, "#FF7F50");
            StyleButton(loginsignupbtn, "#FF7F50");

            usertxt.Focus();

        }
      

        private void StyleButton(Button button, string baseColorHex)
        {
            button.UseVisualStyleBackColor = false;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = ColorTranslator.FromHtml(baseColorHex);
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            button.MouseEnter += (s, e) => button.BackColor = ColorTranslator.FromHtml("#E06A3C");
            button.MouseLeave += (s, e) => button.BackColor = ColorTranslator.FromHtml(baseColorHex);
        }




        private void loginpanel_Paint(object sender, PaintEventArgs e)
        {
            int radius = 50;
            int borderThickness = 3;
            Color borderColor = ColorTranslator.FromHtml("#2f2f2f");

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(loginpanel.Width - radius - 1, 0, radius, radius, 270, 90);
                path.AddArc(loginpanel.Width - radius - 1, loginpanel.Height - radius - 1, radius, radius, 0, 90);
                path.AddArc(0, loginpanel.Height - radius - 1, radius, radius, 90, 90);
                path.CloseAllFigures();

                using (Pen pen = new Pen(borderColor, borderThickness))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
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
        private void RoundTextBox(TextBox txtBox, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(txtBox.Width - radius - 1, 0, radius, radius, 270, 90);
            path.AddArc(txtBox.Width - radius - 1, txtBox.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(0, txtBox.Height - radius - 1, radius, radius, 90, 90);
            path.CloseFigure();
            txtBox.Region = new Region(path);
        }

        
    }
}
