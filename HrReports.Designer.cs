namespace FlavorFlowIT13
{
    partial class HrReports
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
            systempanelcontents = new Panel();
            hrreportsanalyticsbtn = new Button();
            hrreportsreportbtn = new Button();
            hrreportsgeneratereportbtn = new Button();
            SuspendLayout();
            // 
            // systempanelcontents
            // 
            systempanelcontents.BackColor = Color.White;
            systempanelcontents.Location = new Point(-38, 136);
            systempanelcontents.Name = "systempanelcontents";
            systempanelcontents.Size = new Size(1447, 478);
            systempanelcontents.TabIndex = 74;
            // 
            // hrreportsanalyticsbtn
            // 
            hrreportsanalyticsbtn.BackColor = Color.Black;
            hrreportsanalyticsbtn.BackgroundImageLayout = ImageLayout.None;
            hrreportsanalyticsbtn.Cursor = Cursors.Hand;
            hrreportsanalyticsbtn.FlatStyle = FlatStyle.Flat;
            hrreportsanalyticsbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hrreportsanalyticsbtn.ForeColor = Color.White;
            hrreportsanalyticsbtn.Location = new Point(296, 57);
            hrreportsanalyticsbtn.Name = "hrreportsanalyticsbtn";
            hrreportsanalyticsbtn.Size = new Size(309, 58);
            hrreportsanalyticsbtn.TabIndex = 73;
            hrreportsanalyticsbtn.Text = "Analytics";
            hrreportsanalyticsbtn.UseVisualStyleBackColor = false;
            // 
            // hrreportsreportbtn
            // 
            hrreportsreportbtn.BackColor = Color.Black;
            hrreportsreportbtn.BackgroundImageLayout = ImageLayout.None;
            hrreportsreportbtn.Cursor = Cursors.Hand;
            hrreportsreportbtn.FlatStyle = FlatStyle.Flat;
            hrreportsreportbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hrreportsreportbtn.ForeColor = Color.White;
            hrreportsreportbtn.Location = new Point(-38, 57);
            hrreportsreportbtn.Name = "hrreportsreportbtn";
            hrreportsreportbtn.Size = new Size(309, 58);
            hrreportsreportbtn.TabIndex = 72;
            hrreportsreportbtn.Text = "Reports";
            hrreportsreportbtn.UseVisualStyleBackColor = false;
            // 
            // hrreportsgeneratereportbtn
            // 
            hrreportsgeneratereportbtn.BackColor = Color.Black;
            hrreportsgeneratereportbtn.BackgroundImageLayout = ImageLayout.None;
            hrreportsgeneratereportbtn.Cursor = Cursors.Hand;
            hrreportsgeneratereportbtn.FlatStyle = FlatStyle.Flat;
            hrreportsgeneratereportbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hrreportsgeneratereportbtn.ForeColor = Color.White;
            hrreportsgeneratereportbtn.Location = new Point(535, 646);
            hrreportsgeneratereportbtn.Name = "hrreportsgeneratereportbtn";
            hrreportsgeneratereportbtn.Size = new Size(309, 58);
            hrreportsgeneratereportbtn.TabIndex = 75;
            hrreportsgeneratereportbtn.Text = "Generate Report";
            hrreportsgeneratereportbtn.UseVisualStyleBackColor = false;
            // 
            // HrReports
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1544, 813);
            Controls.Add(hrreportsgeneratereportbtn);
            Controls.Add(systempanelcontents);
            Controls.Add(hrreportsanalyticsbtn);
            Controls.Add(hrreportsreportbtn);
            Name = "HrReports";
            Text = "HrReports";
            Load += HrReports_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel systempanelcontents;
        private Button hrreportsanalyticsbtn;
        private Button hrreportsreportbtn;
        private Button hrreportsgeneratereportbtn;
    }
}