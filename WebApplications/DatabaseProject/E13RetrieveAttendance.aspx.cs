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
    public partial class RetrieveAttendance : System.Web.UI.Page
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

                SqlCommand attendanceFunc = new SqlCommand("SELECT * FROM dbo.MyAttendance(@employee_ID)", conn);

                attendanceFunc.CommandType = CommandType.Text;

                attendanceFunc.Parameters.AddWithValue("@employee_ID", empID);

                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(attendanceFunc);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                attendanceGridView.DataSource = dt;
                attendanceGridView.DataBind();

                conn.Close();

                if (dt.Rows.Count == 0)
                {
                    errorLabel.ForeColor = System.Drawing.Color.Orange;
                    errorLabel.Text = "No attendance records found for the current month.";
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