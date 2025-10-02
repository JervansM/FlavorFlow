using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace FlavorFlowIT13
{
    public partial class FinanceExpenses : Form
    {
        private readonly string cloudConnectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
        private readonly string localConnectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        private string activeConnectionString;
        public FinanceExpenses()
        {
            InitializeComponent();


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

        private void FinanceExpenses_Load(object sender, EventArgs e)
        {
            RoundPanel(panelContent, 25);
            RoundPanel(financeexpensespanel, 25);
            RoundButton(netsalessumbtn, 20);
            RoundButton(expensereportsbtn, 20);
            RoundButton(netprofitsummarybtn, 20);

            activeConnectionString = GetAvailableConnection();

            financeexpensespanel.BackColor = ColorTranslator.FromHtml("#2f2f2f");


            netsalessumbtn.UseVisualStyleBackColor = false;
            netsalessumbtn.FlatStyle = FlatStyle.Flat;
            netsalessumbtn.FlatAppearance.BorderSize = 0;
            netsalessumbtn.BackColor = ColorTranslator.FromHtml("#6C6868");
            netsalessumbtn.ForeColor = Color.White;
            netsalessumbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            netsalessumbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            expensereportsbtn.UseVisualStyleBackColor = false;
            expensereportsbtn.FlatStyle = FlatStyle.Flat;
            expensereportsbtn.FlatAppearance.BorderSize = 0;
            expensereportsbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            expensereportsbtn.ForeColor = Color.White;
            expensereportsbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#6C6868");
            expensereportsbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            netprofitsummarybtn.UseVisualStyleBackColor = false;
            netprofitsummarybtn.FlatStyle = FlatStyle.Flat;
            netprofitsummarybtn.FlatAppearance.BorderSize = 0;
            netprofitsummarybtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            netprofitsummarybtn.ForeColor = Color.White;
            netprofitsummarybtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#6C6868");
            netprofitsummarybtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            netsalestxt.Text = "₱0.00";
            loadnetsalessummary();
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

        private void financeexpensespanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void netsalessumbtn_Click(object sender, EventArgs e)
        {

            loadnetsalessummary();
        }

        private void loadnetsalessummary()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(activeConnectionString))
                {
                    conn.Open();

                    string query = "SELECT \r\n    ISNULL(SUM(TotalAmount), 0) - ISNULL(SUM(DiscountAmount), 0) AS NetSales\r\nFROM Orders\r\nWHERE Status = 'Completed' AND PaymentStatus = 'Paid';";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();

                        decimal netSales = 0;
                        if (result != DBNull.Value)
                            netSales = Convert.ToDecimal(result);

                        CultureInfo ph = new CultureInfo("en-PH");

                        netsalestxt.Text = netSales.ToString("C2", ph);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading net sales: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void expensereportsbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new Expenses());

        }

        private void netsalestxt_Click(object sender, EventArgs e)
        {

        }

        private void netprofitsummarybtn_Click(object sender, EventArgs e)
        {
            LoadContent(new NetProfit());
        }
    }
}
