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
    public partial class RetrievePerformance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["role"] == null || (Session["role"].ToString() != "employee" && Session["role"].ToString() != "Dean" && Session["role"].ToString() != "Vice Dean" && Session["role"].ToString() != "President"))
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void ShowPerformance(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            errorLabel.ForeColor = System.Drawing.Color.Red;

            // Making sure that the semester field is not empty
            if (String.IsNullOrWhiteSpace(semester.Text))
            {
                errorLabel.Text = "Please enter a semester.";
                return;
            }

            String semesterText = semester.Text.Trim();

            try
            {
                String connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int empID = Int16.Parse(Session["user"].ToString());

                SqlCommand performanceFunc = new SqlCommand("SELECT * FROM dbo.MyPerformance(@employee_ID, @period)", conn);

                performanceFunc.CommandType = CommandType.Text;

                performanceFunc.Parameters.AddWithValue("@employee_ID", empID);
                performanceFunc.Parameters.AddWithValue("@period", semesterText);

                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(performanceFunc);
                DataTable performanceTable = new DataTable();
                adapter.Fill(performanceTable);

                performanceGridView.DataSource = performanceTable;
                performanceGridView.DataBind();

                conn.Close();

                if (performanceTable.Rows.Count == 0)
                {
                    errorLabel.ForeColor = System.Drawing.Color.Orange;
                    errorLabel.Text = "No performance records found for semester: " + semesterText;
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