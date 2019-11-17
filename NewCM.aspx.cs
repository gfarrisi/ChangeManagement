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

                int RequestID = Convert.ToInt32(Session["SelectedRequestType"].ToString());
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
                     
                            Label lblText = new Label();
                            lblText.Text = question_text;
                            lblText.CssClass = "form-text";
                            panelCM.Controls.Add(lblText);

                            if (question_control == "RadioButtonList")
                            {
                                foreach (string option in question_options)
                                {
                                    RadioButton rbOption = new RadioButton();
                                    rbOption.Text = option;
                                    rbOption.CssClass = "form-check";
                                    panelCM.Controls.Add(rbOption);
                                }
                            }
                            else if (question_control == "TextBox")
                            {
                                TextBox txtAnswer = new TextBox();
                                txtAnswer.CssClass = "form-control";
                                panelCM.Controls.Add(txtAnswer);
                            }
                            else if (question_control == "DropDownList")
                            {
                                DropDownList ddlOptions = new DropDownList();
                                ddlOptions.CssClass = "dropdown";

                                foreach (string option in question_options)
                                {
                                    ddlOptions.Items.Add(option);                           
                                    panelCM.Controls.Add(ddlOptions);
                                }
                                
                            }
                                                                                                     
                        }
                    }



                }
                buildSubmission();


            }
            
        }
        public void buildSubmission()
        {
            int RequestID = 9999;
            RequestTypes types = new RequestTypes();
            foreach (Request requestType in types.requestTypes)
            {
                if (requestType.RequestID == RequestID)
                {
                    foreach (Question question in requestType.requestQuestions)
                    {
                        string question_text = question.Question_Text;
                        string question_control = question.Question_Control;
                        string question_order = question.Question_Order;
                        List<string> question_options = question.Question_Options;

                        Label lblText = new Label();
                        lblText.Text = question_text;
                        lblText.CssClass = "form-text";
                        panelCM.Controls.Add(lblText);

                        if (question_control == "RadioButtonList")
                        {
                            foreach (string option in question_options)
                            {
                                RadioButton rbOption = new RadioButton();
                                rbOption.Text = option;
                                rbOption.CssClass = "form-check";
                                panelCM.Controls.Add(rbOption);
                            }
                        }
                        else if (question_control == "TextBox")
                        {
                            TextBox txtAnswer = new TextBox();
                            txtAnswer.CssClass = "form-control";
                            panelCM.Controls.Add(txtAnswer);
                        }
                        else if (question_control == "DropDownList")
                        {
                            DropDownList ddlOptions = new DropDownList();
                            ddlOptions.CssClass = "dropdown";

                            foreach (string option in question_options)
                            {
                                ddlOptions.Items.Add(option);
                                panelCM.Controls.Add(ddlOptions);
                            }

                        }

                    }
                }



            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        
    }
}