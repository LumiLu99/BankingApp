<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Statement.aspx.cs" Inherits="viewBalance" %>

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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="transactionID" DataSourceID="StatementSource">
                <Columns>
                    <asp:BoundField DataField="transactionID" HeaderText="Transaction No." InsertVisible="False" ReadOnly="True" SortExpression="transactionID" />
                    <asp:BoundField DataField="debit" HeaderText="Debit" SortExpression="debit" />
                    <asp:BoundField DataField="credit" HeaderText="Credit" SortExpression="credit" />
                    <asp:BoundField DataField="payeeAccount" HeaderText="Account Number" SortExpression="payeeAccount" />
                    <asp:BoundField DataField="payeeName" HeaderText="Payee" SortExpression="payeeName" />
                    <asp:BoundField DataField="transactionType" HeaderText="Transaction Type" SortExpression="transactionType" />
                    <asp:BoundField DataField="transactionDate" HeaderText="Date" SortExpression="transactionDate" DataFormatString="{0:dd-MM-yyyy}" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="StatementSource" runat="server" ConnectionString="<%$ ConnectionStrings:BankingAppConnectionString %>" SelectCommand="SELECT [transactionID], [debit], [credit], [payeeAccount], [payeeName], [transactionType], [transactionDate] FROM [TransactionTable]"></asp:SqlDataSource>
            <br />
            <asp:Button ID="BackButton" runat="server" OnClick="BackButton_Click" Text="Back" />
            <asp:HiddenField ID="hdfTransactionDate" runat="server" />
            <asp:HiddenField runat="server" ID="hdfCustomerID" />
        </div>
    </form>
</body>
</html>
