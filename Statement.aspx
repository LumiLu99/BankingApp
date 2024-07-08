<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Statement.aspx.cs" Inherits="Statement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title>Statement</title>

</head>
<body>
    <form id="form1" runat="server">
        <h1>Statement</h1>
        <asp:Label ID="lblName" runat="server"></asp:Label>
            <br />
            Your account number:
            <asp:Label ID="lblAccount" runat="server"></asp:Label>
            <br />
            Your available balance: RM<asp:Label ID="lblBalance" runat="server"></asp:Label>
        <br />
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="transactionID" DataSourceID="GridID">
                <Columns>
                    <asp:BoundField DataField="customerID" HeaderText="customerID" SortExpression="customerID" />
                    <asp:BoundField DataField="transactionID" HeaderText="transactionID" SortExpression="transactionID" InsertVisible="False" ReadOnly="True" />
                    <asp:BoundField DataField="payeeAccount" HeaderText="payeeAccount" SortExpression="payeeAccount" />
                    <asp:BoundField DataField="payeeName" HeaderText="payeeName" SortExpression="payeeName" />
                    <asp:BoundField DataField="transactionType" HeaderText="transactionType" SortExpression="transactionType" />
                    <asp:BoundField DataField="transactionDate" HeaderText="transactionDate" SortExpression="transactionDate"/>
                    <asp:BoundField DataField="debit" HeaderText="debit" SortExpression="debit"/>
                    <asp:BoundField DataField="credit" HeaderText="credit" SortExpression="credit"/>
                    <asp:BoundField DataField="balance" HeaderText="balance" SortExpression="balance" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="GridID" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
                SelectCommand="SELECT * FROM [TransactionTable]">
            </asp:SqlDataSource>
            <br />
            <asp:Button ID="BackButton" runat="server" OnClick="BackButton_Click" Text="Back" CausesValidation="False" />
            <asp:HiddenField ID="hdfTransactionDate" runat="server" />
            <asp:HiddenField runat="server" ID="hdfCustomerID" />
        </div>
    </form>
</body>
</html>
