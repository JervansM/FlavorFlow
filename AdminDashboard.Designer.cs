namespace FlavorFlowIT13
{
    partial class AdminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            panelTop = new Panel();
            dashadrefreshicon = new PictureBox();
            dashadtime = new Label();
            dashaddate = new Label();
            panelContent = new Panel();
            dashnetprofit = new Panel();
            netprofittxt = new Label();
            dashnetprofittxt = new Label();
            dashinventoryusage = new Panel();
            dashInventoryUsed_txt = new Label();
            label2 = new Label();
            dashtotalexpense = new Panel();
            totalexpensetxt = new Label();
            dashtotalexptxt = new Label();
            dashinventorystatus = new Panel();
            dashTotalItems_txt = new Label();
            dashinventorytxt = new Label();
            dashactive = new Panel();
            activeorderslbl = new Label();
            dashactiveon = new PictureBox();
            label1 = new Label();
            dashnotif = new Panel();
            sysalertlbl = new Label();
            pendinglbl = new Label();
            lowstocklbl = new Label();
            recenttransactionlbl = new Label();
            dashsystemnotif = new Label();
            dashpendingapprovals = new Label();
            dashlowstackalerts = new Label();
            dashrecenttransactions = new Label();
            dashvisuals = new Panel();
            menulblsales = new Label();
            totalordersmenu = new Label();
            totalsalesmenu = new Label();
            topsellingmenupic = new PictureBox();
            dashvisualtoptxt = new Label();
            dashtotalsales = new Panel();
            dashsalescontenttxt = new Label();
            dashsalesicon = new PictureBox();
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
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dashadrefreshicon).BeginInit();
            panelContent.SuspendLayout();
            dashnetprofit.SuspendLayout();
            dashinventoryusage.SuspendLayout();
            dashtotalexpense.SuspendLayout();
            dashinventorystatus.SuspendLayout();
            dashactive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dashactiveon).BeginInit();
            dashnotif.SuspendLayout();
            dashvisuals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)topsellingmenupic).BeginInit();
            dashtotalsales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dashsalesicon).BeginInit();
            panelNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)adminicon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fficonadmin).BeginInit();
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
            panelTop.Location = new Point(30, 28);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1872, 972);
            panelTop.TabIndex = 0;
            panelTop.Paint += panelTop_Paint;
            // 
            // dashadrefreshicon
            // 
            dashadrefreshicon.BackColor = Color.Transparent;
            dashadrefreshicon.BackgroundImageLayout = ImageLayout.None;
            dashadrefreshicon.Cursor = Cursors.Hand;
            dashadrefreshicon.Image = (Image)resources.GetObject("dashadrefreshicon.Image");
            dashadrefreshicon.Location = new Point(1697, 68);
            dashadrefreshicon.Name = "dashadrefreshicon";
            dashadrefreshicon.Size = new Size(118, 48);
            dashadrefreshicon.SizeMode = PictureBoxSizeMode.Zoom;
            dashadrefreshicon.TabIndex = 3;
            dashadrefreshicon.TabStop = false;
            dashadrefreshicon.Click += dashadrefreshicon_Click;
            // 
            // dashadtime
            // 
            dashadtime.AutoSize = true;
            dashadtime.BackColor = Color.Transparent;
            dashadtime.FlatStyle = FlatStyle.Flat;
            dashadtime.Font = new Font("Segoe UI", 32.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dashadtime.ForeColor = Color.Coral;
            dashadtime.Location = new Point(1414, 57);
            dashadtime.Name = "dashadtime";
            dashadtime.Size = new Size(124, 59);
            dashadtime.TabIndex = 16;
            dashadtime.Text = "Time";
            dashadtime.Click += dashadtime_Click;
            // 
            // dashaddate
            // 
            dashaddate.AutoSize = true;
            dashaddate.BackColor = Color.Transparent;
            dashaddate.FlatStyle = FlatStyle.Flat;
            dashaddate.Font = new Font("Segoe UI", 32.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dashaddate.ForeColor = Color.Coral;
            dashaddate.Location = new Point(982, 57);
            dashaddate.Name = "dashaddate";
            dashaddate.Size = new Size(120, 59);
            dashaddate.TabIndex = 15;
            dashaddate.Text = "Date";
            dashaddate.Click += dashaddate_Click;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.Silver;
            panelContent.BackgroundImageLayout = ImageLayout.None;
            panelContent.Controls.Add(dashnetprofit);
            panelContent.Controls.Add(dashinventoryusage);
            panelContent.Controls.Add(dashtotalexpense);
            panelContent.Controls.Add(dashinventorystatus);
            panelContent.Controls.Add(dashactive);
            panelContent.Controls.Add(dashnotif);
            panelContent.Controls.Add(dashvisuals);
            panelContent.Controls.Add(dashtotalsales);
            panelContent.Location = new Point(303, 125);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1545, 814);
            panelContent.TabIndex = 14;
            panelContent.Paint += panelContent_Paint;
            // 
            // dashnetprofit
            // 
            dashnetprofit.Anchor = AnchorStyles.Bottom;
            dashnetprofit.BackColor = Color.Black;
            dashnetprofit.Controls.Add(netprofittxt);
            dashnetprofit.Controls.Add(dashnetprofittxt);
            dashnetprofit.Location = new Point(1054, 621);
            dashnetprofit.Name = "dashnetprofit";
            dashnetprofit.Size = new Size(468, 174);
            dashnetprofit.TabIndex = 4;
            dashnetprofit.Paint += dashnetprofit_Paint;
            // 
            // netprofittxt
            // 
            netprofittxt.AutoSize = true;
            netprofittxt.BackColor = Color.Transparent;
            netprofittxt.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            netprofittxt.ForeColor = Color.DeepSkyBlue;
            netprofittxt.Location = new Point(97, 61);
            netprofittxt.Name = "netprofittxt";
            netprofittxt.Size = new Size(59, 65);
            netprofittxt.TabIndex = 4;
            netprofittxt.Text = "₱";
            netprofittxt.Click += netprofittxt_Click;
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
            dashinventoryusage.Controls.Add(dashInventoryUsed_txt);
            dashinventoryusage.Controls.Add(label2);
            dashinventoryusage.Location = new Point(1054, 382);
            dashinventoryusage.Name = "dashinventoryusage";
            dashinventoryusage.Size = new Size(468, 233);
            dashinventoryusage.TabIndex = 3;
            // 
            // dashInventoryUsed_txt
            // 
            dashInventoryUsed_txt.AutoSize = true;
            dashInventoryUsed_txt.BackColor = Color.Transparent;
            dashInventoryUsed_txt.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dashInventoryUsed_txt.ForeColor = Color.Coral;
            dashInventoryUsed_txt.Location = new Point(97, 116);
            dashInventoryUsed_txt.Name = "dashInventoryUsed_txt";
            dashInventoryUsed_txt.Size = new Size(59, 65);
            dashInventoryUsed_txt.TabIndex = 6;
            dashInventoryUsed_txt.Text = "₱";
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
            dashtotalexpense.Controls.Add(totalexpensetxt);
            dashtotalexpense.Controls.Add(dashtotalexptxt);
            dashtotalexpense.Location = new Point(1054, 206);
            dashtotalexpense.Name = "dashtotalexpense";
            dashtotalexpense.Size = new Size(468, 170);
            dashtotalexpense.TabIndex = 3;
            // 
            // totalexpensetxt
            // 
            totalexpensetxt.AutoSize = true;
            totalexpensetxt.BackColor = Color.Transparent;
            totalexpensetxt.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalexpensetxt.ForeColor = Color.IndianRed;
            totalexpensetxt.Location = new Point(97, 65);
            totalexpensetxt.Name = "totalexpensetxt";
            totalexpensetxt.Size = new Size(59, 65);
            totalexpensetxt.TabIndex = 3;
            totalexpensetxt.Text = "₱";
            totalexpensetxt.Click += totalexpensetxt_Click;
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
            // dashinventorystatus
            // 
            dashinventorystatus.BackColor = Color.Black;
            dashinventorystatus.Controls.Add(dashTotalItems_txt);
            dashinventorystatus.Controls.Add(dashinventorytxt);
            dashinventorystatus.Location = new Point(919, 20);
            dashinventorystatus.Name = "dashinventorystatus";
            dashinventorystatus.Size = new Size(603, 180);
            dashinventorystatus.TabIndex = 2;
            // 
            // dashTotalItems_txt
            // 
            dashTotalItems_txt.AutoSize = true;
            dashTotalItems_txt.BackColor = Color.Transparent;
            dashTotalItems_txt.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dashTotalItems_txt.ForeColor = Color.Coral;
            dashTotalItems_txt.Location = new Point(232, 63);
            dashTotalItems_txt.Name = "dashTotalItems_txt";
            dashTotalItems_txt.Size = new Size(59, 65);
            dashTotalItems_txt.TabIndex = 4;
            dashTotalItems_txt.Text = "₱";
            // 
            // dashinventorytxt
            // 
            dashinventorytxt.AutoSize = true;
            dashinventorytxt.BackColor = Color.Transparent;
            dashinventorytxt.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            dashinventorytxt.ForeColor = Color.White;
            dashinventorytxt.Location = new Point(26, 6);
            dashinventorytxt.Name = "dashinventorytxt";
            dashinventorytxt.Size = new Size(265, 45);
            dashinventorytxt.TabIndex = 2;
            dashinventorytxt.Text = "Inventory Status";
            // 
            // dashactive
            // 
            dashactive.BackColor = Color.Black;
            dashactive.Controls.Add(activeorderslbl);
            dashactive.Controls.Add(dashactiveon);
            dashactive.Controls.Add(label1);
            dashactive.Location = new Point(456, 20);
            dashactive.Name = "dashactive";
            dashactive.Size = new Size(457, 180);
            dashactive.TabIndex = 1;
            dashactive.Paint += dashactive_Paint;
            // 
            // activeorderslbl
            // 
            activeorderslbl.AutoSize = true;
            activeorderslbl.BackColor = Color.Transparent;
            activeorderslbl.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            activeorderslbl.ForeColor = Color.White;
            activeorderslbl.Location = new Point(206, 63);
            activeorderslbl.Name = "activeorderslbl";
            activeorderslbl.Size = new Size(47, 65);
            activeorderslbl.TabIndex = 18;
            activeorderslbl.Text = "-";
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
            dashactiveon.Click += dashactiveon_Click_;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(30, 6);
            label1.Name = "label1";
            label1.Size = new Size(223, 45);
            label1.TabIndex = 1;
            label1.Text = "Active Orders";
            // 
            // dashnotif
            // 
            dashnotif.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dashnotif.BackColor = Color.Black;
            dashnotif.Controls.Add(sysalertlbl);
            dashnotif.Controls.Add(pendinglbl);
            dashnotif.Controls.Add(lowstocklbl);
            dashnotif.Controls.Add(recenttransactionlbl);
            dashnotif.Controls.Add(dashsystemnotif);
            dashnotif.Controls.Add(dashpendingapprovals);
            dashnotif.Controls.Add(dashlowstackalerts);
            dashnotif.Controls.Add(dashrecenttransactions);
            dashnotif.Location = new Point(27, 570);
            dashnotif.Name = "dashnotif";
            dashnotif.Size = new Size(1021, 225);
            dashnotif.TabIndex = 2;
            dashnotif.Paint += dashnotif_Paint;
            // 
            // sysalertlbl
            // 
            sysalertlbl.AutoSize = true;
            sysalertlbl.BackColor = Color.Transparent;
            sysalertlbl.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sysalertlbl.ForeColor = Color.White;
            sysalertlbl.Location = new Point(635, 131);
            sysalertlbl.Name = "sysalertlbl";
            sysalertlbl.Size = new Size(47, 65);
            sysalertlbl.TabIndex = 25;
            sysalertlbl.Text = "-";
            // 
            // pendinglbl
            // 
            pendinglbl.AutoSize = true;
            pendinglbl.BackColor = Color.Transparent;
            pendinglbl.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pendinglbl.ForeColor = Color.White;
            pendinglbl.Location = new Point(635, 86);
            pendinglbl.Name = "pendinglbl";
            pendinglbl.Size = new Size(47, 65);
            pendinglbl.TabIndex = 24;
            pendinglbl.Text = "-";
            // 
            // lowstocklbl
            // 
            lowstocklbl.AutoSize = true;
            lowstocklbl.BackColor = Color.Transparent;
            lowstocklbl.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lowstocklbl.ForeColor = Color.White;
            lowstocklbl.Location = new Point(635, 36);
            lowstocklbl.Name = "lowstocklbl";
            lowstocklbl.Size = new Size(47, 65);
            lowstocklbl.TabIndex = 23;
            lowstocklbl.Text = "-";
            // 
            // recenttransactionlbl
            // 
            recenttransactionlbl.AutoSize = true;
            recenttransactionlbl.BackColor = Color.Transparent;
            recenttransactionlbl.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            recenttransactionlbl.ForeColor = Color.White;
            recenttransactionlbl.Location = new Point(635, -16);
            recenttransactionlbl.Name = "recenttransactionlbl";
            recenttransactionlbl.Size = new Size(47, 65);
            recenttransactionlbl.TabIndex = 22;
            recenttransactionlbl.Text = "-";
            // 
            // dashsystemnotif
            // 
            dashsystemnotif.AutoSize = true;
            dashsystemnotif.BackColor = Color.Transparent;
            dashsystemnotif.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            dashsystemnotif.ForeColor = Color.White;
            dashsystemnotif.Location = new Point(19, 164);
            dashsystemnotif.Name = "dashsystemnotif";
            dashsystemnotif.Size = new Size(317, 32);
            dashsystemnotif.TabIndex = 6;
            dashsystemnotif.Text = "System Alerts / Audit Logs";
            dashsystemnotif.Click += label6_Click;
            // 
            // dashpendingapprovals
            // 
            dashpendingapprovals.AutoSize = true;
            dashpendingapprovals.BackColor = Color.Transparent;
            dashpendingapprovals.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            dashpendingapprovals.ForeColor = Color.White;
            dashpendingapprovals.Location = new Point(19, 112);
            dashpendingapprovals.Name = "dashpendingapprovals";
            dashpendingapprovals.Size = new Size(231, 32);
            dashpendingapprovals.TabIndex = 5;
            dashpendingapprovals.Text = "Pending Approvals";
            // 
            // dashlowstackalerts
            // 
            dashlowstackalerts.AutoSize = true;
            dashlowstackalerts.BackColor = Color.Transparent;
            dashlowstackalerts.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            dashlowstackalerts.ForeColor = Color.White;
            dashlowstackalerts.Location = new Point(19, 60);
            dashlowstackalerts.Name = "dashlowstackalerts";
            dashlowstackalerts.Size = new Size(203, 32);
            dashlowstackalerts.TabIndex = 4;
            dashlowstackalerts.Text = "Low Stock Alerts";
            // 
            // dashrecenttransactions
            // 
            dashrecenttransactions.AutoSize = true;
            dashrecenttransactions.BackColor = Color.Transparent;
            dashrecenttransactions.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            dashrecenttransactions.ForeColor = Color.White;
            dashrecenttransactions.Location = new Point(19, 10);
            dashrecenttransactions.Name = "dashrecenttransactions";
            dashrecenttransactions.Size = new Size(241, 32);
            dashrecenttransactions.TabIndex = 3;
            dashrecenttransactions.Text = "Recent Transactions";
            dashrecenttransactions.Click += label3_Click;
            // 
            // dashvisuals
            // 
            dashvisuals.BackColor = Color.Black;
            dashvisuals.Controls.Add(menulblsales);
            dashvisuals.Controls.Add(totalordersmenu);
            dashvisuals.Controls.Add(totalsalesmenu);
            dashvisuals.Controls.Add(topsellingmenupic);
            dashvisuals.Controls.Add(dashvisualtoptxt);
            dashvisuals.Location = new Point(27, 206);
            dashvisuals.Name = "dashvisuals";
            dashvisuals.Size = new Size(1021, 357);
            dashvisuals.TabIndex = 1;
            // 
            // menulblsales
            // 
            menulblsales.AutoSize = true;
            menulblsales.BackColor = Color.Transparent;
            menulblsales.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            menulblsales.ForeColor = Color.White;
            menulblsales.Location = new Point(591, 20);
            menulblsales.Name = "menulblsales";
            menulblsales.Size = new Size(311, 45);
            menulblsales.TabIndex = 7;
            menulblsales.Text = "Total Sales / Orders";
            // 
            // totalordersmenu
            // 
            totalordersmenu.AutoSize = true;
            totalordersmenu.BackColor = Color.Transparent;
            totalordersmenu.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalordersmenu.ForeColor = Color.White;
            totalordersmenu.Location = new Point(623, 220);
            totalordersmenu.Name = "totalordersmenu";
            totalordersmenu.Size = new Size(59, 65);
            totalordersmenu.TabIndex = 6;
            totalordersmenu.Text = "₱";
            totalordersmenu.Click += totalordersmenu_Click;
            // 
            // totalsalesmenu
            // 
            totalsalesmenu.AutoSize = true;
            totalsalesmenu.BackColor = Color.Transparent;
            totalsalesmenu.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalsalesmenu.ForeColor = Color.LimeGreen;
            totalsalesmenu.Location = new Point(623, 91);
            totalsalesmenu.Name = "totalsalesmenu";
            totalsalesmenu.Size = new Size(59, 65);
            totalsalesmenu.TabIndex = 5;
            totalsalesmenu.Text = "₱";
            totalsalesmenu.Click += totalsalesmenu_Click;
            // 
            // topsellingmenupic
            // 
            topsellingmenupic.Location = new Point(38, 91);
            topsellingmenupic.Name = "topsellingmenupic";
            topsellingmenupic.Size = new Size(502, 233);
            topsellingmenupic.SizeMode = PictureBoxSizeMode.StretchImage;
            topsellingmenupic.TabIndex = 3;
            topsellingmenupic.TabStop = false;
            topsellingmenupic.Click += topsellingmenupic_Click;
            // 
            // dashvisualtoptxt
            // 
            dashvisualtoptxt.AutoSize = true;
            dashvisualtoptxt.BackColor = Color.Transparent;
            dashvisualtoptxt.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            dashvisualtoptxt.ForeColor = Color.White;
            dashvisualtoptxt.Location = new Point(27, 20);
            dashvisualtoptxt.Name = "dashvisualtoptxt";
            dashvisualtoptxt.Size = new Size(285, 45);
            dashvisualtoptxt.TabIndex = 2;
            dashvisualtoptxt.Text = "Top-Selling Menu";
            // 
            // dashtotalsales
            // 
            dashtotalsales.BackColor = Color.Black;
            dashtotalsales.Controls.Add(dashsalescontenttxt);
            dashtotalsales.Controls.Add(dashsalesicon);
            dashtotalsales.Controls.Add(dashsalestxt);
            dashtotalsales.Location = new Point(27, 20);
            dashtotalsales.Name = "dashtotalsales";
            dashtotalsales.Size = new Size(423, 180);
            dashtotalsales.TabIndex = 0;
            dashtotalsales.Paint += dashtotalsales_Paint;
            // 
            // dashsalescontenttxt
            // 
            dashsalescontenttxt.AutoSize = true;
            dashsalescontenttxt.BackColor = Color.Transparent;
            dashsalescontenttxt.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dashsalescontenttxt.ForeColor = Color.LimeGreen;
            dashsalescontenttxt.Location = new Point(74, 63);
            dashsalescontenttxt.Name = "dashsalescontenttxt";
            dashsalescontenttxt.Size = new Size(59, 65);
            dashsalescontenttxt.TabIndex = 2;
            dashsalescontenttxt.Text = "₱";
            dashsalescontenttxt.Click += dashsalescontent_Click;
            // 
            // dashsalesicon
            // 
            dashsalesicon.BackColor = Color.Transparent;
            dashsalesicon.BackgroundImageLayout = ImageLayout.None;
            dashsalesicon.Image = (Image)resources.GetObject("dashsalesicon.Image");
            dashsalesicon.Location = new Point(290, 0);
            dashsalesicon.Name = "dashsalesicon";
            dashsalesicon.Size = new Size(118, 62);
            dashsalesicon.SizeMode = PictureBoxSizeMode.Zoom;
            dashsalesicon.TabIndex = 1;
            dashsalesicon.TabStop = false;
            // 
            // dashsalestxt
            // 
            dashsalestxt.AutoSize = true;
            dashsalestxt.BackColor = Color.Transparent;
            dashsalestxt.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            dashsalestxt.ForeColor = Color.White;
            dashsalestxt.Location = new Point(18, 8);
            dashsalestxt.Name = "dashsalestxt";
            dashsalestxt.Size = new Size(286, 45);
            dashsalestxt.TabIndex = 0;
            dashsalestxt.Text = "Total Sales Today ";
            dashsalestxt.Click += dashsalestxt_Click;
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
            panelNav.Paint += panelNav_Paint;
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
            admenubtn.Text = "Menu Management";
            admenubtn.UseVisualStyleBackColor = false;
            admenubtn.Click += admenubtn_Click;
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
            adlogoutbtn.Location = new Point(12, 734);
            adlogoutbtn.Name = "adlogoutbtn";
            adlogoutbtn.Size = new Size(243, 62);
            adlogoutbtn.TabIndex = 12;
            adlogoutbtn.Text = "Log out";
            adlogoutbtn.UseVisualStyleBackColor = false;
            adlogoutbtn.Click += adlogoutbtn_Click;
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
            adlogsbtn.Text = "Audit Logs / Security";
            adlogsbtn.UseVisualStyleBackColor = false;
            adlogsbtn.Click += adlogsbtn_Click;
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
            adsystembtn.Text = "System Settings";
            adsystembtn.UseVisualStyleBackColor = false;
            adsystembtn.Click += adsystembtn_Click;
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
            adsupplybtn.Text = "   Supplier / Purchase";
            adsupplybtn.SelectedIndexChanged += adsupplybtn_SelectedIndexChanged;
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
            adfinancebtn.Text = "Finance / Expenses";
            adfinancebtn.UseVisualStyleBackColor = false;
            adfinancebtn.Click += adfinancebtn_Click;
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
            adstaffbtn.Text = "Staff Management";
            adstaffbtn.UseVisualStyleBackColor = false;
            adstaffbtn.Click += adstaffbtn_Click;
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
            adinventorybtn.Text = "Inventory Management";
            adinventorybtn.UseVisualStyleBackColor = false;
            adinventorybtn.Click += adinventorybtn_Click;
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
            adsalesbtn.Text = "Sales / POS Reports";
            adsalesbtn.UseVisualStyleBackColor = false;
            adsalesbtn.Click += adsalesbtn_Click;
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
            dashbtn.Click += dashbtn_Click;
            // 
            // adminicon
            // 
            adminicon.BackColor = Color.Transparent;
            adminicon.BackgroundImageLayout = ImageLayout.None;
            adminicon.Image = (Image)resources.GetObject("adminicon.Image");
            adminicon.Location = new Point(575, 42);
            adminicon.Name = "adminicon";
            adminicon.Size = new Size(80, 77);
            adminicon.SizeMode = PictureBoxSizeMode.Zoom;
            adminicon.TabIndex = 2;
            adminicon.TabStop = false;
            adminicon.Click += adminicon_Click;
            // 
            // userwelcome
            // 
            userwelcome.AutoSize = true;
            userwelcome.BackColor = Color.Transparent;
            userwelcome.FlatStyle = FlatStyle.Flat;
            userwelcome.Font = new Font("Segoe UI", 32.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userwelcome.ForeColor = Color.Coral;
            userwelcome.Location = new Point(221, 57);
            userwelcome.Name = "userwelcome";
            userwelcome.Size = new Size(369, 59);
            userwelcome.TabIndex = 1;
            userwelcome.Text = "Welcome, Admin";
            userwelcome.Click += userwelcome_Click;
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
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1924, 1061);
            Controls.Add(panelTop);
            Cursor = Cursors.Hand;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AdminDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += AdminDashboard_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dashadrefreshicon).EndInit();
            panelContent.ResumeLayout(false);
            dashnetprofit.ResumeLayout(false);
            dashnetprofit.PerformLayout();
            dashinventoryusage.ResumeLayout(false);
            dashinventoryusage.PerformLayout();
            dashtotalexpense.ResumeLayout(false);
            dashtotalexpense.PerformLayout();
            dashinventorystatus.ResumeLayout(false);
            dashinventorystatus.PerformLayout();
            dashactive.ResumeLayout(false);
            dashactive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dashactiveon).EndInit();
            dashnotif.ResumeLayout(false);
            dashnotif.PerformLayout();
            dashvisuals.ResumeLayout(false);
            dashvisuals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)topsellingmenupic).EndInit();
            dashtotalsales.ResumeLayout(false);
            dashtotalsales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dashsalesicon).EndInit();
            panelNav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)adminicon).EndInit();
            ((System.ComponentModel.ISupportInitialize)fficonadmin).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private PictureBox fficonadmin;
        private Label userwelcome;
        private PictureBox adminicon;
        private Panel panelNav;
        private Button dashbtn;
        private Button adstaffbtn;
        private Button adinventorybtn;
        private Button adsalesbtn;
        private ComboBox adsupplybtn;
        private Button adfinancebtn;
        private Button adlogsbtn;
        private Button adsystembtn;
        private Button adlogoutbtn;
        private Button admenubtn;
        private Panel panelContent;
        private Panel dashtotalsales;
        private Panel dashnotif;
        private Panel dashvisuals;
        private Panel dashtotalexpense;
        private Panel dashinventorystatus;
        private Panel dashactive;
        private Panel dashnetprofit;
        private Panel dashinventoryusage;
        private Label dashsalestxt;
        private Label label1;
        private Label dashtotalexptxt;
        private Label dashinventorytxt;
        private Label label2;
        private Label dashnetprofittxt;
        private Label dashrecenttransactions;
        private Label dashvisualtoptxt;
        private Label dashsystemnotif;
        private Label dashpendingapprovals;
        private Label dashlowstackalerts;
        private Label dashadtime;
        private Label dashaddate;
        private PictureBox dashsalesicon;
        private Label dashsalescontenttxt;
        private PictureBox dashadrefreshicon;
        private PictureBox dashactiveon;
        private Label totalexpensetxt;
        private Label netprofittxt;
        private Label dashInventoryUsed_txt;
        private Label dashTotalItems_txt;
        private Label totalsalesmenu;
        private PictureBox topsellingmenupic;
        private Label totalordersmenu;
        private Label menulblsales;
        private Label activeorderslbl;
        private Label sysalertlbl;
        private Label pendinglbl;
        private Label lowstocklbl;
        private Label recenttransactionlbl;
    }
}