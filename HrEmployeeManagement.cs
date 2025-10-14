using FlavorFlow;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlavorFlowIT13
{
    public partial class HrEmployeeManagement : Form
    {
        private readonly string connectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

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

            RoundPanel(systemsearchbarpanel, 25);
            RoundPanel(panelContent, 25);
            RoundPanel(systempanelcontents, 25);
            RoundButton(hremployeemanagementaddemployeebtn, 20);


            systemsettingsuseraddicon.BackColor = ColorTranslator.FromHtml("#2f2f2f");

            hremployeemanagementaddemployeebtn.UseVisualStyleBackColor = false;
            hremployeemanagementaddemployeebtn.FlatStyle = FlatStyle.Flat;
            hremployeemanagementaddemployeebtn.FlatAppearance.BorderSize = 0;
            hremployeemanagementaddemployeebtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            hremployeemanagementaddemployeebtn.ForeColor = Color.White;
            hremployeemanagementaddemployeebtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            hremployeemanagementaddemployeebtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

        }

        private void LoadEmployees()
        {
            StyleUserGrid();
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
                 //       editImg = Properties.Resources.edit_icon; 
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
        private void panelContent_Paint(object sender, PaintEventArgs e) {
        
        }

        private void RoundButton(Button button, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(button.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(button.Width - radius, button.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, button.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            button.Region = new System.Drawing.Region(path);
        }

        private void RoundPanel(Panel pnl, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(pnl.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(pnl.Width - radius, pnl.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, pnl.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            pnl.Region = new Region(path);
        }
        private void StyleUserGrid()
        {
            dataGridViewEmployees.EnableHeadersVisualStyles = false;
            dataGridViewEmployees.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;


            dataGridViewEmployees.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dataGridViewEmployees.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridViewEmployees.DefaultCellStyle.BackColor = Color.White;
            dataGridViewEmployees.DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            dataGridViewEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            dataGridViewEmployees.RowHeadersVisible = false;
            dataGridViewEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEmployees.MultiSelect = false;
            dataGridViewEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEmployees.BorderStyle = BorderStyle.None;
            dataGridViewEmployees.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewEmployees.GridColor = Color.White;
            dataGridViewEmployees.ClearSelection();
            dataGridViewEmployees.GridColor = Color.LightGray;
            dataGridViewEmployees.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewEmployees.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            dataGridViewEmployees.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridViewEmployees.BackgroundColor = Color.WhiteSmoke;
        }
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
