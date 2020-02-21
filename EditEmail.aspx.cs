using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ChangeManagementSystem.Utilities;
using ChangeManagementSystem.RequestLibrary;

namespace ChangeManagementSystem
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        ArrayList list = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {


                if (!IsPostBack)
                {
                    DBConnect db = new DBConnect();
                    SqlCommand objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "GetEmailTemplate";

                    DataSet cmData = db.GetDataSetUsingCmdObj(objCommand);
                    DataTable dataTable = cmData.Tables[0];

                    gvEmails.DataSource = cmData;
                    gvEmails.DataBind();
                }
            }
        

      
        protected void btnEdit_Click(object sender, EventArgs e)
        {
          
            Response.Write("<script>alert('" + (hf.Value.ToString()) + "');</script>");

            int row = Convert.ToInt32(hf.Value);
            GridViewRow emailRow = gvEmails.SelectedRow;

            string body = txtBody.Text;

            DBConnect db = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateEmailTemplate";

            objCommand.Parameters.AddWithValue("@id", row);
            objCommand.Parameters.AddWithValue("@Body",body);
            db.GetConnection().Open();
            db.ExecuteScalarFunction(objCommand);



            DBConnect db2 = new DBConnect();
            SqlCommand objCommand2 = new SqlCommand();
            objCommand2.CommandType = CommandType.StoredProcedure;
            objCommand2.CommandText = "GetEmailTemplate";

            DataSet cmData2 = db.GetDataSetUsingCmdObj(objCommand2);
            DataTable dataTable2 = cmData2.Tables[0];

            gvEmails.DataSource = cmData2;
            gvEmails.DataBind();
        }
    }
}