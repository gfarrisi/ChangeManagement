using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Empty_Project_Template
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArrayList list = theList();
                //< td class="viewRequest" data-toggle="modal" data-target="#exampleModalLong" style="cursor: pointer"><i class='far fa-eye'></i></td>  
                gvUserRequests.DataSource = list;
                gvUserRequests.DataBind();
            }
        }
        private ArrayList theList()
        {
            ArrayList list = new ArrayList();
            list.Add(new allRequests("CM1900", "Jane Doe", "Kristi Morgridge", "CLA", "Systems View", "Complete", "11/18/19"));
            list.Add(new allRequests("CM1905", "Jane Doe", "Dima Dabbas", "CLA", "Work Flow", "Assigned", "11/26/19"));
            list.Add(new allRequests("CM1906", "Jane Doe", "Dima Dabbas", "CLA", "Activity Codes", "Assigned", "11/24/19"));
            list.Add(new allRequests("CM1909", "Jane Doe", "Dima Dabbas", "CLA", "Field", "Complete", "11/10/19"));
            list.Add(new allRequests("CM1913", "Jane Doe", "Dima Dabbas", "CLA", "Forms", "Preprod", "11/24/19"));
            list.Add(new allRequests("CM1916", "Jane Doe", "Kristi Morgridge", "CLA", "Entity", "Not Assigned", "12/01/19"));
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
          //  Response.Redirect("CM.aspx");
        }
    }
}