using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ACSAdminWeb.Models
{
    public class ACSSecurityServices
    {
        internal static void CheckPasswordParameter(string param, string paramName)
        {
            if (param == null)
                throw new ArgumentNullException(paramName);
            CheckForEmptyParameter(param, paramName);
        }

        internal static void CheckForEmptyOrWhiteSpaceParameter(ref string param, string paramName)
        {
            if (param == null)
                return;
            param = param.Trim();
            CheckForEmptyParameter(param, paramName);
        }

        internal static void CheckForEmptyParameter(string param, string paramName)
        {
            if (param.Length >= 1)
                return;
            throw new ArgumentException(string.Format((IFormatProvider)CultureInfo.CurrentCulture, "Parameter_can_not_be_empty", new object[1]
            {
                (object) paramName
            }), paramName);
        }
    }
}