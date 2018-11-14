using FiltersTestProject.AuthData;
using System.Web;
using System.Web.Mvc;

namespace FiltersTestProject
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomAuthorizationAttribute());
        }
    }
}
