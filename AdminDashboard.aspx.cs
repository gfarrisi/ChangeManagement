
using ChangeManagementSystem.Utilities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ChangeManagementSystem
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetCMsByStatus";
                objCommand.Parameters.AddWithValue("@CMStatus", "not assigned");


            }
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAllRequests.aspx");
        }
        protected void btnNewRequest_Click(object sender, EventArgs e)
        {
            Response.Redirect("SelectRequestType.aspx");
        }
    }
}