<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
        <title>Home</title>
</head>
<body>
    <form id="form1" runat="server">
            <h1>Online Banking</h1>
        <div>
            <span>Welcome 
            <asp:Label ID="lblName" runat="server"></asp:Label>!<br />
            Your account number:&nbsp;
            <asp:Label ID="lblAccount" runat="server"></asp:Label>
            </span>
            &nbsp;<p>Your current balance: RM
                <asp:Label ID="lblBalance" runat="server"></asp:Label>
            </p> 
            <ul>
            <li><a href="PayBill.aspx">Pay Bills</a></li>
            <li><a href="Statement.aspx">Statement</a></li>
            <li><a href="TransferMoney.aspx">Transfer Money</a></li>
            </ul>
            <asp:HiddenField runat="server" ID="hdfCustomerID" />
        </div>
    </form>
</body>
</html>
