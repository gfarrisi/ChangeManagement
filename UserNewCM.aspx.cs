using ChangeManagementSystem.RequestLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChangeManagementSystem
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        private System.Windows.Forms.WebBrowser webBrowser1;
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

                //to write to session
                List<int> idArray = new List<int>();

                foreach (Question question in requestType.requestQuestions)
                {
                    if (question.Question_ID < 92)
                    {
                        string question_text = question.Question_Text;
                        string question_control = question.Question_Control;
                        int question_id = question.Question_ID;
                        List<string> question_options = question.Question_Options;
                        idArray.Add(question_id);

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
                            rbList.Attributes.Add("name", question_id.ToString());
                            rbList.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                            col6Div.Controls.Add(rbList);

                        }
                        else if (question_control == "TextBox")
                        {
                            TextBox txtAnswer = new TextBox();
                            txtAnswer.CssClass = "form-control";
                            txtAnswer.ID = question_id.ToString();
                            txtAnswer.Attributes.Add("name", txtAnswer.ClientIDMode.ToString());
                            txtAnswer.ClientIDMode = System.Web.UI.ClientIDMode.Static;
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
                            ddlOptions.Attributes.Add("name", question_id.ToString());
                            ddlOptions.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                        }

                        HiddenField hfQuestionID = new HiddenField();
                        hfQuestionID.Value = question_id.ToString();
                        hfQuestionID.ID = "hfQuestionID";
                        hfQuestionID.ClientIDMode = System.Web.UI.ClientIDMode.Static;

                        Response.Write("<script>alert('" + hfQuestionID.Value + "');</script>");
                        col6Div.Controls.Add(hfQuestionID);

                    }
                }
                Session["IDs"] = idArray;

                //  buildSubmission();
            }
        }


        protected void btnSubmitUser_Click(object sender, EventArgs e)
        {

            List<int> questionIDs = (List<int>)Session["IDs"];
            List<int> submissionQuestionIDs = (List<int>)Session["SubmissionIDs"];

            List<QuestionResponse> questionResponseList = new List<QuestionResponse>();
            if (questionIDs != null)
            {
                foreach (int id in questionIDs)
                {
                    string questID = id.ToString();
                    string response = Request["ctl00$CPH1$" + questID];
                    Response.Write("<script>alert('" + response + "');</script>");

                    //create question object w/o cmid
                    QuestionResponse questionResponse = new QuestionResponse(id, response);
                    //add to quiestion response list
                    questionResponseList.Add(questionResponse);
                }
                string detailedDesc = txtDescResponse.Text;
                string desiredDate = txtDesiredDate.Text;
                string quesCom = txtQuesCom.Text;

                string filename = Path.GetFileName(fuScreenshots.FileName);
                string contentType = fuScreenshots.PostedFile.ContentType;
                using (Stream fs = fuScreenshots.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] byte1 = br.ReadBytes((Int32)fs.Length);


                        //create cm-request object based on list and all other fields
                        // CMRequest cmRequest = new CMRequest("Not Assigned", byte1, null, null, null, null, );



                        //stored procedure - insert into CM_Request
                        //pass CMRequest object data as params into stored procedures
                        //in stored procedure return CMID



                        //for each question is question response
                        //stored procedure - insert into cm_response
                        //using CMID and question list objects as paramaters 

                    }

                }









            }
        }
    }
}