using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FlavorFlowIT13
{
    public partial class HrAttendance : Form
    {
        private readonly string connectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";


        public HrAttendance()
        {
            InitializeComponent();
            this.Load += HrAttendance_Load;
        }

        private void HrAttendance_Load(object sender, EventArgs e)
        {
            LoadAttendance();
        }

        // 🔹 Load attendance data from your database
        private void LoadAttendance()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
SELECT 
    A.AttendanceID,
    E.EmployeeID,
    CONCAT(E.FirstName, ' ', E.LastName) AS EmployeeName,
    S.Name AS ShiftName,
    S.StartTime,
    S.EndTime,
    A.Date,
    A.TimeIn,
    A.TimeOut,
    A.Status
FROM Attendance A
INNER JOIN Employee E ON A.EmployeeID = E.EmployeeID
LEFT JOIN ShiftSchedule SS ON E.EmployeeID = SS.EmployeeID
LEFT JOIN Shift S ON SS.ShiftID = S.ShiftID
WHERE A.Date BETWEEN SS.EffectiveDate AND SS.ExpiryDate
ORDER BY A.Date DESC;
";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAttendance.DataSource = dt;
                }

                // ✅ Style DataGridView
                dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvAttendance.DefaultCellStyle.ForeColor = Color.Black;
                dgvAttendance.DefaultCellStyle.BackColor = Color.White;
                dgvAttendance.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                dgvAttendance.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvAttendance.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance data: " + ex.Message);
            }
        }

        // 🔹 Save edits made in Time In / Time Out columns
        private void dgvAttendance_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvAttendance.Columns[e.ColumnIndex].HeaderText == "Time In" ||
                    dgvAttendance.Columns[e.ColumnIndex].HeaderText == "Time Out")
                {
                    string scheduleId = dgvAttendance.Rows[e.RowIndex].Cells["Schedule ID"].Value.ToString();
                    string timeIn = dgvAttendance.Rows[e.RowIndex].Cells["Time In"].Value?.ToString();
                    string timeOut = dgvAttendance.Rows[e.RowIndex].Cells["Time Out"].Value?.ToString();

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string updateQuery = "UPDATE ShiftSchedule SET ShiftStart = @timeIn, ShiftEnd = @timeOut WHERE ShiftScheduleID = @id";
                        SqlCommand cmd = new SqlCommand(updateQuery, conn);
                        cmd.Parameters.AddWithValue("@timeIn", string.IsNullOrEmpty(timeIn) ? DBNull.Value : (object)timeIn);
                        cmd.Parameters.AddWithValue("@timeOut", string.IsNullOrEmpty(timeOut) ? DBNull.Value : (object)timeOut);
                        cmd.Parameters.AddWithValue("@id", scheduleId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving edited attendance: " + ex.Message);
            }
        }

        // 🔹 Reload attendance when "Daily Attendance" button is clicked
        private void hrdailyattendancebtn_Click(object sender, EventArgs e)
        {
            LoadAttendance();
        }

        // 🔹 Open the schedule view
        private void hrschedulebtn_Click(object sender, EventArgs e)
        {
            LoadContent(new HrSchedule());
        }

        // 🔹 Reuse existing content loading logic
        private void LoadContent(Form form)
        {
            foreach (Control ctrl in panelContent.Controls)
                ctrl.Dispose();

            panelContent.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContent.Controls.Add(form);
            form.Show();
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hrattendanceschedulebtn_Click(object sender, EventArgs e)
        {
            LoadContent(new HrSchedule());
        }

        private void hrattendancedailyttendancebtn_Click(object sender, EventArgs e)
        {
            LoadContent(new HrAttendance());

        }

        private void HrAttendance_Load_1(object sender, EventArgs e)
        {

        }
    }
}
