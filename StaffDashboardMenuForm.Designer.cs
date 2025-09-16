namespace FlavorFlowIT13
{
    partial class StaffDashboardMenuForm
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
            flowLayoutMenuCard = new FlowLayoutPanel();
            panelContent = new Panel();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutMenuCard
            // 
            flowLayoutMenuCard.AutoScroll = true;
            flowLayoutMenuCard.Location = new Point(36, 12);
            flowLayoutMenuCard.Name = "flowLayoutMenuCard";
            flowLayoutMenuCard.Size = new Size(964, 937);
            flowLayoutMenuCard.TabIndex = 1;
            flowLayoutMenuCard.Paint += flowLayoutMenuCard_Paint;
            // 
            // panelContent
            // 
            panelContent.AutoScroll = true;
            panelContent.BackColor = Color.White;
            panelContent.Controls.Add(flowLayoutMenuCard);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1026, 961);
            panelContent.TabIndex = 27;
            panelContent.Paint += panelContent_Paint;
            // 
            // StaffDashboardMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1026, 961);
            Controls.Add(panelContent);
            Name = "StaffDashboardMenuForm";
            Text = "StaffDashboardMenuForm";
            Load += StaffDashboardMenuForm_Load;
            panelContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutMenuCard;
        private Panel panelContent;
    }
}