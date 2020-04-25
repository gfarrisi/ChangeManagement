using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChangeManagementSystem.Utilities;
using System.Data.SqlClient;
using System.Configuration;
using ChangeManagementSystem.RequestLibrary;
using System.Web.UI.HtmlControls;
using System.Net;
using System.IO;

namespace ChangeManagementSystem
{
    public partial class ViewAllRequests : System.Web.UI.Page
    {
        DBConnect objDB;
        SqlCommand objCommand = new SqlCommand();
        DBConnect db = new DBConnect();
        DataSet ds = new DataSet();
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
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "GetUserByID";
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());

                    DataSet userData = db.GetDataSetUsingCmdObj(objCommand);
                    DataTable dt = userData.Tables[0];
                    string userName = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                    
                    lblUserName.Text = userName;

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "GetAllCMsAdminView";
                    objCommand.Parameters.Clear();
                    this.BindGrid();
                }
                else
                {
                    ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                    Session["SessionId"] = ViewState["ViewStateId"].ToString();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "GetUserByID";
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());

                    DataSet userData = db.GetDataSetUsingCmdObj(objCommand);
                    DataTable dt = userData.Tables[0];
                    string userName = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                    lblUserName.Text = userName;

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "GetAllCMsAdminView";
                    objCommand.Parameters.Clear();
                    this.BindGrid();
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

        private void BindGrid(string sortExpression = null)
        {
            DBConnect db = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllCMsAdminView";
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = db.GetConnection();
                    using (DataTable dt = new DataTable())
                    {
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
 
                        gvAllRequests.DataSource = dt;

                        gvAllRequests.DataBind();
                    }
                }
            }
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
                  btnSave.Visible = true;

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
                  btnSave.Visible = true;

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
                  btnSave.Visible = false;

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
                  btnSave.Visible = true;

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
                  btnSave.Visible = false;
              }
              else if (((HiddenField)e.Item.FindControl("hiddenCMStatus")).Value == "Failed")
              {
                  ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("style", "width: 0%");
                  ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuenow", "0");
                  ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemin", "0");
                  ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemax", "100");
                    
                  statusChangeControls.Attributes.Add("class", "visibility-hidden");
                  status.Attributes.Add("class", "visibility-hidden");
                  btnSave.Visible = false;
              }

            }
            else 
            {
                hiddenCMSaving.Value = "false";
            }
        
        }

        protected void btnNewComment_Click(object sender, EventArgs e)
        {
            //validate comment text
            if (Validation.ValidateForm(txtNewComment.Text) && IsPageRefresh == false)
            {
                DateTime dt = DateTime.Now;
                string CMID = Session["hiddenCM"].ToString();
                Session.Add("UserID", Session["UserID"].ToString());
                //insert new comment into cm
                DBConnect ObjDb = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "InsertComment";
                objCommand.Parameters.AddWithValue("@CommentText", txtNewComment.Text);
                objCommand.Parameters.AddWithValue("@LastUpdateDate", dt.ToString());
                objCommand.Parameters.AddWithValue("@CommenterID", Session["UserID"].ToString());
                objCommand.Parameters.AddWithValue("@CMID", CMID);

                int response = db.DoUpdateUsingCmdObj(objCommand);
                if (response > 0)
                {
                    //Response.Write("<script>alert('Comment entered!');</script>");
                    txtNewComment.Text = "";
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "GetComments";
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@CMID", CMID);


                    DataSet cmRequestData = db.GetDataSetUsingCmdObj(objCommand);
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

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#exampleModalLong').modal('show');", true);
        }

        protected void btnDownloadAsPDF_Click(object sender, EventArgs e)
        {
            Session["pdfCM"] = Session["hiddenCM"].ToString();

            Response.Redirect("DownloadAsPDFPage.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            objDB = new DBConnect();

            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateCMStatus";
            objCommand.Parameters.Clear();
            objCommand.Parameters.AddWithValue("@CMID", Session["hiddenCM"].ToString());

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
                objCommand.Parameters.AddWithValue("@CMID", Session["hiddenCM"].ToString());
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
                Server.Transfer("ViewAllRequests.aspx");
            }

            objDB.DoUpdateUsingCmdObj(objCommand); // Updating CM Status

            objCommand.Parameters.Clear();
            objCommand.CommandText = "GetCMAndUserAndTypeByID";
            objCommand.Parameters.AddWithValue("@CMID", Session["hiddenCM"].ToString());
            DataSet cmData = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable cmTable = cmData.Tables[0];

            DataSet emailData = objDB.GetDataSetUsingCmdObj(objCommandEmail);
            DataTable emailTable = emailData.Tables[0];

            Email objEmail = new Email();
            String strTO = cmTable.Rows[0]["Email"].ToString();
            String strFROM = "noreply@temple.edu";
            String strSubject = "CM #" + Session["hiddenCM"].ToString() + ": " + emailTable.Rows[0]["Subject"].ToString();
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

            Server.Transfer("ViewAllRequests.aspx");
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lb.NamingContainer;
            int index = 0;
            string name = "";
            if (row != null)
            {
                index = row.RowIndex; //gets the row index selected
                name = gvAllRequests.Rows[index].Cells[0].Text;
            }
            if (ViewState["ViewStateId"].ToString() != Session["SessionId"].ToString())
            {
                IsPageRefresh = true;
            }
            Session["SessionId"] = System.Guid.NewGuid().ToString();
            ViewState["ViewStateId"] = Session["SessionId"].ToString();
            if (name != null && IsPageRefresh == false)
            {
                Page.MaintainScrollPositionOnPostBack = true;
                int CMID = Int32.Parse(name);
                Session["hiddenCM"] = CMID;
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetCMByID";
                objCommand.Parameters.Clear();
                objCommand.Parameters.AddWithValue("@CMID", CMID);
                DataSet dataSet = db.GetDataSetUsingCmdObj(objCommand);
                rptCMStatus.DataSource = dataSet;
                rptCMStatus.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#exampleModalLong').modal('show');", true);

                rptModalHeader.DataSource = dataSet;
                rptModalHeader.DataBind();

                rptScreenshots.DataSource = dataSet;
                rptScreenshots.DataBind();

                objCommand.CommandText = "GetCMAndUserAndTypeByID";
                dataSet = db.GetDataSetUsingCmdObj(objCommand);
                rptRequestInfo.DataSource = dataSet;
                rptRequestInfo.DataBind();

                objCommand.CommandText = "GetCMAndAdminAndTypeByID";
                dataSet = db.GetDataSetUsingCmdObj(objCommand);
                rptAdminName.DataSource = dataSet;
                rptAdminName.DataBind();

                objCommand.CommandText = "GetResponsesByCMID";
                dataSet = db.GetDataSetUsingCmdObj(objCommand);
                rptResponse.DataSource = dataSet;
                rptResponse.DataBind();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetComments";
                objCommand.Parameters.Clear();
                objCommand.Parameters.AddWithValue("@CMID", CMID);


                DataSet cmRequestData = db.GetDataSetUsingCmdObj(objCommand);
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
                int CMID = Int32.Parse(name);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetComments";
                objCommand.Parameters.Clear();              
                objCommand.Parameters.AddWithValue("@CMID", CMID);
            }
        }

        protected void btnLink1_Click(object sender, EventArgs e)
        {
            DownloadAttachment(3, 16);
        }

        protected void btnLink2_Click(object sender, EventArgs e)
        {
            DownloadAttachment(4, 17);
        }

        protected void btnLink3_Click(object sender, EventArgs e)
        {
            DownloadAttachment(5, 18);
        }

        protected void btnLink4_Click(object sender, EventArgs e)
        {
            DownloadAttachment(6, 19);
        }

        protected void btnLink5_Click(object sender, EventArgs e)
        {
            DownloadAttachment(7, 20);
        }

        protected void DownloadAttachment(int imgCol, int nameCol)
        {
            objDB = new DBConnect();
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;

            int CMID = Convert.ToInt32(Session["hiddenCM"]);
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
                // System.IO.File.WriteAllBytes(Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\") + imgName, imgByte);
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

            int CMID = Convert.ToInt32(Session["hiddenCM"]);
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
            Response.Redirect("ViewAllRequests.aspx");
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

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#mdlCMAttachment').modal('show');", true);
        }

        protected void gvAllRequests_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
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
                objCommand.Parameters.AddWithValue("@CMID", Session["hiddenCM"].ToString());
                objCommand.Parameters.AddWithValue("@CMStatus", "Pre-Production");

                objDB.DoUpdateUsingCmdObj(objCommand);

                objCommand.Parameters.Clear();
                objCommand.CommandText = "GetCMAndAdminAndTypeByID";
                objCommand.Parameters.AddWithValue("@CMID", Session["hiddenCM"].ToString());
                DataSet cmData = objDB.GetDataSetUsingCmdObj(objCommand);
                DataTable cmTable = cmData.Tables[0];

                SqlCommand objCommandEmail = new SqlCommand();
                objCommandEmail.CommandType = CommandType.StoredProcedure;
                objCommandEmail.CommandText = "GetEmailByType";
                objCommandEmail.Parameters.AddWithValue("@Type", "Confirmed Testing");
                DataSet emailData = objDB.GetDataSetUsingCmdObj(objCommandEmail);
                DataTable emailTable = emailData.Tables[0];

                Email objEmail = new Email();
                String strTO = cmTable.Rows[0]["Email"].ToString(); 
                String strFROM = "noreply@temple.edu";
                String strSubject = "CM #" + Session["hiddenCM"].ToString() + ": " + emailTable.Rows[0]["Subject"].ToString();
                String strMessage = emailTable.Rows[0]["Body"].ToString();

                try
                {
                    objEmail.SendMail(strTO, strFROM, strSubject, strMessage);
                }
                catch (Exception ex)
                {

                }

                Server.Transfer("ViewAllRequests.aspx");
            }
        }
    }
}
