using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace FlavorFlowIT13  // Make sure this matches your project namespace
{
    public partial class HrLeave : Form
    {
        private DataGridView dgvLeaveRequests;
        private string connectionString = "Data Source=DESKTOP-2SPCOE3;Initial Catalog=FlavorFlow;Integrated Security=True;TrustServerCertificate=True";

        public HrLeave()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        // This keeps your LoadContent method for switching forms inside panelContent
        private void LoadContent(Form form)
        {
            foreach (Control ctrl in panelContent.Controls)
            {
                ctrl.Dispose();
            }

            panelContent.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panelContent.Controls.Add(form);
            form.Show();
        }

        // Initialize DataGridView in systempanelcontents panel
        private void InitializeDataGridView()
        {
            if (dgvLeaveRequests == null)
            {
                dgvLeaveRequests = new DataGridView();
                dgvLeaveRequests.Location = new Point(0, 0);
                dgvLeaveRequests.Size = new Size(systempanelcontents.Width, systempanelcontents.Height);
                dgvLeaveRequests.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                dgvLeaveRequests.BackgroundColor = Color.FromArgb(45, 45, 48);
                dgvLeaveRequests.ForeColor = Color.White;
                dgvLeaveRequests.GridColor = Color.Gray;
                dgvLeaveRequests.DefaultCellStyle.BackColor = Color.FromArgb(62, 62, 66);
                dgvLeaveRequests.DefaultCellStyle.ForeColor = Color.White;
                dgvLeaveRequests.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
                dgvLeaveRequests.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 140, 105);
                dgvLeaveRequests.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                dgvLeaveRequests.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                dgvLeaveRequests.EnableHeadersVisualStyles = false;
                dgvLeaveRequests.AllowUserToAddRows = false;
                dgvLeaveRequests.ReadOnly = false; // Changed to allow editing
                dgvLeaveRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Add event handler for status changes
                dgvLeaveRequests.CellValueChanged += dgvLeaveRequests_CellValueChanged;
                dgvLeaveRequests.CurrentCellDirtyStateChanged += dgvLeaveRequests_CurrentCellDirtyStateChanged;

                systempanelcontents.Controls.Add(dgvLeaveRequests);
            }

            LoadLeaveRequests();
        }

        // Load leave requests from DB
        private void LoadLeaveRequests()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            lr.LeaveID as ID,
                            CONCAT(e.FirstName, ' ', e.LastName) as Employee,
                            lr.LeaveType as Type,
                            CONCAT(FORMAT(lr.StartDate, 'MM/dd/yyyy'), ' - ', FORMAT(lr.EndDate, 'MM/dd/yyyy')) as Dates,
                            lr.Status
                        FROM [FlavorFlow].[dbo].[LeaveRequest] lr
                        INNER JOIN [FlavorFlow].[dbo].[Employee] e ON lr.EmployeeID = e.EmployeeID
                        ORDER BY lr.LeaveID DESC";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvLeaveRequests.DataSource = dt;

                        // Format columns and make Status column a dropdown
                        if (dgvLeaveRequests.Columns.Count > 0)
                        {
                            // Make other columns read-only
                            dgvLeaveRequests.Columns["ID"].ReadOnly = true;
                            dgvLeaveRequests.Columns["Employee"].ReadOnly = true;
                            dgvLeaveRequests.Columns["Type"].ReadOnly = true;
                            dgvLeaveRequests.Columns["Dates"].ReadOnly = true;

                            // Convert Status column to ComboBox
                            DataGridViewComboBoxColumn statusComboColumn = new DataGridViewComboBoxColumn();
                            statusComboColumn.Name = "Status";
                            statusComboColumn.HeaderText = "Status";
                            statusComboColumn.Items.AddRange(new string[] { "Pending", "Approved", "Rejected" });
                            statusComboColumn.DataPropertyName = "Status";
                            statusComboColumn.FlatStyle = FlatStyle.Flat;

                            // Replace the Status column
                            int statusIndex = dgvLeaveRequests.Columns["Status"].Index;
                            dgvLeaveRequests.Columns.RemoveAt(statusIndex);
                            dgvLeaveRequests.Columns.Insert(statusIndex, statusComboColumn);

                            dgvLeaveRequests.Columns["ID"].Width = 60;
                            dgvLeaveRequests.Columns["Employee"].Width = 200;
                            dgvLeaveRequests.Columns["Type"].Width = 150;
                            dgvLeaveRequests.Columns["Dates"].Width = 250;
                            dgvLeaveRequests.Columns["Status"].Width = 120;

                            // Color statuses
                            foreach (DataGridViewRow row in dgvLeaveRequests.Rows)
                            {
                                if (row.Cells["Status"].Value != null)
                                {
                                    string status = row.Cells["Status"].Value.ToString().ToLower();
                                    switch (status)
                                    {
                                        case "pending":
                                            row.Cells["Status"].Style.BackColor = Color.Orange;
                                            row.Cells["Status"].Style.ForeColor = Color.Black;
                                            break;
                                        case "approved":
                                            row.Cells["Status"].Style.BackColor = Color.Green;
                                            row.Cells["Status"].Style.ForeColor = Color.White;
                                            break;
                                        case "rejected":
                                            row.Cells["Status"].Style.BackColor = Color.Red;
                                            row.Cells["Status"].Style.ForeColor = Color.White;
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading leave requests: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Open modal for adding leave
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (AddLeaveForm addLeaveForm = new AddLeaveForm())
                {
                    addLeaveForm.StartPosition = FormStartPosition.CenterParent;
                    DialogResult result = addLeaveForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        LoadLeaveRequests();
                        MessageBox.Show("Leave request has been submitted successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Add Leave form: {ex.Message}\n\nMake sure AddLeaveForm.cs is added to your project.",
                    "Form Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hrleaveleaverequestbtn_Click(object sender, EventArgs e)
        {
            // Refresh current form instead of loading new instance
            LoadLeaveRequests();
        }

        private void hrleavetimeoffbtn_Click(object sender, EventArgs e)
        {
            // You can later add functionality for Time Off
            MessageBox.Show("Time Off functionality will be implemented later.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Empty event handlers to prevent errors
        private void systempanelcontents_Paint(object sender, PaintEventArgs e)
        {
            // Paint event handler - can be empty
        }

        private void label10_Click(object sender, EventArgs e)
        {
            // Click event handler - can be empty
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Paint event handler - can be empty
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {
            // Paint event handler - can be empty
        }

        // Add this method if you have a refresh button
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLeaveRequests();
        }

        // Handle dropdown changes immediately
        private void dgvLeaveRequests_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvLeaveRequests.IsCurrentCellDirty && dgvLeaveRequests.CurrentCell.ColumnIndex == dgvLeaveRequests.Columns["Status"].Index)
            {
                dgvLeaveRequests.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // Handle status changes and update database
        private void dgvLeaveRequests_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvLeaveRequests.Columns["Status"].Index && e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dgvLeaveRequests.Rows[e.RowIndex];
                    string employeeName = row.Cells["Employee"].Value.ToString();
                    string newStatus = row.Cells["Status"].Value.ToString();
                    string dates = row.Cells["Dates"].Value.ToString();

                    // Get the date range to identify the specific leave request
                    string[] dateParts = dates.Split('-');
                    string startDate = dateParts[0].Trim();

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string updateQuery = @"
                            UPDATE lr 
                            SET Status = @Status 
                            FROM [FlavorFlow].[dbo].[LeaveRequest] lr
                            INNER JOIN [FlavorFlow].[dbo].[Employee] e ON lr.EmployeeID = e.EmployeeID
                            WHERE CONCAT(e.FirstName, ' ', e.LastName) = @EmployeeName 
                            AND FORMAT(lr.StartDate, 'MM/dd/yyyy') = @StartDate";

                        using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Status", newStatus);
                            cmd.Parameters.AddWithValue("@EmployeeName", employeeName);
                            cmd.Parameters.AddWithValue("@StartDate", startDate);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show($"Status updated to '{newStatus}' for {employeeName}", "Status Updated",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Refresh the grid to show color changes
                                LoadLeaveRequests();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating status: {ex.Message}", "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Reload to revert the change
                    LoadLeaveRequests();
                }
            }
        }

        // Override form closing to cleanup resources
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (dgvLeaveRequests != null)
            {
                dgvLeaveRequests.DataSource = null;
                dgvLeaveRequests.Dispose();
            }
            base.OnFormClosing(e);
        }

       
    }
}