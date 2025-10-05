using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;  // use Microsoft.Data.SqlClient

namespace FlavorFlowIT13
{
    public partial class HrGeneratePayroll : Form
    {
        // connection string (replace with your actual server + database)
        string connectionString = "Data Source=DESKTOP-2SPCOE3;Initial Catalog=FlavorFlow;Integrated Security=True;TrustServerCertificate=True";

        public HrGeneratePayroll()
        {
            InitializeComponent();
        }

        private void HrGeneratePayroll_Load(object sender, EventArgs e)
        {
            LoadPayrollData();
        }

        private void LoadPayrollData()
        {
            string connString = "Data Source=DESKTOP-2SPCOE3;Initial Catalog=FlavorFlow;Integrated Security=True;TrustServerCertificate=True";

            string query = @"
                SELECT 
                    e.EmployeeID,
                    (e.FirstName + ' ' + e.LastName) AS [Full Name],
                    e.Position,
                    e.BasicSalary,
                    ISNULL(SUM(CASE WHEN d.Type = 'Overtime' THEN d.Amount END),0) AS Overtime,
                    ISNULL(SUM(CASE WHEN d.Type <> 'Overtime' THEN d.Amount END),0) AS Deductions,
                    (e.BasicSalary 
                        + ISNULL(SUM(CASE WHEN d.Type = 'Overtime' THEN d.Amount END),0)
                        - ISNULL(SUM(CASE WHEN d.Type <> 'Overtime' THEN d.Amount END),0)) AS NetPay
                FROM Employee e
                LEFT JOIN Deductions d 
                    ON e.EmployeeID = d.EmployeeID
                GROUP BY e.EmployeeID, e.FirstName, e.LastName, e.Position, e.BasicSalary";

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    datageneratepayroll.DataSource = dt;

                    datageneratepayroll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    datageneratepayroll.ReadOnly = true;

                    FormatGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading payroll: " + ex.Message);
            }
        }

        private void FormatGrid()
        {
            if (datageneratepayroll.Columns.Count > 0)
            {
                datageneratepayroll.Columns[0].HeaderText = "Employee ID";
                datageneratepayroll.Columns[1].HeaderText = "Name";
                datageneratepayroll.Columns[2].HeaderText = "Position";
                datageneratepayroll.Columns[3].HeaderText = "Basic Pay";
                datageneratepayroll.Columns[4].HeaderText = "Overtime";
                datageneratepayroll.Columns[5].HeaderText = "Total Deductions";
                datageneratepayroll.Columns[6].HeaderText = "Net Pay";

                datageneratepayroll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                datageneratepayroll.ReadOnly = true;
                datageneratepayroll.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Default cell style
                datageneratepayroll.DefaultCellStyle.ForeColor = Color.Black;
                datageneratepayroll.DefaultCellStyle.BackColor = Color.White;
                datageneratepayroll.DefaultCellStyle.SelectionForeColor = Color.White;
                datageneratepayroll.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;

                // 🔶 Header row style (like your screenshot)
                datageneratepayroll.EnableHeadersVisualStyles = false; // allow custom style
                datageneratepayroll.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
                datageneratepayroll.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                datageneratepayroll.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                datageneratepayroll.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

        }

        private void hrpayrollperiodsgeneratepayrolltxt_Click(object sender, EventArgs e)
        {
            LoadPayrollData();
        }

        private void hrpayrollperiodsallowanceanddeductionstxt_Click(object sender, EventArgs e)
        {
            // open allowance/deductions form if you want
        }

        private void datageneratepayroll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
