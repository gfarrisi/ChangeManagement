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
            string submission = txtField1.Value + " has been added as a user.";
            Response.Write("<script>alert('" + submission + "');</script>");

            txtField1.Value = string.Empty;
            txtField2.Value = string.Empty;
            txtField3.Value = string.Empty;
            txtField4.Value = string.Empty;
       
        }
    }
}