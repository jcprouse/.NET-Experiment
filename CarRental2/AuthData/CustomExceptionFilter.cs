using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersTestProject.AuthData
{
    public class CustomExceptionFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Debug.Print("Custom exception");
            base.OnException(filterContext);
            var result = new ViewResult { ViewName = "Error" };
            result.ViewData.Add("Exception", filterContext.Exception);
            // TODO: Pass additional detailed data via ViewData
            filterContext.Result = result;
        }
    }
}