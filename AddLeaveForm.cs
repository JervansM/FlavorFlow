using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace FlavorFlowIT13
{
    public partial class AddLeaveForm : Form
    {
        // Declare the UI controls
        private ComboBox comboEmployee;
        private ComboBox comboLeaveType;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private Button btnAddLeave;
        private Button btnCancel;
        private DataGridView dataGridViewLeaveRequests;

        string connectionString = "Data Source=DESKTOP-2SPCOE3;Initial Catalog=FlavorFlow;Integrated Security=True;TrustServerCertificate=True";

        public AddLeaveForm()
        {
            InitializeComponent(); // Required for Windows Forms - this calls the Designer code
            InitializeCustomComponents();
            this.Text = "Add New Leave Request"; // Set title after InitializeComponent to override Designer setting
            LoadEmployees();
         
        }

        private void InitializeCustomComponents()
        {
            this.Size = new Size(500, 280); // Made smaller since no DataGridView
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.White;

            // Title Label
            Label lblTitle = new Label();
            lblTitle.Text = "Add New Leave Request";
            lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Size = new Size(300, 25);
            this.Controls.Add(lblTitle);

            // Employee Label and ComboBox
            Label lblEmployee = new Label();
            lblEmployee.Text = "Employee:";
            lblEmployee.ForeColor = Color.White;
            lblEmployee.Location = new Point(20, 60);
            lblEmployee.Size = new Size(80, 23);
            this.Controls.Add(lblEmployee);

            comboEmployee = new ComboBox();
            comboEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            comboEmployee.BackColor = Color.FromArgb(62, 62, 66);
            comboEmployee.ForeColor = Color.White;
            comboEmployee.FlatStyle = FlatStyle.Flat;
            comboEmployee.Location = new Point(110, 60);
            comboEmployee.Size = new Size(200, 23);
            this.Controls.Add(comboEmployee);

            // Leave Type Label and ComboBox
            Label lblLeaveType = new Label();
            lblLeaveType.Text = "Leave Type:";
            lblLeaveType.ForeColor = Color.White;
            lblLeaveType.Location = new Point(20, 100);
            lblLeaveType.Size = new Size(80, 23);
            this.Controls.Add(lblLeaveType);

            comboLeaveType = new ComboBox();
            comboLeaveType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboLeaveType.Items.AddRange(new string[] { "Vacation", "Sick", "Emergency", "Personal" });
            comboLeaveType.BackColor = Color.FromArgb(62, 62, 66);
            comboLeaveType.ForeColor = Color.White;
            comboLeaveType.FlatStyle = FlatStyle.Flat;
            comboLeaveType.Location = new Point(110, 100);
            comboLeaveType.Size = new Size(200, 23);
            this.Controls.Add(comboLeaveType);

            // Start Date Label and DateTimePicker
            Label lblStartDate = new Label();
            lblStartDate.Text = "Start Date:";
            lblStartDate.ForeColor = Color.White;
            lblStartDate.Location = new Point(20, 140);
            lblStartDate.Size = new Size(80, 23);
            this.Controls.Add(lblStartDate);

            dateTimePickerStart = new DateTimePicker();
            dateTimePickerStart.Format = DateTimePickerFormat.Short;
            dateTimePickerStart.Location = new Point(110, 140);
            dateTimePickerStart.Size = new Size(120, 23);
            this.Controls.Add(dateTimePickerStart);

            // End Date Label and DateTimePicker
            Label lblEndDate = new Label();
            lblEndDate.Text = "End Date:";
            lblEndDate.ForeColor = Color.White;
            lblEndDate.Location = new Point(250, 140);
            lblEndDate.Size = new Size(70, 23);
            this.Controls.Add(lblEndDate);

            dateTimePickerEnd = new DateTimePicker();
            dateTimePickerEnd.Format = DateTimePickerFormat.Short;
            dateTimePickerEnd.Location = new Point(320, 140);
            dateTimePickerEnd.Size = new Size(120, 23);
            this.Controls.Add(dateTimePickerEnd);

            // Add Leave Button
            btnAddLeave = new Button();
            btnAddLeave.Text = "Add Leave";
            btnAddLeave.Location = new Point(280, 190);
            btnAddLeave.Size = new Size(80, 30);
            btnAddLeave.BackColor = Color.FromArgb(0, 122, 204);
            btnAddLeave.ForeColor = Color.White;
            btnAddLeave.FlatStyle = FlatStyle.Flat;
            btnAddLeave.FlatAppearance.BorderSize = 0;
            btnAddLeave.Click += btnAddLeave_Click;
            this.Controls.Add(btnAddLeave);

            // Cancel Button
            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(370, 190);
            btnCancel.Size = new Size(70, 30);
            btnCancel.BackColor = Color.FromArgb(231, 76, 60);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += btnCancel_Click;
            this.Controls.Add(btnCancel);
        }

        private void AddLeaveForm_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void btnAddLeave_Click(object sender, EventArgs e)
        {
            // Validation
            if (comboEmployee.SelectedValue == null)
            {
                MessageBox.Show("Please select an employee.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboLeaveType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a leave type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dateTimePickerEnd.Value < dateTimePickerStart.Value)
            {
                MessageBox.Show("End date cannot be before start date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"INSERT INTO LeaveRequest (EmployeeID, StartDate, EndDate, LeaveType, Status) 
                             VALUES (@EmployeeID, @StartDate, @EndDate, @LeaveType, @Status)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", comboEmployee.SelectedValue);
                        cmd.Parameters.AddWithValue("@StartDate", dateTimePickerStart.Value.Date);
                        cmd.Parameters.AddWithValue("@EndDate", dateTimePickerEnd.Value.Date);
                        cmd.Parameters.AddWithValue("@LeaveType", comboLeaveType.Text);
                        cmd.Parameters.AddWithValue("@Status", "Pending");

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Leave request added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding leave request: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LoadEmployees()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    // Match your Employee table structure
                    string query = "SELECT EmployeeID, CONCAT(FirstName, ' ', LastName) AS EmployeeName FROM Employee";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Add sample data if table is empty
                    if (dt.Rows.Count == 0)
                    {
                        dt.Columns.Add("EmployeeID", typeof(int));
                        dt.Columns.Add("EmployeeName", typeof(string));
                        dt.Rows.Add(1, "Maria Garcia");
                        dt.Rows.Add(2, "Juan Rodriguez");
                        dt.Rows.Add(3, "Pedro Martinez");
                    }

                    comboEmployee.DataSource = dt;
                    comboEmployee.DisplayMember = "EmployeeName";
                    comboEmployee.ValueMember = "EmployeeID";
                    comboEmployee.SelectedIndex = -1; // No selection initially
                }
            }
            catch (Exception ex)
            {
                // Fallback with sample data
                DataTable dt = new DataTable();
                dt.Columns.Add("EmployeeID", typeof(int));
                dt.Columns.Add("EmployeeName", typeof(string));
                dt.Rows.Add(1, "Employee 1");
                dt.Rows.Add(2, "Employee 2");
                dt.Rows.Add(3, "Employee 3");

                comboEmployee.DataSource = dt;
                comboEmployee.DisplayMember = "EmployeeName";
                comboEmployee.ValueMember = "EmployeeID";
                comboEmployee.SelectedIndex = -1;

                MessageBox.Show("Could not connect to database. Using sample data.\nError: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }

    // Remove all the unnecessary methods - LoadLeaveRequests, btnDeleteLeave_Click
}
