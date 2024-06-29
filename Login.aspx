<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Welcome to Richard always call Darren Bank</div>
        <p>
            Username:<asp:TextBox ID="txtUser" runat="server" OnTextChanged="username_TextChanged"></asp:TextBox>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        </p>
        <p>
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="Please enter your username."></asp:RequiredFieldValidator>
        </p>
        <p>
            Password:<asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <p>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="password" ErrorMessage="Please enter your password."></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Button ID="Btnlogin" runat="server" Text="Login" OnClick="loginBtn_Click" />
        </p>
        <asp:Label ID="lblUserError" runat="server" Text="Invalid username or password."></asp:Label>
    </form>
</body>
</html>
