using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace DatabaseProject
{
    public partial class CompensationLeaveApplication : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["role"] == null || (Session["role"].ToString() != "employee" && Session["role"].ToString() != "Dean" && Session["role"].ToString() != "Vice Dean" && Session["role"].ToString() != "President"))
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Making sure the fields are not empty
            if (String.IsNullOrWhiteSpace(txtCompensationDate.Text) || String.IsNullOrWhiteSpace(txtOriginalWorkday.Text))
            {
                ShowMessage("FAILED", "Dates required", "Enter compensation date and original work day.");
                return;
            }

            if (String.IsNullOrWhiteSpace(txtReason.Text))
            {
                ShowMessage("FAILED", "Reason required", "Enter reason for working on day off.");
                return;
            }

            if (String.IsNullOrWhiteSpace(txtReplacementID.Text))
            {
                ShowMessage("FAILED", "Replacement required", "Enter replacement employee ID.");
                return;
            }

            try
            {
                int empId = Int32.Parse(Session["user"].ToString());
                DateTime compensationDate = DateTime.Parse(txtCompensationDate.Text);
                DateTime originalWorkday = DateTime.Parse(txtOriginalWorkday.Text);

                string reason = txtReason.Text;
                int replacementId;
                if (!Int32.TryParse(txtReplacementID.Text, out replacementId))
                {
                    ShowMessage("FAILED", "Invalid replacement ID", "Replacement ID must be a number.");
                    return;
                }

                String connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand cmd = new SqlCommand("Submit_compensation", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@employee_ID", empId);
                cmd.Parameters.AddWithValue("@compensation_date", compensationDate);
                cmd.Parameters.AddWithValue("@reason", reason);
                cmd.Parameters.AddWithValue("@date_of_original_workday", originalWorkday);
                cmd.Parameters.AddWithValue("@rep_emp_id", replacementId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                ShowMessage("SUCCESS", "Compensation leave submitted", "HR will review your request.");

                txtCompensationDate.Text = "";
                txtOriginalWorkday.Text = "";
                txtReason.Text = "";
                txtReplacementID.Text = "";
            }
            catch (SqlException sqlEx)
            {
                ShowMessage("FAILED", "Database error", sqlEx.Message);
            }
            catch (FormatException)
            {
                ShowMessage("FAILED", "Invalid input", "Check date format and replacement ID.");
            }
            catch (Exception ex)
            {
                ShowMessage("FAILED", "Error", ex.Message);
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