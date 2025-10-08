using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FlavorFlowIT13
{
    public partial class HrTime_Off : UserControl
    {
        private readonly string connectionString =
            "Data Source=DESKTOP-2SPCOE3;Initial Catalog=FlavorFlow;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        public HrTime_Off()
        {
            InitializeComponent();
        }

        private void HrTime_Off_Load(object sender, EventArgs e)
        {
            LoadTimeOffData();
            StyleDataGridView();
            AdjustLayoutForContainer();
            ShowTimeOffView();
        }

        // Show grid and buttons
        public void ShowTimeOffView()
        {
            datatimeoff.Visible = true;
            hraddnewtimeoffbtn.Visible = true;
            hrtimeoffviewbalancebtn.Visible = true;
        }

        // Load data from DB with Employee names
        private void LoadTimeOffData(string searchTerm = "")
        {
            try
            {
                string query = @"SELECT 
                    tr.TimeOffID as ID,
                    CONCAT(e.FirstName, ' ', e.LastName) as Employee,
                    FORMAT(tr.Date, 'MM/dd/yyyy') as Date,
                    tr.Hours,
                    tr.Reason,
                    tr.Status
                FROM [FlavorFlow].[dbo].[TimeOffRequest] tr
                INNER JOIN [FlavorFlow].[dbo].[Employee] e ON tr.EmployeeID = e.EmployeeID";

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query += @" WHERE CONCAT(e.FirstName, ' ', e.LastName) LIKE @search 
                           OR tr.Reason LIKE @search 
                           OR tr.Status LIKE @search";
                }

                query += " ORDER BY tr.TimeOffID DESC";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    if (!string.IsNullOrWhiteSpace(searchTerm))
                        cmd.Parameters.AddWithValue("@search", $"%{searchTerm}%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    datatimeoff.DataSource = dt;

                    if (datatimeoff.Columns.Count > 0)
                    {
                        foreach (DataGridViewColumn col in datatimeoff.Columns)
                        {
                            col.ReadOnly = true;
                            col.SortMode = DataGridViewColumnSortMode.NotSortable;
                        }

                        datatimeoff.Columns["ID"].Width = 100;
                        datatimeoff.Columns["Employee"].Width = 350;
                        datatimeoff.Columns["Date"].Width = 200;
                        datatimeoff.Columns["Hours"].Width = 150;
                        datatimeoff.Columns["Reason"].Width = 400;

                        int statusIndex = datatimeoff.Columns["Status"].Index;
                        datatimeoff.Columns.RemoveAt(statusIndex);

                        DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn
                        {
                            Name = "Status",
                            HeaderText = "Status (Pending, Approved, Rejected)",
                            DataPropertyName = "Status",
                            Width = 300,
                            FlatStyle = FlatStyle.Flat,
                            DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                        };

                        statusColumn.Items.AddRange("Pending", "Approved", "Rejected");
                        datatimeoff.Columns.Insert(statusIndex, statusColumn);

                        for (int i = 0; i < datatimeoff.Rows.Count && i < dt.Rows.Count; i++)
                        {
                            if (!datatimeoff.Rows[i].IsNewRow && dt.Rows[i]["Status"] != DBNull.Value)
                            {
                                datatimeoff.Rows[i].Cells["Status"].Value = dt.Rows[i]["Status"].ToString();
                            }
                        }
                    }

                    ColorCodeStatusCells();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading time-off requests: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleDataGridView()
        {
            datatimeoff.BorderStyle = BorderStyle.None;
            datatimeoff.BackgroundColor = Color.White;
            datatimeoff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            datatimeoff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            datatimeoff.ReadOnly = false;
            datatimeoff.AllowUserToAddRows = false;
            datatimeoff.AllowUserToDeleteRows = false;
            datatimeoff.AllowUserToResizeRows = false;
            datatimeoff.AllowUserToResizeColumns = false;
            datatimeoff.SelectionMode = DataGridViewSelectionMode.CellSelect;
            datatimeoff.RowHeadersVisible = false;
            datatimeoff.ScrollBars = ScrollBars.Vertical;
            datatimeoff.MultiSelect = false;

            datatimeoff.EnableHeadersVisualStyles = false;
            datatimeoff.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            datatimeoff.ColumnHeadersDefaultCellStyle.BackColor = Color.Coral;
            datatimeoff.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            datatimeoff.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            datatimeoff.ColumnHeadersHeight = 50;

            datatimeoff.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
            datatimeoff.RowTemplate.Height = 45;
            datatimeoff.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            datatimeoff.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);

            datatimeoff.CellValueChanged += DatatimeOff_CellValueChanged;
            datatimeoff.CurrentCellDirtyStateChanged += DatatimeOff_CurrentCellDirtyStateChanged;
        }

        private void ColorCodeStatusCells()
        {
            foreach (DataGridViewRow row in datatimeoff.Rows)
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

        private void DatatimeOff_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (datatimeoff.IsCurrentCellDirty &&
                datatimeoff.CurrentCell != null &&
                datatimeoff.Columns["Status"] != null &&
                datatimeoff.CurrentCell.ColumnIndex == datatimeoff.Columns["Status"].Index)
            {
                datatimeoff.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DatatimeOff_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                datatimeoff.Columns["Status"] != null &&
                e.ColumnIndex == datatimeoff.Columns["Status"].Index)
            {
                try
                {
                    int timeOffID = Convert.ToInt32(datatimeoff.Rows[e.RowIndex].Cells["ID"].Value);
                    string newStatus = datatimeoff.Rows[e.RowIndex].Cells["Status"].Value?.ToString();

                    if (!string.IsNullOrEmpty(newStatus))
                    {
                        UpdateTimeOffStatus(timeOffID, newStatus);
                        ColorCodeStatusCells();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating status: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadTimeOffData();
                }
            }
        }

        private void UpdateTimeOffStatus(int timeOffID, string newStatus)
        {
            try
            {
                string query = @"UPDATE [FlavorFlow].[dbo].[TimeOffRequest] 
                               SET Status = @Status 
                               WHERE TimeOffID = @TimeOffID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", newStatus);
                    cmd.Parameters.AddWithValue("@TimeOffID", timeOffID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving status: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       private void AdjustLayoutForContainer()
{
    // Adjust the DataGridView height
    datatimeoff.Height = 400;

    // Calculate center position dynamically
    int containerWidth = this.Width;
    int buttonSpacing = 30; // space between buttons
    int buttonWidth = 180;
    int totalWidth = (buttonWidth * 2) + buttonSpacing;
    int startX = (containerWidth - totalWidth) / 2;

    // Place buttons below DataGridView, centered horizontally
    int yPosition = datatimeoff.Bottom + 25;

    hraddnewtimeoffbtn.Size = new Size(buttonWidth, 50);
    hrtimeoffviewbalancebtn.Size = new Size(buttonWidth, 50);

    hraddnewtimeoffbtn.Location = new Point(startX, yPosition);
    hrtimeoffviewbalancebtn.Location = new Point(startX + buttonWidth + buttonSpacing, yPosition);

    // Bring buttons to front for visibility
    hraddnewtimeoffbtn.BringToFront();
    hrtimeoffviewbalancebtn.BringToFront();
}

        // ✅ Add Time-Off button
        private void hraddnewtimeoffbtn_Click(object sender, EventArgs e)
        {
            AddTimeOffForm addForm = new AddTimeOffForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadTimeOffData();
            }
        }

        // ✅ View Balance button
        private void hrtimeoffviewbalancebtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("View Time-Off Balance feature coming soon!", "Time-Off Balance",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void datatimeoff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // placeholder for grid clicks
        }
    }
}
