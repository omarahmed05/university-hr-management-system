<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="E10EmployeeDashboard.aspx.cs" Inherits="DatabaseProject.EmployeeDashboard" %>
<%@ Register Src="EmployeeNavigationBar.ascx" TagPrefix="uc" TagName="EmpNav" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Dashboard</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:EmpNav runat="server" ID="EmpNav" />

        <div class="page-container">

            <div class="dash-welcome dash-welcome-emp">
                <h2>Welcome back &#128075;</h2>
                <p>Here's everything you can manage from your employee portal.</p>
            </div>

            <div class="action-grid">

                <asp:Button ID="RetrievePerformanceID" runat="server"
                    Text="&#127941;&#10;My Performance"
                    onClick="RetrievePerformance"
                    CssClass="action-card" />

                <asp:Button ID="RetrieveAttendanceID" runat="server"
                    Text="&#128197;&#10;My Attendance"
                    onClick="RetrieveAttendance"
                    CssClass="action-card" />

                <asp:Button ID="RetrievePayrollID" runat="server"
                    Text="&#128176;&#10;My Payroll"
                    onClick="RetrievePayroll"
                    CssClass="action-card" />

                <asp:Button ID="FetchDeductionsID" runat="server"
                    Text="&#128200;&#10;My Deductions"
                    onClick="FetchDeductions"
                    CssClass="action-card" />

                <asp:Button ID="AnnualLeaveApplicationID" runat="server"
                    Text="&#127774;&#10;Annual Leave"
                    onClick="AnnualLeaveApplication"
                    CssClass="action-card" />

                <asp:Button ID="ViewStatusOfLeavesID" runat="server"
                    Text="&#128203;&#10;Leave Status"
                    onClick="ViewStatusOfLeaves"
                    CssClass="action-card" />

                <asp:Button ID="AccidentalLeaveApplicationID" runat="server"
                    Text="&#9889;&#10;Accidental Leave"
                    onClick="AccidentalLeaveApplication"
                    CssClass="action-card" />

                <asp:Button ID="MedicalLeaveApplicationID" runat="server"
                    Text="&#128137;&#10;Medical Leave"
                    OnClick="MedicalLeaveApplication"
                    CssClass="action-card" />

                <asp:Button ID="UnpaidLeaveApplicationID" runat="server"
                    Text="&#128683;&#10;Unpaid Leave"
                    OnClick="UnpaidLeaveApplication"
                    CssClass="action-card" />

                <asp:Button ID="CompensationLeaveApplicationID" runat="server"
                    Text="&#9878;&#10;Compensation Leave"
                    OnClick="CompensationLeaveApplication"
                    CssClass="action-card" />

                <asp:Button ID="ApproveUnpaidLeavesID" runat="server"
                    Text="&#9989;&#10;Approve Unpaid"
                    OnClick="ApproveUnpaidLeaves"
                    CssClass="action-card" Visible="false" />

                <asp:Button ID="ApproveAnnualLeavesID" runat="server"
                    Text="&#9989;&#10;Approve Annual"
                    OnClick="ApproveAnnualLeaves"
                    CssClass="action-card" Visible="false" />

                <asp:Button ID="EvaluateEmployeeID" runat="server"
                    Text="&#11088;&#10;Evaluate Employees"
                    OnClick="EvaluateEmployee"
                    CssClass="action-card" Visible="false" />

            </div>
        </div>
    </form>
</body>
</html>
