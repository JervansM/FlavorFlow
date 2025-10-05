using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlavorFlowIT13
{
    public partial class StaffTableMapOrder : Form
    {
        public event Action<string> TableSelected; // event to notify StaffDashboard


        public StaffTableMapOrder()
        {
            InitializeComponent();

        }

        private void StaffTableMapOrder_Load(object sender, EventArgs e)
        {

            LoadTableStatuses();





            RoundButton(table1btn, 30);
            RoundButton(table2btn, 30);
            RoundButton(table3btn, 30);
            RoundButton(table4btn, 30);
            RoundButton(table5btn, 30);
            RoundButton(table6btn, 30);

            table1btn.UseVisualStyleBackColor = false;
            table1btn.FlatStyle = FlatStyle.Flat;
            table1btn.FlatAppearance.BorderSize = 0;
            table1btn.UseVisualStyleBackColor = false;

            table2btn.FlatStyle = FlatStyle.Flat;
            table2btn.FlatAppearance.BorderSize = 0;
            table2btn.UseVisualStyleBackColor = false;

            table3btn.FlatStyle = FlatStyle.Flat;
            table3btn.FlatAppearance.BorderSize = 0;
            table3btn.UseVisualStyleBackColor = false;

            table4btn.FlatStyle = FlatStyle.Flat;
            table4btn.FlatAppearance.BorderSize = 0;
            table4btn.UseVisualStyleBackColor = false;

            table5btn.FlatStyle = FlatStyle.Flat;
            table5btn.FlatAppearance.BorderSize = 0;
            table5btn.UseVisualStyleBackColor = false;



            table6btn.UseVisualStyleBackColor = false;
            table6btn.FlatStyle = FlatStyle.Flat;
            table6btn.FlatAppearance.BorderSize = 0;
        }
        private void RoundButton(Button button, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(button.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(button.Width - radius, button.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, button.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            button.Region = new System.Drawing.Region(path);
        }
        private void LoadContent(Form form)
        {
            foreach (Control ctrl in panelitems.Controls)
            {
                ctrl.Dispose();
            }

            panelitems.Controls.Clear();

            // Prepare the new form
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Add to panel
            panelitems.Controls.Add(form);
            form.Show();

        }
        private DataTable GetTableStatusesFromDB()
        {
            string connectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

            string query = "SELECT TableName, Status FROM Tables";

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                conn.Open();
                da.Fill(dt);
            }

            return dt;
        }

        private void LoadTableStatuses()
        {
            DataTable tableData = GetTableStatusesFromDB();

            // Map TableName in DB to actual Button names in Form
            Dictionary<string, Button> tableButtons = new Dictionary<string, Button>()
    {
        { "Table 1", table1btn },
        { "Table 2", table2btn },
        { "Table 3", table3btn },
        { "Table 4", table4btn },
        { "Table 5", table5btn },
        { "Table 6", table6btn }
    };

            foreach (DataRow row in tableData.Rows)
            {
                string tableName = row["TableName"].ToString();
                string status = row["Status"].ToString();

                if (tableButtons.ContainsKey(tableName))
                {
                    Button tableBtn = tableButtons[tableName];

                    switch (status)
                    {
                        case "Available":
                            tableBtn.BackColor = Color.Green;
                            break;
                        case "Pending":
                            tableBtn.BackColor = Color.Red;
                            break;
                        case "InProgress":
                            tableBtn.BackColor = Color.Blue;
                            break;
                        case "Unavailable":
                            tableBtn.BackColor = Color.Silver;
                            tableBtn.ForeColor = Color.Black;
                            break;
                        default:
                            tableBtn.BackColor = Color.Silver;
                            tableBtn.ForeColor = Color.Black;

                            break;
                    }
                }
            }
        }


        public void RefreshTableStatuses()
        {
            LoadTableStatuses();
        }

        private void table1btn_Click(object sender, EventArgs e)
        {
            TableSelected?.Invoke("Table 1");
        }

        private void table2btn_Click(object sender, EventArgs e)
        {
            TableSelected?.Invoke("Table 2");
        }

        private void table3btn_Click(object sender, EventArgs e)
        {
            TableSelected?.Invoke("Table 3");
        }

        private void table4btn_Click(object sender, EventArgs e)
        {
            TableSelected?.Invoke("Table 4");
        }
        private void table5btn_Click(object sender, EventArgs e)
        {
            TableSelected?.Invoke("Table 5");
        }


        private void table6btn_Click(object sender, EventArgs e)
        {
            TableSelected?.Invoke("Table 6");

        }

        
    }
}
