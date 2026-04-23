<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A11AdminLogin.aspx.cs" Inherits="DatabaseProject.AdminLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body class="login-page login-page-admin">
    <form id="form1" runat="server">
        <div class="login-card">

            <div class="login-header">
                <div class="login-logo login-logo-admin">&#128737;</div>
                <h1>Admin Login</h1>
                <p>Sign in to access the admin panel</p>
            </div>

            <div class="form-group">
                <label class="form-label">Admin ID</label>
                <asp:TextBox ID="username_1" runat="server" CssClass="form-control form-control-admin" placeholder="Enter your admin ID"></asp:TextBox>
            </div>

            <div class="form-group">
                <label class="form-label">Password</label>
                <asp:TextBox ID="password_1" runat="server" TextMode="Password" CssClass="form-control form-control-admin" placeholder="Enter your password"></asp:TextBox>
            </div>

            <asp:Label ID="errl" runat="server" Text="" CssClass="alert alert-error" ForeColor=""></asp:Label>

            <asp:Button ID="loginbutton1" runat="server" Text="Sign In" OnClick="Login"
                CssClass="btn btn-lg btn-full btn-admin mt-4" />

            <a href="HomePage.aspx" class="login-back">&#8592; Back to Portal Selection</a>

        </div>
    </form>
</body>
</html>
