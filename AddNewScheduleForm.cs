using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FlavorFlowIT13
{
    public partial class AddNewScheduleForm : Form
    {
        private readonly string connectionString = "Data Source=DESKTOP-2SPCOE3;Initial Catalog=FlavorFlow;Integrated Security=True;TrustServerCertificate=True";

        // Controls
        private ComboBox cmbEmployee;
        private TextBox txtRole;
        private ComboBox cmbShift;
        private DateTimePicker dtpEffectiveDate;
        private DateTimePicker dtpExpiryDate;
        private CheckBox chkNoExpiryDate;
        private Button btnSave;
        private Button btnCancel;
        private Button btnViewHistory;
        private Label lblShiftInfo;

        public AddNewScheduleForm()
        {
            InitializeComponent();
            InitializeCustomControls();
            this.Load += AddScheduleForm_Load;
        }

        private void InitializeCustomControls()
        {
            this.Text = "Add New Schedule";
            this.Size = new Size(550, 550);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            int labelX = 30, controlX = 180, startY = 30, gap = 55;

            // Employee
            this.Controls.Add(new Label { Text = "Employee:", Location = new Point(labelX, startY), Size = new Size(140, 25), Font = new Font("Segoe UI", 10F, FontStyle.Bold) });
            cmbEmployee = new ComboBox { Location = new Point(controlX, startY), Size = new Size(320, 25), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 10F) };
            cmbEmployee.SelectedIndexChanged += CmbEmployee_SelectedIndexChanged;
            this.Controls.Add(cmbEmployee);

            // Role (Read-only)
            this.Controls.Add(new Label { Text = "Role:", Location = new Point(labelX, startY + gap), Size = new Size(140, 25), Font = new Font("Segoe UI", 10F, FontStyle.Bold) });
            txtRole = new TextBox { Location = new Point(controlX, startY + gap), Size = new Size(320, 25), Font = new Font("Segoe UI", 10F), ReadOnly = true, BackColor = Color.LightGray };
            this.Controls.Add(txtRole);

            // Shift
            this.Controls.Add(new Label { Text = "Shift:", Location = new Point(labelX, startY + gap * 2), Size = new Size(140, 25), Font = new Font("Segoe UI", 10F, FontStyle.Bold) });
            cmbShift = new ComboBox { Location = new Point(controlX, startY + gap * 2), Size = new Size(320, 25), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 10F) };
            this.Controls.Add(cmbShift);

            // Effective Date
            this.Controls.Add(new Label { Text = "Effective Date:", Location = new Point(labelX, startY + gap * 3), Size = new Size(140, 25), Font = new Font("Segoe UI", 10F, FontStyle.Bold) });
            dtpEffectiveDate = new DateTimePicker { Location = new Point(controlX, startY + gap * 3), Size = new Size(320, 25), Format = DateTimePickerFormat.Short, Font = new Font("Segoe UI", 10F) };
            dtpEffectiveDate.ValueChanged += DtpEffectiveDate_ValueChanged;
            this.Controls.Add(dtpEffectiveDate);

            // Expiry Date
            this.Controls.Add(new Label { Text = "Expiry Date:", Location = new Point(labelX, startY + gap * 4), Size = new Size(140, 25), Font = new Font("Segoe UI", 10F, FontStyle.Bold) });
            dtpExpiryDate = new DateTimePicker { Location = new Point(controlX, startY + gap * 4), Size = new Size(320, 25), Format = DateTimePickerFormat.Short, Font = new Font("Segoe UI", 10F) };
            this.Controls.Add(dtpExpiryDate);

            // No Expiry Date Checkbox
            chkNoExpiryDate = new CheckBox { Text = "No Expiry Date (Ongoing)", Location = new Point(controlX, startY + gap * 5), Size = new Size(320, 25), Font = new Font("Segoe UI", 9F) };
            chkNoExpiryDate.CheckedChanged += ChkNoExpiryDate_CheckedChanged;
            this.Controls.Add(chkNoExpiryDate);

            // Shift Information Label
            lblShiftInfo = new Label
            {
                Text = "ℹ️ Employees can have maximum 2 shifts per year.\nShift changes require a 6-month gap.",
                Location = new Point(30, startY + gap * 6),
                Size = new Size(490, 40),
                Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                ForeColor = Color.DarkBlue,
                BackColor = Color.LightYellow,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5)
            };
            this.Controls.Add(lblShiftInfo);

            // View History Button
            btnViewHistory = new Button
            {
                Text = "View Shift History",
                Location = new Point(30, startY + gap * 7),
                Size = new Size(150, 35),
                BackColor = Color.FromArgb(33, 150, 243),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F)
            };
            btnViewHistory.FlatAppearance.BorderSize = 0;
            btnViewHistory.Click += BtnViewHistory_Click;
            this.Controls.Add(btnViewHistory);

            // Save Button
            btnSave = new Button
            {
                Text = "Save Schedule",
                Location = new Point(300, startY + gap * 7),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            // Cancel Button
            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(430, startY + gap * 7),
                Size = new Size(90, 35),
                BackColor = Color.FromArgb(244, 67, 54),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F)
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += BtnCancel_Click;
            this.Controls.Add(btnCancel);
        }

        private void AddScheduleForm_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            LoadShifts();
            dtpEffectiveDate.Value = DateTime.Today;
            dtpExpiryDate.Value = DateTime.Today.AddMonths(6);
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
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employees: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            catch (Exception ex)
            {
                MessageBox.Show("Error loading shifts: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    using (SqlCommand cmd = new SqlCommand("SELECT Position FROM Employee WHERE EmployeeID=@EmployeeID", conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                        object role = cmd.ExecuteScalar();
                        txtRole.Text = role != null ? role.ToString() : "N/A";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChkNoExpiryDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpExpiryDate.Enabled = !chkNoExpiryDate.Checked;
        }

        private void DtpEffectiveDate_ValueChanged(object sender, EventArgs e)
        {
            // Automatically set expiry date to 6 months later
            if (!chkNoExpiryDate.Checked)
            {
                dtpExpiryDate.Value = dtpEffectiveDate.Value.AddMonths(6);
            }
        }

        private void BtnViewHistory_Click(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedValue == null || cmbEmployee.SelectedValue is DataRowView)
            {
                MessageBox.Show("Please select an employee first.", "No Employee Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int employeeId = Convert.ToInt32(cmbEmployee.SelectedValue);
            int year = dtpEffectiveDate.Value.Year;

            HrSchedule scheduleForm = this.Owner as HrSchedule;
            if (scheduleForm != null)
            {
                DataTable history = scheduleForm.GetEmployeeShiftHistory(employeeId, year);
                if (history != null && history.Rows.Count > 0)
                {
                    string message = $"Shift History for {cmbEmployee.Text} in {year}:\n\n";
                    foreach (DataRow row in history.Rows)
                    {
                        message += $"• {row["ShiftName"]} - Effective: {Convert.ToDateTime(row["EffectiveDate"]):MMM dd, yyyy}";
                        if (row["ExpiryDate"] != DBNull.Value)
                            message += $" to {Convert.ToDateTime(row["ExpiryDate"]):MMM dd, yyyy}";
                        else
                            message += " (Ongoing)";
                        message += $"\n  Duration: {row["DurationMonths"]} months\n\n";
                    }
                    MessageBox.Show(message, "Shift History", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"No shift history found for {cmbEmployee.Text} in {year}.", "No History", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (cmbEmployee.SelectedValue == null || cmbShift.SelectedValue == null)
            {
                MessageBox.Show("Please select both employee and shift.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int employeeId = Convert.ToInt32(cmbEmployee.SelectedValue);
            int shiftId = Convert.ToInt32(cmbShift.SelectedValue);
            DateTime effectiveDate = dtpEffectiveDate.Value.Date;
            DateTime? expiryDate = chkNoExpiryDate.Checked ? (DateTime?)null : dtpExpiryDate.Value.Date;

            // Validate expiry date if provided
            if (expiryDate.HasValue && expiryDate.Value <= effectiveDate)
            {
                MessageBox.Show("Expiry date must be after the effective date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ VALIDATION 1: Check if employee can have a new shift (2 per year max, 6-month gap)
            HrSchedule scheduleForm = this.Owner as HrSchedule;
            if (scheduleForm != null)
            {
                string errorMessage;
                if (!scheduleForm.CanAssignNewShift(employeeId, effectiveDate, out errorMessage))
                {
                    MessageBox.Show(errorMessage, "Shift Assignment Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ VALIDATION 2: Check for overlapping shifts
                int? activeShiftId;
                if (scheduleForm.HasActiveShift(employeeId, effectiveDate, out activeShiftId))
                {
                    DialogResult result = MessageBox.Show(
                        $"This employee has an active shift on the selected date.\n\nWould you like to end the current shift and start the new one?",
                        "Overlapping Shift Detected",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // End the previous shift one day before the new effective date
                        EndPreviousShift(activeShiftId.Value, effectiveDate.AddDays(-1));
                    }
                    else
                    {
                        return;
                    }
                }
            }

            // Save the new schedule
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO ShiftSchedule (EmployeeID, ShiftID, EffectiveDate, ExpiryDate)
                                     VALUES (@EmployeeID, @ShiftID, @EffectiveDate, @ExpiryDate)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                    cmd.Parameters.AddWithValue("@ShiftID", shiftId);
                    cmd.Parameters.AddWithValue("@EffectiveDate", effectiveDate);
                    cmd.Parameters.AddWithValue("@ExpiryDate", (object)expiryDate ?? DBNull.Value);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Schedule added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving schedule: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EndPreviousShift(int scheduleId, DateTime endDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE ShiftSchedule SET ExpiryDate = @ExpiryDate WHERE ScheduleID = @ScheduleID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ExpiryDate", endDate);
                    cmd.Parameters.AddWithValue("@ScheduleID", scheduleId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ending previous shift: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}