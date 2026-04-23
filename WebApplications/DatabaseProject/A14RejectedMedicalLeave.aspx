<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A14RejectedMedicalLeave.aspx.cs" Inherits="DatabaseProject.RejectedMedicalLeave" %>
<%@ Register Src="AdminNavigationBar.ascx" TagPrefix="uc" TagName="AdminNav" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rejected Medical Leaves</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:AdminNav runat="server" ID="AdminNav" />
        <div class="page-container">

            <div class="page-header">
                <h2>&#128137; Rejected Medical Leaves</h2>
                <p>All medical leave requests that have been rejected.</p>
            </div>

            <div class="grid-wrap">
                <asp:GridView ID="medGrid" runat="server" AutoGenerateColumns="true"
                    CssClass="" CellPadding="0" GridLines="None">
                </asp:GridView>
            </div>

        </div>
    </form>
</body>
</html>
