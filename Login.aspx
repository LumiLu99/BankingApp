<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="card border-0 shadow-sm mx-auto" style="max-width: 400px;">
            <div class="card-body">
                <h2 class="text-center mb-4">Login</h2>
                <div class="mb-3">
                    <label for="txtUser" class="form-label">Username:</label>
                    <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" placeholder="Enter your username"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUser" ErrorMessage="Please enter your username." CssClass="text-danger"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div class="mb-3">
                    <label for="txtPassword" class="form-label">Password:</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter your password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter your password." CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
                <asp:Button ID="loginBtn" runat="server" Text="Login" OnClick="loginBtn_Click" CssClass="btn btn-primary w-100"></asp:Button>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/activation.aspx">Acitvate Account!</asp:HyperLink>

            </div>
        </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-U1DAWAznBHeqEIlVSCgzq+c9gqGAJn5c/t99JyeKa9xxaYpSvHU5awsuZVVFIhvj" crossorigin="anonymous"></script>
        <p>
                <asp:Label ID="lblUserError" runat="server" CssClass="text-danger mt-2"></asp:Label>
            </p>
        <p>
            <asp:Label ID="lblUserError1" runat="server" ForeColor="Red"></asp:Label>
        </p>
    </form>

    </body>
</html>
