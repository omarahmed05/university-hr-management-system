using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace DatabaseProject
{
    public partial class UnpaidLeaveApplication : Page
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
            if (String.IsNullOrWhiteSpace(txtStartDate.Text) || String.IsNullOrWhiteSpace(txtEndDate.Text))
            {
                ShowMessage("FAILED", "Dates required", "Enter start and end dates.");
                return;
            }

            if (String.IsNullOrWhiteSpace(txtDocDescription.Text) || String.IsNullOrWhiteSpace(txtFileName.Text))
            {
                ShowMessage("FAILED", "Memo required", "Unpaid leave requires memo document.");
                return;
            }

            try
            {
                int empId = Int32.Parse(Session["user"].ToString());
                DateTime startDate = DateTime.Parse(txtStartDate.Text);
                DateTime endDate = DateTime.Parse(txtEndDate.Text);

                if (endDate < startDate)
                {
                    ShowMessage("FAILED", "Invalid dates", "End date must be after start date.");
                    return;
                }

                string docDesc = txtDocDescription.Text;
                string fileName = txtFileName.Text;

                String connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand cmd = new SqlCommand("Submit_unpaid", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@employee_ID", empId);
                cmd.Parameters.AddWithValue("@start_date", startDate);
                cmd.Parameters.AddWithValue("@end_date", endDate);
                cmd.Parameters.AddWithValue("@document_description", docDesc);
                cmd.Parameters.AddWithValue("@file_name", fileName);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                ShowMessage("SUCCESS", "Unpaid leave submitted", "Higher-ranking employee, President, and HR will review.");

                txtStartDate.Text = "";
                txtEndDate.Text = "";
                txtDocDescription.Text = "";
                txtFileName.Text = "";
            }
            catch (SqlException sqlEx)
            {
                ShowMessage("FAILED", "Database error", sqlEx.Message);
            }
            catch (FormatException)
            {
                ShowMessage("FAILED", "Invalid date", "Use a valid date format.");
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