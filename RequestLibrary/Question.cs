using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Empty_Project_Template.RequestLibrary
{
    public class Question
    {
        private string question_text { get; set; }
        private string question_order { get; set; }
        private string question_control { get; set; }
        private List<string> question_options { get; set; }

        public Question(string text, string order, string control, List<string> options)
        {
            question_text = text;
            question_control = control;
            question_control = control;
            question_options = options;
        }

        public string Question_Text
        {
            get { return question_text; }
            set { question_text = value; }
        }

        public string Question_Order
        {
            get { return question_order; }
            set { question_order = value; }
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
