using ChangeManagementSystem.RequestLibrary;
using ChangeManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace ChangeManagementSystem
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        List<int> idArray = new List<int>();
        private System.Windows.Forms.WebBrowser webBrowser1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (isAuthenticated() == false)
            {
                Session["Authenticated"] = false;
                Response.Redirect("default.aspx");
            }
            else if (isAuthenticated() == true)
            {
                if (!IsPostBack)
                {
                    generateForm(true);
                }
                if (IsPostBack)
                {
                    panelCM.Attributes.Clear();
                    generateTypeQuestions();

                }

            }
            else
            {
                generateTypeQuestions();
            }
        }
        private void generateTypeQuestions()
        {
            RequestTypeData requestTypeData = new RequestTypeData();
            Request requestType = requestTypeData.GetRequestTypeData(Convert.ToInt32(ViewState["requestNum"]));

            spanCM.InnerHtml = requestType.RequestName;
            //to write to session
            //List<int> idArray = new List<int>();
            //try
            //{
            foreach (Question question in requestType.requestQuestions)
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
                lblText.Text = question_text + " *";
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
                else if (question_control == "Dropdown")
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
                else if (question_control == "Calendar")
                {
                    TextBox txtAnswer = new TextBox();
                    txtAnswer.CssClass = "form-control";
                    txtAnswer.ID = question_id.ToString();

                    txtAnswer.Attributes.Add("name", txtAnswer.ClientIDMode.ToString());
                    txtAnswer.TextMode = TextBoxMode.Date;
                    txtAnswer.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    col6Div.Controls.Add(txtAnswer);
                }

                HiddenField hfQuestionID = new HiddenField();
                hfQuestionID.Value = question_id.ToString();
                hfQuestionID.ID = "hfQuestionID" + Guid.NewGuid().ToString("N");
                hfQuestionID.ClientIDMode = System.Web.UI.ClientIDMode.Static;

                //Response.Write("<script>alert('" + hfQuestionID.Value + "');</script>");
                col6Div.Controls.Add(hfQuestionID);


            }
            Session["IDs"] = idArray;
            //}
            //catch
            //{
            //    lblErrorMessage.Visible = true;
            //}




        }
        private void generateForm(Boolean isValid)
        {
            //pass in boolean, determine which error to display
            //validSubmission or //BlankEntry
            Session["CMSuccess"] = "Failure";
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            //get user name for nav
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

            spanCM.InnerHtml = requestType.RequestName;

            //to write to session
            List<int> idArray = new List<int>();

            foreach (Question question in requestType.requestQuestions)
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
                lblText.Text = question_text + " *";
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
                else if (question_control == "Dropdown")
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
                else if (question_control == "Calendar")
                {
                    TextBox txtAnswer = new TextBox();
                    txtAnswer.CssClass = "form-control";
                    txtAnswer.ID = question_id.ToString();

                    txtAnswer.Attributes.Add("name", txtAnswer.ClientIDMode.ToString());
                    txtAnswer.TextMode = TextBoxMode.Date;
                    txtAnswer.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    col6Div.Controls.Add(txtAnswer);
                }

                HiddenField hfQuestionID = new HiddenField();
                hfQuestionID.Value = question_id.ToString();
                hfQuestionID.ID = "hfQuestionID";
                hfQuestionID.ClientIDMode = System.Web.UI.ClientIDMode.Static;

                //Response.Write("<script>alert('" + hfQuestionID.Value + "');</script>");
                col6Div.Controls.Add(hfQuestionID);


            }
            Session["IDs"] = idArray;

            //  buildSubmission();

        }
        protected Boolean isAuthenticated()
        {
            Boolean isAllowed = false;

            if (Session["Authenticated"] == null)
            {
                isAllowed = false;
            }
            else if (Session["Authenticated"] != null)
            {
                Boolean isAuthenticated = Boolean.Parse(Session["Authenticated"].ToString());

                if (!isAuthenticated)
                {
                    isAllowed = false;
                }
                else if (isAuthenticated)
                {
                    if (Session["UserType"].ToString() == "User")
                    {
                        isAllowed = true;
                    }
                    else
                    {
                        isAllowed = false;
                    }
                }
            }

            return isAllowed;
        }
        private void submssionModal()
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#mdlCMSubmssion').modal('show');", true);

        }

        protected void btnSubmitUser_Click(object sender, EventArgs e)
        {
            string userID = Session["UserID"].ToString();
            List<int> questionIDs = (List<int>)idArray;
            List<int> submissionQuestionIDs = (List<int>)Session["SubmissionIDs"];


            List<QuestionResponse> questionResponseList = new List<QuestionResponse>();
            if (questionIDs != null)
            {
                foreach (int id in questionIDs)
                {
                    string questID = id.ToString();
                    string response = Request["ctl00$CPH1$" + questID];
                    //Response.Write("<script>alert('" + response + "');</script>");

                    DateTime dDate;
                    if (DateTime.TryParse(response, out dDate))
                    {
                        QuestionResponse questionResponse = new QuestionResponse(id, String.Format("{0:MM/dd/yyyy}", dDate));
                        //add to quiestion response list
                        questionResponseList.Add(questionResponse);
                    }
                    else
                    {
                        //create question object w/o cmid
                        QuestionResponse questionResponse = new QuestionResponse(id, response);
                        //add to quiestion response list
                        questionResponseList.Add(questionResponse);
                    }
                }

                bool valid = true;

                try
                {
                    for (int i = 0; i < questionResponseList.Count; i++)
                    {
                        String strResponse = questionResponseList[i].Response.ToString();

                        if (!Validation.ValidateForm(strResponse))
                        {
                            valid = false;
                        }

                        if (valid == false)
                        {
                            lblErrorMessage.Visible = true;

                        }
                    }
                }
                catch
                {
                    // Response.Write("<script>alert('" +" VALIDATION FAILED" + "');</script>");
                    valid = false;
                    lblErrorMessage.Visible = true;
                }

                if (valid)
                {
                    string detailedDesc = txtDescResponse.Text;
                    DateTime desiredDate;
                    string quesCom = txtQuesCom.Text;
                    string CMProjName = txtCMname.Text;
                    byte[] byte0 = null;
                    byte[] byte1 = null;
                    byte[] byte2 = null;
                    byte[] byte3 = null;
                    byte[] byte4 = null;
                    string file1 = null;
                    string file2 = null;
                    string file3 = null;
                    string file4 = null;
                    string file5 = null;



                    if (!Validation.ValidateBottomForm(detailedDesc, txtDesiredDate.Text, quesCom, CMProjName))
                    {
                        if (fuScreenshots.PostedFiles == null)
                        {
                            lblErrorMessage.Visible = true;
                        }
                        lblErrorMessage.Visible = true;
                    }
                    else
                    {
                        desiredDate = DateTime.Parse(txtDesiredDate.Text);
                        bool validScreenshots = true;


                        foreach (HttpPostedFile file in fuScreenshots.PostedFiles)
                        {
                            if (!(Path.GetExtension(file.FileName) == ".pdf" ||
                                    Path.GetExtension(file.FileName) == ".PDF" ||
                                    Path.GetExtension(file.FileName) == ".PNG" ||
                                    Path.GetExtension(file.FileName) == ".png" ||
                                    Path.GetExtension(file.FileName) == ".JPG" ||
                                    Path.GetExtension(file.FileName) == ".jpg" ||
                                    Path.GetExtension(file.FileName) == ".xls" ||
                                    Path.GetExtension(file.FileName) == ".XLS" ||
                                    Path.GetExtension(file.FileName) == ".xlsx" ||
                                    Path.GetExtension(file.FileName) == ".XLSX" ||
                                    Path.GetExtension(file.FileName) == ".doc" ||
                                    Path.GetExtension(file.FileName) == ".DOC" ||
                                    Path.GetExtension(file.FileName) == ".docx" ||
                                    Path.GetExtension(file.FileName) == ".DOCX" ||
                                    Path.GetExtension(file.FileName) == ".csv" ||
                                    Path.GetExtension(file.FileName) == ".CSV"
                                   ))

                            {

                                lblScreenshotsError.Visible = true;
                                fuScreenshots.Attributes.Clear();
                                validScreenshots = false;



                            }

                            else if (validScreenshots == true)

                            {
                                for (int i = 0; i < fuScreenshots.PostedFiles.Count(); i++)
                                {

                                    if (i == 0)
                                    {
                                        string filename = Path.GetFileName(fuScreenshots.PostedFiles[0].FileName);
                                        file1 = filename;
                                        string contentType = fuScreenshots.PostedFiles[0].ContentType;
                                        using (Stream fs = fuScreenshots.PostedFiles[0].InputStream)
                                        {
                                            using (BinaryReader br = new BinaryReader(fs))
                                            {
                                                byte0 = br.ReadBytes((Int32)fs.Length);
                                                i++;
                                            }
                                        }
                                    }
                                    if (i == 1 && fuScreenshots.PostedFiles.Count() > 1)
                                    {
                                        string filename = Path.GetFileName(fuScreenshots.PostedFiles[1].FileName);
                                        file2 = filename;
                                        string contentType = fuScreenshots.PostedFiles[1].ContentType;
                                        using (Stream fs = fuScreenshots.PostedFiles[1].InputStream)
                                        {
                                            using (BinaryReader br = new BinaryReader(fs))
                                            {
                                                byte1 = br.ReadBytes((Int32)fs.Length);
                                                i++;
                                            }
                                        }
                                    }
                                    if (i == 2 && fuScreenshots.PostedFiles.Count() > 2)
                                    {
                                        string filename = Path.GetFileName(fuScreenshots.PostedFiles[2].FileName);
                                        file3 = filename;
                                        string contentType = fuScreenshots.PostedFiles[2].ContentType;
                                        using (Stream fs = fuScreenshots.PostedFiles[2].InputStream)
                                        {
                                            using (BinaryReader br = new BinaryReader(fs))
                                            {
                                                byte2 = br.ReadBytes((Int32)fs.Length);
                                                i++;
                                            }
                                        }
                                    }

                                    if (i == 3 && fuScreenshots.PostedFiles.Count() > 3)
                                    {
                                        string filename = Path.GetFileName(fuScreenshots.PostedFiles[3].FileName);
                                        file4 = filename;
                                        string contentType = fuScreenshots.PostedFiles[3].ContentType;
                                        using (Stream fs = fuScreenshots.PostedFiles[3].InputStream)
                                        {
                                            using (BinaryReader br = new BinaryReader(fs))
                                            {
                                                byte3 = br.ReadBytes((Int32)fs.Length);
                                                i++;
                                            }
                                        }
                                    }

                                    if (i == 4 && fuScreenshots.PostedFiles.Count() < 6 && fuScreenshots.PostedFiles.Count() > 4)
                                    {
                                        string filename = Path.GetFileName(fuScreenshots.PostedFiles[4].FileName);
                                        file5 = filename;
                                        string contentType = fuScreenshots.PostedFiles[4].ContentType;
                                        using (Stream fs = fuScreenshots.PostedFiles[4].InputStream)
                                        {
                                            using (BinaryReader br = new BinaryReader(fs))
                                            {
                                                byte4 = br.ReadBytes((Int32)fs.Length);
                                                i++;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (validScreenshots == true)
                        {
                            int requestType = Convert.ToInt32(Session["SelectedRequestType"].ToString());

                            //create cm-request object based on list and all other fields
                            CMRequest newCmRequest = new CMRequest("Not Assigned", detailedDesc, CMProjName, byte0, byte1, byte2, byte3, byte4, quesCom, null, DateTime.Now, userID, null, requestType, desiredDate, questionResponseList, file1, file2, file3, file4, file5);
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
                            objCommand.Parameters.AddWithValue("@filename1", newCmRequest.File1);
                            objCommand.Parameters.AddWithValue("@filename2", newCmRequest.File2);
                            objCommand.Parameters.AddWithValue("@filename3", newCmRequest.File3);
                            objCommand.Parameters.AddWithValue("@filename4", newCmRequest.File4);
                            objCommand.Parameters.AddWithValue("@filename5", newCmRequest.File5);

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
                            //    }
                            //}

                            Session["CMSuccess"] = "Success";
                            submssionModal();
                            //lblErrorMessage.Visible = true;
                            //lblErrorMessage.Text = "Your request has been successfully submitted!";
                            //lblErrorMessage.ForeColor = System.Drawing.Color.Green;
                            sendEmail();
                        }

                    }
                }

            }

            else
            {
                Session["CMSuccess"] = "Failure";
                lblErrorMessage.Visible = true;
            }
        }


        public void sendEmail()
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommandCMID = new SqlCommand();
            objCommandCMID.CommandType = CommandType.StoredProcedure;
            objCommandCMID.CommandText = "GetLastCMID";
            DataSet cmData = objDB.GetDataSetUsingCmdObj(objCommandCMID);
            DataTable cmTable = cmData.Tables[0];
            string CMID = cmTable.Rows[0]["CMID"].ToString();

            SqlCommand objCommandEmail = new SqlCommand();
            objCommandEmail.CommandType = CommandType.StoredProcedure;
            objCommandEmail.CommandText = "GetEmailByType";
            objCommandEmail.Parameters.AddWithValue("@Type", "New Request");

            DataSet emailData = objDB.GetDataSetUsingCmdObj(objCommandEmail);
            DataTable emailTable = emailData.Tables[0];

            Email objEmail = new Email();
            String strTO = "crm@temple.edu";
            String strFROM = "noreply@temple.edu";
            String strSubject = "CM #" + CMID + ": " + emailTable.Rows[0]["Subject"].ToString();
            String strMessage = emailTable.Rows[0]["Body"].ToString();

            try
            {
                objEmail.SendMail(strTO, strFROM, strSubject, strMessage);
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserDashboard.aspx");
        }
    }
}