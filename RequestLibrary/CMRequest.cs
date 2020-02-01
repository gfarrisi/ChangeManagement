using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Empty_Project_Template.RequestLibrary
{
    public class CMRequest
    {
        private int cmID;
        private string cmStatus;
        private byte[] attachment1;
        private byte[] attachment2;
        private byte[] attachment3;
        private byte[] attachment4;
        private byte[] attachment5;
        private string questionsComments;
        private string lastUpdateUser;
        private DateTime lastUpdateDate;
        private string userID;
        private string adminID;
        private int requestTypeID;
        private DateTime desiredDate;
        private List<QuestionResponse> questionResponses;

        public CMRequest(string status, byte[] att1, byte[] att2, byte[] att3, byte[] att4, byte[] att5, string questComm, string lastUser,
            DateTime lastDate, string user, string admin, int typeID, DateTime desireddate, List<QuestionResponse> responses)
        {
            cmStatus = status;
            attachment1 = att1;
            attachment2 = att2;
            attachment3 = att3;
            attachment4 = att4;
            attachment5 = att5;
            questionsComments = questComm;
            lastUpdateUser = lastUser;
            lastUpdateDate = lastDate;
            userID = user;
            adminID = admin;
            requestTypeID = typeID;
            desiredDate = desireddate;
            questionResponses = responses;
        }

        public int CMID
        {
            get { return cmID; }
            set { cmID = value; }
        }

        public string CMStatus
        {
            get { return cmStatus; }
            set { cmStatus = value; }
        }

        public string LastUpdateUser
        {
            get { return lastUpdateUser; }
            set { lastUpdateUser = value; }
        }

        public DateTime LastUpdateDate
        {
            get { return lastUpdateDate; }
            set { lastUpdateDate = value; }
        }

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string AdminID
        {
            get { return adminID; }
            set { adminID = value; }
        }

        public int RequestTypeID
        {
            get { return requestTypeID; }
            set { requestTypeID = value; }
        }
    }
}