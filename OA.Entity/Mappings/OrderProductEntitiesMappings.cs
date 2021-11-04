using OA.Entity.Orders;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entity.Mappings
{
    public class OrderProductEntitiesMappings : EntityTypeConfiguration<OrderProductEntities>
    {
        public OrderProductEntitiesMappings()
        {
            this.ToTable("OrderProducts");
            this.HasKey(z => z.Id);
            this.HasRequired(z => z.Orders).WithMany(z => z.OrderProducts).HasForeignKey(z => z.OrderId);
            this.HasRequired(z => z.Products).WithMany(z => z.OrderProducts).HasForeignKey(z => z.ProductId);
        }
    }
}
