using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseProject
{
    public partial class HRDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["role"] == null || Session["role"].ToString() != "HR")
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        private void ExecuteHRProcedure(string procedureName, SqlParameter[] parameters)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(procedureName, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Action completed successfully!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                catch (SqlException sqlEx)
                {
                    lblMessage.Text = "Database Error: " + sqlEx.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void ApproveAnnualLeave(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            if (String.IsNullOrWhiteSpace(txtLeaveRequestID.Text))
            {
                lblMessage.Text = "Please enter a Leave Request ID.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int requestID;
            if (!int.TryParse(txtLeaveRequestID.Text, out requestID))
            {
                lblMessage.Text = "Please enter a valid numeric Request ID.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@request_ID", requestID),
                new SqlParameter("@HR_ID", Convert.ToInt32(Session["user"]))
            };

            ExecuteHRProcedure("HR_approval_an_acc", p);
            txtLeaveRequestID.Text = "";
        }

        protected void ApproveUnpaidLeave(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            if (String.IsNullOrWhiteSpace(txtLeaveRequestID.Text))
            {
                lblMessage.Text = "Please enter a Leave Request ID.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int requestID;
            if (!int.TryParse(txtLeaveRequestID.Text, out requestID))
            {
                lblMessage.Text = "Please enter a valid numeric Request ID.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@request_ID", requestID),
                new SqlParameter("@HR_ID", Convert.ToInt32(Session["user"]))
            };

            ExecuteHRProcedure("HR_approval_Unpaid", p);
            txtLeaveRequestID.Text = "";
        }

        protected void ApproveCompensationLeave(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            if (String.IsNullOrWhiteSpace(txtLeaveRequestID.Text))
            {
                lblMessage.Text = "Please enter a Leave Request ID.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int requestID;
            if (!int.TryParse(txtLeaveRequestID.Text, out requestID))
            {
                lblMessage.Text = "Please enter a valid numeric Request ID.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@request_ID", requestID),
                new SqlParameter("@HR_ID", Convert.ToInt32(Session["user"]))
            };

            ExecuteHRProcedure("HR_approval_comp", p);
            txtLeaveRequestID.Text = "";
        }

        protected void AddDeductionHours(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            if (String.IsNullOrWhiteSpace(txtTargetEmployeeID.Text))
            {
                lblMessage.Text = "Please enter a Target Employee ID.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int empID;
            if (!int.TryParse(txtTargetEmployeeID.Text, out empID))
            {
                lblMessage.Text = "Please enter a valid numeric Employee ID.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@employee_ID", empID)
            };

            ExecuteHRProcedure("Deduction_hours", p);
        }

        protected void AddDeductionDays(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            if (String.IsNullOrWhiteSpace(txtTargetEmployeeID.Text))
            {
                lblMessage.Text = "Please enter a Target Employee ID.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int empID;
            if (!int.TryParse(txtTargetEmployeeID.Text, out empID))
            {
                lblMessage.Text = "Please enter a valid numeric Employee ID.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@employee_ID", empID)
            };

            ExecuteHRProcedure("Deduction_days", p);
        }

        protected void AddDeductionUnpaid(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            if (String.IsNullOrWhiteSpace(txtTargetEmployeeID.Text))
            {
                lblMessage.Text = "Please enter a Target Employee ID.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int empID;
            if (!int.TryParse(txtTargetEmployeeID.Text, out empID))
            {
                lblMessage.Text = "Please enter a valid numeric Employee ID.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@employee_ID", empID)
            };

            ExecuteHRProcedure("Deduction_unpaid", p);
        }

        protected void GeneratePayroll(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            if (String.IsNullOrWhiteSpace(txtTargetEmployeeID.Text))
            {
                lblMessage.Text = "Please enter a Target Employee ID.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int empID;
            if (!int.TryParse(txtTargetEmployeeID.Text, out empID))
            {
                lblMessage.Text = "Please enter a valid numeric Employee ID.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (String.IsNullOrWhiteSpace(txtPayrollFrom.Text) || String.IsNullOrWhiteSpace(txtPayrollTo.Text))
            {
                lblMessage.Text = "Please enter both From and To dates.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            DateTime fromDate, toDate;
            if (!DateTime.TryParse(txtPayrollFrom.Text, out fromDate) || !DateTime.TryParse(txtPayrollTo.Text, out toDate))
            {
                lblMessage.Text = "Please enter valid Start and End dates.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (fromDate > toDate)
            {
                lblMessage.Text = "'From Date' cannot be after 'To Date'.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@employee_ID", empID),
                new SqlParameter("@from", fromDate),
                new SqlParameter("@to", toDate)
            };

            ExecuteHRProcedure("Add_Payroll", p);
            txtPayrollFrom.Text = "";
            txtPayrollTo.Text = "";
        }
    }
}