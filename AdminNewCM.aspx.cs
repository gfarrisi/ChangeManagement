﻿using ChangeManagementSystem.RequestLibrary;
using ChangeManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChangeManagementSystem
{

    public partial class NewCM : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int RequestID = Convert.ToInt32(Session["SelectedRequestType"].ToString());

                RequestTypeData requestTypeData = new RequestTypeData();
                Request requestType = requestTypeData.GetRequestTypeData(RequestID);

                Label lblHeading = new Label();
                lblHeading.Text = requestType.RequestName;
                lblHeading.CssClass = "form-text h4";
                panelCM.Controls.Add(lblHeading);

                foreach (Question question in requestType.requestQuestions)
                {
                    string question_text = question.Question_Text;
                    string question_control = question.Question_Control;
                    int question_id = question.Question_ID;
                    List<string> question_options = question.Question_Options;


                    System.Web.UI.HtmlControls.HtmlGenericControl rowDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    rowDiv.ID = "rowDiv";
                    rowDiv.Attributes.Add("class", "row mt-3 mb-3");
                    panelCM.Controls.Add(rowDiv);


                    System.Web.UI.HtmlControls.HtmlGenericControl colDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    colDiv.ID = "colDiv";
                    colDiv.Attributes.Add("class", "col-lg-6");
                    rowDiv.Controls.Add(colDiv);


                    Label lblText = new Label();
                    lblText.Text = question_text;
                    lblText.CssClass = "form-text";
                    colDiv.Controls.Add(lblText);


                    System.Web.UI.HtmlControls.HtmlGenericControl col6Div = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    col6Div.ID = "col6Div";
                    col6Div.Attributes.Add("class", "col-lg-6");
                    rowDiv.Controls.Add(col6Div);

                    if (question_control == "RadioButton")
                    {
                        foreach (string option in question_options)
                        {
                            RadioButton rbOption = new RadioButton();
                            rbOption.Text = option;
                            rbOption.CssClass = "form-check";
                            col6Div.Controls.Add(rbOption);
                        }
                    }
                    else if (question_control == "TextBox")
                    {
                        TextBox txtAnswer = new TextBox();
                        txtAnswer.CssClass = "form-control";
                        col6Div.Controls.Add(txtAnswer);
                    }
                    else if (question_control == "DropDownList")
                    {
                        DropDownList ddlOptions = new DropDownList();
                        ddlOptions.CssClass = "dropdown form-control";

                        foreach (string option in question_options)
                        {
                            ddlOptions.Items.Add(option);
                            col6Div.Controls.Add(ddlOptions);
                        }
                    }

                }
                buildSubmission();
            }
        }
        
        public void buildSubmission()
        {
            RequestTypeData requestTypeData = new RequestTypeData();
            Request requestType = requestTypeData.GetScreenshotAndSubmission();

            Label lblHeading = new Label();
            lblHeading.Text = "Screenshots";
            lblHeading.CssClass = "form-text h4";
            panelCM.Controls.Add(lblHeading);

            foreach (Question question in requestType.requestQuestions)
            {
                string question_text = question.Question_Text;
                string question_control = question.Question_Control;
                int question_id = question.Question_ID;
                List<string> question_options = question.Question_Options;

                System.Web.UI.HtmlControls.HtmlGenericControl rowDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                rowDiv.ID = "rowDiv";
                rowDiv.Attributes.Add("class", "row mt-3 mb-3");
                panelCM.Controls.Add(rowDiv);


                System.Web.UI.HtmlControls.HtmlGenericControl colDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                colDiv.ID = "colDiv";
                colDiv.Attributes.Add("class", "col-lg-6");
                rowDiv.Controls.Add(colDiv);


                Label lblText = new Label();
                lblText.Text = question_text;
                lblText.CssClass = "form-text";
                colDiv.Controls.Add(lblText);


                System.Web.UI.HtmlControls.HtmlGenericControl col6Div = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                col6Div.ID = "col6Div";
                col6Div.Attributes.Add("class", "col-lg-6");
                rowDiv.Controls.Add(col6Div);

                if (question_control == "RadioButton")
                {
                    foreach (string option in question_options)
                    {
                        RadioButton rbOption = new RadioButton();
                        rbOption.Text = option;
                        rbOption.CssClass = "form-check";
                        col6Div.Controls.Add(rbOption);
                    }
                }
                else if (question_control == "TextBox")
                {
                    TextBox txtAnswer = new TextBox();
                    txtAnswer.CssClass = "form-control";
                    col6Div.Controls.Add(txtAnswer);
                }
                else if (question_control == "FileUpload")
                {
                    FileUpload fuScreenshots = new FileUpload();
                    fuScreenshots.CssClass = "form-control-file";
                    fuScreenshots.AllowMultiple = true;
                    col6Div.Controls.Add(fuScreenshots);
                }
                else if (question_control == "Calendar")
                {
                    //   Calendar calendar = new Calendar();
                    ////   calendar.CssClass = "input-group date";
                    TextBox calendar = new TextBox();
                    calendar.CssClass = "form-control";
                    calendar.TextMode = TextBoxMode.Date;
                    col6Div.Controls.Add(calendar);
                }
                else if (question_control == "DropDownList")
                {
                    DropDownList ddlOptions = new DropDownList();
                    ddlOptions.CssClass = "dropdown";

                    foreach (string option in question_options)
                    {
                        ddlOptions.Items.Add(option);
                        col6Div.Controls.Add(ddlOptions);
                    }
                }

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}