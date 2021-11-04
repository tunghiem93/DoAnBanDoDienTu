using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DTO.Users
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public string Password { get; set; }
    }
}
