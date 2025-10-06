using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FlavorFlowIT13
{
    public partial class StaffManagement : Form
    {
        private readonly string cloudConnectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
        private readonly string localConnectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        private string activeConnectionString;
        public StaffManagement()
        {
            InitializeComponent();

            activeConnectionString = GetAvailableConnection();

        }
        private string GetAvailableConnection()
        {
            if (TestConnection(cloudConnectionString))
                return cloudConnectionString;

            if (TestConnection(localConnectionString))
                return localConnectionString;

            MessageBox.Show("No available database connection.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        private bool TestConnection(string connectionString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
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
        private void StyleUserGrid()
        {
            dgvstaff.EnableHeadersVisualStyles = false;
            dgvstaff.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;


            dgvstaff.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvstaff.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvstaff.DefaultCellStyle.BackColor = Color.White;
            dgvstaff.DefaultCellStyle.ForeColor = Color.Black;
            dgvstaff.DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            dgvstaff.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            dgvstaff.RowHeadersVisible = false;
            dgvstaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvstaff.MultiSelect = false;
            dgvstaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvstaff.BorderStyle = BorderStyle.None;
            dgvstaff.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvstaff.GridColor = Color.White;
            dgvstaff.ClearSelection();
            dgvstaff.GridColor = Color.LightGray;
            dgvstaff.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvstaff.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            dgvstaff.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvstaff.BackgroundColor = Color.WhiteSmoke;
        }
        private void StaffManagement_Load(object sender, EventArgs e)
        {
            RoundPanel(panelContent, 25);
            RoundPanel(panelstaffcontents, 25);
            RoundButton(addnewstaffbtn, 20);

            addnewstaffbtn.UseVisualStyleBackColor = false;
            addnewstaffbtn.FlatStyle = FlatStyle.Flat;
            addnewstaffbtn.FlatAppearance.BorderSize = 0;
            addnewstaffbtn.BackColor = ColorTranslator.FromHtml("LimeGreen");
            addnewstaffbtn.ForeColor = Color.White;
            addnewstaffbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#51A135");
            addnewstaffbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#51A135");

            LoadStaffData(); // <-- Load staff on form load
        }

        private void LoadContent(Form form)
        {
            foreach (Control ctrl in panelContent.Controls)
            {
                ctrl.Dispose();
            }

            panelContent.Controls.Clear();

            // Prepare the new form
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Add to panel
            panelContent.Controls.Add(form);
            form.Show();

        }

        private void LoadStaffData()
        {
            StyleUserGrid();
            if (string.IsNullOrEmpty(activeConnectionString)) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(activeConnectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT TOP (1000) 
                            [StaffID],
                            [Name],
                            [Role],
                            [Contact],
                            [HireDate],
                            [UserID]
                        FROM [db28059].[dbo].[Staff]
                        ORDER BY StaffID ASC"; // optional: order by StaffID

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvstaff.DataSource = dt;

                    // Optional: format columns
                    dgvstaff.Columns["HireDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    dgvstaff.AutoResizeColumns();

                    dgvstaff.Columns["HireDate"].Visible = false;


                    if (dgvstaff.Columns.Contains("UserID"))
                        dgvstaff.Columns["UserID"].Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading staff data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvstaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addnewstaffbtn_Click(object sender, EventArgs e)
        {
            StaffManagementAddForm newform = new StaffManagementAddForm();
            newform.Show();
        }
    }
}
