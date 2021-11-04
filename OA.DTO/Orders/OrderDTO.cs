using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DTO.Orders
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public float ShipCost { get; set; }
        public DateTime OrderDate { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float TotalPrices { get; set; }
    }

    public class OrderDetailViewDTO : OrderDTO
    {
        public List<OrderProductDTO> OrderProducts { get; set; }

        public OrderDetailViewDTO()
        {
            this.OrderProducts = new List<OrderProductDTO>();
        }
    }
}
