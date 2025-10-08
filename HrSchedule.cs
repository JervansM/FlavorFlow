using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FlavorFlowIT13
{
    public partial class HrSchedule : Form
    {
        private string connectionString = "Data Source=DESKTOP-2SPCOE3;Initial Catalog=FlavorFlow;Integrated Security=True;TrustServerCertificate=True";

        public HrSchedule()
        {
            InitializeComponent();
        }

        private void HrSchedule_Load(object sender, EventArgs e)
        {
            LoadSchedule();
            // Ensure the Add New Schedule button is visible
            if (addnewschedulebtn != null)
                addnewschedulebtn.Visible = true;
        }

        private void LoadSchedule()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            ss.ScheduleID,
                            e.FirstName + ' ' + e.LastName AS EmployeeName,
                            e.Position AS Role,
                            sh.Name AS ShiftName,
                            sh.StartTime,
                            sh.EndTime,
                            ss.EffectiveDate,
                            ss.ExpiryDate
                        FROM ShiftSchedule ss
                        INNER JOIN Employee e ON ss.EmployeeID = e.EmployeeID
                        INNER JOIN Shift sh ON ss.ShiftID = sh.ShiftID
                        ORDER BY ss.EffectiveDate DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    scheduleGrid.DataSource = dt;

                    // Apply dark theme styling
                    StyleScheduleGrid();
                }

                // Show Add New Schedule button when viewing schedules
                if (addnewschedulebtn != null)
                    addnewschedulebtn.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading schedule: " + ex.Message);
            }
        }

        // ✅ NEW: Check if employee can have a new shift assignment
        public bool CanAssignNewShift(int employeeId, DateTime effectiveDate, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Get the current year
                    int year = effectiveDate.Year;
                    DateTime yearStart = new DateTime(year, 1, 1);
                    DateTime yearEnd = new DateTime(year, 12, 31);

                    // Count how many shifts this employee has in the current year
                    string countQuery = @"
                        SELECT COUNT(*) 
                        FROM ShiftSchedule 
                        WHERE EmployeeID = @EmployeeID 
                        AND YEAR(EffectiveDate) = @Year";

                    int shiftCount;
                    using (SqlCommand cmd = new SqlCommand(countQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                        cmd.Parameters.AddWithValue("@Year", year);
                        shiftCount = (int)cmd.ExecuteScalar();
                    }

                    // If employee already has 2 shifts this year, deny
                    if (shiftCount >= 2)
                    {
                        errorMessage = $"This employee already has 2 shift assignments in {year}. An employee can only change shifts once per year (maximum 2 shifts per year).";
                        return false;
                    }

                    // If this is the second shift (shift change), check 6-month gap
                    if (shiftCount == 1)
                    {
                        string lastShiftQuery = @"
                            SELECT TOP 1 EffectiveDate 
                            FROM ShiftSchedule 
                            WHERE EmployeeID = @EmployeeID 
                            AND YEAR(EffectiveDate) = @Year
                            ORDER BY EffectiveDate DESC";

                        DateTime lastShiftDate;
                        using (SqlCommand cmd = new SqlCommand(lastShiftQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                            cmd.Parameters.AddWithValue("@Year", year);
                            lastShiftDate = (DateTime)cmd.ExecuteScalar();
                        }

                        // Calculate difference in months
                        int monthsDifference = ((effectiveDate.Year - lastShiftDate.Year) * 12) + effectiveDate.Month - lastShiftDate.Month;

                        if (monthsDifference < 6)
                        {
                            DateTime earliestChangeDate = lastShiftDate.AddMonths(6);
                            errorMessage = $"Shift changes require a 6-month gap. This employee's last shift started on {lastShiftDate:MMMM dd, yyyy}. The earliest they can change shifts is {earliestChangeDate:MMMM dd, yyyy}.";
                            return false;
                        }
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Error validating shift assignment: " + ex.Message;
                return false;
            }
        }

        // ✅ NEW: Get employee's shift history for a year
        public DataTable GetEmployeeShiftHistory(int employeeId, int year)
        {
            DataTable dt = new DataTable();
            string connectionString = "Data Source=DESKTOP-2SPCOE3;Initial Catalog=FlavorFlow;Integrated Security=True;TrustServerCertificate=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    s.ScheduleID,
                    sh.Name AS ShiftName,
                    s.EffectiveDate,
                    s.ExpiryDate,
                    DATEDIFF(MONTH, s.EffectiveDate, ISNULL(s.ExpiryDate, GETDATE())) AS DurationMonths
                FROM ShiftSchedule s
                INNER JOIN Shift sh ON s.ShiftID = sh.ShiftID
                WHERE s.EmployeeID = @EmployeeID
                  AND YEAR(s.EffectiveDate) = @Year
                ORDER BY s.EffectiveDate DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@EmployeeID", employeeId);
                    da.SelectCommand.Parameters.AddWithValue("@Year", year);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving shift history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }


        // ✅ NEW: Check if an employee already has an active shift
        public bool HasActiveShift(int employeeId, DateTime effectiveDate, out int? activeShiftId)
        {
            activeShiftId = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT ScheduleID 
                        FROM ShiftSchedule 
                        WHERE EmployeeID = @EmployeeID 
                        AND EffectiveDate <= @EffectiveDate 
                        AND (ExpiryDate IS NULL OR ExpiryDate >= @EffectiveDate)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                        cmd.Parameters.AddWithValue("@EffectiveDate", effectiveDate);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            activeShiftId = Convert.ToInt32(result);
                            return true;
                        }

                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking active shift: " + ex.Message);
                return false;
            }
        }

        // ✅ Style DataGridView with dark theme
        private void StyleScheduleGrid()
        {
            // Make grid read-only (non-editable)
            scheduleGrid.ReadOnly = true;
            scheduleGrid.AllowUserToAddRows = false;
            scheduleGrid.AllowUserToDeleteRows = false;
            scheduleGrid.EditMode = DataGridViewEditMode.EditProgrammatically;

            // Apply dark theme styling
            scheduleGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            scheduleGrid.BackgroundColor = Color.FromArgb(45, 45, 48);
            scheduleGrid.ForeColor = Color.White;
            scheduleGrid.GridColor = Color.Gray;

            // Cell styling
            scheduleGrid.DefaultCellStyle.BackColor = Color.FromArgb(62, 62, 66);
            scheduleGrid.DefaultCellStyle.ForeColor = Color.White;
            scheduleGrid.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            scheduleGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            scheduleGrid.DefaultCellStyle.SelectionForeColor = Color.White;

            // Header styling
            scheduleGrid.EnableHeadersVisualStyles = false;
            scheduleGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 140, 105);
            scheduleGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            scheduleGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            scheduleGrid.ColumnHeadersHeight = 30;

            // Selection and layout
            scheduleGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            scheduleGrid.MultiSelect = false;
            scheduleGrid.RowHeadersVisible = false;
            scheduleGrid.BorderStyle = BorderStyle.None;

            // Alternating row colors for better readability
            scheduleGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(52, 52, 56);
        }

        private void hrscheduleschedulebtn_Click(object sender, EventArgs e)
        {
            LoadSchedule();
        }

        // ✅ Navigate to HrAttendance form
        private void hrscheduledailyttendancebtn_Click(object sender, EventArgs e)
        {
            NavigateToAttendance();
        }

        private void hrscheduledailyttendancebtn_Click_1(object sender, EventArgs e)
        {
            NavigateToAttendance();
        }

        // ✅ Method to navigate back to HrAttendance
        private void NavigateToAttendance()
        {
            // Find the parent panel that contains this form
            Panel parentPanel = this.Parent as Panel;
            if (parentPanel != null)
            {
                // Clear the panel and load HrAttendance
                foreach (Control ctrl in parentPanel.Controls)
                    ctrl.Dispose();

                parentPanel.Controls.Clear();

                HrAttendance attendanceForm = new HrAttendance();
                attendanceForm.TopLevel = false;
                attendanceForm.FormBorderStyle = FormBorderStyle.None;
                attendanceForm.Dock = DockStyle.Fill;
                parentPanel.Controls.Add(attendanceForm);
                attendanceForm.Show();
            }
            else
            {
                // If not embedded in a panel, open as a new form
                HrAttendance attendanceForm = new HrAttendance();
                attendanceForm.Show();
                this.Close();
            }
        }



        // ✅ Add New Schedule button implementation
        private void addnewschedulebtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add New Schedule button clicked!\n\nNote: Employees can have maximum 2 shifts per year, with a 6-month gap between shift changes.");
            // TODO: Open a form or dialog for creating a new schedule
            // Example:
            // AddScheduleForm addForm = new AddScheduleForm();
            // if (addForm.ShowDialog() == DialogResult.OK)
            // {
            //     LoadSchedule(); // Refresh the schedule grid
            // }
        }

        private void addnewschedulebtn_Click_1(object sender, EventArgs e)
        {
            addnewschedulebtn_Click(sender, e);
        }

        private void scheduleGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell clicks if needed
        }

        private void panelContent_Paint_1(object sender, PaintEventArgs e)
        {
            // Optional: visual styling
        }

        private void systempanelcontents_Paint(object sender, PaintEventArgs e)
        {
            // Optional: visual styling
        }

        private void addnewschedulebtn_Click_2(object sender, EventArgs e)
        {
            AddNewScheduleForm addForm = new AddNewScheduleForm();
            addForm.Owner = this; // ✅ This is the key line!
            addForm.ShowDialog(); // opens modally
        }

        private void scheduleGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}