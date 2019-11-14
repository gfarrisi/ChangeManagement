using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Empty_Project_Template.RequestLibrary
{
    public class RequestTypes
    {
 
        public List<Request> requestTypes = new List<Request>();

        public RequestTypes()
        {
            createWorkflow();
        }
        public void createWorkflow()
        {
            int workflowID = 1001;
            List<Question> questionList = new List<Question>();

            List<string> options = new List<string>();
            Question q1 = new Question("Workflow/Process","1","TextBox", options);
            Question q2 = new Question("Entity", "2", "TextBox", options);
            Question q3 = new Question("Description", "3", "TextBox", options);

            List<string> options4 = new List<string>();
            options4.Add("New");
            options4.Add("Revised");
            Question q4 = new Question("Is this New or Revised?", "4", "RadioButtonList", options4);

            List<string> options5 = new List<string>();
            options5.Add("Yes - Email Template");
            options5.Add("Yes - Email Within the Workflow");
            options5.Add("No");
            Question q5 = new Question("Does this workflow fire an email?", "5", "RadioButtonList", options5);

            List<string> options6 = new List<string>();
            options6.Add("Yes");
            options6.Add("No");
            Question q6 = new Question("If YES to the previous question, does the email include environment-specific links?", "6", "RadioButtonList", options6);

            List<string> options7 = new List<string>();
            options7.Add("Yes - No Changes to Workflow Schedule");
            options7.Add("Yes - New Workflow Schedule");
            options7.Add("Yes - Revised Workflow Schedule");
            options7.Add("No - Workflow is triggered");
            Question q7 = new Question("If YES to the previous question, does the email include environment-specific links?", "7", "RadioButtonList", options7);


            questionList.Add(q1);
            questionList.Add(q2);
            questionList.Add(q3);
            questionList.Add(q4);
            questionList.Add(q5);
            questionList.Add(q6);
            questionList.Add(q7);
            Request request = new Request(questionList, workflowID);

            requestTypes.Add(request);
        }

    }
}