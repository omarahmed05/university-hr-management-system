<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="E21AccidentalLeaveApplication.aspx.cs" Inherits="DatabaseProject.AccidentalLeaveApplication" %>
<%@ Register Src="EmployeeNavigationBar.ascx" TagPrefix="uc" TagName="EmpNav" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Accidental Leave</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:EmpNav runat="server" ID="EmpNav" />
        <div class="page-container">

            <div class="page-header">
                <h2>&#9889; Apply for Accidental Leave</h2>
                <p>Submit an emergency accidental leave for a specific date.</p>
            </div>

            <div class="card" style="max-width:480px">
                <div class="card-title">Leave Details</div>

                <asp:Label ID="lblResult" runat="server" CssClass="alert alert-error" ForeColor="" Visible="false"></asp:Label>
                <asp:Label ID="lblSuggestion" runat="server" CssClass="alert alert-info" ForeColor="" Visible="false"></asp:Label>

                <div class="form-group">
                    <label class="form-label">Leave Date</label>
                    <asp:TextBox ID="txtDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                </div>

                <asp:Button ID="btnSubmit" runat="server" Text="Submit Accidental Leave" OnClick="btnSubmit_Click" CssClass="btn btn-primary btn-lg btn-full" />
            </div>

        </div>
    </form>
</body>
</html>
