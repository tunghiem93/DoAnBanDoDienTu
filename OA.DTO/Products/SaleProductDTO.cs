using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DTO.Products
{
    public class SaleProductDTO
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float SaleCost { get; set; }
    }

    public class SaleProductViewDTO : SaleProductDTO
    {
        public string Title { get; set; }
    }
}
