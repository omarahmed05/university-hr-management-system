<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="H00HRDashboard.aspx.cs" Inherits="DatabaseProject.HRDashboard" %>
<%@ Register Src="HRNavigationBar.ascx" TagPrefix="uc" TagName="HRNav" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HR Dashboard</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:HRNav runat="server" ID="HRNav" />

        <div class="page-container">

            <div class="dash-welcome dash-welcome-hr">
                <h2>HR Management Panel &#128203;</h2>
                <p>Process leave requests, manage deductions, and generate payroll.</p>
            </div>

            <!-- Leave Management -->
            <div class="card">
                <div class="card-title">&#127774; Leave Management</div>

                <div class="form-group">
                    <label class="form-label">Leave Request ID</label>
                    <asp:TextBox ID="txtLeaveRequestID" runat="server" TextMode="Number" CssClass="form-control form-control-hr" placeholder="Enter leave request ID" style="max-width:280px"></asp:TextBox>
                    <asp:Label ID="lblLeaveID" runat="server" Text="" style="display:none"></asp:Label>
                </div>

                <div class="d-flex gap-3 flex-wrap">
                    <asp:Button ID="btnApproveAnnual" runat="server" Text="Approve / Reject Annual &amp; Accidental Leave"
                        OnClick="ApproveAnnualLeave" CssClass="btn btn-hr" />
                    <asp:Button ID="btnApproveUnpaid" runat="server" Text="Approve / Reject Unpaid Leave"
                        OnClick="ApproveUnpaidLeave" CssClass="btn btn-hr" />
                    <asp:Button ID="btnApproveComp" runat="server" Text="Approve / Reject Compensation Leave"
                        OnClick="ApproveCompensationLeave" CssClass="btn btn-hr" />
                </div>
            </div>

            <!-- Deduction Management -->
            <div class="card">
                <div class="card-title">&#128200; Deduction Management</div>

                <div class="form-group">
                    <label class="form-label">Target Employee ID</label>
                    <asp:TextBox ID="txtTargetEmployeeID" runat="server" TextMode="Number" CssClass="form-control form-control-hr" placeholder="Enter employee ID" style="max-width:280px"></asp:TextBox>
                    <asp:Label ID="lblEmpID" runat="server" Text="" style="display:none"></asp:Label>
                </div>

                <div class="d-flex gap-3 flex-wrap">
                    <asp:Button ID="btnAddDedHours" runat="server" Text="&#43; Deduction: Missing Hours"
                        OnClick="AddDeductionHours" CssClass="btn btn-danger" />
                    <asp:Button ID="btnAddDedDays" runat="server" Text="&#43; Deduction: Missing Days"
                        OnClick="AddDeductionDays" CssClass="btn btn-danger" />
                    <asp:Button ID="btnAddDedUnpaid" runat="server" Text="&#43; Deduction: Unpaid Leave"
                        OnClick="AddDeductionUnpaid" CssClass="btn btn-danger" />
                </div>
            </div>

            <!-- Payroll Management -->
            <div class="card">
                <div class="card-title">&#128176; Payroll Management</div>
                <p class="text-muted-sm mb-4">Uses the Target Employee ID entered in the Deduction section above.</p>

                <div class="form-grid" style="max-width:560px">
                    <div class="form-group">
                        <label class="form-label">From Date</label>
                        <asp:TextBox ID="txtPayrollFrom" runat="server" TextMode="Date" CssClass="form-control form-control-hr"></asp:TextBox>
                        <asp:Label ID="lblFromDate" runat="server" Text="" style="display:none"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label class="form-label">To Date</label>
                        <asp:TextBox ID="txtPayrollTo" runat="server" TextMode="Date" CssClass="form-control form-control-hr"></asp:TextBox>
                        <asp:Label ID="lblToDate" runat="server" Text="" style="display:none"></asp:Label>
                    </div>
                </div>

                <asp:Button ID="btnGenPayroll" runat="server" Text="Generate Monthly Payroll" OnClick="GeneratePayroll" CssClass="btn btn-hr btn-lg" />
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="alert alert-error mt-4" ForeColor=""></asp:Label>
            </div>

        </div>
    </form>
</body>
</html>
