﻿using System;
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
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                DBConnect db = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetAllUsers";

                DataSet cmData = db.GetDataSetUsingCmdObj(objCommand);
                DataTable dataTable = cmData.Tables[0];

                gvAllUsers.DataSource = cmData;
                gvAllUsers.DataBind();
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
            string UserID = "915307371";
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
    }
}