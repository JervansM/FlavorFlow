namespace FlavorFlowIT13
{
    partial class ExpensesOrigin
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
            dgvexpenses = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvexpenses).BeginInit();
            SuspendLayout();
            // 
            // dgvexpenses
            // 
            dgvexpenses.AllowUserToAddRows = false;
            dgvexpenses.AllowUserToDeleteRows = false;
            dgvexpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvexpenses.Dock = DockStyle.Fill;
            dgvexpenses.Location = new Point(0, 0);
            dgvexpenses.Name = "dgvexpenses";
            dgvexpenses.ReadOnly = true;
            dgvexpenses.Size = new Size(1439, 737);
            dgvexpenses.TabIndex = 0;
            dgvexpenses.CellContentClick += dgvexpenses_CellContentClick;
            // 
            // ExpensesOrigin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1439, 737);
            Controls.Add(dgvexpenses);
            Name = "ExpensesOrigin";
            Text = "ExpensesOrigin";
            Load += ExpensesOrigin_Load;
            ((System.ComponentModel.ISupportInitialize)dgvexpenses).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvexpenses;
    }
}