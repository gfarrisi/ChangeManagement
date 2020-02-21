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
    public partial class ViewAllUsers : System.Web.UI.Page
    {
        SqlCommand dbCommand = new SqlCommand();
        DBConnect db = new DBConnect();
        DataSet ds = new DataSet();
        //      protected void Page_Load(object sender, EventArgs e)
        //{

        //          if (!IsPostBack)
        //          {
        //              DBConnect db = new DBConnect();
        //              SqlCommand objCommand = new SqlCommand();
        //              objCommand.CommandType = CommandType.StoredProcedure;
        //              objCommand.CommandText = "GetAllUsers";

        //              DataSet cmData = db.GetDataSetUsingCmdObj(objCommand);
        //              DataTable dataTable = cmData.Tables[0];

        //              gvAllUsers.DataSource = cmData;
        //              gvAllUsers.DataBind();
        //          }
        //      }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DBConnect db = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetUserByID";
                objCommand.Parameters.Clear();
                objCommand.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());

                DataSet userData = db.GetDataSetUsingCmdObj(objCommand);
                DataTable dt = userData.Tables[0];
                string userName = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                lblUserName.Text = userName;

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
                cmd.CommandText = "GetAllUsers";
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
                            gvAllUsers.DataSource = dv;
                        }
                        else
                        {
                            gvAllUsers.DataSource = dt;
                        }
                        gvAllUsers.DataBind();
                    }
                }
            }
        }

        protected void btnNewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewUser.aspx");
        }

        protected void EyeButton_Click(object sender, ImageClickEventArgs e)
        {
            dbCommand.Parameters.Clear();
            DBConnect db = new DBConnect();
            dbCommand.CommandType = CommandType.StoredProcedure;
            HiddenField field = (HiddenField)gvAllUsers.Rows[gvAllUsers.SelectedIndex].FindControl("hdnfldVariable");
            string UserID = field.ToString();
            dbCommand.Parameters.AddWithValue("@UserID", UserID);
            string theDate = DateTime.Now.ToString();
            dbCommand.Parameters.AddWithValue("@Date", theDate);
            dbCommand.CommandText = "DeactivateUser";
            db.GetDataSetUsingCmdObj(dbCommand);

            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "GetAllUsers";
            DataSet cmData = db.GetDataSetUsingCmdObj(dbCommand);
            DataTable dataTable = cmData.Tables[0];

            gvAllUsers.DataSource = cmData;
            gvAllUsers.DataBind();

            //data - dismiss = "modal"
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                DataSet searchSet = db.GetDataSet("SELECT * FROM [User] WHERE Active = 1");
                gvAllUsers.DataSource = searchSet;
                gvAllUsers.DataBind();
            }
            else
            {
                string search = txtSearch.Text;
                dbCommand.Parameters.Clear();
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = "UserSearch";
                SqlParameter inputParameter = new SqlParameter("@Search", search);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                inputParameter.Size = 50;
                dbCommand.Parameters.Add(inputParameter);

                DataSet searchSet = db.GetDataSetUsingCmdObj(dbCommand);
                gvAllUsers.DataSource = searchSet;
                gvAllUsers.DataBind();
            }
        }

        protected void btnDeactivate_Click(object sender, EventArgs e)
        {
            dbCommand.Parameters.Clear();
            DBConnect db = new DBConnect();
            dbCommand.CommandType = CommandType.StoredProcedure;

            HiddenField field = (HiddenField)gvAllUsers.Rows[gvAllUsers.SelectedIndex].FindControl("hdnfldVariable");
            string UserID = field.ToString();
            dbCommand.Parameters.AddWithValue("@UserID", UserID);
            string theDate = DateTime.Now.ToString();
            dbCommand.Parameters.AddWithValue("@Date", theDate);
            dbCommand.CommandText = "DeactivateUser";
            db.GetDataSetUsingCmdObj(dbCommand);

            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "GetAllUsers";
            DataSet cmData = db.GetDataSetUsingCmdObj(dbCommand);
            DataTable dataTable = cmData.Tables[0];

            gvAllUsers.DataSource = cmData;
            gvAllUsers.DataBind();
        }
    }
}