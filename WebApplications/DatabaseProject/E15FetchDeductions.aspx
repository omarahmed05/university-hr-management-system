<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="E15FetchDeductions.aspx.cs" Inherits="DatabaseProject.FetchDeductions" %>
<%@ Register Src="EmployeeNavigationBar.ascx" TagPrefix="uc" TagName="EmpNav" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Deductions</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:EmpNav runat="server" ID="EmpNav" />
        <div class="page-container">

            <div class="page-header">
                <h2>&#128200; My Deductions</h2>
                <p>View salary deductions for a specific month.</p>
            </div>

            <div class="card">
                <div class="card-title">Filter by Month</div>
                <div class="form-group">
                    <label class="form-label">Month (1 &ndash; 12)</label>
                    <div class="d-flex gap-3 flex-wrap align-center">
                        <asp:TextBox ID="month" runat="server" CssClass="form-control" placeholder="e.g. 3 for March" style="max-width:200px"></asp:TextBox>
                        <asp:Button ID="ShowDeductionsID" runat="server" Text="Show Deductions" onClick="ShowDeductions" CssClass="btn btn-primary" />
                    </div>
                    <asp:Label ID="errorLabel" runat="server" Text="" CssClass="alert alert-error mt-4" ForeColor=""></asp:Label>
                </div>
            </div>

            <div class="grid-wrap">
                <asp:GridView ID="deductionsGridView" runat="server" AutoGenerateColumns="True"
                    EmptyDataText="No deduction records found for this month."
                    CssClass="" CellPadding="0" GridLines="None">
                </asp:GridView>
            </div>

        </div>
    </form>
</body>
</html>
