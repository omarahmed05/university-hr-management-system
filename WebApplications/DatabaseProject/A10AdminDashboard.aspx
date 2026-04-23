<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A10AdminDashboard.aspx.cs" Inherits="DatabaseProject.AdminDashboard" %>
<%@ Register Src="AdminNavigationBar.ascx" TagPrefix="uc" TagName="AdminNav" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:AdminNav runat="server" ID="AdminNav" />

        <div class="page-container">

            <div class="dash-welcome dash-welcome-admin">
                <h2>Admin Control Panel &#128737;</h2>
                <p>Manage employees, attendance, holidays and departmental operations.</p>
            </div>

            <!-- Quick Actions -->
            <div class="card">
                <div class="card-title">&#128640; Quick Actions</div>
                <div class="action-grid">
                    <asp:Button ID="Button1" runat="server" Text="Employee Profiles" OnClick="b1" CssClass="action-card" />
                    <asp:Button ID="Button5" runat="server" Text="Update Attendance" OnClick="b5" CssClass="action-card" />
                    <asp:Button ID="Button4" runat="server" Text="Remove Deductions" OnClick="b4" CssClass="action-card" />
                    <asp:Button ID="Button2" runat="server" Text="Employees Per Dept" OnClick="b2" CssClass="action-card" />
                    <asp:Button ID="Button7" runat="server" Text="Initiate Attendance" OnClick="b7" CssClass="action-card" />
                    <asp:Button ID="Button6" runat="server" Text="Add Official Holiday" OnClick="b6" CssClass="action-card" />
                    <asp:Button ID="Button3" runat="server" Text="Rejected Medical Leaves" OnClick="b3" CssClass="action-card" />
                    <asp:Button ID="Btn_FetchYesterdayAttendance" runat="server" Text="Yesterday's Attendance" OnClick="FetchYesterdayAttendance_Click" CssClass="action-card" />
                    <asp:Button ID="Button8" runat="server" Text="Winter Performance" OnClick="FetchPerformanceWinter_Click" CssClass="action-card" />
                    <asp:Button ID="Button9" runat="server" Text="Remove Holiday Attendance" OnClick="RemoveAttendanceHoliday_Click" CssClass="action-card" />
                </div>
                <asp:Label ID="Label8" runat="server" CssClass="msg-success mt-4" ForeColor=""></asp:Label>
                <asp:Label ID="z" runat="server" Text="" CssClass="msg-success mt-2" ForeColor=""></asp:Label>
                <asp:Label ID="l" runat="server" Text="" CssClass="msg-success mt-2" ForeColor=""></asp:Label>
            </div>

            <!-- Attendance Adjustments -->
            <div class="card">
                <div class="card-title">&#128197; Attendance Adjustments</div>

                <div class="form-group">
                    <label class="form-label">Employee ID &mdash; Remove Unattended Day-off</label>
                    <div class="d-flex gap-3 flex-wrap align-center">
                        <asp:TextBox ID="empid1" runat="server" CssClass="form-control" placeholder="Employee ID" style="max-width:220px"></asp:TextBox>
                        <asp:Button ID="Button10" runat="server" Text="Remove Unattended Day-off" OnClick="RemoveUnattendedDayoff_Click" CssClass="btn btn-admin" />
                    </div>
                    <asp:Label ID="DayOffMessageLabel" runat="server" CssClass="alert alert-error mt-2" ForeColor=""></asp:Label>
                </div>

                <hr class="divider" />

                <div class="form-group">
                    <label class="form-label">Employee ID &mdash; Remove Approved Leave Attendance</label>
                    <div class="d-flex gap-3 flex-wrap align-center">
                        <asp:TextBox ID="empid2" runat="server" CssClass="form-control" placeholder="Employee ID" style="max-width:220px"></asp:TextBox>
                        <asp:Button ID="Button11" runat="server" Text="Remove Approved Leave" OnClick="RemoveApprovedDayoff_Click" CssClass="btn btn-admin" />
                    </div>
                    <asp:Label ID="ApprovedLeaveMessageLabel" runat="server" CssClass="alert alert-error mt-2" ForeColor=""></asp:Label>
                </div>
            </div>

            <!-- Employee Replacement -->
            <div class="card">
                <div class="card-title">&#128257; Employee Replacement</div>

                <div class="form-grid">
                    <div class="form-group">
                        <label class="form-label">Employee Being Replaced (ID)</label>
                        <asp:TextBox ID="empid3" runat="server" CssClass="form-control" placeholder="Employee ID 1"></asp:TextBox>
                        <asp:Label ID="Label3" runat="server" Text="" style="display:none"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label class="form-label">Replacement Employee (ID)</label>
                        <asp:TextBox ID="empid4" runat="server" CssClass="form-control" placeholder="Employee ID 2"></asp:TextBox>
                        <asp:Label ID="Label4" runat="server" Text="" style="display:none"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label class="form-label">From Date</label>
                        <asp:TextBox ID="TextBox1" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="Label5" runat="server" Text="" style="display:none"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label class="form-label">To Date</label>
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="Label6" runat="server" Text="" style="display:none"></asp:Label>
                    </div>
                </div>

                <asp:Button ID="Button12" runat="server" Text="Replace Employees" OnClick="ReplaceEmployees_Click" CssClass="btn btn-admin" />
                <asp:Label ID="MessageLabel" runat="server" CssClass="alert alert-error mt-4" ForeColor=""></asp:Label>
            </div>

            <!-- Employment Status -->
            <div class="card">
                <div class="card-title">&#128221; Update Employment Status</div>
                <div class="form-group">
                    <label class="form-label">Employee ID</label>
                    <div class="d-flex gap-3 flex-wrap align-center">
                        <asp:TextBox ID="StatusEmpIdTextBox" runat="server" CssClass="form-control" placeholder="Enter Employee ID" style="max-width:220px"></asp:TextBox>
                        <asp:Button ID="StatusUpdateButton" runat="server" Text="Update Status" OnClick="UpdateEmploymentStatus_Click" CssClass="btn btn-admin" />
                    </div>
                    <asp:Label ID="Label7" runat="server" Text="" style="display:none"></asp:Label>
                    <asp:Label ID="Label1" runat="server" Text="" style="display:none"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="" style="display:none"></asp:Label>
                </div>
                <asp:Label ID="StatusMessageLabel" runat="server" CssClass="alert alert-error mt-2" ForeColor=""></asp:Label>
            </div>

        </div>
    </form>
</body>
</html>
