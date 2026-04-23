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
    public partial class FetchYesterdayAttendance_Click : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            String connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand fetchAttendance = new SqlCommand("SELECT * FROM allEmployeeAttendance", conn);
            fetchAttendance.CommandType = CommandType.Text;
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(fetchAttendance);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            attendanceGridView.DataSource = dt;
            attendanceGridView.DataBind();

            conn.Close();
        
        }
    }
}