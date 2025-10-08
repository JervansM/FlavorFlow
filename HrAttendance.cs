using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FlavorFlowIT13
{
    public partial class HrAttendance : Form
    {
        private readonly string connectionString = "Data Source=DESKTOP-2SPCOE3;Initial Catalog=FlavorFlow;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        // ✅ Cache the schedule form to prevent recreation
        private HrSchedule cachedScheduleForm = null;

        public HrAttendance()
        {
            InitializeComponent();
            this.Load += HrAttendance_Load;

            // ✅ Enable double buffering to reduce flickering
            this.DoubleBuffered = true;
            SetDoubleBuffered(dgvAttendance);
        }

        private void SetDoubleBuffered(Control control)
        {
            if (control != null)
            {
                typeof(Control).InvokeMember("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                    null, control, new object[] { true });
            }
        }

        private void HrAttendance_Load(object sender, EventArgs e)
        {
            LoadAttendance();
        }

        // 🔹 Load attendance data
        private void LoadAttendance()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            CONCAT(E.FirstName, ' ', E.LastName) AS EmployeeName,
                            S.Name AS ShiftName,
                            A.Date,
                            A.TimeIn,
                            A.TimeOut,
                            A.Status
                        FROM Attendance A
                        INNER JOIN Employee E ON A.EmployeeID = E.EmployeeID
                        LEFT JOIN Shift S ON A.ShiftID = S.ShiftID
                        ORDER BY A.Date DESC, A.TimeIn DESC;";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAttendance.DataSource = dt;

                    StyleAttendanceGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance data: " + ex.Message);
            }
        }

        // 🔹 Daily attendance button
        private void hrdailyattendancebtn_Click(object sender, EventArgs e)
        {
            LoadAttendance();
        }

        // ✅ IMPROVED: Smooth switching to schedule without flickering
        private void hrattendanceschedulebtn_Click(object sender, EventArgs e)
        {
            LoadContent();
        }

        private void hrattendancedailyttendancebtn_Click(object sender, EventArgs e)
        {
            LoadAttendance();
        }

        // ✅ NEW: Optimized content loading - reuse existing form
        private void LoadContent()
        {
            if (panelContent == null) return;

            // Create schedule form only once
            if (cachedScheduleForm == null || cachedScheduleForm.IsDisposed)
            {
                cachedScheduleForm = new HrSchedule();
                cachedScheduleForm.TopLevel = false;
                cachedScheduleForm.FormBorderStyle = FormBorderStyle.None;
                cachedScheduleForm.Dock = DockStyle.Fill;
                panelContent.Controls.Add(cachedScheduleForm);
            }

            // Just bring it to front and show, don't recreate
            cachedScheduleForm.BringToFront();
            cachedScheduleForm.Show();
        }

        // 🔹 Open add attendance form
        private void addnewattendanebtn_Click(object sender, EventArgs e)
        {
            OpenAddAttendanceForm();
        }

        private void OpenAddAttendanceForm()
        {
            addnewattendanceform addForm = new addnewattendanceform();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadAttendance();
            }
        }

        // ✅ NEW: Validate if employee already has attendance for the given date
        public bool HasAttendanceForDate(int employeeId, DateTime date)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT COUNT(*) 
                        FROM Attendance 
                        WHERE EmployeeID = @EmployeeID 
                        AND CAST(Date AS DATE) = @Date";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                        cmd.Parameters.AddWithValue("@Date", date.Date);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking attendance: " + ex.Message);
                return false;
            }
        }

        // ✅ NEW: Validate date is not in the future
        public bool IsValidAttendanceDate(DateTime date, out string errorMessage)
        {
            errorMessage = string.Empty;
            DateTime today = DateTime.Today;

            if (date.Date > today)
            {
                errorMessage = "Cannot add attendance for future dates. Please select today or a past date.";
                return false;
            }

            return true;
        }

        // ✅ NEW: Normalize past dates to today
        public DateTime NormalizeDateToToday(DateTime selectedDate)
        {
            DateTime today = DateTime.Today;

            // If selected date is in the past, return today's date
            if (selectedDate.Date < today)
            {
                return today;
            }

            return selectedDate;
        }

        // ✅ Style DataGridView with dark theme matching schedule grid
        private void StyleAttendanceGrid()
        {
            // Make grid read-only (non-editable)
            dgvAttendance.ReadOnly = true;
            dgvAttendance.AllowUserToAddRows = false;
            dgvAttendance.AllowUserToDeleteRows = false;
            dgvAttendance.EditMode = DataGridViewEditMode.EditProgrammatically;

            // Apply dark theme styling
            dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAttendance.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvAttendance.ForeColor = Color.White;
            dgvAttendance.GridColor = Color.Gray;

            // Cell styling
            dgvAttendance.DefaultCellStyle.BackColor = Color.FromArgb(62, 62, 66);
            dgvAttendance.DefaultCellStyle.ForeColor = Color.White;
            dgvAttendance.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dgvAttendance.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dgvAttendance.DefaultCellStyle.SelectionForeColor = Color.White;

            // Header styling
            dgvAttendance.EnableHeadersVisualStyles = false;
            dgvAttendance.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 140, 105);
            dgvAttendance.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvAttendance.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            dgvAttendance.ColumnHeadersHeight = 30;

            // Selection and layout
            dgvAttendance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAttendance.MultiSelect = false;
            dgvAttendance.RowHeadersVisible = false;
            dgvAttendance.BorderStyle = BorderStyle.None;

            // Alternating row colors for better readability
            dgvAttendance.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(52, 52, 56);
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}