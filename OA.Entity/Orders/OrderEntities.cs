using OA.Entity.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entity.Orders
{
    public class OrderEntities
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public float ShipCost { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual UsersEntities Users { get; set; }
        public virtual ICollection<OrderProductEntities> OrderProducts { get; set; }

        public OrderEntities()
        {
            OrderProducts = new List<OrderProductEntities>();
        }

    }
}
