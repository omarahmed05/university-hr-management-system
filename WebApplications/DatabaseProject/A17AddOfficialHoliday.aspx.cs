using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace DatabaseProject
{
    public partial class AddOfficialHoliday : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["role"] == null || Session["role"].ToString() != "admin")
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        public void b11(object sender, EventArgs e)
        {
            string holidayNameInput = TextBox1.Text.Trim();
            string fromDateInput = TextBox2.Text.Trim();
            string toDateInput = TextBox3.Text.Trim();

            l2.Text = "";
            l2.ForeColor = System.Drawing.Color.Red;

            if (string.IsNullOrEmpty(holidayNameInput))
            {
                l2.Text = "Please enter a holiday name.";
                return;
            }

            if (string.IsNullOrEmpty(fromDateInput) || string.IsNullOrEmpty(toDateInput))
            {
                l2.Text = "Please select both from and to dates.";
                return;
            }

            DateTime fromDate = DateTime.Parse(fromDateInput);
            DateTime toDate = DateTime.Parse(toDateInput);

            if (fromDate > toDate)
            {
                l2.Text = "From date cannot be after to date.";
                return;
            }

            string connStr = WebConfigurationManager.ConnectionStrings["University_HRManagementDatabase"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("Add_Holiday", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@holiday_name", holidayNameInput));
                    cmd.Parameters.Add(new SqlParameter("@from_date", fromDate));
                    cmd.Parameters.Add(new SqlParameter("@to_date", toDate));

                    string messages = "";

                    conn.InfoMessage += (senderInfo, eInfo) =>
                    {
                        messages += eInfo.Message + "<br/>";
                    };

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        l2.Text = messages;

                        if (string.IsNullOrEmpty(l2.Text))
                        {
                            l2.Text = "Holiday added successfully.";
                            l2.ForeColor = System.Drawing.Color.Green;
                            
                            TextBox1.Text = "";
                            TextBox2.Text = "";
                            TextBox3.Text = "";
                        }
                    }
                    catch (SqlException ex)
                    {
                        l2.Text = "Database error: " + ex.Message;
                    }
                    catch (Exception ex)
                    {
                        l2.Text = "Error: " + ex.Message;
                    }
                }
            }
        }
    }
}