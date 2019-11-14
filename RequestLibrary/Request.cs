using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Empty_Project_Template.RequestLibrary
{
    public class Request
    {
        public List<Question> requestQuestions = new List<Question>();
        private int requestID;
        public Request(List<Question> questions, int id)
        {
            requestID = id;
            foreach(Question question in questions)
            {
                requestQuestions.Add(question);
            }
            
        }

        public int RequestID
        {
            get { return requestID; }
            set { requestID = value; }
        }
    }
}