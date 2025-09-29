namespace FlavorFlowIT13
{
    partial class WebAppMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebAppMenu));
            panel2 = new Panel();
            panel1 = new Panel();
            panel3 = new Panel();
            userwelcome = new Label();
            adminicon = new PictureBox();
            systemsearchbar = new TextBox();
            panel4 = new Panel();
            desserts = new Button();
            beveragesbtn = new Button();
            maincoursebtn = new Button();
            appetizersbtn = new Button();
            allitemsbtn = new Button();
            panel5 = new Panel();
            panel6 = new Panel();
            button1 = new Button();
            label1 = new Label();
            panel7 = new Panel();
            ((System.ComponentModel.ISupportInitialize)adminicon).BeginInit();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Zoom;
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(168, 124);
            panel2.TabIndex = 10;
            panel2.Paint += panel2_Paint;
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.Location = new Point(1155, 29);
            panel1.Name = "panel1";
            panel1.Size = new Size(69, 70);
            panel1.TabIndex = 43;
            // 
            // panel3
            // 
            panel3.BackgroundImage = (Image)resources.GetObject("panel3.BackgroundImage");
            panel3.BackgroundImageLayout = ImageLayout.Zoom;
            panel3.Location = new Point(1258, 29);
            panel3.Name = "panel3";
            panel3.Size = new Size(81, 70);
            panel3.TabIndex = 44;
            // 
            // userwelcome
            // 
            userwelcome.AutoSize = true;
            userwelcome.BackColor = Color.Transparent;
            userwelcome.FlatStyle = FlatStyle.Flat;
            userwelcome.Font = new Font("Segoe UI", 24.25F, FontStyle.Bold);
            userwelcome.ForeColor = Color.Coral;
            userwelcome.Location = new Point(196, 29);
            userwelcome.Name = "userwelcome";
            userwelcome.Size = new Size(181, 90);
            userwelcome.TabIndex = 41;
            userwelcome.Text = "Welcome, \r\nCustomer";
            // 
            // adminicon
            // 
            adminicon.BackColor = Color.Transparent;
            adminicon.BackgroundImageLayout = ImageLayout.None;
            adminicon.Image = (Image)resources.GetObject("adminicon.Image");
            adminicon.Location = new Point(374, 29);
            adminicon.Name = "adminicon";
            adminicon.Size = new Size(84, 90);
            adminicon.SizeMode = PictureBoxSizeMode.Zoom;
            adminicon.TabIndex = 42;
            adminicon.TabStop = false;
            // 
            // systemsearchbar
            // 
            systemsearchbar.Anchor = AnchorStyles.None;
            systemsearchbar.BorderStyle = BorderStyle.None;
            systemsearchbar.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            systemsearchbar.ForeColor = Color.Black;
            systemsearchbar.Location = new Point(501, 52);
            systemsearchbar.Multiline = true;
            systemsearchbar.Name = "systemsearchbar";
            systemsearchbar.PlaceholderText = "Search";
            systemsearchbar.Size = new Size(533, 67);
            systemsearchbar.TabIndex = 40;
            systemsearchbar.Text = "   Search";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(255, 192, 128);
            panel4.Controls.Add(desserts);
            panel4.Controls.Add(beveragesbtn);
            panel4.Controls.Add(maincoursebtn);
            panel4.Controls.Add(appetizersbtn);
            panel4.Controls.Add(allitemsbtn);
            panel4.Location = new Point(40, 181);
            panel4.Name = "panel4";
            panel4.Size = new Size(1299, 86);
            panel4.TabIndex = 45;
            // 
            // desserts
            // 
            desserts.Font = new Font("Lucida Bright", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            desserts.Location = new Point(1060, 12);
            desserts.Name = "desserts";
            desserts.Size = new Size(206, 58);
            desserts.TabIndex = 4;
            desserts.Text = "Desserts";
            desserts.UseVisualStyleBackColor = true;
            // 
            // beveragesbtn
            // 
            beveragesbtn.Font = new Font("Lucida Bright", 18F, FontStyle.Bold);
            beveragesbtn.Location = new Point(808, 12);
            beveragesbtn.Name = "beveragesbtn";
            beveragesbtn.Size = new Size(206, 58);
            beveragesbtn.TabIndex = 3;
            beveragesbtn.Text = "Beverages";
            beveragesbtn.UseVisualStyleBackColor = true;
            // 
            // maincoursebtn
            // 
            maincoursebtn.Font = new Font("Lucida Bright", 18F, FontStyle.Bold);
            maincoursebtn.Location = new Point(554, 12);
            maincoursebtn.Name = "maincoursebtn";
            maincoursebtn.Size = new Size(206, 58);
            maincoursebtn.TabIndex = 2;
            maincoursebtn.Text = "Main Course";
            maincoursebtn.UseVisualStyleBackColor = true;
            // 
            // appetizersbtn
            // 
            appetizersbtn.Font = new Font("Lucida Bright", 18F, FontStyle.Bold);
            appetizersbtn.Location = new Point(291, 12);
            appetizersbtn.Name = "appetizersbtn";
            appetizersbtn.Size = new Size(206, 58);
            appetizersbtn.TabIndex = 1;
            appetizersbtn.Text = "Appetizers";
            appetizersbtn.UseVisualStyleBackColor = true;
            // 
            // allitemsbtn
            // 
            allitemsbtn.Font = new Font("Lucida Bright", 18F, FontStyle.Bold);
            allitemsbtn.Location = new Point(33, 12);
            allitemsbtn.Name = "allitemsbtn";
            allitemsbtn.Size = new Size(206, 58);
            allitemsbtn.TabIndex = 0;
            allitemsbtn.Text = "All Items";
            allitemsbtn.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Location = new Point(40, 273);
            panel5.Name = "panel5";
            panel5.Size = new Size(770, 464);
            panel5.TabIndex = 46;
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(button1);
            panel6.Controls.Add(label1);
            panel6.Controls.Add(panel7);
            panel6.Location = new Point(848, 273);
            panel6.Name = "panel6";
            panel6.Size = new Size(491, 464);
            panel6.TabIndex = 47;
            // 
            // button1
            // 
            button1.BackColor = Color.LimeGreen;
            button1.Font = new Font("Lucida Bright", 14.25F, FontStyle.Bold);
            button1.Location = new Point(116, 394);
            button1.Name = "button1";
            button1.Size = new Size(260, 52);
            button1.TabIndex = 47;
            button1.Text = "Place Delivery Order";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Bright", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(212, 16);
            label1.Name = "label1";
            label1.Size = new Size(130, 22);
            label1.TabIndex = 46;
            label1.Text = "Your Orders";
            // 
            // panel7
            // 
            panel7.BackgroundImage = (Image)resources.GetObject("panel7.BackgroundImage");
            panel7.BackgroundImageLayout = ImageLayout.Zoom;
            panel7.Location = new Point(147, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(59, 46);
            panel7.TabIndex = 45;
            // 
            // WebAppMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(adminicon);
            Controls.Add(userwelcome);
            Controls.Add(systemsearchbar);
            Controls.Add(panel2);
            Name = "WebAppMenu";
            Text = "WebAppMenu";
            Load += WebAppMenu_Load;
            ((System.ComponentModel.ISupportInitialize)adminicon).EndInit();
            panel4.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel2;
        private Panel panel1;
        private Panel panel3;
        private Label userwelcome;
        private PictureBox adminicon;
        private TextBox systemsearchbar;
        private Panel panel4;
        private Button desserts;
        private Button beveragesbtn;
        private Button maincoursebtn;
        private Button appetizersbtn;
        private Button allitemsbtn;
        private Panel panel5;
        private Panel panel6;
        private Label label1;
        private Panel panel7;
        private Button button1;
    }
}