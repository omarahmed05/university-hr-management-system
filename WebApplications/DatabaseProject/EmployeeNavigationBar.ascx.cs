using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseProject
{
    public partial class EmployeeNavigationBar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != null)
            {
                string userRole = Session["role"].ToString();

                // Show approval links only for Dean, Vice Dean, or President
                if (userRole == "Dean" || userRole == "Vice Dean" || userRole == "President")
                {
                    lnkApproveUnpaid.Visible = true;
                    lnkApproveAnnual.Visible = true;
                }

                // Show evaluate link only for Dean
                if (userRole == "Dean")
                {
                    lnkEvaluate.Visible = true;
                }
            }
        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("HomePage.aspx");
        }
    }
}