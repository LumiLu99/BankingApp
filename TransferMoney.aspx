﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TransferMoney.aspx.cs" Inherits="TransferMoney" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Transfer Funds</h1>
        <asp:Label ID="lblName" runat="server"></asp:Label>
            <br />
            Your account number:
            <asp:Label ID="lblAccount" runat="server"></asp:Label>
            <br />
            Your available balance: RM<asp:Label ID="lblBalance" runat="server"></asp:Label>
            <br />
        <br />
        Account number to transfer to:<br />
        <asp:TextBox ID="accNumber" runat="server" Height="18px" TextMode="Number" Width="117px"></asp:TextBox>
        <br />
        <br />
        Amount:<br />
        <asp:TextBox ID="transferAmt" runat="server" Height="16px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BtnTransfer" runat="server" OnClick="BtnTransfer_Click" Text="Confirm Transfer" />
&nbsp;<asp:Label ID="lblSuccess" runat="server" Visible="False"></asp:Label>
        <br />
        <asp:Button ID="BackButton" runat="server" OnClick="BackButton_Click" Text="Back" />
            <br />
        <div>
            <asp:HiddenField ID="hdfTransactionDate" runat="server" />
            <asp:HiddenField runat="server" ID="hdfCustomerID" />
        </div>
    </form>
</body>
</html>
