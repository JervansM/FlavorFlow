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
            flowLayoutMenuCard = new FlowLayoutPanel();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.AutoScroll = true;
            panelContent.AutoSize = true;
            panelContent.BackColor = Color.White;
            panelContent.Controls.Add(flowLayoutMenuCard);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1924, 1061);
            panelContent.TabIndex = 28;
            panelContent.Paint += panelContent_Paint;
            // 
            // flowLayoutMenuCard
            // 
            flowLayoutMenuCard.AutoScroll = true;
            flowLayoutMenuCard.Dock = DockStyle.Fill;
            flowLayoutMenuCard.Location = new Point(0, 0);
            flowLayoutMenuCard.Name = "flowLayoutMenuCard";
            flowLayoutMenuCard.Size = new Size(1924, 1061);
            flowLayoutMenuCard.TabIndex = 1;
            flowLayoutMenuCard.Paint += flowLayoutMenuCard_Paint;
            // 
            // StaffDashboardMenuFormOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            ClientSize = new Size(1924, 1061);
            Controls.Add(panelContent);
            Name = "StaffDashboardMenuFormOrder";
            Text = "StaffDashboardMenuFormOrder";
            Load += StaffDashboardMenuFormOrder_Load;
            panelContent.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelContent;
        private FlowLayoutPanel flowLayoutMenuCard;
    }
}