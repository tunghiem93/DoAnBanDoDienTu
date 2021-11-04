using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DTO.Products
{
    public class SaleDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public DateTime EndDate { get; set; }
        public int IsActive { get; set; }
    }
}
