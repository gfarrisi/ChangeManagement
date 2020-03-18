using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChangeManagementSystem.RequestLibrary;
using ChangeManagementSystem.Utilities;

namespace ChangeManagementSystem
{
    public partial class NewRequest2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (isAuthenticated() == false)
            {
                Session["Authenticated"] = false;
                Response.Redirect("default.aspx");
            }
            else if (isAuthenticated() == true)
            {
                if (!IsPostBack)
                {
                    DBConnect objDB = new DBConnect();
                    SqlCommand objCommand = new SqlCommand();


                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "GetUserByID";
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());

                    DataSet userData = objDB.GetDataSetUsingCmdObj(objCommand);
                    DataTable dt = userData.Tables[0];

                    string userName = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                    lblUserName.Text = userName;

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "GetAllRequestTypes";
                    objCommand.Parameters.Clear();

                    DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                    DataTable myDT = myDS.Tables[0];
                    if (myDT.Rows.Count > 0)
                    {

                        ArrayList values = new ArrayList();

                        foreach (DataRow row in myDT.Rows)
                        {
                            string typeName = row["RequestTypeName"].ToString();
                            int typeID = Convert.ToInt32(row["RequestTypeID"].ToString());
                            if (typeID != 99)
                            {
                                values.Add(new SelectRequestType(typeName, typeID));
                            }
                        }

                        Repeater1.DataSource = values;
                        Repeater1.DataBind();
                    }
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
                    if (Session["UserType"].ToString() == "Admin")
                    {
                        isAllowed = true;
                    }
                    else
                    {
                        isAllowed = false;
                    }
                }
            }

            return isAllowed;
        }

        protected void btnRequestType_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            var hf = (HiddenField)item.FindControl("hfSelectRequestType");

            Session["SelectedRequestType"] = hf.Value;
            Response.Redirect("AdminNewCM.aspx");
        }
    }


    //test class until we can bind data from database
    public class SelectRequestType
    {

        private string name;
        private int requestID;

        public SelectRequestType(string name, int requestID)
        {
            this.name = name;
            this.requestID = requestID;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int RequestID
        {
            get
            {
                return requestID;
            }
        }
    }
}