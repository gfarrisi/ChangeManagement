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

namespace ChangeManagementSystem
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlCommand dbCommand = new SqlCommand();
        DBConnect db = new DBConnect();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DBConnect db = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetAllCMsByUser";

                DataSet cmData = db.GetDataSetUsingCmdObj(objCommand);
                DataTable dataTable = cmData.Tables[0];
                gvUserRequests.DataSource = cmData;
                gvUserRequests.DataBind();
            }
        }

        protected void EyeButton_Click(object sender, ImageClickEventArgs e)
        {
          //  Response.Redirect("CM.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                DataSet searchSet = db.GetDataSet("SELECT * FROM CM_Request WHERE UserID = "+ "915351046");
                gvUserRequests.DataSource = searchSet;
                gvUserRequests.DataBind();
            }
            else
            {
                string search = txtSearch.Text;
                dbCommand.Parameters.Clear();
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = "UserRequestSearch";
                SqlParameter inputParameter = new SqlParameter("@Search", search);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                inputParameter.Size = 50;
                dbCommand.Parameters.Add(inputParameter);

                DataSet searchSet = db.GetDataSetUsingCmdObj(dbCommand);
                gvUserRequests.DataSource = searchSet;
                gvUserRequests.DataBind();
            }
        }
    }
}