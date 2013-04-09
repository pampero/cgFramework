using System.Web;
using System.Web.Mvc;
using Framework.Filters;
using log4net;

namespace Framework
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthorizeAttribute());
        }
    }
}