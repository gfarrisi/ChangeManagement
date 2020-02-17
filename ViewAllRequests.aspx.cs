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
    public partial class ViewAllRequests : System.Web.UI.Page
    {
        SqlCommand dbCommand = new SqlCommand();
        DBConnect db = new DBConnect();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //sam:
                
                DBConnect db = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetAllCMsAdminView";

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
                    listDB.Add(new allRequests(ID, user, admin,college, type, status, date));
                    gvAllRequests.DataSource = dataTable;
                    gvAllRequests.DataBind();
                }
            }
        }

        private ArrayList theList()
        {
            ArrayList list = new ArrayList();
            list.Add(new allRequests("CM1900", "Jane Doe", "Kristi Morgridge", "CLA", "Systems View", "Complete", "11/18/19"));
            list.Add(new allRequests("CM1901", "Sandy James", "Kristi Morgridge", "Boyer", "Entity", "Not Assigned", "12/02/19"));

            return list;
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
            Response.Redirect("CM.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    if (txtSearch.Text == "")
        //    {
        //        DataSet searchSet = db.GetDataSet("SELECT * FROM CM_Request");
        //        gvAllRequests.DataSource = searchSet;
        //        gvAllRequests.DataBind();
        //    }
        //    else
        //    {
        //        string search = txtSearch.Text;
        //        dbCommand.Parameters.Clear();
        //        dbCommand.CommandType = CommandType.StoredProcedure;
        //        dbCommand.CommandText = "UserRequestSearch";
        //        SqlParameter inputParameter = new SqlParameter("@Search", search);
        //        inputParameter.Direction = ParameterDirection.Input;
        //        inputParameter.SqlDbType = SqlDbType.VarChar;
        //        inputParameter.Size = 50;
        //        dbCommand.Parameters.Add(inputParameter);

        //        DataSet searchSet = db.GetDataSetUsingCmdObj(dbCommand);
        //        gvAllRequests.DataSource = searchSet;
        //        gvAllRequests.DataBind();
        //    }
        //}
    }
}