namespace FlavorFlowIT13
{
    partial class HrAnalytics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HrAnalytics));
            systempanelcontents = new Panel();
            hranalyticsanalyticstxt = new TextBox();
            label9 = new Label();
            hranalyticsanalyticsbtn = new Button();
            hranalyticsreportbtn = new Button();
            systempanelcontents.SuspendLayout();
            SuspendLayout();
            // 
            // systempanelcontents
            // 
            systempanelcontents.BackColor = Color.White;
            systempanelcontents.Controls.Add(hranalyticsanalyticstxt);
            systempanelcontents.Controls.Add(label9);
            systempanelcontents.Location = new Point(-38, 105);
            systempanelcontents.Name = "systempanelcontents";
            systempanelcontents.Size = new Size(1447, 556);
            systempanelcontents.TabIndex = 71;
            // 
            // hranalyticsanalyticstxt
            // 
            hranalyticsanalyticstxt.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            hranalyticsanalyticstxt.Location = new Point(89, 74);
            hranalyticsanalyticstxt.Multiline = true;
            hranalyticsanalyticstxt.Name = "hranalyticsanalyticstxt";
            hranalyticsanalyticstxt.Size = new Size(373, 177);
            hranalyticsanalyticstxt.TabIndex = 16;
            hranalyticsanalyticstxt.Text = resources.GetString("hranalyticsanalyticstxt.Text");
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label9.Location = new Point(67, 21);
            label9.Name = "label9";
            label9.Size = new Size(357, 50);
            label9.TabIndex = 10;
            label9.Text = "Analytics\n📅 Monthly Summary (September 2025)";
            // 
            // hranalyticsanalyticsbtn
            // 
            hranalyticsanalyticsbtn.BackColor = Color.Black;
            hranalyticsanalyticsbtn.BackgroundImageLayout = ImageLayout.None;
            hranalyticsanalyticsbtn.Cursor = Cursors.Hand;
            hranalyticsanalyticsbtn.FlatStyle = FlatStyle.Flat;
            hranalyticsanalyticsbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hranalyticsanalyticsbtn.ForeColor = Color.White;
            hranalyticsanalyticsbtn.Location = new Point(296, 26);
            hranalyticsanalyticsbtn.Name = "hranalyticsanalyticsbtn";
            hranalyticsanalyticsbtn.Size = new Size(309, 58);
            hranalyticsanalyticsbtn.TabIndex = 70;
            hranalyticsanalyticsbtn.Text = "Analytics";
            hranalyticsanalyticsbtn.UseVisualStyleBackColor = false;
            // 
            // hranalyticsreportbtn
            // 
            hranalyticsreportbtn.BackColor = Color.Black;
            hranalyticsreportbtn.BackgroundImageLayout = ImageLayout.None;
            hranalyticsreportbtn.Cursor = Cursors.Hand;
            hranalyticsreportbtn.FlatStyle = FlatStyle.Flat;
            hranalyticsreportbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hranalyticsreportbtn.ForeColor = Color.White;
            hranalyticsreportbtn.Location = new Point(-38, 26);
            hranalyticsreportbtn.Name = "hranalyticsreportbtn";
            hranalyticsreportbtn.Size = new Size(309, 58);
            hranalyticsreportbtn.TabIndex = 69;
            hranalyticsreportbtn.Text = "Reports";
            hranalyticsreportbtn.UseVisualStyleBackColor = false;
            // 
            // HrAnalytics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(systempanelcontents);
            Controls.Add(hranalyticsanalyticsbtn);
            Controls.Add(hranalyticsreportbtn);
            Name = "HrAnalytics";
            Text = "HrAnalytics";
            systempanelcontents.ResumeLayout(false);
            systempanelcontents.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel systempanelcontents;
        private TextBox hranalyticsanalyticstxt;
        private Label label9;
        private Button hranalyticsanalyticsbtn;
        private Button hranalyticsreportbtn;
    }
}