namespace FlavorFlowIT13
{
    partial class DeliveryIssues
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
            panel1 = new Panel();
            panel2 = new Panel();
            label3 = new Label();
            label2 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            deliveryisuuesreportnewissuetxt = new Button();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(28, 166);
            panel1.Name = "panel1";
            panel1.Size = new Size(1303, 460);
            panel1.TabIndex = 56;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label1);
            panel2.ForeColor = Color.White;
            panel2.Location = new Point(28, 117);
            panel2.Name = "panel2";
            panel2.Size = new Size(1303, 53);
            panel2.TabIndex = 57;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Black;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(1169, 10);
            label3.Name = "label3";
            label3.Size = new Size(67, 32);
            label3.TabIndex = 11;
            label3.Text = "Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Black;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(949, 10);
            label2.Name = "label2";
            label2.Size = new Size(83, 32);
            label2.TabIndex = 10;
            label2.Text = "Status";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Black;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(467, 10);
            label6.Name = "label6";
            label6.Size = new Size(96, 32);
            label6.TabIndex = 9;
            label6.Text = "Reason";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Black;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(212, 10);
            label5.Name = "label5";
            label5.Size = new Size(106, 32);
            label5.TabIndex = 8;
            label5.Text = "OrderID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Black;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(42, 10);
            label4.Name = "label4";
            label4.Size = new Size(28, 32);
            label4.TabIndex = 4;
            label4.Text = "#";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(724, 10);
            label1.Name = "label1";
            label1.Size = new Size(81, 32);
            label1.TabIndex = 5;
            label1.Text = "Notes";
            // 
            // deliveryisuuesreportnewissuetxt
            // 
            deliveryisuuesreportnewissuetxt.BackColor = Color.DarkRed;
            deliveryisuuesreportnewissuetxt.BackgroundImageLayout = ImageLayout.None;
            deliveryisuuesreportnewissuetxt.Cursor = Cursors.Hand;
            deliveryisuuesreportnewissuetxt.FlatStyle = FlatStyle.Flat;
            deliveryisuuesreportnewissuetxt.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deliveryisuuesreportnewissuetxt.ForeColor = Color.White;
            deliveryisuuesreportnewissuetxt.Location = new Point(28, 29);
            deliveryisuuesreportnewissuetxt.Name = "deliveryisuuesreportnewissuetxt";
            deliveryisuuesreportnewissuetxt.Size = new Size(309, 58);
            deliveryisuuesreportnewissuetxt.TabIndex = 58;
            deliveryisuuesreportnewissuetxt.Text = " Report New Issue ";
            deliveryisuuesreportnewissuetxt.UseVisualStyleBackColor = false;
            // 
            // DeliveryIssues
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(deliveryisuuesreportnewissuetxt);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "DeliveryIssues";
            Text = "DeliveryIssues";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label1;
        private Label label3;
        private Label label2;
        private Button deliveryisuuesreportnewissuetxt;
    }
}