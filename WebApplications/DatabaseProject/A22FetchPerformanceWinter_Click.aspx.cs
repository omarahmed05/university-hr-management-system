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
    public partial class FetchPerformanceWinter_Click : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["role"] == null || Session["role"].ToString() != "admin")
            {
                Response.Redirect("HomePage.aspx");
            }

            String connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand fetchPerformance = new SqlCommand("SELECT * FROM allPerformance", conn);
            fetchPerformance.CommandType = CommandType.Text;
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(fetchPerformance);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            PerformanceGridView.DataSource = dt;
            PerformanceGridView.DataBind();

            conn.Close();
        }
    }
}