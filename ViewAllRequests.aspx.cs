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
    public partial class ViewAllRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArrayList list = theList();

                gvAllRequests.DataSource = list;
                gvAllRequests.DataBind();

                //// Create a new table.
                //DataTable taskTable = new DataTable("TaskList");

                //// Create the columns.
                //taskTable.Columns.Add("Id", typeof(int));
                //taskTable.Columns.Add("Description", typeof(string));

                ////Add data to the new table.
                //for (int i = 0; i < 10; i++)
                //{
                //    DataRow tableRow = taskTable.NewRow();
                //    tableRow["Id"] = i;
                //    tableRow["Description"] = "Task " + (10 - i).ToString();
                //    taskTable.Rows.Add(tableRow);
                //}

                ////Persist the table in the Session object.
                //Session["TaskTable"] = taskTable;

                ////Bind the GridView control to the data source.
                //gvAllRequests.DataSource = Session["TaskTable"];
                //gvAllRequests.DataBind();
            }
        }
        //protected void gvAllRequests_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    //Retrieve the table from the session object.
        //    DataTable dt = Session["TaskTable"] as DataTable;
        //    if (dt != null)
        //    {
        //        //Sort the data.
        //        dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
        //        gvAllRequests.DataSource = Session["TaskTable"];
        //        gvAllRequests.DataBind();
        //    }
        //}
        //private string GetSortDirection(string column)
        //{
        //    // By default, set the sort direction to ascending.
        //    string sortDirection = "ASC";
        //    // Retrieve the last column that was sorted.
        //    string sortExpression = ViewState["SortExpression"] as string;

        //    if (sortExpression != null)
        //    {
        //        // Check if the same column is being sorted.
        //        // Otherwise, the default value can be returned.
        //        if (sortExpression == column)
        //        {
        //            string lastDirection = ViewState["SortDirection"] as string;
        //            if ((lastDirection != null) && (lastDirection == "ASC"))
        //            {
        //                sortDirection = "DESC";
        //            }
        //        }
        //    }
        //    // Save new values in ViewState.
        //    ViewState["SortDirection"] = sortDirection;
        //    ViewState["SortExpression"] = column;
        //    return sortDirection;
        //}

        private ArrayList theList()
        {
            ArrayList list = new ArrayList();
            list.Add(new allRequests("CM1900", "Jane Doe", "Kristi Morgridge", "CLA", "Systems View", "Complete", "8/18/19"));
            list.Add(new allRequests("CM1901", "Sandy James", "Kristi Morgridge", "Boyer", "Entity", "Not Assigned", "10/08/19"));
            list.Add(new allRequests("CM1902", "Sam Kelly", "Dima Dabbas", "Global", "Forms", "Preprod", "10/24/19"));
            list.Add(new allRequests("CM1903", "Lauren O'Neil", "Dima Dabbas", "Tyler", "Field", "Complete", "9/28/19"));
            list.Add(new allRequests("CM1904", "Jaime Martino", "Kristi Morgridge", "UG", "Activity Codes", "Assigned", "9/22/19"));
            list.Add(new allRequests("CM1905", "Jane Doe", "Kristi Morgridge", "CLA", "Work Flow", "Preprod", "9/28/19"));
            list.Add(new allRequests("CM1906", "Jane Doe", "Dima Dabbas", "CLA", "Activity Codes", "Assigned", "10/24/19"));
            list.Add(new allRequests("CM1907", "Helene Houser", "Kristi Morgridge", "CRM", "Workflow", "Complete", "8/8/19"));
            list.Add(new allRequests("CM1908", "Megan Nyquist", "Dima Dabbas", "CST", "System Views", "Failed", "8/8/19"));
            list.Add(new allRequests("CM1909", "Jane Doe", "Dima Dabbas", "CLA", "Field", "Complete", "9/28/19"));
            list.Add(new allRequests("CM1910", "Sam Kelly", "Kristi Morgridge", "Global", "Forms", "Preprod", "10/24/19"));
            list.Add(new allRequests("CM1911", "Megan Nyquist", "Dima Dabbas", "CST", "System Views", "Failed", "8/8/19"));
            list.Add(new allRequests("CM1912", "Sandy James", "Dima Dabbas", "Global", "Forms", "Preprod", "10/24/19"));
            list.Add(new allRequests("CM1913", "Jane Doe", "Dima Dabbas", "CLA", "Forms", "Preprod", "10/24/19"));
            list.Add(new allRequests("CM1914", "Sandy James", "Kristi Morgridge", "Boyer", "Entity", "Not Assigned", "10/08/19"));
            list.Add(new allRequests("CM1915", "Lauren O'Neil", "Dima Dabbas", "Tyler", "Field", "Complete", "9/28/19"));
            list.Add(new allRequests("CM1916", "Jane Doe", "Kristi Morgridge", "CLA", "Entity", "Not Assigned", "10/08/19"));
            list.Add(new allRequests("CM1917", "Sam Kelly", "Dima Dabbas", "Global", "Forms", "Preprod", "10/24/19"));
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
    }
}