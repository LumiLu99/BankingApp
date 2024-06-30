using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class adminHome : System.Web.UI.Page
{
    string connectionString = "Data Source=AMSBH04\\SQLEXPRESS;Initial Catalog=bank;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateGridView();
        }
    }

    private void PopulateGridView()
    {
        string query = "SELECT * FROM [Table]";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter data = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        data.Fill(dt);

        userTable.DataSource = dt;
        userTable.DataBind();
    }

    protected void registerUser(object sender, EventArgs e)
    {
        Response.Redirect("register-user.aspx");
    }
}