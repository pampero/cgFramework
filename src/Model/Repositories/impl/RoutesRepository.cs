using System.Collections.Generic;
using System.Linq;
using Model.Repositories.interfaces;

namespace Model.Repositories.impl
{
    public class RoutesRepository : GenericRepository<Route>, IRoutesRepository
    {
        public RoutesRepository(AppDbContext context)
            : base(context)
        {
            
        }
        

        public List<Route> GetAll()
        {
            // TODO: SOLO RETORNAR IQueryable. No es PERFORMANTE con el ToList en este punto.
            return context.Routes.Where(x => !x.IsDeleted).OrderByDescending(x =>x.Created).ToList();
        }
    }
}
