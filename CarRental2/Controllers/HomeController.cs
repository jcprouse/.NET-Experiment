using FiltersTestProject.AuthData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace FiltersTestProject.Controllers
{
    [CustomAuthenticationAttribute]
    public class HomeController : Controller
    {

        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            string abc = "a";
        }

        protected override void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            string abc = "a";
        }


        public ActionResult Index()
        {
            return View();
        }
        //[Authorize]
        //[Authorize(Roles = "Admin")]
        //[CustomAuthenticationAttribute]
        [CustomAuthorizationAttribute]
        [CustomActionFilter]
        [CustomResultFilter]
        public ActionResult About()
        {
            var hairColour = ((CustomPrincipal)ControllerContext.HttpContext.User).hairColour;
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [CustomExceptionFilter(View = "Shared/Error")]
        [Authorize(Roles = "User,Admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[CustomExceptionFilter(View="Shared/Error")]
        [HandleError]
        public ActionResult fail()
        {
            throw new Exception("Not implemented!");
        }
    }
}