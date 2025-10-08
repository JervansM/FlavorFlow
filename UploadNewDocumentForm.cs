using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FlavorFlowIT13
{
    public partial class UploadNewDocumentForm : Form
    {
        private string connectionString =
            "Data Source=DESKTOP-2SPCOE3;Initial Catalog=FlavorFlow;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        private string selectedFilePath = null;

        public UploadNewDocumentForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.BackColor = Color.WhiteSmoke;
        }

        private void UploadNewDocumentForm_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            LoadDocumentTypes();
            StyleControls();

            dtpIssueDate.MaxDate = DateTime.Today;
            dtpExpiryDate.MinDate = DateTime.Today.AddDays(1);
        }

        private void StyleControls()
        {
            lblTitle.Text = "Upload New Compliance Document";
            lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(255, 128, 0);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void LoadEmployees()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT EmployeeID, (FirstName + ' ' + LastName) AS FullName FROM Employee";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbEmployee.DataSource = dt;
                    cmbEmployee.DisplayMember = "FullName";
                    cmbEmployee.ValueMember = "EmployeeID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employees: " + ex.Message);
            }
        }

        private void LoadDocumentTypes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT DISTINCT DocumentType FROM EmployeeDocuments WHERE DocumentType IS NOT NULL";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                        cmbDocumentType.Items.Add(reader["DocumentType"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading document types: " + ex.Message);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "PDF Files|*.pdf|Image Files|*.jpg;*.jpeg;*.png|All Files|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = ofd.FileName;
                    txtFilePath.Text = selectedFilePath;
                    lblFileName.Text = Path.GetFileName(selectedFilePath);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedIndex < 0 || string.IsNullOrWhiteSpace(cmbDocumentType.Text) || selectedFilePath == null)
            {
                MessageBox.Show("Please select an employee, document type, and upload a file.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime today = DateTime.Today;
            DateTime issueDate = dtpIssueDate.Value.Date;
            DateTime expiryDate = dtpExpiryDate.Value.Date;

            if (issueDate > today)
            {
                MessageBox.Show("The issue date cannot be in the future.", "Invalid Issue Date",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (expiryDate <= issueDate)
            {
                MessageBox.Show("The expiry date must be later than the issue date.", "Invalid Expiry Date",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UploadedDocuments");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string fileName = Path.GetFileName(selectedFilePath);
                string destinationPath = Path.Combine(folderPath, fileName);

                if (File.Exists(destinationPath))
                {
                    string uniqueName = Path.GetFileNameWithoutExtension(fileName)
                        + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss")
                        + Path.GetExtension(fileName);
                    destinationPath = Path.Combine(folderPath, uniqueName);
                }

                File.Copy(selectedFilePath, destinationPath, true);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO EmployeeDocuments 
                                    (EmployeeID, DocumentType, IssueDate, ExpiryDate, Status, FilePath)
                                     VALUES (@EmployeeID, @DocumentType, @IssueDate, @ExpiryDate, @Status, @FilePath)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", cmbEmployee.SelectedValue);
                        cmd.Parameters.AddWithValue("@DocumentType", cmbDocumentType.Text);
                        cmd.Parameters.AddWithValue("@IssueDate", issueDate);
                        cmd.Parameters.AddWithValue("@ExpiryDate", expiryDate);
                        cmd.Parameters.AddWithValue("@Status", "Valid");
                        cmd.Parameters.AddWithValue("@FilePath", destinationPath);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("✅ Document uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving document: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
