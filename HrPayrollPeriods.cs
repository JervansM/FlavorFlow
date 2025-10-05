using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; // ✅ Microsoft.Data.SqlClient

namespace FlavorFlowIT13
{
    public partial class HrPayrollPeriods : Form
    {
        private readonly string connectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public HrPayrollPeriods()
        {
            InitializeComponent();

            // ✅ Always auto-size columns from the start
            datapayrollperiod.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ✅ Subscribe to value change event
            datapayrollperiod.CellValueChanged += datapayrollperiod_CellValueChanged;
        }

        private void LoadPayrollPeriods()
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT PeriodID, StartDate, EndDate, Status FROM PayrollPeriod";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                datapayrollperiod.DataSource = dt;
            }

            // ✅ Auto fill columns
            datapayrollperiod.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ✅ Row styling
            datapayrollperiod.DefaultCellStyle.ForeColor = Color.Black;
            datapayrollperiod.DefaultCellStyle.BackColor = Color.White;
            datapayrollperiod.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;

            // ✅ Replace Status column with ComboBox column
            if (datapayrollperiod.Columns.Contains("Status"))
            {
                int colIndex = datapayrollperiod.Columns["Status"].Index;
                datapayrollperiod.Columns.Remove("Status");

                DataGridViewComboBoxColumn statusCombo = new DataGridViewComboBoxColumn
                {
                    HeaderText = "Status",
                    Name = "Status",
                    DataPropertyName = "Status"
                };
                statusCombo.Items.AddRange("Open", "Closed");
                datapayrollperiod.Columns.Insert(colIndex, statusCombo);
            }

            // ✅ Highlight FIRST ROW with light orange
            if (datapayrollperiod.Rows.Count > 0)
            {
                datapayrollperiod.Rows[0].DefaultCellStyle.BackColor = Color.Moccasin;
                datapayrollperiod.Rows[0].DefaultCellStyle.ForeColor = Color.Black;
                datapayrollperiod.Rows[0].DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
        }

        private void Addperiod_Click(object sender, EventArgs e)
        {
            using (AddPayrollPeriodForm addForm = new AddPayrollPeriodForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadPayrollPeriods(); // ✅ Refresh after adding
                }
            }
        }

        private void datapayrollperiod_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Optional
        }

        private void HrPayrollPeriods_Load(object sender, EventArgs e)
        {
            LoadPayrollPeriods();

            // 🔶 Header style
            datapayrollperiod.EnableHeadersVisualStyles = false;
            datapayrollperiod.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            datapayrollperiod.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            datapayrollperiod.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            datapayrollperiod.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // ✅ Update database when dropdown value changes
        private void datapayrollperiod_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && datapayrollperiod.Columns[e.ColumnIndex].Name == "Status")
            {
                int periodID = Convert.ToInt32(datapayrollperiod.Rows[e.RowIndex].Cells["PeriodID"].Value);
                string newStatus = datapayrollperiod.Rows[e.RowIndex].Cells["Status"].Value?.ToString();

                if (!string.IsNullOrEmpty(newStatus))
                {
                    UpdateStatusInDatabase(periodID, newStatus);
                }
            }
        }

        private void UpdateStatusInDatabase(int periodID, string newStatus)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE PayrollPeriod SET Status = @Status WHERE PeriodID = @PeriodID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", newStatus);
                    cmd.Parameters.AddWithValue("@PeriodID", periodID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
