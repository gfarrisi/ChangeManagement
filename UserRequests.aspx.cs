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
        DBConnect db = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetAllCMsByUser";
                objCommand.Parameters.AddWithValue("@UserID", "915351045");

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

        public class allRequests
        {
            private string user;
            private string admin;
            private string college;
            private string type;
            private string status;
            private string cmid;
            private string date;
            public allRequests(string cmid, string user, string admin, string college, string type, string status, string date)
            {
                Cmid = cmid;
                User = user;
                Admin = admin;
                College = college;
                Type = type;
                Status = status;
                Date = date;
            }
            public string User
            {
                get { return user; }
                set { user = value; }
            }
            public string Admin
            {
                get { return admin; }
                set { admin = value; }
            }
            public string College
            {
                get { return college; }
                set { college = value; }
            }
            public string Type
            {
                get { return type; }
                set { type = value; }
            }
            public string Status
            {
                get { return status; }
                set { status = value; }
            }
            public string Date
            {
                get { return date; }
                set { date = value; }
            }
            public string Cmid
            {
                get { return cmid; }
                set { cmid = value; }
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
                objCommand.Parameters.Clear();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetAllCMsByUser";
                objCommand.Parameters.AddWithValue("@UserID", "915351045");

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
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                inputParameter.Size = 50;
                objCommand.Parameters.Add(inputParameter);

                DataSet searchSet = db.GetDataSetUsingCmdObj(objCommand);
                gvUserRequests.DataSource = searchSet;
                gvUserRequests.DataBind();
            }
        }
    }
}