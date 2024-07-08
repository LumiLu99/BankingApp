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
                    <asp:BoundField DataField="transactionID" HeaderText="Transaction Number" SortExpression="transactionID" InsertVisible="False" ReadOnly="True" />
                    <asp:BoundField DataField="payeeAccount" HeaderText="Account No;" SortExpression="payeeAccount" />
                    <asp:BoundField DataField="payeeName" HeaderText="Name" SortExpression="payeeName" />
                    <asp:BoundField DataField="transactionType" HeaderText="Transaction Type" SortExpression="transactionType" />
                    <asp:BoundField DataField="transactionDate" HeaderText="Date" SortExpression="transactionDate" DataFormatString="{0:dd-MM-yyyy}" />
                     <asp:BoundField DataField="debit" HeaderText="Debit" SortExpression="debit" DataFormatString="{0:N2}"/>
                    <asp:BoundField DataField="credit" HeaderText="Credit" SortExpression="credit" DataFormatString="{0:N2}"/>
                    <asp:BoundField DataField="balance" HeaderText="Balance" SortExpression="balance" DataFormatString="{0:N2}"/>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="GridID" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
                SelectCommand="SELECT [transactionID], [payeeAccount], [payeeName], [transactionType], [transactionDate], [debit], [credit], [balance] FROM [TransactionTable] WHERE [customerID] = @customerID ORDER BY [transactionDate]">
                 <SelectParameters>
                    <asp:SessionParameter Name="customerID" SessionField="customerID" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <asp:Button ID="BackButton" runat="server" OnClick="BackButton_Click" Text="Back" CausesValidation="False" />
            <asp:HiddenField ID="hdfTransactionDate" runat="server" />
            <asp:HiddenField runat="server" ID="hdfCustomerID" />
        </div>
    </form>
</body>
</html>
