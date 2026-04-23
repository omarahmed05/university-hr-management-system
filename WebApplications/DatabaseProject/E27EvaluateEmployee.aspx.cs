using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace DatabaseProject
{
    public partial class EvaluateEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) 
        {
            if (Session["user"] == null || Session["role"] == null || Session["role"].ToString() != "Dean")
            {
                if (Session["role"].ToString() == "Vice Dean" || Session["role"].ToString() == "President" || Session["role"].ToString() == "employee")
                {
                    Response.Redirect("E10EmployeeDashboard.aspx");
                }
                else
                {
                    Response.Redirect("HomePage.aspx");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblSteps.Text = "";
            lblMessage.CssClass = "info";

            // Making sure the input fields are valid
            if (!Int32.TryParse(txtEmployeeId.Text, out int employeeId) ||
                !Int32.TryParse(txtRating.Text, out int rating))
            {
                lblMessage.CssClass = "error";
                lblMessage.Text = "Invalid input.";
                lblSteps.Text = "Ensure Employee ID and Rating are numbers.";
                return;
            }

            try
            {
                int evaluatorId = Int32.Parse(Session["user"].ToString());
                string comments = txtComments.Text.Trim();
                string semester = txtSemester.Text.Trim();

                String connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand cmd = new SqlCommand("Dean_andHR_Evaluation", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@employee_ID", employeeId);
                cmd.Parameters.AddWithValue("@rating", rating);
                cmd.Parameters.AddWithValue("@comment", comments);
                cmd.Parameters.AddWithValue("@semester", semester);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                lblMessage.CssClass = "success";
                lblMessage.Text = "Evaluation submitted successfully.";
                lblSteps.Text = "Performance record saved for Employee ID: " + employeeId;

                txtEmployeeId.Text = "";
                txtRating.Text = "";
                txtSemester.Text = "";
                txtComments.Text = "";
            }
            catch (SqlException sqlEx)
            {
                lblMessage.CssClass = "error";
                lblMessage.Text = "Database error.";
                lblSteps.Text = sqlEx.Message;
            }
            catch (Exception ex)
            {
                lblMessage.CssClass = "error";
                lblMessage.Text = "Unexpected error occurred.";
                lblSteps.Text = ex.Message;
            }
        }
    }
}