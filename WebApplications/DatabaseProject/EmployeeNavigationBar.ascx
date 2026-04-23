<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeNavigationBar.ascx.cs" Inherits="DatabaseProject.EmployeeNavigationBar" %>

<nav class="nav-bar nav-emp">
    <span class="nav-brand">&#127979; UniHR</span>
    <asp:HyperLink ID="lnkDashboard"     runat="server" NavigateUrl="~/E10EmployeeDashboard.aspx">Dashboard</asp:HyperLink>
    <asp:HyperLink ID="lnkPerformance"   runat="server" NavigateUrl="~/E12RetrievePerformance.aspx">Performance</asp:HyperLink>
    <asp:HyperLink ID="lnkAttendance"    runat="server" NavigateUrl="~/E13RetrieveAttendance.aspx">Attendance</asp:HyperLink>
    <asp:HyperLink ID="lnkPayroll"       runat="server" NavigateUrl="~/E14RetrievePayroll.aspx">Payroll</asp:HyperLink>
    <asp:HyperLink ID="lnkDeductions"    runat="server" NavigateUrl="~/E15FetchDeductions.aspx">Deductions</asp:HyperLink>
    <asp:HyperLink ID="lnkAnnualLeave"   runat="server" NavigateUrl="~/E16AnnualLeaveApplication.aspx">Annual Leave</asp:HyperLink>
    <asp:HyperLink ID="lnkLeaveStatus"   runat="server" NavigateUrl="~/E17ViewStatusOfLeaves.aspx">Leave Status</asp:HyperLink>
    <asp:HyperLink ID="lnkAccidentalLeave" runat="server" NavigateUrl="~/E21AccidentalLeaveApplication.aspx">Accidental</asp:HyperLink>
    <asp:HyperLink ID="lnkMedicalLeave"  runat="server" NavigateUrl="~/E22MedicalLeaveApplication.aspx">Medical</asp:HyperLink>
    <asp:HyperLink ID="lnkUnpaidLeave"   runat="server" NavigateUrl="~/E23UnpaidLeaveApplication.aspx">Unpaid</asp:HyperLink>
    <asp:HyperLink ID="lnkCompLeave"     runat="server" NavigateUrl="~/E24CompensationLeaveApplication.aspx">Compensation</asp:HyperLink>
    <asp:HyperLink ID="lnkApproveUnpaid" runat="server" NavigateUrl="~/E25ApproveUnpaidLeaves.aspx" Visible="false">Approve Unpaid</asp:HyperLink>
    <asp:HyperLink ID="lnkApproveAnnual" runat="server" NavigateUrl="~/E26ApproveAnnualLeaves.aspx" Visible="false">Approve Annual</asp:HyperLink>
    <asp:HyperLink ID="lnkEvaluate"      runat="server" NavigateUrl="~/E27EvaluateEmployee.aspx"    Visible="false">Evaluate</asp:HyperLink>
    <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="Logout_Click" CssClass="logout-btn" />
</nav>
