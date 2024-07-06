using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.EnterpriseServices;
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
        bool accountExists = CheckPayeeAccountExists(PayeeAccount);
        int recipientAccount = int.Parse(accNumber.Text);
        int recipientCustomerID = GetRecipientCustomerID(recipientAccount);
        decimal recipientCurrentBalance = GetCurrentBalance(recipientAccount);

        if (accountExists)
        {
            // Insert information into transaction table for current session user 
            hookUp = new SqlConnection("Server=LAPTOP-11MN0H02\\SQLEXPRESS;Database=BankingApp;Integrated Security=True");
            sql = "INSERT INTO dbo.TransactionTable (customerID, payeeAccount, transactionType, transactionDate, debit, balance)" +
                           "VALUES (@CustomerID, @PayeeAccount, @TransactionType, @TransactionDate, @Debit, @Balance)";
            sqlCmd = new SqlCommand(sql, hookUp);
            sqlCmd.Parameters.AddWithValue("@CustomerID", customerID);
            sqlCmd.Parameters.AddWithValue("@PayeeAccount", PayeeAccount);
            sqlCmd.Parameters.AddWithValue("@TransactionType", transactionType);
            sqlCmd.Parameters.AddWithValue("@TransactionDate", transactionDate);
            sqlCmd.Parameters.AddWithValue("@Debit", amountToTransfer);
            sqlCmd.Parameters.AddWithValue("@Balance", newBalance);
            hookUp.Open();
            sqlCmd.ExecuteNonQuery();
            hookUp.Close();

            // Update receiver's account balance 
            hookUp = new SqlConnection("Server=LAPTOP-11MN0H02\\SQLEXPRESS;Database=BankingApp;Integrated Security=True");
            sql = "UPDATE dbo.customerDetails SET customerBalance = customerBalance + @Credit WHERE customerAccount = @RecipientAccount;";
            sqlCmd = new SqlCommand(sql, hookUp);
            sqlCmd.Parameters.AddWithValue("@Credit", amountToTransfer);
            sqlCmd.Parameters.AddWithValue("@RecipientAccount", recipientAccount);
            hookUp.Open();
            sqlCmd.ExecuteNonQuery();
            hookUp.Close();

            // Insert information into transaction table for receiver 
            sql = "INSERT INTO dbo.TransactionTable (customerID, payeeAccount, transactionType, transactionDate, credit, balance)" +
              "VALUES (@CustomerID, @PayeeAccount, @TransactionType, @TransactionDate, @Credit, @Balance)";
            sqlCmd = new SqlCommand(sql, hookUp);
            sqlCmd.Parameters.AddWithValue("@CustomerID", recipientCustomerID);
            sqlCmd.Parameters.AddWithValue("@PayeeAccount", recipientAccount);
            sqlCmd.Parameters.AddWithValue("@TransactionType", transactionType);
            sqlCmd.Parameters.AddWithValue("@TransactionDate", transactionDate);
            sqlCmd.Parameters.AddWithValue("@Credit", amountToTransfer);
            sqlCmd.Parameters.AddWithValue("@Balance", (recipientCurrentBalance + amountToTransfer));
            hookUp.Open();
            sqlCmd.ExecuteNonQuery();
            hookUp.Close();

            // Update current session user's account balance 
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
        else
        {
            lblAccValid.Text = "Account does not exist";
            lblAccValid.Visible = true;
        }
    }
    
    private bool CheckPayeeAccountExists(int PayeeAccount) // Check if user entered account exists
    {
        hookUp = new SqlConnection("Server=LAPTOP-11MN0H02\\SQLEXPRESS;Database=BankingApp;Integrated Security=True");
        sql = "SELECT COUNT(*) FROM dbo.customerDetails WHERE customerAccount = @PayeeAccount";
        sqlCmd = new SqlCommand(sql, hookUp);
        sqlCmd.Parameters.AddWithValue("@PayeeAccount", PayeeAccount);
        hookUp.Open();
        int count = (int)sqlCmd.ExecuteScalar(); // Get the count of matching accounts
        return count > 0;
    }

    private int GetRecipientCustomerID(int payeeAccount)
    {
        hookUp = new SqlConnection("Server=LAPTOP-11MN0H02\\SQLEXPRESS;Database=BankingApp;Integrated Security=True");
        sql = "SELECT customerID FROM dbo.customerDetails WHERE customerAccount = @PayeeAccount";
        sqlCmd = new SqlCommand(sql, hookUp);
        sqlCmd.Parameters.AddWithValue("@PayeeAccount", payeeAccount);
        hookUp.Open();
        int recipientCustomerID = (int)sqlCmd.ExecuteScalar(); // Get the recipient's customerID
        hookUp.Close();
        return recipientCustomerID;
    }

    private decimal GetCurrentBalance(int recipientAccount)
    {
        hookUp = new SqlConnection("Server=LAPTOP-11MN0H02\\SQLEXPRESS;Database=BankingApp;Integrated Security=True");
        sql = "SELECT customerBalance FROM dbo.customerDetails WHERE customerAccount = @RecipientAccount";
        sqlCmd = new SqlCommand(sql, hookUp);
        sqlCmd.Parameters.AddWithValue("@RecipientAccount", recipientAccount);
        hookUp.Open();
        decimal currentBalance = (decimal)sqlCmd.ExecuteScalar();
        hookUp.Close();
        return currentBalance;
    }
}