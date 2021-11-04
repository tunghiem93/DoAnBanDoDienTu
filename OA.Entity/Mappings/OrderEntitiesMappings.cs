using OA.Entity.Orders;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entity.Mappings
{
    public class OrderEntitiesMappings : EntityTypeConfiguration<OrderEntities>
    {
        public OrderEntitiesMappings()
        {
            this.ToTable("Orders");
            this.HasKey(z => z.Id);
            this.HasRequired(z => z.Users).WithMany(z => z.Orders).HasForeignKey(z => z.UserId);
        }
    }
}
