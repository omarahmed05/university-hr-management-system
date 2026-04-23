<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="E24CompensationLeaveApplication.aspx.cs" Inherits="DatabaseProject.CompensationLeaveApplication" %>
<%@ Register Src="EmployeeNavigationBar.ascx" TagPrefix="uc" TagName="EmpNav" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Compensation Leave</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:EmpNav runat="server" ID="EmpNav" />
        <div class="page-container">

            <div class="page-header">
                <h2>&#9878; Apply for Compensation Leave</h2>
                <p>Request a day off in compensation for a previously worked day.</p>
            </div>

            <div class="card" style="max-width:560px">
                <div class="card-title">Compensation Leave Details</div>

                <asp:Label ID="lblResult" runat="server" CssClass="alert alert-error" ForeColor="" Visible="false"></asp:Label>
                <asp:Label ID="lblSuggestion" runat="server" CssClass="alert alert-info" ForeColor="" Visible="false"></asp:Label>
                <asp:HyperLink ID="lnkBack" runat="server" NavigateUrl="academic_dashboard.aspx" style="display:none"></asp:HyperLink>

                <div class="form-grid">
                    <div class="form-group">
                        <label class="form-label">Compensation Date <span class="form-hint">(day off requested)</span></label>
                        <asp:TextBox ID="txtCompensationDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="form-label">Original Work Day <span class="form-hint">(day that was worked)</span></label>
                        <asp:TextBox ID="txtOriginalWorkday" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="form-label">Reason</label>
                    <asp:TextBox ID="txtReason" runat="server" CssClass="form-control" placeholder="Explain why you are requesting this compensation"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label class="form-label">Replacement Employee ID</label>
                    <asp:TextBox ID="txtReplacementID" runat="server" CssClass="form-control" placeholder="ID of your replacement during this leave"></asp:TextBox>
                </div>

                <asp:Button ID="btnSubmit" runat="server" Text="Submit Compensation Leave" OnClick="btnSubmit_Click" CssClass="btn btn-primary btn-lg btn-full" />
            </div>

        </div>
    </form>
</body>
</html>
