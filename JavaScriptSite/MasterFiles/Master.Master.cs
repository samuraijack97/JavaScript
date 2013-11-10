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
            if (Session["LoggedIn"] != null)
            {
                int userID = (int)Session["LoggedIn"];

                bool isActive = Convert.ToBoolean(Database.ExecuteSQL("SELECT IsActive FROM Users WHERE UserID = @UserID;", new SqlParameter("@UserID", userID)));

                if (!isActive)
                {
                    Session.Add("Message", "Your account is not active");
                    Session.Remove("LoggedIn");
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