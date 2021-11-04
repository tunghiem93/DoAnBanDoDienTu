using OA.Entity.Products;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entity.Mappings
{
    public class ProductEntitiesMappings : EntityTypeConfiguration<ProductEntities>
    {
        public ProductEntitiesMappings()
        {
            this.ToTable("Products");
            this.HasKey(z => z.Id);
            this.Property(z => z.Name).HasColumnType("nvarchar").HasMaxLength(250).IsRequired();
            this.Property(z => z.ImageURL).HasColumnType("nvarchar").HasMaxLength(250).IsRequired();
            this.Property(z => z.Description).IsRequired();
            this.HasRequired(z => z.Categories).WithMany(z => z.Products).HasForeignKey(z => z.CategoryId);
        }
    }
}
