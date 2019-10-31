using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Empty_Project_Template
{
    public partial class NewCM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl1.Text = "Workflow/Process";
            lbl2.Text = "Entity";
            lbl3.Text = "Description";
            lbl4.Text = "Is this New or Revised?";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            txtField1.Value = string.Empty;
            txtField2.Value = string.Empty;
            txtField3.Value = string.Empty;
            Response.Write("<script>alert('Your new CM has been submitted! You will receive an email confirmation when the request is assigned.');</script>");
        }

        protected void ddlRequestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRequestType.SelectedValue == "Workflow")
            {
                rd1.Visible = true;
                rd2.Visible = true;
                lbl4.Visible = true;

                lbl1.Text = "Workflow/Process";
                lbl2.Text = "Entity";
                lbl3.Text = "Description";
                lbl4.Text = "Is this New or Revised?";
            }
            else if (ddlRequestType.SelectedValue == "Entity")
            {
                rd1.Visible = false;
                rd2.Visible = false;
                lbl4.Visible = false;

                lbl1.Text = "Display";
                lbl2.Text = "Plural";
                lbl3.Text = "Name";

            }
            else
            {
                rd1.Visible = false;
                rd2.Visible = false;
                lbl4.Visible = false;

                lbl1.Text = "Entity";
                lbl2.Text = "Business Role";
                lbl3.Text = "Description";
            }
        }
    }
}