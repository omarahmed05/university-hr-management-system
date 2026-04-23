<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HRNavigationBar.ascx.cs" Inherits="DatabaseProject.HRNavigationBar" %>

<nav class="nav-bar nav-hr">
    <span class="nav-brand">&#127979; UniHR &mdash; HR</span>
    <asp:HyperLink ID="lnkDashboard" runat="server" NavigateUrl="~/H00HRDashboard.aspx">Dashboard</asp:HyperLink>
    <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="Logout_Click" CssClass="logout-btn" />
</nav>
