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
    public partial class NetProfit : Form
    {
        private readonly string cloudConnectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
        private readonly string localConnectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        private string activeConnectionString;


        public NetProfit()
        {
            InitializeComponent();

            activeConnectionString = GetAvailableConnection();
        }
        private string GetAvailableConnection()
        {
            if (TestConnection(cloudConnectionString))
            {
                return cloudConnectionString;
            }
            else if (TestConnection(localConnectionString))
            {
                return localConnectionString;
            }
            else
            {
                MessageBox.Show("No available database connection.", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
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
                return false; // Connection failed
            }
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
        private void systemsearchbaricon_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void systemgeneralsettings_Click(object sender, EventArgs e)
        {

        }

        private void systemappconfigure_Click(object sender, EventArgs e)
        {

        }

        private void systempanelheadercoral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void systemsettingssavebtn_Click(object sender, EventArgs e)
        {

        }

        private void systemsearchbar_TextChanged(object sender, EventArgs e)
        {

        }

        private void expensesreportbtn_Click(object sender, EventArgs e)
        {

        }

        private void NetProfit_Load(object sender, EventArgs e)
        {
            RoundPanel(panelContent, 25);
            RoundPanel(financeexpensespanel, 25);
            RoundButton(netsalessumbtn, 20);
            RoundButton(expensereportsbtn, 20);
            RoundButton(netprofitsummarybtn, 20);
        }

        private void expensereportsbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new Expenses());
        }

        private void netprofitsummarybtn_Click(object sender, EventArgs e)
        {
            LoadContent(new NetProfit());
        }

        private void netsalessumbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new FinanceExpenses());
        }

        private void netprofitchart_Click(object sender, EventArgs e)
        {

        }
    }
}
