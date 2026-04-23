<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="DatabaseProject.HomePage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>University HR System</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="home-page">

            <div class="home-header">
                <div class="home-logo">&#127891;</div>
                <h1 class="site-title">University HR System</h1>
                <p class="site-subtitle">Manage your academic workforce, leaves &amp; payroll in one place</p>
            </div>

            <div class="portal-grid">

                <div class="portal-option">
                    <div class="portal-icon">&#128188;</div>
                    <h3>Employee Portal</h3>
                    <p>Access your profile, manage leaves, view payroll &amp; attendance</p>
                    <asp:Button ID="EmployeeLoginBtn" runat="server" Text="Sign In as Employee"
                        onClick="Employee_Button" CssClass="btn btn-lg btn-full btn-primary" />
                </div>

                <div class="portal-option">
                    <div class="portal-icon">&#128737;</div>
                    <h3>Admin Portal</h3>
                    <p>Manage departments, holidays, attendance &amp; staff operations</p>
                    <asp:Button ID="AdminLoginBtn" runat="server" Text="Sign In as Admin"
                        onClick="Admin_Button" CssClass="btn btn-lg btn-full btn-admin" />
                </div>

                <div class="portal-option">
                    <div class="portal-icon">&#128203;</div>
                    <h3>HR Portal</h3>
                    <p>Process leave requests, deductions &amp; generate payroll</p>
                    <asp:Button ID="HRLoginBtn" runat="server" Text="Sign In as HR"
                        onClick="HR_Button" CssClass="btn btn-lg btn-full btn-hr" />
                </div>

            </div>

        </div>
    </form>
</body>
</html>
