using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChangeManagementSystem.Utilities;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChangeManagementSystem.Secure
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Variables
            string employeeNumber = string.Empty, eduPersonPrincipalName = string.Empty, mail = string.Empty, affiliation = string.Empty;

            /* Check if the application is running demo mode */
            //if (ConfigurationManager.AppSettings["demo_mode"].ToLower().Equals("false"))
            //{
            /* Check if the application is running locally for development
             * Retrieve request header information
             */
            if (HttpContext.Current.Request.IsLocal.Equals(true))
            {
                /*The SSO Sign-on page will not appear while running locally. This is only used for development.*/

                //employeeNumber = "915368285"; //use to test user account locally

                employeeNumber = "915351047"; //use to test admin account locally


            }
            else
            {
                /*Application is running on server and the user has active Shibboleth session.*/
                employeeNumber = GetShibbolethHeaderAttributes();
            }

            /*Use employee number to get user information from web services and then redirect*/
            GetUserInformation(employeeNumber);
            //}

        }


        /// <summary>
        /// Retrieve user information from Shibboleth headers
        /// </summary>
        /// <returns>User's TUid</returns>
        protected string GetShibbolethHeaderAttributes()
        {
            string employeeNumber = Request.Headers["employeeNumber"]; //Use this to retrieve the user's information via the web services  
            Session["SSO_Attribute_mail"] = Request.Headers["mail"];
            Session["SSO_Attribute_affiliation"] = Request.Headers["affiliation"];
            Session["SSO_Attribute_eduPersonPrincipalName"] = Request.Headers["eduPersonPrincipalName"];
            Session["SSO_Attribute_Unscoped_Affiliation"] = Request.Headers["unscopedaffiliation"];
            Session["SSO_Attribute_employeeNumber"] = employeeNumber;

            return employeeNumber;
        }




        /// <summary>
        /// Use employeeNumber (TUid) to retrieve information about the user
        /// from the web services.
        /// </summary>
        /// <param name="employeeNumber">TUid</param>
        protected void GetUserInformation(string employeeNumber)
        {
            if (!string.IsNullOrWhiteSpace(employeeNumber))
            {
                /*Security Session Variable*/
                Session["Authenticated"] = true;

                /* Requesting user's LDAP information via Web Service */
                WebService.LDAPuser Temple_Information = WebService.Webservice.getLDAPEntryByTUID(employeeNumber);

                /* Checking we received something from Web Services*/
                if (Temple_Information != null)
                {
                    /*Populating the Session Object with the user's information*/
                    Session["TU_ID"] = Temple_Information.templeEduID;
                    Session["First_Name"] = Temple_Information.givenName;
                    Session["Last_Name"] = Temple_Information.sn;
                    Session["Email"] = Temple_Information.mail;
                    Session["Title"] = Temple_Information.title;
                    Session["Affiliation_Primary"] = Temple_Information.eduPersonPrimaryAffiliation;
                    Session["Affiliation_Secondary"] = Temple_Information.eduPersonAffiliation;
                    Session["Full_Name"] = Temple_Information.cn;

                    /* If the user is a student, we can request academic information via the Web Service */
                    WebService.StudentObj Student_Information = WebService.Webservice.getStudentInfo(Temple_Information.templeEduID);

                    /* Checking we received something from Web Service and then adding information to the Session Object*/
                    if (Student_Information != null)
                    {
                        Session["School"] = Student_Information.school;
                        Session["Major_1"] = Student_Information.major1;
                        Session["Major_2"] = Student_Information.major2;
                    }
                }

                /*Successful Login - Allowed to be redirected to Home.aspx*/
                Response.Redirect("Home.aspx");
            }
            else
            {
                //Error: Couldn't retrieve employeeNumber from request header
                Server.Transfer("500http.aspx");
            }
        }

        /// <summary>
        /// Spoof user to look like my information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEmployeeTestAcct_Click(object sender, EventArgs e)
        {
            try
            {
                GetUserInformation("915368285");
            }
            catch (Exception)
            {
                Server.Transfer("500http.aspx");
            }
        }

        /// <summary>
        /// Spoof test account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnStudentTestAcct_Click(object sender, EventArgs e)
        {
            try
            {
                GetUserInformation("915368285");
            }
            catch (Exception)
            {
                Server.Transfer("500http.aspx");
            }
        }


        /// <summary>
        /// Use shibboleth if application is running demo_mode, but also not running locally.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnShibb_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.Headers["employeeNumber"] != null)
                {
                    GetUserInformation(Request.Headers["employeeNumber"]);
                }
                else
                {
                    divError.Visible = true;
                    lblError.Text = (HttpContext.Current.Request.IsLocal.Equals(true)) ? "<strong>Error:</strong> Shibboleth cannot be used if application is running locally." : "<strong>Error:</strong> Profile could not be loaded!";
                }
            }
            catch (Exception)
            {
                Server.Transfer("500http.aspx");
            }
        }



    }
}