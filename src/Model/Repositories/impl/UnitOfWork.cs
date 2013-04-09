using System;
using System.Data.Common;
using Model.Repositories.impl;
using Model.Repositories.interfaces;
using log4net;

namespace Model
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private AppDbContext context = new AppDbContext();
        private IRoutesRepository _routesRepository;
        
        public ILog Logger { get; set; }

        public DbConnection GetConnection()
        {
            return context.Database.Connection;
        }

        public IRoutesRepository RoutesRepository
        {
            get {  if (this._routesRepository == null)
                {
                    this._routesRepository = new RoutesRepository(context);
                }
                return _routesRepository; }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}