namespace FlavorFlowIT13
{
    partial class RenewDocumentForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.cmbDocumentType = new System.Windows.Forms.ComboBox();
            this.dtpIssueDate = new System.Windows.Forms.DateTimePicker();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblDocType = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblUpload = new System.Windows.Forms.Label();

            this.SuspendLayout();

            int labelX = 70;
            int fieldX = 220;
            int width = 300;
            int top = 80;
            int space = 50;

            // Title
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Text = "Renew Compliance Document";
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Height = 60;

            // Employee
            this.lblEmployee.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEmployee.Location = new System.Drawing.Point(labelX, top);
            this.lblEmployee.Text = "Employee:";
            this.cmbEmployee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEmployee.Location = new System.Drawing.Point(fieldX, top - 5);
            this.cmbEmployee.Size = new System.Drawing.Size(width, 30);

            // Document Type
            this.lblDocType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDocType.Location = new System.Drawing.Point(labelX, top + space);
            this.lblDocType.Text = "Document Type:";
            this.cmbDocumentType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDocumentType.Location = new System.Drawing.Point(fieldX, top + space - 5);
            this.cmbDocumentType.Size = new System.Drawing.Size(width, 30);

            // Issue Date
            this.lblIssueDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblIssueDate.Location = new System.Drawing.Point(labelX, top + space * 2);
            this.lblIssueDate.Text = "Issue Date:";
            this.dtpIssueDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpIssueDate.Location = new System.Drawing.Point(fieldX, top + space * 2 - 5);
            this.dtpIssueDate.Size = new System.Drawing.Size(width, 30);
            this.dtpIssueDate.ValueChanged += new System.EventHandler(this.DtpIssueDate_ValueChanged);

            // Expiry Date
            this.lblExpiryDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblExpiryDate.Location = new System.Drawing.Point(labelX, top + space * 3);
            this.lblExpiryDate.Text = "Expiry Date:";
            this.dtpExpiryDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpExpiryDate.Location = new System.Drawing.Point(fieldX, top + space * 3 - 5);
            this.dtpExpiryDate.Size = new System.Drawing.Size(width, 30);

            // Status
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(labelX, top + space * 4);
            this.lblStatus.Text = "Status:";
            this.txtStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStatus.Location = new System.Drawing.Point(fieldX, top + space * 4 - 5);
            this.txtStatus.Size = new System.Drawing.Size(width, 30);
            this.txtStatus.Text = "Valid";
            this.txtStatus.ReadOnly = true;

            // Upload
            this.lblUpload.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUpload.Location = new System.Drawing.Point(labelX, top + space * 5);
            this.lblUpload.Text = "Upload File:";
            this.btnUpload.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpload.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(255, 128, 0);
            this.btnUpload.Location = new System.Drawing.Point(fieldX, top + space * 5 - 5);
            this.btnUpload.Size = new System.Drawing.Size(120, 30);
            this.btnUpload.Text = "Upload";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);

            this.lblFileName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblFileName.ForeColor = System.Drawing.Color.Gray;
            this.lblFileName.Location = new System.Drawing.Point(fieldX + 130, top + space * 5);
            this.lblFileName.Text = "No file selected";

            // Save and Cancel
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(255, 128, 0);
            this.btnSave.Location = new System.Drawing.Point(180, 420);
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCancel.Location = new System.Drawing.Point(320, 420);
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(620, 490);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.BackColor = System.Drawing.Color.White;

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.lblDocType);
            this.Controls.Add(this.cmbDocumentType);
            this.Controls.Add(this.lblIssueDate);
            this.Controls.Add(this.dtpIssueDate);
            this.Controls.Add(this.lblExpiryDate);
            this.Controls.Add(this.dtpExpiryDate);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblUpload);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Load += new System.EventHandler(this.RenewDocumentForm_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle, lblEmployee, lblDocType, lblIssueDate, lblExpiryDate, lblStatus, lblUpload, lblFileName;
        private System.Windows.Forms.ComboBox cmbEmployee, cmbDocumentType;
        private System.Windows.Forms.DateTimePicker dtpIssueDate, dtpExpiryDate;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnSave, btnCancel, btnUpload;
    }
}
