namespace FlavorFlowIT13
{
    partial class WebAppMyOrdersPending
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebAppMyOrdersPending));
            panel1 = new Panel();
            webapppendingpanel = new Panel();
            panel3 = new Panel();
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
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(199, 155);
            panel1.TabIndex = 5;
            // 
            // webapppendingpanel
            // 
            webapppendingpanel.BackColor = Color.White;
            webapppendingpanel.Controls.Add(panel3);
            webapppendingpanel.Controls.Add(panel1);
            webapppendingpanel.Controls.Add(panel2);
            webapppendingpanel.Controls.Add(label1);
            webapppendingpanel.ForeColor = Color.White;
            webapppendingpanel.Location = new Point(-2, 0);
            webapppendingpanel.Name = "webapppendingpanel";
            webapppendingpanel.Size = new Size(1926, 1055);
            webapppendingpanel.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Silver;
            panel3.Location = new Point(52, 290);
            panel3.Name = "panel3";
            panel3.Size = new Size(1797, 701);
            panel3.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 192, 128);
            panel2.Controls.Add(webapppastordersbtn);
            panel2.Controls.Add(webappcompletebtn);
            panel2.Controls.Add(webappoutfordeliverybtn);
            panel2.Controls.Add(webapppendingbtn);
            panel2.Location = new Point(51, 164);
            panel2.Name = "panel2";
            panel2.Size = new Size(1798, 101);
            panel2.TabIndex = 4;
            // 
            // webapppastordersbtn
            // 
            webapppastordersbtn.Font = new Font("Lucida Bright", 21.75F, FontStyle.Bold);
            webapppastordersbtn.ForeColor = Color.Black;
            webapppastordersbtn.Location = new Point(1376, 20);
            webapppastordersbtn.Name = "webapppastordersbtn";
            webapppastordersbtn.Size = new Size(345, 72);
            webapppastordersbtn.TabIndex = 3;
            webapppastordersbtn.Text = "Past Orders";
            webapppastordersbtn.UseVisualStyleBackColor = true;
            webapppastordersbtn.Click += webapppastordersbtn_Click;
            // 
            // webappcompletebtn
            // 
            webappcompletebtn.Font = new Font("Lucida Bright", 21.75F, FontStyle.Bold);
            webappcompletebtn.ForeColor = Color.Black;
            webappcompletebtn.Location = new Point(956, 20);
            webappcompletebtn.Name = "webappcompletebtn";
            webappcompletebtn.Size = new Size(345, 72);
            webappcompletebtn.TabIndex = 2;
            webappcompletebtn.Text = "Complete";
            webappcompletebtn.UseVisualStyleBackColor = true;
            webappcompletebtn.Click += webappcompletebtn_Click;
            // 
            // webappoutfordeliverybtn
            // 
            webappoutfordeliverybtn.Font = new Font("Lucida Bright", 21.75F, FontStyle.Bold);
            webappoutfordeliverybtn.ForeColor = Color.Black;
            webappoutfordeliverybtn.Location = new Point(522, 20);
            webappoutfordeliverybtn.Name = "webappoutfordeliverybtn";
            webappoutfordeliverybtn.Size = new Size(345, 72);
            webappoutfordeliverybtn.TabIndex = 1;
            webappoutfordeliverybtn.Text = "Out for Delivery";
            webappoutfordeliverybtn.UseVisualStyleBackColor = true;
            webappoutfordeliverybtn.Click += webappoutfordeliverybtn_Click;
            // 
            // webapppendingbtn
            // 
            webapppendingbtn.Font = new Font("Lucida Bright", 21.75F, FontStyle.Bold);
            webapppendingbtn.ForeColor = Color.Black;
            webapppendingbtn.Location = new Point(60, 20);
            webapppendingbtn.Name = "webapppendingbtn";
            webapppendingbtn.Size = new Size(345, 72);
            webapppendingbtn.TabIndex = 0;
            webapppendingbtn.Text = "Pending";
            webapppendingbtn.UseVisualStyleBackColor = true;
            webapppendingbtn.Click += webapppendingbtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 48F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(769, 19);
            label1.Name = "label1";
            label1.Size = new Size(352, 86);
            label1.TabIndex = 3;
            label1.Text = "My Orders";
            // 
            // WebAppMyOrdersPending
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1061);
            Controls.Add(webapppendingpanel);
            Name = "WebAppMyOrdersPending";
            Text = "WebAppMyOrdersPending";
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
        private Panel panel3;
    }
}