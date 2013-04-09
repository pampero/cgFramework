using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Framework.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View("Error");
        }

        public ActionResult NotFound()
        {
            return View("NotFound");
        }

        public ActionResult UnAuthorized()
        {
            return View("UnAuthorized");
        }
    }
}
