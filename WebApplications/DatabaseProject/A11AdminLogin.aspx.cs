using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseProject
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login(object sender, EventArgs e)
        {
            try
            {
                
                if (string.IsNullOrEmpty(username_1.Text.Trim())|| string.IsNullOrEmpty(password_1.Text.Trim()))
                {
                    if (string.IsNullOrEmpty(password_1.Text.Trim()) && string.IsNullOrEmpty(username_1.Text.Trim()))
                    {
                        errl.Text = "Passsword and Username cannot be empty.";
                        return;
                    }
                    if (string.IsNullOrEmpty(username_1.Text.Trim()))
                    {
                        errl.Text = "Username cannot be empty.";
                        return;
                    }
                    if (string.IsNullOrEmpty(password_1.Text.Trim()))
                    {
                        errl.Text = "Password cannot be empty.";
                        return;
                    }

                }



                if (!int.TryParse(username_1.Text.Trim(), out int username))
                {
                    errl.Text = "Username must be a numeric ID.";
                    return;
                }

                string password = password_1.Text.Trim();

               
                if (username == 1 && password == "adminpassword")
                {
                    Session["user"] = username;
                    Session["role"] = "admin";
                    Response.Redirect("A10AdminDashboard.aspx");
                }
                else
                {
                   
                    errl.Text = "Invalid username or password!";
                }
            }
            catch (SqlException ex)
            {
                
                errl.Text = "Database error. Please try again later.";
               
            }
            catch (Exception ex)
            {
                
                errl.Text = "An unexpected error occurred. Please try again.";
                
            }
        }
    }
}