using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string customerName = (string)Session["CustomerName"];
        decimal customerBalance = (decimal)Session["CustomerBalance"];
        int customerAccount = (int)Session["CustomerAccount"];
        int customerID = (int)Session["CustomerID"];

        lblName.Text = customerName;
        lblBalance.Text = customerBalance.ToString();
        lblAccount.Text = customerAccount.ToString();
        hdfCustomerID.Value = customerID.ToString();

    }
}