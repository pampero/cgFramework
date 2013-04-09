using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Mappings
{
    public class RouteMap : EntityTypeConfiguration<Route>
    {
        public RouteMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Distance)
                .IsRequired();
            
            // Table & Column Mappings
            this.ToTable("Route");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Distance).HasColumnName("Distance");
            this.Property(t => t.Comments).HasColumnName("Comments");

        }
    }
}
