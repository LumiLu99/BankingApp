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
            if (Session["LoggedIn"] == null || !(bool)Session["LoggedIn"])
            {
                Response.Redirect("admin.aspx");
            }
            PopulateGridView();
        }
    }
    //Generate data table from SQL
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
    //Convert int in "status" into string by substitude the int with string during GridView rendering
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label statusLabel = e.Row.FindControl("lblStatus") as Label;

            if (statusLabel != null && statusLabel.Text == "1")
            {
                statusLabel.Text = "Block";
            }
            else { statusLabel.Text = "Active"; }
        }
    }
    protected void registerUser(object sender, EventArgs e)
    {
        Response.Redirect("register-user.aspx");
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        searchUser();
    }
    protected void textchange(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        userTable.PageIndex = e.NewPageIndex;
    }
    //Search for value in database
    private void searchUser()
    {
        string searchtxt = search.Text.Trim();

        string query = "SELECT * FROM [Table] WHERE firstName LIKE @search OR lastName LIKE @search OR accountNo LIKE @search OR email LIKE @search";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter data = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        cmd.Parameters.AddWithValue("@search", "%" + searchtxt + "%");
        con.Open();
        data.Fill(dt);
        con.Close();

        userTable.DataSource = dt;
        userTable.DataBind();
    }
    //passing the value with session to edit page
    protected void editButton(object sender, EventArgs e)
    {
        Button userEdit = (Button)sender;
        GridViewRow row = (GridViewRow)userEdit.NamingContainer;
        int rowIndex = row.RowIndex;
        int id = Convert.ToInt32(userTable.DataKeys[rowIndex]["id"]);

        Session["EditUser"] = id;
        Response.Redirect("EditUser.aspx");
    }
}