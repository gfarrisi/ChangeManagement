using ChangeManagementSystem.RequestLibrary;
using ChangeManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChangeManagementSystem
{
    public partial class UserDashboard : System.Web.UI.Page
    {
        DBConnect objDB;
        SqlCommand objCommand;
        DataSet dashboardData;
        SqlCommand objCommandDashboard;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Session.Add("UserID", 915351046); // Admin user in database; will be preserved from login in the future

                objDB = new DBConnect();
                objCommand = new SqlCommand();
                objCommandDashboard = new SqlCommand();

                // Not assigned CMs

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetCMResponsesByUserByStatus";
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

                objCommandDashboard.Parameters.Clear();
                objCommandDashboard.Parameters.AddWithValue("@CMStatus", "pre-production");
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

                objCommandDashboard.Parameters.Clear();
                objCommandDashboard.Parameters.AddWithValue("@CMStatus", "completed");
                objCommandDashboard.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());

                dashboardData = objDB.GetDataSetUsingCmdObj(objCommandDashboard);
                rptCompleted.DataSource = dashboardData;
                rptCompleted.DataBind();
            }
            
        }

        protected void btnNewRequest_Click(object sender, EventArgs e)
        {

            Response.Redirect("SelectRequestType.aspx");
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAllRequests.aspx");
        }

    }
               
}
