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
        SqlCommand objCommand = new SqlCommand();
        DBConnect db = new DBConnect();
        DataSet ds = new DataSet();
        bool IsPageRefresh = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (isAuthenticated() == false)
            {
                Session["Authenticated"] = false;
                Response.Redirect("default.aspx");
            }
            else if (isAuthenticated() == true)
            {
                if (!this.IsPostBack)
                {
                    lblError2.Attributes.Add("class", "invisible");
                    lblError.Text = "";
                    lblError2.Text = "";
                    btnManual.Visible = false;
                    ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                    Session["SessionId"] = ViewState["ViewStateId"].ToString();
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
                objCommand.Parameters.Clear();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "UserSearch";
                SqlParameter inputParameter = new SqlParameter("@Search", search);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                inputParameter.Size = 50;
                objCommand.Parameters.Add(inputParameter);

                DataSet searchSet = db.GetDataSetUsingCmdObj(objCommand);
                gvAllUsers.DataSource = searchSet;
                gvAllUsers.DataBind();
            }
        }

        protected void btnDeactivate_Click(object sender, EventArgs e)
        {
            objCommand.Parameters.Clear();
            DBConnect db = new DBConnect();
            objCommand.CommandType = CommandType.StoredProcedure;

            int UserID = Convert.ToInt32(hf.Value);
            objCommand.Parameters.AddWithValue("@UserID", UserID);
            string theDate = DateTime.Now.ToString();
            objCommand.Parameters.AddWithValue("@Date", theDate);
            objCommand.CommandText = "DeactivateUser";
            db.GetDataSetUsingCmdObj(objCommand);

            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetAllUsers";
            DataSet cmData = db.GetDataSetUsingCmdObj(objCommand);
            DataTable dataTable = cmData.Tables[0];

            gvAllUsers.DataSource = cmData;
            gvAllUsers.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            string TUID = txtID.Text;
            if (!string.IsNullOrWhiteSpace(TUID))// if not blank
            {
                /*Security Session Variable*/
                Session["Authenticated"] = true;

                /* Requesting user's LDAP information via Web Service */
                WebService.LDAPuser Temple_Information = WebService.Webservice.getLDAPEntryByTUID(TUID);

                /* Checking we received something from Web Services*/
                if (Temple_Information != null)// if pulls some info
                {
                    /*Populating the Session Object with the user's information*/
                    Session["TU_ID"] = Temple_Information.templeEduID;
                    Session["First_Name"] = Temple_Information.givenName;
                    Session["Last_Name"] = Temple_Information.sn;
                    Session["Email"] = Temple_Information.mail;

                    /* If the user is a student, we can request academic information via the Web Service */
                    WebService.StudentObj Student_Information = WebService.Webservice.getStudentInfo(Temple_Information.templeEduID);

                    /* Checking we received something from Web Service and then adding information to the Session Object*/
                    if (Student_Information != null)
                    {
                        Session["School"] = Student_Information.school;
                    }

                    int check = checkDisabled(TUID);
                    if (check == 1) //if info already in DB alert them
                    {
                        lblError.Text = "An account already exists with this ID";
                        txtID.Text = "";
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModal').modal('show')", true);
                    }
                    else if (check == 2) //if in but disabled, reactivate
                    {
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "ReactivateUser";
                        objCommand.Parameters.Clear();
                        objCommand.Parameters.AddWithValue("@UserID", TUID);
                        string theDate = DateTime.Now.ToString();
                        objCommand.Parameters.AddWithValue("@Date", theDate);
                        
                        db.GetDataSetUsingCmdObj(objCommand);

                        objCommand.Parameters.Clear();
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "GetAllUsers";
                        DataSet cmData = db.GetDataSetUsingCmdObj(objCommand);
                        DataTable dataTable = cmData.Tables[0];

                        gvAllUsers.DataSource = cmData;
                        gvAllUsers.DataBind();
                    }
                    else // else enter the user
                    {
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "AddUser";
                        objCommand.Parameters.Clear();
                        objCommand.Parameters.AddWithValue("@UserID", TUID);
                        string type = ddlType.SelectedValue.ToString();
                        objCommand.Parameters.AddWithValue("@UserType", type);
                        objCommand.Parameters.AddWithValue("@FirstName", Session["First_Name"].ToString());
                        objCommand.Parameters.AddWithValue("@LastName", Session["Last_Name"].ToString());
                        objCommand.Parameters.AddWithValue("@Email", Session["Email"].ToString());
                        objCommand.Parameters.AddWithValue("@College", Session["School"].ToString());
                        string theDate = DateTime.Now.ToString();
                        objCommand.Parameters.AddWithValue("@Date", theDate);

                        db.GetDataSetUsingCmdObj(objCommand);

                        objCommand.Parameters.Clear();
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "GetAllUsers";
                        DataSet cmData = db.GetDataSetUsingCmdObj(objCommand);
                        DataTable dataTable = cmData.Tables[0];

                        gvAllUsers.DataSource = cmData;
                        gvAllUsers.DataBind();
                    }
                }
                else// if no info pulled, enter manually
                {
                    lblError.Text = "Error: Enter account manually or try again";
                    txtID.Text = "";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModal').modal('show')", true);
                    btnManual.Visible = true;
                    // new modal or page for entering all info and stored procedure for new user
                }
            }
            else
            {
                //Error: Couldn't retrieve employeeNumber from request header
                lblError.Text = "Please enter a TUID";
                txtID.Text = "";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModal').modal('show')", true);
            }
        }

        public int checkDisabled(string TUID)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetUserByID";
            objCommand.Parameters.Clear();
            objCommand.Parameters.AddWithValue("@UserID", TUID);

            DataSet myDS = db.GetDataSetUsingCmdObj(objCommand);
            int size = myDS.Tables[0].Rows.Count;

            if(size == 0)
            {
                return 0;
            }
            else
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "CheckUserActive";
                objCommand.Parameters.Clear();
                objCommand.Parameters.AddWithValue("@UserID", TUID);

                DataSet myDS2 = db.GetDataSetUsingCmdObj(objCommand);
                int size2 = myDS2.Tables[0].Rows.Count;

                if (size2 == 0)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            
        }

        protected void btnManual_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#manualModal').modal('show')", true);
        }

        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            btnAdd2.Visible = false;
            string TUID = txtID2.Text;
            string firstName = txtFName.Text;
            string lastName = txtLName.Text;
            string userEmail = txtEmail.Text;
            string college = txtCollege.Text;
            if (!Validation.ValidateNewUser(TUID, firstName, lastName, userEmail, college))
            {
                lblError2.Attributes.Remove("invisible");
                lblError2.Text = "Make sure every field has been filled out";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#manualModal').modal('show')", true);
            }
            else
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "AddUser";
                objCommand.Parameters.Clear();
                objCommand.Parameters.AddWithValue("@UserID", TUID);
                string type = ddlType2.SelectedValue.ToString();
                objCommand.Parameters.AddWithValue("@UserType", type);
                objCommand.Parameters.AddWithValue("@FirstName", firstName);
                objCommand.Parameters.AddWithValue("@LastName", lastName);
                objCommand.Parameters.AddWithValue("@Email", userEmail);
                objCommand.Parameters.AddWithValue("@College", college);
                string theDate = DateTime.Now.ToString();
                objCommand.Parameters.AddWithValue("@Date", theDate);

                db.GetDataSetUsingCmdObj(objCommand);

                objCommand.Parameters.Clear();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetAllUsers";
                DataSet cmData = db.GetDataSetUsingCmdObj(objCommand);
                DataTable dataTable = cmData.Tables[0];

                gvAllUsers.DataSource = cmData;
                gvAllUsers.DataBind();
            }
        }

        protected void btnOpenModal_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModal').modal('show')", true);
            lblError.Text = "";
            lblError2.Text = "";
            btnManual.Visible = false;
        }
    }
}