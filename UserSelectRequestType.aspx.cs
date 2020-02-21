using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChangeManagementSystem;
using ChangeManagementSystem.RequestLibrary;
using ChangeManagementSystem.Utilities;

namespace ChangeManagementSystem
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ///UPDATE NEEDED * 
                ///call database using stored procedure and retrieve all request type names and request type id's
                ///based on uniqe request type id's 
                ///then loop through the returned dataset and 
                ///add to values in a similar way
                ///values.Add(new SelectRequestType(row.Request_Name, row.Request_TypeID));

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
                        if(typeID != 99)
                        {
                            values.Add(new SelectRequestType(typeName, typeID));
                        }
                    }

                    rptUserRequest.DataSource = values;
                    rptUserRequest.DataBind();
                }

            }
        }

        protected void btnRequestType_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            var hf = (HiddenField)item.FindControl("hfSelectRequestType");

            Session["SelectedRequestType"] = hf.Value;
            Response.Redirect("UserNewCM.aspx");
        }
    }
}