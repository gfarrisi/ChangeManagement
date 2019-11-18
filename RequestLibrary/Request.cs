using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Empty_Project_Template.RequestLibrary
{
    public class Request
    {
        public List<Question> requestQuestions = new List<Question>();
        private int requestID { get; set; }
        private string requestName { get; set; }
        public Request(List<Question> questions, int id, string name)
        {
            requestID = id;
            requestName = name;
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

        public string RequestName
        {
            get { return requestName; }
            set { requestName = value; }
        }
    }
}