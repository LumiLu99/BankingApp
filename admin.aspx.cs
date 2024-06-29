using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(userId.Text))
        {
            userEmpty.Visible = true;
            return;
        }


        string user = userId.ToString().Trim();
        string pass = password.ToString().Trim();

        string connectionString = ""; //Sql Server string
        string query = ""; // query to execute, select count * from <table> where <column> = user and <column> = password

        SqlConnection connect = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(query, connect);

        cmd.Parameters.AddWithValue("@user", user);
        cmd.Parameters.AddWithValue("@pass", pass);

        connect.Open();
        int count = (int)cmd.ExecuteScalar();
        connect.Close();

        if (count > 0)
        {
            Response.Redirect("");
        }
        else
        {
            error.Visible = true;
        }
    }
}