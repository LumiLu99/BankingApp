﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Statement : System.Web.UI.Page
{
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
        Session["CustomerName"] = lblName.Text;
        Session["CustomerBalance"] = Decimal.Parse(lblBalance.Text);
        Session["CustomerAccount"] = Int32.Parse(lblAccount.Text);
        Session["CustomerID"] = Int32.Parse(hdfCustomerID.Value);
        Response.Redirect("Home.aspx");
    }
}