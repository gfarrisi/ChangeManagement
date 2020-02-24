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
using ChangeManagementSystem.RequestLibrary;

namespace ChangeManagementSystem
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        DBConnect db = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetAllCMsByUser";
                objCommand.Parameters.AddWithValue("@UserID", "915368285");

                DataSet cmData = db.GetDataSetUsingCmdObj(objCommand);
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
                    gvUserRequests.DataSource = dataTable;
                    gvUserRequests.DataBind();
                }
            }
        }

     
        
        private string SortDirection
        {
            get { return ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "ASC"; }
            set { ViewState["SortDirection"] = value; }
        }
        protected void OnSorting(object sender, GridViewSortEventArgs e)
        {
            this.BindGrid(e.SortExpression);

        }

        private void BindGrid(string sortExpression = null)
        {
            DBConnect db = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllCMsByUser";
                cmd.Parameters.AddWithValue("@UserID", "915368285");
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
                            gvUserRequests.DataSource = dv;
                        }
                        else
                        {
                            gvUserRequests.DataSource = dt;
                        }
                        gvUserRequests.DataBind();
                    }
                }
            }
        }


        protected void EyeButton_Click(object sender, ImageClickEventArgs e)
        {
            //  Response.Redirect("CM.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlCommand dbCommand = new SqlCommand();
            DBConnect db = new DBConnect();
            DataSet ds = new DataSet();
            if (txtSearch.Text == "")
            {
                objCommand.Parameters.Clear();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetAllCMsByUser";
                objCommand.Parameters.AddWithValue("@UserID", "915368285");

                DataSet cmData = db.GetDataSetUsingCmdObj(objCommand);
                DataTable dataTable = cmData.Tables[0];
                gvUserRequests.DataSource = dataTable;
                gvUserRequests.DataBind();
            }
            else
            {
                string search = txtSearch.Text;
                objCommand.Parameters.Clear();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "UserRequestSearch";
                SqlParameter inputParameter = new SqlParameter("@Search", search);
                SqlParameter inputParameter2 = new SqlParameter("@UserID", "915368285");

                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                inputParameter.Size = 50;
                objCommand.Parameters.Add(inputParameter);
                objCommand.Parameters.Add(inputParameter2);

                DataSet searchSet = db.GetDataSetUsingCmdObj(objCommand);
                gvUserRequests.DataSource = searchSet;
                gvUserRequests.DataBind();
            }
        }

        protected void gvUserRequests_Sorting(object sender, GridViewSortEventArgs e)
        {

        }
    }
}