using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DTO.Category
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public string Name { get; set; }
        public int IsActive { get; set; }
    }
}
