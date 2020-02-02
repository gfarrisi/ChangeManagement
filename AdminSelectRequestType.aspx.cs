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