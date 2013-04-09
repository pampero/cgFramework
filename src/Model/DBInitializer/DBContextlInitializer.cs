using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Model
{
    // Deprecado, se utiliza el script de PostDeploy en Model.Sql
    public class DBContextInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            try
            {
                var routes = new List<Route>
                            {
                                new Route { Name="Name1", Created=DateTime.Now, CreatedBy="cvazquez", Distance = 12  },
                                new Route { Name="Name2", Created=DateTime.Now, CreatedBy="cvazquez", Distance = 13},
                                new Route { Name="Name3", Created=DateTime.Now, CreatedBy="cvazquez", Distance = 14}
                            };

                routes.ForEach(s => context.Routes.Add(s));

                context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw;
            }
            
        }
    }
}
