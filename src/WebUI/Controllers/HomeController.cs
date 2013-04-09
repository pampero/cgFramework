using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Base;
using Framework.Filters;
using log4net.Core;
using log4net;

namespace Framework.Controllers
{
    public class HomeController : BaseController
    {
        // INFO: 
        // Se ejemplifica el uso del atributo UserTrackerLog para loguear la llamada a la acción Index.
        // UserAuthorizeAttribute permite ejecutar la acción Index() si y solo si el usuario tiene el Rol "Admin".
        // NOTA: 
        // El atributo Authorize provisto por MVC está ejecutando en todos los controladores a nivel global -en la clase FilterConfig- el problema es que redirecciona 
        // a la vista de login independientemente de si el usuario no ha sido autenticado o no ha sido autorizado.
        // En caso de que tenga autenticación pero no autorización debería ir a la vista de "acceso denegado", para ello utilizar el atributo RoleAuthorizeAttribute.
        [UserTrackerLog]
        [RoleAuthorizeAttribute(Roles="Admin")]
        public ActionResult Index()
        {
            Logger.Error("LOG ERROR");
            Logger.Info("LOG INFO");
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
