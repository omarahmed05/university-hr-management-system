<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A17AddOfficialHoliday.aspx.cs" Inherits="DatabaseProject.AddOfficialHoliday" %>
<%@ Register Src="AdminNavigationBar.ascx" TagPrefix="uc" TagName="AdminNav" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Official Holiday</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:AdminNav runat="server" ID="AdminNav" />
        <div class="page-container">

            <div class="page-header">
                <h2>&#127956; Add Official Holiday</h2>
                <p>Register an official university holiday to exclude it from attendance tracking.</p>
            </div>

            <div class="card" style="max-width:520px">
                <div class="card-title">Holiday Details</div>

                <div class="form-group">
                    <label class="form-label">Holiday Name</label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="e.g. National Day, Eid Al-Adha"></asp:TextBox>
                    <asp:Label ID="Labol1" runat="server" Text="" style="display:none"></asp:Label>
                </div>

                <div class="form-grid">
                    <div class="form-group">
                        <label class="form-label">From Date</label>
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="Labol2" runat="server" Text="" style="display:none"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label class="form-label">To Date</label>
                        <asp:TextBox ID="TextBox3" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="Labol3" runat="server" Text="" style="display:none"></asp:Label>
                    </div>
                </div>

                <asp:Button ID="Button1" runat="server" Text="Add Holiday" OnClick="b11" CssClass="btn btn-admin btn-lg btn-full" />
                <asp:Label ID="l2" runat="server" Text="" CssClass="alert alert-success mt-4" ForeColor=""></asp:Label>
            </div>

        </div>
    </form>
</body>
</html>
