using IronPdf;
using ChangeManagementSystem.Utilities;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChangeManagementSystem;
using ChangeManagementSystem.RequestLibrary;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Net;
using System.IO;

namespace ChangeManagementSystem
{
    public partial class AdminDashboard : System.Web.UI.Page
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

                    Session.Add("UserID", Session["TU_ID"].ToString());

                    objDB = new DBConnect();
                    objCommand = new SqlCommand();
                    objCommandDashboard = new SqlCommand();


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
                    objCommand.CommandText = "GetCMResponsesByStatus";
                    objCommand.Parameters.Clear();
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
                    objCommandDashboard.CommandText = "GetCMsByStatus";

                    objCommandDashboard.Parameters.AddWithValue("@CMStatus", "not assigned");
                    dashboardData = objDB.GetDataSetUsingCmdObj(objCommandDashboard);
                    rptNotAssigned.DataSource = dashboardData;
                    rptNotAssigned.DataBind();

                    // Assigned CMs

                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@CMStatus", "assigned");

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
                    dashboardData = objDB.GetDataSetUsingCmdObj(objCommandDashboard);
                    rptAssigned.DataSource = dashboardData;
                    rptAssigned.DataBind();

                    // Pre-Production CMs

                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@CMStatus", "pre-production");

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

                    objCommandDashboard.CommandText = "GetPreProdCMs";
                    objCommandDashboard.Parameters.Clear();
                    dashboardData = objDB.GetDataSetUsingCmdObj(objCommandDashboard);
                    rptPreProduction.DataSource = dashboardData;
                    rptPreProduction.DataBind();

                    // Completed CMs

                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@CMStatus", "completed");

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

                    objCommandDashboard.CommandText = "GetCompletedCMs";
                    objCommandDashboard.Parameters.Clear();
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

                        int CMID = Convert.ToInt32(hiddenCMClicked.Value);
                        objCommand.CommandText = "GetCMByID";
                        objCommand.Parameters.AddWithValue("@CMID", CMID);
                        DataSet dataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                        rptCMStatus.DataSource = dataSet;
                        rptCMStatus.DataBind();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#exampleModalLong').modal('show');", true);

                        rptModalHeader.DataSource = dataSet;
                        rptModalHeader.DataBind();

                        rptScreenshots.DataSource = dataSet;
                        rptScreenshots.DataBind();

                        objCommand.CommandText = "GetCMAndUserByID";
                        dataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                        rptRequestInfo.DataSource = dataSet;
                        rptRequestInfo.DataBind();

