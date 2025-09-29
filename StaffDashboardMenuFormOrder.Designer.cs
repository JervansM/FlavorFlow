namespace FlavorFlowIT13
{
    partial class StaffDashboardMenuFormOrder
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
            menusearchbarpanel = new Panel();
            systemsearchbaricon = new PictureBox();
            menusearchbar = new TextBox();
            flowLayoutMenuCard = new FlowLayoutPanel();
            panelContent.SuspendLayout();
            menusearchbarpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)systemsearchbaricon).BeginInit();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.AutoScroll = true;
            panelContent.BackColor = Color.White;
            panelContent.Controls.Add(menusearchbarpanel);
            panelContent.Controls.Add(flowLayoutMenuCard);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1924, 849);
            panelContent.TabIndex = 28;
            panelContent.Paint += panelContent_Paint;
            // 
            // menusearchbarpanel
            // 
            menusearchbarpanel.BackColor = Color.White;
            menusearchbarpanel.BorderStyle = BorderStyle.FixedSingle;
            menusearchbarpanel.Controls.Add(systemsearchbaricon);
            menusearchbarpanel.Controls.Add(menusearchbar);
            menusearchbarpanel.Location = new Point(26, 15);
            menusearchbarpanel.Name = "menusearchbarpanel";
            menusearchbarpanel.Size = new Size(922, 59);
            menusearchbarpanel.TabIndex = 25;
            menusearchbarpanel.Paint += menusearchbarpanel_Paint;
            // 
            // systemsearchbaricon
            // 
            systemsearchbaricon.BackColor = Color.Transparent;
            systemsearchbaricon.BackgroundImageLayout = ImageLayout.None;
            systemsearchbaricon.Image = Properties.Resources.searchbar_removebg_preview;
            systemsearchbaricon.Location = new Point(828, 7);
            systemsearchbaricon.Name = "systemsearchbaricon";
            systemsearchbaricon.Size = new Size(81, 46);
            systemsearchbaricon.SizeMode = PictureBoxSizeMode.Zoom;
            systemsearchbaricon.TabIndex = 23;
            systemsearchbaricon.TabStop = false;
            // 
            // menusearchbar
            // 
            menusearchbar.Anchor = AnchorStyles.None;
            menusearchbar.BorderStyle = BorderStyle.None;
            menusearchbar.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menusearchbar.ForeColor = Color.Black;
            menusearchbar.Location = new Point(7, 6);
            menusearchbar.Multiline = true;
            menusearchbar.Name = "menusearchbar";
            menusearchbar.PlaceholderText = "Search";
            menusearchbar.Size = new Size(914, 47);
            menusearchbar.TabIndex = 22;
            menusearchbar.TextChanged += menusearchbar_TextChanged;
            // 
            // flowLayoutMenuCard
            // 
            flowLayoutMenuCard.Location = new Point(35, 80);
            flowLayoutMenuCard.Name = "flowLayoutMenuCard";
            flowLayoutMenuCard.Size = new Size(936, 1500);
            flowLayoutMenuCard.TabIndex = 1;
            flowLayoutMenuCard.Paint += flowLayoutMenuCard_Paint;
            // 
            // StaffDashboardMenuFormOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 849);
            Controls.Add(panelContent);
            Name = "StaffDashboardMenuFormOrder";
            Text = "StaffDashboardMenuFormOrder";
            Load += StaffDashboardMenuFormOrder_Load;
            panelContent.ResumeLayout(false);
            menusearchbarpanel.ResumeLayout(false);
            menusearchbarpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)systemsearchbaricon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContent;
        private FlowLayoutPanel flowLayoutMenuCard;
        private Panel menusearchbarpanel;
        private PictureBox systemsearchbaricon;
        private TextBox menusearchbar;
    }
}