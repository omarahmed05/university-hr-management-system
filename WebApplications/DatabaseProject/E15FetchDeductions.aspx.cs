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
    public partial class FetchDeductions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["role"] == null || (Session["role"].ToString() != "employee" && Session["role"].ToString() != "Dean" && Session["role"].ToString() != "Vice Dean" && Session["role"].ToString() != "President"))
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void ShowDeductions(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            errorLabel.ForeColor = System.Drawing.Color.Red;

            // Making sure the month field is not empty
            if (String.IsNullOrWhiteSpace(month.Text))
            {
                errorLabel.Text = "Please enter a month (1-12).";
                return;
            }

            // Making sure the month is a valid number and that the number is in between 1 and 12
            int monthNumber;
            if (!Int32.TryParse(month.Text, out monthNumber))
            {
                errorLabel.Text = "Month must be a valid number.";
                return;
            }

            if (monthNumber < 1 || monthNumber > 12)
            {
                errorLabel.Text = "Month must be between 1 and 12.";
                return;
            }

            try
            {
                String connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int empID = Int16.Parse(Session["user"].ToString());

                SqlCommand deductionsFunc = new SqlCommand("SELECT * FROM dbo.Deductions_Attendance(@employee_ID, @month)", conn);

                deductionsFunc.CommandType = CommandType.Text;

                deductionsFunc.Parameters.AddWithValue("@employee_ID", empID);
                deductionsFunc.Parameters.AddWithValue("@month", monthNumber);

                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(deductionsFunc);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                deductionsGridView.DataSource = dt;
                deductionsGridView.DataBind();

                conn.Close();

                if (dt.Rows.Count == 0)
                {
                    errorLabel.ForeColor = System.Drawing.Color.Orange;
                    errorLabel.Text = "No deduction records found for month: " + monthNumber;
                }
            }
            catch (SqlException sqlEx)
            {
                errorLabel.Text = "Database error: " + sqlEx.Message;
            }
            catch (FormatException)
            {
                errorLabel.Text = "Invalid session data. Please log in again.";
                Response.Redirect("E11EmployeeLogin.aspx");
            }
            catch (Exception ex)
            {
                errorLabel.Text = "Error: " + ex.Message;
            }
        }
    }
}