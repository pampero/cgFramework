using System;
using System.Collections.Generic;
using System.Linq;
using Common.Base;
using Framework.Filters;
using Framework.ViewModels;
using Frontend.Notifications;
using Model;
using Services.Routes.interfaces;
using System.Web.Mvc;

namespace Framework.Areas.BackOffice.Controllers
{
    public class RoutesController : BaseController
    {
        private IRoutesService _routesService { get; set; }
        private NotificationHub _notificationHub { get; set; }

        public RoutesController(IRoutesService routesService, NotificationHub notificationHub)
        {
            _routesService = routesService;
            
            // Utilizar para consulta de listas filtradas.
            // http://www.sql-server-performance.com/2012/entity-framework-performance-optimization/
            var listRoute =_routesService.List().Where(x=>x.ID == 1);

            _notificationHub = notificationHub;
        }

        public ActionResult jQueryDataTablesHandler(jQueryDataTableParamModel param)
        {
            var routes = _routesService.GetAll();
            IEnumerable<Route> filteredRoutes = routes;
                       
            //Filter by Search
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                filteredRoutes = filteredRoutes.Where(c => c.Name.Contains(param.sSearch));
            }
            
            //Ordering
            if (!string.IsNullOrEmpty(Request["iSortCol_0"]) && !string.IsNullOrEmpty(Request["sSortDir_0"]))
            {
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                var columnName = param.sColumns.Split(',')[sortColumnIndex];
                Func<Route, object> orderingFunction = (r => r.GetType().GetProperty(columnName).GetValue(r));
                if (Request["sSortDir_0"] == "asc")
                    filteredRoutes = filteredRoutes.OrderBy(orderingFunction);
                else
                    filteredRoutes = filteredRoutes.OrderByDescending(orderingFunction);
            }

            //Paging
            var displayedRoutes = filteredRoutes
                .Skip(param.iDisplayStart)
                .Take(param.iDisplayLength);

            
            try
            {
                //Prepare Rows
            var result = displayedRoutes.Select(x => new string[] {
                x.Name,
                x.Distance.ToString(),
                x.Created.ToString(),
                x.CreatedBy.ToString(),
                x.Deleted.HasValue ? x.Deleted.ToString() : "",
                x.DeletedBy != null ? x.DeletedBy : "",
                x.Updated.HasValue ? x.Updated.ToString() : "",
                x.UpdatedBy != null ? x.UpdatedBy : "",
                x.IsDeleted.ToString()
            }).ToArray();

                            return Json(new
                        {
                            sEcho = param.sEcho,
                            iTotalRecords = routes.Count(),
                            iTotalDisplayRecords = routes.Count(),
                            aaData = result
                        },
                        JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                
                throw;
            }
            

        }

        // INFO: Descomentar la línea dentro de la acción para probar la ejecución del filtro HandleAndLogError
        [HandleAndLogError]
        public ActionResult Index()
        {
            //throw new Exception("Error generado manualmente");
            Logger.Info("ROUTES CONTROLLER");
            
            // Utilizar solo para listar todas las entidades. Sino usar List()
            var routes = _routesService.GetAll();
            return View(routes);
        }

        [HandleAndLogError]
        public ActionResult Amanda()
        {
            return View("Amanda");
        }



        public ActionResult Bootstrap()
        {
            return View();
        }

        //
        // GET: /BackOffice/Jobs/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BackOffice/Jobs/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /BackOffice/Routes/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            NotificationHub.Send("Mensaje enviado en forma asincrónica -SignalR-");
            var route = _routesService.GetById(id);
            RouteViewModel routeViewModel = new RouteViewModel();
            
            var customers = new List<Customer>();
            customers.Add(new Customer { ID = 1, Name = "Carlos", Created = DateTime.Now});
            customers.Add(new Customer { ID = 2, Name = "Daniel", Created = DateTime.Now});
            
            routeViewModel.Customers = customers;
            routeViewModel.Route = route;

            return View(routeViewModel);
        }

        //
        // POST: /BackOffice/Routes/Edit/5
        // El objeto Route mapea todos los campos TEXTUALMENTE. En vez de Route se puede usar FormCollection que tendrá TODOS los campos del FORM
        // Se puede extender el comportamiento mediante las clases ModelBinding.
        [HttpPost]
        public ActionResult Edit(int id, Route route)
        {
            System.Threading.Thread.Sleep(2000);
            try
            {
            // Obtener el OBJETO Customer y agregarlo directamente
            //route.Customer = _customersService.GetCustomerById(id);
                _routesService.Update(route);
                return Json("Ruta modificada correctamente");
            }
            catch (Exception exception)
            {
                return Json("Error modificar la ruta. " + exception.Message);
            }
        }

    }
}
