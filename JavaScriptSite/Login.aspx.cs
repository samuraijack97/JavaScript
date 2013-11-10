using System;
using System.Collections.Generic;
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
            string userName = string.Empty;
            if (!string.IsNullOrEmpty(Request.Form["name"]))
            {
                userName = Request.Form["name"];
            }
            else
            {
                return;
            }

            userName = userName.ToLowerInvariant().Trim();
        }
    }
}