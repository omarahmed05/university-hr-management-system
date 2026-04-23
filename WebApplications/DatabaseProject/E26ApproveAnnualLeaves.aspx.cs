using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;

namespace DatabaseProject
{
    public partial class ApproveAnnualLeaves : System.Web.UI.Page
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
                if (string.IsNullOrEmpty(txtRequestId.Text))
                {
                    ShowMessage("FAILED", "Request ID required", "Enter annual leave request ID.");
                    return;
                }

                int requestId = int.Parse(txtRequestId.Text);
                int upperboardId = int.Parse(ddlApprover.SelectedValue);

                using (SqlConnection conn = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ConnectionString))
                {
                    conn.Open();

                    string getReplacementQuery = @"
                        SELECT AL.replacement_emp, 
                               L.final_approval_status,
                               E1.first_name + ' ' + E1.last_name as employee_name,
                               E2.first_name + ' ' + E2.last_name as replacement_name
                        FROM Annual_Leave AL
                        INNER JOIN Leave L ON AL.request_ID = L.request_ID
                        INNER JOIN Employee E1 ON AL.emp_ID = E1.employee_id
                        INNER JOIN Employee E2 ON AL.replacement_emp = E2.employee_id
                        WHERE AL.request_ID = @requestId";

                    SqlCommand getCmd = new SqlCommand(getReplacementQuery, conn);
                    getCmd.Parameters.AddWithValue("@requestId", requestId);

                    SqlDataReader reader = getCmd.ExecuteReader();
                    if (!reader.Read())
                    {
                        ShowMessage("FAILED", "Invalid request", "Request ID not found or not an annual leave.");
                        return;
                    }

                    int replacementId = Convert.ToInt32(reader["replacement_emp"]);
                    string status = reader["final_approval_status"].ToString();
                    string employeeName = reader["employee_name"].ToString();
                    string replacementName = reader["replacement_name"].ToString();
                    reader.Close();

                    if (!status.Equals("Pending", StringComparison.OrdinalIgnoreCase))
                    {
                        ShowMessage("FAILED", "Already processed",
                            $"This leave request is already {status.ToLower()}. Current status: {status}");
                        return;
                    }

                    if (action == "approve")
                    {
                        SqlCommand cmd = new SqlCommand("Upperboard_approve_annual", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@request_ID", requestId);
                        cmd.Parameters.AddWithValue("@Upperboard_ID", upperboardId);
                        cmd.Parameters.AddWithValue("@replacement_ID", replacementId);

                        cmd.ExecuteNonQuery();

                        string checkStatusQuery = "SELECT final_approval_status FROM Leave WHERE request_ID = @requestId";
                        SqlCommand checkCmd = new SqlCommand(checkStatusQuery, conn);
                        checkCmd.Parameters.AddWithValue("@requestId", requestId);
                        string finalStatus = (string)checkCmd.ExecuteScalar();

                        if (finalStatus.Equals("Approved", StringComparison.OrdinalIgnoreCase))
                        {
                            ShowMessage("SUCCESS", "Annual leave approved",
                                $"Leave for {employeeName} approved. Replacement: {replacementName} (ID: {replacementId})");
                        }
                        else
                        {
                            ShowMessage("REJECTED", "Leave rejected by system",
                                $"Replacement {replacementName} may be: 1) Part-time, 2) Not in same department, 3) On leave");
                        }
                    }
                    else
                    {
                        string updateQuery = @"
                            UPDATE Employee_Approve_Leave 
                            SET status = 'Rejected' 
                            WHERE leave_ID = @requestId AND Emp1_ID = @upperboardId";

                        SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@requestId", requestId);
                        updateCmd.Parameters.AddWithValue("@upperboardId", upperboardId);

                        int rowsAffected = updateCmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            string insertQuery = @"
                                INSERT INTO Employee_Approve_Leave (Emp1_ID, leave_ID, status) 
                                VALUES (@upperboardId, @requestId, 'Rejected')";

                            SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                            insertCmd.Parameters.AddWithValue("@upperboardId", upperboardId);
                            insertCmd.Parameters.AddWithValue("@requestId", requestId);
                            insertCmd.ExecuteNonQuery();
                        }

                        string checkRejectQuery = @"
                            UPDATE Leave 
                            SET final_approval_status = 'Rejected'
                            WHERE request_ID = @requestId 
                            AND NOT EXISTS (
                                SELECT 1 FROM Employee_Approve_Leave 
                                WHERE leave_ID = @requestId AND status = 'Approved'
                            )";

                        SqlCommand rejectCmd = new SqlCommand(checkRejectQuery, conn);
                        rejectCmd.Parameters.AddWithValue("@requestId", requestId);
                        rejectCmd.ExecuteNonQuery();

                        ShowMessage("SUCCESS", "Annual leave rejected", $"Leave for {employeeName} rejected.");
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Message.Contains("part_time"))
                    ShowMessage("FAILED", "Part-time employee", "Part-time employees cannot take annual leave.");
                else if (sqlEx.Message.Contains("same department"))
                    ShowMessage("FAILED", "Different department", "Replacement must be in same department.");
                else if (sqlEx.Message.Contains("replacement") && sqlEx.Message.Contains("leave"))
                    ShowMessage("FAILED", "Replacement on leave", "Replacement employee is on leave.");
                else if (sqlEx.Message.Contains("already been processed"))
                    ShowMessage("FAILED", "Already processed", "This leave request has already been processed.");
                else
                    ShowMessage("FAILED", "Database error", sqlEx.Message);
            }
            catch (FormatException)
            {
                ShowMessage("FAILED", "Invalid input", "Request ID must be a number.");
            }
            catch (Exception ex)
            {
                ShowMessage("FAILED", "System error", ex.Message);
            }
        }

        private void ShowMessage(string status, string reason, string correctiveSteps)
        {
            lblResult.Visible = true;
            lblSuggestion.Visible = true;
            lblResult.Text = status + ": " + reason;
            lblSuggestion.Text = "Action: " + correctiveSteps;
            lblResult.ForeColor = (status == "SUCCESS" || status == "REJECTED")
                ? System.Drawing.Color.Green : System.Drawing.Color.Red;
        }
    }
}