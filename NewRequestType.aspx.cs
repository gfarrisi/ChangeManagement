using ChangeManagementSystem.RequestLibrary;
using ChangeManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChangeManagementSystem
{
    public partial class NewRequestType : System.Web.UI.Page
    {

        public int questionOrder;

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
                    Session["DeletedItem"] = false;
                    //added to check if page load was triggered by refresh
                    ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                    Session["SessionId"] = ViewState["ViewStateId"].ToString();

                    int questionID = 0;
                    Session["QuestionID"] = questionID;
                    Session["request"] = null; //reset request object

                    DBConnect db = new DBConnect();
                    SqlCommand objCommand = new SqlCommand();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "GetUserByID";
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());

                    DataSet userData = db.GetDataSetUsingCmdObj(objCommand);
                    DataTable dt = userData.Tables[0];
                    string userName = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                    lblUserName.Text = userName;

                    questionOrder = 1;
                }
                else
                {

                }


            }

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
                    if (Session["UserType"].ToString() == "Admin")
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            Response.Write("<script>alert('Request type Constraint is created and now available to users.');</script>");
            //add validation!!

            JavaScriptSerializer js = new JavaScriptSerializer();
            string serializedRequest = Session["request"] == null ? null : Session["request"].ToString();
            List<Question> request = js.Deserialize<List<Question>>(serializedRequest);


            DBConnect db = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetLastTypeID";
            objCommand.Parameters.Clear();

            DataSet userData = db.GetDataSetUsingCmdObj(objCommand);
            DataTable dt = userData.Tables[0];
            int requestTypeID = Convert.ToInt32(dt.Rows[0]["CurrentRequestID"].ToString()) + 1;

            string requestTypeName = txtRequestName.Text;

            foreach (Question question in request)
            {
                string options = "";
                //link options if exist by comma seperate list
                for (int i = 0; i < question.Question_Options.Count; i++)
                {
                    if (i == (question.Question_Options.Count - 1))
                    {
                        options += question.Question_Options[i];
                    }
                    else
                    {
                        options += question.Question_Options[i] + ",";
                    }

                }


                db = new DBConnect();
                objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "InsertNewRequestType";
                objCommand.Parameters.Clear();
                objCommand.Parameters.AddWithValue("@RequestTypeID", requestTypeID);
                objCommand.Parameters.AddWithValue("@RequestTypeName", requestTypeName);
                objCommand.Parameters.AddWithValue("@QuestionText", question.Question_Text);
                objCommand.Parameters.AddWithValue("@QuestionControl", question.Question_Control);
                objCommand.Parameters.AddWithValue("@QuestionOptions", options);
                db.GetConnection().Open();
                //int resultID = db.DoUpdateUsingCmdObj(objCommand);
                // userData = db.GetDataSetUsingCmdObj(objCommand);
                int resultID = Convert.ToInt32(db.ExecuteScalarFunction(objCommand));
                if (resultID == 0)
                {
                    Response.Write("<script>alert('suncess!');</script>");
                    db.CloseConnection();
                    Response.Redirect("AdminDashboard.aspx");
                }
                Response.Write("<script>alert('" + resultID + "');</script>");


            }

        }



        protected void btnAdd_ServerClick(object sender, EventArgs e)
        {
            HttpCookie deletedItemCookie = Request.Cookies["DeletedItem"];
            HttpCookie editedItemCookie = Request.Cookies["EditedItem"];
            if (deletedItemCookie != null)
            {
                Boolean isDeteled = Convert.ToBoolean(deletedItemCookie.Value);
                // Response.Write("<script>alert('Request type Constraint is created and now available to users.');</script>");

                if (isDeteled == true)
                {
                    //remove old cookie and reset to false
                    HttpContext.Current.Response.Cookies.Remove("DeletedItem");
                    deletedItemCookie.Expires = DateTime.Now.AddDays(-10);
                    deletedItemCookie.Value = null;
                    HttpContext.Current.Response.Cookies.Set(deletedItemCookie);

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    HttpCookie reqCookies = Request.Cookies["newRequestObj"];
                    List<Question> request = new List<Question>();
                    if (reqCookies != null)
                    {
                        HttpCookie serializedNewRequest = HttpContext.Current.Request.Cookies["newRequestObj"];
                        request = js.Deserialize<List<Question>>(Server.UrlDecode(serializedNewRequest.Value));
                        var serializedResult = js.Serialize(request);
                        Session["request"] = serializedResult;
                        createForm();
                    }


                }
            }
            else if (editedItemCookie != null)
            {
                Boolean isEdited = Convert.ToBoolean(editedItemCookie.Value);
                if (isEdited == true)
                {
                    //remove old cookie and reset to false
                    HttpContext.Current.Response.Cookies.Remove("EditedItem");
                    editedItemCookie.Expires = DateTime.Now.AddDays(-10);
                    editedItemCookie.Value = null;
                    HttpContext.Current.Response.Cookies.Set(editedItemCookie);
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    HttpCookie reqCookies = Request.Cookies["newRequestObj"];
                    List<Question> request = new List<Question>();
                    if (reqCookies != null)
                    {
                        HttpCookie serializedNewRequest = HttpContext.Current.Request.Cookies["newRequestObj"];
                        request = js.Deserialize<List<Question>>(Server.UrlDecode(serializedNewRequest.Value));
                        var serializedResult = js.Serialize(request);
                        Session["request"] = serializedResult;
                        addQuestion();
                        createForm();
                    }

                }
            }
            else
            {
                //validate   
                if (validateModal())
                {
                    lblControlTextError.Visible = false;
                    lblControlTypeError.Visible = false;
                    clearModal.Value = "true";
                    addQuestion();
                    createForm();
                    addButton();
                }

            }


        }
        public Boolean validateModal()
        {
            string controlText = Request["control-text"];
            string controlType = Request["control-type"];
            // string controlText = txtControl.Text;
            if (controlText == "" || (controlType == "" || controlType == "--"))
            {
                if (controlText == "")
                {
                    lblControlTextError.Visible = true;
                }
                else
                {
                    lblControlTextError.Visible = false;
                }

                if (controlType == "" || controlType == "--")
                {
                    lblControlTypeError.Visible = true;
                }
                else
                {
                    lblControlTypeError.Visible = false;
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#mdlAddQuestion').modal('show');", true);
                clearModal.Value = "false";
                return false;

            }
            return true;
        }

        public void addButton()
        {
            Button iconWrapper = new Button();
            iconWrapper.ID = "iconWrapper";
            iconWrapper.Text = "Edit2";
            iconWrapper.Visible = false;

            newRequestType_container.Controls.Add(iconWrapper);
            //newRequestType_container.Attributes.Add("onclick", "edit();");
        }

        public void addQuestion()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            int questionID = Convert.ToInt32(Session["QuestionID"].ToString());
            questionID++;
            if (Session["request"] != null)
            {
                //get serialized js request and convert it into list of questions            
                string serializedRequest = Session["request"] == null ? null : Session["request"].ToString();
                List<Question> request = js.Deserialize<List<Question>>(serializedRequest);
                Response.Write("<script>console.log('request," + request + "');</script>");

                string controlType = Request["control-type"];
                string controlText = Request["control-text"];
                // string controlText = txtControl.Text;
                List<string> options = new List<string>();
                if (controlType != "TextBox")
                {
                    HttpCookie reqCookies = Request.Cookies["optioncookie"];
                    if (reqCookies != null)
                    {
                        HttpCookie optionCookie = HttpContext.Current.Request.Cookies["optioncookie"];

                        options = js.Deserialize<List<string>>(Server.UrlDecode(optionCookie.Value));
                    }
                }
                Question newQuestion = new Question(controlText, controlType, questionID, options);

                Session["QuestionID"] = questionID;

                //add session for creating form
                request.Add(newQuestion);
                Session["request"] = js.Serialize(request);
                //add session serialized for javascript edit and delete buttons



                questionOrder++;
                Session["questionOrder"] = questionOrder;


            }
            else
            {

                List<Question> requestFirst = new List<Question>();

                string controlType = Request["control-type"];
                string controlText = Request["control-text"];
                // string controlText = txtControl.Text;// Request["control-text"];
                List<string> options = new List<string>();
                if (controlType != "TextBox")
                {
                    HttpCookie reqCookies = Request.Cookies["optioncookie"];
                    if (reqCookies != null)
                    {
                        HttpCookie optionCookie = HttpContext.Current.Request.Cookies["optioncookie"];

                        options = js.Deserialize<List<string>>(Server.UrlDecode(optionCookie.Value));

                    }
                }

                Question newQuestion = new Question(controlText, controlType, questionID, options);
                Session["QuestionID"] = questionID;

                requestFirst.Add(newQuestion);
                var serializedResult = js.Serialize(requestFirst);
                Session["request"] = serializedResult;

                List<Question> request = js.Deserialize<List<Question>>(serializedResult);

                questionOrder++;
                Session["questionOrder"] = questionOrder;

                //Response.Write("<script>alert('" + controlType + controlText + "');</script>");
            }
        }




        public void createForm()
        {
            if (Session["request"] != null)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();

                //get serialized js request and convert it into list of questions
                string serializedRequest = Session["request"] == null ? null : Session["request"].ToString();
                List<Question> request = js.Deserialize<List<Question>>(serializedRequest);

                newRequestType_container.Controls.Clear();
                newRequestType_container.Dispose();

                foreach (IDisposable control in newRequestType_container.Controls)
                {
                    control.Dispose();
                }
                // int questionID = Convert.ToInt32(Session["QuestionID"].ToString());

                foreach (Question question in request)
                {
                    string question_text = question.Question_Text;
                    string question_control = question.Question_Control;
                    int question_id = question.Question_ID;
                    List<string> question_options = question.Question_Options;

                    System.Web.UI.HtmlControls.HtmlGenericControl rowDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    rowDiv.ID = "rowDiv__" + question_id;
                    rowDiv.Attributes.Add("class", "row mt-3 mb-3");
                    newRequestType_container.Controls.Add(rowDiv);

                    System.Web.UI.HtmlControls.HtmlGenericControl firstCol6Div = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    firstCol6Div.ID = "firstCol6Div__" + question_id;
                    firstCol6Div.Attributes.Add("class", "col-lg-5 ml-3");
                    rowDiv.Controls.Add(firstCol6Div);

                    Label lblText = new Label();
                    lblText.Text = question_text;
                    lblText.CssClass = "form-text";
                    firstCol6Div.Controls.Add(lblText);


                    System.Web.UI.HtmlControls.HtmlGenericControl secondCol6Div = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    secondCol6Div.ID = "secondCol6Div__" + question_id;
                    secondCol6Div.Attributes.Add("class", "col-lg-5");
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
                    System.Web.UI.HtmlControls.HtmlGenericControl newRequestTypeDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    newRequestTypeDiv.ID = "newRequestTypeDiv__" + question_id;

                    System.Web.UI.HtmlControls.HtmlGenericControl editIcon = new System.Web.UI.HtmlControls.HtmlGenericControl("i");
                    editIcon.ID = "edit_" + question_id.ToString();
                    editIcon.Attributes.Add("class", "far fa-edit mt-1 pointer");
                    //iconWrapper.Controls.Add(editIcon);
                    newRequestTypeDiv.Controls.Add(editIcon);
                    newRequestTypeDiv.Attributes.Add("onclick", "edit(this.id);");

                    rowDiv.Controls.Add(newRequestTypeDiv);


                    System.Web.UI.HtmlControls.HtmlGenericControl deleteBtnDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    deleteBtnDiv.ID = "deleteBtnDiv__" + question_id;

                    System.Web.UI.HtmlControls.HtmlGenericControl deleteIcon = new System.Web.UI.HtmlControls.HtmlGenericControl("i");
                    deleteIcon.ID = "delete_" + question_id.ToString();
                    deleteIcon.Attributes.Add("class", "fa fa-times x-icon mt-1 pointer");
                    //iconWrapper.Controls.Add(editIcon);
                    deleteBtnDiv.Controls.Add(deleteIcon);
                    deleteBtnDiv.Attributes.Add("onclick", "deleteQuestion(this.id);");

                    rowDiv.Controls.Add(deleteBtnDiv);
                }

            }
        }
        protected void btnEditIcon_Click(object sender, EventArgs e)
        {
            //LinkButton iconWrapper = sender as LinkButton;
            //string id = iconWrapper.ID;
            Response.Write("<script>alert('edit clicked');</script>");
            //Response.Write("<script>alert('"+id+"');</script>");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('create clicked');</script>");
        }
    }
}