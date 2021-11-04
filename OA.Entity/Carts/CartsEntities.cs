using OA.Entity.Products;
using OA.Entity.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entity.Carts
{
    public class CartsEntities
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual UsersEntities Users { get; set; }
        public virtual ProductEntities Product { get; set; }
    }
}
