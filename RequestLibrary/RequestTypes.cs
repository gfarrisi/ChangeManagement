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
            createEntity();
            createField();
            createActivityCodes();
            ScreenshotsAndSubmission();

        }

        public void ScreenshotsAndSubmission()
        {
            List<string> options = new List<string>(); // Default for TextBox controls that don't require options

            int ScreenshotAndSubmissionID = 9999;
            List<Question> questionListScreenshotAndSubmission = new List<Question>();

            Question q1Screenshot = new Question("Detailed Description of Change", "1", "TextBox", options);
            Question q2Screenshot = new Question("Please upload all applicable screenshots with all changes NOTED (circled or with arrows pointing to the change) on all screenshots.", "2", "TextBox", options);
            Question q3Screenshot = new Question("Desired Date for Move", "3", "TextBox", options);
            Question q4Screenshot = new Question("Questions/Comments", "4", "TextBox", options);

            questionListScreenshotAndSubmission.Add(q1Screenshot);
            questionListScreenshotAndSubmission.Add(q2Screenshot);
            questionListScreenshotAndSubmission.Add(q3Screenshot);
            questionListScreenshotAndSubmission.Add(q4Screenshot);

            Request screenshotAndSubmission = new Request(questionListScreenshotAndSubmission, ScreenshotAndSubmissionID);
            requestTypes.Add(screenshotAndSubmission);
        }
        public void createWorkflow()
        {
            List<string> options = new List<string>(); // Default for TextBox controls that don't require options

            int workflowID = 1014;
            List<Question> questionListWorkflow = new List<Question>();

            Question q1Workflow = new Question("Workflow/Process", "1", "TextBox", options);
            Question q2Workflow = new Question("Entity", "2", "TextBox", options);
            Question q3Workflow = new Question("Description", "3", "TextBox", options);

            List<string> options4Workflow = new List<string>();
            options4Workflow.Add("New");
            options4Workflow.Add("Revised");
            Question q4Workflow = new Question("Is this New or Revised?", "4", "RadioButtonList", options4Workflow);

            List<string> options5Workflow = new List<string>();
            options5Workflow.Add("Yes - Email Template");
            options5Workflow.Add("Yes - Email Within the Workflow");
            options5Workflow.Add("No");
            Question q5Workflow = new Question("Does this workflow fire an email?", "5", "RadioButtonList", options5Workflow);

            List<string> options6Workflow = new List<string>();
            options6Workflow.Add("Yes");
            options6Workflow.Add("No");
            Question q6Workflow = new Question("If YES to the previous question, does the email include environment-specific links?", "6", "RadioButtonList", options6Workflow);

            List<string> options7Workflow = new List<string>();
            options7Workflow.Add("Yes - No Changes to Workflow Schedule");
            options7Workflow.Add("Yes - New Workflow Schedule");
            options7Workflow.Add("Yes - Revised Workflow Schedule");
            options7Workflow.Add("No - Workflow is triggered");
            Question q7Workflow = new Question("If YES to the previous question, does the email include environment-specific links?", "7", "RadioButtonList", options7Workflow);


            questionListWorkflow.Add(q1Workflow);
            questionListWorkflow.Add(q2Workflow);
            questionListWorkflow.Add(q3Workflow);
            questionListWorkflow.Add(q4Workflow);
            questionListWorkflow.Add(q5Workflow);
            questionListWorkflow.Add(q6Workflow);
            questionListWorkflow.Add(q7Workflow);

            Request requestWorkflow = new Request(questionListWorkflow, workflowID);
            requestTypes.Add(requestWorkflow);

           
        }
        public void createEntity()
        {

            int entityID = 1004;
            List<Question> questionListEntity = new List<Question>();
            List<string> options = new List<string>();

            Question q1Entity = new Question("Display Name", "1", "TextBox", options);
            Question q2Entity = new Question("Plural Name", "2", "TextBox", options);
            Question q3Entity = new Question("Name", "3", "TextBox", options);
            Question q4Entity = new Question("Description", "4", "TextBox", options);

            List<String> options5Entity = new List<string>();
            options5Entity.Add("Yes");
            options5Entity.Add("No");
            Question q5Entity = new Question("Enable Auditing", "5", "RadioButtonList", options5Entity);

            Question q6Entity = new Question("Other Details not listed above", "6", "TextBox", options);

            questionListEntity.Add(q1Entity);
            questionListEntity.Add(q2Entity);
            questionListEntity.Add(q3Entity);
            questionListEntity.Add(q4Entity);
            questionListEntity.Add(q5Entity);
            questionListEntity.Add(q6Entity);

            Request requestEntity = new Request(questionListEntity, entityID);
            requestTypes.Add(requestEntity);


            int workflowScheduleID = 1015;
            List<Question> questionListWorkflowSchedule = new List<Question>();

            Question q1WorkflowSchedule = new Question("Workflow Name", "1", "TextBox", options);
            Question q2WorkflowSchedule = new Question("Entity", "2", "TextBox", options);
            Question q3WorkflowSchedule = new Question("Workflow", "3", "TextBox", options);

            List<String> options4WorkflowSchedule = new List<string>();
            options4WorkflowSchedule.Add("YES");
            options4WorkflowSchedule.Add("NO");
            Question q4WorkflowSchedule = new Question("Has the Workflow View been created and shared in new environment?", "4", "RadioButtonList", options4WorkflowSchedule);

            Question q5WorkflowSchedule = new Question("Start Date", "5", "TextBox", options);

            List<String> options6WorkflowSchedule = new List<string>();
            options6WorkflowSchedule.Add("Every X hours?");
            options6WorkflowSchedule.Add("Every X days?");
            options6WorkflowSchedule.Add("Every X weeks?");
            Question q6WorkflowSchedule = new Question("Frequency", "6", "RadioButtonList", options6WorkflowSchedule);

            questionListWorkflowSchedule.Add(q1WorkflowSchedule);
            questionListWorkflowSchedule.Add(q2WorkflowSchedule);
            questionListWorkflowSchedule.Add(q3WorkflowSchedule);
            questionListWorkflowSchedule.Add(q4WorkflowSchedule);
            questionListWorkflowSchedule.Add(q5WorkflowSchedule);
            questionListWorkflowSchedule.Add(q6WorkflowSchedule);

            Request requestWorkflowSchedule = new Request(questionListWorkflowSchedule, workflowScheduleID);
            requestTypes.Add(requestWorkflowSchedule);

        }
        public void createField()
        {
            int fieldID = 1005;
            List<Question> questionListField = new List<Question>();
            List<string> options = new List<string>();

            Question q1Field = new Question("Display Name", "1", "TextBox", options);
            Question q2Field = new Question("Scheme Name", "2", "TextBox", options);
            Question q3Field = new Question("Entity", "3", "TextBox", options);
            Question q4Field = new Question("Description", "4", "TextBox", options);

            List<String> options5Field = new List<string>();
            options5Field.Add("NEW");
            options5Field.Add("REVISED");
            Question q5Field = new Question("Is this a NEW field or a REVISED field?", "5", "RadioButtonList", options5Field);

            List<String> options6Field = new List<string>();
            options6Field.Add("Single Line of Text");
            options6Field.Add("Option Set");
            options6Field.Add("Two Options");
            options6Field.Add("Image");
            options6Field.Add("Whole Number");
            options6Field.Add("Floating Point Number");
            options6Field.Add("Decimal Number");
            options6Field.Add("Currency");
            options6Field.Add("Multiple Lines of Text");
            options6Field.Add("Date and Time");
            options6Field.Add("Lookup");
            Question q6Field = new Question("Data Type", "6", "DropDownList", options6Field);

            questionListField.Add(q1Field);
            questionListField.Add(q2Field);
            questionListField.Add(q3Field);
            questionListField.Add(q4Field);
            questionListField.Add(q5Field);
            questionListField.Add(q6Field);

            Request requestField = new Request(questionListField, fieldID);
            requestTypes.Add(requestField);

            int securityRolesID = 1010;
            List<Question> questionListSecurityRoles = new List<Question>();

            Question q1SecurityRoles = new Question("Security Role Name", "1", "TextBox", options);

            List<String> options2SecurityRoles = new List<string>();
            options2SecurityRoles.Add("NEW");
            options2SecurityRoles.Add("REVISED - Please attach screenshots for each tab with changes; please highlight the changes.");
            Question q2SecurityRoles = new Question("NEW or REVISED?", "2", "RadioButtonList", options2SecurityRoles);

            questionListSecurityRoles.Add(q1SecurityRoles);
            questionListSecurityRoles.Add(q2SecurityRoles);

            Request requestSecurityRoles = new Request(questionListSecurityRoles, securityRolesID);
            requestTypes.Add(requestSecurityRoles);

            int businessRulesID = 1002;
            List<Question> questionListBusinessRules = new List<Question>();

            Question q1BusinessRules = new Question("Entity", "1", "TextBox", options);
            Question q2BusinessRules = new Question("Business Rule Name", "2", "TextBox", options);
            Question q3BusinessRules = new Question("Description", "3", "TextBox", options);

            questionListBusinessRules.Add(q1BusinessRules);
            questionListBusinessRules.Add(q2BusinessRules);
            questionListBusinessRules.Add(q3BusinessRules);

            Request requestBusinessRules = new Request(questionListBusinessRules, businessRulesID);
            requestTypes.Add(requestBusinessRules);

        }

        public void createActivityCodes()
        {
            List<string> options = new List<string>(); // Default for TextBox controls that don't require options

            int workflowID = 1001;
            List<Question> questionListActivityCodes = new List<Question>();

            Question q1Workflow = new Question("Name", "1", "TextBox", options);
            Question q2Workflow = new Question("Abbreviation", "2", "TextBox", options);
            Question q3Workflow = new Question("Banner ADMR Code (N/A if not needed)", "3", "TextBox", options);  
            Question q4Workflow = new Question("Display Order", "4", "TextBox", options);

            questionListActivityCodes.Add(q1Workflow);
            questionListActivityCodes.Add(q2Workflow);
            questionListActivityCodes.Add(q3Workflow);
            questionListActivityCodes.Add(q4Workflow);

            Request requestWorkflow = new Request(questionListActivityCodes, workflowID);
            requestTypes.Add(requestWorkflow);

        }

    }
}