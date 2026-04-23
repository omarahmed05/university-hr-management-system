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
    public partial class AnnualLeaveApplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["role"] == null || (Session["role"].ToString() != "employee" && Session["role"].ToString() != "Dean" && Session["role"].ToString() != "Vice Dean" && Session["role"].ToString() != "President"))
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void SubmitAnnualLeave(object sender, EventArgs e)
        {
            messageLabel.ForeColor = System.Drawing.Color.Red;
            messageLabel.Text = "";

            // Making sure that all fields are filled
            if (String.IsNullOrWhiteSpace(replacementEmpID.Text))
            {
                messageLabel.Text = "Please enter a replacement employee ID.";
                return;
            }

            if (String.IsNullOrWhiteSpace(startDate.Text))
            {
                messageLabel.Text = "Please enter a start date.";
                return;
            }

            if (String.IsNullOrWhiteSpace(endDate.Text))
            {
                messageLabel.Text = "Please enter an end date.";
                return;
            }

            // Validating the input values
            int replacementEmpIDValue;
            if (!Int32.TryParse(replacementEmpID.Text, out replacementEmpIDValue))
            {
                messageLabel.Text = "Replacement employee ID must be a valid number.";
                return;
            }

            DateTime startDateValue;
            if (!DateTime.TryParse(startDate.Text, out startDateValue))
            {
                messageLabel.Text = "Please enter a valid start date.";
                return;
            }

            DateTime endDateValue;
            if (!DateTime.TryParse(endDate.Text, out endDateValue))
            {
                messageLabel.Text = "Please enter a valid end date.";
                return;
            }

            if (endDateValue < startDateValue)
            {
                messageLabel.Text = "End date cannot be before start date.";
                return;
            }

            try
            {
                String connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int empID = Int16.Parse(Session["user"].ToString());

                SqlCommand submitAnnualProc = new SqlCommand("Submit_annual", conn);

                submitAnnualProc.CommandType = CommandType.StoredProcedure;

                submitAnnualProc.Parameters.AddWithValue("@employee_ID", empID);
                submitAnnualProc.Parameters.AddWithValue("@replacement_emp", replacementEmpIDValue);
                submitAnnualProc.Parameters.AddWithValue("@start_date", startDateValue);
                submitAnnualProc.Parameters.AddWithValue("@end_date", endDateValue);

                conn.Open();

                submitAnnualProc.ExecuteNonQuery();

                conn.Close();

                messageLabel.ForeColor = System.Drawing.Color.Green;
                messageLabel.Text = "Annual leave request submitted successfully!";

                replacementEmpID.Text = "";
                startDate.Text = "";
                endDate.Text = "";
            }
            catch (SqlException ex)
            {
                messageLabel.Text = "Error occured with the database: " + ex.Message;
            }
            catch (Exception ex)
            {
                messageLabel.Text = "Couldn't submit leave request: " + ex.Message;
            }
        }
    }
}