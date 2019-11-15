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
	public partial class ViewAllUsers : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                ArrayList list = theList();

                gvAllUsers.DataSource = list;
                gvAllUsers.DataBind();
            }
        }

        private ArrayList theList()
        {
            ArrayList list = new ArrayList();
            list.Add(new allRequests("Matthew Schillizzi", "Boyer", "8/8/19"));
            list.Add(new allRequests("Sandy James", "Boyer", "8/8/19"));
            list.Add(new allRequests("Trevor Hinkle", "Boyer", "9/28/19"));
            list.Add(new allRequests("Jemin Patel", "CPH", "10/24/19"));
            list.Add(new allRequests("Philip Riesch", "CST", "8/8/19"));
            list.Add(new allRequests("Tristin Carmichael", "CST", "10/24/19"));
            list.Add(new allRequests("Megan Nyquist", "CST", "10/24/19"));
            list.Add(new allRequests("Lori Bailey", "EDUC", "10/08/19"));
            list.Add(new allRequests("Rahel Teklegiorgis", "EDUC", "9/28/19"));
            list.Add(new allRequests("Colleen Baillie", "CPH", "10/08/19"));
            list.Add(new allRequests("Liz Windhaus", "ENGR", "10/24/19"));
            list.Add(new allRequests("Erika Clemons", "Global", "8/18/19"));
            list.Add(new allRequests("Owen Jones", "Global", "10/08/19"));
            list.Add(new allRequests("Sam Kelley", "Global", "10/24/19"));
            list.Add(new allRequests("Michael Toner", "GRAD", "9/28/19"));
            list.Add(new allRequests("Sabriya McWilliams", "INTL", "9/22/19"));
            list.Add(new allRequests("Elle Butler", "INTL", "9/28/19"));
            list.Add(new allRequests("Kaitlin Pierce", "KLEIN", "10/24/19"));
            list.Add(new allRequests("Stefan Schechs", "LKSOM", "8/8/19"));
            list.Add(new allRequests("Neal Conley", "NDEG", "8/8/19"));
            list.Add(new allRequests("Joan Hankins", "PHARM", "9/28/19"));
            list.Add(new allRequests("Grace Ahn Klensin", "TYL", "10/24/19"));
            list.Add(new allRequests("Lauren O'Neil", "TYL", "8/8/19"));
            list.Add(new allRequests("Charles Musgrove", "UG", "10/24/19"));
            list.Add(new allRequests("Jaime Martino", "UG", "10/24/19"));
            list.Add(new allRequests("Dima Dabbas", "CRM", "10/08/19"));
            list.Add(new allRequests("Ferria Amzovski", "CRM", "9/28/19"));
            list.Add(new allRequests("Helene Houser", "CRM", "10/08/19"));
            list.Add(new allRequests("Kristi Morgridge", "CRM", "10/24/19"));
            return list;
        }

        public class allRequests
        {
            private string user;
            private string college;
            private string date;
            public allRequests(string user, string college, string date)
            {
                User = user;
                College = college;
                Date = date;
            }
            public string User
            {
                get { return user; }
                set { user = value; }
            }
            public string College
            {
                get { return college; }
                set { college = value; }
            }
            public string Date
            {
                get { return date; }
                set { date = value; }
            }
        }

        protected void btnNewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewUser.aspx");
        }

        protected void EyeButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CM.aspx");
        }
    }
}