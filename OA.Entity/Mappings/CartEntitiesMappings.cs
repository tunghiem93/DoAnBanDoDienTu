using OA.Entity.Carts;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entity.Mappings
{
    public class CartEntitiesMappings : EntityTypeConfiguration<CartsEntities>
    {
        public CartEntitiesMappings()
        {
            this.ToTable("Carts");
            this.HasKey(z => z.Id);
            this.HasRequired(z => z.Users).WithMany(z => z.Carts).HasForeignKey(z => z.UserId);
            this.HasRequired(z => z.Product).WithMany(z => z.Carts).HasForeignKey(z => z.ProductId);
        }
    }
}
