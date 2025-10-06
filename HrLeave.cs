using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FlavorFlowIT13
{
    public partial class HrLeave : Form
    {
        private readonly string connectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public HrLeave()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        // Keep your LoadContent method for switching forms inside panelContent
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

        // Setup dataleave (the DataGridView from Designer)
        private void InitializeDataGridView()
        {
            dataleave.Dock = DockStyle.Fill;
            dataleave.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataleave.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataleave.BackgroundColor = Color.FromArgb(45, 45, 48);
            dataleave.ForeColor = Color.White;
            dataleave.GridColor = Color.Gray;
            dataleave.DefaultCellStyle.BackColor = Color.FromArgb(62, 62, 66);
            dataleave.DefaultCellStyle.ForeColor = Color.White;
            dataleave.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataleave.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 140, 105);
            dataleave.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataleave.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dataleave.EnableHeadersVisualStyles = false;
            dataleave.AllowUserToAddRows = false;
            dataleave.ReadOnly = false; // allow editing for status
            dataleave.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataleave.RowHeadersVisible = false;

            // Event handlers
            dataleave.CellValueChanged += dgvLeaveRequests_CellValueChanged;
            dataleave.CurrentCellDirtyStateChanged += dgvLeaveRequests_CurrentCellDirtyStateChanged;

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
                        FROM [db28059].[dbo].[LeaveRequest] lr
                        INNER JOIN [db28059].[dbo].[Employee] e ON lr.EmployeeID = e.EmployeeID
                        ORDER BY lr.LeaveID DESC";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataleave.DataSource = dt;

                        if (dataleave.Columns.Count > 0)
                        {
                            // Make read-only columns
                            dataleave.Columns["ID"].ReadOnly = true;
                            dataleave.Columns["Employee"].ReadOnly = true;
                            dataleave.Columns["Type"].ReadOnly = true;
                            dataleave.Columns["Dates"].ReadOnly = true;

                            // Replace Status column with ComboBox
                            int statusIndex = dataleave.Columns["Status"].Index;
                            dataleave.Columns.RemoveAt(statusIndex);

                            DataGridViewComboBoxColumn statusComboColumn = new DataGridViewComboBoxColumn
                            {
                                Name = "Status",
                                HeaderText = "Status",
                                DataPropertyName = "Status",
                                FlatStyle = FlatStyle.Flat
                            };
                            statusComboColumn.Items.AddRange("Pending", "Approved", "Rejected");

                            dataleave.Columns.Insert(statusIndex, statusComboColumn);

                            // Column widths - make columns fill the available space
                            dataleave.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dataleave.Columns["ID"].FillWeight = 8;  // 8% of total width
                            dataleave.Columns["Employee"].FillWeight = 25;  // 25% of total width
                            dataleave.Columns["Type"].FillWeight = 15;  // 15% of total width
                            dataleave.Columns["Dates"].FillWeight = 32;  // 32% of total width
                            dataleave.Columns["Status"].FillWeight = 20;  // 20% of total width

                            // Color rows by status
                            foreach (DataGridViewRow row in dataleave.Rows)
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

        // Add new leave
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
                MessageBox.Show($"Error opening Add Leave form: {ex.Message}", "Form Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hrleaveleaverequestbtn_Click(object sender, EventArgs e)
        {
            systempanelcontents.Controls.Clear();
            dataleave.Dock = DockStyle.Fill;
            systempanelcontents.Controls.Add(dataleave);
            LoadLeaveRequests();
        }

        private void hrleavetimeoffbtn_Click(object sender, EventArgs e)
        {
            systempanelcontents.Controls.Clear();

            HrTime_Off timeOffControl = new HrTime_Off
            {
                Dock = DockStyle.Fill
            };
            systempanelcontents.Controls.Add(timeOffControl);
            timeOffControl.ShowTimeOffView();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLeaveRequests();
        }

        // Commit dropdown change instantly
        private void dgvLeaveRequests_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataleave.IsCurrentCellDirty && dataleave.CurrentCell.ColumnIndex == dataleave.Columns["Status"].Index)
            {
                dataleave.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // Update DB when status changes
        private void dgvLeaveRequests_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataleave.Columns["Status"].Index && e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataleave.Rows[e.RowIndex];
                    string employeeName = row.Cells["Employee"].Value.ToString();
                    string newStatus = row.Cells["Status"].Value.ToString();
                    string dates = row.Cells["Dates"].Value.ToString();

                    string[] dateParts = dates.Split('-');
                    string startDate = dateParts[0].Trim();

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string updateQuery = @"
                            UPDATE lr 
                            SET Status = @Status 
                            FROM [db28059].[dbo].[LeaveRequest] lr
                            INNER JOIN [db28059].[dbo].[Employee] e ON lr.EmployeeID = e.EmployeeID
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

                                LoadLeaveRequests();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating status: {ex.Message}", "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    LoadLeaveRequests();
                }
            }
        }

        // Cleanup
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            dataleave.DataSource = null;
            base.OnFormClosing(e);
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HrLeave_Load(object sender, EventArgs e)
        {

        }

        private void hrleaveviewbalancebtn_Click(object sender, EventArgs e)
        {

        }
    }
}
