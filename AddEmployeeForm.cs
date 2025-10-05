using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FlavorFlow
{
    public partial class EmployeeForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-2SPCOE3;Initial Catalog=FlavorFlow;Integrated Security=True;TrustServerCertificate=True";

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
    }
}
