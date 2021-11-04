using OA.Commons.Enums;
using OA.Commons.MD5;
using OA.DTO.Users;
using OA.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DAL.Users
{
    public class UsersDAL
    {
        public async Task<UsersDTO> Login(LoginDTO request)
        {
            using(var context = new PhoneContext())
            {
                var Users = await context.Users.Where(z => z.Email == request.Email && z.Password == MD5Helpers.Encrypt(request.Password) && z.IsActive == Convert.ToInt16(ActiveStatus.Actived))
                    .Select(z => new UsersDTO
                    {
                        Id = z.Id,
                        Address = z.Address,
                        Email = z.Email,
                        IsActive = z.IsActive,
                        Name = z.Name,
                        Password = z.Password,
                        PhoneNumber = z.PhoneNumber,
                        Role = z.Role
                    }).FirstOrDefaultAsync();

                return Users;
            }
        }

        public async Task<(bool, string)> Save(UsersDTO request)
        {
            var msg = string.Empty;
            using(var context = new PhoneContext())
            {
                var _Any = await context.Users.AnyAsync(z => z.Email == request.Email && z.IsActive == Convert.ToInt16(ActiveStatus.Actived));
                if(_Any)
                {
                    msg = "Email đã tồn tại";
                    return (false, msg);
                }
                context.Users.Add(new Entity.Users.UsersEntities
                {
                    Address = request.Address,
                    Email = request.Email,
                    IsActive = Convert.ToInt16(ActiveStatus.Actived),
                    Name = request.Name,
                    Password = MD5Helpers.Encrypt(request.Password),
                    PhoneNumber = request.PhoneNumber,
                    Role = request.Role
                });
                var Result = await context.SaveChangesAsync();
                if(Result == 1)
                {
                    return (true, "Đăng kí tài khoản thành công");
                }
                return (false, "Đăng kí tài khoản thất bại");
            }
        }

        public async Task<List<UsersDTO>> GetList()
        {
            using(var context = new PhoneContext())
            {
                var models = await context.Users.Where(z => z.IsActive != Convert.ToInt16(ActiveStatus.Deleted))
                    .Select(z => new UsersDTO
                    {
                        Id = z.Id,
                        Address = z.Address,
                        Email = z.Email,
                        IsActive = z.IsActive,
                        Name = z.Name,
                        Password = z.Password,
                        PhoneNumber = z.PhoneNumber,
                        Role = z.Role
                    }).ToListAsync();
                return models;
            }
        }

        public async Task<UsersDTO> GetById(int Id)
        {
            using(var context = new PhoneContext())
            {
                var models = await context.Users.Where(z => z.IsActive != Convert.ToInt16(ActiveStatus.Deleted) && z.Id == Id)
                    .Select(z => new UsersDTO
                    {
                        Id = z.Id,
                        Address = z.Address,
                        Email = z.Email,
                        IsActive = z.IsActive,
                        Name = z.Name,
                        Password = z.Password,
                        PhoneNumber = z.PhoneNumber,
                        Role = z.Role
                    }).FirstOrDefaultAsync();
                return models;
            }
        }

        public async Task<(bool, string)> Update(UsersDTO request)
        {
            using(var context = new PhoneContext())
            {
                var Users = context.Users.Find(request.Id);
                if(Users == null)
                {
                    return (false, "Tài khoản không tồn tại");
                }
                Users.Name = request.Name;
                Users.Address = request.Address;
                Users.Password = MD5Helpers.Encrypt(request.Password);
                Users.PhoneNumber = request.PhoneNumber;
                var Result = await context.SaveChangesAsync();
                if(Result >= 0)
                {
                    return (true, "Cập nhật thông tin thành công");
                }
                return (false, "Cập nhật thông tin thất bại");
            }
        }
    }
}
