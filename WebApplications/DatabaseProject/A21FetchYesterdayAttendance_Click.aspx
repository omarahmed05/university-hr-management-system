<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A21FetchYesterdayAttendance_Click.aspx.cs" Inherits="DatabaseProject.FetchYesterdayAttendance_Click" %>
<%@ Register Src="AdminNavigationBar.ascx" TagPrefix="uc" TagName="AdminNav" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yesterday's Attendance</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:AdminNav runat="server" ID="AdminNav" />
        <div class="page-container">

            <div class="page-header">
                <h2>&#128197; Yesterday's Attendance</h2>
                <p>Attendance records logged for yesterday.</p>
            </div>

            <div class="grid-wrap">
                <asp:GridView ID="attendanceGridView" runat="server" AutoGenerateColumns="True"
                    EmptyDataText="No attendance records found for yesterday."
                    CssClass="" CellPadding="0" GridLines="None">
                </asp:GridView>
            </div>

        </div>
    </form>
</body>
</html>
