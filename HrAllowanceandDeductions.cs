using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; // ✅ using Microsoft.Data.SqlClient

namespace FlavorFlowIT13
{
    public partial class HrAllowanceandDeductions : Form
    {
        private readonly string connStr = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public HrAllowanceandDeductions()
        {
            InitializeComponent();
        }

        private void HrAllowanceandDeductions_Load(object sender, EventArgs e)
        {
            LoadAllowancesAndDeductions();
        }

        private void LoadAllowancesAndDeductions()
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
                    SELECT 
                        e.EmployeeID,
                        e.FirstName + ' ' + e.LastName AS Name,
                        'Allowance' AS Type,
                        ad.Reason,
                        ad.Amount
                    FROM Employee e
                    INNER JOIN AllowanceDeduction ad ON e.EmployeeID = ad.EmployeeID

                    UNION ALL

                    SELECT 
                        e.EmployeeID,
                        e.FirstName + ' ' + e.LastName AS Name,
                        'Deduction' AS Type,
                        d.Type AS Reason,
                        d.Amount
                    FROM Employee e
                    INNER JOIN Deductions d ON e.EmployeeID = d.EmployeeID

                    ORDER BY e.EmployeeID;
                ";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataallowanceanddeductions.DataSource = dt;
            }

            // ✅ Grid styling
            dataallowanceanddeductions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataallowanceanddeductions.EnableHeadersVisualStyles = false;
            dataallowanceanddeductions.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            dataallowanceanddeductions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataallowanceanddeductions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataallowanceanddeductions.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataallowanceanddeductions.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }

        private void dataallowanceanddeductions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: handle clicks if needed
        }
    }
}
