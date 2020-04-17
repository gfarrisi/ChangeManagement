using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChangeManagementSystem.Secure
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            if (url.Contains("pre-stem"))
            {
                Session.Clear();
                Session.Abandon();
                Response.Cookies.Clear();
                Response.Redirect("https://pre-stem.temple.edu/Shibboleth.sso/Logout?return=https://np-fim.temple.edu/idp/profile/Logout");
               
            }
            else if (url.Contains("np-stem"))
            {
                Session.Clear();
                Session.Abandon();
                Response.Cookies.Clear();
                Response.Redirect("https://np-stem.temple.edu/Shibboleth.sso/Logout?return=https://np-fim.temple.edu/idp/profile/Logout");
            }
          
        }
    }
}