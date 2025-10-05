namespace FlavorFlowIT13
{
    partial class AuditsLogsSecurity
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
            panelContent = new Panel();
            securitybtn = new Button();
            systemsearchbarpanel = new Panel();
            systemsearchbaricon = new PictureBox();
            systemsearchbar = new TextBox();
            auditlogspanel = new Panel();
            auditlogsdatagrid = new DataGridView();
            auditlogsbtn = new Button();
            dashnetprofit = new Panel();
            dashnetprofittxt = new Label();
            dashinventoryusage = new Panel();
            label2 = new Label();
            dashtotalexpense = new Panel();
            dashtotalexptxt = new Label();
            panel4 = new Panel();
            label7 = new Label();
            panel5 = new Panel();
            label8 = new Label();
            panel6 = new Panel();
            label9 = new Label();
            panelContent.SuspendLayout();
            systemsearchbarpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)systemsearchbaricon).BeginInit();
            auditlogspanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)auditlogsdatagrid).BeginInit();
            dashnetprofit.SuspendLayout();
            dashinventoryusage.SuspendLayout();
            dashtotalexpense.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.AutoScroll = true;
            panelContent.BackColor = Color.Silver;
            panelContent.BackgroundImageLayout = ImageLayout.None;
            panelContent.Controls.Add(securitybtn);
            panelContent.Controls.Add(systemsearchbarpanel);
            panelContent.Controls.Add(auditlogspanel);
            panelContent.Controls.Add(auditlogsbtn);
            panelContent.Controls.Add(dashnetprofit);
            panelContent.Controls.Add(dashinventoryusage);
            panelContent.Controls.Add(dashtotalexpense);
            panelContent.Controls.Add(panel4);
            panelContent.Controls.Add(panel5);
            panelContent.Controls.Add(panel6);
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1511, 1032);
            panelContent.TabIndex = 18;
            // 
            // securitybtn
            // 
            securitybtn.BackColor = Color.Black;
            securitybtn.Cursor = Cursors.Hand;
            securitybtn.FlatStyle = FlatStyle.Popup;
            securitybtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            securitybtn.ForeColor = Color.Honeydew;
            securitybtn.Location = new Point(325, 101);
            securitybtn.Name = "securitybtn";
            securitybtn.Size = new Size(270, 62);
            securitybtn.TabIndex = 54;
            securitybtn.Text = "Security";
            securitybtn.UseVisualStyleBackColor = false;
            // 
            // systemsearchbarpanel
            // 
            systemsearchbarpanel.BackColor = Color.White;
            systemsearchbarpanel.Controls.Add(systemsearchbaricon);
            systemsearchbarpanel.Controls.Add(systemsearchbar);
            systemsearchbarpanel.Location = new Point(12, 12);
            systemsearchbarpanel.Name = "systemsearchbarpanel";
            systemsearchbarpanel.Size = new Size(1487, 59);
            systemsearchbarpanel.TabIndex = 25;
            // 
            // systemsearchbaricon
            // 
            systemsearchbaricon.BackColor = Color.Transparent;
            systemsearchbaricon.BackgroundImageLayout = ImageLayout.None;
            systemsearchbaricon.Image = Properties.Resources.searchbar_removebg_preview;
            systemsearchbaricon.Location = new Point(1392, 6);
            systemsearchbaricon.Name = "systemsearchbaricon";
            systemsearchbaricon.Size = new Size(81, 46);
            systemsearchbaricon.SizeMode = PictureBoxSizeMode.Zoom;
            systemsearchbaricon.TabIndex = 23;
            systemsearchbaricon.TabStop = false;
            // 
            // systemsearchbar
            // 
            systemsearchbar.Anchor = AnchorStyles.None;
            systemsearchbar.BorderStyle = BorderStyle.None;
            systemsearchbar.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            systemsearchbar.ForeColor = Color.Black;
            systemsearchbar.Location = new Point(8, 6);
            systemsearchbar.Multiline = true;
            systemsearchbar.Name = "systemsearchbar";
            systemsearchbar.PlaceholderText = "Search";
            systemsearchbar.Size = new Size(1431, 47);
            systemsearchbar.TabIndex = 22;
            systemsearchbar.TextChanged += systemsearchbar_TextChanged;
            // 
            // auditlogspanel
            // 
            auditlogspanel.BackColor = Color.White;
            auditlogspanel.Controls.Add(auditlogsdatagrid);
            auditlogspanel.Location = new Point(12, 187);
            auditlogspanel.Name = "auditlogspanel";
            auditlogspanel.Size = new Size(1487, 3000);
            auditlogspanel.TabIndex = 53;
            auditlogspanel.Paint += auditlogspanel_Paint;
            // 
            // auditlogsdatagrid
            // 
            auditlogsdatagrid.BackgroundColor = Color.White;
            auditlogsdatagrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            auditlogsdatagrid.Dock = DockStyle.Fill;
            auditlogsdatagrid.Location = new Point(0, 0);
            auditlogsdatagrid.Name = "auditlogsdatagrid";
            auditlogsdatagrid.ReadOnly = true;
            auditlogsdatagrid.Size = new Size(1487, 3000);
            auditlogsdatagrid.TabIndex = 0;
            auditlogsdatagrid.CellContentClick += auditlogsdatagrid_CellContentClick;
            // 
            // auditlogsbtn
            // 
            auditlogsbtn.BackColor = Color.Black;
            auditlogsbtn.Cursor = Cursors.Hand;
            auditlogsbtn.FlatStyle = FlatStyle.Popup;
            auditlogsbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            auditlogsbtn.ForeColor = Color.Honeydew;
            auditlogsbtn.Location = new Point(12, 101);
            auditlogsbtn.Name = "auditlogsbtn";
            auditlogsbtn.Size = new Size(270, 62);
            auditlogsbtn.TabIndex = 51;
            auditlogsbtn.Text = "Audit Logs";
            auditlogsbtn.UseVisualStyleBackColor = false;
            // 
            // dashnetprofit
            // 
            dashnetprofit.Anchor = AnchorStyles.Bottom;
            dashnetprofit.BackColor = Color.Black;
            dashnetprofit.Controls.Add(dashnetprofittxt);
            dashnetprofit.Location = new Point(2417, 4460);
            dashnetprofit.Name = "dashnetprofit";
            dashnetprofit.Size = new Size(468, 169);
            dashnetprofit.TabIndex = 20;
            // 
            // dashnetprofittxt
            // 
            dashnetprofittxt.AutoSize = true;
            dashnetprofittxt.BackColor = Color.Transparent;
            dashnetprofittxt.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dashnetprofittxt.ForeColor = Color.White;
            dashnetprofittxt.Location = new Point(28, 0);
            dashnetprofittxt.Name = "dashnetprofittxt";
            dashnetprofittxt.Size = new Size(321, 45);
            dashnetprofittxt.TabIndex = 5;
            dashnetprofittxt.Text = "Net Profit Summary";
            // 
            // dashinventoryusage
            // 
            dashinventoryusage.Anchor = AnchorStyles.None;
            dashinventoryusage.BackColor = Color.Black;
            dashinventoryusage.Controls.Add(label2);
            dashinventoryusage.Location = new Point(2417, 2306);
            dashinventoryusage.Name = "dashinventoryusage";
            dashinventoryusage.Size = new Size(468, 226);
            dashinventoryusage.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(28, 0);
            label2.Name = "label2";
            label2.Size = new Size(265, 45);
            label2.TabIndex = 4;
            label2.Text = "Inventory Usage";
            // 
            // dashtotalexpense
            // 
            dashtotalexpense.Anchor = AnchorStyles.Top;
            dashtotalexpense.BackColor = Color.Black;
            dashtotalexpense.Controls.Add(dashtotalexptxt);
            dashtotalexpense.Location = new Point(2417, 206);
            dashtotalexpense.Name = "dashtotalexpense";
            dashtotalexpense.Size = new Size(468, 170);
            dashtotalexpense.TabIndex = 19;
            // 
            // dashtotalexptxt
            // 
            dashtotalexptxt.AutoSize = true;
            dashtotalexptxt.BackColor = Color.Transparent;
            dashtotalexptxt.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            dashtotalexptxt.ForeColor = Color.White;
            dashtotalexptxt.Location = new Point(28, 0);
            dashtotalexptxt.Name = "dashtotalexptxt";
            dashtotalexptxt.Size = new Size(225, 45);
            dashtotalexptxt.TabIndex = 3;
            dashtotalexptxt.Text = "Total Expense";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Bottom;
            panel4.BackColor = Color.Black;
            panel4.Controls.Add(label7);
            panel4.Location = new Point(3091, 5174);
            panel4.Name = "panel4";
            panel4.Size = new Size(468, 169);
            panel4.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(28, 0);
            label7.Name = "label7";
            label7.Size = new Size(321, 45);
            label7.TabIndex = 5;
            label7.Text = "Net Profit Summary";
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.None;
            panel5.BackColor = Color.Black;
            panel5.Controls.Add(label8);
            panel5.Location = new Point(3091, 2663);
            panel5.Name = "panel5";
            panel5.Size = new Size(468, 226);
            panel5.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(28, 0);
            label8.Name = "label8";
            label8.Size = new Size(265, 45);
            label8.TabIndex = 4;
            label8.Text = "Inventory Usage";
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top;
            panel6.BackColor = Color.Black;
            panel6.Controls.Add(label9);
            panel6.Location = new Point(3091, 206);
            panel6.Name = "panel6";
            panel6.Size = new Size(468, 170);
            panel6.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(28, 0);
            label9.Name = "label9";
            label9.Size = new Size(225, 45);
            label9.TabIndex = 3;
            label9.Text = "Total Expense";
            // 
            // AuditsLogsSecurity
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1526, 1056);
            Controls.Add(panelContent);
            Name = "AuditsLogsSecurity";
            Text = "AuditsLogsSecurity";
            Load += AuditsLogsSecurity_Load;
            panelContent.ResumeLayout(false);
            systemsearchbarpanel.ResumeLayout(false);
            systemsearchbarpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)systemsearchbaricon).EndInit();
            auditlogspanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)auditlogsdatagrid).EndInit();
            dashnetprofit.ResumeLayout(false);
            dashnetprofit.PerformLayout();
            dashinventoryusage.ResumeLayout(false);
            dashinventoryusage.PerformLayout();
            dashtotalexpense.ResumeLayout(false);
            dashtotalexpense.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContent;
        private Button securitybtn;
        private Panel systemsearchbarpanel;
        private PictureBox systemsearchbaricon;
        private TextBox systemsearchbar;
        private Panel auditlogspanel;
        private Button auditlogsbtn;
        private Panel dashnetprofit;
        private Label dashnetprofittxt;
        private Panel dashinventoryusage;
        private Label label2;
        private Panel dashtotalexpense;
        private Label dashtotalexptxt;
        private Panel panel4;
        private Label label7;
        private Panel panel5;
        private Label label8;
        private Panel panel6;
        private Label label9;
        private DataGridView auditlogsdatagrid;
    }
}