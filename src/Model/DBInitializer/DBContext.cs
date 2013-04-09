using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Model.Mappings;

namespace Model
{
    public class AppDbContext: DbContext
    {
        static AppDbContext()
        {
          //  Database.SetInitializer<AppDbContext>(new DBContextInitializer());
          //  Deprecado. En vez de utilizar este comando para crear la base se utiliza el comando update-database desde el Package Manager Console, seleccionado el proyecto Model.
        }

        public AppDbContext()
            : base("Name=AppDbContext")
        {
        }

        public DbSet<Route> Routes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new RouteMap());
        }
    }
}
