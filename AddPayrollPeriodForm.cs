using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;  // ✅ use Microsoft.Data.SqlClient

namespace FlavorFlowIT13
{
    public partial class AddPayrollPeriodForm : Form
    {
        public AddPayrollPeriodForm()
        {
            InitializeComponent();
            cmbStatus.Items.Add("Open");
            cmbStatus.Items.Add("Closed");
            cmbStatus.SelectedIndex = 0; // default Open
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connStr = "Data Source=DESKTOP-2SPCOE3;Initial Catalog=FlavorFlow;Integrated Security=True;TrustServerCertificate=True"; // adjust your connection string

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "INSERT INTO PayrollPeriod (StartDate, EndDate, Status) VALUES (@StartDate, @EndDate, @Status)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date);
                cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Payroll period added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
