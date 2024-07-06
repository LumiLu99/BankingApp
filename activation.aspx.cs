using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.IO;
using System.Security.Cryptography;
using System.Text;
public partial class activation : System.Web.UI.Page
{
    string connectionString = "Data Source=AMSBH04\\SQLEXPRESS;Initial Catalog=bank;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected bool searchDatabase()
    {
        string query = "SELECT COUNT(*) FROM [Table] WHERE accountNo = @accountNo AND email = @email";

        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@accountNo", Int32.Parse(accountNo.Text));
        cmd.Parameters.AddWithValue("@email", email.Text);

        con.Open();
        int count = (int)cmd.ExecuteScalar();
        con.Close();

        return count > 0 ? true : false;
    }
    protected bool checkPassword()
    {
        string query = "SELECT password FROM [Table] WHERE accountNo = @accountNo";

        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@accountNo", Int32.Parse(accountNo.Text));

        con.Open();
        object result = cmd.ExecuteScalar();

        return (result == null || result == DBNull.Value) ? true : false;
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        if (!checkPassword())
        {
            error.Text = "Kindly contact admin to reset password.";
        }
        else if (searchDatabase() && checkPassword())
        {
            SymmetricEncryption en = new SymmetricEncryption();
            string query = "UPDATE [Table] SET password = @password WHERE accountNo = @accountNo";
            string EncryptedPass = en.Encrypt(password.Text);

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@password", EncryptedPass);
            cmd.Parameters.AddWithValue("@accountNo", Int32.Parse(accountNo.Text));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            error.Text = "Activation Successful! Kindly login";
        }
        error.Visible = true;
    }

    protected void backClick(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}