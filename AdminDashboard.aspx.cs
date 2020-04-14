
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
using System.Windows;
using System.Net.Mail;
using System.Windows.Forms;

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
                    
                    objCommandDashboard.CommandType = CommandType.StoredProcedure;
                    objCommandDashboard.CommandText = "GetCMsByStatus";

                    objCommandDashboard.Parameters.AddWithValue("@CMStatus", "not assigned");
                    dashboardData = objDB.GetDataSetUsingCmdObj(objCommandDashboard);
                    rptNotAssigned.DataSource = dashboardData;
                    rptNotAssigned.DataBind();

                    // Assigned CMs
                    
                    objCommandDashboard.Parameters.Clear();
                    objCommandDashboard.Parameters.AddWithValue("@CMStatus", "assigned");
                    dashboardData = objDB.GetDataSetUsingCmdObj(objCommandDashboard);
                    rptAssigned.DataSource = dashboardData;
                    rptAssigned.DataBind();

                    // Pre-Production CMs
                    
                    objCommandDashboard.CommandText = "GetPreProdCMs";
                    objCommandDashboard.Parameters.Clear();
                    dashboardData = objDB.GetDataSetUsingCmdObj(objCommandDashboard);
                    rptPreProduction.DataSource = dashboardData;
                    rptPreProduction.DataBind();

                    // Completed CMs

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

                    if (hiddenCMClicked.Value != "" && IsPageRefresh == false)

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

                        Session["hiddenCMClickedS"] = hiddenCMClicked.Value; //stores CMID for cm to pdf page
                    }
                    else
                    {
                        Response.Redirect(Request.RawUrl);
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
                ((HtmlControl)e.Item.FindControl("btnCM")).Attributes.Add("style", "box-shadow: 0 0 10px 2.5px; color:white; background-color:#A41E35;");
            }
        }

        protected void rptNotAssigned_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
        }

        protected void rptPreProduction_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (((HiddenField)e.Item.FindControl("hiddenAdminID")).Value == Session["UserID"].ToString())
            {
                ((HtmlControl)e.Item.FindControl("btnCM")).Attributes.Add("style", "box-shadow: 0 0 10px 2.5px; color:white; background-color:#A41E35;");
            }
        }

        protected void rptCompleted_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (((HiddenField)e.Item.FindControl("hiddenAdminID")).Value == Session["UserID"].ToString())
            {
                ((HtmlControl)e.Item.FindControl("btnCM")).Attributes.Add("style", "box-shadow: 0 0 10px 2.5px; color:white; background-color:#A41E35;");
            }
        }

        protected void btnCMClicked_Click(object sender, EventArgs e)
        {

        }

        protected void rptCMStatus_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (hiddenCMSaving.Value != "true")
            {
                if (((HiddenField)e.Item.FindControl("hiddenCMStatus")).Value == "Not Assigned")
                {
                    ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("style", "width: 0%");
                    ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuenow", "0");
                    ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemin", "0");
                    ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemax", "100");

                    if (((HiddenField)e.Item.FindControl("selectedCMUserID")).Value == Session["UserID"].ToString())
                    {
                        status.Attributes.Add("class", "visibility-hidden");
                        statusChangeControls.Attributes.Add("class", "visibility-hidden");
                    }
                    else
                    {
                        status.Attributes.Add("class", "visibility-hidden");
                        statusChangeControls.Attributes.Clear();
                        ddlCMStatus.Visible = true;
                        lblCMStatus.Text = "Update Status";

                        List<string> statusList = new List<string>();
                        statusList.Add("--Select a Status--");
                        statusList.Add("Assign to Me");
                        statusList.Add("CM Failed");
                        ddlCMStatus.DataSource = statusList;
                        ddlCMStatus.DataBind();
                    }

                }
                else if (((HiddenField)e.Item.FindControl("hiddenCMStatus")).Value == "Assigned")
                {
                    ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("style", "width: 25%");
                    ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuenow", "25");
                    ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemin", "0");
                    ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemax", "100");

                    if (((HiddenField)e.Item.FindControl("selectedCMUserID")).Value == Session["UserID"].ToString())
                    {
                        status.Attributes.Add("class", "visibility-hidden");
                        statusChangeControls.Attributes.Add("class", "visibility-hidden");
                    }
                    else
                    {
                        status.Attributes.Add("class", "visibility-hidden");
                        statusChangeControls.Attributes.Clear();
                        ddlCMStatus.Visible = true;
                        lblCMStatus.Text = "Update Status";

                        List<string> statusList = new List<string>();
                        statusList.Add("--Select a Status--");
                        statusList.Add("Change Implemented in Pre-Production");
                        statusList.Add("CM Failed");
                        ddlCMStatus.DataSource = statusList;
                        ddlCMStatus.DataBind();
                    }

                }
                else if (((HiddenField)e.Item.FindControl("hiddenCMStatus")).Value == "Pre-Production Needs Testing")
                {
                    ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("style", "width: 75%");
                    ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuenow", "75");
                    ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemin", "0");
                    ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemax", "100");

                    if (((HiddenField)e.Item.FindControl("selectedCMUserID")).Value == Session["UserID"].ToString())
                    {
                        statusChangeControls.Attributes.Add("class", "visibility-hidden");

                        status.Attributes.Clear();
                        preprod.Attributes.Clear();
                        preprodTested.Attributes.Add("class", "visibility-hidden");
                    }
                    else
                    {
                        status.Attributes.Add("class", "visibility-hidden");
                        statusChangeControls.Attributes.Clear();
                        ddlCMStatus.Visible = false;
                        lblCMStatus.Text = "Pending User Testing of Changes";
                        lblCMStatus.Attributes.Clear();
                    }

                }
                else if (((HiddenField)e.Item.FindControl("hiddenCMStatus")).Value == "Pre-Production")
                {
                    ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("style", "width: 75%");
                    ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuenow", "75");
                    ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemin", "0");
                    ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemax", "100");

                    if (((HiddenField)e.Item.FindControl("selectedCMUserID")).Value == Session["UserID"].ToString())
                    {
                        statusChangeControls.Attributes.Add("class", "visibility-hidden");

                        status.Attributes.Clear();
                        preprodTested.Attributes.Clear();
                        preprod.Attributes.Add("class", "visibility-hidden");
                    }
                    else
                    {
                        status.Attributes.Add("class", "visibility-hidden");
                        statusChangeControls.Attributes.Clear();
                        ddlCMStatus.Visible = true;
                        lblCMStatus.Text = "Update Status";

                        List<string> statusList = new List<string>();
                        statusList.Add("--Select a Status--");
                        statusList.Add("Change Implemented in Production");
                        statusList.Add("CM Failed");
                        ddlCMStatus.DataSource = statusList;
                        ddlCMStatus.DataBind();
                    }

                }
                else if (((HiddenField)e.Item.FindControl("hiddenCMStatus")).Value == "Completed")
                {
                    ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("style", "width: 100%");
                    ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuenow", "100");
                    ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemin", "0");
                    ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemax", "100");

                    statusChangeControls.Attributes.Add("class", "visibility-hidden");
                    status.Attributes.Add("class", "visibility-hidden");

                }
            }
            else
            {
                hiddenCMSaving.Value = "false";
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

            int CMID = Convert.ToInt32(hiddenCMClicked.Value);
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
                
                // System.IO.File.WriteAllBytes(Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Downloads") + imgName, imgByte);
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", @"inline; filename=" + imgName);
                Response.BinaryWrite(imgByte);
                Response.Flush();
                Response.End();
                //attachmentModal(imgName);

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

            // get aspx control on page for the link
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
                String strTO = "tug52322@temple.edu"; //  cmTable.Rows[0]["Email"].ToString(); 
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

                Server.Transfer("AdminDashboard.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
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

            //isModalOpen.Value = "false";
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "HidePop", "$('#exampleModalLong').modal('hide');", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#mdlCMAttachment').modal('show');", true);

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
                objCommand.Parameters.AddWithValue("@CMStatus", "Completed");

                objCommandEmail.Parameters.AddWithValue("@Type", "Implemented in Prod");
            }
            else if (ddlCMStatus.SelectedValue == "--Select a Status--")
            {
                Server.Transfer("AdminDashboard.aspx");
            }

            objDB.DoUpdateUsingCmdObj(objCommand); // Updating CM Status

            objCommand.Parameters.Clear();
            objCommand.CommandText = "GetCMAndUserAndTypeByID";
            objCommand.Parameters.AddWithValue("@CMID", hiddenCMClicked.Value);
            DataSet cmData = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable cmTable = cmData.Tables[0];

            DataSet emailData = objDB.GetDataSetUsingCmdObj(objCommandEmail);
            DataTable emailTable = emailData.Tables[0];

            Email objEmail = new Email();
            String strTO = "tug52322@temple.edu"; //cmTable.Rows[0]["Email"].ToString();
            String strFROM = "noreply@temple.edu";
            String strSubject = "CM #{" + hiddenCMClicked.Value + "}: " + emailTable.Rows[0]["Subject"].ToString();
            String strMessage = emailTable.Rows[0]["Body"].ToString();

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
    }
        
}