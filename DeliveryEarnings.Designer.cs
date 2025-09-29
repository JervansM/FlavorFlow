namespace FlavorFlowIT13
{
    partial class DeliveryEarnings
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
            panel3 = new Panel();
            label8 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            panel4 = new Panel();
            label2 = new Label();
            totalthisweektxt = new TextBox();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.Black;
            panel3.Controls.Add(label8);
            panel3.Location = new Point(34, 35);
            panel3.Name = "panel3";
            panel3.Size = new Size(312, 58);
            panel3.TabIndex = 55;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Black;
            label8.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(15, 13);
            label8.Name = "label8";
            label8.Size = new Size(74, 32);
            label8.TabIndex = 11;
            label8.Text = "Date:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(34, 193);
            panel1.Name = "panel1";
            panel1.Size = new Size(1303, 460);
            panel1.TabIndex = 53;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label1);
            panel2.ForeColor = Color.White;
            panel2.Location = new Point(34, 144);
            panel2.Name = "panel2";
            panel2.Size = new Size(1303, 53);
            panel2.TabIndex = 54;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Black;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(628, 10);
            label6.Name = "label6";
            label6.Size = new Size(136, 32);
            label6.TabIndex = 9;
            label6.Text = "On-time %";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Black;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(264, 10);
            label5.Name = "label5";
            label5.Size = new Size(126, 32);
            label5.TabIndex = 8;
            label5.Text = "Deliveries";
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
            label1.Location = new Point(1041, 10);
            label1.Name = "label1";
            label1.Size = new Size(113, 32);
            label1.TabIndex = 5;
            label1.Text = "Earnings";
            // 
            // panel4
            // 
            panel4.BackColor = Color.Black;
            panel4.Controls.Add(totalthisweektxt);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(439, 35);
            panel4.Name = "panel4";
            panel4.Size = new Size(451, 58);
            panel4.TabIndex = 56;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Black;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(15, 13);
            label2.Name = "label2";
            label2.Size = new Size(200, 32);
            label2.TabIndex = 11;
            label2.Text = "Total This Week:";
            // 
            // totalthisweektxt
            // 
            totalthisweektxt.Location = new Point(221, 7);
            totalthisweektxt.Multiline = true;
            totalthisweektxt.Name = "totalthisweektxt";
            totalthisweektxt.Size = new Size(224, 48);
            totalthisweektxt.TabIndex = 12;
            // 
            // DeliveryEarnings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(1370, 749);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "DeliveryEarnings";
            Text = "DeliveryEarnings";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private Label label8;
        private Panel panel1;
        private Panel panel2;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label1;
        private Panel panel4;
        private Label label2;
        private TextBox totalthisweektxt;
    }
}