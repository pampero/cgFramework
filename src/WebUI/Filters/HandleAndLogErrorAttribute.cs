using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net.Core;
using log4net;

namespace Framework.Filters
{
    // INFO: Para mas información sobre Exception Handling en MVC
    // http://www.codeproject.com/Articles/422572/Exception-Handling-in-ASP-NET-MVC
    public class HandleAndLogErrorAttribute : HandleErrorAttribute
    {
        public ILog Logger { get; set; }

        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }

            if (new HttpException(null, filterContext.Exception).GetHttpCode() != 500)
            {
                return;
            }

            if (!ExceptionType.IsInstanceOfType(filterContext.Exception))
            {
                return;
            }

            // if the request is AJAX return JSON else view.
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                filterContext.Result = new JsonResult 
                { 
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet, 
                    Data = new 
                    { 
                        error = true,
                        message = filterContext.Exception.Message
                    } 
                };
            }
            else
            {
                var controllerName = (string)filterContext.RouteData.Values["controller"];
                var actionName = (string)filterContext.RouteData.Values["action"];
                var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
            
                filterContext.Result = new ViewResult
                {
                    ViewName = View,
                    MasterName = Master,
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                    TempData = filterContext.Controller.TempData
                };
            }

            Logger.Error(filterContext.Exception.Message, filterContext.Exception);

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;

            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;      
        }
    }
}