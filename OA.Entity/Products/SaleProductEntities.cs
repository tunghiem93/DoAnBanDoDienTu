using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entity.Products
{
    public class SaleProductEntities
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float SaleCost { get; set; }

        public virtual SaleEntities Sales { get; set; }
        public virtual ProductEntities Products { get; set; }
    }
}
