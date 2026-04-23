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
    public partial class UpdateAttendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["role"] == null || Session["role"].ToString() != "admin")
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void c1(object sender, EventArgs e)
        {
            labelout.ForeColor = System.Drawing.Color.Red;
            labelout.Text = "";

            if (String.IsNullOrWhiteSpace(TextBox11.Text))
            {
                labelout.Text = "Please enter an Employee ID.";
                return;
            }

            int employeeId;
            if (!int.TryParse(TextBox11.Text, out employeeId))
            {
                labelout.Text = "Employee ID must be a valid number.";
                return;
            }

            TimeSpan? checkInTime = null;
            TimeSpan? checkOutTime = null;

            if (!String.IsNullOrWhiteSpace(TextBox22.Text))
            {
                TimeSpan parsedCheckIn;
                if (!TimeSpan.TryParse(TextBox22.Text, out parsedCheckIn))
                {
                    labelout.Text = "Invalid check-in time format.";
                    return;
                }
                checkInTime = parsedCheckIn;
            }

            if (!String.IsNullOrWhiteSpace(TextBox33.Text))
            {
                TimeSpan parsedCheckOut;
                if (!TimeSpan.TryParse(TextBox33.Text, out parsedCheckOut))
                {
                    labelout.Text = "Invalid check-out time format.";
                    return;
                }
                checkOutTime = parsedCheckOut;
            }

            if ((checkInTime.HasValue && !checkOutTime.HasValue) || (!checkInTime.HasValue && checkOutTime.HasValue))
            {
                labelout.Text = "Please provide both check-in and check-out times, or leave both empty to mark as absent.";
                return;
            }

            if (checkInTime.HasValue && checkOutTime.HasValue && checkOutTime.Value <= checkInTime.Value)
            {
                labelout.Text = "Check-out time must be after check-in time.";
                return;
            }

            try
            {
                String connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand("Update_Attendance", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = employeeId;
                cmd.Parameters.Add("@check_in_time", SqlDbType.Time).Value = (object)checkInTime ?? DBNull.Value;
                cmd.Parameters.Add("@check_out_time", SqlDbType.Time).Value = (object)checkOutTime ?? DBNull.Value;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                labelout.ForeColor = System.Drawing.Color.Green;
                labelout.Text = "Attendance updated successfully for Employee ID: " + employeeId;

                TextBox11.Text = "";
                TextBox22.Text = "";
                TextBox33.Text = "";
            }
            catch (SqlException sqlEx)
            {
                labelout.Text = "Database Error: " + sqlEx.Message;
            }
            catch (Exception ex)
            {
                labelout.Text = "Error: " + ex.Message;
            }
        }
    }
}