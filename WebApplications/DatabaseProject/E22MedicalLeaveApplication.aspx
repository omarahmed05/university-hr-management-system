<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="E22MedicalLeaveApplication.aspx.cs" Inherits="DatabaseProject.MedicalLeaveApplication" %>
<%@ Register Src="EmployeeNavigationBar.ascx" TagPrefix="uc" TagName="EmpNav" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Medical Leave</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <uc:EmpNav runat="server" ID="EmpNav" />
        <div class="page-container">

            <div class="page-header">
                <h2>&#128137; Apply for Medical Leave</h2>
                <p>Submit a medical or maternity leave request with supporting documentation.</p>
            </div>

            <div class="card" style="max-width:600px">
                <div class="card-title">Medical Leave Details</div>

                <asp:Label ID="lblResult" runat="server" CssClass="alert alert-error" ForeColor="" Visible="false"></asp:Label>
                <asp:Label ID="lblSuggestion" runat="server" CssClass="alert alert-info" ForeColor="" Visible="false"></asp:Label>

                <div class="form-grid">
                    <div class="form-group">
                        <label class="form-label">Start Date</label>
                        <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="form-label">End Date</label>
                        <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="form-label">Leave Type</label>
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control">
                        <asp:ListItem Value="">Select leave type</asp:ListItem>
                        <asp:ListItem Value="sick">Sick Leave</asp:ListItem>
                        <asp:ListItem Value="maternity">Maternity Leave</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <label class="form-label">Insurance Coverage</label>
                    <div class="d-flex gap-3 align-center">
                        <asp:CheckBox ID="cbInsurance" runat="server" />
                        <span class="text-muted-sm">Covered by insurance</span>
                    </div>
                </div>

                <div class="form-group">
                    <label class="form-label">Disability Details <span class="text-muted-sm">(if applicable)</span></label>
                    <asp:TextBox ID="txtDisability" runat="server" CssClass="form-control" placeholder="Describe any disability (optional)"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label class="form-label">Medical Document</label>
                    <asp:FileUpload ID="fuDocument" runat="server" CssClass="form-control" />
                </div>

                <div class="form-group">
                    <label class="form-label">Document Description</label>
                    <asp:TextBox ID="txtDocDescription" runat="server" CssClass="form-control" placeholder="Briefly describe the uploaded document"></asp:TextBox>
                </div>

                <asp:Button ID="btnSubmit" runat="server" Text="Submit Medical Leave" OnClick="btnSubmit_Click" CssClass="btn btn-primary btn-lg btn-full" />
            </div>

        </div>
    </form>
</body>
</html>
