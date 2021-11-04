using OA.Entity.Products;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entity.Mappings
{
    public class SaleEntitiesMappings : EntityTypeConfiguration<SaleEntities>
    {
        public SaleEntitiesMappings()
        {
            this.ToTable("Sales");
            this.HasKey(z => z.Id);
            this.Property(z => z.Title).HasMaxLength(500).IsRequired();
        }
    }
}
