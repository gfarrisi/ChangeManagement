using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ChangeManagementSystem.Utilities
{
    public static class Validation
    {
        public static Boolean ValidateForm(string input)
        {
            bool valid = false;

            if (!(String.IsNullOrEmpty(input) || String.IsNullOrWhiteSpace(input)))
            {
                valid = true;
            }

            return valid;
        }
      

        public static Boolean ValidateBottomForm(string desiredDesc, string desiredDate, string quesCom, string CMProjName)
        {
            bool valid = false;

            if (!(String.IsNullOrEmpty(desiredDesc) || String.IsNullOrWhiteSpace(desiredDesc) || String.IsNullOrEmpty(quesCom) || String.IsNullOrWhiteSpace(quesCom)
                || String.IsNullOrWhiteSpace(CMProjName) || String.IsNullOrEmpty(CMProjName) || String.IsNullOrEmpty(desiredDate) || String.IsNullOrWhiteSpace(desiredDate)))
            {
                valid = true;
            }

            return valid;
        }

        public static Boolean ValidateNewUser(string TUID, string firstName, string lastName, string userEmail)
        {
            bool valid = false;

            if (!(String.IsNullOrEmpty(TUID) || String.IsNullOrWhiteSpace(TUID) || String.IsNullOrEmpty(firstName) || String.IsNullOrWhiteSpace(firstName)
                || String.IsNullOrWhiteSpace(lastName) || String.IsNullOrEmpty(lastName) || String.IsNullOrEmpty(userEmail) || String.IsNullOrWhiteSpace(userEmail)))
            {
                valid = true;
            }

            return valid;
        }

        //Validates for a valid phone number 
        public static bool ValidatePhoneNumber(string PhoneNumber)
        {
            Regex regexPhoneNumber = new Regex(@"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$");
            return (regexPhoneNumber.IsMatch(PhoneNumber));
        }

        //Validate for a non-negative number
        public static bool ValidateNonNegativeNumber(string nonNegativeNumber)
        {
            Regex NonNegativeNumber = new Regex(@"^\d+$");
            return (NonNegativeNumber.IsMatch(nonNegativeNumber));
        }

        //Validate date
        public static bool ValidateDate(string date)
        {
            DateTime res;
            return (DateTime.TryParse(date, out res));
        }

        //Validate for a temple email address.  This also checks for the Temple Hospital emails
        public static bool ValidateTempleEmail(string Email)
        {
            Regex regexTempleEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return ((regexTempleEmail.IsMatch(Email)) && (Email.EndsWith("@temple.edu") || Email.EndsWith("@tuhs.temple.edu")));
        }

        // Validate that it is a potentially vialid email address
        public static bool ValidateAnyEmail(string Email)
        {
            Regex regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return (regexEmail.IsMatch(Email));
        }

        //Validate a 9 didgit TUid
        public static bool ValidateTUID(string TUID)
        {
            Regex regexTUID = new Regex(@"^\d{9}$");
            return (regexTUID.IsMatch(TUID));
        }
    }
}