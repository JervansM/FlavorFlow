namespace FlavorFlowIT13
{
    partial class PurchaseOrder
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
            viewpendingorderbtn = new Button();
            createneworderbtn = new Button();
            receivedordersbtn = new Button();
            markasreceivedbtn = new Button();
            printpobtn = new Button();
            cancelorderbtn = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(receivedordersbtn);
            panel1.Controls.Add(viewpendingorderbtn);
            panel1.Controls.Add(createneworderbtn);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1567, 932);
            panel1.TabIndex = 0;
            // 
            // viewpendingorderbtn
            // 
            viewpendingorderbtn.BackColor = Color.Black;
            viewpendingorderbtn.Cursor = Cursors.Hand;
            viewpendingorderbtn.FlatStyle = FlatStyle.Popup;
            viewpendingorderbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            viewpendingorderbtn.ForeColor = Color.Honeydew;
            viewpendingorderbtn.Location = new Point(385, 36);
            viewpendingorderbtn.Name = "viewpendingorderbtn";
            viewpendingorderbtn.Size = new Size(270, 62);
            viewpendingorderbtn.TabIndex = 53;
            viewpendingorderbtn.Text = "View Pending Order";
            viewpendingorderbtn.UseVisualStyleBackColor = false;
            // 
            // createneworderbtn
            // 
            createneworderbtn.BackColor = Color.Black;
            createneworderbtn.Cursor = Cursors.Hand;
            createneworderbtn.FlatStyle = FlatStyle.Popup;
            createneworderbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            createneworderbtn.ForeColor = Color.Honeydew;
            createneworderbtn.Location = new Point(55, 36);
            createneworderbtn.Name = "createneworderbtn";
            createneworderbtn.Size = new Size(270, 62);
            createneworderbtn.TabIndex = 54;
            createneworderbtn.Text = "Create New Order";
            createneworderbtn.UseVisualStyleBackColor = false;
            // 
            // receivedordersbtn
            // 
            receivedordersbtn.BackColor = Color.Black;
            receivedordersbtn.Cursor = Cursors.Hand;
            receivedordersbtn.FlatStyle = FlatStyle.Popup;
            receivedordersbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            receivedordersbtn.ForeColor = Color.Honeydew;
            receivedordersbtn.Location = new Point(715, 36);
            receivedordersbtn.Name = "receivedordersbtn";
            receivedordersbtn.Size = new Size(270, 62);
            receivedordersbtn.TabIndex = 53;
            receivedordersbtn.Text = "Received Orders";
            receivedordersbtn.UseVisualStyleBackColor = false;
            // 
            // markasreceivedbtn
            // 
            markasreceivedbtn.BackColor = Color.Black;
            markasreceivedbtn.Cursor = Cursors.Hand;
            markasreceivedbtn.FlatStyle = FlatStyle.Popup;
            markasreceivedbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            markasreceivedbtn.ForeColor = Color.Honeydew;
            markasreceivedbtn.Location = new Point(236, 965);
            markasreceivedbtn.Name = "markasreceivedbtn";
            markasreceivedbtn.Size = new Size(270, 62);
            markasreceivedbtn.TabIndex = 53;
            markasreceivedbtn.Text = "Mark as Received";
            markasreceivedbtn.UseVisualStyleBackColor = false;
            // 
            // printpobtn
            // 
            printpobtn.BackColor = Color.Black;
            printpobtn.Cursor = Cursors.Hand;
            printpobtn.FlatStyle = FlatStyle.Popup;
            printpobtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            printpobtn.ForeColor = Color.Honeydew;
            printpobtn.Location = new Point(582, 965);
            printpobtn.Name = "printpobtn";
            printpobtn.Size = new Size(270, 62);
            printpobtn.TabIndex = 54;
            printpobtn.Text = "Print PO";
            printpobtn.UseVisualStyleBackColor = false;
            // 
            // cancelorderbtn
            // 
            cancelorderbtn.BackColor = Color.Black;
            cancelorderbtn.Cursor = Cursors.Hand;
            cancelorderbtn.FlatStyle = FlatStyle.Popup;
            cancelorderbtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            cancelorderbtn.ForeColor = Color.Honeydew;
            cancelorderbtn.Location = new Point(943, 965);
            cancelorderbtn.Name = "cancelorderbtn";
            cancelorderbtn.Size = new Size(270, 62);
            cancelorderbtn.TabIndex = 55;
            cancelorderbtn.Text = "Cancel Order";
            cancelorderbtn.UseVisualStyleBackColor = false;
            // 
            // PurchaseOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1409, 1061);
            Controls.Add(cancelorderbtn);
            Controls.Add(printpobtn);
            Controls.Add(markasreceivedbtn);
            Controls.Add(panel1);
            Name = "PurchaseOrder";
            Text = "PurchaseOrder";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button receivedordersbtn;
        private Button viewpendingorderbtn;
        private Button createneworderbtn;
        private Button markasreceivedbtn;
        private Button printpobtn;
        private Button cancelorderbtn;
    }
}