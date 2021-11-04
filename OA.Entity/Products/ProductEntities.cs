using OA.Entity.Carts;
using OA.Entity.Category;
using OA.Entity.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entity.Products
{
    public class ProductEntities
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public int Quantity { get; set; }
        public float Prices { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int IsActive { get; set; }

        public virtual ICollection<CartsEntities> Carts { get; set; }
        public virtual ICollection<OrderProductEntities> OrderProducts { get; set; }
        public virtual CategoryEntities Categories { get; set; }
        public virtual ICollection<SaleProductEntities> SaleProducts { get; set; }
    }
}
