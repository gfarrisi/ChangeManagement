using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChangeManagementSystem.RequestLibrary
{
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
}