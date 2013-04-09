using System.Threading;
using System.Web.Mvc;
using log4net;

namespace Common.Base
{
    public class BaseController : Controller
    {
        public ILog Logger { get; set; }
    }
}
