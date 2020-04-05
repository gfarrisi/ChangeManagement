using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChangeManagementSystem.RequestLibrary
{
    public class Question
    {
        private string question_text { get; set; }
        private string question_control { get; set; }
        private int question_id { get; set; }
        private List<string> question_options { get; set; }

        public Question()
        {

        }
        public Question(string text, string control, int id, List<string> options)
        {
            question_text = text;
            question_control = control;
            question_id = id;
            question_options = options;
        }

        public string Question_Text
        {
            get { return question_text; }
            set { question_text = value; }
        }

        public int Question_ID
        {
            get { return question_id; }
            set { question_id = value; }
        }
        public string Question_Control
        {
            get { return question_control; }
            set { question_control = value; }
        }
        public List<string> Question_Options
        {
            get { return question_options; }
            set { question_options = value; }
        }
    }

}
