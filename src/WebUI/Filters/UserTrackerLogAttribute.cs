using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace Framework.Filters
{
    // INFO: Para mas información sobre Logging de información en MVC
    // http://weblogs.asp.net/shijuvarghese/archive/2011/07/18/user-activity-logging-in-asp-net-mvc-app-using-action-filter-and-log4net.aspx
    // Los archivos de configuración se encuentran en \db\user.tracker.configuration
    public class UserTrackerLogAttribute : ActionFilterAttribute, IActionFilter
    {
        //public ILog Logger { get; set; }
        public ILog Logger  = LogManager.GetLogger("UserTrackerLog");

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var actionDescriptor= filterContext.ActionDescriptor;
            string controllerName = actionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = actionDescriptor.ActionName;
            string userName = filterContext.HttpContext.User.Identity.Name.ToString();
            DateTime timeStamp = filterContext.HttpContext.Timestamp;
            string routeId=string.Empty;
            if (filterContext.RouteData.Values["id"] != null)
            {
                routeId = filterContext.RouteData.Values["id"].ToString();
            }
            StringBuilder message = new StringBuilder();
            message.Append("UserName=");
            message.Append(userName + "|");
            message.Append("Controller=");
            message.Append(controllerName+"|");
            message.Append("Action=");
            message.Append(actionName + "|");
            message.Append("TimeStamp=");
            message.Append(timeStamp.ToString() + "|");
            if (!string.IsNullOrEmpty(routeId))
            {
                message.Append("RouteId=");
                message.Append(routeId);
            }
            
            Logger.Info(message.ToString());
            base.OnActionExecuted(filterContext);
        }
    }
}