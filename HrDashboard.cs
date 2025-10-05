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

namespace FlavorFlowIT13
{
    public partial class HrDashboard : Form
    {
        private readonly string connectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public HrDashboard()
        {
            InitializeComponent();

        }

        private void HrDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardData();

            hrdate.Text = DateTime.Now.ToString("d");
            hrtime.Text = DateTime.Now.ToString("t");


            RoundPanel(panelContent, 25);
            RoundPanel(panel1, 25);
            RoundButton(button9, 19);
            RoundButton(EmployeeManagementbtn, 19);
            RoundButton(hrpayrollbtn, 19);
            RoundButton(hrattendaceshiftbtn, 19);
            RoundButton(hrleavetimeoffbtn, 19);
            RoundButton(hrcompliancepoliciesbtn, 19);
            RoundButton(hrreportsanalyticsbtn, 19);
            RoundButton(Logoutbtn, 19);

            button9.UseVisualStyleBackColor = false;
            button9.FlatStyle = FlatStyle.Flat;
            button9.FlatAppearance.BorderSize = 0;
            button9.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            button9.ForeColor = Color.White;
            button9.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            button9.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            EmployeeManagementbtn.UseVisualStyleBackColor = false;
            EmployeeManagementbtn.FlatStyle = FlatStyle.Flat;
            EmployeeManagementbtn.FlatAppearance.BorderSize = 0;
            EmployeeManagementbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            EmployeeManagementbtn.ForeColor = Color.White;
            EmployeeManagementbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            EmployeeManagementbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            hrpayrollbtn.UseVisualStyleBackColor = false;
            hrpayrollbtn.FlatStyle = FlatStyle.Flat;
            hrpayrollbtn.FlatAppearance.BorderSize = 0;
            hrpayrollbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            hrpayrollbtn.ForeColor = Color.White;
            hrpayrollbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            hrpayrollbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            hrattendaceshiftbtn.UseVisualStyleBackColor = false;
            hrattendaceshiftbtn.FlatStyle = FlatStyle.Flat;
            hrattendaceshiftbtn.FlatAppearance.BorderSize = 0;
            hrattendaceshiftbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            hrattendaceshiftbtn.ForeColor = Color.White;
            hrattendaceshiftbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            hrattendaceshiftbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            hrleavetimeoffbtn.UseVisualStyleBackColor = false;
            hrleavetimeoffbtn.FlatStyle = FlatStyle.Flat;
            hrleavetimeoffbtn.FlatAppearance.BorderSize = 0;
            hrleavetimeoffbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            hrleavetimeoffbtn.ForeColor = Color.White;
            hrleavetimeoffbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            hrleavetimeoffbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            hrcompliancepoliciesbtn.UseVisualStyleBackColor = false;
            hrcompliancepoliciesbtn.FlatStyle = FlatStyle.Flat;
            hrcompliancepoliciesbtn.FlatAppearance.BorderSize = 0;
            hrcompliancepoliciesbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            hrcompliancepoliciesbtn.ForeColor = Color.White;
            hrcompliancepoliciesbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            hrcompliancepoliciesbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            hrreportsanalyticsbtn.UseVisualStyleBackColor = false;
            hrreportsanalyticsbtn.FlatStyle = FlatStyle.Flat;
            hrreportsanalyticsbtn.FlatAppearance.BorderSize = 0;
            hrreportsanalyticsbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            hrreportsanalyticsbtn.ForeColor = Color.White;
            hrreportsanalyticsbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            hrreportsanalyticsbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            Logoutbtn.UseVisualStyleBackColor = false;
            Logoutbtn.FlatStyle = FlatStyle.Flat;
            Logoutbtn.FlatAppearance.BorderSize = 0;
            Logoutbtn.BackColor = ColorTranslator.FromHtml("Coral");
            Logoutbtn.ForeColor = Color.White;
            Logoutbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("Maroon");
            Logoutbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("Maroon");








        }

        private void LoadDashboardData()
        {
            LoadActiveEmployeeHeadcount();
            LoadLeaveContracts();
            LoadLeaveRequests();
            LoadAttendanceToday();

        }

