<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminHome.aspx.cs" Inherits="adminHome" %>

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
        <div class="row">
            <!-- User Management Section -->
            <div class="col">
                <div class="user-list">
                    <h2>User Management</h2>
                    <form runat="server" id="form1">
                        <asp:Button ID="register" runat="server" class="btn btn-primary" Text="+Add New User" OnClick="registerUser"/>
                        <asp:GridView ID="userTable" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" class="table-bordered table">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="ID" />
                                <asp:BoundField DataField="accountNo" HeaderText="Account No." />
                                <asp:BoundField DataField="firstName" HeaderText="First Name" />
                                <asp:BoundField DataField="lastName" HeaderText="Last Name" />
                                <asp:BoundField DataField="status" HeaderText="Status" />
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:Button ID="userEdit" runat="server" Text="Edit" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="pagination" />
                            <PagerSettings Mode="NumericFirstLast" />
                        </asp:GridView>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
