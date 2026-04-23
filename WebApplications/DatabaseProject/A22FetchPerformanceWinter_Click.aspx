<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A22FetchPerformanceWinter_Click.aspx.cs" Inherits="DatabaseProject.FetchPerformanceWinter_Click" %>
<%@ Register Src="AdminNavigationBar.ascx" TagPrefix="uc" TagName="AdminNav" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Winter Performance</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:AdminNav runat="server" ID="AdminNav" />
        <div class="page-container">

            <div class="page-header">
                <h2>&#127968; Winter Semester Performance</h2>
                <p>Employee performance records across all winter semesters.</p>
            </div>

            <div class="grid-wrap">
                <asp:GridView ID="PerformanceGridView" runat="server" AutoGenerateColumns="True"
                    EmptyDataText="No performance records for any winter semester."
                    CssClass="" CellPadding="0" GridLines="None">
                </asp:GridView>
            </div>

        </div>
    </form>
</body>
</html>
