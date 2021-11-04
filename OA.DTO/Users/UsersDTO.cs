using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace OA.DTO.Users
{
    public class UsersDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public int Role { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public int IsActive { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc")]
        public string Address { get; set; }
    }
}
