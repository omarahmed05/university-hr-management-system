<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="H01HRLogin.aspx.cs" Inherits="DatabaseProject.HRLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HR Login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body class="login-page login-page-hr">
    <form id="form1" runat="server">
        <div class="login-card">

            <div class="login-header">
                <div class="login-logo login-logo-hr">&#128203;</div>
                <h1>HR Login</h1>
                <p>Sign in to access the HR management panel</p>
            </div>

            <div class="form-group">
                <label class="form-label">HR Employee ID</label>
                <asp:TextBox ID="HRUsername" runat="server" CssClass="form-control form-control-hr" placeholder="Enter your HR ID"></asp:TextBox>
            </div>

            <div class="form-group">
                <label class="form-label">Password</label>
                <asp:TextBox ID="HRPassword" runat="server" TextMode="Password" CssClass="form-control form-control-hr" placeholder="Enter your password"></asp:TextBox>
            </div>

            <asp:Label ID="errorLabel" runat="server" Text="" CssClass="alert alert-error" ForeColor=""></asp:Label>

            <asp:Button ID="loginButton" runat="server" OnClick="Login" Text="Sign In"
                CssClass="btn btn-lg btn-full btn-hr mt-4" />

            <a href="HomePage.aspx" class="login-back">&#8592; Back to Portal Selection</a>

        </div>
    </form>
</body>
</html>
