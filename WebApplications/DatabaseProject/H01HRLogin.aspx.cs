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
    public partial class HRLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            errorLabel.ForeColor = System.Drawing.Color.Red;

            // Making sure the fields are not empty
            if (String.IsNullOrWhiteSpace(HRUsername.Text))
            {
                errorLabel.Text = "Please enter your Employee ID.";
                return;
            }

            if (String.IsNullOrWhiteSpace(HRPassword.Text))
            {
                errorLabel.Text = "Please enter your password.";
                return;
            }

            // Making sure the username is a number
            int username;
            if (!Int32.TryParse(HRUsername.Text, out username))
            {
                errorLabel.Text = "Employee ID must be a valid number.";
                return;
            }

            String password = HRPassword.Text;

            try
            {
                String connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand loginFunc = new SqlCommand("SELECT dbo.HRLoginValidation(@employee_ID, @password)", conn);

                loginFunc.CommandType = CommandType.Text;

                loginFunc.Parameters.AddWithValue("@employee_ID", username);
                loginFunc.Parameters.AddWithValue("@password", password);

                conn.Open();
                object result = loginFunc.ExecuteScalar();
                conn.Close();

                if (result != null && Convert.ToBoolean(result))
                {
                    Session["user"] = username;
                    Session["role"] = "HR";
                    Response.Redirect("H00HRDashboard.aspx");
                }
                else
                {
                    errorLabel.Text = "Invalid Employee ID or password.";
                }
            }
            catch (SqlException sqlEx)
            {
                errorLabel.Text = "Database error: " + sqlEx.Message;
            }
            catch (Exception ex)
            {
                errorLabel.Text = "Error: " + ex.Message;
            }
        }
    }
}