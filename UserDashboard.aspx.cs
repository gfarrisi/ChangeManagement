using ChangeManagementSystem.RequestLibrary;
using ChangeManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using IronPdf;
using System.Net;
using System.IO;

namespace ChangeManagementSystem
{
    public partial class UserDashboard : System.Web.UI.Page
    {
        DBConnect objDB;
        SqlCommand objCommand;
        DataSet dashboardData;
        SqlCommand objCommandDashboard;

        bool IsPageRefresh = false;
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
                    ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                    Session["SessionId"] = ViewState["ViewStateId"].ToString();
                    hiddenCMClicked.Value = null;

                    Session.Add("UserID", Session["TU_ID"].ToString()); // Admin user in database; will be preserved from login in the future

                    objDB = new DBConnect();
                    objCommand = new SqlCommand();
                    objCommandDashboard = new SqlCommand();

                    //get user name for nav
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "GetUserByID";
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());

                    DataSet userData = objDB.GetDataSetUsingCmdObj(objCommand);
                    DataTable dt = userData.Tables[0];
                    string userName = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                    lblUserName.Text = userName;


                    // Not assigned CMs

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "GetCMResponsesByUserByStatus";
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                    objCommand.Parameters.AddWithValue("@CMStatus", "not assigned");

                    DataSet cmRequestData = objDB.GetDataSetUsingCmdObj(objCommand);
                    DataTable dataTable = cmRequestData.Tables[0];


