using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories.interfaces
{
    public interface IRoutesRepository
    {
        List<Route> GetAll();
        IQueryable<Route> List();
        
        IEnumerable<Route> Get(
            Expression<Func<Route, bool>> filter = null,
            Func<IQueryable<Route>, IOrderedQueryable<Route>> orderBy = null,
            string includeProperties = "");

        Route GetByID(object id);
        void Insert(Route entity);
        void Delete(object id);
        void Delete(Route entityToDelete);
        void Update(Route entityToUpdate);
        IEnumerable<Route> GetWithRawSql(string query, params object[] parameters);
    }
}
