using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChangeManagementSystem;

namespace ChangeManagementSystem
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        
        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAllRequests.aspx");
        }
        protected void btnNewRequest_Click(object sender, EventArgs e)
        {
            Response.Redirect("SelectRequestType.aspx");
        }
    }
}