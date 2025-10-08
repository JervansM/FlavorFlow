namespace FlavorFlowIT13
{
    partial class HrPolicies
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelPolicies = new FlowLayoutPanel();
            btnAddPolicy = new Button();
            SuspendLayout();
            // 
            // panelPolicies
            // 
            panelPolicies.AutoScroll = true;
            panelPolicies.BackColor = Color.White;
            panelPolicies.BorderStyle = BorderStyle.FixedSingle;
            panelPolicies.FlowDirection = FlowDirection.TopDown;
            panelPolicies.Location = new Point(40, 26);
            panelPolicies.Name = "panelPolicies";
            panelPolicies.Size = new Size(1327, 580);
            panelPolicies.TabIndex = 0;
            panelPolicies.WrapContents = false;
            // 
            // btnAddPolicy
            // 
            btnAddPolicy.BackColor = Color.FromArgb(255, 128, 0);
            btnAddPolicy.FlatStyle = FlatStyle.Flat;
            btnAddPolicy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddPolicy.ForeColor = Color.White;
            btnAddPolicy.Location = new Point(566, 630);
            btnAddPolicy.Name = "btnAddPolicy";
            btnAddPolicy.Size = new Size(180, 40);
            btnAddPolicy.TabIndex = 1;
            btnAddPolicy.Text = "Add New Policy";
            btnAddPolicy.UseVisualStyleBackColor = false;
            btnAddPolicy.Click += btnAddPolicy_Click;
            // 
            // HrPolicies
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1410, 720);
            Controls.Add(panelPolicies);
            Controls.Add(btnAddPolicy);
            FormBorderStyle = FormBorderStyle.None;
            Name = "HrPolicies";
            Text = "HrPolicies";
            Load += HrPolicies_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelPolicies;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Button btnAddPolicy;
    }
}
