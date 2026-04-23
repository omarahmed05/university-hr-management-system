<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminNavigationBar.ascx.cs" Inherits="DatabaseProject.AdminNavigationBar" %>

<nav class="nav-bar nav-admin">
    <span class="nav-brand">&#127979; UniHR &mdash; Admin</span>
    <asp:HyperLink ID="lnkDashboard"          runat="server" NavigateUrl="~/A10AdminDashboard.aspx">Dashboard</asp:HyperLink>
    <asp:HyperLink ID="lnkEmployeeProfiles"   runat="server" NavigateUrl="~/A12EmployeeDetails.aspx">Employee Profiles</asp:HyperLink>
    <asp:HyperLink ID="lnkDepartments"        runat="server" NavigateUrl="~/A13NoEmployeePerDept.aspx">Departments</asp:HyperLink>
    <asp:HyperLink ID="lnkUpdateAttendance"   runat="server" NavigateUrl="~/A16UpdateAttendance.aspx">Update Attendance</asp:HyperLink>
    <asp:HyperLink ID="lnkAddHoliday"         runat="server" NavigateUrl="~/A17AddOfficialHoliday.aspx">Add Holiday</asp:HyperLink>
    <asp:HyperLink ID="lnkMedicalLeaves"      runat="server" NavigateUrl="~/A14RejectedMedicalLeave.aspx">Medical Leaves</asp:HyperLink>
    <asp:HyperLink ID="lnkYesterdayAttendance" runat="server" NavigateUrl="~/A21FetchYesterdayAttendance_Click.aspx">Yesterday's Attendance</asp:HyperLink>
    <asp:HyperLink ID="lnkPerformance"        runat="server" NavigateUrl="~/A22FetchPerformanceWinter_Click.aspx">Performance</asp:HyperLink>
    <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="Logout_Click" CssClass="logout-btn" />
</nav>
