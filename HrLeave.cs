using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FlavorFlowIT13
{
    public partial class HrLeave : Form
    {
        private string connectionString = "Data Source=DESKTOP-2SPCOE3;Initial Catalog=FlavorFlow;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        private DataGridView dgvLeaveRequests;
        private HrTime_Off timeOffControl;

        public HrLeave()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dgvLeaveRequests = new DataGridView
            {
                Location = new Point(0, 0),
                Size = systempanelcontents.Size,
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                ReadOnly = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                AllowUserToResizeColumns = false,
                SelectionMode = DataGridViewSelectionMode.CellSelect,
                RowHeadersVisible = false,
                ScrollBars = ScrollBars.Vertical,
                ColumnHeadersVisible = true,
                MultiSelect = false
            };

            dgvLeaveRequests.ColumnHeadersDefaultCellStyle.BackColor = Color.Coral;
            dgvLeaveRequests.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            dgvLeaveRequests.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvLeaveRequests.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLeaveRequests.ColumnHeadersHeight = 50;
            dgvLeaveRequests.EnableHeadersVisualStyles = false;

            dgvLeaveRequests.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
            dgvLeaveRequests.RowTemplate.Height = 45;
            dgvLeaveRequests.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvLeaveRequests.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);
            dgvLeaveRequests.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dgvLeaveRequests.CellValueChanged += DgvLeaveRequests_CellValueChanged;
            dgvLeaveRequests.CurrentCellDirtyStateChanged += DgvLeaveRequests_CurrentCellDirtyStateChanged;

            systempanelcontents.Controls.Add(dgvLeaveRequests);
            systemsearchbar.TextChanged += SystemSearchBar_TextChanged;
        }

        private void hrleaveleaverequestbtn_Click(object sender, EventArgs e)
        {
            // Hide Time-Off view if it's active
            if (timeOffControl != null)
            {
                timeOffControl.Visible = false;
                timeOffControl.SendToBack(); // ensure it's behind the leave UI
            }

            // Show Leave Request UI
            dgvLeaveRequests.Visible = true;
            panel1.Visible = true;
            label10.Visible = true;
            hrleaveaddnewleavebtn.Visible = true;

            dgvLeaveRequests.BringToFront();
            panel1.BringToFront();

            LoadLeaveRequests();
            LoadLeaveBalance();
        }

        private void hrleavetimeoffbtn_Click(object sender, EventArgs e)
        {
            // Hide Leave Request UI
            dgvLeaveRequests.Visible = false;
            panel1.Visible = false;
            label10.Visible = false;
            hrleaveaddnewleavebtn.Visible = false;

            // Resize container (restores layout for time-off UI)
            systempanelcontents.Size = new Size(1654, 500);

            // Show or initialize Time-Off control
            if (timeOffControl == null)
            {
                timeOffControl = new HrTime_Off();
                timeOffControl.Dock = DockStyle.Fill;
                systempanelcontents.Controls.Add(timeOffControl);
            }

            timeOffControl.Visible = true;
            timeOffControl.BringToFront();
            timeOffControl.ShowTimeOffView();
        }

        public void ShowLeaveView()
        {
            dgvLeaveRequests.Visible = true;
            panel1.Visible = true;
            label10.Visible = true;
            hrleaveaddnewleavebtn.Visible = true;
           // hrleaveviewbalancebtn.Visible = true;
            if (timeOffControl != null)
                timeOffControl.Visible = false;
        }

        private void SystemSearchBar_TextChanged(object sender, EventArgs e)
        {
            LoadLeaveRequests(systemsearchbar.Text);
        }

        public void LoadLeaveRequests(string searchTerm = "")
        {
            try
            {
                string query = @"SELECT 
                                    lr.LeaveID as ID,
                                    CONCAT(e.FirstName, ' ', e.LastName) as Employee,
                                    lr.LeaveType as Type,
                                    CONCAT(FORMAT(lr.StartDate, 'MM/dd/yyyy'), ' - ', FORMAT(lr.EndDate, 'MM/dd/yyyy')) as Dates,
                                    lr.Status
                                 FROM [FlavorFlow].[dbo].[LeaveRequest] lr
                                 INNER JOIN [FlavorFlow].[dbo].[Employee] e ON lr.EmployeeID = e.EmployeeID";

                if (!string.IsNullOrWhiteSpace(searchTerm))
                    query += @" WHERE CONCAT(e.FirstName, ' ', e.LastName) LIKE @search 
                                OR lr.LeaveType LIKE @search 
                                OR lr.Status LIKE @search";

                query += " ORDER BY lr.LeaveID DESC";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    if (!string.IsNullOrWhiteSpace(searchTerm))
                        cmd.Parameters.AddWithValue("@search", $"%{searchTerm}%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvLeaveRequests.DataSource = dt;

                    if (dgvLeaveRequests.Columns.Count > 0)
                    {
                        foreach (DataGridViewColumn col in dgvLeaveRequests.Columns)
                        {
                            col.ReadOnly = true;
                            col.SortMode = DataGridViewColumnSortMode.NotSortable;
                        }

                        dgvLeaveRequests.Columns["ID"].Width = 100;
                        dgvLeaveRequests.Columns["Employee"].Width = 350;
                        dgvLeaveRequests.Columns["Type"].Width = 280;
                        dgvLeaveRequests.Columns["Dates"].Width = 380;

                        int statusIndex = dgvLeaveRequests.Columns["Status"].Index;
                        dgvLeaveRequests.Columns.RemoveAt(statusIndex);

                        DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn
                        {
                            Name = "Status",
                            HeaderText = "Status",
                            DataPropertyName = "Status",
                            Width = 544,
                            FlatStyle = FlatStyle.Flat,
                            DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                        };
                        statusColumn.Items.AddRange("Pending", "Approved", "Rejected");
                        dgvLeaveRequests.Columns.Insert(statusIndex, statusColumn);

                        for (int i = 0; i < dgvLeaveRequests.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["Status"] != DBNull.Value)
                            {
                                string status = dt.Rows[i]["Status"].ToString();
                                dgvLeaveRequests.Rows[i].Cells["Status"].Value = status;

                                // Make the cell read-only if Approved or Rejected
                                if (status.ToLower() == "approved" || status.ToLower() == "rejected")
                                {
                                    dgvLeaveRequests.Rows[i].Cells["Status"].ReadOnly = true;
                                }
                                else
                                {
                                    dgvLeaveRequests.Rows[i].Cells["Status"].ReadOnly = false;
                                }
                            }
                        }
                        ColorCodeStatusCells();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading leave requests: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ColorCodeStatusCells()
        {
            foreach (DataGridViewRow row in dgvLeaveRequests.Rows)
            {
                if (row.Cells["Status"].Value != null)
                {
                    string status = row.Cells["Status"].Value.ToString().ToLower();
                    if (status == "approved")
                        row.Cells["Status"].Style.ForeColor = Color.Green;
                    else if (status == "pending")
                        row.Cells["Status"].Style.ForeColor = Color.Orange;
                    else if (status == "rejected")
                        row.Cells["Status"].Style.ForeColor = Color.Red;
                }
            }
        }

        private void DgvLeaveRequests_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvLeaveRequests.IsCurrentCellDirty &&
                dgvLeaveRequests.CurrentCell.ColumnIndex == dgvLeaveRequests.Columns["Status"].Index)
            {
                dgvLeaveRequests.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvLeaveRequests_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvLeaveRequests.Columns["Status"].Index)
                return;

            try
            {
                int leaveID = Convert.ToInt32(dgvLeaveRequests.Rows[e.RowIndex].Cells["ID"].Value);
                string newStatus = dgvLeaveRequests.Rows[e.RowIndex].Cells["Status"].Value?.ToString();
                if (string.IsNullOrEmpty(newStatus))
                    return;

                int employeeID = 0;
                DateTime startDate = DateTime.MinValue;
                DateTime endDate = DateTime.MinValue;

                if (newStatus.ToLower() == "approved")
                {
                    string checkQuery = @"SELECT EmployeeID, StartDate, EndDate
                                          FROM [FlavorFlow].[dbo].[LeaveRequest] 
                                          WHERE LeaveID = @LeaveID";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                        checkCmd.Parameters.AddWithValue("@LeaveID", leaveID);

                        using (SqlDataReader reader = checkCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                employeeID = Convert.ToInt32(reader["EmployeeID"]);
                                startDate = Convert.ToDateTime(reader["StartDate"]);
                                endDate = Convert.ToDateTime(reader["EndDate"]);
                                reader.Close();

                                if (!CanEmployeeRequestLeave(employeeID, startDate, endDate, out string message))
                                {
                                    MessageBox.Show(message, "Cannot Approve Leave", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    dgvLeaveRequests.Rows[e.RowIndex].Cells["Status"].Value = "Pending";
                                    ColorCodeStatusCells();
                                    return;
                                }
                            }
                        }
                    }
                }

                UpdateLeaveStatus(leaveID, newStatus);
                ColorCodeStatusCells();

                if (employeeID != 0)
                    UpdateLeaveBalanceForEmployee(employeeID, startDate, endDate);

                // Force reload of DataGridView to show updates immediately
                LoadLeaveRequests(systemsearchbar.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateLeaveStatus(int leaveID, string newStatus)
        {
            try
            {
                string query = @"UPDATE [FlavorFlow].[dbo].[LeaveRequest] 
                                 SET Status = @Status 
                                 WHERE LeaveID = @LeaveID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", newStatus);
                    cmd.Parameters.AddWithValue("@LeaveID", leaveID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadLeaveBalance()
        {
            panel1.AutoScroll = true;
            panel1.Controls.Clear();

            try
            {
                string query = @"SELECT 
                                    e.EmployeeID,
                                    CONCAT(e.FirstName, ' ', e.LastName) as EmployeeName,
                                    ISNULL(SUM(CASE WHEN lr.Status = 'Approved' 
                                        THEN DATEDIFF(day, lr.StartDate, lr.EndDate) + 1 
                                        ELSE 0 END), 0) as DaysUsed,
                                    (20 - ISNULL(SUM(CASE WHEN lr.Status = 'Approved' 
                                        THEN DATEDIFF(day, lr.StartDate, lr.EndDate) + 1 
                                        ELSE 0 END), 0)) as RemainingDays
                                 FROM [FlavorFlow].[dbo].[Employee] e
                                 LEFT JOIN [FlavorFlow].[dbo].[LeaveRequest] lr 
                                     ON e.EmployeeID = lr.EmployeeID AND YEAR(lr.StartDate) = YEAR(GETDATE())
                                 GROUP BY e.EmployeeID, e.FirstName, e.LastName
                                 ORDER BY e.FirstName, e.LastName";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    int yPos = 10;
                    if (!reader.HasRows)
                    {
                        Label noData = new Label
                        {
                            Text = "No employee data available",
                            Location = new Point(20, yPos),
                            AutoSize = true,
                            Font = new Font("Segoe UI", 12F),
                            ForeColor = Color.Gray
                        };
                        panel1.Controls.Add(noData);
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            string employeeName = reader["EmployeeName"].ToString();
                            int daysUsed = Convert.ToInt32(reader["DaysUsed"]);
                            int remainingDays = Convert.ToInt32(reader["RemainingDays"]);

                            Label lbl = new Label
                            {
                                Text = $"{employeeName}: {remainingDays} days remaining ({daysUsed}/20 used)",
                                Location = new Point(20, yPos),
                                AutoSize = true,
                                Font = new Font("Segoe UI", 12F),
                                MaximumSize = new Size(panel1.Width - 40, 0),
                                ForeColor = remainingDays <= 0 ? Color.Red :
                                             remainingDays <= 5 ? Color.Orange :
                                             Color.Green
                            };

                            panel1.Controls.Add(lbl);
                            yPos += 35;
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading leave balance: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CanEmployeeRequestLeave(int employeeID, DateTime startDate, DateTime endDate, out string message)
        {
            try
            {
                int requestYear = startDate.Year;
                int daysRequested = (endDate - startDate).Days + 1;

                string query = @"SELECT 
                                    ISNULL(SUM(DATEDIFF(day, lr.StartDate, lr.EndDate) + 1), 0) as TotalDaysUsed
                                 FROM [FlavorFlow].[dbo].[LeaveRequest] lr
                                 WHERE lr.EmployeeID = @EmployeeID 
                                 AND lr.Status = 'Approved'
                                 AND YEAR(lr.StartDate) = @Year";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                    cmd.Parameters.AddWithValue("@Year", requestYear);

                    int totalDaysUsed = Convert.ToInt32(cmd.ExecuteScalar());
                    int remainingDays = 20 - totalDaysUsed;

                    if (totalDaysUsed + daysRequested > 20)
                    {
                        message = $"Cannot approve leave request.\n\nEmployee has used {totalDaysUsed} days in {requestYear}.\nRemaining days: {remainingDays}\nRequested: {daysRequested} days\n\nAnnual limit: 20 days per year.";
                        return false;
                    }

                    message = $"Leave can be approved.\nDays used: {totalDaysUsed}/20\nRequested: {daysRequested} days\nRemaining after approval: {20 - totalDaysUsed - daysRequested} days";
                    return true;
                }
            }
            catch (Exception ex)
            {
                message = $"Error checking leave balance: {ex.Message}";
                return false;
            }
        }

        private void hrleaveaddnewleavebtn_Click(object sender, EventArgs e)
        {
            AddLeaveForm addLeaveForm = new AddLeaveForm();
            if (addLeaveForm.ShowDialog() == DialogResult.OK)
                LoadLeaveRequests(systemsearchbar.Text);
        }

        private void UpdateLeaveBalanceForEmployee(int employeeID, DateTime startDate, DateTime endDate)
        {
            try
            {
                // Reload only that employee's label
                LoadLeaveBalance();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating leave balance: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
