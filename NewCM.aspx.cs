using Empty_Project_Template.RequestLibrary;
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

            if (!IsPostBack)
            {
                
                int RequestID = 1001;
                RequestTypes types = new RequestTypes();
                foreach(Request requestType in types.requestTypes)
                {
                    if (requestType.RequestID == RequestID)
                    {
                        foreach (Question question in requestType.requestQuestions)
                        {
                            string question_text = question.Question_Text;
                            string question_control = question.Question_Control;
                            string question_order = question.Question_Order;
                            List<string> question_options = question.Question_Options;

                            Response.Write("<script>alert('" + question.Question_Text + "," + question_control + "," + question_order + "');</script>");
                        }
                    }
                    
                   
                }

                

                lbl1.Text = "Workflow/Process";
                lbl2.Text = "Entity";
                lbl3.Text = "Description";
                rd1.Visible = true;
                rd2.Visible = true;
                rd3.Visible = true;
                rd4.Visible = true;
            }
            
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
                rd3.Visible = true;
                rd4.Visible = true;

                lbl1.Text = "Workflow/Process";
                lbl2.Text = "Entity";
                lbl3.Text = "Description";
           
            }
            else if (ddlRequestType.SelectedValue == "Entity")
            {
                rd1.Visible = false;
                rd2.Visible = false;
                rd3.Visible = false;
                rd4.Visible = false;

                lbl1.Text = "Display";
                lbl2.Text = "Plural";
                lbl3.Text = "Name";

            }
            else
            {
                rd1.Visible = false;
                rd2.Visible = false;
                rd3.Visible = false;
                rd4.Visible = false;

                lbl1.Text = "Entity";
                lbl2.Text = "Business Role";
                lbl3.Text = "Description";
            }
        }
    }
}