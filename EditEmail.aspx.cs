using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChangeManagementSystem
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        ArrayList list = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArrayList list = theList();
                gvEmails.DataSource = list;
                gvEmails.DataBind();
                
            }
        }

        private ArrayList theList()
        {
            list.Add(new allRequests(1, "Moved to Assigned", "Recruit User", "CM #{} : Has Been Assigned", "Your CM has been assigned to USER, Click Here to view CM"));
            list.Add(new allRequests(2, "Implemented in Pre-Prod", "Recruit User", "CM #{} : Has Been Implemented in Pre-Production", "Your CM has been implemented in pre-production, Click Here to view CM"));
            list.Add(new allRequests(3, "Implemented in Prod", "Recruit User", "CM #{} : Has Been Implemented in Production", "Your CM has been implemented in production, Click Here to view CM"));
            list.Add(new allRequests(4, "CM has failed", "Recruit User", "CM #{} : Has Failed", "Your CM has been marked as failed, Click Here to view CM"));
            list.Add(new allRequests(5, "New Request", "CM Admin", "New Request Submitted", "A new request has been submitted, Click Here to view CM"));
            list.Add(new allRequests(6, "Confirmed Testing", "CM Admin", "{USER} Has Confirmed Testing of CM # {}", "A User has confirmed testing on an existing CM, Click Here to view CM"));
            return list;
        }
        public class allRequests
        {
            private string body;
            private string subject;
            private string sent;
            private string type;
            private int id;
            public allRequests(int id, string type, string sent, string subject, string body)
            {
                Sent = sent;
                ID = id;
                Type = type;
                Subject = subject;
                Body = body;
            }
            public int ID
            {
                get { return id; }
                set { id = value; }
            }
            public string Sent
            {
                get { return sent; }
                set { sent = value; }
            }
            public string Subject
            {
                get { return subject; }
                set { subject = value; }
            }
            public string Body
            {
                get { return body; }
                set { body = value; }
            }
            public string Type
            {
                get { return type; }
                set { type = value; }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string body = txtBody.Text;

        }
    }
}