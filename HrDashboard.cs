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

      
    }
}
