<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A13NoEmployeePerDept.aspx.cs" Inherits="DatabaseProject.NoEmployeePerDept" %>
<%@ Register Src="AdminNavigationBar.ascx" TagPrefix="uc" TagName="AdminNav" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees Per Department</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:AdminNav runat="server" ID="AdminNav" />
        <div class="page-container">

            <div class="page-header">
                <h2>&#127970; Employees per Department</h2>
                <p>Headcount breakdown across all university departments.</p>
            </div>

            <div class="grid-wrap">
                <asp:GridView ID="perGrid" runat="server" AutoGenerateColumns="true"
                    CssClass="" CellPadding="0" GridLines="None">
                </asp:GridView>
            </div>

        </div>
    </form>
</body>
</html>
