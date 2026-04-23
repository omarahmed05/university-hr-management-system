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
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null || Session["role"] == null || Session["role"].ToString() != "admin")
            {
                Response.Redirect("HomePage.aspx");
            }

            string connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM allEmployeeProfiles";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                EmployeeGrid.DataSource = dt;
                EmployeeGrid.DataBind();
            }
        }
    }
}