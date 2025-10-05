using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FlavorFlowIT13
{
    public partial class DashboardControl : UserControl
    {
        private readonly string connectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public DashboardControl()
        {
            InitializeComponent();
            this.Load += DashboardControl_Load;
        }

        private void DashboardControl_Load(object sender, EventArgs e)
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
                    // Example: Count approved leave contracts
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
                    // Example: Count pending leave requests
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
                    // Example: Count employees marked present today
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

        private void hrdashboardemployeeheadcounttxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void hrdashboardleavecontractstxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void hrdashboardattendancetodaytxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void dashtotalsales_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