                    List<QuestionResponse> responseListNotAssigned = new List<QuestionResponse>();

                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            QuestionResponse questionResponse = new QuestionResponse(Convert.ToInt32(dataTable.Rows[i]["CMID"].ToString()), Convert.ToInt32(dataTable.Rows[i]["QuestionID"].ToString()), dataTable.Rows[i]["QuestionResponse"].ToString());
                            responseListNotAssigned.Add(questionResponse);
                        }
                    }

                    Session.Add("responseListNotAssigned", responseListNotAssigned.ToString());

                    objCommandDashboard.CommandType = CommandType.StoredProcedure;
                    objCommandDashboard.CommandText = "GetCMsByUserByStatus";
                    objCommandDashboard.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                    objCommandDashboard.Parameters.AddWithValue("@CMStatus", "not assigned");

                    dashboardData = objDB.GetDataSetUsingCmdObj(objCommandDashboard);
                    rptNotAssigned.DataSource = dashboardData;
                    rptNotAssigned.DataBind();

                    // Assigned CMs

                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@CMStatus", "assigned");
                    objCommand.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());

                    cmRequestData = objDB.GetDataSetUsingCmdObj(objCommand);
                    dataTable = cmRequestData.Tables[0];


                    List<QuestionResponse> responseListAssigned = new List<QuestionResponse>();

                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            QuestionResponse questionResponse = new QuestionResponse(int.Parse(dataTable.Rows[i]["CMID"].ToString()), int.Parse(dataTable.Rows[i]["QuestionID"].ToString()), dataTable.Rows[i]["QuestionResponse"].ToString());
                            responseListAssigned.Add(questionResponse);
                        }
                    }

                    Session.Add("responseListAssigned", responseListAssigned.ToString());

                    objCommandDashboard.Parameters.Clear();
                    objCommandDashboard.Parameters.AddWithValue("@CMStatus", "assigned");
                    objCommandDashboard.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                    dashboardData = objDB.GetDataSetUsingCmdObj(objCommandDashboard);
                    rptAssigned.DataSource = dashboardData;
                    rptAssigned.DataBind();

                    // Pre-Production CMs

                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@CMStatus", "pre-production");
                    objCommand.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());

                    cmRequestData = objDB.GetDataSetUsingCmdObj(objCommand);
                    dataTable = cmRequestData.Tables[0];


                    List<QuestionResponse> responseListPreProduction = new List<QuestionResponse>();

                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            QuestionResponse questionResponse = new QuestionResponse(int.Parse(dataTable.Rows[i]["CMID"].ToString()), int.Parse(dataTable.Rows[i]["QuestionID"].ToString()), dataTable.Rows[i]["QuestionResponse"].ToString());
                            responseListPreProduction.Add(questionResponse);
                        }
                    }

                    Session.Add("responseListPreProduction", responseListPreProduction.ToString());

                    objCommandDashboard.CommandText = "GetPreProdCMsByUser";
                    objCommandDashboard.Parameters.Clear();
                    objCommandDashboard.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());

                    dashboardData = objDB.GetDataSetUsingCmdObj(objCommandDashboard);
                    rptPreProduction.DataSource = dashboardData;
                    rptPreProduction.DataBind();

                    // Completed CMs

                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@CMStatus", "completed");
                    objCommand.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());

                    cmRequestData = objDB.GetDataSetUsingCmdObj(objCommand);
                    dataTable = cmRequestData.Tables[0];


                    List<QuestionResponse> responseListCompleted = new List<QuestionResponse>();

                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            QuestionResponse questionResponse = new QuestionResponse(int.Parse(dataTable.Rows[i]["CMID"].ToString()), int.Parse(dataTable.Rows[i]["QuestionID"].ToString()), dataTable.Rows[i]["QuestionResponse"].ToString());
                            responseListNotAssigned.Add(questionResponse);
                        }
                    }

                    Session.Add("responseListCompleted", responseListCompleted.ToString());

                    objCommandDashboard.CommandText = "GetCompletedCMsByUser";
                    objCommandDashboard.Parameters.Clear();
                    objCommandDashboard.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());

                    dashboardData = objDB.GetDataSetUsingCmdObj(objCommandDashboard);
                    rptCompleted.DataSource = dashboardData;
                    rptCompleted.DataBind();

                }
                else
                {
                    Session["hiddenCMClickedS"] = hiddenCMClicked.Value; //stores CMID for cm to pdf page

                    if (ViewState["ViewStateId"].ToString() != Session["SessionId"].ToString())
                    {
                        IsPageRefresh = true;
                    }

                    Session["SessionId"] = System.Guid.NewGuid().ToString();
                    ViewState["ViewStateId"] = Session["SessionId"].ToString();
                    if (hiddenCMClicked.Value != null && IsPageRefresh == false)
                    {
                        Page.MaintainScrollPositionOnPostBack = true;

                        objDB = new DBConnect();
                        objCommand = new SqlCommand();
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.Clear();

                        int CMID = Convert.ToInt32(hiddenCMClicked.Value);

                        objCommand.CommandText = "GetCMByID";
                        objCommand.Parameters.AddWithValue("@CMID", CMID);
                        DataSet dataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                        rptCMStatus.DataSource = dataSet;
                        rptCMStatus.DataBind();

                        // only assign false if attachment link was clicked
                        if (downloadFile.Value == "true")
                        {
                            isModalOpen.Value = "false";
                        }

                        if (isModalOpen.Value == "true")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#exampleModalLong').modal('show');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "HidePop", "$('#exampleModalLong').modal('hide');", true);
                        }

                        rptModalHeader.DataSource = dataSet;
                        rptModalHeader.DataBind();

                        rptScreenshots.DataSource = dataSet;
                        rptScreenshots.DataBind();

                        objCommand.CommandText = "GetCMAndUserAndTypeByID";
                        dataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                        rptRequestInfo.DataSource = dataSet;
                        rptRequestInfo.DataBind();

                        objCommand.CommandText = "GetCMAndAdminAndTypeByID";
                        dataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                        rptAdminName.DataSource = dataSet;
                        rptAdminName.DataBind();

                        objCommand.CommandText = "GetResponsesByCMID";
                        dataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                        rptResponse.DataSource = dataSet;
                        rptResponse.DataBind();


                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "GetComments";
                        objCommand.Parameters.Clear();
                        objCommand.Parameters.AddWithValue("@CMID", CMID);


                        DataSet cmRequestData = objDB.GetDataSetUsingCmdObj(objCommand);
                        DataTable dataTable = cmRequestData.Tables[0];

                        if (dataTable.Rows.Count > 0)
                        {
                            pnlNoComments.Visible = false;
                            pnlComments.Visible = true;
                            rptComments.DataSource = dataTable;
                            rptComments.DataBind();
                        }
                        else
                        {
                            pnlComments.Visible = false;
                            pnlNoComments.Visible = true;
                        }

                        // multitxt.Text = "Line1" + Environment.NewLine + "Line2";

                    }
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

        protected void tmComments_Tick(object sender, EventArgs e)
        {
            //SqlCommand objCommand = new SqlCommand();
            //objCommand.CommandType = CommandType.StoredProcedure;
            //objCommand.CommandText = "TP_GetCurrentOrder";
            //objCommand.Parameters.Clear();
            //objCommand.Parameters.AddWithValue("@OrderID", OrderID);
            //DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            //if (ds != null)
            //{

            //}
        }


        protected void btnNewRequest_Click(object sender, EventArgs e)
        {
            hiddenCMClicked.Value = null;
            Response.Redirect("SelectRequestType.aspx");
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            hiddenCMClicked.Value = null;
            Response.Redirect("ViewAllRequests.aspx");
        }

        protected void rptAssigned_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (((HiddenField)e.Item.FindControl("hiddenAdminID")).Value == Session["UserID"].ToString())
            {
                ((HtmlControl)e.Item.FindControl("btnCM")).Attributes.Add("style", "box-shadow: 0 0 10px 2.5px #8C2132;");
            }
        }

        protected void rptNotAssigned_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (((HiddenField)e.Item.FindControl("hiddenAdminID")).Value == Session["UserID"].ToString())
            {
                ((HtmlControl)e.Item.FindControl("btnCM")).Attributes.Add("style", "box-shadow: 0 0 10px 2.5px #8C2132;");
            }
        }

        protected void rptPreProduction_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (((HiddenField)e.Item.FindControl("hiddenAdminID")).Value == Session["UserID"].ToString())
            {
                ((HtmlControl)e.Item.FindControl("btnCM")).Attributes.Add("style", "box-shadow: 0 0 10px 2.5px #8C2132;");
            }
        }

        protected void rptCompleted_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (((HiddenField)e.Item.FindControl("hiddenAdminID")).Value == Session["UserID"].ToString())
            {
                ((HtmlControl)e.Item.FindControl("btnCM")).Attributes.Add("style", "box-shadow: 0 0 10px 2.5px #8C2132;");
            }
        }

        protected void btnCMClicked_Click(object sender, EventArgs e)
        {

        }

        protected void rptCMStatus_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (((HiddenField)e.Item.FindControl("hiddenCMStatus")).Value == "Not Assigned")
            {
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("style", "width: 0%");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuenow", "0");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemin", "0");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemax", "100");

                status.Attributes.Add("class", "visibility-hidden");
                //lblPreProdTesting.Visible = false;
                //chkPreProd.Visible = false;
                //lblTestingConfirmed.Visible = false;
                //btnSubmitTesting.Visible = false;
                //lblAwaitingAdmin.Visible = false;
            }
            else if (((HiddenField)e.Item.FindControl("hiddenCMStatus")).Value == "Assigned")
            {
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("style", "width: 25%");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuenow", "25");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemin", "0");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemax", "100");

                status.Attributes.Add("class", "visibility-hidden");
            }

            else if (((HiddenField)e.Item.FindControl("hiddenCMStatus")).Value == "Pre-Production Needs Testing")
            {
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("style", "width: 75%");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuenow", "75");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemin", "0");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemax", "100");

                status.Attributes.Clear();
                preprod.Attributes.Clear();
                preprodTested.Attributes.Add("class", "visibility-hidden");


            }
            else if (((HiddenField)e.Item.FindControl("hiddenCMStatus")).Value == "Pre-Production")
            {
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("style", "width: 75%");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuenow", "75");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemin", "0");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemax", "100");

                status.Attributes.Clear();
                preprodTested.Attributes.Clear();
                preprod.Attributes.Add("class", "visibility-hidden");
            }
            else if (((HiddenField)e.Item.FindControl("hiddenCMStatus")).Value == "Completed")
            {
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("style", "width: 100%");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuenow", "100");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemin", "0");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemax", "100");

                status.Attributes.Add("class", "visibility-hidden");

            }

        }

        protected void btnNewComment_Click(object sender, EventArgs e)
        {
            //validate comment text
            if (Validation.ValidateForm(txtNewComment.Text) && IsPageRefresh == false)
            {
                DateTime dt = DateTime.Now;
                string CMID = hiddenCMClicked.Value;

                //insert new comment into cm
                DBConnect ObjDb = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "InsertComment";
                objCommand.Parameters.AddWithValue("@CommentText", txtNewComment.Text);
                objCommand.Parameters.AddWithValue("@LastUpdateDate", dt.ToString());
                objCommand.Parameters.AddWithValue("@CommenterID", Session["UserID"].ToString());
                objCommand.Parameters.AddWithValue("@CMID", CMID);

                int response = objDB.DoUpdateUsingCmdObj(objCommand);
                if (response > 0)
                {
                    //Response.Write("<script>alert('Comment entered!');</script>");
                    txtNewComment.Text = "";
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "GetComments";
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@CMID", CMID);


                    DataSet cmRequestData = objDB.GetDataSetUsingCmdObj(objCommand);
                    DataTable dataTable = cmRequestData.Tables[0];

                    if (dataTable.Rows.Count > 0)
                    {
                        pnlNoComments.Visible = false;
                        pnlComments.Visible = true;
                        rptComments.DataSource = dataTable;
                        rptComments.DataBind();
                    }
                    else
                    {
                        pnlComments.Visible = false;
                        pnlNoComments.Visible = true;
                    }

                }
                else
                {
                    Response.Write("<script>alert('Comment not entered');</script>");
                }
            }

        }


        protected void btnSubmitTesting_Click(object sender, EventArgs e)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;

            if (chkPreProd.Checked == true)
            {
                objCommand.CommandText = "UpdateCMStatus";

                objCommand.Parameters.Clear();
                objCommand.Parameters.AddWithValue("@CMID", hiddenCMClicked.Value);
                objCommand.Parameters.AddWithValue("@CMStatus", "Pre-Production");

                objDB.DoUpdateUsingCmdObj(objCommand);

                objCommand.Parameters.Clear();
                objCommand.CommandText = "GetCMAndAdminAndTypeByID";
                objCommand.Parameters.AddWithValue("@CMID", hiddenCMClicked.Value);
                DataSet cmData = objDB.GetDataSetUsingCmdObj(objCommand);
                DataTable cmTable = cmData.Tables[0];

                SqlCommand objCommandEmail = new SqlCommand();
                objCommandEmail.CommandType = CommandType.StoredProcedure;
                objCommandEmail.CommandText = "GetEmailByType";
                objCommandEmail.Parameters.AddWithValue("@Type", "Confirmed Testing");
                DataSet emailData = objDB.GetDataSetUsingCmdObj(objCommandEmail);
                DataTable emailTable = emailData.Tables[0];

                Email objEmail = new Email();
                String strTO = "tug52322@temple.edu"; // cmTable.Rows[0]["Email"].ToString(); 
                String strFROM = "noreply@temple.edu";
                String strSubject = "CM #{" + hiddenCMClicked.Value + "}: " + emailTable.Rows[0]["Subject"].ToString();
                String strMessage = emailTable.Rows[0]["Body"].ToString();

                try
                {
                    objEmail.SendMail(strTO, strFROM, strSubject, strMessage);
                }
                catch (Exception ex)
                {

                }

                Server.Transfer("UserDashboard.aspx");
            }
        }

        protected void btnDownloadAsPDF_Click(object sender, EventArgs e)
        {
            Response.Redirect("DownloadAsPDFPage.aspx");
        }

        protected void RefreshTimer_Tick(object sender, EventArgs e)
        {
            objDB = new DBConnect();
            objCommandDashboard = new SqlCommand();

            objCommandDashboard.CommandType = CommandType.StoredProcedure;
            objCommandDashboard.CommandText = "GetCMsByUserByStatus";
            objCommandDashboard.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            objCommandDashboard.Parameters.AddWithValue("@CMStatus", "not assigned");

            dashboardData = objDB.GetDataSetUsingCmdObj(objCommandDashboard);
            rptNotAssigned.DataSource = dashboardData;
            rptNotAssigned.DataBind();

            objCommandDashboard.Parameters.Clear();
            objCommandDashboard.Parameters.AddWithValue("@CMStatus", "assigned");
            objCommandDashboard.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            dashboardData = objDB.GetDataSetUsingCmdObj(objCommandDashboard);
            rptAssigned.DataSource = dashboardData;
            rptAssigned.DataBind();

            objCommandDashboard.CommandText = "GetPreProdCMsByUser";
            objCommandDashboard.Parameters.Clear();
            objCommandDashboard.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());

            dashboardData = objDB.GetDataSetUsingCmdObj(objCommandDashboard);
            rptPreProduction.DataSource = dashboardData;
            rptPreProduction.DataBind();

            objCommandDashboard.CommandText = "GetCompletedCMsByUser";
            objCommandDashboard.Parameters.Clear();
            objCommandDashboard.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());

            dashboardData = objDB.GetDataSetUsingCmdObj(objCommandDashboard);
            rptCompleted.DataSource = dashboardData;
            rptCompleted.DataBind();
        }

        protected void btnLink1_Click(object sender, EventArgs e)
        {
            DownloadAttachment(3, 16);
            isModalOpen.Value = "false";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "HidePop", "$('#exampleModalLong').modal('hide');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#mdlCMAttachment').modal('show');", true);
        }

        protected void btnLink2_Click(object sender, EventArgs e)
        {
            DownloadAttachment(4, 17);
            isModalOpen.Value = "false";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "HidePop", "$('#exampleModalLong').modal('hide');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#mdlCMAttachment').modal('show');", true);
        }

        protected void btnLink3_Click(object sender, EventArgs e)
        {
            DownloadAttachment(5, 18);
            isModalOpen.Value = "false";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "HidePop", "$('#exampleModalLong').modal('hide');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#mdlCMAttachment').modal('show');", true);
        }

        protected void btnLink4_Click(object sender, EventArgs e)
        {
            DownloadAttachment(6, 19);
            isModalOpen.Value = "false";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "HidePop", "$('#exampleModalLong').modal('hide');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#mdlCMAttachment').modal('show');", true);
        }

        protected void btnLink5_Click(object sender, EventArgs e)
        {
            DownloadAttachment(7, 20);
            isModalOpen.Value = "false";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "HidePop", "$('#exampleModalLong').modal('hide');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#mdlCMAttachment').modal('show');", true);
        }

        protected void DownloadAttachment(int imgCol, int nameCol)
        {
            objDB = new DBConnect();
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;

            int CMID = Convert.ToInt32(Session["hiddenCMClickedS"]);
            objCommand.CommandText = "GetCMByID";
            objCommand.Parameters.AddWithValue("@CMID", CMID);
            DataSet dataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            //get data
            DataTable dt = dataSet.Tables[0];
            byte[] imgByte = (byte[])dt.Rows[0][imgCol];
            string imgName = (string)dt.Rows[0][nameCol];

            if ((imgByte != null) && (imgName != null))
            {
                // turn byte into downloaded file
                System.IO.File.WriteAllBytes(@"W:\CIS4396-S08\tug94028\" + imgName, imgByte);

                attachmentModal(imgName);
            }
            else
            {
                string name = "noname";
                attachmentModal(name);
            }
        }

        protected void rptScreenshots_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            objDB = new DBConnect();
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;

            int CMID = Convert.ToInt32(Session["hiddenCMClickedS"]);
            objCommand.CommandText = "GetCMByID";
            objCommand.Parameters.AddWithValue("@CMID", CMID);
            DataSet dataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            //get data
            DataTable dt = dataSet.Tables[0];

            LinkButton l2 = (LinkButton)e.Item.FindControl("btnLink2");
            LinkButton l3 = (LinkButton)e.Item.FindControl("btnLink3");
            LinkButton l4 = (LinkButton)e.Item.FindControl("btnLink4");
            LinkButton l5 = (LinkButton)e.Item.FindControl("btnLink5");

            if (dt.Rows[0][7] != DBNull.Value)
            {
                l5.Visible = true;
                l4.Visible = true;
                l3.Visible = true;
                l2.Visible = true;
            }
            else if (dt.Rows[0][6] != DBNull.Value)
            {
                l4.Visible = true;
                l3.Visible = true;
                l2.Visible = true;
            }
            else if (dt.Rows[0][5] != DBNull.Value)
            {
                l3.Visible = true;
                l2.Visible = true;
            }
            else if (dt.Rows[0][4] != DBNull.Value)
            {
                l2.Visible = true;
            }
        }

        protected void btnAttachment_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserDashboard.aspx");
        }

        protected void attachmentModal(string name)
        {
            if (name != "noname")
            {
                Label1.InnerText = name + " has successfully downloaded!";    
            }
            else
            {
                Label1.InnerText = "The attachment has failed to download. Please try again.";
            }
        }
    }
}
