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
    
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        DBConnect db = new DBConnect();
        //        SqlCommand objCommand = new SqlCommand();
        //        objCommand.CommandType = CommandType.StoredProcedure;
        //        objCommand.CommandText = "GetAllCMsByUser";
        //        //objCommand.Parameters.Add()

        //        DataSet cmData = db.GetDataSetUsingCmdObj(objCommand);
        //        DataTable dataTable = cmData.Tables[0];
        //        gvUserRequests.DataSource = cmData;
        //        gvUserRequests.DataBind();
        //    }
        //}
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
                DataSet searchSet = db.GetDataSet("SELECT * FROM CM_Request WHERE UserID = "+ "915368285");
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