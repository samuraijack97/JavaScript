using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JavaScriptSite
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            litMessage.Text = string.Empty;

            string emailAddress = string.Empty;
            if (Request.Form["email"] != null)
            {
                emailAddress = Request.Form["email"].ToLowerInvariant().Trim();
            }
            else
            {
                litMessage.Text = "<p style='color: red; font-weight: bold;'>Please enter an email address.</p>";
                return;
            }

            string pattern = "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
            if (!Regex.Match(emailAddress, pattern).Success)
            {
                litMessage.Text = "<p style='color: red; font-weight: bold;'>Email address entered is not a valid email.</p>";
                return;
            }

            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (!password.Equals(confirmPassword))
            {
                litMessage.Text = "<p style='color: red; font-weight: bold;'>Passwords are not the same.</p>";
                return;
            }
            string salt = BCrypt.Net.BCrypt.GenerateSalt(7);

            string encrpytPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            Database.InsertRecord("INSERT Users VALUES (@FirstName, @LastName, @Email, @Password, @Salt, 0, 0, GETDATE(), GETDATE(), GETDATE(), @IPAddress);",
                new SqlParameter("@FirstName", (Request.Form["firstname"] as string ?? string.Empty)),
                new SqlParameter("@LastName", (Request.Form["firstname"] as string ?? string.Empty)),
                new SqlParameter("@Email", emailAddress), new SqlParameter("@Password", encrpytPassword),
                new SqlParameter("@Salt", salt), new SqlParameter("@IPAddress", HttpContext.Current.Request.UserHostAddress));
        }
    }
}