using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersTestProject.AuthData
{
    [AttributeUsage (AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizationAttribute : AuthorizeAttribute/*, IAuthorizationFilter*/
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //string hairColour = ((CustomPrincipal)httpContext.User).hairColour;
            return base.AuthorizeCore(httpContext);
        }
    }
}