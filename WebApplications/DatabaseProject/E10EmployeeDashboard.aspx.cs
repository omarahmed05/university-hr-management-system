using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseProject
{
    public partial class EmployeeDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["role"] == null || (Session["role"].ToString() != "employee" && Session["role"].ToString() != "Dean" && Session["role"].ToString() != "Vice Dean" && Session["role"].ToString() != "President"))
            {
                if (Session["role"].ToString() == "Dean" || Session["role"].ToString() == "Vice Dean" || Session["role"].ToString() == "President")
                {
                    ApproveAnnualLeavesID.Visible = true;
                    ApproveUnpaidLeavesID.Visible = true;
                }

                if (Session["role"].ToString() == "Dean")
                {
                    EvaluateEmployeeID.Visible = true;
                }

                Response.Redirect("HomePage.aspx");
            }
        }

        protected void RetrievePerformance(object sender, EventArgs e)
        {
            Response.Redirect("E12RetrievePerformance.aspx");
        }

        protected void RetrieveAttendance(object sender, EventArgs e)
        {
            Response.Redirect("E13RetrieveAttendance.aspx");
        }

        protected void RetrievePayroll(object sender, EventArgs e)
        {
            Response.Redirect("E14RetrievePayroll.aspx");
        }

        protected void FetchDeductions(object sender, EventArgs e)
        {
            Response.Redirect("E15FetchDeductions.aspx");
        }

        protected void AnnualLeaveApplication(object sender, EventArgs e)
        {
            Response.Redirect("E16AnnualLeaveApplication.aspx");
        }

        protected void ViewStatusOfLeaves(object sender, EventArgs e)
        {
            Response.Redirect("E17ViewStatusOfLeaves.aspx");
        }

        protected void AccidentalLeaveApplication(object sender, EventArgs e)
        {
            Response.Redirect("E21AccidentalLeaveApplication.aspx");
        }

        protected void MedicalLeaveApplication(object sender, EventArgs e)
        {
            Response.Redirect("E22MedicalLeaveApplication.aspx");
        }

        protected void UnpaidLeaveApplication(object sender, EventArgs e)
        {
            Response.Redirect("E23UnpaidLeaveApplication.aspx");
        }

        protected void CompensationLeaveApplication(object sender, EventArgs e)
        {
            Response.Redirect("E24CompensationLeaveApplication.aspx");
        }

        protected void ApproveUnpaidLeaves(object sender, EventArgs e)
        {
            Response.Redirect("E25ApproveUnpaidLeaves.aspx");
        }

        protected void ApproveAnnualLeaves(object sender, EventArgs e)
        {
            Response.Redirect("E26ApproveAnnualLeaves.aspx");
        }

        protected void EvaluateEmployee(object sender, EventArgs e)
        {
            Response.Redirect("E27EvaluateEmployee.aspx");
        }
    }
}