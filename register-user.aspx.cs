using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.ServiceModel.Configuration;

public partial class register_user : System.Web.UI.Page
{
    string connectionString = "Data Source=AMSBH04\\SQLEXPRESS;Initial Catalog=bank;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            accountNo.Text = AccountNumber().ToString();
        }
    }
    protected int AccountNumber()
    {
        int randomNumber;
        bool isValid;

        do
        {
            randomNumber = GenerateAccountNumber();
            isValid = checkAccountNumber(randomNumber);
        } while (isValid);
        return randomNumber;
    }
    protected int GenerateAccountNumber()
    {
        Random random = new Random();

        int randomNumber = random.Next(1, 10000);
        string lastFourDigit = String.Format("{0:D4}", randomNumber);
        string a = DateTime.Now.ToString("yyyy") + lastFourDigit;
        int accountNo = Int32.Parse(a);

        return accountNo;
    }
    protected bool checkAccountNumber(int number)
    {
        string query = "SELECT COUNT(*) FROM [customerDetails] WHERE customerAccount = @accountNo";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@accountNo", number);
        con.Open();
        int count = (int)cmd.ExecuteScalar();
        con.Close();

        if (count > 0)
        {
            return true;
        }
        return false;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/adminHome.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string query = "INSERT INTO [customerDetails] (customerName, customerAccount, customerBalance, status, email, loginAttempt) VALUES (@firstName, @accountNo, @balance, @status, @email, @attempt)";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@accountNo", accountNo.Text);
        cmd.Parameters.AddWithValue("@firstName", firstName.Text);
        cmd.Parameters.AddWithValue("@balance", Int32.Parse(balance.Text));
        cmd.Parameters.AddWithValue("@status", 0);
        cmd.Parameters.AddWithValue("@attempt", 0);
        cmd.Parameters.AddWithValue("@email", email.Text);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        firstName.ReadOnly = true;
        balance.ReadOnly = true;
        email.ReadOnly = true;
        password.ReadOnly = true;

        uploadStatus.Text = "Done Register!";

    }
}