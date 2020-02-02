using Empty_Project_Template.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Empty_Project_Template.RequestLibrary
{
    public class RequestTypeData
    {
        private int RequestTypeID;
        private int ScreenshotsID = 99;

        public RequestTypeData()
        {           
        }

        public Request GetRequestTypeData(int requestTypeID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            Request request;

            RequestTypeID = requestTypeID;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetRequestType";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@RequestTypeID", RequestTypeID);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable myDT = myDS.Tables[0];
            if (myDT.Rows.Count > 0)
            {
                string typeName = myDT.Rows[0]["RequestTypeName"].ToString();
                List<int> questionIDs = new List<int>();

                foreach (DataRow row in myDT.Rows)
                {
                    questionIDs.Add(Convert.ToInt32(row["QuestionID"].ToString()));
                }

                List<Question> questions = new List<Question>();

                foreach (int id in questionIDs)
                {
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "GetQuestion";
                    objCommand.Parameters.Clear();

                    objCommand.Parameters.AddWithValue("@QuestionID", id);

                    myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                    myDT = myDS.Tables[0];
                    if (myDT.Rows.Count > 0)
                    {
                        string questionText = myDT.Rows[0]["QuestionText"].ToString();
                        string questionControl = myDT.Rows[0]["QuestionControl"].ToString();
                        string questionOptionsString = myDT.Rows[0]["QuestionOptions"].ToString();
                        List<string> questionOptions = questionOptionsString.Split(',').ToList();
                        Question quest = new Question(questionText, questionControl, id, questionOptions);

                        questions.Add(quest);
                    }
                }
                request = new Request(questions, RequestTypeID, typeName);                             
            }
            else
            {
                request = null;
            }
            return request;
        }

        public Request GetScreenshotAndSubmission()
        {
            return GetRequestTypeData(ScreenshotsID);
        }
    }
}