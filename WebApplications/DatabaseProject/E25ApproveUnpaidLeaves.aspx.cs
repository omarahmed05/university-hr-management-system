using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;

namespace DatabaseProject
{
    public partial class ApproveUnpaidLeaves : Page
    {
        protected void Page_Load(object sender, EventArgs e) 
        {
            if (Session["user"] == null || Session["role"] == null || (Session["role"].ToString() != "Dean" && Session["role"].ToString() != "Vice Dean" && Session["role"].ToString() != "President"))
            {
                if (Session["role"].ToString() == "employee")
                {
                    Response.Redirect("E10EmployeeDashboard.aspx");
                }
                else
                {
                    Response.Redirect("HomePage.aspx");
                }
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            ProcessRequest("approve");
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            ProcessRequest("reject");
        }

        private void ProcessRequest(string action)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRequestID.Text))
                {
                    ShowMessage("FAILED", "Request ID required", "Enter unpaid leave request ID.");
                    return;
                }

                int requestId = int.Parse(txtRequestID.Text);
                int approverId = int.Parse(ddlApprover.SelectedValue);

                using (SqlConnection conn = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ConnectionString))
                {
                    conn.Open();

                    if (action == "approve")
                    {
                        // Call the stored procedure for approval
                        SqlCommand cmd = new SqlCommand("Upperboard_approve_unpaids", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@request_ID", requestId);
                        cmd.Parameters.AddWithValue("@upperboard_ID", approverId);

                        cmd.ExecuteNonQuery();
                        ShowMessage("SUCCESS", "Unpaid leave approved", "Leave request has been approved.");
                    }
                    else
                    {
                        // For rejection - just update the approval status
                        string query = @"
                            UPDATE Employee_Approve_Leave 
                            SET status = 'Rejected' 
                            WHERE leave_ID = @requestID AND Emp1_ID = @approverId";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@requestID", requestId);
                        cmd.Parameters.AddWithValue("@approverId", approverId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            ShowMessage("SUCCESS", "Unpaid leave rejected", "Leave request has been rejected.");
                        }
                        else
                        {
                            // If not in approval chain, add them
                            string insertQuery = @"
                                INSERT INTO Employee_Approve_Leave (Emp1_ID, leave_ID, status) 
                                VALUES (@approverId, @requestID, 'Rejected')";

                            SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                            insertCmd.Parameters.AddWithValue("@approverId", approverId);
                            insertCmd.Parameters.AddWithValue("@requestID", requestId);
                            insertCmd.ExecuteNonQuery();

                            ShowMessage("SUCCESS", "Unpaid leave rejected", "Leave request has been rejected.");
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                ShowMessage("FAILED", "Database error", sqlEx.Message);
            }
            catch (FormatException)
            {
                ShowMessage("FAILED", "Invalid ID", "Request ID must be a number.");
            }
            catch (Exception ex)
            {
                ShowMessage("FAILED", "System error", "Try again or contact support.");
            }
        }

        private void ShowMessage(string status, string reason, string correctiveSteps)
        {
            lblResult.Visible = lblSuggestion.Visible = true;
            lblResult.Text = status + ": " + reason;
            lblSuggestion.Text = "Action needed: " + correctiveSteps;
            lblResult.ForeColor = status == "SUCCESS" ? System.Drawing.Color.Green : System.Drawing.Color.Red;
        }
    }
}