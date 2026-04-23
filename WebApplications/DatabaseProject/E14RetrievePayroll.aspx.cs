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
    public partial class RetrievePayroll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["role"] == null || (Session["role"].ToString() != "employee" && Session["role"].ToString() != "Dean" && Session["role"].ToString() != "Vice Dean" && Session["role"].ToString() != "President"))
            {
                Response.Redirect("HomePage.aspx");
            }

            errorLabel.Text = "";
            errorLabel.ForeColor = System.Drawing.Color.Red;

            try
            {
                String connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int empID = Int16.Parse(Session["user"].ToString());

                SqlCommand payrollFunc = new SqlCommand("SELECT * FROM dbo.Last_month_payroll(@employee_ID)", conn);

                payrollFunc.CommandType = CommandType.Text;

                payrollFunc.Parameters.AddWithValue("@employee_ID", empID);

                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(payrollFunc);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                payrollGridView.DataSource = dt;
                payrollGridView.DataBind();

                conn.Close();

                if (dt.Rows.Count == 0)
                {
                    errorLabel.ForeColor = System.Drawing.Color.Orange;
                    errorLabel.Text = "No payroll records found for last month.";
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