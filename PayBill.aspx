<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PayBill.aspx.cs" Inherits="PayBill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title>Bill Payment</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Bill payment</h1>
        <div>
            <asp:Label ID="lblName" runat="server"></asp:Label>
            <br />
            Your account number:
            <asp:Label ID="lblAccount" runat="server"></asp:Label>
            <br />
            Your available balance: RM<asp:Label ID="lblBalance" runat="server"></asp:Label>
            <br />
            <br />
            To payee:
            <br />
            <asp:DropDownList ID="ddlPayee" runat="server" DataSourceID="Payee" DataTextField="payeeName" DataValueField="payeeName">
            </asp:DropDownList>
            <asp:SqlDataSource ID="Payee" runat="server" ConnectionString="<%$ ConnectionStrings:BankingAppConnectionString %>" ProviderName="<%$ ConnectionStrings:BankingAppConnectionString.ProviderName %>" SelectCommand="SELECT [payeeName] FROM [billPayee]"></asp:SqlDataSource>
            <br />
            <br />
            Amount:
            <br />
            <asp:TextBox ID="billAmount" runat="server" TextMode="Number"></asp:TextBox>
            <br />
            <br />
            <asp:HiddenField ID="hdfTransactionDate" runat="server" />
            <asp:HiddenField runat="server" ID="hdfCustomerID" />
            <asp:Button ID="btnBill" runat="server" Text="Confirm payment" OnClick="btnBill_Click" />
            &nbsp;<asp:Label ID="lblSuccess" runat="server" Visible="False"></asp:Label>
            <br />
            <asp:Button ID="backBill" runat="server" OnClick="backBill_Click" Text="Back" />
            <br />
        </div>
    </form>
</body>
</html>
