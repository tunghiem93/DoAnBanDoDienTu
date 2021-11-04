using OA.Commons.Enums;
using OA.DTO.Category;
using OA.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DAL.Category
{
    public class CategoryDAL
    {
        public async Task<bool> Create(CategoryDTO request)
        {
            using(var context = new PhoneContext())
            {
                context.Categories.Add(new Entity.Category.CategoryEntities
                {
                    IsActive = Convert.ToInt16(ActiveStatus.Actived),
                    Name = request.Name,
                });
                var Result = await context.SaveChangesAsync();
                return Result == 1;
            }
        }

        public async Task<(bool,string)> Update(CategoryDTO request)
        {
            using(var context = new PhoneContext())
            {
                var Categories = context.Categories.Find(request.Id);
                if(Categories == null)
                {
                    return (false, "Không tồn tại thể loại này");
                }
                Categories.Name = request.Name;
                var Result = await context.SaveChangesAsync();
                if(Result >= 0)
                {
                    return (true, "Cập nhật thể loại sản phẩm thành công");
                }
                return (false, "Cập nhật thể loại sản phẩm không thành công");
            }
        }

        public async Task<List<CategoryDTO>> GetList()
        {
            using(var context = new PhoneContext())
            {
                var models = await context.Categories.Where(z => z.IsActive != Convert.ToInt16(ActiveStatus.Deleted))
                    .Select(z => new CategoryDTO
                    {
                        Id = z.Id,
                        IsActive = z.IsActive,
                        Name = z.Name
                    }).ToListAsync();
                return models;
            }
        }

        public async Task<CategoryDTO> GetById(int Id)
        {
            using (var context = new PhoneContext())
            {
                var models = await context.Categories.Where(z => z.IsActive != Convert.ToInt16(ActiveStatus.Deleted) && z.Id == Id)
                    .Select(z => new CategoryDTO
                    {
                        Id = z.Id,
                        IsActive = z.IsActive,
                        Name = z.Name
                    }).FirstOrDefaultAsync();
                return models;
            }
        }

        public async Task<(bool, string)> Destroy(int Id)
        {
            using(var context = new PhoneContext())
            {
                var Category = context.Categories.Find(Id);
                if(Category == null)
                {
                    return (false, "Không tìm thấy thể loại sản phẩm");
                }
                Category.IsActive = Convert.ToInt32(ActiveStatus.Deleted);
                var Result = await context.SaveChangesAsync();
                if(Result == 1)
                {
                    return (true, "Xóa thể loại sản phẩm thành công");
                }
                return (false, "Xóa thể loại sản phẩm không thành công");
            }
        }
    }
}
