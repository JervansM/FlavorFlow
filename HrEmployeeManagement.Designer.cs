namespace FlavorFlowIT13
{
    partial class HrEmployeeManagement
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
            systempanelcontents = new Panel();
            dataGridViewEmployees = new DataGridView();
            systemsettingsuseraddicon = new PictureBox();
            systemsearchbar = new TextBox();
            hremployeemanagementaddemployeebtn = new Button();
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
            systempanelcontents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmployees).BeginInit();
            ((System.ComponentModel.ISupportInitialize)systemsettingsuseraddicon).BeginInit();
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
            panelContent.BackColor = Color.Silver;
            panelContent.BackgroundImageLayout = ImageLayout.None;
            panelContent.Controls.Add(systempanelcontents);
            panelContent.Controls.Add(systemsettingsuseraddicon);
            panelContent.Controls.Add(systemsearchbar);
            panelContent.Controls.Add(hremployeemanagementaddemployeebtn);
            panelContent.Controls.Add(dashnetprofit);
            panelContent.Controls.Add(dashinventoryusage);
            panelContent.Controls.Add(dashtotalexpense);
            panelContent.Controls.Add(panel4);
            panelContent.Controls.Add(panel5);
            panelContent.Controls.Add(panel6);
            panelContent.Location = new Point(-89, -32);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1560, 852);
            panelContent.TabIndex = 20;
            panelContent.Paint += panelContent_Paint;
            // 
            // systempanelcontents
            // 
            systempanelcontents.BackColor = Color.White;
            systempanelcontents.Controls.Add(dataGridViewEmployees);
            systempanelcontents.Location = new Point(100, 164);
            systempanelcontents.Name = "systempanelcontents";
            systempanelcontents.Size = new Size(1284, 499);
            systempanelcontents.TabIndex = 24;
            systempanelcontents.Paint += systempanelcontents_Paint;
            // 
            // dataGridViewEmployees
            // 
            dataGridViewEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEmployees.Location = new Point(0, -1);
            dataGridViewEmployees.Margin = new Padding(3, 2, 3, 2);
            dataGridViewEmployees.Name = "dataGridViewEmployees";
            dataGridViewEmployees.RowHeadersWidth = 51;
            dataGridViewEmployees.Size = new Size(1284, 500);
            dataGridViewEmployees.TabIndex = 0;
            dataGridViewEmployees.CellContentClick += dataGridViewEmployees_CellContentClick;
            // 
            // systemsettingsuseraddicon
            // 
            systemsettingsuseraddicon.BackColor = Color.Black;
            systemsettingsuseraddicon.Cursor = Cursors.Hand;
            systemsettingsuseraddicon.Image = Properties.Resources.plusicon;
            systemsettingsuseraddicon.Location = new Point(103, 103);
            systemsettingsuseraddicon.Name = "systemsettingsuseraddicon";
            systemsettingsuseraddicon.Size = new Size(57, 50);
            systemsettingsuseraddicon.SizeMode = PictureBoxSizeMode.Zoom;
            systemsettingsuseraddicon.TabIndex = 0;
            systemsettingsuseraddicon.TabStop = false;
            systemsettingsuseraddicon.Click += systemsettingsuseraddicon_Click;
            // 
            // systemsearchbar
            // 
            systemsearchbar.Anchor = AnchorStyles.None;
            systemsearchbar.BorderStyle = BorderStyle.None;
            systemsearchbar.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            systemsearchbar.ForeColor = Color.Black;
            systemsearchbar.Location = new Point(100, 53);
            systemsearchbar.Multiline = true;
            systemsearchbar.Name = "systemsearchbar";
            systemsearchbar.PlaceholderText = "Search";
            systemsearchbar.Size = new Size(1293, 41);
            systemsearchbar.TabIndex = 22;
            systemsearchbar.TextChanged += systemsearchbar_TextChanged;
            // 
            // hremployeemanagementaddemployeebtn
            // 
            hremployeemanagementaddemployeebtn.BackColor = Color.Black;
            hremployeemanagementaddemployeebtn.BackgroundImageLayout = ImageLayout.None;
            hremployeemanagementaddemployeebtn.Cursor = Cursors.Hand;
            hremployeemanagementaddemployeebtn.FlatStyle = FlatStyle.Flat;
            hremployeemanagementaddemployeebtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hremployeemanagementaddemployeebtn.ForeColor = Color.White;
            hremployeemanagementaddemployeebtn.Location = new Point(100, 100);
            hremployeemanagementaddemployeebtn.Name = "hremployeemanagementaddemployeebtn";
            hremployeemanagementaddemployeebtn.Size = new Size(306, 58);
            hremployeemanagementaddemployeebtn.TabIndex = 29;
            hremployeemanagementaddemployeebtn.Text = "Add Employee";
            hremployeemanagementaddemployeebtn.UseVisualStyleBackColor = false;
            hremployeemanagementaddemployeebtn.Click += systemgeneralsettings_Click;
            // 
            // dashnetprofit
            // 
            dashnetprofit.Anchor = AnchorStyles.Bottom;
            dashnetprofit.BackColor = Color.Black;
            dashnetprofit.Controls.Add(dashnetprofittxt);
            dashnetprofit.Location = new Point(4429, 4249);
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
            dashinventoryusage.Location = new Point(4429, 2202);
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
            dashtotalexpense.Location = new Point(4429, 206);
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
            panel4.Location = new Point(5103, 4963);
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
            panel5.Location = new Point(5103, 2559);
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
            panel6.Location = new Point(5103, 206);
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
            // HrEmployeeManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1318, 641);
            Controls.Add(panelContent);
            Name = "HrEmployeeManagement";
            Text = "HrEmployeeManagement";
            Load += HrEmployeeManagement_Load;
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            systempanelcontents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmployees).EndInit();
            ((System.ComponentModel.ISupportInitialize)systemsettingsuseraddicon).EndInit();
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
        private Button systemappconfigure;
        private Button systemusermanagement;
        private Button hremployeemanagementaddemployeebtn;
        private Panel systempanelcontents;
        private PictureBox systemsettingsuseraddicon;
        private TextBox systemsearchbar;
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
        private DataGridView dataGridViewEmployees;
    }
}