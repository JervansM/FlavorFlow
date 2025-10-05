using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FlavorFlow
{
    partial class EmployeeForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.TextBox txtBasicSalary;
        private System.Windows.Forms.DateTimePicker dtpHireDate; // ✅ Date picker
        private System.Windows.Forms.ComboBox cmbStatus; // ✅ ComboBox
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblBasicSalary;
        private System.Windows.Forms.Label lblHireDate;
        private System.Windows.Forms.Label lblStatus;

        /// <summary>
        /// Clean up resources
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtPosition = new TextBox();
            txtBasicSalary = new TextBox();
            dtpHireDate = new DateTimePicker();
            cmbStatus = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblFirstName = new Label();
            lblLastName = new Label();
            lblPosition = new Label();
            lblBasicSalary = new Label();
            lblHireDate = new Label();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(150, 20);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(200, 23);
            txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(150, 60);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(200, 23);
            txtLastName.TabIndex = 3;
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(150, 100);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(200, 23);
            txtPosition.TabIndex = 5;
            // 
            // txtBasicSalary
            // 
            txtBasicSalary.Location = new Point(150, 140);
            txtBasicSalary.Name = "txtBasicSalary";
            txtBasicSalary.Size = new Size(200, 23);
            txtBasicSalary.TabIndex = 7;
            // 
            // dtpHireDate
            // 
            dtpHireDate.Format = DateTimePickerFormat.Short;
            dtpHireDate.Location = new Point(150, 180);
            dtpHireDate.Name = "dtpHireDate";
            dtpHireDate.Size = new Size(200, 23);
            dtpHireDate.TabIndex = 9;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Items.AddRange(new object[] { "Active", "Inactive" });
            cmbStatus.Location = new Point(150, 220);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(200, 23);
            cmbStatus.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(80, 280);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(200, 280);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // lblFirstName
            // 
            lblFirstName.Location = new Point(20, 20);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(100, 23);
            lblFirstName.TabIndex = 0;
            lblFirstName.Text = "First Name:";
            // 
            // lblLastName
            // 
            lblLastName.Location = new Point(20, 60);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(100, 23);
            lblLastName.TabIndex = 2;
            lblLastName.Text = "Last Name:";
            // 
            // lblPosition
            // 
            lblPosition.Location = new Point(20, 100);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(100, 23);
            lblPosition.TabIndex = 4;
            lblPosition.Text = "Position:";
            // 
            // lblBasicSalary
            // 
            lblBasicSalary.Location = new Point(20, 140);
            lblBasicSalary.Name = "lblBasicSalary";
            lblBasicSalary.Size = new Size(100, 23);
            lblBasicSalary.TabIndex = 6;
            lblBasicSalary.Text = "Basic Salary:";
            // 
            // lblHireDate
            // 
            lblHireDate.Location = new Point(20, 180);
            lblHireDate.Name = "lblHireDate";
            lblHireDate.Size = new Size(100, 23);
            lblHireDate.TabIndex = 8;
            lblHireDate.Text = "Hire Date:";
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(20, 220);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(100, 23);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Status:";
            // 
            // EmployeeForm
            // 
            ClientSize = new Size(400, 400);
            Controls.Add(lblFirstName);
            Controls.Add(txtFirstName);
            Controls.Add(lblLastName);
            Controls.Add(txtLastName);
            Controls.Add(lblPosition);
            Controls.Add(txtPosition);
            Controls.Add(lblBasicSalary);
            Controls.Add(txtBasicSalary);
            Controls.Add(lblHireDate);
            Controls.Add(dtpHireDate);
            Controls.Add(lblStatus);
            Controls.Add(cmbStatus);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Name = "EmployeeForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Employee";
            Load += EmployeeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
