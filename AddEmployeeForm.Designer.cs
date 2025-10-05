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
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.txtBasicSalary = new System.Windows.Forms.TextBox();
            this.dtpHireDate = new System.Windows.Forms.DateTimePicker();
            this.cmbStatus = new System.Windows.Forms.ComboBox();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblBasicSalary = new System.Windows.Forms.Label();
            this.lblHireDate = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // Form properties
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Employee";

            // Labels + Inputs
            this.lblFirstName.Text = "First Name:";
            this.lblFirstName.Location = new System.Drawing.Point(20, 20);
            this.txtFirstName.Location = new System.Drawing.Point(150, 20);
            this.txtFirstName.Width = 200;

            this.lblLastName.Text = "Last Name:";
            this.lblLastName.Location = new System.Drawing.Point(20, 60);
            this.txtLastName.Location = new System.Drawing.Point(150, 60);
            this.txtLastName.Width = 200;

            this.lblPosition.Text = "Position:";
            this.lblPosition.Location = new System.Drawing.Point(20, 100);
            this.txtPosition.Location = new System.Drawing.Point(150, 100);
            this.txtPosition.Width = 200;

            this.lblBasicSalary.Text = "Basic Salary:";
            this.lblBasicSalary.Location = new System.Drawing.Point(20, 140);
            this.txtBasicSalary.Location = new System.Drawing.Point(150, 140);
            this.txtBasicSalary.Width = 200;

            this.lblHireDate.Text = "Hire Date:";
            this.lblHireDate.Location = new System.Drawing.Point(20, 180);
            this.dtpHireDate.Location = new System.Drawing.Point(150, 180);
            this.dtpHireDate.Width = 200;
            this.dtpHireDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblStatus.Text = "Status:";
            this.lblStatus.Location = new System.Drawing.Point(20, 220);
            this.cmbStatus.Location = new System.Drawing.Point(150, 220);
            this.cmbStatus.Width = 200;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] { "Active", "Inactive" });

            // Buttons
            this.btnSave.Text = "Save";
            this.btnSave.Location = new System.Drawing.Point(80, 280);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(200, 280);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Add controls
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.lblBasicSalary);
            this.Controls.Add(this.txtBasicSalary);
            this.Controls.Add(this.lblHireDate);
            this.Controls.Add(this.dtpHireDate);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            this.ResumeLayout(false);
        }

        #endregion
    }
}
