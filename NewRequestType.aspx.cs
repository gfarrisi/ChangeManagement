using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Empty_Project_Template
{
    public partial class NewRequestType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){
                lblQ1.Visible = false;
                lblQ2.Visible = false;
                lblQ3.Visible = false;
                txtQ1.Visible = false;
                txtQ2.Visible = false;
                txtQ3.Visible = false;
                opt1Q3.Visible = false;
                opt2Q3.Visible = false;
            }
            
        }

        protected void btnAddQuestion_Click(object sender, EventArgs e)
        {
            if (ddlControlTypes.SelectedValue == "Short Answer")
            {
                if (lblQ1.Visible == false)
                {
                    lblQ1.Visible = true;
                    txtQ1.Visible = true;
                }
                else if (lblQ2.Visible == false)
                {
                    lblQ2.Visible = true;
                    txtQ2.Visible = true;
                }
            }
            if (ddlControlTypes.SelectedValue == "Multiple Choice")
            {
                lblQ3.Visible = true;
                txtQ3.Visible = true;
                opt1Q3.Visible = true;
                opt2Q3.Visible = true;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblQ1.Visible = false;
            lblQ2.Visible = false;
            lblQ3.Visible = false;
            txtQ1.Visible = false;
            txtQ2.Visible = false;
            txtQ3.Visible = false;
            opt1Q3.Visible = false;
            opt2Q3.Visible = false;

            Response.Write("<script>alert('Request type Constraint is created and now available to users.');</script>");

        }
    }
}