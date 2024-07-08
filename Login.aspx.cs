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
        DBConnector db = new DBConnector();

        hookUp = new SqlConnection(db.ConnectionString());
        sql = "SELECT customerName, customerUsername, customerPassword, customerBalance, customerAccount, customerID, loginAttempt, status FROM dbo.customerDetails WHERE customerUsername = @username AND customerPassword = @password";

        SymmetricEncryption en = new SymmetricEncryption();
        string enPass = en.Encrypt(password);
        string enUser = en.Encrypt(username);

        sqlCmd = new SqlCommand(sql, hookUp);
        sqlCmd.Parameters.AddWithValue("@username", enUser);
        sqlCmd.Parameters.AddWithValue("@password", enPass);
        hookUp.Open();
        reader = sqlCmd.ExecuteReader();
        if (reader.HasRows && reader.Read())
        {
            int loginAttempts = Convert.ToInt32(reader["loginAttempt"]);
            int status = Convert.ToInt32(reader["status"]);

            if (status == 1)
            {
                reader.Close();
                lblUserError.Text = "";
                lblUserError1.Text = "Your account is blocked. Please contact support for assistance.";
                return false;
            }
            string retrievedUsername = reader["customerUsername"].ToString().Trim();
            string retrievedPassword = reader["customerPassword"].ToString().Trim();
            string retrievedName = reader["customerName"].ToString();
            decimal retrievedBalance = Convert.ToDecimal(reader["customerBalance"]);
            int retrievedAccount = Convert.ToInt32(reader["customerAccount"]);
            int retrievedID = Convert.ToInt32(reader["customerID"]);

            reader.Close();

            if (retrievedPassword != enPass)
            {

                // Update login attempts in database
                UpdateLoginAttempts(username, loginAttempts + 1);

                // Check if login attempts exceeded
                if (loginAttempts + 1 >= 3) // Block after 3 attempts
                {
                    UpdateAccountStatus(username, 1);
                    lblUserError1.Text = "Your account has been blocked due to multiple failed login attempts.";
                    lblUserError.Text = "";
                }
                else
                {
                    lblUserError.Text = "Invalid Username or Password";
                    lblUserError1.Text = "";
                }
                return false;
            }
            else
            {
                // Reset login attempts as login successful
                UpdateLoginAttempts(username, 0);

                // Reset status to 0 (assuming 0 means active)
                UpdateAccountStatus(username, 0);

                // Store user session
                Session["CustomerName"] = retrievedName;
                Session["CustomerBalance"] = retrievedBalance;
                Session["CustomerAccount"] = retrievedAccount;
                Session["CustomerID"] = retrievedID;

                return true;
            }
        }
        else
        {
            reader.Close();
            lblUserError.Text = "Invalid Username or Password";
            lblUserError1.Text = "";
            return false;
        }
    }
    private void UpdateLoginAttempts(string username, int attempts)
    {
        // Update LoginAttempts in database
        sql = "UPDATE dbo.customerDetails SET loginAttempt = @attempts WHERE customerUsername = @username";
        sqlCmd = new SqlCommand(sql, hookUp);
        sqlCmd.Parameters.AddWithValue("@attempts", attempts);
        sqlCmd.Parameters.AddWithValue("@username", username);
        sqlCmd.ExecuteNonQuery();
    }

    private void UpdateAccountStatus(string username, int status)
    {
        // Update Status in database
        sql = "UPDATE dbo.customerDetails SET status = @Status WHERE customerUsername = @username";
        sqlCmd = new SqlCommand(sql, hookUp);
        sqlCmd.Parameters.AddWithValue("@Status", status);
        sqlCmd.Parameters.AddWithValue("@username", username);
        sqlCmd.ExecuteNonQuery();
    }
}

