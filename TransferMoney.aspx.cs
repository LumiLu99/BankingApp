using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TransferMoney : System.Web.UI.Page
{
    private string sql;
    private SqlCommand sqlCmd;
    private SqlConnection hookUp;
    protected void Page_Load(object sender, EventArgs e)
    {
            if (!IsPostBack)
            {
                string customerName = Session["CustomerName"] as string ?? "Guest";
                int customerAccount = (int)Session["CustomerAccount"];
                int customerID = (int)Session["CustomerID"];

                lblName.Text = customerName;
                lblAccount.Text = customerAccount.ToString();

                if (Session["CustomerBalance"] != null)
                {
                    decimal customerBalance = (decimal)Session["CustomerBalance"];
                    lblBalance.Text = customerBalance.ToString();
                }
                else
                {
                    lblBalance.Text = "Not Available";
                }

                hdfTransactionDate.Value = DateTime.Now.ToString("dd-MM-yyyy");
                hdfCustomerID.Value = customerID.ToString();
            }
        }

    protected void BackButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx");
    }

    protected void BtnTransfer_Click(object sender, EventArgs e)
    {
        int customerID = int.Parse(hdfCustomerID.Value);
        decimal amountToTransfer = decimal.Parse(transferAmt.Text);
        string transactionType = "Fund transfer";
        int PayeeAccount = int.Parse(accNumber.Text);
        string transactionDate = hdfTransactionDate.Value;
        decimal customerBalance = (decimal)Session["CustomerBalance"];
        lblBalance.Text = customerBalance.ToString();
        decimal newBalance = customerBalance - amountToTransfer;

        hookUp = new SqlConnection("Server=LAPTOP-11MN0H02\\SQLEXPRESS;Database=BankingApp;Integrated Security=True");
        sql = "INSERT INTO dbo.TransactionTable (customerID, payeeAccount, transactionType, transactionDate, debit)" +
                       "VALUES (@CustomerID, @PayeeAccount, @TransactionType, @TransactionDate, @Debit)";
        sqlCmd = new SqlCommand(sql, hookUp);
        sqlCmd.Parameters.AddWithValue("@CustomerID", customerID);
        sqlCmd.Parameters.AddWithValue("@PayeeAccount", PayeeAccount);
        sqlCmd.Parameters.AddWithValue("@TransactionType", transactionType);
        sqlCmd.Parameters.AddWithValue("@TransactionDate", transactionDate);
        sqlCmd.Parameters.AddWithValue("@Debit", amountToTransfer);
        hookUp.Open();
        sqlCmd.ExecuteNonQuery();
        hookUp.Close();


        hookUp = new SqlConnection("Server=LAPTOP-11MN0H02\\SQLEXPRESS;Database=BankingApp;Integrated Security=True");
        sql = "UPDATE dbo.customerDetails SET customerBalance = customerBalance - @Debit WHERE customerID = @CustomerID;";
        sqlCmd = new SqlCommand(sql, hookUp);
        sqlCmd.Parameters.AddWithValue("@CustomerID", customerID);
        sqlCmd.Parameters.AddWithValue("@Debit", amountToTransfer);
        hookUp.Open();
        sqlCmd.ExecuteNonQuery();
        hookUp.Close();
        lblSuccess.Text = "Data submitted successfully!";
        lblSuccess.Visible = true;
        Session["CustomerBalance"] = newBalance;
        Response.Redirect("Home.aspx");
    }
}