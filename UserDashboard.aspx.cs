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

            if (!IsPostBack)
            {
                ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                Session["SessionId"] = ViewState["ViewStateId"].ToString();
                hiddenCMClicked.Value = null;

                Session.Add("UserID", 915368285); // Admin user in database; will be preserved from login in the future


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

                    string CMID = hiddenCMClicked.Value;

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

                   // multitxt.Text = "Line1" + Environment.NewLine + "Line2";

                }
            }

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


            }
            else if (((HiddenField)e.Item.FindControl("hiddenCMStatus")).Value == "Assigned")
            {
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("style", "width: 25%");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuenow", "25");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemin", "0");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemax", "100");

            }
            else if (((HiddenField)e.Item.FindControl("hiddenCMStatus")).Value == "Pre-Production")
            {
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("style", "width: 75%");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuenow", "75");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemin", "0");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemax", "100");

                lblPreProdTesting.Visible = true;
                chkPreProd.Visible = true;
                lblTestingConfirmed.Visible = true;

            }
            else if (((HiddenField)e.Item.FindControl("hiddenCMStatus")).Value == "Completed")
            {
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("style", "width: 100%");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuenow", "100");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemin", "0");
                ((HtmlControl)e.Item.FindControl("progressBar")).Attributes.Add("aria-valuemax", "100");

            }

        }

        protected void btnNewComment_Click(object sender, EventArgs e)
        {
            //validate comment text
            if (Validation.ValidateForm(txtNewComment.Text) && IsPageRefresh == false)
            {
                DateTime dt = DateTime.Now;
                string CMID = hiddenCMClicked.Value;
                Session.Add("UserID", 915368285);
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
                if(response > 0)
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
            if (chkPreProd.Checked == true)
            {
                objCommand.CommandText = "UpdateCMStatus";

                objCommand.Parameters.Clear();
                objCommand.Parameters.AddWithValue("@CMID", hiddenCMClicked.Value);
                objCommand.Parameters.AddWithValue("@CMStatus", "Pre-Production");

                objDB.DoUpdateUsingCmdObj(objCommand);
                Server.Transfer("UserDashboard.aspx");
            }
        }

        protected void btnDownloadAsPDF_Click(object sender, EventArgs e)
        {
            WebRequest request;
            WebResponse reponse;
            StreamReader reader;
            StreamWriter writer;
            string strHTML;
  
            string cmName = "CMRequest"; // will be dynamic later, need to figure out how to retrieve the specific name
            IronPdf.HtmlToPdf Renderer = new IronPdf.HtmlToPdf();
 
            request = WebRequest.Create("http://localhost:55877/AdminDashboard.aspx");
            reponse = request.GetResponse();
            reader = new StreamReader(reponse.GetResponseStream());
            strHTML = reader.ReadToEnd();

            var PDF = Renderer.RenderHtmlAsPdf(strHTML);

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + cmName + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(PDF.BinaryData);

            Response.End();
            Response.Flush();

        }
    }        
}
