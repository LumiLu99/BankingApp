using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Threading;

public partial class admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        //need change the connectionString and query
        string connectionString = "Data Source=AMSBH04\\SQLEXPRESS;Initial Catalog=bank;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
        string query = "SELECT COUNT(*) FROM admin2 WHERE username = @user AND password = @pass"; 

        SqlConnection connect = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(query, connect);

        cmd.Parameters.AddWithValue("@user", userId.Text);
        cmd.Parameters.AddWithValue("@pass", password.Text);

        connect.Open();
        int count = (int)cmd.ExecuteScalar();
        connect.Close();

        if (count > 0)
        {
            Session["LoggedIn"] = true;
            Response.Redirect("adminHome.aspx");
        }
        else
        {
            error.Visible = true;
        }
    }
}