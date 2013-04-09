using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Model;
using System.Configuration;
using Model.Repositories;
using Model.Repositories.interfaces;
using Services.Routes.interfaces;
using Common.Base;
using log4net;

namespace Services.Routes.impl
{
    public class DefaultRoutesService : BaseService, IRoutesService
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public DefaultRoutesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<Route> GetAll()
        {
            Logger.Error("GETROUTES METHOD");
            return _unitOfWork.RoutesRepository.GetAll();
        }

        public Route GetById(int routeId)
        {
            return _unitOfWork.RoutesRepository.GetByID(routeId);
        }

        public IQueryable<Route> List()
        {
            return _unitOfWork.RoutesRepository.List();
        }

        public void Add(Route route)
        {
            _unitOfWork.RoutesRepository.Insert(route);
            _unitOfWork.Save();
        }
        
        public void Update(Route route)
        {
            _unitOfWork.RoutesRepository.Update(route);
            _unitOfWork.Save();
        }

        public void Delete(Route route)
        {
            _unitOfWork.RoutesRepository.Update(route);
            _unitOfWork.Save();
        }


        public string GetRouteName()
        {
            throw new NotImplementedException();
        }
    }
}
