using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolMISDayLog.Helper
{
    public static class Extension
    {
        public static string GetModelStateErrors(this ModelStateDictionary modelState)
        {
            var result = string.Empty;
            foreach (ModelState modelStateValue in modelState.Values)
            {
                foreach (ModelError error in modelStateValue.Errors)
                {
                    result += error.ErrorMessage;
                }
            }
            return result;
        }
    }
}