<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditUser.aspx.cs" Inherits="EditUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
</head>
<body>
    <nav class="navbar navbar-dark bg-dark">
        <div class="container-fluid">
            <button class="navbar-toggler" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasDarkNavbar" aria-controls="offcanvasDarkNavbar" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <a class="navbar-brand" href="#">Admin Dashboard</a>
            <div class="offcanvas offcanvas-start text-bg-dark" tabindex="-1" id="offcanvasDarkNavbar" aria-labelledby="offcanvasDarkNavbarLabel">
                <div class="offcanvas-header">
                    <h5 class="offcanvas-title" id="offcanvasDarkNavbarLabel">Welcome,
                    <asp:Label ID="user" runat="server" Text="user"></asp:Label></h5>
                    <button type="button" class="btn-close btn-close-white" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                </div>
                <div class="offcanvas-body">
                    <ul class="navbar-nav justify-content-end flex-grow-1 pe-3">
                        <li class="nav-item">
                            <a class="nav-link active" aria-current="page" href="#">User Management</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Settings</a>
                        </li>
                        <li class="nav-item">
                            <asp:HyperLink ID="logout" NavigateUrl="~/admin.aspx" runat="server" CssClass="nav-link">Logout</asp:HyperLink>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </nav>
    <div class="container">
        <div class="col-sm-8 offset-sm-2">
            <div class="container">
                <h2 class="my-5">Edit User</h2>
                <form runat="server" id="addUser">
                    <div class="mb-3 row">
                        <asp:Label runat="server" ID="accountNoLabel" class="col-sm-2 col-form-label">Account No:</asp:Label>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" ID="accountNo" class="form-control-plaintext" Read="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label runat="server" ID="firstNameLabel" class="col-sm-2 col-form-label">First Name:</asp:Label>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" ID="firstName" class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="First Name required!" ControlToValidate="firstName"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label runat="server" ID="lastNameLabel" class="col-sm-2 col-form-label">Username:</asp:Label>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lastName" class="form-control-label"></asp:Label>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label runat="server" ID="emailLabel" class="col-sm-2 col-form-label">Email:</asp:Label>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" ID="email" class="form-control" TextMode="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="Email required!" ControlToValidate="email"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label runat="server" ID="passwordLabel" class="col-sm-2 col-form-label">Password:</asp:Label>
                         <div class="col-sm-3">
                            <asp:Button runat="server" ID="resetPassword" CssClass="btn btn-danger" Text="Reset" OnClick="resetPassword_Click" />
                             <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="mb-3 row align-items-center">
                        <asp:Label runat="server" ID="StatusLabel" class="col-sm-2 col-form-label">Block:</asp:Label>
                        <div class="col-sm-8">
                            <asp:CheckBox ID="status" runat="server" />
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <div class="col-sm-8 offset-sm-2">
                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Style="margin-right: 10px" Text="Save" OnClick="Button1_Click" /><asp:Button ID="Button2" CssClass="btn btn-danger" runat="server" CausesValidation="false" Text="Back" OnClick="Button2_Click" />
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <div class="col-sm-8 offset-sm-2">
                            <asp:Label runat="server" ID="uploadStatus" ForeColor="#33CC33"></asp:Label>    
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
