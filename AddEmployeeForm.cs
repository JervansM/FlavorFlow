using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FlavorFlow
{
    public partial class EmployeeForm : Form
    {
        private readonly string connectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Employee (FirstName, LastName, Position, BasicSalary, HireDate, Status)
                                     VALUES (@FirstName, @LastName, @Position, @BasicSalary, @HireDate, @Status)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@Position", txtPosition.Text);
                        cmd.Parameters.AddWithValue("@BasicSalary", decimal.Parse(txtBasicSalary.Text));

                        // ✅ Use DateTimePicker instead of parsing text
                        cmd.Parameters.AddWithValue("@HireDate", dtpHireDate.Value);

                        // ✅ Get selected value from ComboBox
                        cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem?.ToString() ?? "Inactive");

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Employee saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving employee: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
