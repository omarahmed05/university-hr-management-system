<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="E16AnnualLeaveApplication.aspx.cs" Inherits="DatabaseProject.AnnualLeaveApplication" %>
<%@ Register Src="EmployeeNavigationBar.ascx" TagPrefix="uc" TagName="EmpNav" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Annual Leave Application</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:EmpNav runat="server" ID="EmpNav" />
        <div class="page-container">

            <div class="page-header">
                <h2>&#127774; Apply for Annual Leave</h2>
                <p>Submit an annual leave request with your replacement and dates.</p>
            </div>

            <div class="card" style="max-width:560px">
                <div class="card-title">Leave Details</div>

                <div class="form-group">
                    <label class="form-label">Replacement Employee ID</label>
                    <asp:TextBox ID="replacementEmpID" runat="server" CssClass="form-control" placeholder="Enter replacement employee ID"></asp:TextBox>
                </div>

                <div class="form-grid">
                    <div class="form-group">
                        <label class="form-label">Start Date</label>
                        <asp:TextBox ID="startDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="form-label">End Date</label>
                        <asp:TextBox ID="endDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <asp:Button ID="submitButton" runat="server" Text="Submit Annual Leave Request" OnClick="SubmitAnnualLeave" CssClass="btn btn-primary btn-lg btn-full" />
                <asp:Label ID="messageLabel" runat="server" CssClass="alert alert-success mt-4" ForeColor=""></asp:Label>
            </div>

        </div>
    </form>
</body>
</html>
