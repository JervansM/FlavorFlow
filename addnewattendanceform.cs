using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FlavorFlowIT13
{
    public partial class addnewattendanceform : Form
    {
        private readonly string connectionString = "Data Source=DESKTOP-2SPCOE3;Initial Catalog=FlavorFlow;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        // Controls
        private ComboBox cmbEmployee;
        private ComboBox cmbShift;
        private TextBox txtRole;
        private DateTimePicker dtpDate;
        private DateTimePicker dtpTimeIn;
        private DateTimePicker dtpTimeOut;
        private ComboBox cmbStatus;
        private Button btnSave;
        private Button btnCancel;

        public addnewattendanceform()
        {
            InitializeComponent();
            InitializeCustomControls();
            this.Load += addnewattendanceform_Load;
        }

        private void InitializeCustomControls()
        {
            this.Text = "Add New Attendance";
            this.Size = new Size(500, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            int labelX = 30, controlX = 180, startY = 30, gap = 50;

            // Employee
            this.Controls.Add(new Label { Text = "Employee:", Location = new Point(labelX, startY), Size = new Size(140, 25), Font = new Font("Segoe UI", 10F, FontStyle.Bold) });
            cmbEmployee = new ComboBox { Location = new Point(controlX, startY), Size = new Size(270, 25), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 10F) };
            cmbEmployee.SelectedIndexChanged += CmbEmployee_SelectedIndexChanged;
            this.Controls.Add(cmbEmployee);

            // Role
            this.Controls.Add(new Label { Text = "Role:", Location = new Point(labelX, startY + gap), Size = new Size(140, 25), Font = new Font("Segoe UI", 10F, FontStyle.Bold) });
            txtRole = new TextBox { Location = new Point(controlX, startY + gap), Size = new Size(270, 25), Font = new Font("Segoe UI", 10F), ReadOnly = true };
            this.Controls.Add(txtRole);

            // Shift
            this.Controls.Add(new Label { Text = "Shift:", Location = new Point(labelX, startY + gap * 2), Size = new Size(140, 25), Font = new Font("Segoe UI", 10F, FontStyle.Bold) });
            cmbShift = new ComboBox { Location = new Point(controlX, startY + gap * 2), Size = new Size(270, 25), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 10F) };
            this.Controls.Add(cmbShift);

            // Date
            this.Controls.Add(new Label { Text = "Date:", Location = new Point(labelX, startY + gap * 3), Size = new Size(140, 25), Font = new Font("Segoe UI", 10F, FontStyle.Bold) });
            dtpDate = new DateTimePicker { Location = new Point(controlX, startY + gap * 3), Size = new Size(270, 25), Format = DateTimePickerFormat.Short, Font = new Font("Segoe UI", 10F), MaxDate = DateTime.Today };
            dtpDate.ValueChanged += DtpDate_ValueChanged;
            this.Controls.Add(dtpDate);

            // Time In
            this.Controls.Add(new Label { Text = "Time In:", Location = new Point(labelX, startY + gap * 4), Size = new Size(140, 25), Font = new Font("Segoe UI", 10F, FontStyle.Bold) });
            dtpTimeIn = new DateTimePicker { Location = new Point(controlX, startY + gap * 4), Size = new Size(270, 25), Format = DateTimePickerFormat.Custom, CustomFormat = "hh:mm tt", ShowUpDown = true, Font = new Font("Segoe UI", 10F) };
            this.Controls.Add(dtpTimeIn);

            // Time Out
            this.Controls.Add(new Label { Text = "Time Out:", Location = new Point(labelX, startY + gap * 5), Size = new Size(140, 25), Font = new Font("Segoe UI", 10F, FontStyle.Bold) });
            dtpTimeOut = new DateTimePicker { Location = new Point(controlX, startY + gap * 5), Size = new Size(270, 25), Format = DateTimePickerFormat.Custom, CustomFormat = "hh:mm tt", ShowUpDown = true, Font = new Font("Segoe UI", 10F) };
            this.Controls.Add(dtpTimeOut);

            // Status
            this.Controls.Add(new Label { Text = "Status:", Location = new Point(labelX, startY + gap * 6), Size = new Size(140, 25), Font = new Font("Segoe UI", 10F, FontStyle.Bold) });
            cmbStatus = new ComboBox { Location = new Point(controlX, startY + gap * 6), Size = new Size(270, 25), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 10F) };
            cmbStatus.Items.AddRange(new object[] { "Present", "Absent", "Late", "Half Day" });
            cmbStatus.SelectedIndex = 0;
            this.Controls.Add(cmbStatus);

            // Buttons
            btnSave = new Button { Text = "Save", Location = new Point(250, startY + gap * 7), Size = new Size(100, 35), BackColor = Color.FromArgb(76, 175, 80), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            btnCancel = new Button { Text = "Cancel", Location = new Point(360, startY + gap * 7), Size = new Size(100, 35), BackColor = Color.FromArgb(244, 67, 54), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += BtnCancel_Click;
            this.Controls.Add(btnCancel);
        }

        private void addnewattendanceform_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            LoadShifts();
            // Set date to today by default
            dtpDate.Value = DateTime.Today;
        }

        // ✅ NEW: Validate and restrict date selection
        private void DtpDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpDate.Value.Date;
            DateTime today = DateTime.Today;

            // If user tries to select a future date, reset to today
            if (selectedDate > today)
            {
                dtpDate.Value = today;
                MessageBox.Show("Cannot select future dates. Attendance can only be added for today or past dates.",
                    "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadEmployees()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT EmployeeID, CONCAT(FirstName, ' ', LastName) AS FullName FROM Employee ORDER BY FirstName";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbEmployee.DisplayMember = "FullName";
                    cmbEmployee.ValueMember = "EmployeeID";
                    cmbEmployee.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading employees: " + ex.Message); }
        }

        private void LoadShifts()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ShiftID, Name, CONCAT(Name, ' (', FORMAT(StartTime,'hh:mm tt'), ' - ', FORMAT(EndTime,'hh:mm tt'),')') AS ShiftDisplay FROM Shift ORDER BY Name";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbShift.DisplayMember = "ShiftDisplay";
                    cmbShift.ValueMember = "ShiftID";
                    cmbShift.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading shifts: " + ex.Message); }
        }

        private void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedValue == null || cmbEmployee.SelectedValue is DataRowView) return;
            int employeeId = Convert.ToInt32(cmbEmployee.SelectedValue);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Load Role
                    using (SqlCommand cmd = new SqlCommand("SELECT Position FROM Employee WHERE EmployeeID=@EmployeeID", conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                        object role = cmd.ExecuteScalar();
                        txtRole.Text = role != null ? role.ToString() : "N/A";
                    }

                    // Auto-select latest shift
                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 ShiftID FROM ShiftSchedule WHERE EmployeeID=@EmployeeID ORDER BY EffectiveDate DESC", conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                        object shift = cmd.ExecuteScalar();
                        if (shift != null) cmbShift.SelectedValue = shift;
                        else cmbShift.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading employee data: " + ex.Message); }
        }

        // ✅ NEW: Check if employee already has attendance for the selected date
        private bool HasAttendanceForDate(int employeeId, DateTime date)
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (cmbEmployee.SelectedValue == null || cmbShift.SelectedValue == null)
            {
                MessageBox.Show("Please select employee and shift.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int employeeId = Convert.ToInt32(cmbEmployee.SelectedValue);
            DateTime selectedDate = dtpDate.Value.Date;
            DateTime today = DateTime.Today;

            // ✅ VALIDATION 1: Prevent future dates
            if (selectedDate > today)
            {
                MessageBox.Show("Cannot add attendance for future dates. Please select today or a past date.",
                    "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDate.Value = today;
                return;
            }

            // ✅ VALIDATION 2: Check for duplicate attendance
            if (HasAttendanceForDate(employeeId, selectedDate))
            {
                string employeeName = cmbEmployee.Text;
                MessageBox.Show($"{employeeName} already has an attendance record for {selectedDate:MMMM dd, yyyy}.\n\nEach employee can only have one attendance entry per day.",
                    "Duplicate Attendance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ VALIDATION 3: Ensure TimeOut is after TimeIn
            if (dtpTimeOut.Value.TimeOfDay <= dtpTimeIn.Value.TimeOfDay)
            {
                MessageBox.Show("Time Out must be after Time In.", "Invalid Time",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // All validations passed, save attendance
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Attendance (EmployeeID, ShiftID, Date, TimeIn, TimeOut, Status)
                                     VALUES (@EmployeeID, @ShiftID, @Date, @TimeIn, @TimeOut, @Status)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                    cmd.Parameters.AddWithValue("@ShiftID", cmbShift.SelectedValue);
                    cmd.Parameters.AddWithValue("@Date", selectedDate);
                    cmd.Parameters.AddWithValue("@TimeIn", dtpTimeIn.Value.TimeOfDay);
                    cmd.Parameters.AddWithValue("@TimeOut", dtpTimeOut.Value.TimeOfDay);
                    cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Attendance added successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 2627 || sqlEx.Number == 2601) // Duplicate key error
                {
                    MessageBox.Show("This attendance record already exists in the database.",
                        "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Database error: " + sqlEx.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving attendance: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}