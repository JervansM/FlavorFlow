namespace FlavorFlowIT13
{
    partial class WebAppMyOrdersComplete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebAppMyOrdersComplete));
            panel1 = new Panel();
            webapppendingpanel = new Panel();
            panel2 = new Panel();
            webapppastordersbtn = new Button();
            webappcompletebtn = new Button();
            webappoutfordeliverybtn = new Button();
            webapppendingbtn = new Button();
            label1 = new Label();
            webapppendingpanel.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(168, 124);
            panel1.TabIndex = 5;
            // 
            // webapppendingpanel
            // 
            webapppendingpanel.BackColor = Color.White;
            webapppendingpanel.Controls.Add(panel2);
            webapppendingpanel.Controls.Add(label1);
            webapppendingpanel.ForeColor = Color.White;
            webapppendingpanel.Location = new Point(12, 144);
            webapppendingpanel.Name = "webapppendingpanel";
            webapppendingpanel.Size = new Size(1346, 593);
            webapppendingpanel.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SandyBrown;
            panel2.Controls.Add(webapppastordersbtn);
            panel2.Controls.Add(webappcompletebtn);
            panel2.Controls.Add(webappoutfordeliverybtn);
            panel2.Controls.Add(webapppendingbtn);
            panel2.Location = new Point(16, 72);
            panel2.Name = "panel2";
            panel2.Size = new Size(1318, 70);
            panel2.TabIndex = 4;
            // 
            // webapppastordersbtn
            // 
            webapppastordersbtn.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            webapppastordersbtn.ForeColor = Color.Black;
            webapppastordersbtn.Location = new Point(1006, 3);
            webapppastordersbtn.Name = "webapppastordersbtn";
            webapppastordersbtn.Size = new Size(280, 64);
            webapppastordersbtn.TabIndex = 3;
            webapppastordersbtn.Text = "Past Orders";
            webapppastordersbtn.UseVisualStyleBackColor = true;
            // 
            // webappcompletebtn
            // 
            webappcompletebtn.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            webappcompletebtn.ForeColor = Color.Black;
            webappcompletebtn.Location = new Point(670, 3);
            webappcompletebtn.Name = "webappcompletebtn";
            webappcompletebtn.Size = new Size(285, 64);
            webappcompletebtn.TabIndex = 2;
            webappcompletebtn.Text = "Complete";
            webappcompletebtn.UseVisualStyleBackColor = true;
            // 
            // webappoutfordeliverybtn
            // 
            webappoutfordeliverybtn.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            webappoutfordeliverybtn.ForeColor = Color.Black;
            webappoutfordeliverybtn.Location = new Point(345, 3);
            webappoutfordeliverybtn.Name = "webappoutfordeliverybtn";
            webappoutfordeliverybtn.Size = new Size(276, 64);
            webappoutfordeliverybtn.TabIndex = 1;
            webappoutfordeliverybtn.Text = "Out for Delivery";
            webappoutfordeliverybtn.UseVisualStyleBackColor = true;
            // 
            // webapppendingbtn
            // 
            webapppendingbtn.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            webapppendingbtn.ForeColor = Color.Black;
            webapppendingbtn.Location = new Point(37, 3);
            webapppendingbtn.Name = "webapppendingbtn";
            webapppendingbtn.Size = new Size(259, 64);
            webapppendingbtn.TabIndex = 0;
            webapppendingbtn.Text = "Pending";
            webapppendingbtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(36, 16);
            label1.Name = "label1";
            label1.Size = new Size(147, 36);
            label1.TabIndex = 3;
            label1.Text = "My Orders";
            // 
            // WebAppMyOrdersComplete
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(panel1);
            Controls.Add(webapppendingpanel);
            Name = "WebAppMyOrdersComplete";
            Text = "WebAppMyOrdersComplete";
            webapppendingpanel.ResumeLayout(false);
            webapppendingpanel.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel webapppendingpanel;
        private Panel panel2;
        private Button webapppastordersbtn;
        private Button webappcompletebtn;
        private Button webappoutfordeliverybtn;
        private Button webapppendingbtn;
        private Label label1;
    }
}