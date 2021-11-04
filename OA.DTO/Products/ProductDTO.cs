using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DTO.Products
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public float Prices { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public int CategoryId { get; set; }

        public int IsActive { get; set; }
    }

    public class ProductViewModels : ProductDTO
    {
        public string CategoryName { get; set; }

        public SaleProductViewDTO SaleProduct { get; set; }
    }
}
