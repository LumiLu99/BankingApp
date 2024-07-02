using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Ajax.Utilities;

public partial class Login : System.Web.UI.Page
{
    private string sql;
    private SqlCommand sqlCmd;
    private SqlConnection hookUp;
    private SqlDataReader reader;

    protected void loginBtn_Click(object sender, EventArgs e)
    {

        bool isValid = ValidateUser(txtUser.Text, txtPassword.Text);

        if (isValid)
        {
            Response.Redirect("Home.aspx");
        }
        else
        {
            lblUserError.Text = "Invalid Username or Password";
            txtUser.Text = "";
            txtPassword.Text = "";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblUserError.Text = ""; // Clear error message on initial page load
        }
    }

    private bool ValidateUser(string username, string password)
    {
        hookUp = new SqlConnection("Server=LAPTOP-11MN0H02\\SQLEXPRESS;Database=BankingApp;Integrated Security=True");
        sql = "SELECT customerName, customerUsername, customerPassword, customerBalance, customerAccount, customerID FROM dbo.customerDetails WHERE customerUsername = @username AND customerPassword = @password";
        sqlCmd = new SqlCommand(sql, hookUp);
        sqlCmd.Parameters.AddWithValue("@username", username);
        sqlCmd.Parameters.AddWithValue("@password", password);
        hookUp.Open();
        reader = sqlCmd.ExecuteReader();
        if (reader.HasRows && reader.Read())
        {
            string retrievedUsername = reader["customerUsername"].ToString();
            string retrievedPassword = reader["customerPassword"].ToString();
            string retrievedName = reader["customerName"].ToString();
            decimal retrievedBalance = Convert.ToDecimal(reader["customerBalance"]);
            int retrievedAccount = Convert.ToInt32(reader["customerAccount"]);
            int retrievedID = Convert.ToInt32(reader["customerID"]);

            if (retrievedUsername != username || retrievedPassword != password)
            {
                reader.Close();
                hookUp.Close();
                return false;
            }
            else
            {
                Session["CustomerName"] = retrievedName;
                Session["CustomerBalance"] = retrievedBalance;
                Session["CustomerAccount"] = retrievedAccount;
                Session["CustomerID"] = retrievedID;
                reader.Close();
                hookUp.Close();
                return true;
            }
        }
        else
        {
            reader.Close();
            hookUp.Close();
            return false;
        }
    }

}