        private void LoadDashboard()
        {
            panelContent.Controls.Clear();
            DashboardControl dashboard = new DashboardControl();
            dashboard.Dock = DockStyle.Fill;
            panelContent.Controls.Add(dashboard);

            // Also refresh counts when dashboard is reloaded
            LoadDashboardData();
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

        private void LoadContent(Form form)
        {
            foreach (Control ctrl in panelContent.Controls)
            {
                ctrl.Dispose();
            }
            panelContent.Controls.Clear();

            // Prepare the new form
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Add to panel
            panelContent.Controls.Add(form);
            form.Show();
        }

        private void LoadActiveEmployeeHeadcount()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Employee WHERE Status = 'Active'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int count = (int)cmd.ExecuteScalar();
                        hrdashboardemployeeheadcounttxt.Text = count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee headcount: " + ex.Message);
            }
        }

        private void LoadLeaveContracts()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM LeaveRequest WHERE Status = 'Approved'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int count = (int)cmd.ExecuteScalar();
                        hrdashboardleavecontractstxt.Text = count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading leave contracts: " + ex.Message);
            }
        }

        private void LoadLeaveRequests()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM LeaveRequest WHERE Status = 'Pending'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int count = (int)cmd.ExecuteScalar();
                        hrdashboardleaverequeststxt.Text = count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading leave requests: " + ex.Message);
            }
        }

        private void LoadAttendanceToday()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Attendance WHERE CAST(Date AS DATE) = CAST(GETDATE() AS DATE) AND Status = 'Present'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int count = (int)cmd.ExecuteScalar();
                        hrdashboardattendancetodaytxt.Text = count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance today: " + ex.Message);
            }
        }

        // UI Event Handlers
        private void label1_Click(object sender, EventArgs e) { }
        private void dashlowstackalerts_Click(object sender, EventArgs e) { }
        private void panelNav_Paint(object sender, PaintEventArgs e) { }
        private void adstaffbtn_Click(object sender, EventArgs e) { }
        private void dashvisuals_Paint(object sender, PaintEventArgs e) { }
        private void dashinventorytxt_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void fficonadmin_Click(object sender, EventArgs e) { }
        private void panelContent_Paint(object sender, PaintEventArgs e) { }
        private void EmployeeManagement_Click(object sender, EventArgs e) { LoadContent(new HrEmployeeManagement()); }
        private void panelTop_Paint(object sender, PaintEventArgs e) { }
        private void dashvisualtxtsales_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void button7_Click(object sender, EventArgs e) { LoadContent(new HrAttendance()); }
        private void hrpayrollbtn_Click(object sender, EventArgs e) { LoadContent(new HrPayrollMain()); }
        private void hrleavetimeoffbtn_Click(object sender, EventArgs e) { LoadContent(new HrLeave()); }
        private void hrcompliancepoliciesbtn_Click(object sender, EventArgs e) { LoadContent(new HrCompliances()); }
        private void hrreportsanalyticsbtn_Click(object sender, EventArgs e) { LoadContent(new HrReports()); }
        private void button9_Click(object sender, EventArgs e) { LoadDashboard(); }
        private void dashtotalsales_Paint(object sender, PaintEventArgs e) { }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
        private void hrdashboardemployeeheadcounttxt_TextChanged(object sender, EventArgs e) { }
        private void hrdashboardleavecontractstxt_TextChanged(object sender, EventArgs e) { }
        private void userwelcome_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void hrdashboardemployeeheadcounttxt_TextChanged_1(object sender, EventArgs e) { }

        private void hrdate_Click(object sender, EventArgs e)
        {

        }

        private void hrrefresh_Click(object sender, EventArgs e)
        {
            RefreshUI();
        }
        private void RefreshIcon_Click(object sender, EventArgs e)
        {
            RefreshUI();
        }
        private void RefreshUI()
        {

            this.Hide();
            HrDashboard newForm = new HrDashboard();
            newForm.Show();
            this.Close();

        }
    }
}
