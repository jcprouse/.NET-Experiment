using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace FiltersTestProject.AuthData
{
    public class CustomAuthenticationAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            filterContext.Principal = new CustomPrincipal(filterContext.HttpContext.User.Identity, "Red");
        }

        // Runs after OnAuthentication method. Can capture when request has failed authentication or authorization polices for an action method. 
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var user = (CustomPrincipal) filterContext.HttpContext.User;
            string hairColour = user.hairColour;

            /*if (user == null || !user.Identity.IsAuthenticated)
                filterContext.Result = new HttpUnauthorizedResult();*/
        }
    }

    public class CustomPrincipal : IPrincipal
    {
        public CustomPrincipal(IIdentity identity, string hairColour)
        {
            this.Identity = identity;
            this.hairColour = hairColour;
        }

        public IIdentity Identity { get; private set; }
        public string hairColour { get; private set; }
        public bool IsInRole(string role) { return false; }
    }
}