                        objCommand.CommandText = "GetCMAndAdminByID";
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
        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAllRequests.aspx");
        }
        protected void btnNewRequest_Click(object sender, EventArgs e)
        {
            Response.Redirect("SelectRequestType.aspx");
        }

        protected void rptAssigned_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (((HiddenField)e.Item.FindControl("hiddenAdminID")).Value == Session["UserID"].ToString())
            {
                ((HtmlControl)e.Item.FindControl("btnCM")).Attributes.Add("style", "box-shadow: 0 0 10px .5px #8C2132;");
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

                lblCMStatus.Visible = false;
                ddlCMStatus.Visible = true;

                List<string> statusList = new List<string>();
                statusList.Add("Assign to Me");
                statusList.Add("CM Failed");
                ddlCMStatus.DataSource = statusList;
                ddlCMStatus.DataBind();


            }
            else if (((HiddenField)e.Item.FindControl("hiddenCMStatus")).Value == "Assigned")
            {
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("style", "width: 25%");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuenow", "25");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemin", "0");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemax", "100");

                lblCMStatus.Visible = false;
                ddlCMStatus.Visible = true;

                List<string> statusList = new List<string>();
                statusList.Add("Change Implemented in Pre-Production");
                statusList.Add("CM Failed");
                ddlCMStatus.DataSource = statusList;
                ddlCMStatus.DataBind();

            }
            else if (((HiddenField)e.Item.FindControl("hiddenCMStatus")).Value == "Pre-Production Needs Testing")
            {
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("style", "width: 75%");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuenow", "75");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemin", "0");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemax", "100");

                ddlCMStatus.Visible = false;
                lblCMStatus.Text = "Pending User Testing of Changes";
                lblCMStatus.Visible = true;
            }
            else if (((HiddenField)e.Item.FindControl("hiddenCMStatus")).Value == "Pre-Production")
            {
                ddlCMStatus.Visible = true;
                lblCMStatus.Text = "Update Status";
                lblCMStatus.Visible = true;

                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("style", "width: 75%");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuenow", "75");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemin", "0");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemax", "100");

                List<string> statusList = new List<string>();
                statusList.Add("Change Implemented in Production");
                statusList.Add("CM Failed");
                ddlCMStatus.DataSource = statusList;
                ddlCMStatus.DataBind();

            }
            else if (((HiddenField)e.Item.FindControl("hiddenCMStatus")).Value == "Completed")
            {
                ddlCMStatus.Visible = false;
                lblCMStatus.Visible = false;

                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("style", "width: 100%");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuenow", "100");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemin", "0");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemax", "100");

            }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            objDB = new DBConnect();

            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateCMStatus";
            objCommand.Parameters.Clear();
            objCommand.Parameters.AddWithValue("@CMID", hiddenCMClicked.Value);

            SqlCommand objCommandEmail = new SqlCommand();
            objCommandEmail.CommandType = CommandType.StoredProcedure;
            objCommandEmail.CommandText = "GetEmailByType";

            if (ddlCMStatus.SelectedValue == "CM Failed")
            {
                objCommand.Parameters.AddWithValue("@CMStatus", "Failed");

                objCommandEmail.Parameters.AddWithValue("@Type", "CM has failed");
            }
            else if (ddlCMStatus.SelectedValue == "Assign to Me")
            {
                objCommand.CommandText = "UpdateCMStatusAndAdmin";
                objCommand.Parameters.Clear();
                objCommand.Parameters.AddWithValue("@CMID", hiddenCMClicked.Value);
                objCommand.Parameters.AddWithValue("@CMStatus", "Assigned");
                objCommand.Parameters.AddWithValue("@AdminID", Session["UserID"].ToString());

                objCommandEmail.Parameters.AddWithValue("@Type", "Moved to Assigned");
            }
            else if (ddlCMStatus.SelectedValue == "Change Implemented in Pre-Production")
            {
                objCommand.Parameters.AddWithValue("@CMStatus", "Pre-Production Needs Testing");

                objCommandEmail.Parameters.AddWithValue("@Type", "Implemented in Pre-Prod");
            }
            else if (ddlCMStatus.SelectedValue == "Change Implemented in Production")
            {
                objCommand.Parameters.AddWithValue("@CMStatus", "Production");

                objCommandEmail.Parameters.AddWithValue("@Type", "Implemented in Prod");
            }

            objDB.DoUpdateUsingCmdObj(objCommand); // Updating CM Status

            objCommand.Parameters.Clear();
            objCommand.CommandText = "GetCMAndUserByID";
            objCommand.Parameters.AddWithValue("@CMID", hiddenCMClicked.Value);
            DataSet cmData = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable cmTable = cmData.Tables[0];

            DataSet emailData = objDB.GetDataSetUsingCmdObj(objCommandEmail);
            DataTable emailTable = emailData.Tables[0];

            Email objEmail = new Email();
            String strTO = "tug52322@temple.edu"; //cmTable.Columns["Email"].ToString();
            String strFROM = "noreply@temple.edu";
            String strSubject = emailTable.Columns["Subject"].ToString();
            String strMessage = "CM #{" + hiddenCMClicked.Value + "}: " + emailTable.Columns["Body"].ToString();

            try
            {
                objEmail.SendMail(strTO, strFROM, strSubject, strMessage);
                //  lblDisplay.Text = "The email was sent.";
            }
            catch (Exception ex)
            {
                //lblDisplay.Text = "The email wasn't sent because one of the required fields was missing.";
            }

            Server.Transfer("AdminDashboard.aspx");
        }
        protected void btnNewComment_Click(object sender, EventArgs e)
        {
            //validate comment text
            if (Validation.ValidateForm(txtNewComment.Text) && IsPageRefresh == false)
            {
                DateTime dt = DateTime.Now;
                string CMID = hiddenCMClicked.Value;
                Session.Add("UserID", 915351047);
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

        protected void btnDownloadAsPDF_Click(object sender, EventArgs e)
        {
            Response.Redirect("DownloadAsPDFPage.aspx");
        }

        protected void RefreshTimer_Tick(object sender, EventArgs e)
        {
            objDB = new DBConnect();
            objCommandDashboard = new SqlCommand();

            objCommandDashboard.CommandType = CommandType.StoredProcedure;
            objCommandDashboard.CommandText = "GetCMsByStatus";

            objCommandDashboard.Parameters.AddWithValue("@CMStatus", "not assigned");
            dashboardData = objDB.GetDataSetUsingCmdObj(objCommandDashboard);
            rptNotAssigned.DataSource = dashboardData;
            rptNotAssigned.DataBind();

            objCommandDashboard.Parameters.Clear();
            objCommandDashboard.Parameters.AddWithValue("@CMStatus", "assigned");
            dashboardData = objDB.GetDataSetUsingCmdObj(objCommandDashboard);
            rptAssigned.DataSource = dashboardData;
            rptAssigned.DataBind();

            objCommandDashboard.CommandText = "GetPreProdCMs";
            objCommandDashboard.Parameters.Clear();
            dashboardData = objDB.GetDataSetUsingCmdObj(objCommandDashboard);
            rptPreProduction.DataSource = dashboardData;
            rptPreProduction.DataBind();

            objCommandDashboard.CommandText = "GetCompletedCMs";
            objCommandDashboard.Parameters.Clear();
            dashboardData = objDB.GetDataSetUsingCmdObj(objCommandDashboard);
            rptCompleted.DataSource = dashboardData;
            rptCompleted.DataBind();
        }
    }
}