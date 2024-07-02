using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = "Data Source=AMSBH04\\SQLEXPRESS;Initial Catalog=bank;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        if (!IsPostBack)
        {
            if (Session["EditUser"] != null)
            {
                int userID = Convert.ToInt32(Session["EditUser"]);

                string query = "SELECT Id, accountNo, firstName, lastName, status, username, email FROM [Table] WHERE Id = @UserID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserID", userID);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Populate controls with user data for editing
                        accountNo.Text = reader["accountNo"].ToString();
                        firstName.Text = reader["firstName"].ToString();
                        lastName.Text = reader["lastName"].ToString();
                        email.Text = reader["email"].ToString();
                        bool status1 = Convert.ToBoolean(reader["status"]);
                        status.Checked = status1;
                    }

                    reader.Close();
                }
            }
            else
            {
                // Handle case where session is null (e.g., redirect to error page)
                Response.Redirect("adminHome.aspx");
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminHome.aspx");
    }
}