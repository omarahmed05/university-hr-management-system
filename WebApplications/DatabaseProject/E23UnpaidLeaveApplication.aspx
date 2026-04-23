<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="E23UnpaidLeaveApplication.aspx.cs" Inherits="DatabaseProject.UnpaidLeaveApplication" %>
<%@ Register Src="EmployeeNavigationBar.ascx" TagPrefix="uc" TagName="EmpNav" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Unpaid Leave</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:EmpNav runat="server" ID="EmpNav" />
        <div class="page-container">

            <div class="page-header">
                <h2>&#128683; Apply for Unpaid Leave</h2>
                <p>Submit an unpaid leave request with supporting memo and documentation.</p>
            </div>

            <div class="card" style="max-width:560px">
                <div class="card-title">Leave Details</div>

                <asp:Label ID="lblResult" runat="server" CssClass="alert alert-error" ForeColor="" Visible="false"></asp:Label>
                <asp:Label ID="lblSuggestion" runat="server" CssClass="alert alert-info" ForeColor="" Visible="false"></asp:Label>
                <asp:HyperLink ID="lnkBack" runat="server" NavigateUrl="academic_dashboard.aspx" style="display:none"></asp:HyperLink>

                <div class="form-grid">
                    <div class="form-group">
                        <label class="form-label">Start Date</label>
                        <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="form-label">End Date</label>
                        <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="form-label">Memo / Reason</label>
                    <asp:TextBox ID="txtDocDescription" runat="server" CssClass="form-control" placeholder="Describe the reason for unpaid leave"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label class="form-label">Supporting File Name</label>
                    <asp:TextBox ID="txtFileName" runat="server" CssClass="form-control" placeholder="e.g. leave_memo.pdf"></asp:TextBox>
                </div>

                <asp:Button ID="btnSubmit" runat="server" Text="Submit Unpaid Leave" OnClick="btnSubmit_Click" CssClass="btn btn-primary btn-lg btn-full" />
            </div>

        </div>
    </form>
</body>
</html>
