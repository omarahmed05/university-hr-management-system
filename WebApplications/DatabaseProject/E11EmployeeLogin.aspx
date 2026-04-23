<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="E11EmployeeLogin.aspx.cs" Inherits="DatabaseProject.EmployeeLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body class="login-page login-page-emp">
    <form id="form1" runat="server">
        <div class="login-card">

            <div class="login-header">
                <div class="login-logo login-logo-emp">&#128188;</div>
                <h1>Employee Login</h1>
                <p>Sign in to access your dashboard</p>
            </div>

            <div class="form-group">
                <label class="form-label">Employee ID</label>
                <asp:TextBox ID="employeeUsername" runat="server" CssClass="form-control" placeholder="Enter your employee ID"></asp:TextBox>
            </div>

            <div class="form-group">
                <label class="form-label">Password</label>
                <asp:TextBox ID="employeePassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter your password"></asp:TextBox>
            </div>

            <asp:Label ID="errorLabel" runat="server" Text="" CssClass="alert alert-error" ForeColor=""></asp:Label>

            <asp:Button ID="loginButton" runat="server" OnClick="Login" Text="Sign In"
                CssClass="btn btn-lg btn-full btn-primary mt-4" />

            <a href="HomePage.aspx" class="login-back">&#8592; Back to Portal Selection</a>

        </div>
    </form>
</body>
</html>
