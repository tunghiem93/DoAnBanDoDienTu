using OA.Entity.Products;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entity.Mappings
{
    public class SaleProductEntitiesMappings : EntityTypeConfiguration<SaleProductEntities>
    {
        public SaleProductEntitiesMappings()
        {
            this.ToTable("SaleProducts");
            this.HasKey(z => z.Id);
            this.HasRequired(z => z.Products).WithMany(z => z.SaleProducts).HasForeignKey(z => z.ProductId);
            this.HasRequired(z => z.Sales).WithMany(z => z.SaleProducts).HasForeignKey(z => z.SaleId);
        }
    }
}
