<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="E27EvaluateEmployee.aspx.cs" Inherits="DatabaseProject.EvaluateEmployee" %>
<%@ Register Src="EmployeeNavigationBar.ascx" TagPrefix="uc" TagName="EmpNav" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Evaluate Employee</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:EmpNav runat="server" ID="EmpNav" />
        <div class="page-container">

            <div class="page-header">
                <h2>&#11088; Employee Evaluation</h2>
                <p>Submit a performance evaluation for an employee in a given semester.</p>
            </div>

            <div class="card" style="max-width:580px">
                <div class="card-title">Evaluation Form</div>

                <div class="form-grid">
                    <div class="form-group">
                        <label class="form-label">Dean ID</label>
                        <asp:TextBox ID="txtDeanId" runat="server" CssClass="form-control" placeholder="Your Dean ID"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="form-label">Employee ID</label>
                        <asp:TextBox ID="txtEmployeeId" runat="server" CssClass="form-control" placeholder="Employee being evaluated"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="form-label">Rating (1 &ndash; 5)</label>
                        <asp:TextBox ID="txtRating" runat="server" CssClass="form-control" placeholder="1 = Poor, 5 = Excellent"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="form-label">Semester Code</label>
                        <asp:TextBox ID="txtSemester" runat="server" CssClass="form-control" placeholder="e.g. W25, S25"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="form-label">Comments</label>
                    <asp:TextBox ID="txtComments" TextMode="MultiLine" Rows="4" runat="server" CssClass="form-control" placeholder="Provide detailed performance feedback..."></asp:TextBox>
                </div>

                <asp:Button ID="btnSubmit" Text="Submit Evaluation" runat="server" OnClick="btnSubmit_Click" CssClass="btn btn-primary btn-lg btn-full" />

                <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-info mt-4" ForeColor=""></asp:Label>
                <asp:Label ID="lblSteps"   runat="server" CssClass="text-muted-sm mt-2" ForeColor=""></asp:Label>
            </div>

        </div>
    </form>
</body>
</html>
