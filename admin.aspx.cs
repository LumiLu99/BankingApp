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
        string query = "SELECT COUNT(*) FROM admin2 WHERE username = @user AND password = @pass"; 
        DBConnector db = new DBConnector();

        if (db.verifyUser(query, userId.Text, password.Text) > 0)
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