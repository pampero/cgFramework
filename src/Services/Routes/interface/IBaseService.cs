using System;
using System.Collections.Generic;
using System.Linq;
using Model;


namespace Services.Routes.interfaces
{
    public interface IBaseService<TEntity>
    {
        IList<TEntity> GetAll();
        IQueryable<TEntity> List();
        TEntity GetById(int objectId);
        void Delete(TEntity entity);
        void Add(TEntity entity);
        void Update(TEntity entity);
    }
}