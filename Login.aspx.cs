using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblUserError.Text = ""; // Clear error message on initial page load
        }
    }
    protected void loginBtn_Click(object sender, EventArgs e)
    {
        string username = txtUser.Text.Trim();
        string password = txtPassword.Text;
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

    private bool ValidateUser(string username, string password)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string sql = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);

            try
            {
                connection.Open();
                int count = (int)command.ExecuteScalar(); // Executes the query and returns the first column of the first row in the result set

                if (count > 0)
                {
                    return true; // User credentials are valid
                }
                else
                {
                    return false; // User credentials are not valid
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while validating user credentials.", ex);
            }
        }
    }
 
}


