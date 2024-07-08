using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Providers.Entities;

public class DBConnector
{
    private string connectionString = "Server=tcp:intidemo.database.windows.net,1433;Initial Catalog=bankApp;Persist Security Info=False;User ID=darren;Password=123456Abc;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    public string ConnectionString()
    {
        return connectionString;
    }
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
    public DataTable GetData(string query, string searchText)
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
    public bool searchDatabase(string query, string accountNo, string email, int method)
    {
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@accountNo", Int32.Parse(accountNo));
        if (email != null)
        {
            cmd.Parameters.AddWithValue("@email", email);
        }
        if (method == 1)
        {
            con.Open();
            int count = (int)cmd.ExecuteScalar();
            con.Close();

            return count > 0 ? true : false;
        }
        else if (method == 2)
        {
            con.Open();
            object result = cmd.ExecuteScalar();

            return (result == null || result == DBNull.Value) ? true : false;
        }
        return false;
    }
}


