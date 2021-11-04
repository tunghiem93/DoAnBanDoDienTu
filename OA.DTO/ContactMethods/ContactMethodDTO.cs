using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DTO.ContactMethods
{
    public class ContactMethodDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public string Method { get; set; }
    }
}
