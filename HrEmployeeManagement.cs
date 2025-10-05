using FlavorFlow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlavorFlowIT13
{
    public partial class HrEmployeeManagement : Form
    {
        public HrEmployeeManagement()
        {
            InitializeComponent();
            this.TopLevel = false;        // ✅ Allow form to be hosted inside a panel
            this.FormBorderStyle = FormBorderStyle.None; // ✅ Remove borders
            this.Dock = DockStyle.Fill;   // ✅ Make it fill the panel
        }

        private void HrEmployeeManagement_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            string connectionString = "Data Source=DESKTOP-2SPCOE3;Initial Catalog=FlavorFlow;Integrated Security=True;TrustServerCertificate=True";
            string query = "SELECT EmployeeID, FirstName, LastName, Position, Status FROM Employee";

            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }

                // Build display table
                DataTable displayTable = new DataTable();
                displayTable.Columns.Add("EmployeeID", typeof(int));
                displayTable.Columns.Add("Name", typeof(string));
                displayTable.Columns.Add("Role", typeof(string));
                displayTable.Columns.Add("Status", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    string first = row["FirstName"]?.ToString() ?? "";
                    string last = row["LastName"]?.ToString() ?? "";
                    int id = row["EmployeeID"] != DBNull.Value ? Convert.ToInt32(row["EmployeeID"]) : 0;
                    displayTable.Rows.Add(id, $"{first} {last}".Trim(), row["Position"]?.ToString() ?? "", row["Status"]?.ToString() ?? "");
                }

                // Ensure grid exists
                if (dataGridViewEmployees == null)
                {
                    MessageBox.Show("dataGridViewEmployees control not found on the form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dataGridViewEmployees.SuspendLayout();
                dataGridViewEmployees.DataSource = displayTable;

                // Fill the panel and stretch columns
                dataGridViewEmployees.Dock = DockStyle.Fill;
                dataGridViewEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewEmployees.AllowUserToAddRows = false;
                dataGridViewEmployees.ReadOnly = true;
                dataGridViewEmployees.RowHeadersVisible = false;
                dataGridViewEmployees.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dataGridViewEmployees.BorderStyle = BorderStyle.None;

                // Add Edit image column (try resource first, then file path, then fallback to text button)
                if (!dataGridViewEmployees.Columns.Contains("Edit"))
                {
                    Image editImg = null;

                    // Try Properties.Resources (recommended)
                    try
                    {
                        // If you've added the image to Resources.resx, this will succeed:
                        editImg = Properties.Resources.edit_icon; // <-- name depends on your resource entry
                    }
                    catch
                    {
                        editImg = null;
                    }

                    // If resource not found, try loading from file path (your provided path)
                    if (editImg == null)
                    {
                        try
                        {
                            string filePath = @"C:\Users\Asus\Source\Repos\FlavorFlow\Resources\edit_icon.png";
                            if (System.IO.File.Exists(filePath))
                                editImg = Image.FromFile(filePath);
                        }
                        catch
                        {
                            editImg = null;
                        }
                    }

                    // Add the appropriate column type
                    if (editImg != null)
                    {
                        var imgCol = new DataGridViewImageColumn
                        {
                            Name = "Edit",
                            HeaderText = "Action",
                            Image = editImg,
                            ImageLayout = DataGridViewImageCellLayout.Zoom
                        };
                        dataGridViewEmployees.Columns.Add(imgCol);
                    }
                    else
                    {
                        // fallback to a text button if icon not available
                        var btn = new DataGridViewButtonColumn
                        {
                            Name = "Edit",
                            HeaderText = "Action",
                            Text = "Edit",
                            UseColumnTextForButtonValue = true,
                            FlatStyle = FlatStyle.Flat
                        };
                        dataGridViewEmployees.Columns.Add(btn);
                    }
                }

                // Now that columns exist, set fill weights safely
                if (dataGridViewEmployees.Columns.Contains("EmployeeID"))
                    dataGridViewEmployees.Columns["EmployeeID"].FillWeight = 20;
                if (dataGridViewEmployees.Columns.Contains("Name"))
                    dataGridViewEmployees.Columns["Name"].FillWeight = 70;
                if (dataGridViewEmployees.Columns.Contains("Role"))
                    dataGridViewEmployees.Columns["Role"].FillWeight = 50;
                if (dataGridViewEmployees.Columns.Contains("Status"))
                    dataGridViewEmployees.Columns["Status"].FillWeight = 40;
                if (dataGridViewEmployees.Columns.Contains("Edit"))
                    dataGridViewEmployees.Columns["Edit"].FillWeight = 20;

                // Header styling (slightly darker orange)
                dataGridViewEmployees.EnableHeadersVisualStyles = false;
                dataGridViewEmployees.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 170, 60);
                dataGridViewEmployees.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridViewEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                dataGridViewEmployees.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewEmployees.ColumnHeadersHeight = 60;
                dataGridViewEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


                foreach (DataGridViewColumn col in dataGridViewEmployees.Columns)
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // Row styles
                dataGridViewEmployees.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                dataGridViewEmployees.DefaultCellStyle.BackColor = Color.White;
                dataGridViewEmployees.DefaultCellStyle.ForeColor = Color.Black;
                dataGridViewEmployees.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                dataGridViewEmployees.DefaultCellStyle.SelectionForeColor = Color.Black;

                // Ensure the click event is wired (avoid duplicate wiring)
                dataGridViewEmployees.CellContentClick -= dataGridViewEmployees_CellContentClick;
                dataGridViewEmployees.CellContentClick += dataGridViewEmployees_CellContentClick;

                dataGridViewEmployees.ResumeLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employees: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dataGridViewEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dataGridViewEmployees.Columns[e.ColumnIndex].Name == "Edit")
            {
                string employeeId = dataGridViewEmployees.Rows[e.RowIndex].Cells["EmployeeID"].Value.ToString();
                MessageBox.Show("Edit Employee ID: " + employeeId);

                // TODO: open Edit Employee form here
            }
        }

        // Existing event handlers
        private void systemgeneralsettings_Click(object sender, EventArgs e) {
            using (EmployeeForm empForm = new EmployeeForm())
            {
                if (empForm.ShowDialog() == DialogResult.OK)
                {
                    // Refresh employee list (if you have DataGridView)
                    LoadEmployees();
                }
            }

        }
        private void panelContent_Paint(object sender, PaintEventArgs e) { }
        private void systemsearchbarpanel_Paint(object sender, PaintEventArgs e) { }
        private void systemsearchbaricon_Click(object sender, EventArgs e) { }
        private void systemsearchbar_TextChanged(object sender, EventArgs e) { }
        private void systempanelcontents_Paint(object sender, PaintEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void systemsearchbaricon_Click_1(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }

        private void systempanelheadercoral_Paint(object sender, PaintEventArgs e)
        {

        }

       
            private void systemsettingsuseraddicon_Click(object sender, EventArgs e)
        {
            using (EmployeeForm empForm = new EmployeeForm())
            {
                if (empForm.ShowDialog() == DialogResult.OK)
                {
                    // Refresh employee list (if you have DataGridView)
                    LoadEmployees();
                }
            }
        }
    }
    
}
