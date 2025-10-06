namespace FlavorFlowIT13
{
    partial class DashboardControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelContent = new Panel();
            label5 = new Label();
            dashnotif = new Panel();
            hrdashboardexpiriestxt = new TextBox();
            hrdashboardbirthdaystxt = new TextBox();
            dashlowstackalerts = new Label();
            dashrecenttransactions = new Label();
            dashattendancetodaypanel = new Panel();
            hrdashboardattendancetodaytxt = new TextBox();
            dashinventorytxt = new Label();
            hrdashboardleaverequestspanel = new Panel();
            hrdashboardleaverequeststxt = new TextBox();
            label3 = new Label();
            dashvisualtxtsales = new Label();
            dashnetprofit = new Panel();
            dashnetprofittxt = new Label();
            dashinventoryusage = new Panel();
            label2 = new Label();
            dashtotalexpense = new Panel();
            dashtotalexptxt = new Label();
            dashactive = new Panel();
            label4 = new Label();
            hrdashboardleavecontractstxt = new TextBox();
            dashactiveon = new PictureBox();
            label1 = new Label();
            dashvisuals = new Panel();
            dashvisualtoptxt = new Label();
            dashtotalsales = new Panel();
            hrdashboardemployeeheadcounttxt = new TextBox();
            dashsalestxt = new Label();
            panelContent.SuspendLayout();
            dashnotif.SuspendLayout();
            dashattendancetodaypanel.SuspendLayout();
            hrdashboardleaverequestspanel.SuspendLayout();
            dashnetprofit.SuspendLayout();
            dashinventoryusage.SuspendLayout();
            dashtotalexpense.SuspendLayout();
            dashactive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dashactiveon).BeginInit();
            dashvisuals.SuspendLayout();
            dashtotalsales.SuspendLayout();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.Silver;
            panelContent.BackgroundImageLayout = ImageLayout.None;
            panelContent.Controls.Add(label5);
            panelContent.Controls.Add(dashnotif);
            panelContent.Controls.Add(dashattendancetodaypanel);
            panelContent.Controls.Add(hrdashboardleaverequestspanel);
            panelContent.Controls.Add(dashvisualtxtsales);
            panelContent.Controls.Add(dashnetprofit);
            panelContent.Controls.Add(dashinventoryusage);
            panelContent.Controls.Add(dashtotalexpense);
            panelContent.Controls.Add(dashactive);
            panelContent.Controls.Add(dashvisuals);
            panelContent.Controls.Add(dashtotalsales);
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1560, 852);
            panelContent.TabIndex = 15;
            panelContent.Paint += panelContent_Paint_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(16, 574);
            label5.Name = "label5";
            label5.Size = new Size(153, 30);
            label5.TabIndex = 5;
            label5.Text = "Notifications: ";
            // 
            // dashnotif
            // 
            dashnotif.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dashnotif.BackColor = Color.Black;
            dashnotif.Controls.Add(hrdashboardexpiriestxt);
            dashnotif.Controls.Add(hrdashboardbirthdaystxt);
            dashnotif.Controls.Add(dashlowstackalerts);
            dashnotif.Controls.Add(dashrecenttransactions);
            dashnotif.Location = new Point(16, 615);
            dashnotif.Name = "dashnotif";
            dashnotif.Size = new Size(1500, 218);
            dashnotif.TabIndex = 2;
            // 
            // hrdashboardexpiriestxt
            // 
            hrdashboardexpiriestxt.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            hrdashboardexpiriestxt.ForeColor = Color.Black;
            hrdashboardexpiriestxt.Location = new Point(252, 85);
            hrdashboardexpiriestxt.Multiline = true;
            hrdashboardexpiriestxt.Name = "hrdashboardexpiriestxt";
            hrdashboardexpiriestxt.ReadOnly = true;
            hrdashboardexpiriestxt.Size = new Size(171, 44);
            hrdashboardexpiriestxt.TabIndex = 6;
            // 
            // hrdashboardbirthdaystxt
            // 
            hrdashboardbirthdaystxt.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            hrdashboardbirthdaystxt.ForeColor = Color.Black;
            hrdashboardbirthdaystxt.Location = new Point(252, 15);
            hrdashboardbirthdaystxt.Multiline = true;
            hrdashboardbirthdaystxt.Name = "hrdashboardbirthdaystxt";
            hrdashboardbirthdaystxt.ReadOnly = true;
            hrdashboardbirthdaystxt.Size = new Size(171, 44);
            hrdashboardbirthdaystxt.TabIndex = 5;
            // 
            // dashlowstackalerts
            // 
            dashlowstackalerts.AutoSize = true;
            dashlowstackalerts.BackColor = Color.Transparent;
            dashlowstackalerts.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            dashlowstackalerts.ForeColor = Color.White;
            dashlowstackalerts.Location = new Point(39, 97);
            dashlowstackalerts.Name = "dashlowstackalerts";
            dashlowstackalerts.Size = new Size(110, 32);
            dashlowstackalerts.TabIndex = 4;
            dashlowstackalerts.Text = "Expiries:";
            // 
            // dashrecenttransactions
            // 
            dashrecenttransactions.AutoSize = true;
            dashrecenttransactions.BackColor = Color.Transparent;
            dashrecenttransactions.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            dashrecenttransactions.ForeColor = Color.White;
            dashrecenttransactions.Location = new Point(39, 32);
            dashrecenttransactions.Name = "dashrecenttransactions";
            dashrecenttransactions.Size = new Size(129, 32);
            dashrecenttransactions.TabIndex = 3;
            dashrecenttransactions.Text = "Birthdays:";
            // 
            // dashattendancetodaypanel
            // 
            dashattendancetodaypanel.BackColor = Color.Black;
            dashattendancetodaypanel.Controls.Add(hrdashboardattendancetodaytxt);
            dashattendancetodaypanel.Controls.Add(dashinventorytxt);
            dashattendancetodaypanel.Location = new Point(1001, 16);
            dashattendancetodaypanel.Name = "dashattendancetodaypanel";
            dashattendancetodaypanel.Size = new Size(515, 127);
            dashattendancetodaypanel.TabIndex = 2;
            // 
            // hrdashboardattendancetodaytxt
            // 
            hrdashboardattendancetodaytxt.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            hrdashboardattendancetodaytxt.ForeColor = Color.Black;
            hrdashboardattendancetodaytxt.Location = new Point(54, 48);
            hrdashboardattendancetodaytxt.Multiline = true;
            hrdashboardattendancetodaytxt.Name = "hrdashboardattendancetodaytxt";
            hrdashboardattendancetodaytxt.ReadOnly = true;
            hrdashboardattendancetodaytxt.Size = new Size(174, 52);
            hrdashboardattendancetodaytxt.TabIndex = 4;
            // 
            // dashinventorytxt
            // 
            dashinventorytxt.AutoSize = true;
            dashinventorytxt.BackColor = Color.Transparent;
            dashinventorytxt.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            dashinventorytxt.ForeColor = Color.White;
            dashinventorytxt.Location = new Point(26, 6);
            dashinventorytxt.Name = "dashinventorytxt";
            dashinventorytxt.Size = new Size(172, 25);
            dashinventorytxt.TabIndex = 2;
            dashinventorytxt.Text = "Attendance Today";
            // 
            // hrdashboardleaverequestspanel
            // 
            hrdashboardleaverequestspanel.BackColor = Color.Black;
            hrdashboardleaverequestspanel.Controls.Add(hrdashboardleaverequeststxt);
            hrdashboardleaverequestspanel.Controls.Add(label3);
            hrdashboardleaverequestspanel.Location = new Point(1001, 160);
            hrdashboardleaverequestspanel.Name = "hrdashboardleaverequestspanel";
            hrdashboardleaverequestspanel.Size = new Size(515, 127);
            hrdashboardleaverequestspanel.TabIndex = 3;
            // 
            // hrdashboardleaverequeststxt
            // 
            hrdashboardleaverequeststxt.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            hrdashboardleaverequeststxt.ForeColor = Color.Black;
            hrdashboardleaverequeststxt.Location = new Point(54, 60);
            hrdashboardleaverequeststxt.Multiline = true;
            hrdashboardleaverequeststxt.Name = "hrdashboardleaverequeststxt";
            hrdashboardleaverequeststxt.ReadOnly = true;
            hrdashboardleaverequeststxt.Size = new Size(174, 52);
            hrdashboardleaverequeststxt.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(26, 6);
            label3.Name = "label3";
            label3.Size = new Size(146, 25);
            label3.TabIndex = 2;
            label3.Text = "Leave Requests";
            // 
            // dashvisualtxtsales
            // 
            dashvisualtxtsales.AutoSize = true;
            dashvisualtxtsales.BackColor = Color.Transparent;
            dashvisualtxtsales.Font = new Font("Segoe UI", 30.75F, FontStyle.Bold);
            dashvisualtxtsales.ForeColor = Color.Black;
            dashvisualtxtsales.Location = new Point(16, 246);
            dashvisualtxtsales.Name = "dashvisualtxtsales";
            dashvisualtxtsales.Size = new Size(303, 55);
            dashvisualtxtsales.TabIndex = 1;
            dashvisualtxtsales.Text = "Visual Insights";
            // 
            // dashnetprofit
            // 
            dashnetprofit.Anchor = AnchorStyles.Bottom;
            dashnetprofit.BackColor = Color.Black;
            dashnetprofit.Controls.Add(dashnetprofittxt);
            dashnetprofit.Location = new Point(2414, 2126);
            dashnetprofit.Name = "dashnetprofit";
            dashnetprofit.Size = new Size(468, 174);
            dashnetprofit.TabIndex = 4;
            // 
            // dashnetprofittxt
            // 
            dashnetprofittxt.AutoSize = true;
            dashnetprofittxt.BackColor = Color.Transparent;
            dashnetprofittxt.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
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
            dashinventoryusage.Location = new Point(2414, 1134);
            dashinventoryusage.Name = "dashinventoryusage";
            dashinventoryusage.Size = new Size(468, 233);
            dashinventoryusage.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
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
            dashtotalexpense.Location = new Point(2414, 206);
            dashtotalexpense.Name = "dashtotalexpense";
            dashtotalexpense.Size = new Size(468, 170);
            dashtotalexpense.TabIndex = 3;
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
            // dashactive
            // 
            dashactive.BackColor = Color.Black;
            dashactive.Controls.Add(label4);
            dashactive.Controls.Add(hrdashboardleavecontractstxt);
            dashactive.Controls.Add(dashactiveon);
            dashactive.Controls.Add(label1);
            dashactive.Location = new Point(413, 16);
            dashactive.Name = "dashactive";
            dashactive.Size = new Size(540, 176);
            dashactive.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(35, 94);
            label4.Name = "label4";
            label4.Size = new Size(152, 25);
            label4.TabIndex = 5;
            label4.Text = "Leave Contracts";
            // 
            // hrdashboardleavecontractstxt
            // 
            hrdashboardleavecontractstxt.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            hrdashboardleavecontractstxt.ForeColor = Color.Black;
            hrdashboardleavecontractstxt.Location = new Point(213, 83);
            hrdashboardleavecontractstxt.Multiline = true;
            hrdashboardleavecontractstxt.Name = "hrdashboardleavecontractstxt";
            hrdashboardleavecontractstxt.ReadOnly = true;
            hrdashboardleavecontractstxt.Size = new Size(192, 48);
            hrdashboardleavecontractstxt.TabIndex = 4;
            // 
            // dashactiveon
            // 
            dashactiveon.BackColor = Color.Transparent;
            dashactiveon.BackgroundImageLayout = ImageLayout.None;
            dashactiveon.Cursor = Cursors.Hand;
            dashactiveon.Image = Properties.Resources.toggleon_removebg_preview;
            dashactiveon.Location = new Point(286, 0);
            dashactiveon.Name = "dashactiveon";
            dashactiveon.Size = new Size(118, 62);
            dashactiveon.SizeMode = PictureBoxSizeMode.Zoom;
            dashactiveon.TabIndex = 3;
            dashactiveon.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(24, 17);
            label1.Name = "label1";
            label1.Size = new Size(186, 25);
            label1.TabIndex = 1;
            label1.Text = " Pending Approvals";
            // 
            // dashvisuals
            // 
            dashvisuals.BackColor = Color.Black;
            dashvisuals.Controls.Add(dashvisualtoptxt);
            dashvisuals.Location = new Point(13, 327);
            dashvisuals.Name = "dashvisuals";
            dashvisuals.Size = new Size(1503, 162);
            dashvisuals.TabIndex = 1;
            // 
            // dashvisualtoptxt
            // 
            dashvisualtoptxt.AutoSize = true;
            dashvisualtoptxt.BackColor = Color.Transparent;
            dashvisualtoptxt.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            dashvisualtoptxt.ForeColor = Color.White;
            dashvisualtoptxt.Location = new Point(3, 4);
            dashvisualtoptxt.Name = "dashvisualtoptxt";
            dashvisualtoptxt.Size = new Size(311, 30);
            dashvisualtoptxt.TabIndex = 2;
            dashvisualtoptxt.Text = "Upcoming Contracts Renewals";
            // 
            // dashtotalsales
            // 
            dashtotalsales.BackColor = Color.Black;
            dashtotalsales.Controls.Add(hrdashboardemployeeheadcounttxt);
            dashtotalsales.Controls.Add(dashsalestxt);
            dashtotalsales.Location = new Point(21, 16);
            dashtotalsales.Name = "dashtotalsales";
            dashtotalsales.Size = new Size(360, 176);
            dashtotalsales.TabIndex = 0;
            // 
            // hrdashboardemployeeheadcounttxt
            // 
            hrdashboardemployeeheadcounttxt.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            hrdashboardemployeeheadcounttxt.ForeColor = Color.Black;
            hrdashboardemployeeheadcounttxt.Location = new Point(34, 89);
            hrdashboardemployeeheadcounttxt.Multiline = true;
            hrdashboardemployeeheadcounttxt.Name = "hrdashboardemployeeheadcounttxt";
            hrdashboardemployeeheadcounttxt.ReadOnly = true;
            hrdashboardemployeeheadcounttxt.Size = new Size(192, 48);
            hrdashboardemployeeheadcounttxt.TabIndex = 1;
            // 
            // dashsalestxt
            // 
            dashsalestxt.AutoSize = true;
            dashsalestxt.BackColor = Color.Transparent;
            dashsalestxt.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dashsalestxt.ForeColor = Color.White;
            dashsalestxt.Location = new Point(26, 26);
            dashsalestxt.Name = "dashsalestxt";
            dashsalestxt.Size = new Size(210, 25);
            dashsalestxt.TabIndex = 0;
            dashsalestxt.Text = "Employee Head Count";
            // 
            // DashboardControl
            // 
            Controls.Add(panelContent);
            Name = "DashboardControl";
            Size = new Size(1510, 1335);
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            dashnotif.ResumeLayout(false);
            dashnotif.PerformLayout();
            dashattendancetodaypanel.ResumeLayout(false);
            dashattendancetodaypanel.PerformLayout();
            hrdashboardleaverequestspanel.ResumeLayout(false);
            hrdashboardleaverequestspanel.PerformLayout();
            dashnetprofit.ResumeLayout(false);
            dashnetprofit.PerformLayout();
            dashinventoryusage.ResumeLayout(false);
            dashinventoryusage.PerformLayout();
            dashtotalexpense.ResumeLayout(false);
            dashtotalexpense.PerformLayout();
            dashactive.ResumeLayout(false);
            dashactive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dashactiveon).EndInit();
            dashvisuals.ResumeLayout(false);
            dashvisuals.PerformLayout();
            dashtotalsales.ResumeLayout(false);
            dashtotalsales.PerformLayout();
            ResumeLayout(false);
        }
        private Panel panelContent;
        private Label label5;
        private Panel dashnotif;
        private TextBox hrdashboardexpiriestxt;
        private TextBox hrdashboardbirthdaystxt;
        private Label dashlowstackalerts;
        private Label dashrecenttransactions;
        private Panel dashattendancetodaypanel;
        private TextBox hrdashboardattendancetodaytxt;
        private Label dashinventorytxt;
        private Panel hrdashboardleaverequestspanel;
        private TextBox hrdashboardleaverequeststxt;
        private Label label3;
        private Label dashvisualtxtsales;
        private Panel dashnetprofit;
        private Label dashnetprofittxt;
        private Panel dashinventoryusage;
        private Label label2;
        private Panel dashtotalexpense;
        private Label dashtotalexptxt;
        private Panel dashactive;
        private Label label4;
        private TextBox hrdashboardleavecontractstxt;
        private PictureBox dashactiveon;
        private Label label1;
        private Panel dashvisuals;
        private Label dashvisualtoptxt;
        private Panel dashtotalsales;
        private TextBox hrdashboardemployeeheadcounttxt;
        private Label dashsalestxt;
    }
}
