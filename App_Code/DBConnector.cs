using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Providers.Entities;

/// <summary>
/// Summary description for DBConnector
/// </summary>
public class DBConnector
{
    private string connectionString = "Data Source=AMSBH04\\SQLEXPRESS;Initial Catalog=bank;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

    public void BindData(string query, string search, GridView grid)
    {

        DataTable dt = GetData(query, search);
        if (dt.Rows.Count > 0)
        {
            grid.DataSource = dt;
            grid.DataBind();
        }
        else
        {
            grid.DataSource = null;
            grid.DataBind();
            grid.EmptyDataText = "No record found";
        }
    }
    private DataTable GetData(string query, string searchText)
    {
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        if (searchText != null)
        {
            cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");
        }

        con.Open();
        adapter.Fill(dt);
        con.Close();

        return dt;
    }

    public int verifyUser(string query, string username, string password)
    {
        SymmetricEncryption en = new SymmetricEncryption();
        string enPass = en.Encrypt(password);

        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@user", username);
        cmd.Parameters.AddWithValue("@pass", enPass);

        con.Open();
        int count = (int)cmd.ExecuteScalar();
        con.Close();

        return count;
    }
}


