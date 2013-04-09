using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Mappings
{
    public class BaseClassMap : EntityTypeConfiguration<BaseClass>
    {
        public BaseClassMap()
        {
            
            // Primary Key
            this.HasKey(t => t.ID);

            this.Property(t => t.Created)
                .IsRequired();

            this.Property(t => t.CreatedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("BaseClass");
            this.Property(t => t.ID).HasColumnName("ID");

            this.Property(t => t.Created).HasColumnName("Creado");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.Deleted).HasColumnName("Deleted");
            this.Property(t => t.DeletedBy).HasColumnName("DeletedBy");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.Updated).HasColumnName("Updated");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
        }
    }
}
