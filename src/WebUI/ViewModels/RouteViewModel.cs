using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace Framework.ViewModels
{
    public class RouteViewModel
    {
        public RouteViewModel()
        {
            Customers = new List<Customer>();
        }

        public Route Route{ get; set; }

        public List<Customer> Customers{ get; set; }
    }
}