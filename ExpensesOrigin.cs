using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;


namespace FlavorFlowIT13
{
    public partial class ExpensesOrigin : Form
    {
        private readonly string cloudConnectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public ExpensesOrigin()
        {
            InitializeComponent();
        }

        private void ExpensesOrigin_Load(object sender, EventArgs e)
        {
            LoadExpensesData();

        }
        private void LoadExpensesData()
        {
            StyleUserGrid();
            try
            {
                using (SqlConnection conn = new SqlConnection(cloudConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT ExpenseID, Category, Amount, Date, Notes
                        FROM dbo.Expenses
                        ORDER BY ExpenseID ASC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvexpenses.DataSource = dt;

                    // Optional formatting
                    dgvexpenses.AutoResizeColumns();
                    dgvexpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvexpenses.MultiSelect = false;
                    dgvexpenses.ReadOnly = true;
                    dgvexpenses.AllowUserToAddRows = false;
                    dgvexpenses.AllowUserToDeleteRows = false;

                    // Format Amount and Date columns
                    if (dgvexpenses.Columns.Contains("Amount"))
                        dgvexpenses.Columns["Amount"].DefaultCellStyle.Format = "N2";

                    if (dgvexpenses.Columns.Contains("Date"))
                        dgvexpenses.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    dgvexpenses.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading expenses data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvexpenses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void StyleUserGrid()
        {
            dgvexpenses.EnableHeadersVisualStyles = false;
            dgvexpenses.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Header style
            dgvexpenses.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvexpenses.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvexpenses.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            dgvexpenses.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 5, 10, 5); // even spacing

            // Cell style
            dgvexpenses.DefaultCellStyle.BackColor = Color.White;
            dgvexpenses.DefaultCellStyle.ForeColor = Color.Black;
            dgvexpenses.DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            dgvexpenses.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5); // even spacing
            dgvexpenses.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            dgvexpenses.RowHeadersVisible = false;
            dgvexpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvexpenses.MultiSelect = false;
            dgvexpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvexpenses.BorderStyle = BorderStyle.None;
            dgvexpenses.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // optional: shows light line
            dgvexpenses.GridColor = Color.LightGray;
            dgvexpenses.ClearSelection();
            dgvexpenses.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            dgvexpenses.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvexpenses.BackgroundColor = Color.WhiteSmoke;

            dgvexpenses.RowTemplate.Height = 35; 
        }
    }
}
