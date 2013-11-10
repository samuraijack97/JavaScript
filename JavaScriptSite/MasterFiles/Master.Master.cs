using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected override void OnInit(EventArgs e)
        {
            string userID = string.Empty;
            bool isActive = false;

            if (Session["LoggedIn"] != null)
            {
                userID = Session["LoggedIn"].ToString();

                isActive = Convert.ToBoolean(Database.ExecuteSQL("SELECT IsActive FROM Users WHERE UserID = @UserID;",
                    new SqlParameter("@UserID", userID)));

                if (!isActive)
                {
                    Session.Add("Message", "Your account is not active");
                    Session.Remove("LoggedIn");
                }

                bool isAdmin = Convert.ToBoolean(Database.ExecuteSQL("SELECT IsAdmin FROM Users(NOLOCK) WHERE UserID = @UserID;",
                    new SqlParameter("@UserID", userID)));

                if (isAdmin)
                {
                    litMenu.Text = "<li><a href='createtest.aspx'><span>Create Test</span></a></li>";
                    litMenu.Text += "<li><a href='edittest.aspx'><span>Edit Test</span></a></li>";
                    litMenu.Text += "<li><a href='gradetest.aspx'><span>Grade Test</span></a></li>";
                }
                else
                {
                    litMenu.Text = "<li><a href='viewtest.aspx'><span>View Test Grades</span></a></li>";
                    litMenu.Text += "<li><a href='taketest.aspx'><span>Take Test</span></a></li>";
                }
            }
            else
            {
                Response.Redirect("Login.aspx", true);
            }
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}