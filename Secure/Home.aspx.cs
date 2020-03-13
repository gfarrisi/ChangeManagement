using ChangeManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChangeManagementSystem.Secure
{
    public partial class Home : System.Web.UI.Page
    {

        DBConnect objDB;
        SqlCommand objCommand;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (isAuthenticated() == false)
            {
                Session["Authenticated"] = false;
                Response.Redirect("default.aspx");
            }
            else if (isAuthenticated() == true)
            {

                string TUID = Session["TU_ID"].ToString();

                objDB = new DBConnect();
                objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetUserByID";
                objCommand.Parameters.Clear();
                objCommand.Parameters.AddWithValue("@UserID", TUID);

                DataSet userData = objDB.GetDataSetUsingCmdObj(objCommand);
                DataTable dt = userData.Tables[0];


                string type = dt.Rows[0]["UserType"].ToString();

                if (type == "Admin")
                {
                    Response.Redirect("../AdminDashboard.aspx");
                }
                else
                {
                    Response.Redirect("../UserDashboard.aspx");
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
                    isAllowed = true;
                }
            }

            return isAllowed;
        }

    }
}