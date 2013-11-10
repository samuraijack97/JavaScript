using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JavaScriptSite
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoginIn_Click(object sender, EventArgs e)
        {
            string email = string.Empty;
            if (!string.IsNullOrEmpty(Request.Form["email"]))
            {
                email = Request.Form["email"];
            }
            else
            {
                return;
            }

            email = email.ToLowerInvariant().Trim();

            string password = txtPassword.Text;

            List<List<string>> username_password = Database.ExecuteSQL("SELECT Password, SaltKey FROM Users(NOLOCK) WHERE Email = @Email;",
                new List<string>() { "Password", "SaltKey" }, new List<SqlParameter>() { new SqlParameter("@Email", email) });

            if (username_password == null)
            {
                return;
            }

            string encryptedPassword = BCrypt.Net.BCrypt.HashPassword(password, username_password[0][1]);

            if (!encryptedPassword.Equals(username_password[0][0]))
            {
                return;
            }

            string userID = Database.ExecuteSQL("SELECT UserID FROM Users(NOLOCK) WHERE Email = @Email", 
                new SqlParameter("@Email", email)).ToString();

            Session.Add("LoggedIn", userID);

            Response.Redirect("default.aspx", true);
        }
    }
}