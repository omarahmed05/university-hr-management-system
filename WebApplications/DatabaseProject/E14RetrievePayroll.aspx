<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="E14RetrievePayroll.aspx.cs" Inherits="DatabaseProject.RetrievePayroll" %>
<%@ Register Src="EmployeeNavigationBar.ascx" TagPrefix="uc" TagName="EmpNav" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Payroll</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:EmpNav runat="server" ID="EmpNav" />
        <div class="page-container">

            <div class="page-header">
                <h2>&#128176; My Payroll</h2>
                <p>Your payroll summary for the last month.</p>
            </div>

            <asp:Label ID="errorLabel" runat="server" Text="" CssClass="alert alert-error" ForeColor=""></asp:Label>

            <div class="grid-wrap">
                <asp:GridView ID="payrollGridView" runat="server" AutoGenerateColumns="True"
                    EmptyDataText="No payroll records found for last month."
                    CssClass="" CellPadding="0" GridLines="None">
                </asp:GridView>
            </div>

        </div>
    </form>
</body>
</html>
