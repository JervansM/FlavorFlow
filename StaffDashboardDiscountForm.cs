using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlavorFlowIT13
{
    public partial class StaffDashboardDiscountForm : Form
    {

        private const decimal DiscountRate = 0.20m; // 20% discount rate
        private readonly string localConnectionString =
                  "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        // ✅ Cloud connection
        private readonly string cloudConnectionString =
            "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        // ✅ Active connection string
        private string connectionString;
        private CancellationTokenSource typingCts; // for debounce typing

        public StaffDashboardDiscountForm()
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

        private void StaffDashboardDiscountForm_Load(object sender, EventArgs e)
        {
            RoundButton(discountclosebtn, 19);
            RoundButton(discountregisterbn, 19);

            discountclosebtn.UseVisualStyleBackColor = false;
            discountclosebtn.FlatStyle = FlatStyle.Flat;
            discountclosebtn.FlatAppearance.BorderSize = 0;
            discountclosebtn.BackColor = ColorTranslator.FromHtml("Silver");
            discountclosebtn.ForeColor = Color.White;

            discountregisterbn.UseVisualStyleBackColor = false;
            discountregisterbn.FlatStyle = FlatStyle.Flat;
            discountregisterbn.FlatAppearance.BorderSize = 0;
            discountregisterbn.BackColor = ColorTranslator.FromHtml("Coral");
            discountregisterbn.ForeColor = Color.White;


            discountpercentagetxt.Text = (DiscountRate * 100).ToString() + "%";
            if (Properties.Resources.check_removebg_preview == null)
                MessageBox.Show("Check image resource!");
        }


        private void discountregisterbn_Click(object sender, EventArgs e)
        {
            var addForm = new StaffDashboardDiscountFormAdd();
            addForm.Show();
        }

        private void discountclosebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ===================== CARD VALIDATION =====================
        private async void discountcardnumbertxt_TextChanged(object sender, EventArgs e)
        {
            // cancel previous typing if user continues typing
            typingCts?.Cancel();
            typingCts = new CancellationTokenSource();
            var token = typingCts.Token;

            try
            {
                await Task.Delay(500, token); // debounce delay
                bool? isActive = await IsCardActiveAsync(discountcardnumbertxt.Text.Trim());
                UpdateCardStatusImage(isActive);
            }
            catch (TaskCanceledException) { }
        }

        private async Task<bool?> IsCardActiveAsync(string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
                return null; // treat empty as invalid

            try
            {
                await using SqlConnection conn = new SqlConnection(connectionString);
                await conn.OpenAsync();

                await using SqlCommand cmd = new SqlCommand(
                    "SELECT Status FROM DiscountCards WHERE CardNumber = @CardNumber", conn);
                cmd.Parameters.AddWithValue("@CardNumber", cardNumber);

                object result = await cmd.ExecuteScalarAsync();

                if (result == null)
                {
                    return null; // card not found → ❌
                }

                return Convert.ToBoolean(result); 
            }
            catch
            {
                return null; // in case of DB error
            }
        }

        private void UpdateCardStatusImage(bool? isActive)
        {
            if (cardStatuspic.Image != null)
                cardStatuspic.Image.Dispose();

            cardStatuspic.Image = isActive == true
                ? Properties.Resources.check_removebg_preview      
                : isActive == false
                    ? Properties.Resources.blocked_removebg_preview  
                    : Properties.Resources.x_removebg_preview;      

            cardStatuspic.SizeMode = PictureBoxSizeMode.Zoom;
            cardStatuspic.Invalidate();
        }


        private void cardStatuspic_Click(object sender, EventArgs e)
        {
            // manual validation on click
            discountcardnumbertxt_TextChanged(sender, e);
        }

        // DISCOUNT CALCULATION
        private void discountpersoncounttxt_TextChanged(object sender, EventArgs e) => CalculateDiscount();
        private void discountpercentagetxt_TextChanged(object sender, EventArgs e) => CalculateDiscount();
        private void discountsumamounttxt_TextChanged(object sender, EventArgs e) => CalculateDiscount();
        private void discountnetamounttxt_TextChanged(object sender, EventArgs e) => CalculateDiscount();

        private void CalculateDiscount()
        {
            if (decimal.TryParse(discountnetamounttxt.Text, out decimal netAmount) &&
                int.TryParse(discountpersoncounttxt.Text, out int personCount) &&
                personCount > 0)
            {
                decimal totalDiscount = netAmount * DiscountRate;
                decimal discountPerPerson = totalDiscount / personCount;
                decimal fixedAmount = netAmount - discountPerPerson;

                discountsumamounttxt.Text = discountPerPerson.ToString("0.00");
            }
            else
            {
                discountsumamounttxt.Text = "0.00";
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
