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
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        DBConnector db = new DBConnector();

        string verificationQuery = "SELECT COUNT(*) FROM [Table] WHERE accountNo = @accountNo AND email = @email";
        string nullPasswordQuery = "SELECT password FROM [Table] WHERE accountNo = @accountNo";

        if (!db.searchDatabase(nullPasswordQuery, accountNo.Text, null, 2)) //Check if password exist in user, if exist user need to contact admin.
        {
            error.Text = "Kindly contact admin to reset password.";
        }
        else if (db.searchDatabase(verificationQuery, accountNo.Text, email.Text, 1))
        {
            SymmetricEncryption en = new SymmetricEncryption();
            string queryUpdate = "UPDATE [Table] SET password = @password, username = @username WHERE accountNo = @accountNo";
            string EncryptedPass = en.Encrypt(password.Text);
            string EncryptedUser = en.Encrypt(TextBox1.Text);

            SqlConnection con = new SqlConnection(db.ConnectionString());
            SqlCommand cmd = new SqlCommand(queryUpdate, con);

            cmd.Parameters.AddWithValue("@password", EncryptedPass);
            cmd.Parameters.AddWithValue("@username", EncryptedUser);
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