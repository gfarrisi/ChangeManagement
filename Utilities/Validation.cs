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
    }
}