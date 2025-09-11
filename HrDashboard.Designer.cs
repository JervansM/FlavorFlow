namespace FlavorFlowIT13
{
    partial class HrDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HrDashboard));
            panelTop = new Panel();
            dashadrefreshicon = new PictureBox();
            dashadtime = new Label();
            dashaddate = new Label();
            panelContent = new Panel();
            dashnetprofit = new Panel();
            dashnetprofittxt = new Label();
            dashinventoryusage = new Panel();
            label2 = new Label();
            dashtotalexpense = new Panel();
            dashtotalexptxt = new Label();
            dashattendancetodaypanel = new Panel();
            dashinventorytxt = new Label();
            dashactive = new Panel();
            dashactiveon = new PictureBox();
            label1 = new Label();
            dashnotif = new Panel();
            dashlowstackalerts = new Label();
            dashrecenttransactions = new Label();
            dashvisuals = new Panel();
            dashvisualtoptxt = new Label();
            dashvisualtxtsales = new Label();
            dashtotalsales = new Panel();
            dashsalestxt = new Label();
            panelNav = new Panel();
            admenubtn = new Button();
            adlogoutbtn = new Button();
            adlogsbtn = new Button();
            adsystembtn = new Button();
            adsupplybtn = new ComboBox();
            adfinancebtn = new Button();
            adstaffbtn = new Button();
            adinventorybtn = new Button();
            adsalesbtn = new Button();
            dashbtn = new Button();
            adminicon = new PictureBox();
            userwelcome = new Label();
            fficonadmin = new PictureBox();
            hrdashboardleaverequestspanel = new Panel();
            label3 = new Label();
            hrdashboardleaverequeststxt = new TextBox();
            hrdashboardattendancetodaytxt = new TextBox();
            hrdashboardleavecontractstxt = new TextBox();
            label4 = new Label();
            hrdashboardemployeeheadcounttxt = new TextBox();
            label5 = new Label();
            hrdashboardbirthdaystxt = new TextBox();
            hrdashboardexpiriestxt = new TextBox();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dashadrefreshicon).BeginInit();
            panelContent.SuspendLayout();
            dashnetprofit.SuspendLayout();
            dashinventoryusage.SuspendLayout();
            dashtotalexpense.SuspendLayout();
            dashattendancetodaypanel.SuspendLayout();
            dashactive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dashactiveon).BeginInit();
            dashnotif.SuspendLayout();
            dashvisuals.SuspendLayout();
            dashtotalsales.SuspendLayout();
            panelNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)adminicon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fficonadmin).BeginInit();
            hrdashboardleaverequestspanel.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.AutoScroll = true;
            panelTop.BackColor = Color.WhiteSmoke;
            panelTop.BackgroundImageLayout = ImageLayout.None;
            panelTop.Controls.Add(dashadrefreshicon);
            panelTop.Controls.Add(dashadtime);
            panelTop.Controls.Add(dashaddate);
            panelTop.Controls.Add(panelContent);
            panelTop.Controls.Add(panelNav);
            panelTop.Controls.Add(adminicon);
            panelTop.Controls.Add(userwelcome);
            panelTop.Controls.Add(fficonadmin);
            panelTop.Location = new Point(-251, -112);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1872, 972);
            panelTop.TabIndex = 1;
            // 
            // dashadrefreshicon
            // 
            dashadrefreshicon.BackColor = Color.Transparent;
            dashadrefreshicon.BackgroundImageLayout = ImageLayout.None;
            dashadrefreshicon.Cursor = Cursors.Hand;
            dashadrefreshicon.Image = (Image)resources.GetObject("dashadrefreshicon.Image");
            dashadrefreshicon.Location = new Point(1697, 57);
            dashadrefreshicon.Name = "dashadrefreshicon";
            dashadrefreshicon.Size = new Size(118, 48);
            dashadrefreshicon.SizeMode = PictureBoxSizeMode.Zoom;
            dashadrefreshicon.TabIndex = 3;
            dashadrefreshicon.TabStop = false;
            // 
            // dashadtime
            // 
            dashadtime.AutoSize = true;
            dashadtime.BackColor = Color.Transparent;
            dashadtime.FlatStyle = FlatStyle.Flat;
            dashadtime.Font = new Font("Segoe UI", 38.25F, FontStyle.Bold);
            dashadtime.ForeColor = Color.Coral;
            dashadtime.Location = new Point(1414, 38);
            dashadtime.Name = "dashadtime";
            dashadtime.Size = new Size(148, 68);
            dashadtime.TabIndex = 16;
            dashadtime.Text = "Time";
            // 
            // dashaddate
            // 
            dashaddate.AutoSize = true;
            dashaddate.BackColor = Color.Transparent;
            dashaddate.FlatStyle = FlatStyle.Flat;
            dashaddate.Font = new Font("Segoe UI", 38.25F, FontStyle.Bold);
            dashaddate.ForeColor = Color.Coral;
            dashaddate.Location = new Point(982, 38);
            dashaddate.Name = "dashaddate";
            dashaddate.Size = new Size(142, 68);
            dashaddate.TabIndex = 15;
            dashaddate.Text = "Date";
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.Silver;
            panelContent.BackgroundImageLayout = ImageLayout.None;
            panelContent.Controls.Add(label5);
            panelContent.Controls.Add(dashnotif);
            panelContent.Controls.Add(hrdashboardleaverequestspanel);
            panelContent.Controls.Add(dashvisualtxtsales);
            panelContent.Controls.Add(dashnetprofit);
            panelContent.Controls.Add(dashinventoryusage);
            panelContent.Controls.Add(dashtotalexpense);
            panelContent.Controls.Add(dashattendancetodaypanel);
            panelContent.Controls.Add(dashactive);
            panelContent.Controls.Add(dashvisuals);
            panelContent.Controls.Add(dashtotalsales);
            panelContent.Location = new Point(303, 125);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1545, 814);
            panelContent.TabIndex = 14;
            // 
            // dashnetprofit
            // 
            dashnetprofit.Anchor = AnchorStyles.Bottom;
            dashnetprofit.BackColor = Color.Black;
            dashnetprofit.Controls.Add(dashnetprofittxt);
            dashnetprofit.Location = new Point(1726, 1335);
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
            dashinventoryusage.Location = new Point(1726, 739);
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
            dashtotalexpense.Location = new Point(1726, 206);
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
            // dashattendancetodaypanel
            // 
            dashattendancetodaypanel.BackColor = Color.Black;
            dashattendancetodaypanel.Controls.Add(hrdashboardattendancetodaytxt);
            dashattendancetodaypanel.Controls.Add(dashinventorytxt);
            dashattendancetodaypanel.Location = new Point(919, 20);
            dashattendancetodaypanel.Name = "dashattendancetodaypanel";
            dashattendancetodaypanel.Size = new Size(603, 126);
            dashattendancetodaypanel.TabIndex = 2;
            // 
            // dashinventorytxt
            // 
            dashinventorytxt.AutoSize = true;
            dashinventorytxt.BackColor = Color.Transparent;
            dashinventorytxt.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            dashinventorytxt.ForeColor = Color.White;
            dashinventorytxt.Location = new Point(26, 6);
            dashinventorytxt.Name = "dashinventorytxt";
            dashinventorytxt.Size = new Size(289, 45);
            dashinventorytxt.TabIndex = 2;
            dashinventorytxt.Text = "Attendance Today";
            // 
            // dashactive
            // 
            dashactive.BackColor = Color.Black;
            dashactive.Controls.Add(label4);
            dashactive.Controls.Add(hrdashboardleavecontractstxt);
            dashactive.Controls.Add(dashactiveon);
            dashactive.Controls.Add(label1);
            dashactive.Location = new Point(456, 20);
            dashactive.Name = "dashactive";
            dashactive.Size = new Size(457, 241);
            dashactive.TabIndex = 1;
            // 
            // dashactiveon
            // 
            dashactiveon.BackColor = Color.Transparent;
            dashactiveon.BackgroundImageLayout = ImageLayout.None;
            dashactiveon.Cursor = Cursors.Hand;
            dashactiveon.Image = Properties.Resources.toggleon_removebg_preview;
            dashactiveon.Location = new Point(259, 0);
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
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(30, 6);
            label1.Name = "label1";
            label1.Size = new Size(173, 90);
            label1.TabIndex = 1;
            label1.Text = " Pending \nApprovals";
            label1.Click += label1_Click;
            // 
            // dashnotif
            // 
            dashnotif.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dashnotif.BackColor = Color.Black;
            dashnotif.Controls.Add(hrdashboardexpiriestxt);
            dashnotif.Controls.Add(hrdashboardbirthdaystxt);
            dashnotif.Controls.Add(dashlowstackalerts);
            dashnotif.Controls.Add(dashrecenttransactions);
            dashnotif.Location = new Point(27, 570);
            dashnotif.Name = "dashnotif";
            dashnotif.Size = new Size(1021, 939);
            dashnotif.TabIndex = 2;
            // 
            // dashlowstackalerts
            // 
            dashlowstackalerts.AutoSize = true;
            dashlowstackalerts.BackColor = Color.Transparent;
            dashlowstackalerts.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            dashlowstackalerts.ForeColor = Color.White;
            dashlowstackalerts.Location = new Point(19, 90);
            dashlowstackalerts.Name = "dashlowstackalerts";
            dashlowstackalerts.Size = new Size(110, 32);
            dashlowstackalerts.TabIndex = 4;
            dashlowstackalerts.Text = "Expiries:";
            dashlowstackalerts.Click += dashlowstackalerts_Click;
            // 
            // dashrecenttransactions
            // 
            dashrecenttransactions.AutoSize = true;
            dashrecenttransactions.BackColor = Color.Transparent;
            dashrecenttransactions.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            dashrecenttransactions.ForeColor = Color.White;
            dashrecenttransactions.Location = new Point(19, 27);
            dashrecenttransactions.Name = "dashrecenttransactions";
            dashrecenttransactions.Size = new Size(129, 32);
            dashrecenttransactions.TabIndex = 3;
            dashrecenttransactions.Text = "Birthdays:";
            // 
            // dashvisuals
            // 
            dashvisuals.BackColor = Color.Black;
            dashvisuals.Controls.Add(dashvisualtoptxt);
            dashvisuals.Location = new Point(27, 338);
            dashvisuals.Name = "dashvisuals";
            dashvisuals.Size = new Size(1021, 172);
            dashvisuals.TabIndex = 1;
            // 
            // dashvisualtoptxt
            // 
            dashvisualtoptxt.AutoSize = true;
            dashvisualtoptxt.BackColor = Color.Transparent;
            dashvisualtoptxt.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            dashvisualtoptxt.ForeColor = Color.White;
            dashvisualtoptxt.Location = new Point(3, 4);
            dashvisualtoptxt.Name = "dashvisualtoptxt";
            dashvisualtoptxt.Size = new Size(474, 45);
            dashvisualtoptxt.TabIndex = 2;
            dashvisualtoptxt.Text = "Upcoming Contracts Renewals";
            // 
            // dashvisualtxtsales
            // 
            dashvisualtxtsales.AutoSize = true;
            dashvisualtxtsales.BackColor = Color.Transparent;
            dashvisualtxtsales.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            dashvisualtxtsales.ForeColor = Color.White;
            dashvisualtxtsales.Location = new Point(27, 290);
            dashvisualtxtsales.Name = "dashvisualtxtsales";
            dashvisualtxtsales.Size = new Size(235, 45);
            dashvisualtxtsales.TabIndex = 1;
            dashvisualtxtsales.Text = "Visual Insights";
            // 
            // dashtotalsales
            // 
            dashtotalsales.BackColor = Color.Black;
            dashtotalsales.Controls.Add(hrdashboardemployeeheadcounttxt);
            dashtotalsales.Controls.Add(dashsalestxt);
            dashtotalsales.Location = new Point(27, 20);
            dashtotalsales.Name = "dashtotalsales";
            dashtotalsales.Size = new Size(423, 241);
            dashtotalsales.TabIndex = 0;
            // 
            // dashsalestxt
            // 
            dashsalestxt.AutoSize = true;
            dashsalestxt.BackColor = Color.Transparent;
            dashsalestxt.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            dashsalestxt.ForeColor = Color.White;
            dashsalestxt.Location = new Point(18, 8);
            dashsalestxt.Name = "dashsalestxt";
            dashsalestxt.Size = new Size(263, 90);
            dashsalestxt.TabIndex = 0;
            dashsalestxt.Text = "Employee Head \ncount";
            // 
            // panelNav
            // 
            panelNav.BackColor = Color.Silver;
            panelNav.Controls.Add(admenubtn);
            panelNav.Controls.Add(adlogoutbtn);
            panelNav.Controls.Add(adlogsbtn);
            panelNav.Controls.Add(adsystembtn);
            panelNav.Controls.Add(adsupplybtn);
            panelNav.Controls.Add(adfinancebtn);
            panelNav.Controls.Add(adstaffbtn);
            panelNav.Controls.Add(adinventorybtn);
            panelNav.Controls.Add(adsalesbtn);
            panelNav.Controls.Add(dashbtn);
            panelNav.Location = new Point(25, 125);
            panelNav.Name = "panelNav";
            panelNav.Size = new Size(272, 814);
            panelNav.TabIndex = 3;
            // 
            // admenubtn
            // 
            admenubtn.BackColor = Color.Black;
            admenubtn.Cursor = Cursors.Hand;
            admenubtn.FlatStyle = FlatStyle.Popup;
            admenubtn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            admenubtn.ForeColor = Color.Honeydew;
            admenubtn.Location = new Point(12, 260);
            admenubtn.Name = "admenubtn";
            admenubtn.Size = new Size(243, 62);
            admenubtn.TabIndex = 13;
            admenubtn.Text = "Payroll";
            admenubtn.UseVisualStyleBackColor = false;
            // 
            // adlogoutbtn
            // 
            adlogoutbtn.Anchor = AnchorStyles.None;
            adlogoutbtn.BackColor = Color.Coral;
            adlogoutbtn.BackgroundImageLayout = ImageLayout.None;
            adlogoutbtn.Cursor = Cursors.Hand;
            adlogoutbtn.FlatStyle = FlatStyle.Flat;
            adlogoutbtn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            adlogoutbtn.ForeColor = Color.Honeydew;
            adlogoutbtn.Location = new Point(48, 1091);
            adlogoutbtn.Name = "adlogoutbtn";
            adlogoutbtn.Size = new Size(243, 62);
            adlogoutbtn.TabIndex = 12;
            adlogoutbtn.Text = "Log out";
            adlogoutbtn.UseVisualStyleBackColor = false;
            // 
            // adlogsbtn
            // 
            adlogsbtn.BackColor = Color.Black;
            adlogsbtn.Cursor = Cursors.Hand;
            adlogsbtn.FlatStyle = FlatStyle.Popup;
            adlogsbtn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            adlogsbtn.ForeColor = Color.Honeydew;
            adlogsbtn.Location = new Point(12, 630);
            adlogsbtn.Name = "adlogsbtn";
            adlogsbtn.Size = new Size(243, 62);
            adlogsbtn.TabIndex = 11;
            adlogsbtn.Text = "Reports & Analytics";
            adlogsbtn.UseVisualStyleBackColor = false;
            // 
            // adsystembtn
            // 
            adsystembtn.BackColor = Color.Black;
            adsystembtn.Cursor = Cursors.Hand;
            adsystembtn.FlatStyle = FlatStyle.Popup;
            adsystembtn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            adsystembtn.ForeColor = Color.Honeydew;
            adsystembtn.Location = new Point(12, 550);
            adsystembtn.Name = "adsystembtn";
            adsystembtn.Size = new Size(243, 62);
            adsystembtn.TabIndex = 10;
            adsystembtn.Text = "Compliance & Policies";
            adsystembtn.UseVisualStyleBackColor = false;
            // 
            // adsupplybtn
            // 
            adsupplybtn.BackColor = Color.Black;
            adsupplybtn.Cursor = Cursors.Hand;
            adsupplybtn.FlatStyle = FlatStyle.Flat;
            adsupplybtn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            adsupplybtn.ForeColor = Color.Honeydew;
            adsupplybtn.FormattingEnabled = true;
            adsupplybtn.Items.AddRange(new object[] { "           Suppliers", "     Purchase orders" });
            adsupplybtn.Location = new Point(12, 415);
            adsupplybtn.Name = "adsupplybtn";
            adsupplybtn.Size = new Size(243, 38);
            adsupplybtn.TabIndex = 9;
            adsupplybtn.Text = "Recruitment and Onboarding ";
            // 
            // adfinancebtn
            // 
            adfinancebtn.BackColor = Color.Black;
            adfinancebtn.Cursor = Cursors.Hand;
            adfinancebtn.FlatStyle = FlatStyle.Popup;
            adfinancebtn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            adfinancebtn.ForeColor = Color.Honeydew;
            adfinancebtn.Location = new Point(12, 468);
            adfinancebtn.Name = "adfinancebtn";
            adfinancebtn.Size = new Size(243, 62);
            adfinancebtn.TabIndex = 8;
            adfinancebtn.Text = "Performance & Training";
            adfinancebtn.UseVisualStyleBackColor = false;
            // 
            // adstaffbtn
            // 
            adstaffbtn.BackColor = Color.Black;
            adstaffbtn.Cursor = Cursors.Hand;
            adstaffbtn.FlatStyle = FlatStyle.Popup;
            adstaffbtn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            adstaffbtn.ForeColor = Color.Honeydew;
            adstaffbtn.Location = new Point(12, 338);
            adstaffbtn.Name = "adstaffbtn";
            adstaffbtn.Size = new Size(243, 62);
            adstaffbtn.TabIndex = 7;
            adstaffbtn.Text = "Leave &Time-Off";
            adstaffbtn.UseVisualStyleBackColor = false;
            // 
            // adinventorybtn
            // 
            adinventorybtn.BackColor = Color.Black;
            adinventorybtn.Cursor = Cursors.Hand;
            adinventorybtn.FlatStyle = FlatStyle.Popup;
            adinventorybtn.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            adinventorybtn.ForeColor = Color.Honeydew;
            adinventorybtn.Location = new Point(12, 181);
            adinventorybtn.Name = "adinventorybtn";
            adinventorybtn.Size = new Size(243, 62);
            adinventorybtn.TabIndex = 6;
            adinventorybtn.Text = "Attendance & Shifts";
            adinventorybtn.UseVisualStyleBackColor = false;
            // 
            // adsalesbtn
            // 
            adsalesbtn.BackColor = Color.Black;
            adsalesbtn.Cursor = Cursors.Hand;
            adsalesbtn.FlatStyle = FlatStyle.Popup;
            adsalesbtn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            adsalesbtn.ForeColor = Color.Honeydew;
            adsalesbtn.Location = new Point(12, 100);
            adsalesbtn.Name = "adsalesbtn";
            adsalesbtn.Size = new Size(243, 62);
            adsalesbtn.TabIndex = 5;
            adsalesbtn.Text = "Employee Management";
            adsalesbtn.UseVisualStyleBackColor = false;
            // 
            // dashbtn
            // 
            dashbtn.BackColor = Color.Black;
            dashbtn.Cursor = Cursors.Hand;
            dashbtn.FlatStyle = FlatStyle.Popup;
            dashbtn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            dashbtn.ForeColor = Color.Honeydew;
            dashbtn.Location = new Point(12, 20);
            dashbtn.Name = "dashbtn";
            dashbtn.Size = new Size(243, 62);
            dashbtn.TabIndex = 4;
            dashbtn.Text = "Dashboard";
            dashbtn.UseVisualStyleBackColor = false;
            // 
            // adminicon
            // 
            adminicon.BackColor = Color.Transparent;
            adminicon.BackgroundImageLayout = ImageLayout.None;
            adminicon.Image = (Image)resources.GetObject("adminicon.Image");
            adminicon.Location = new Point(624, 10);
            adminicon.Name = "adminicon";
            adminicon.Size = new Size(103, 96);
            adminicon.SizeMode = PictureBoxSizeMode.Zoom;
            adminicon.TabIndex = 2;
            adminicon.TabStop = false;
            // 
            // userwelcome
            // 
            userwelcome.AutoSize = true;
            userwelcome.BackColor = Color.Transparent;
            userwelcome.FlatStyle = FlatStyle.Flat;
            userwelcome.Font = new Font("Segoe UI", 38.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userwelcome.ForeColor = Color.Coral;
            userwelcome.Location = new Point(203, 38);
            userwelcome.Name = "userwelcome";
            userwelcome.Size = new Size(439, 68);
            userwelcome.TabIndex = 1;
            userwelcome.Text = "Welcome, Admin";
            // 
            // fficonadmin
            // 
            fficonadmin.BackColor = Color.Transparent;
            fficonadmin.BackgroundImageLayout = ImageLayout.None;
            fficonadmin.Image = (Image)resources.GetObject("fficonadmin.Image");
            fficonadmin.Location = new Point(-43, -105);
            fficonadmin.Name = "fficonadmin";
            fficonadmin.Size = new Size(324, 324);
            fficonadmin.SizeMode = PictureBoxSizeMode.Zoom;
            fficonadmin.TabIndex = 0;
            fficonadmin.TabStop = false;
            // 
            // hrdashboardleaverequestspanel
            // 
            hrdashboardleaverequestspanel.BackColor = Color.Black;
            hrdashboardleaverequestspanel.Controls.Add(hrdashboardleaverequeststxt);
            hrdashboardleaverequestspanel.Controls.Add(label3);
            hrdashboardleaverequestspanel.Location = new Point(919, 152);
            hrdashboardleaverequestspanel.Name = "hrdashboardleaverequestspanel";
            hrdashboardleaverequestspanel.Size = new Size(603, 126);
            hrdashboardleaverequestspanel.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(26, 6);
            label3.Name = "label3";
            label3.Size = new Size(246, 45);
            label3.TabIndex = 2;
            label3.Text = "Leave Requests";
            // 
            // hrdashboardleaverequeststxt
            // 
            hrdashboardleaverequeststxt.Location = new Point(127, 57);
            hrdashboardleaverequeststxt.Multiline = true;
            hrdashboardleaverequeststxt.Name = "hrdashboardleaverequeststxt";
            hrdashboardleaverequeststxt.Size = new Size(174, 52);
            hrdashboardleaverequeststxt.TabIndex = 3;
            // 
            // hrdashboardattendancetodaytxt
            // 
            hrdashboardattendancetodaytxt.Location = new Point(127, 54);
            hrdashboardattendancetodaytxt.Multiline = true;
            hrdashboardattendancetodaytxt.Name = "hrdashboardattendancetodaytxt";
            hrdashboardattendancetodaytxt.Size = new Size(174, 52);
            hrdashboardattendancetodaytxt.TabIndex = 4;
            // 
            // hrdashboardleavecontractstxt
            // 
            hrdashboardleavecontractstxt.Location = new Point(223, 148);
            hrdashboardleavecontractstxt.Multiline = true;
            hrdashboardleavecontractstxt.Name = "hrdashboardleavecontractstxt";
            hrdashboardleavecontractstxt.Size = new Size(185, 75);
            hrdashboardleavecontractstxt.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(30, 143);
            label4.Name = "label4";
            label4.Size = new Size(148, 80);
            label4.TabIndex = 5;
            label4.Text = "Leave\nContracts";
            // 
            // hrdashboardemployeeheadcounttxt
            // 
            hrdashboardemployeeheadcounttxt.Location = new Point(120, 101);
            hrdashboardemployeeheadcounttxt.Multiline = true;
            hrdashboardemployeeheadcounttxt.Name = "hrdashboardemployeeheadcounttxt";
            hrdashboardemployeeheadcounttxt.Size = new Size(192, 118);
            hrdashboardemployeeheadcounttxt.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(27, 522);
            label5.Name = "label5";
            label5.Size = new Size(231, 45);
            label5.TabIndex = 5;
            label5.Text = "Notifications: ";
            // 
            // hrdashboardbirthdaystxt
            // 
            hrdashboardbirthdaystxt.Location = new Point(252, 15);
            hrdashboardbirthdaystxt.Multiline = true;
            hrdashboardbirthdaystxt.Name = "hrdashboardbirthdaystxt";
            hrdashboardbirthdaystxt.Size = new Size(171, 44);
            hrdashboardbirthdaystxt.TabIndex = 5;
            // 
            // hrdashboardexpiriestxt
            // 
            hrdashboardexpiriestxt.Location = new Point(252, 85);
            hrdashboardexpiriestxt.Multiline = true;
            hrdashboardexpiriestxt.Name = "hrdashboardexpiriestxt";
            hrdashboardexpiriestxt.Size = new Size(171, 44);
            hrdashboardexpiriestxt.TabIndex = 6;
            // 
            // HrDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(panelTop);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "HrDashboard";
            Text = "HR Dashboard";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dashadrefreshicon).EndInit();
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            dashnetprofit.ResumeLayout(false);
            dashnetprofit.PerformLayout();
            dashinventoryusage.ResumeLayout(false);
            dashinventoryusage.PerformLayout();
            dashtotalexpense.ResumeLayout(false);
            dashtotalexpense.PerformLayout();
            dashattendancetodaypanel.ResumeLayout(false);
            dashattendancetodaypanel.PerformLayout();
            dashactive.ResumeLayout(false);
            dashactive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dashactiveon).EndInit();
            dashnotif.ResumeLayout(false);
            dashnotif.PerformLayout();
            dashvisuals.ResumeLayout(false);
            dashvisuals.PerformLayout();
            dashtotalsales.ResumeLayout(false);
            dashtotalsales.PerformLayout();
            panelNav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)adminicon).EndInit();
            ((System.ComponentModel.ISupportInitialize)fficonadmin).EndInit();
            hrdashboardleaverequestspanel.ResumeLayout(false);
            hrdashboardleaverequestspanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private PictureBox dashadrefreshicon;
        private Label dashadtime;
        private Label dashaddate;
        private Panel panelContent;
        private Panel dashnetprofit;
        private Label dashnetprofittxt;
        private Panel dashinventoryusage;
        private Label label2;
        private Panel dashtotalexpense;
        private Label dashtotalexptxt;
        private Panel dashattendancetodaypanel;
        private Label dashinventorytxt;
        private Panel dashactive;
        private PictureBox dashactiveon;
        private Label label1;
        private Panel dashnotif;
        private Label dashlowstackalerts;
        private Label dashrecenttransactions;
        private Panel dashvisuals;
        private Label dashvisualtoptxt;
        private Label dashvisualtxtsales;
        private Panel dashtotalsales;
        private Label dashsalestxt;
        private Panel panelNav;
        private Button admenubtn;
        private Button adlogoutbtn;
        private Button adlogsbtn;
        private Button adsystembtn;
        private ComboBox adsupplybtn;
        private Button adfinancebtn;
        private Button adstaffbtn;
        private Button adinventorybtn;
        private Button adsalesbtn;
        private Button dashbtn;
        private PictureBox adminicon;
        private Label userwelcome;
        private PictureBox fficonadmin;
        private Panel hrdashboardleaverequestspanel;
        private Label label3;
        private TextBox hrdashboardleaverequeststxt;
        private TextBox hrdashboardattendancetodaytxt;
        private Label label5;
        private TextBox hrdashboardbirthdaystxt;
        private Label label4;
        private TextBox hrdashboardleavecontractstxt;
        private TextBox hrdashboardemployeeheadcounttxt;
        private TextBox hrdashboardexpiriestxt;
    }
}