namespace FlavorFlowIT13
{
    partial class HrCompliances
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            hrcompliancesuploadnewdocumnetbtn = new Button();
            systempanelcontents = new Panel();
            hrcompliancespoliciesbtn = new Button();
            hrcompliancescompliancesbtn = new Button();
            dgvCompliance = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvCompliance).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Location = new Point(12, 527);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1440, 190);
            panel1.TabIndex = 64;
            // 
            // hrcompliancesuploadnewdocumnetbtn
            // 
            hrcompliancesuploadnewdocumnetbtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            hrcompliancesuploadnewdocumnetbtn.Location = new Point(718, 725);
            hrcompliancesuploadnewdocumnetbtn.Margin = new Padding(3, 4, 3, 4);
            hrcompliancesuploadnewdocumnetbtn.Name = "hrcompliancesuploadnewdocumnetbtn";
            hrcompliancesuploadnewdocumnetbtn.Size = new Size(285, 83);
            hrcompliancesuploadnewdocumnetbtn.TabIndex = 61;
            hrcompliancesuploadnewdocumnetbtn.Text = "Upload New Document";
            hrcompliancesuploadnewdocumnetbtn.UseVisualStyleBackColor = true;
            hrcompliancesuploadnewdocumnetbtn.Click += hrcompliancesuploadnewdocumnetbtn_Click;
            // 
            // systempanelcontents
            // 
            systempanelcontents.BackColor = Color.White;
            systempanelcontents.Location = new Point(12, 109);
            systempanelcontents.Margin = new Padding(3, 4, 3, 4);
            systempanelcontents.Name = "systempanelcontents";
            systempanelcontents.Size = new Size(1440, 399);
            systempanelcontents.TabIndex = 60;
            // 
            // hrcompliancespoliciesbtn
            // 
            hrcompliancespoliciesbtn.BackColor = Color.Black;
            hrcompliancespoliciesbtn.FlatStyle = FlatStyle.Flat;
            hrcompliancespoliciesbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            hrcompliancespoliciesbtn.ForeColor = Color.White;
            hrcompliancespoliciesbtn.Location = new Point(389, 25);
            hrcompliancespoliciesbtn.Name = "hrcompliancespoliciesbtn";
            hrcompliancespoliciesbtn.Size = new Size(353, 77);
            hrcompliancespoliciesbtn.TabIndex = 59;
            hrcompliancespoliciesbtn.Text = "Policies";
            hrcompliancespoliciesbtn.UseVisualStyleBackColor = false;
            hrcompliancespoliciesbtn.Click += hrcompliancespoliciesbtn_Click;
            // 
            // hrcompliancescompliancesbtn
            // 
            hrcompliancescompliancesbtn.BackColor = Color.Black;
            hrcompliancescompliancesbtn.FlatStyle = FlatStyle.Flat;
            hrcompliancescompliancesbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            hrcompliancescompliancesbtn.ForeColor = Color.White;
            hrcompliancescompliancesbtn.Location = new Point(21, 25);
            hrcompliancescompliancesbtn.Name = "hrcompliancescompliancesbtn";
            hrcompliancescompliancesbtn.Size = new Size(353, 77);
            hrcompliancescompliancesbtn.TabIndex = 58;
            hrcompliancescompliancesbtn.Text = "Compliances";
            hrcompliancescompliancesbtn.UseVisualStyleBackColor = false;
            // 
            // dgvCompliance
            // 
            dgvCompliance.AllowUserToAddRows = false;
            dgvCompliance.AllowUserToDeleteRows = false;
            dgvCompliance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCompliance.BackgroundColor = Color.White;
            dgvCompliance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCompliance.Location = new Point(12, 109);
            dgvCompliance.Margin = new Padding(3, 4, 3, 4);
            dgvCompliance.Name = "dgvCompliance";
            dgvCompliance.ReadOnly = true;
            dgvCompliance.RowHeadersVisible = false;
            dgvCompliance.RowHeadersWidth = 51;
            dgvCompliance.Size = new Size(1440, 399);
            dgvCompliance.TabIndex = 65;
            dgvCompliance.CellContentClick += dgvCompliance_CellContentClick;
            // 
            // HrCompliances
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(1566, 999);
            Controls.Add(dgvCompliance);
            Controls.Add(panel1);
            Controls.Add(hrcompliancesuploadnewdocumnetbtn);
            Controls.Add(systempanelcontents);
            Controls.Add(hrcompliancespoliciesbtn);
            Controls.Add(hrcompliancescompliancesbtn);
            Name = "HrCompliances";
            Text = "HrCompliances";
            Load += HrCompliances_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCompliance).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button hrcompliancesuploadnewdocumnetbtn;
        private Panel systempanelcontents;
        private Button hrcompliancespoliciesbtn;
        private Button hrcompliancescompliancesbtn;
        private DataGridView dgvCompliance; // ✅ added declaration
    }
}
