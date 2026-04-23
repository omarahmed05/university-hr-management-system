<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="E17ViewStatusOfLeaves.aspx.cs" Inherits="DatabaseProject.ViewStatusOfLeaves" %>
<%@ Register Src="EmployeeNavigationBar.ascx" TagPrefix="uc" TagName="EmpNav" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Leave Status</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:EmpNav runat="server" ID="EmpNav" />
        <div class="page-container">

            <div class="page-header">
                <h2>&#128203; Status of Leaves</h2>
                <p>Track the status of your annual and accidental leave requests.</p>
            </div>

            <asp:Label ID="errorLabel" runat="server" Text="" CssClass="alert alert-error" ForeColor=""></asp:Label>

            <div class="grid-wrap">
                <asp:GridView ID="leaveStatusGridView" runat="server" AutoGenerateColumns="True"
                    EmptyDataText="No leave requests found."
                    CssClass="" CellPadding="0" GridLines="None">
                </asp:GridView>
            </div>

        </div>
    </form>
</body>
</html>
