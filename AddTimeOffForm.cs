using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FlavorFlowIT13
{
    public partial class AddTimeOffForm : Form
    {
        private readonly string connectionString = "Data Source=DESKTOP-2SPCOE3;Initial Catalog=FlavorFlow;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        private ComboBox cmbEmployee;
        private DateTimePicker dtpDate;
        private ComboBox cmbDuration;
        private TextBox txtReason;
        private ComboBox cmbStatus;
        private Button btnSave;
        private Button btnCancel;

        public AddTimeOffForm()
        {
            InitializeComponent();
            SetupForm();
            LoadEmployees();
        }

      

        private void SetupForm()
        {
            // Employee Label and ComboBox
            Label lblEmployee = new Label
            {
                Text = "Employee:",
                Location = new Point(30, 30),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 10F)
            };
            this.Controls.Add(lblEmployee);

            cmbEmployee = new ComboBox
            {
                Location = new Point(160, 30),
                Size = new Size(300, 25),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F)
            };
            this.Controls.Add(cmbEmployee);

            // Date Label and DateTimePicker
            Label lblDate = new Label
            {
                Text = "Date:",
                Location = new Point(30, 80),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 10F)
            };
            this.Controls.Add(lblDate);

            dtpDate = new DateTimePicker
            {
                Location = new Point(160, 80),
                Size = new Size(300, 25),
                Format = DateTimePickerFormat.Short,
                Font = new Font("Segoe UI", 10F)
            };
            this.Controls.Add(dtpDate);

            // Duration Label and ComboBox
            Label lblDuration = new Label
            {
                Text = "Duration:",
                Location = new Point(30, 130),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 10F)
            };
            this.Controls.Add(lblDuration);

            cmbDuration = new ComboBox
            {
                Location = new Point(160, 130),
                Size = new Size(300, 25),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F)
            };
            cmbDuration.Items.AddRange(new string[] { "30 minutes", "1 hour" });
            cmbDuration.SelectedIndex = 0; // Default
            this.Controls.Add(cmbDuration);

            // Reason Label and TextBox
            Label lblReason = new Label
            {
                Text = "Reason:",
                Location = new Point(30, 180),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 10F)
            };
            this.Controls.Add(lblReason);

            txtReason = new TextBox
            {
                Location = new Point(160, 180),
                Size = new Size(300, 25),
                Font = new Font("Segoe UI", 10F)
            };
            this.Controls.Add(txtReason);

            // Status Label and ComboBox
            Label lblStatus = new Label
            {
                Text = "Status:",
                Location = new Point(30, 230),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 10F)
            };
            this.Controls.Add(lblStatus);

            cmbStatus = new ComboBox
            {
                Location = new Point(160, 230),
                Size = new Size(300, 25),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F)
            };
            cmbStatus.Items.AddRange(new string[] { "Pending", "Approved", "Rejected" });
            cmbStatus.SelectedIndex = 0;
            this.Controls.Add(cmbStatus);

            // Save Button
            btnSave = new Button
            {
                Text = "Save",
                Location = new Point(260, 310),
                Size = new Size(100, 40),
                BackColor = Color.Coral,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            // Cancel Button
            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(370, 310),
                Size = new Size(100, 40),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += BtnCancel_Click;
            this.Controls.Add(btnCancel);
        }

        private void LoadEmployees()
        {
            try
            {
                string query = @"SELECT EmployeeID, CONCAT(FirstName, ' ', LastName) AS FullName 
                                 FROM [FlavorFlow].[dbo].[Employee] 
                                 ORDER BY FirstName, LastName";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    cmbEmployee.DisplayMember = "FullName";
                    cmbEmployee.ValueMember = "EmployeeID";
                    cmbEmployee.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbEmployee.SelectedValue == null)
                {
                    MessageBox.Show("Please select an employee.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtReason.Text))
                {
                    MessageBox.Show("Please provide a reason.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime selectedDate = dtpDate.Value.Date;
                DateTime today = DateTime.Now.Date;

                // ✅ Warn if the selected date is in the past
                if (selectedDate < today)
                {
                    DialogResult confirm = MessageBox.Show(
                        "The selected date is earlier than today.\nDo you still want to proceed?",
                        "Confirm Late Time-Off Request",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirm == DialogResult.No)
                        return; // Cancel save if user chooses "No"
                }

                // Duration: only 30 mins or 1 hour
                decimal hours = cmbDuration.SelectedItem.ToString() == "30 minutes" ? 0.5m : 1.0m;

                // ✅ Save record
                string query = @"INSERT INTO [FlavorFlow].[dbo].[TimeOffRequest] 
                        (EmployeeID, Date, Hours, Reason, Status)
                        VALUES (@EmployeeID, @Date, @Hours, @Reason, @Status)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", cmbEmployee.SelectedValue);
                        cmd.Parameters.AddWithValue("@Date", selectedDate);
                        cmd.Parameters.AddWithValue("@Hours", hours);
                        cmd.Parameters.AddWithValue("@Reason", txtReason.Text.Trim());
                        cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Time-off request submitted successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving time-off request: {ex.Message}", "Error",
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
