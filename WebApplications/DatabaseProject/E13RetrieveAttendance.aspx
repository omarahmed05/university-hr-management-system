<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="E13RetrieveAttendance.aspx.cs" Inherits="DatabaseProject.RetrieveAttendance" %>
<%@ Register Src="EmployeeNavigationBar.ascx" TagPrefix="uc" TagName="EmpNav" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Attendance</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:EmpNav runat="server" ID="EmpNav" />
        <div class="page-container">

            <div class="page-header">
                <h2>&#128197; My Attendance</h2>
                <p>Your attendance records for the current month.</p>
            </div>

            <asp:Label ID="errorLabel" runat="server" Text="" CssClass="alert alert-error" ForeColor=""></asp:Label>

            <div class="grid-wrap">
                <asp:GridView ID="attendanceGridView" runat="server" AutoGenerateColumns="True"
                    EmptyDataText="No attendance records found for this month."
                    CssClass="" CellPadding="0" GridLines="None">
                </asp:GridView>
            </div>

        </div>
    </form>
</body>
</html>
