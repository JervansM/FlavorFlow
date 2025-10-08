using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FlavorFlowIT13
{
    public partial class RenewDocumentForm : Form
    {
        private ComplianceDocument _document;
        private string connectionString =
            "Data Source=DESKTOP-2SPCOE3;Initial Catalog=FlavorFlow;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
        private string uploadedFilePath = string.Empty;

        public RenewDocumentForm(ComplianceDocument document)
        {
            InitializeComponent();
            _document = document;
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.BackColor = Color.WhiteSmoke;
        }

        private void RenewDocumentForm_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            LoadDocumentTypes();

            if (_document != null)
            {
                cmbEmployee.SelectedValue = _document.EmpID;
                cmbDocumentType.Text = _document.DocumentType;
                dtpIssueDate.Value = _document.IssueDate != DateTime.MinValue ? _document.IssueDate : DateTime.Today;
                dtpExpiryDate.Value = _document.ExpiryDate != DateTime.MinValue ? _document.ExpiryDate : DateTime.Today.AddYears(1);
                txtStatus.Text = "Valid";
            }

            cmbEmployee.Enabled = false;
            cmbDocumentType.Enabled = false;
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
                    {
                        cmbDocumentType.Items.Add(reader["DocumentType"].ToString());
                    }
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
                ofd.Title = "Select Document File";
                ofd.Filter = "PDF Files (*.pdf)|*.pdf|Image Files (*.jpg;*.png)|*.jpg;*.png|All Files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string fileName = Path.GetFileName(ofd.FileName);
                    string destinationDir = Path.Combine(Application.StartupPath, "docs");

                    // Ensure folder exists
                    if (!Directory.Exists(destinationDir))
                        Directory.CreateDirectory(destinationDir);

                    string destinationPath = Path.Combine(destinationDir, fileName);

                    // Copy file to app docs folder
                    File.Copy(ofd.FileName, destinationPath, true);

                    uploadedFilePath = "docs/" + fileName;
                    lblFileName.Text = fileName;
                }
            }
        }

        private void DtpIssueDate_ValueChanged(object sender, EventArgs e)
        {
            dtpExpiryDate.MinDate = dtpIssueDate.Value.AddDays(1);
            if (dtpExpiryDate.Value <= dtpIssueDate.Value)
                dtpExpiryDate.Value = dtpIssueDate.Value.AddYears(1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime issueDate = dtpIssueDate.Value;
            DateTime expiryDate = dtpExpiryDate.Value;

            if (expiryDate <= issueDate)
            {
                MessageBox.Show("Expiry date must be later than the issue date.",
                                "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (issueDate <= _document.ExpiryDate)
            {
                MessageBox.Show("New issue date must be later than the previous expiry date.",
                                "Invalid Issue Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(uploadedFilePath))
            {
                MessageBox.Show("Please upload the renewed document before saving.",
                                "Missing File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"UPDATE EmployeeDocuments
                                     SET EmployeeID = @EmployeeID,
                                         DocumentType = @DocumentType,
                                         IssueDate = @IssueDate,
                                         ExpiryDate = @ExpiryDate,
                                         Status = @Status,
                                         FilePath = @FilePath,
                                         LastUpdated = GETDATE()
                                     WHERE DocumentID = @DocumentID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", cmbEmployee.SelectedValue);
                        cmd.Parameters.AddWithValue("@DocumentType", cmbDocumentType.Text);
                        cmd.Parameters.AddWithValue("@IssueDate", issueDate);
                        cmd.Parameters.AddWithValue("@ExpiryDate", expiryDate);
                        cmd.Parameters.AddWithValue("@Status", txtStatus.Text);
                        cmd.Parameters.AddWithValue("@FilePath", uploadedFilePath);
                        cmd.Parameters.AddWithValue("@DocumentID", _document.DocumentID);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("✅ Document renewed successfully!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating document: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
