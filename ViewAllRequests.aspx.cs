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

namespace ChangeManagementSystem
{
    public partial class ViewAllRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
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

            //old way of binding data to grid view:

            //objCommand.CommandType = CommandType.StoredProcedure;
            //objCommand.CommandText = "GetAllCMsAdminView";
            ////DataTable requestTable = new DataTable();

            //DataSet cmData = db.GetDataSetUsingCmdObj(objCommand);
            //DataTable dataTable = cmData.Tables[0];

            //foreach (DataRow row in dataTable.Rows)
            //{
            //    string ID = row["CMID"].ToString();
            //    string user = row["UserID"].ToString();
            //    string admin = row["AdminID"].ToString();
            //    string Name = row["CMProjectName"].ToString();
            //    string question = row["Question/Comments"].ToString();
            //    string type = row["RequestTypeName"].ToString();
            //    string college = row["College"].ToString();
            //    string status = row["CMStatus"].ToString();
            //    string date = row["LastUpdateDate"].ToString();



            //    ArrayList listDB = new ArrayList();
            //    listDB.Add(new allRequests(ID, user, admin, college, type, status, date));
            //    gvAllRequests.DataSource = dataTable;
            //    gvAllRequests.DataBind();
            //}
            
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
        //gvAllRequests.DataSource = list;
        //gvAllRequests.DataBind();

        protected void EyeButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CM.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DBConnect db2 = new DBConnect();
            SqlCommand objCommand2 = new SqlCommand();

            if (txtSearch.Text == "")
            {

                objCommand2.CommandType = CommandType.StoredProcedure;
                objCommand2.CommandText = "GetAllCMsAdminView";
                //DataTable requestTable = new DataTable();

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

    }
}