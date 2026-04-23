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
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["role"] == null || Session["role"].ToString() != "admin")
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void b1(object sender, EventArgs e)
        {
            Response.Redirect("A12EmployeeDetails.aspx");
        }

        protected void b5(object sender, EventArgs e)
        {
            Response.Redirect("A16UpdateAttendance.aspx");
        }

        protected void b4(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand("Remove_Deductions", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                if (rowsAffected > 0)
                {
                    z.Text = "Deductions removed successfully!";
                    z.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    z.Text = "Nothing to remove";
                    z.ForeColor = System.Drawing.Color.Orange;
                }
            }
            catch (SqlException sqlEx)
            {
                z.Text = "Database Error: " + sqlEx.Message;
                z.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void b2(object sender, EventArgs e)
        {
            Response.Redirect("A13NoEmployeePerDept.aspx");
        }

        protected void b7(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand("Initiate_Attendance", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                if (rowsAffected > 0)
                {
                    l.Text = "Attendance initiated successfully!";
                    l.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    l.Text = "All attendance for employees is already inserted today.";
                    l.ForeColor = System.Drawing.Color.Orange;
                }
            }
            catch (SqlException sqlEx)
            {
                l.Text = "Database Error: " + sqlEx.Message;
                l.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void b6(object sender, EventArgs e)
        {
            Response.Redirect("A17AddOfficialHoliday.aspx");
        }

        protected void b3(object sender, EventArgs e)
        {
            Response.Redirect("A14RejectedMedicalLeave.aspx");
        }

        protected void FetchYesterdayAttendance_Click(object sender, EventArgs e)
        {
            Response.Redirect("A21FetchYesterdayAttendance_Click.aspx");
        }

        protected void FetchPerformanceWinter_Click(object sender, EventArgs e)
        {
            Response.Redirect("A22FetchPerformanceWinter_Click.aspx");
        }

        protected void RemoveAttendanceHoliday_Click(object sender, EventArgs e)
        {
            try
            {
                String connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand rah = new SqlCommand("Remove_Holiday", conn);
                rah.CommandType = CommandType.StoredProcedure;

                conn.Open();
                rah.ExecuteNonQuery();
                conn.Close();

                Label8.Text = "Holiday attendance removed successfully!";
                Label8.ForeColor = System.Drawing.Color.Green;
            }
            catch (SqlException sqlEx)
            {
                Label8.Text = "Database Error: " + sqlEx.Message;
                Label8.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void RemoveUnattendedDayoff_Click(object sender, EventArgs e)
        {
            int empid;
            if (!int.TryParse(empid1.Text, out empid))
            {
                DayOffMessageLabel.Text = "Error: Employee ID must be a valid number.";
                DayOffMessageLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                String connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand rdo = new SqlCommand("Remove_DayOff", conn);
                rdo.CommandType = CommandType.StoredProcedure;
                rdo.Parameters.Add(new SqlParameter("@employee_ID", empid));

                conn.Open();
                rdo.ExecuteNonQuery();
                conn.Close();

                DayOffMessageLabel.Text = "Unattended day off removed successfully!";
                DayOffMessageLabel.ForeColor = System.Drawing.Color.Green;
                empid1.Text = "";
            }
            catch (SqlException sqlEx)
            {
                DayOffMessageLabel.Text = "Database Error: " + sqlEx.Message;
                DayOffMessageLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void RemoveApprovedDayoff_Click(object sender, EventArgs e)
        {
            int empid;
            if (!int.TryParse(empid2.Text, out empid))
            {
                ApprovedLeaveMessageLabel.Text = "Error: Employee ID must be a valid number.";
                ApprovedLeaveMessageLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                String connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand ral = new SqlCommand("Remove_Approved_Leaves", conn);
                ral.CommandType = CommandType.StoredProcedure;
                ral.Parameters.Add(new SqlParameter("@employee_ID", empid));

                conn.Open();
                ral.ExecuteNonQuery();
                conn.Close();

                ApprovedLeaveMessageLabel.Text = "Approved leave attendance removed successfully!";
                ApprovedLeaveMessageLabel.ForeColor = System.Drawing.Color.Green;
                empid2.Text = "";
            }
            catch (SqlException sqlEx)
            {
                ApprovedLeaveMessageLabel.Text = "Database Error: " + sqlEx.Message;
                ApprovedLeaveMessageLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void ReplaceEmployees_Click(object sender, EventArgs e)
        {
            int emp1ID, emp2ID;

            if (!int.TryParse(empid3.Text, out emp1ID) || !int.TryParse(empid4.Text, out emp2ID))
            {
                MessageLabel.Text = "Error: Employee IDs must be valid numbers.";
                MessageLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (String.IsNullOrWhiteSpace(TextBox1.Text) || String.IsNullOrWhiteSpace(TextBox2.Text))
            {
                MessageLabel.Text = "Error: Please select both from and to dates.";
                MessageLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }

            DateTime fromDate = DateTime.Parse(TextBox1.Text);
            DateTime toDate = DateTime.Parse(TextBox2.Text);

            if (toDate < fromDate)
            {
                MessageLabel.Text = "Error: To date cannot be before from date.";
                MessageLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                String connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand ral = new SqlCommand("Replace_employee", conn);
                ral.CommandType = CommandType.StoredProcedure;
                ral.Parameters.AddWithValue("@Emp1_ID", emp1ID);
                ral.Parameters.AddWithValue("@Emp2_ID", emp2ID);
                ral.Parameters.AddWithValue("@from_date", fromDate);
                ral.Parameters.AddWithValue("@to_date", toDate);

                conn.Open();
                ral.ExecuteNonQuery();
                conn.Close();

                MessageLabel.Text = "Employee replacement recorded successfully!";
                MessageLabel.ForeColor = System.Drawing.Color.Green;

                empid3.Text = "";
                empid4.Text = "";
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            catch (SqlException sqlEx)
            {
                MessageLabel.Text = "Database Error: " + sqlEx.Message;
                MessageLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void UpdateEmploymentStatus_Click(object sender, EventArgs e)
        {
            int employeeID;

            if (!int.TryParse(StatusEmpIdTextBox.Text, out employeeID))
            {
                StatusMessageLabel.Text = "Error: Employee ID must be a valid number.";
                StatusMessageLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand("Update_Employment_Status", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Employee_ID", employeeID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                if (rowsAffected > 0)
                {
                    StatusMessageLabel.Text = $"Status updated successfully for Employee ID: {employeeID}.";
                    StatusMessageLabel.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    StatusMessageLabel.Text = $"Status update executed, but no changes were made. Employee ID {employeeID} may not exist.";
                    StatusMessageLabel.ForeColor = System.Drawing.Color.Orange;
                }
                StatusEmpIdTextBox.Text = "";
            }
            catch (SqlException sqlEx)
            {
                StatusMessageLabel.Text = "Database Error: " + sqlEx.Message;
                StatusMessageLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}