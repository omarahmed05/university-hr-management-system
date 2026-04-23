using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.Configuration;

namespace DatabaseProject
{
    public partial class AccidentalLeaveApplication : Page
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
            // Making sure the field is not empty
            if (String.IsNullOrWhiteSpace(txtDate.Text))
            {
                ShowMessage("FAILED", "Date is required", "Please select a leave date.");
                return;
            }

            try
            {
                int empId = Int32.Parse(Session["user"].ToString());
                DateTime leaveDate = DateTime.Parse(txtDate.Text);

                String connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand cmd = new SqlCommand("Submit_accidental", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@employee_ID", empId);
                cmd.Parameters.AddWithValue("@start_date", leaveDate);
                cmd.Parameters.AddWithValue("@end_date", leaveDate);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                ShowMessage("SUCCESS", "Accidental leave submitted", "HR will review your request.");
                txtDate.Text = "";
            }
            catch (SqlException sqlEx)
            {
                ShowMessage("FAILED", "Database error", sqlEx.Message);
            }
            catch (FormatException)
            {
                ShowMessage("FAILED", "Invalid date format", "Please use a valid date.");
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