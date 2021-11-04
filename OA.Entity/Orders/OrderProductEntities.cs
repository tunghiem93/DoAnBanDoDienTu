using OA.Entity.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entity.Orders
{
    public class OrderProductEntities
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public float Prices { get; set; }

        public virtual OrderEntities Orders { get; set; }
        public virtual ProductEntities Products { get; set; }
    }
}
