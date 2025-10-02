using Microsoft.Data.SqlClient;
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

namespace FlavorFlowIT13
{
    public partial class AuditsLogsSecurity : Form
    {
        private readonly string cloudConnectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
        private readonly string localConnectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        private string activeConnectionString;
        public AuditsLogsSecurity()
        {
            InitializeComponent();
            RoundPanel(panelContent, 25);
            RoundPanel(auditlogspanel, 25);
            RoundButton(auditlogsbtn, 20);
            RoundButton(securitybtn, 20);
            RoundPanel(systemsearchbarpanel, 25);

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
            auditlogsdatagrid.EnableHeadersVisualStyles = false;
            auditlogsdatagrid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            auditlogsdatagrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            auditlogsdatagrid.DefaultCellStyle.BackColor = Color.White;
            auditlogsdatagrid.DefaultCellStyle.ForeColor = Color.Black;
            auditlogsdatagrid.DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            auditlogsdatagrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            auditlogsdatagrid.RowHeadersVisible = false;
            auditlogsdatagrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            auditlogsdatagrid.MultiSelect = false;
            auditlogsdatagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            auditlogsdatagrid.BorderStyle = BorderStyle.FixedSingle;
            auditlogsdatagrid.GridColor = Color.LightGray;
            auditlogsdatagrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            auditlogsdatagrid.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            auditlogsdatagrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            auditlogsdatagrid.BackgroundColor = Color.WhiteSmoke;
        }

        private void AuditsLogsSecurity_Load(object sender, EventArgs e)
        {
            activeConnectionString = GetAvailableConnection();
            LoadAuditLogs();
            StyleUserGrid();
        }
        private string GetAvailableConnection()
        {
            if (TestConnection(cloudConnectionString))
                return cloudConnectionString;

            if (TestConnection(localConnectionString))
                return localConnectionString;

            MessageBox.Show("No available database connection.", "Database Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void AddAuditLog(string action, string userName)
        {
            using (SqlConnection conn = new SqlConnection(activeConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO AuditLogs (Action, UserName) VALUES (@Action, @UserName)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void LoadAuditLogs()
        {
            using (SqlConnection conn = new SqlConnection(activeConnectionString))
            {
                conn.Open();
                string query = "SELECT AuditID, Action, UserName, LogDate FROM AuditLogs ORDER BY LogDate DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                auditlogsdatagrid.DataSource = dt;
            }
        }
        private void auditlogspanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void auditlogsdatagrid_Paint(object sender, PaintEventArgs e)
        {

        }

        private void auditlogsdatagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            activeConnectionString = GetAvailableConnection();
            LoadAuditLogs();
            StyleUserGrid();
        }
    }
}
