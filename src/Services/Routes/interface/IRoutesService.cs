using System;
using System.Collections.Generic;
using System.Linq;
using Model;


namespace Services.Routes.interfaces
{
    public interface IRoutesService : IBaseService<Route>
    {
        string GetRouteName();
    }
}