<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A12EmployeeDetails.aspx.cs" Inherits="DatabaseProject.EmployeeDetails" %>
<%@ Register Src="AdminNavigationBar.ascx" TagPrefix="uc" TagName="AdminNav" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Profiles</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:AdminNav runat="server" ID="AdminNav" />
        <div class="page-container">

            <div class="page-header">
                <h2>&#128101; Employee Profiles</h2>
                <p>Complete list of all employees in the system.</p>
            </div>

            <div class="grid-wrap">
                <asp:GridView ID="EmployeeGrid" runat="server" AutoGenerateColumns="true"
                    CssClass="" CellPadding="0" GridLines="None">
                </asp:GridView>
            </div>

        </div>
    </form>
</body>
</html>
