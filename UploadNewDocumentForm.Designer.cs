namespace FlavorFlowIT13
{
    partial class UploadNewDocumentForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblDocType = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();

            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.cmbDocumentType = new System.Windows.Forms.ComboBox();
            this.dtpIssueDate = new System.Windows.Forms.DateTimePicker();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.txtFilePath = new System.Windows.Forms.TextBox();

            this.btnUpload = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // lblFileName
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFileName.ForeColor = System.Drawing.Color.DimGray;
            this.lblFileName.Location = new System.Drawing.Point(220, 340);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(0, 23);
            this.lblFileName.TabIndex = 10;

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Height = 60;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
            this.lblTitle.Text = "Upload New Document";

            // Labels
            int labelX = 60;
            int inputX = 220;
            int startY = 90;
            int spacingY = 50;

            this.lblEmployee.Location = new System.Drawing.Point(labelX, startY);
            this.lblEmployee.Text = "Employee:";
            this.lblEmployee.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.lblDocType.Location = new System.Drawing.Point(labelX, startY + spacingY);
            this.lblDocType.Text = "Document Type:";
            this.lblDocType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.lblIssueDate.Location = new System.Drawing.Point(labelX, startY + spacingY * 2);
            this.lblIssueDate.Text = "Issue Date:";
            this.lblIssueDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.lblExpiryDate.Location = new System.Drawing.Point(labelX, startY + spacingY * 3);
            this.lblExpiryDate.Text = "Expiry Date:";
            this.lblExpiryDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.lblFilePath.Location = new System.Drawing.Point(labelX, startY + spacingY * 4);
            this.lblFilePath.Text = "File Path:";
            this.lblFilePath.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // Inputs
            this.cmbEmployee.Location = new System.Drawing.Point(inputX, startY);
            this.cmbEmployee.Size = new System.Drawing.Size(300, 30);

            this.cmbDocumentType.Location = new System.Drawing.Point(inputX, startY + spacingY);
            this.cmbDocumentType.Size = new System.Drawing.Size(300, 30);

            this.dtpIssueDate.Location = new System.Drawing.Point(inputX, startY + spacingY * 2);
            this.dtpIssueDate.Size = new System.Drawing.Size(300, 30);

            this.dtpExpiryDate.Location = new System.Drawing.Point(inputX, startY + spacingY * 3);
            this.dtpExpiryDate.Size = new System.Drawing.Size(300, 30);

            this.txtFilePath.Location = new System.Drawing.Point(inputX, startY + spacingY * 4);
            this.txtFilePath.Size = new System.Drawing.Size(220, 30);
            this.txtFilePath.ReadOnly = true;

            this.btnUpload.Location = new System.Drawing.Point(inputX + 230, startY + spacingY * 4);
            this.btnUpload.Size = new System.Drawing.Size(70, 30);
            this.btnUpload.Text = "Browse";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);

            // Buttons
            this.btnSave.Location = new System.Drawing.Point(180, startY + spacingY * 5 + 20);
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Location = new System.Drawing.Point(320, startY + spacingY * 5 + 20);
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Form setup
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.AddRange(new Control[]
            {
                lblTitle, lblEmployee, lblDocType, lblIssueDate, lblExpiryDate, lblFilePath, lblFileName,
                cmbEmployee, cmbDocumentType, dtpIssueDate, dtpExpiryDate, txtFilePath,
                btnUpload, btnSave, btnCancel
            });
            this.Load += new System.EventHandler(this.UploadNewDocumentForm_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Label lblEmployee;
        private Label lblDocType;
        private Label lblIssueDate;
        private Label lblExpiryDate;
        private Label lblFilePath;
        private Label lblFileName;

        private ComboBox cmbEmployee;
        private ComboBox cmbDocumentType;
        private DateTimePicker dtpIssueDate;
        private DateTimePicker dtpExpiryDate;
        private TextBox txtFilePath;

        private Button btnUpload;
        private Button btnSave;
        private Button btnCancel;
    }
}
