using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FlavorFlowIT13
{
    public partial class HrCompliances : Form
    {
        private List<ComplianceDocument> documents;
        private string connectionString =
            "Data Source=DESKTOP-2SPCOE3;Initial Catalog=FlavorFlow;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        public HrCompliances()
        {
            InitializeComponent();
        }

        private void HrCompliances_Load(object sender, EventArgs e)
        {
            LoadComplianceData();
            AddRenewButtonColumn();
            CheckExpiringDocuments();
            StyleGrid();

            // ✅ Make sure the systempanelcontents is hidden initially
            systempanelcontents.Visible = false;

            // ✅ Wire up the compliance button click event
            hrcompliancescompliancesbtn.Click += hrcompliancescompliancesbtn_Click;
        }

        // ✅ Load all documents
        private void LoadComplianceData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            d.DocumentID,
                            e.EmployeeID,
                            (e.FirstName + ' ' + e.LastName) AS EmployeeName,
                            d.DocumentType,
                            d.IssueDate,
                            d.ExpiryDate,
                            d.Status,
                            d.FilePath
                        FROM dbo.EmployeeDocuments d
                        INNER JOIN dbo.Employee e ON d.EmployeeID = e.EmployeeID
                        ORDER BY 
                            CASE 
                                WHEN d.Status = 'Expired' THEN 1
                                WHEN d.Status = 'Expiring' THEN 2
                                WHEN d.Status = 'Valid' THEN 3
                                ELSE 4
                            END, e.FirstName ASC;";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    documents = new List<ComplianceDocument>();

                    while (reader.Read())
                    {
                        documents.Add(new ComplianceDocument
                        {
                            DocumentID = Convert.ToInt32(reader["DocumentID"]),
                            EmpID = reader["EmployeeID"].ToString(),
                            Name = reader["EmployeeName"].ToString(),
                            DocumentType = reader["DocumentType"].ToString(),
                            IssueDate = reader["IssueDate"] != DBNull.Value ? Convert.ToDateTime(reader["IssueDate"]) : DateTime.MinValue,
                            ExpiryDate = reader["ExpiryDate"] != DBNull.Value ? Convert.ToDateTime(reader["ExpiryDate"]) : DateTime.MinValue,
                            Status = reader["Status"].ToString(),
                            FilePath = reader["FilePath"].ToString()
                        });
                    }

                    reader.Close();
                    dgvCompliance.DataSource = documents;

                    // Hide internal columns
                    dgvCompliance.Columns["DocumentID"].Visible = false;
                    dgvCompliance.Columns["FilePath"].Visible = false;
                    dgvCompliance.Columns["EmpID"].Visible = false; // 👈 Hides Employee ID column

                    // Rename headers for visible columns
                    dgvCompliance.Columns["Name"].HeaderText = "Employee Name";
                    dgvCompliance.Columns["DocumentType"].HeaderText = "Document Type";
                    dgvCompliance.Columns["IssueDate"].HeaderText = "Issue Date";
                    dgvCompliance.Columns["ExpiryDate"].HeaderText = "Expiry Date";
                    dgvCompliance.Columns["Status"].HeaderText = "Status";
                }

                // ✅ Status color formatting
                foreach (DataGridViewRow row in dgvCompliance.Rows)
                {
                    string status = row.Cells["Status"].Value?.ToString();
                    if (status == "Valid") row.Cells["Status"].Style.ForeColor = Color.Green;
                    else if (status == "Expiring") row.Cells["Status"].Style.ForeColor = Color.Orange;
                    else row.Cells["Status"].Style.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ Add Renew Button
        private void AddRenewButtonColumn()
        {
            if (!dgvCompliance.Columns.Contains("Renew"))
            {
                DataGridViewButtonColumn renewColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Action",
                    Name = "Renew",
                    Text = "Renew",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat
                };
                dgvCompliance.Columns.Add(renewColumn);

                dgvCompliance.CellClick += DgvCompliance_CellClick;
                dgvCompliance.CellPainting += DgvCompliance_CellPainting; // 🎨 custom round button
            }
        }

        // ✅ Handle Renew button click
        private void DgvCompliance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvCompliance.Columns["Renew"].Index) return;

            var selectedDoc = documents[e.RowIndex];

            if (selectedDoc.Status == "Valid")
            {
                MessageBox.Show("This document is still valid and cannot be renewed.",
                    "Renew Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (RenewDocumentForm renewForm = new RenewDocumentForm(selectedDoc))
            {
                if (renewForm.ShowDialog() == DialogResult.OK)
                {
                    LoadComplianceData();
                    CheckExpiringDocuments();
                }
            }
        }

        // 🎨 Custom rounded outlined Renew button
        private void DgvCompliance_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvCompliance.Columns["Renew"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);

                Rectangle rect = new Rectangle(e.CellBounds.X + 10, e.CellBounds.Y + 8,
                                               e.CellBounds.Width - 15, e.CellBounds.Height - 16);


                using (Pen borderPen = new Pen(Color.FromArgb(255, 128, 0), 2))
                using (Brush textBrush = new SolidBrush(Color.FromArgb(255, 128, 0)))
                using (Font btnFont = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    int radius = 15;
                    var path = RoundedRect(rect, radius);
                    e.Graphics.DrawPath(borderPen, path);

                    string text = "Renew";
                    SizeF textSize = e.Graphics.MeasureString(text, btnFont);
                    float textX = rect.X + (rect.Width - textSize.Width) / 2;
                    float textY = rect.Y + (rect.Height - textSize.Height) / 2;
                    e.Graphics.DrawString(text, btnFont, textBrush, textX, textY);
                }

                e.Handled = true;
            }
        }

        // ✅ Helper for rounded button
        private System.Drawing.Drawing2D.GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        // ✅ Document Alerts Panel
        private void CheckExpiringDocuments()
        {
            panel1.Controls.Clear();
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.AutoScroll = true;

            Label header = new Label
            {
                Text = "📋 Document Alerts",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 128, 0),
                AutoSize = true,
                Location = new Point(15, 10)
            };
            panel1.Controls.Add(header);

            List<string> alerts = new List<string>();
            DateTime now = DateTime.Now;

            foreach (var doc in documents)
            {
                TimeSpan diff = doc.ExpiryDate - now;
                int daysLeft = (int)diff.TotalDays;

                if (daysLeft <= 30 && daysLeft > 0)
                    alerts.Add($"⚠️ {doc.Name}: {doc.DocumentType} expiring in {daysLeft} days");
                else if (daysLeft <= 0)
                    alerts.Add($"❌ {doc.Name}: {doc.DocumentType} EXPIRED");
            }

            int y = 55;
            if (alerts.Count == 0)
            {
                panel1.Controls.Add(new Label
                {
                    Text = "✅ All documents are up to date.",
                    Location = new Point(25, y),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12F),
                    ForeColor = Color.Green
                });
            }
            else
            {
                foreach (var alert in alerts)
                {
                    panel1.Controls.Add(new Label
                    {
                        Text = alert,
                        Location = new Point(25, y),
                        AutoSize = true,
                        Font = new Font("Segoe UI", 12F),
                        ForeColor = alert.Contains("EXPIRED") ? Color.Red : Color.Orange
                    });
                    y += 35;
                }
            }
        }

        // ✅ Grid Styling
        private void StyleGrid()
        {
            dgvCompliance.BackgroundColor = Color.White;
            dgvCompliance.BorderStyle = BorderStyle.None;
            dgvCompliance.GridColor = Color.LightGray;
            dgvCompliance.EnableHeadersVisualStyles = false;

            dgvCompliance.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 128, 0);
            dgvCompliance.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCompliance.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvCompliance.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCompliance.ColumnHeadersHeight = 40;

            dgvCompliance.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
            dgvCompliance.DefaultCellStyle.ForeColor = Color.Black;
            dgvCompliance.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 224, 192);
            dgvCompliance.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCompliance.RowTemplate.Height = 35;

            dgvCompliance.AllowUserToAddRows = false;
            dgvCompliance.AllowUserToDeleteRows = false;
            dgvCompliance.ReadOnly = true;
        }

        private void label10_Click(object sender, EventArgs e) { }

        private void dgvCompliance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void hrcompliancesuploadnewdocumnetbtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (UploadNewDocumentForm uploadForm = new UploadNewDocumentForm())
                {
                    // Open the Upload Document form as a modal dialog
                    if (uploadForm.ShowDialog() == DialogResult.OK)
                    {
                        // Refresh the compliance data after a new document is uploaded
                        LoadComplianceData();
                        CheckExpiringDocuments();

                        MessageBox.Show("New document uploaded successfully!",
                            "Upload Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while uploading the document:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ✅ When Policies button is clicked
        private void hrcompliancespoliciesbtn_Click(object sender, EventArgs e)
        {
            // Hide the compliance-specific controls
            dgvCompliance.Visible = false;
            panel1.Visible = false;
            hrcompliancesuploadnewdocumnetbtn.Visible = false;

            // Clear the system panel
            systempanelcontents.Controls.Clear();

            // ✅ Expand the panel to cover the entire content area
            systempanelcontents.Location = new Point(12, 109);
            systempanelcontents.Size = new Size(1440, 700); // Cover dgv + panel1 + button area

            // Create the HrPolicies form as a child form
            HrPolicies policiesForm = new HrPolicies
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            // Add it to systempanelcontents panel
            systempanelcontents.Controls.Add(policiesForm);
            systempanelcontents.Visible = true;
            policiesForm.Show();
        }
        // ✅ When Compliances button is clicked (going back)
        private void hrcompliancescompliancesbtn_Click(object sender, EventArgs e)
        {
            // Clear the system panel (remove policies form)
            systempanelcontents.Controls.Clear();
            systempanelcontents.Visible = false;

            // ✅ Restore original size
            systempanelcontents.Location = new Point(12, 109);
            systempanelcontents.Size = new Size(1440, 399);

            // Show the compliance controls
            dgvCompliance.Visible = true;
            panel1.Visible = true;
            hrcompliancesuploadnewdocumnetbtn.Visible = true;

            // Refresh the data
            LoadComplianceData();
            CheckExpiringDocuments();
        }

    }
        public class ComplianceDocument
    {
        public int DocumentID { get; set; }
        public string EmpID { get; set; }
        public string Name { get; set; }
        public string DocumentType { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Status { get; set; }
        public string FilePath { get; set; }
    }
}
