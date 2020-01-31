using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Empty_Project_Template.RequestLibrary;
using Empty_Project_Template.Utilities;

namespace Empty_Project_Template
{
    public partial class NewRequest2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

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
                        values.Add(new SelectRequestType(typeName, typeID));
                    }

                    Repeater1.DataSource = values;
                    Repeater1.DataBind();
                }
                //ArrayList values = new ArrayList();

                //values.Add(new SelectRequestType("Activity Codes", 1001));
                //values.Add(new SelectRequestType("Business Rules", 1002));
                //values.Add(new SelectRequestType("Entity", 1004));
                //values.Add(new SelectRequestType("Field", 1005));
                //values.Add(new SelectRequestType("Forms", 1006));
                //values.Add(new SelectRequestType("JavaScript on WFE", 1007));
                //values.Add(new SelectRequestType("Option Sets", 1008));
                //values.Add(new SelectRequestType("Relationships", 1009));
                //values.Add(new SelectRequestType("Security Roles", 1010));
                //values.Add(new SelectRequestType("System Views", 1011));
                //values.Add(new SelectRequestType("New User/Modify User", 1012));
                //values.Add(new SelectRequestType("Web Resources", 1013));
                //values.Add(new SelectRequestType("Workflow", 1014));
                //values.Add(new SelectRequestType("Workflow Schedule", 1015));
                //values.Add(new SelectRequestType("Email Templates", 1017));
                //values.Add(new SelectRequestType("Other", 1016));

                //Repeater1.DataSource = values;
                //Repeater1.DataBind();
            }
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