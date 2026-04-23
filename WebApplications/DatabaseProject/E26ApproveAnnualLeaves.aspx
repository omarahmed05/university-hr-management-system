<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="E26ApproveAnnualLeaves.aspx.cs" Inherits="DatabaseProject.ApproveAnnualLeaves" %>
<%@ Register Src="EmployeeNavigationBar.ascx" TagPrefix="uc" TagName="EmpNav" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Approve Annual Leave</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:EmpNav runat="server" ID="EmpNav" />
        <div class="page-container">

            <div class="page-header">
                <h2>&#9989; Approve / Reject Annual Leave</h2>
                <p>Review and action annual leave requests submitted by employees.</p>
            </div>

            <div class="card" style="max-width:520px">
                <div class="card-title">Leave Decision</div>

                <asp:Label ID="lblResult" runat="server" CssClass="alert alert-error" ForeColor="" Visible="false"></asp:Label>
                <asp:Label ID="lblSuggestion" runat="server" CssClass="alert alert-info" ForeColor="" Visible="false"></asp:Label>
                <asp:HyperLink ID="lnkBack" runat="server" NavigateUrl="academic_dashboard.aspx" style="display:none"></asp:HyperLink>

                <div class="form-group">
                    <label class="form-label">Your Role</label>
                    <asp:DropDownList ID="ddlApprover" runat="server" CssClass="form-control">
                        <asp:ListItem Value="11">Dean (Hazem Ali &mdash; ID 11)</asp:ListItem>
                        <asp:ListItem Value="12">Vice Dean (Hadeel Adel &mdash; ID 12)</asp:ListItem>
                        <asp:ListItem Value="15">President (Karim Abdelaziz &mdash; ID 15)</asp:ListItem>
                        <asp:ListItem Value="16">Vice President (Ghada Adel &mdash; ID 16)</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <label class="form-label">Leave Request ID</label>
                    <asp:TextBox ID="txtRequestId" runat="server" CssClass="form-control" placeholder="Enter the request ID"></asp:TextBox>
                </div>

                <div class="d-flex gap-3">
                    <asp:Button ID="btnApprove" runat="server" Text="&#9989; Approve" OnClick="btnApprove_Click" CssClass="btn btn-success" />
                    <asp:Button ID="btnReject"  runat="server" Text="&#10060; Reject"  OnClick="btnReject_Click"  CssClass="btn btn-danger" />
                </div>
            </div>

        </div>
    </form>
</body>
</html>
