using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace FlavorFlowIT13
{
    public partial class HrTime_Off : UserControl
    {
        private readonly string connectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public HrTime_Off()
        {
            InitializeComponent();
        }

        private void HrTime_Off_Load(object sender, EventArgs e)
        {
            LoadTimeOffData();
            StyleDataGridView();
            CenterDataGridView();

            // Hide buttons until shown
            hraddnewtimeoffbtn.Visible = false;
            hrleaveviewbalancebtn.Visible = false;
        }

        // Show grid and buttons
        public void ShowTimeOffView()
        {
            datatimeoff.Visible = true;
            hraddnewtimeoffbtn.Visible = true;
            hrleaveviewbalancebtn.Visible = true;
        }

        // Load data from DB
        private void LoadTimeOffData()
        {
            string query = "SELECT TimeOffID, EmployeeID, Date, Hours, Reason, Status FROM TimeOffRequest";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    datatimeoff.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching data: " + ex.Message);
                }
            }
        }

        private void StyleDataGridView()
        {
            datatimeoff.BorderStyle = BorderStyle.None;
            datatimeoff.BackgroundColor = Color.White;
            datatimeoff.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            datatimeoff.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            datatimeoff.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            datatimeoff.DefaultCellStyle.SelectionForeColor = Color.White;
            datatimeoff.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            datatimeoff.EnableHeadersVisualStyles = false;
            datatimeoff.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            datatimeoff.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 51, 102);
            datatimeoff.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            datatimeoff.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            datatimeoff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            datatimeoff.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            datatimeoff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datatimeoff.MultiSelect = false;
            datatimeoff.RowHeadersVisible = false;
        }

        private void CenterDataGridView()
        {
            datatimeoff.Location = new Point(
                (this.ClientSize.Width - datatimeoff.Width) / 2,
                (this.ClientSize.Height - datatimeoff.Height) / 2
            );

            datatimeoff.Anchor = AnchorStyles.None;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Placeholder for clicks inside the grid
        }

        private void hrleaveaddnewtimeoffbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Time Off button clicked.");
        }

        private void hrleaveviewbalancebtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("View Balance button clicked.");
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
