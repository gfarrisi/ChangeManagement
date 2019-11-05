using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Empty_Project_Template
{
    public partial class NewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string submission = txtName.Value + " has been added as a user.";
            Response.Write("<script>alert('" + submission + "');</script>");

            txtName.Value = string.Empty;
            txtEmail.Value = string.Empty;
            txtTUID.Value = string.Empty;
            txtCollege.Value = string.Empty;
       
        }
    }
}