<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A16UpdateAttendance.aspx.cs" Inherits="DatabaseProject.UpdateAttendance" %>
<%@ Register Src="AdminNavigationBar.ascx" TagPrefix="uc" TagName="AdminNav" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Attendance</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:AdminNav runat="server" ID="AdminNav" />
        <div class="page-container">

            <div class="page-header">
                <h2>&#128197; Update Attendance</h2>
                <p>Manually update an employee's check-in and check-out times.</p>
            </div>

            <div class="card" style="max-width:480px">
                <div class="card-title">Attendance Record</div>

                <div class="form-group">
                    <label class="form-label">Employee ID</label>
                    <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control" placeholder="Enter employee ID"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text="" style="display:none"></asp:Label>
                </div>

                <div class="form-grid">
                    <div class="form-group">
                        <label class="form-label">Check In Time</label>
                        <asp:TextBox ID="TextBox22" runat="server" TextMode="Time" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="Label2" runat="server" Text="" style="display:none"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label class="form-label">Check Out Time</label>
                        <asp:TextBox ID="TextBox33" runat="server" TextMode="Time" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="Label3" runat="server" Text="" style="display:none"></asp:Label>
                    </div>
                </div>

                <asp:Button ID="Button1" runat="server" Text="Update Attendance" OnClick="c1" CssClass="btn btn-admin btn-lg btn-full" />
                <asp:Label ID="labelout" runat="server" Text="" CssClass="alert alert-success mt-4" ForeColor=""></asp:Label>
            </div>

        </div>
    </form>
</body>
</html>
