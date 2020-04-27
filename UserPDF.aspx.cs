using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ChangeManagementSystem.Utilities;
using System.Web;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System;

namespace ChangeManagementSystem
{
    public partial class UserPDF : System.Web.UI.Page
    {
        DBConnect objDB;
        SqlCommand objCommand;
        DataSet dashboardData;
        SqlCommand objCommandDashboard;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Session["pdfCM"].ToString() != null)
                {

                    objDB = new DBConnect();
                    objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;

                    int CMID = Convert.ToInt32(Session["pdfCM"]);
                    objCommand.CommandText = "GetCMByID";
                    objCommand.Parameters.AddWithValue("@CMID", CMID);
                    DataSet dataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                    rptCMStatus.DataSource = dataSet;
                    rptCMStatus.DataBind();


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

                }
            }
            else
            {
                // set name on navbar
                objDB = new DBConnect();
                objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetUserByID";
                objCommand.Parameters.Clear();
                objCommand.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());

                DataSet userData = objDB.GetDataSetUsingCmdObj(objCommand);
                DataTable dt = userData.Tables[0];

                string userName = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                lblUserName.Text = userName;

                objDB = new DBConnect();
                objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;

                int CMID = Convert.ToInt32(Session["pdfCM"]);
                objCommand.CommandText = "GetCMByID";
                objCommand.Parameters.AddWithValue("@CMID", CMID);
                DataSet dataSet = objDB.GetDataSetUsingCmdObj(objCommand);

                rptCMStatus.DataSource = dataSet;
                rptCMStatus.DataBind();

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
            }
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
                ddlCMStatus.Visible = false;

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
                ddlCMStatus.Visible = false;

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
                ddlCMStatus.Visible = false;
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

        protected void rptScreenshots_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            objDB = new DBConnect();
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;

            int CMID = Convert.ToInt32(Session["pdfCM"]);
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

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserPDF.aspx");
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#mdlCMAttachment').modal('show');", true);
        }

        protected void DownloadAttachment(int imgCol, int nameCol)
        {
            objDB = new DBConnect();
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;

            int CMID = Convert.ToInt32(Session["pdfCM"]);
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
    }
}