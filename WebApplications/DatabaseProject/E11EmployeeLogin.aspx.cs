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
    public partial class EmployeeLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            errorLabel.ForeColor = System.Drawing.Color.Red;

            // Making sure the fields are not empty
            if (String.IsNullOrWhiteSpace(employeeUsername.Text))
            {
                errorLabel.Text = "Please enter your Employee ID.";
                return;
            }

            if (String.IsNullOrWhiteSpace(employeePassword.Text))
            {
                errorLabel.Text = "Please enter your password.";
                return;
            }

            // Making sure the username is a number
            int username;
            if (!Int32.TryParse(employeeUsername.Text, out username))
            {
                errorLabel.Text = "Employee ID must be a valid number.";
                return;
            }

            String password = employeePassword.Text;

            try
            {
                String connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand loginFunc = new SqlCommand("SELECT dbo.EmployeeLoginValidation(@employee_ID, @password)", conn);

                loginFunc.CommandType = CommandType.Text;

                loginFunc.Parameters.AddWithValue("@employee_ID", username);
                loginFunc.Parameters.AddWithValue("@password", password);

                conn.Open();
                object result = loginFunc.ExecuteScalar();

                if (result != null && Convert.ToBoolean(result))
                {
                    SqlCommand getRoleCmd = new SqlCommand(@"
                        SELECT TOP 1 ER.role_name 
                        FROM Employee_Role ER
                        INNER JOIN Role R ON ER.role_name = R.role_name
                        WHERE ER.emp_ID = @employee_ID
                        ORDER BY R.rank ASC", conn);

                    getRoleCmd.Parameters.AddWithValue("@employee_ID", username);

                    object roleResult = getRoleCmd.ExecuteScalar();
                    string userRole = roleResult != null ? roleResult.ToString() : "employee";

                    if (userRole != "Dean" && userRole != "Vice Dean" && userRole != "President")
                    {
                        userRole = "employee";
                    }

                    Session["user"] = username;
                    Session["role"] = userRole;
                    Response.Redirect("E10EmployeeDashboard.aspx");
                }
                else
                {
                    errorLabel.Text = "Invalid Employee ID or password.";
                }

                conn.Close();
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