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
            createWorkflowSchedule();
            createEntity();
            createField();
            createOptionSet();
            createRelationships();
            createSystemViews();
            createBusinessRules();
            createSecurityRoles();
            createActivityCodes();
            createForms();
            createJavaScriptOnWFE();

            createNewUserModifyUser();
            createEmailTemplates();
            createWebResources();
            createOther();


            ScreenshotsAndSubmission();

        }

        public void ScreenshotsAndSubmission()
        {
            List<string> options = new List<string>(); // Default for TextBox controls that don't require options

            int ScreenshotAndSubmissionID = 9999;
            List<Question> questionListScreenshotAndSubmission = new List<Question>();

            Question q1Screenshot = new Question("Detailed Description of Change", "1", "TextBox", options);
            Question q2Screenshot = new Question("Please upload all applicable screenshots with all changes NOTED (circled or with arrows pointing to the change) on all screenshots.", "2", "FileUpload", options);
            Question q3Screenshot = new Question("Desired Date for Move", "3", "Calendar", options);
            Question q4Screenshot = new Question("Questions/Comments", "4", "TextBox", options);

            questionListScreenshotAndSubmission.Add(q1Screenshot);
            questionListScreenshotAndSubmission.Add(q2Screenshot);
            questionListScreenshotAndSubmission.Add(q3Screenshot);
            questionListScreenshotAndSubmission.Add(q4Screenshot);

            Request screenshotAndSubmission = new Request(questionListScreenshotAndSubmission, ScreenshotAndSubmissionID, "Screenshots");
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

            Request requestWorkflow = new Request(questionListWorkflow, workflowID, "Workflow");
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

            Request requestEntity = new Request(questionListEntity, entityID, "Entity");
            requestTypes.Add(requestEntity);        
        }

        public void createWorkflowSchedule()
        {
            int workflowScheduleID = 1015;
            List<Question> questionListWorkflowSchedule = new List<Question>();
            List<string> options = new List<string>();

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

            Request requestWorkflowSchedule = new Request(questionListWorkflowSchedule, workflowScheduleID, "Workflow Schedule");
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

            Request requestField = new Request(questionListField, fieldID, "Field");
            requestTypes.Add(requestField);
        }

        public void createSecurityRoles()
        {
            List<string> options = new List<string>(); // Default for TextBox controls that don't require options

            int securityRolesID = 1010;
            List<Question> questionListSecurityRoles = new List<Question>();

            Question q1SecurityRoles = new Question("Security Role Name", "1", "TextBox", options);

            List<String> options2SecurityRoles = new List<string>();
            options2SecurityRoles.Add("NEW");
            options2SecurityRoles.Add("REVISED - Please attach screenshots for each tab with changes; please highlight the changes.");
            Question q2SecurityRoles = new Question("NEW or REVISED?", "2", "RadioButtonList", options2SecurityRoles);

            questionListSecurityRoles.Add(q1SecurityRoles);
            questionListSecurityRoles.Add(q2SecurityRoles);

            Request requestSecurityRoles = new Request(questionListSecurityRoles, securityRolesID, "Security Roles");
            requestTypes.Add(requestSecurityRoles);
        }

        public void createBusinessRules()
        {
            List<string> options = new List<string>(); // Default for TextBox controls that don't require options

            int businessRulesID = 1002;
            List<Question> questionListBusinessRules = new List<Question>();

            Question q1BusinessRules = new Question("Entity", "1", "TextBox", options);
            Question q2BusinessRules = new Question("Business Rule Name", "2", "TextBox", options);
            Question q3BusinessRules = new Question("Description", "3", "TextBox", options);

            questionListBusinessRules.Add(q1BusinessRules);
            questionListBusinessRules.Add(q2BusinessRules);
            questionListBusinessRules.Add(q3BusinessRules);

            Request requestBusinessRules = new Request(questionListBusinessRules, businessRulesID, "Business Roles");
            requestTypes.Add(requestBusinessRules);

        }
        public void createOptionSet()
        {
            int fieldID = 1008;
            List<Question> questionListField = new List<Question>();
            List<string> options = new List<string>();

            List<String> options1OptionSet = new List<string>();
            options1OptionSet.Add("Simple");
            options1OptionSet.Add("Calculated");
            Question q1OptionSet = new Question("Field Type", "1", "DropDownList", options1OptionSet);

            Question q2OptionSet = new Question("Default", "2", "TextBox", options);

            List<String> options3OptionSet = new List<string>();
            options3OptionSet.Add("YES");
            options3OptionSet.Add("NO (New Option Set)");
            Question q3OptionSet = new Question("Use Existing Option Set?", "3", "RadioButtonList", options3OptionSet);

            questionListField.Add(q1OptionSet);
            questionListField.Add(q2OptionSet);
            questionListField.Add(q3OptionSet);

            Request requestField = new Request(questionListField, fieldID, "Option Set");
            requestTypes.Add(requestField);
        }
        public void createRelationships()
        {
            int fieldID = 1009;
            List<Question> questionListField = new List<Question>();
            List<string> options = new List<string>();

            List<String> options1Relationships = new List<string>();
            options1Relationships.Add("1:N Relationship");
            options1Relationships.Add("N:1 Relationship");
            options1Relationships.Add("N:N Relationship");
            Question q1Relationships = new Question("Type of Relationship?", "1", "RadioButtonList", options1Relationships);

            Question q2Relationships = new Question("Entity", "2", "TextBox", options);
            Question q3Relationships = new Question("Related Entity", "3", "TextBox", options);
            Question q4Relationships = new Question("Name", "4", "TextBox", options);
            Question q5Relationships = new Question("Dispaly Name", "5", "TextBox", options);
            Question q6Relationships = new Question("Description", "6", "TextBox", options);

            List<String> options7Relationships = new List<string>();
            options7Relationships.Add("Parental");
            options7Relationships.Add("Referential");
            options7Relationships.Add("Referential, Restrict Delete");
            options7Relationships.Add("Configurable Cascading");
            Question q7Relationships = new Question("Type of Behavior", "7", "DropDownList", options7Relationships);
            
            Question q8Relationships = new Question("Other", "8", "TextBox", options);
            
            questionListField.Add(q1Relationships);
            questionListField.Add(q2Relationships);
            questionListField.Add(q3Relationships);
            questionListField.Add(q4Relationships);
            questionListField.Add(q5Relationships);
            questionListField.Add(q6Relationships);
            questionListField.Add(q7Relationships);
            questionListField.Add(q8Relationships);

            Request requestField = new Request(questionListField, fieldID, "Relationships");
            requestTypes.Add(requestField);
        }
        public void createSystemViews()
        {
            int fieldID = 1011;
            List<Question> questionListField = new List<Question>();
            List<string> options = new List<string>();

            Question q1SystemViews = new Question("Entity", "1", "TextBox", options);
            Question q2SystemViews = new Question("Entity", "1", "TextBox", options);

            questionListField.Add(q1SystemViews);
            questionListField.Add(q2SystemViews);

            Request requestField = new Request(questionListField, fieldID, "System Views");
            requestTypes.Add(requestField);
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

            Request requestWorkflow = new Request(questionListActivityCodes, workflowID, "Activity Codes");
            requestTypes.Add(requestWorkflow);

        }

        public void createForms()
        {
            List<string> options = new List<string>(); // Default for TextBox controls that don't require options

            int requestID = 1006;
            List<Question> questionList = new List<Question>();

            Question q1 = new Question("Entity", "1", "TextBox", options);
            Question q2 = new Question("Form Name", "2", "TextBox", options);
            Question q3 = new Question("Form Enable Security Roles (If applicable)", "3", "TextBox", options);
            List<String> options4 = new List<string>();
            options4.Add("Yes");
            options4.Add("No");
            Question q4 = new Question("Did you add new fields?", "4", "RadioList", options4);

            questionList.Add(q1);
            questionList.Add(q2);
            questionList.Add(q3);
            questionList.Add(q4);

            //if you answered Yes to number 4
            //createField();



            Request request = new Request(questionList, requestID, "Forms");
            requestTypes.Add(request);
           
        }
        public void createJavaScriptOnWFE()
        {
            List<string> options = new List<string>(); // Default for TextBox controls that don't require options

            int requestID = 1007;
            List<Question> questionList = new List<Question>();

            Question q1 = new Question("Application", "1", "TextBox", options);
            Question q2 = new Question("Page Name", "2", "TextBox", options);
            Question q3 = new Question("Field Scheme Name", "3", "TextBox", options);
            Question q4 = new Question("Field Label", "4", "TextBox", options);
            Question q5 = new Question("FDetailed Change Description", "5", "TextBox", options);
           
            questionList.Add(q1);
            questionList.Add(q2);
            questionList.Add(q3);
            questionList.Add(q4);
            questionList.Add(q5);

            Request request = new Request(questionList, requestID, "Java Script on WFE");
            requestTypes.Add(request);

        }
        public void createEmailTemplates()
        {
            List<string> options = new List<string>(); // Default for TextBox controls that don't require options
            int emailtemplatesID = 1017;

            List<Question> questionListEmailTemplates = new List<Question>();

            Question q1EmailTemplates = new Question("Template", "1", "TextBox", options);
            Question q2EmailTemplates = new Question("Template", "2", "TextBox", options);
            Question q3EmailTemplates = new Question("If used in a workflow, please list workflow name.", "3", "TextBox", options);
            Question q4EmailTemplates = new Question("Description", "4", "TextBox", options);

            List<String> options5EmailTemplates = new List<string>();
            options5EmailTemplates.Add("Yes");
            options5EmailTemplates.Add("No");
            Question q5EmailTemplates = new Question("Do you need to add a new Activity Code related to this template?", "5", "RadioButtonList", options5EmailTemplates);

            questionListEmailTemplates.Add(q1EmailTemplates);
            questionListEmailTemplates.Add(q2EmailTemplates);
            questionListEmailTemplates.Add(q3EmailTemplates);
            questionListEmailTemplates.Add(q4EmailTemplates);
            questionListEmailTemplates.Add(q5EmailTemplates);

            Request requestEmailtemplates = new Request(questionListEmailTemplates, emailtemplatesID, "Email Templates");
            requestTypes.Add(requestEmailtemplates);

        }

        public void createNewUserModifyUser()
        {
            List<string> options = new List<string>(); // Default for TextBox controls that don't require options
            int newUserModifyUserID = 1012;

            List<Question> questionListNewUserModifyUser = new List<Question>();

            Question q1NewUserModifyUser = new Question("To add a new user or modify an existing user, please submit a TU Remedy/TU Help Ticket at TUhelp.temple.edu", "1", "TextBox", options);

            questionListNewUserModifyUser.Add(q1NewUserModifyUser);

            Request requestNewUserModifyUser = new Request(questionListNewUserModifyUser, newUserModifyUserID, "New User/Modify User");
            requestTypes.Add(requestNewUserModifyUser);
        }

        public void createWebResources()
        {
            List<string> options = new List<string>(); // Default for TextBox controls that don't require options
            int webResourcesID = 1013;

            List<Question> questionListWebResources = new List<Question>();

            Question q1WebResources = new Question("Key", "1", "TextBox", options);
            Question q2WebResources = new Question("Value", "2", "TextBox", options);
            Question q3WebResources = new Question("Description", "3", "TextBox", options);

            List<String> options4WebResources = new List<string>();
            options4WebResources.Add("1");
            options4WebResources.Add("2");
            options4WebResources.Add("3");
            options4WebResources.Add("4");
            options4WebResources.Add("5");
            options4WebResources.Add("6");
            options4WebResources.Add("7");
            options4WebResources.Add("8");
            options4WebResources.Add("9");
            options4WebResources.Add("10");
            Question q4WebResources = new Question("Site ID", "4", "DropDownList", options4WebResources);

            questionListWebResources.Add(q1WebResources);
            questionListWebResources.Add(q2WebResources);
            questionListWebResources.Add(q3WebResources);
            questionListWebResources.Add(q4WebResources);

            Request requestWebResources = new Request(questionListWebResources, webResourcesID, "Web Resources");
            requestTypes.Add(requestWebResources);
        }

        public void createOther()
        {
            List<string> options = new List<string>(); // Default for TextBox controls that don't require options
            int otherID = 1016;

            List<Question> questionListOther = new List<Question>();

            Question q1Other = new Question("Description", "1", "TextBox", options);

            questionListOther.Add(q1Other);

            Request requestOther = new Request(questionListOther, otherID, "Other");
            requestTypes.Add(requestOther);
        }

    }
}