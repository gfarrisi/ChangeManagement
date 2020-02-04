using ChangeManagementSystem.RequestLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChangeManagementSystem
{
    public partial class NewRequestType : System.Web.UI.Page
    {
        
        public int questionOrder;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                questionOrder = 1;
            }
                
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            Response.Write("<script>alert('Request type Constraint is created and now available to users.');</script>");

        }



        protected void btnAdd_ServerClick(object sender, EventArgs e)
        {
            addQuestion();
            createForm();
        }

        public void addQuestion()
        {
            List<Question> request = Session["request"] as List<Question>;
            if (request != null)
            {
                string controlType = Request["control-type"];
                string controlText = Request["control-text"];
                List<string> options = new List<string>();
                if (controlType != "TextBox")
                {
                    HttpCookie reqCookies = Request.Cookies["optioncookie"];
                    if (reqCookies != null)
                    {
                        HttpCookie optionCookie = HttpContext.Current.Request.Cookies["optioncookie"];
                        JavaScriptSerializer js = new JavaScriptSerializer();

                        options = js.Deserialize<List<string>>(Server.UrlDecode(optionCookie.Value));
                    }
                }
                //NEEDS UPDATED
                Question newQuestion = new Question(controlText, controlType, 4324,  options);

                request.Add(newQuestion);              
                Session["request"] = request;

                questionOrder++;
                Session["questionOrder"] = questionOrder;

              
            }
            else
            {

                List<Question> requestFirst = new List<Question>();

                string controlType = Request["control-type"];
                string controlText = Request["control-text"];
                List<string> options = new List<string>();
                if (controlType != "TextBox")
                {
                    HttpCookie reqCookies = Request.Cookies["optioncookie"];
                    if (reqCookies != null)
                    {
                        HttpCookie optionCookie = HttpContext.Current.Request.Cookies["optioncookie"];
                        JavaScriptSerializer js = new JavaScriptSerializer();
                    
                        options = js.Deserialize<List<string>>(Server.UrlDecode(optionCookie.Value));                                          
                        
                    }
                }

                ///NEEDS TO UPDATED!!
                Question newQuestion = new Question(controlText, controlType, 213213,  options);

                requestFirst.Add(newQuestion);
                Session["request"] = requestFirst;

                questionOrder++;
                Session["questionOrder"] = questionOrder;

                Response.Write("<script>alert('" + controlType + controlText + "');</script>");
            }
        }




        public void createForm()
        {
            List<Question> request = Session["request"] as List<Question>;
            foreach (Question question in request)
            {
                string question_text = question.Question_Text;
                string question_control = question.Question_Control;
                int question_id = question.Question_ID;
                List<string> question_options = question.Question_Options;

                System.Web.UI.HtmlControls.HtmlGenericControl rowDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                rowDiv.ID = "rowDiv";
                rowDiv.Attributes.Add("class", "row mt-3 mb-3");
                pnlNewRequestType.Controls.Add(rowDiv);

                System.Web.UI.HtmlControls.HtmlGenericControl firstCol6Div = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                firstCol6Div.ID = "firstCol6Div";
                firstCol6Div.Attributes.Add("class", "col-lg-6");
                rowDiv.Controls.Add(firstCol6Div);

                Label lblText = new Label();
                lblText.Text = question_text;
                lblText.CssClass = "form-text";
                firstCol6Div.Controls.Add(lblText);



                System.Web.UI.HtmlControls.HtmlGenericControl secondCol6Div = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                secondCol6Div.ID = "secondCol6Div";
                secondCol6Div.Attributes.Add("class", "col-lg-6");
                rowDiv.Controls.Add(secondCol6Div);

                if (question_control == "RadioButton")
                {
                    foreach (string option in question_options)
                    {
                        RadioButton rbOption = new RadioButton();
                        rbOption.Text = option;
                        rbOption.CssClass = "form-check";
                        secondCol6Div.Controls.Add(rbOption);
                    }
                }
                else if (question_control == "TextBox")
                {
                    TextBox txtAnswer = new TextBox();
                    txtAnswer.CssClass = "form-control";
                    secondCol6Div.Controls.Add(txtAnswer);
                }
                else if (question_control == "Dropdown")
                {
                    DropDownList ddlOptions = new DropDownList();
                    ddlOptions.CssClass = "dropdown form-control";

                    foreach (string option in question_options)
                    {
                        ddlOptions.Items.Add(option);
                        secondCol6Div.Controls.Add(ddlOptions);
                    }

                }
            }

        }

    }
}