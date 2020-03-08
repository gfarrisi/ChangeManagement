using System;
using System.Collections.Generic;
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

namespace ChangeManagementSystem
{
    public partial class DownloadAsPDFPage : System.Web.UI.Page
    {
        DBConnect objDB;
        SqlCommand objCommand;
        DataSet dashboardData;
        SqlCommand objCommandDashboard;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Session["hiddenCMClickedS"].ToString() != null)
                {

                    objDB = new DBConnect();
                    objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;

                    int CMID = Convert.ToInt32(Session["hiddenCMClickedS"]);
                    objCommand.CommandText = "GetCMByID";
                    objCommand.Parameters.AddWithValue("@CMID", CMID);
                    DataSet dataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                    rptCMStatus.DataSource = dataSet;
                    rptCMStatus.DataBind();


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
            else
            {

                objDB = new DBConnect();
                objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;

                int CMID = Convert.ToInt32(Session["hiddenCMClickedS"]);
                objCommand.CommandText = "GetCMByID";
                objCommand.Parameters.AddWithValue("@CMID", CMID);
                DataSet dataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                rptCMStatus.DataSource = dataSet;
                rptCMStatus.DataBind();


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
    }
}