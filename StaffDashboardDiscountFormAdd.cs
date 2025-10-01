using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; 


namespace FlavorFlowIT13
{
    public partial class StaffDashboardDiscountFormAdd : Form
    {
        // ✅ Local connection
        private readonly string localConnectionString =
            "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        // ✅ Cloud connection
        private readonly string cloudConnectionString =
            "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        // ✅ Active connection
        private string connectionString;
        public StaffDashboardDiscountFormAdd()
        {
            InitializeComponent();

            if (CanConnect(cloudConnectionString))
            {
                connectionString = cloudConnectionString;
                Console.WriteLine("✅ Using Cloud Database");
            }
            else
            {
                connectionString = localConnectionString;
                Console.WriteLine("⚡ Using Local Database (cloud not reachable)");
            }
        }
        private bool CanConnect(string connStr)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void StaffDashboardDiscountFormAdd_Load(object sender, EventArgs e)
        {
            RoundButton(discountclosebtn, 19);
            RoundButton(discountreregistercardbtn, 19);

            discountclosebtn.UseVisualStyleBackColor = false;
            discountclosebtn.FlatStyle = FlatStyle.Flat;
            discountclosebtn.FlatAppearance.BorderSize = 0;
            discountclosebtn.BackColor = ColorTranslator.FromHtml("Silver");
            discountclosebtn.ForeColor = Color.White;

            discountreregistercardbtn.UseVisualStyleBackColor = false;
            discountreregistercardbtn.FlatStyle = FlatStyle.Flat;
            discountreregistercardbtn.FlatAppearance.BorderSize = 0;
            discountreregistercardbtn.BackColor = ColorTranslator.FromHtml("LimeGreen");
            discountreregistercardbtn.ForeColor = Color.White;
        }

        private void discountmiddlenamelbl_Click(object sender, EventArgs e)
        {

        }

        private void discountclosebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cardtypetxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cardtypetxt.SelectedItem == null)
                return;

            string selectedType = cardtypetxt.SelectedItem.ToString();

            switch (selectedType)
            {
                 


                case "PWD":
                break;
            case "SENIOR":
                break;
            case "PREGNANT":
                break;
            default:
                break;
            } 
            

        }

        private void discountcardnumbertxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void discountlastnametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void discountfirstnametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void discountmiddlenametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void discountcardstatus_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void discountreregistercardbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Collect inputs safely
                string cardType = cardtypetxt.SelectedItem != null ? cardtypetxt.SelectedItem.ToString() : "";
                string cardNumber = discountcardnumbertxt.Text.Trim();
                string lastName = discountlastnametxt.Text.Trim();
                string firstName = discountfirstnametxt.Text.Trim();
                string middleName = discountmiddlenametxt.Text.Trim();
                DateTime dateRegistered = DateTime.Now;

                bool status = discountcardstatus.Checked;

                // 2. Validate inputs
                if (string.IsNullOrEmpty(cardType) || string.IsNullOrEmpty(cardNumber) ||
                    string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(firstName))
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // 3. Check if CardNumber already exists
                    string checkQuery = "SELECT COUNT(*) FROM DiscountCards WHERE CardNumber = @CardNumber";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@CardNumber", cardNumber);
                        int exists = (int)checkCmd.ExecuteScalar();

                        if (exists > 0)
                        {
                            MessageBox.Show("Card already exists!", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // stop here
                        }
                    }

                    // 4. Insert into DB
                    string query = @"INSERT INTO DiscountCards (CardType, CardNumber, LastName, FirstName, MiddleName, DateRegistered, Status)
                             VALUES (@CardType, @CardNumber, @LastName, @FirstName, @MiddleName, @DateRegistered, @Status)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@CardType", cardType);
                        cmd.Parameters.AddWithValue("@CardNumber", cardNumber);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@MiddleName", middleName);
                        cmd.Parameters.AddWithValue("@DateRegistered", dateRegistered);
                        cmd.Parameters.AddWithValue("@Status", status ? 1 : 0);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Discount card registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 5. Clear inputs after success
                cardtypetxt.SelectedIndex = -1;
                discountcardnumbertxt.Clear();
                discountlastnametxt.Clear();
                discountfirstnametxt.Clear();
                discountmiddlenametxt.Clear();
                discountcardstatus.Checked = true; // reset to Active
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Database error: " + sqlEx.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException nullEx)
            {
                MessageBox.Show("Missing required value: " + nullEx.Message, "Null Reference Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException formatEx)
            {
                MessageBox.Show("Invalid number format. Please enter a valid Card Number.\n\nDetails: " + formatEx.Message, "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }

}
