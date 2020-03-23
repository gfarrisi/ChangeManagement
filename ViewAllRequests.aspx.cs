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
        SqlCommand objCommand = new SqlCommand();
        DBConnect db = new DBConnect();
        DataSet ds = new DataSet();
        bool IsPageRefresh = false;
        protected void Page_Load(object sender, EventArgs e)
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
        }
        private string SortDirection
        {
            get { return ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "ASC"; }
            set { ViewState["SortDirection"] = value; }
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
                        if (sortExpression != null)
                        {
                            DataView dv = dt.AsDataView();
                            this.SortDirection = this.SortDirection == "ASC" ? "DESC" : "ASC";

                            dv.Sort = sortExpression + " " + this.SortDirection;
                            gvAllRequests.DataSource = dv;
                        }
                        else
                        {
                            gvAllRequests.DataSource = dt;
                        }
                        gvAllRequests.DataBind();
                    }
                }
            }
        }
        protected void OnSorting(object sender, GridViewSortEventArgs e)
        {
            this.BindGrid(e.SortExpression);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DBConnect db2 = new DBConnect();
            SqlCommand objCommand2 = new SqlCommand();

            if (txtSearch.Text == "")
            {
                objCommand2.CommandType = CommandType.StoredProcedure;
                objCommand2.CommandText = "GetAllCMsAdminView";

                DataSet cmData = db2.GetDataSetUsingCmdObj(objCommand2);
                DataTable dataTable = cmData.Tables[0];

                foreach (DataRow row in dataTable.Rows)
                {
                    string ID = row["CMID"].ToString();
                    string user = row["UserID"].ToString();
                    string admin = row["AdminID"].ToString();
                    string Name = row["CMProjectName"].ToString();
                    string question = row["Question/Comments"].ToString();
                    string type = row["RequestTypeName"].ToString();
                    string college = row["College"].ToString();
                    string status = row["CMStatus"].ToString();
                    string date = row["LastUpdateDate"].ToString();

                    ArrayList listDB = new ArrayList();
                    listDB.Add(new allRequests(ID, user, admin, college, type, status, date));
                    gvAllRequests.DataSource = dataTable;
                    gvAllRequests.DataBind();
                }
            }
            else
            {
                string search = txtSearch.Text;
                objCommand2.Parameters.Clear();
                objCommand2.CommandType = CommandType.StoredProcedure;
                objCommand2.CommandText = "SearchAllCMsAdminView";
                SqlParameter inputParameter = new SqlParameter("@Search", search);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                inputParameter.Size = 50;
                objCommand2.Parameters.Add(inputParameter);

                DataSet searchSet = db2.GetDataSetUsingCmdObj(objCommand2);
                gvAllRequests.DataSource = searchSet;
                gvAllRequests.DataBind();
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
            }
            else if (((HiddenField)e.Item.FindControl("hiddenCMStatus")).Value == "Pre-Production")
            {
                ddlCMStatus.Visible = true;
                lblCMStatus.Text = "Update Status";

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
                string CMID = hf.Value;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            objCommand.CommandText = "UpdateCMStatus";

            objCommand.Parameters.Clear();
            objCommand.Parameters.AddWithValue("@CMID", hf.Value);

            if (ddlCMStatus.SelectedValue == "CM Failed")
            {
                objCommand.Parameters.AddWithValue("@CMStatus", "Failed");
            }
            else if (ddlCMStatus.SelectedValue == "Assign to Me")
            {
                objCommand.CommandText = "UpdateCMStatusAndAdmin";
                objCommand.Parameters.AddWithValue("@CMStatus", "Assigned");
                objCommand.Parameters.AddWithValue("@AdminID", Session["UserID"].ToString());
            }
            else if (ddlCMStatus.SelectedValue == "Change Implemented in Pre-Production")
            {
                objCommand.Parameters.AddWithValue("@CMStatus", "Pre-Production Needs Testing");
            }
            else if (ddlCMStatus.SelectedValue == "Change Implemented in Production")
            {
                objCommand.Parameters.AddWithValue("@CMStatus", "Production");
            }

            db.DoUpdateUsingCmdObj(objCommand);
            Server.Transfer("AdminDashboard.aspx");
            // Need to open confirmation modal after performing update and reload dashboard

            // Conditions will eventually need to trigger emails
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

                objCommand.CommandText = "GetCMAndUserByID";
                dataSet = db.GetDataSetUsingCmdObj(objCommand);
                rptRequestInfo.DataSource = dataSet;
                rptRequestInfo.DataBind();

                objCommand.CommandText = "GetCMAndAdminByID";
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
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetComments";
                objCommand.Parameters.Clear();
                string CMID = "915368285";
                objCommand.Parameters.AddWithValue("@CMID", CMID);
            }
        }

        protected void gvAllRequests_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                    e.Row.Style.Add("height", "50px");
            }
        }
    }
}