using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersTestProject.AuthData
{
    public class CustomResultFilter : ActionFilterAttribute, IResultFilter
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Debug.Print("OnResultExecuted");
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            Debug.Print("OnResultExecuting");
        }

    }
}