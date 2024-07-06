<%@ Page Language="C#" AutoEventWireup="true" CodeFile="activation.aspx.cs" Inherits="activation"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">

<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <style>
        .login-form {
            max-width: 350px;
            margin: 0 auto;
            padding: 30px 20px;
            background: #f7f7f7;
            border: 1px solid #ebebeb;
            border-radius: 8px;
            box-shadow: 0px 0px 15px 0px rgba(0,0,0,0.1);
        }

            .login-form h2 {
                text-align: center;
                margin-bottom: 30px;
            }
    </style>
</head>
<body>
    <div class="container mt-5">
        <div class="row justify-content-md-center">
            <div class="col-md-6">
                <div class="login-form">
                    <h2>Activate Account</h2>
                    <form id="form1" class="form-signin" runat="server">
                        <div class="mb-3">
                            <label class="form-label">Account No:</label>
                            <asp:TextBox ID="accountNo" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="userEmpty" runat="server" ErrorMessage="Account Number required!" CssClass="text-danger" ControlToValidate="accountNo"></asp:RequiredFieldValidator>
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Email Address:</label>
                            <asp:TextBox ID="email" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Email required!" CssClass="text-danger" ControlToValidate="email"></asp:RequiredFieldValidator>
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Username:</label>
                            <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Username required!" CssClass="text-danger" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Enter New Password:</label>
                            <asp:TextBox ID="password" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="passEmpty" runat="server" ErrorMessage="Password required!" CssClass="text-danger" ControlToValidate="password"></asp:RequiredFieldValidator>
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Confirm Password:</label>
                            <asp:TextBox ID="ConfirmPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Confirm Password required!" CssClass="text-danger" ControlToValidate="ConfirmPassword"></asp:RequiredFieldValidator>
                        </div>
                        <asp:Button ID="Submit" CssClass="btn btn-primary w-100" runat="server" Text="Activate" OnClick="Submit_Click" />
                        <asp:Button ID="back" CssClass="btn btn-primary w-100 mt-2  " runat="server" CausesValidation="false" Text="Back To Login" OnClick="backClick" />
                        <asp:Label ID="error" runat="server" Text="User Not Found!" Visible="false" CssClass="text-danger"></asp:Label>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
