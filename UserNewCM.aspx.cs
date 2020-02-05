using ChangeManagementSystem.RequestLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChangeManagementSystem
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int RequestID = Convert.ToInt32(Session["SelectedRequestType"].ToString());

                RequestTypeData requestTypeData = new RequestTypeData();
                Request requestType = requestTypeData.GetRequestTypeData(RequestID);

                Label lblHeading = new Label();
                lblHeading.Text = requestType.RequestName;
                lblHeading.CssClass = "form-text h4";
                panelCM.Controls.Add(lblHeading);

                foreach (Question question in requestType.requestQuestions)
                {
                    string question_text = question.Question_Text;
                    string question_control = question.Question_Control;
                    int question_id = question.Question_ID;
                    List<string> question_options = question.Question_Options;


                    System.Web.UI.HtmlControls.HtmlGenericControl rowDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    rowDiv.ID = "rowDiv";
                    rowDiv.Attributes.Add("class", "row mt-3 mb-3");
                    panelCM.Controls.Add(rowDiv);


                    System.Web.UI.HtmlControls.HtmlGenericControl colDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    colDiv.ID = "colDiv";
                    colDiv.Attributes.Add("class", "col-lg-6");
                    rowDiv.Controls.Add(colDiv);


                    Label lblText = new Label();
                    lblText.Text = question_text;
                    lblText.CssClass = "form-text";
                    colDiv.Controls.Add(lblText);


                    System.Web.UI.HtmlControls.HtmlGenericControl col6Div = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    col6Div.ID = "col6Div";
                    col6Div.Attributes.Add("class", "col-lg-6");
                    rowDiv.Controls.Add(col6Div);

                    if (question_control == "RadioButton")
                    {

                        RadioButtonList rbList = new RadioButtonList();
                        foreach (string option in question_options)
                        {
                            ListItem rbOption = new ListItem();
                            rbOption.Text = option;
                            rbList.Items.Add(rbOption);
                        }
                        rbList.CssClass = "form-check";
                        rbList.ID = question_id.ToString();
                        col6Div.Controls.Add(rbList);

                    }
                    else if (question_control == "TextBox")
                    {
                        TextBox txtAnswer = new TextBox();
                        txtAnswer.CssClass = "form-control";
                        txtAnswer.ID = question_id.ToString();
                        col6Div.Controls.Add(txtAnswer);
                    }
                    else if (question_control == "DropDownList")
                    {
                        DropDownList ddlOptions = new DropDownList();
                        ddlOptions.CssClass = "dropdown form-control";

                        foreach (string option in question_options)
                        {
                            ddlOptions.Items.Add(option);
                            col6Div.Controls.Add(ddlOptions);
                        }
                        ddlOptions.ID = question_id.ToString();
                    }

                    HiddenField hfQuestionID = new HiddenField();
                    hfQuestionID.Value = question_id.ToString();
                    hfQuestionID.ID = "hfQuestionID";

                    Response.Write("<script>alert('" + hfQuestionID.Value + "');</script>");
                    col6Div.Controls.Add(hfQuestionID);

                }
                buildSubmission();
            }
        }
        public void buildSubmission()
        {

            RequestTypeData requestTypeData = new RequestTypeData();
            Request requestType = requestTypeData.GetScreenshotAndSubmission();

            Label lblHeading = new Label();
            lblHeading.Text = "Screenshots";
            lblHeading.CssClass = "form-text h4";
            panelCM.Controls.Add(lblHeading);

            foreach (Question question in requestType.requestQuestions)
            {
                string question_text = question.Question_Text;
                string question_control = question.Question_Control;
                int question_id = question.Question_ID;
                List<string> question_options = question.Question_Options;

                System.Web.UI.HtmlControls.HtmlGenericControl rowDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                rowDiv.ID = "rowDiv";
                rowDiv.Attributes.Add("class", "row mt-3 mb-3");
                panelCM.Controls.Add(rowDiv);


                System.Web.UI.HtmlControls.HtmlGenericControl colDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                colDiv.ID = "colDiv";
                colDiv.Attributes.Add("class", "col-lg-6");
                rowDiv.Controls.Add(colDiv);


                Label lblText = new Label();
                lblText.Text = question_text;
                lblText.CssClass = "form-text";
                colDiv.Controls.Add(lblText);


                System.Web.UI.HtmlControls.HtmlGenericControl col6Div = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                col6Div.ID = "col6Div";
                col6Div.Attributes.Add("class", "col-lg-6");
                rowDiv.Controls.Add(col6Div);

                if (question_control == "RadioButton")
                {
                    RadioButtonList rbList = new RadioButtonList();
                    foreach (string option in question_options)
                    {
                        ListItem rbOption = new ListItem();
                        rbOption.Text = option;
                        rbList.Items.Add(rbOption);
                    }
                    rbList.CssClass = "form-check";
                    rbList.ID = question_id.ToString();
                    col6Div.Controls.Add(rbList);
                }
                else if (question_control == "TextBox")
                {
                    TextBox txtAnswer = new TextBox();
                    txtAnswer.CssClass = "form-control";
                    txtAnswer.ID = question_id.ToString();
                    col6Div.Controls.Add(txtAnswer);
                }
                else if (question_control == "FileUpload")
                {
                    FileUpload fuScreenshots = new FileUpload();
                    fuScreenshots.CssClass = "form-control-file";
                    fuScreenshots.AllowMultiple = true;
                    fuScreenshots.ID = question_id.ToString();
                    col6Div.Controls.Add(fuScreenshots);
                }
                else if (question_control == "Calendar")
                {
                    //   Calendar calendar = new Calendar();
                    ////   calendar.CssClass = "input-group date";
                    TextBox calendar = new TextBox();
                    calendar.CssClass = "form-control";
                    calendar.TextMode = TextBoxMode.Date;
                    calendar.ID = question_id.ToString();
                    col6Div.Controls.Add(calendar);
                }
                else if (question_control == "DropDownList")
                {
                    DropDownList ddlOptions = new DropDownList();
                    ddlOptions.CssClass = "dropdown";

                    foreach (string option in question_options)
                    {
                        ddlOptions.Items.Add(option);

                    }
                    ddlOptions.ID = question_id.ToString();
                    col6Div.Controls.Add(ddlOptions);

                }

                HiddenField hfQuestionID = new HiddenField();
                hfQuestionID.ID = "hfQuestionIDSubmission";
                hfQuestionID.Value = question_id.ToString();

                col6Div.Controls.Add(hfQuestionID);
            }

        }

        protected void btnSubmitUser_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.HtmlElement tableElem = webBrowser1.Document.GetElementById(tableID);  GetElementById(string id);
            Response.Write("<script>alert('this is working');</script>");
            //take every question from page 

            List<Question> questionList = new List<Question>();

                //foreach (input control on the page){
                    //get the id and response
                    //Question question = new Question(id, response);
                    //add to list of questions
                    //questionList.add(question);
                //}
                   
            //create question object w/o cmid
            int questionID = 1;
            string questionResponse = "";
            //add to quiestion response list
            //create cm-request object based on list and all other fields
            //stored procedure - insert into CM_Request
            //pass CMRequest object data as params into stored procedures
            //in stored procedure return CMID
            //for each question is question response
            //stored procedure - insert into cm_response
            //using CMID and question list objects as paramaters 


        }
    }
}