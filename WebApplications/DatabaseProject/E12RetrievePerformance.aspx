<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="E12RetrievePerformance.aspx.cs" Inherits="DatabaseProject.RetrievePerformance" %>
<%@ Register Src="EmployeeNavigationBar.ascx" TagPrefix="uc" TagName="EmpNav" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Performance</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:EmpNav runat="server" ID="EmpNav" />
        <div class="page-container">

            <div class="page-header">
                <h2>&#127941; Semester Performance</h2>
                <p>View your performance evaluation for a given semester.</p>
            </div>

            <div class="card">
                <div class="card-title">Search by Semester</div>
                <div class="form-group">
                    <label class="form-label">Semester Code (e.g. W25, S25)</label>
                    <div class="d-flex gap-3 flex-wrap align-center">
                        <asp:TextBox ID="semester" runat="server" CssClass="form-control" placeholder="Enter semester code" style="max-width:260px"></asp:TextBox>
                        <asp:Button ID="showPerformanceButton" runat="server" Text="Show Performance" onClick="ShowPerformance" CssClass="btn btn-primary" />
                    </div>
                    <asp:Label ID="errorLabel" runat="server" Text="" CssClass="alert alert-error mt-4" ForeColor=""></asp:Label>
                </div>
            </div>

            <div class="grid-wrap">
                <asp:GridView ID="performanceGridView" runat="server" AutoGenerateColumns="True"
                    EmptyDataText="No performance records found for this semester."
                    CssClass="" CellPadding="0" GridLines="None"
                    HeaderStyle-CssClass="" RowStyle-CssClass="" AlternatingRowStyle-CssClass="">
                </asp:GridView>
            </div>

        </div>
    </form>
</body>
</html>
