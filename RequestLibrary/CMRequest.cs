using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChangeManagementSystem.RequestLibrary
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
        private string projectName;
        private string detailDesc;
        private string filename1;
        private string filename2;
        private string filename3;
        private string filename4;
        private string filename5;

        public CMRequest(string status, string desc, string pName, byte[] att1, byte[] att2, byte[] att3, byte[] att4, byte[] att5, string questComm, string lastUser,
            DateTime lastDate, string user, string admin, int typeID, DateTime desireddate, List<QuestionResponse> responses,
            string file1, string file2, string file3, string file4, string file5)
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
            projectName = pName;
            detailDesc = desc;
            filename1 = file1;
            filename2 = file2;
            filename3 = file3;
            filename4 = file4;
            filename5 = file5;
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
        public byte[] att1
        {
            get { return attachment1; }
            set { attachment1 = value; }
        }
        public byte[] att2
        {
            get { return attachment2; }
            set { attachment2 = value; }
        }
        public byte[] att3
        {
            get { return attachment3; }
            set { attachment3 = value; }
        }
        public byte[] att4
        {
            get { return attachment4; }
            set { attachment4 = value; }
        }
        public byte[] att5
        {
            get { return attachment5; }
            set { attachment5 = value; }
        }
        public string questCom
        {
            get { return questionsComments; }
            set { questionsComments = value; }
        }
        public string projName
        {
            get { return projectName; }
            set { projectName = value; }
        }
        public string detailDescription
        {
            get { return detailDesc; }
            set { detailDesc = value; }
        }
        public string File1
        {
            get { return filename1; }
            set { filename1 = value; }
        }
        public string File2
        {
            get { return filename2; }
            set { filename2 = value; }
        }
        public string File3
        {
            get { return filename3; }
            set { filename3 = value; }
        }
        public string File4
        {
            get { return filename4; }
            set { filename4 = value; }
        }
        public string File5
        {
            get { return filename5; }
            set { filename5 = value; }
        }
    }
}