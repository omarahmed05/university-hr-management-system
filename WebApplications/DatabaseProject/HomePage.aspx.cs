using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseProject
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Admin_Button(object sender, EventArgs e)
        {
            Response.Redirect("A11AdminLogin.aspx");
        }

        protected void Employee_Button(object sender, EventArgs e)
        {
            Response.Redirect("E11EmployeeLogin.aspx");
        }

        protected void HR_Button(object sender, EventArgs e)
        {
            Response.Redirect("H01HRLogin.aspx");
        }
    }
}