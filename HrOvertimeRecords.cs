using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;


namespace FlavorFlowIT13
{
    public partial class HrOvertimeRecords : Form
    {
        public HrOvertimeRecords()
        {
            InitializeComponent();
        }

        private void HrOvertimeRecords_Load(object sender, EventArgs e)
        {
            LoadOvertimeRecords();
        }

        private void LoadOvertimeRecords()
        {
            string connectionString = "Data Source=DESKTOP-2SPCOE3;Initial Catalog=FlavorFlow;Integrated Security=True;TrustServerCertificate=True";

            string query = @"
              SELECT 
    e.EmployeeID,
    e.FirstName + ' ' + e.LastName AS [Name],
    ad.TransactionDate AS [Date],
    ad.Quantity AS [Hours],
    ad.Amount / ad.Quantity AS [Rate/Hour],
    ad.Amount AS [Total]
FROM AllowanceDeduction ad
INNER JOIN Employee e ON ad.EmployeeID = e.EmployeeID
WHERE ad.Reason = 'Overtime';";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataovertimerecords.DataSource = dt;
            }

            // ✅ Styling to match your Allowance & Deductions grid
            dataovertimerecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataovertimerecords.EnableHeadersVisualStyles = false;
            dataovertimerecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            dataovertimerecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataovertimerecords.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataovertimerecords.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataovertimerecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Row style
            dataovertimerecords.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataovertimerecords.DefaultCellStyle.ForeColor = Color.Black; // ✅ ensure row text is visible
            dataovertimerecords.DefaultCellStyle.BackColor = Color.White; // ✅ row background
            dataovertimerecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }
    }
}
