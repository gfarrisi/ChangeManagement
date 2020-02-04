using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChangeManagementSystem.RequestLibrary
{
    public class QuestionResponse
    {
        private int cmID;
        private int questionID;
        private string questionResponse;
        
        public QuestionResponse(int cmid, int questionid, string response)
        {
            cmID = cmid;
            questionID = questionid;
            questionResponse = response;
        }

        public int CMID
        {
            get { return cmID; }
            set { cmID = value; }
        }

        public int QuestionID
        {
            get { return questionID; }
            set { questionID = value; }
        }

        public string Response
        {
            get { return questionResponse; }
            set { questionResponse = value; }
        }
    }
}