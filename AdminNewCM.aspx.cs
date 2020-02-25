using ChangeManagementSystem.RequestLibrary;
using ChangeManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChangeManagementSystem
{

    public partial class NewCM : System.Web.UI.Page
    {
        private System.Windows.Forms.WebBrowser webBrowser1;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Session["CMSuccess"] = "Failure";
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetUserByID";
                objCommand.Parameters.Clear();
                objCommand.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());

                DataSet userData = objDB.GetDataSetUsingCmdObj(objCommand);
                DataTable dt = userData.Tables[0];
                string userName = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                lblUserName.Text = userName;


                int RequestID = Convert.ToInt32(Session["SelectedRequestType"].ToString());

                ViewState["requestNum"] = RequestID;

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

                        //Response.Write("<script>alert('" + hfQuestionID.Value + "');</script>");
                        col6Div.Controls.Add(hfQuestionID);

                    }
                }
                Session["IDs"] = idArray;

                //  buildSubmission();
            }
            else
            {
                //if session submission is successful
                if(Session["CMSuccess"].ToString() == "Success")
                {
                    submssionModal();
                }

                RequestTypeData requestTypeData = new RequestTypeData();
                Request requestType = requestTypeData.GetRequestTypeData(Convert.ToInt32(ViewState["requestNum"]));

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
                        rowDiv.ID = "rowDiv" + Guid.NewGuid().ToString("N");
                        rowDiv.Attributes.Add("class", "row mt-3 mb-3");
                        panelCM.Controls.Add(rowDiv);


                        System.Web.UI.HtmlControls.HtmlGenericControl colDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        colDiv.ID = "colDiv" + Guid.NewGuid().ToString("N");
                        colDiv.Attributes.Add("class", "col-lg-6");
                        rowDiv.Controls.Add(colDiv);


                        Label lblText = new Label();
                        lblText.Text = question_text;
                        lblText.CssClass = "form-text";
                        colDiv.Controls.Add(lblText);


                        System.Web.UI.HtmlControls.HtmlGenericControl col6Div = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        col6Div.ID = "col6Div" + Guid.NewGuid().ToString("N");
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
                        hfQuestionID.ID = "hfQuestionID" + Guid.NewGuid().ToString("N");
                        hfQuestionID.ClientIDMode = System.Web.UI.ClientIDMode.Static;

                        //Response.Write("<script>alert('" + hfQuestionID.Value + "');</script>");
                        col6Div.Controls.Add(hfQuestionID);

                    }
                }
                Session["IDs"] = idArray;
            }
        }

        private void submssionModal()
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#mdlCMSubmssion').modal('show');", true);

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userID = Session["UserID"].ToString();
            List<int> questionIDs = (List<int>)Session["IDs"];
            List<int> submissionQuestionIDs = (List<int>)Session["SubmissionIDs"];

            List<QuestionResponse> questionResponseList = new List<QuestionResponse>();
            if (questionIDs != null)
            {
                foreach (int id in questionIDs)
                {
                    string questID = id.ToString();
                    string response = Request["ctl00$CPH1$" + questID];
                    //Response.Write("<script>alert('" + response + "');</script>");

                    //create question object w/o cmid
                    QuestionResponse questionResponse = new QuestionResponse(id, response);
                    //add to quiestion response list
                    questionResponseList.Add(questionResponse);
                }

                bool valid = true;

                for (int i = 0; i < questionResponseList.Count; i++)
                {
                    String strResponse = questionResponseList[i].Response.ToString();

                    if (!Validation.ValidateForm(strResponse))
                    {
                        valid = false;
                    }

                    if (valid == false)
                    {
                        break;
                    }
                }

                if (valid)
                {
                    string detailedDesc = txtDescResponse.Text;
                    DateTime desiredDate;
                    string quesCom = txtQuesCom.Text;
                    string CMProjName = txtCMname.Text;

                    if (!Validation.ValidateBottomForm(detailedDesc, txtDesiredDate.Text, quesCom, CMProjName))
                    {
                        lblErrorMessage.Visible = true;
                    }
                    else
                    {
                        desiredDate = DateTime.Parse(txtDesiredDate.Text);
        
                        string filename = Path.GetFileName(fuScreenshots.FileName);
                        string contentType = fuScreenshots.PostedFile.ContentType;
                        using (Stream fs = fuScreenshots.PostedFile.InputStream)
                        {
                            using (BinaryReader br = new BinaryReader(fs))
                            {
                                byte[] byte1 = br.ReadBytes((Int32)fs.Length);
                                int requestType = Convert.ToInt32(Session["SelectedRequestType"].ToString());

                                //create cm-request object based on list and all other fields
                                CMRequest newCmRequest = new CMRequest("Not Assigned", detailedDesc, CMProjName, byte1, null, null, null, null, quesCom, null, DateTime.Now, userID, null, requestType, desiredDate, questionResponseList);
                                DBConnect ObjDb = new DBConnect();
                                SqlCommand objCommand = new SqlCommand();
                                objCommand.CommandType = CommandType.StoredProcedure;
                                objCommand.CommandText = "InsertCMRequest";
                                objCommand.Parameters.AddWithValue("@CMStatus", newCmRequest.CMStatus);
                                objCommand.Parameters.AddWithValue("@Attachment1", newCmRequest.att1);
                                objCommand.Parameters.AddWithValue("@Attachment2", newCmRequest.att2);
                                objCommand.Parameters.AddWithValue("@Attachment3", newCmRequest.att3);
                                objCommand.Parameters.AddWithValue("@Attachment4", newCmRequest.att4);
                                objCommand.Parameters.AddWithValue("@Attachment5", newCmRequest.att5);
                                objCommand.Parameters.AddWithValue("@Question", newCmRequest.questCom);
                                objCommand.Parameters.AddWithValue("@UserID", userID);
                                objCommand.Parameters.AddWithValue("@DesiredDate", desiredDate);
                                objCommand.Parameters.AddWithValue("@RequestTypeID", requestType);
                                objCommand.Parameters.AddWithValue("@LastUpdateDate", DateTime.Now);
                                objCommand.Parameters.AddWithValue("@CMProjName", CMProjName);
                                objCommand.Parameters.AddWithValue("@DetailDescription", newCmRequest.detailDescription);

                                ObjDb.GetConnection().Open();
                                int resultID = Convert.ToInt32(ObjDb.ExecuteScalarFunction(objCommand));
                                //Response.Write("<script>alert('" + resultID + "');</script>");
                                ObjDb.CloseConnection();

                                foreach (QuestionResponse qr in questionResponseList)
                                {
                                    try
                                    {
                                        QuestionResponse newResponses = new QuestionResponse(resultID, qr.QuestionID, qr.Response);
                                        DBConnect ObjDb2 = new DBConnect();
                                        SqlCommand objCommand2 = new SqlCommand();
                                        objCommand2.CommandType = CommandType.StoredProcedure;
                                        objCommand2.CommandText = "InsertResponse";
                                        objCommand2.Parameters.AddWithValue("@CMID", resultID);
                                        objCommand2.Parameters.AddWithValue("@QuestionID", qr.QuestionID);
                                        objCommand2.Parameters.AddWithValue("@Response", qr.Response);
                                        ObjDb2.GetConnection().Open();
                                        ObjDb2.ExecuteScalarFunction(objCommand2);
                                        ObjDb2.CloseConnection();
                                    }
                                    catch
                                    {
                                        Response.Write("<script>alert('Error');</script>");
                                    }

                                }
                            }
                        }

                        Session["CMSuccess"] = "Success";
                        submssionModal();
                        //lblErrorMessage.Visible = true;
                        //lblErrorMessage.Text = "Your request has been successfully submitted!";
                        //lblErrorMessage.ForeColor = System.Drawing.Color.Green;
                    }     
                   
                }
                else
                {
                    Session["CMSuccess"] = "Failure";
                    lblErrorMessage.Visible = true;
                }
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }
    }
}
