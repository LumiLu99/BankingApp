using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditUser : System.Web.UI.Page
{
    DBConnector db = new DBConnector();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["EditUser"] != null)
            {
                int userID = Convert.ToInt32(Session["EditUser"]);
                string connectionString = db.ConnectionString();

                string query = "SELECT customerID, customerAccount, customerName, status, customerUsername, email FROM [customerDetails] WHERE customerID = @UserID";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userID);
                
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // Populate controls with user data for editing
                    accountNo.Text = reader["customerAccount"].ToString();
                    firstName.Text = reader["customerName"].ToString();
                    lastName.Text = reader["customerUsername"].ToString();
                    email.Text = reader["email"].ToString();
                    bool status1 = Convert.ToBoolean(reader["status"]);
                    status.Checked = status1;
                }
                reader.Close();
            }
            else
            {
                Response.Redirect("adminHome.aspx");
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int userID = Convert.ToInt32(Session["EditUser"]);
        string connectionString = db.ConnectionString();

        string query = "UPDATE [customerDetails] SET customerName = @firstName, email = @email, status = @status WHERE customerID = @id";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@id", userID);
        cmd.Parameters.AddWithValue("@firstName", firstName.Text);
        cmd.Parameters.AddWithValue("@email", email.Text);
        cmd.Parameters.AddWithValue("@status", status.Checked);

        con.Open();
        int rowAffected = cmd.ExecuteNonQuery();
        con.Close();

        if (rowAffected > 0)
        {
            Response.Redirect("adminHome.aspx");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminHome.aspx");
    }

    protected void resetPassword_Click(object sender, EventArgs e)
    {
        int userID = Convert.ToInt32(Session["EditUser"]);
        string connectionString = db.ConnectionString();

        string query = "UPDATE [customerDetails] SET CustomerPassword = @password WHERE customerID = @id";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@id", userID);
        cmd.Parameters.AddWithValue("@password", DBNull.Value);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        Label1.Text = "Password Reset!";
    }
}