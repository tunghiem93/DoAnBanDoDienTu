using OA.Commons.Enums;
using OA.DTO.Products;
using OA.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DAL.Sales
{
    public class SalesDAL
    {
        public async Task<List<SaleDTO>> GetList()
        {
            using(var context = new PhoneContext())
            {
                var models = await context.Sales.AsNoTracking().Where(z => z.IsActive != Convert.ToInt32(ActiveStatus.Deleted))
                    .Select(z => new SaleDTO
                    {
                        Id = z.Id,
                        EndDate = z.EndDate,
                        IsActive = z.IsActive,
                        StartDate = z.StartDate,
                        Title = z.Title
                    }).ToListAsync();

                return models;
            }
        }

        public async Task<bool> Create(SaleDTO model)
        {
            using(var context = new PhoneContext())
            {
                context.Sales.Add(new Entity.Products.SaleEntities
                {
                    EndDate = model.EndDate,
                    IsActive = model.IsActive,
                    StartDate = model.StartDate,
                    Title = model.Title
                });

                return await context.SaveChangesAsync() == 1;
            }
        }

        public async Task<bool> Update(SaleDTO model)
        {
            using(var context = new PhoneContext())
            {
                var Sales = await context.Sales.FindAsync(model.Id);
                if(Sales == null)
                {
                    return false;
                }
                Sales.IsActive = model.IsActive;
                Sales.Title = model.Title;
                Sales.StartDate = model.StartDate;
                Sales.EndDate = model.EndDate;

                return await context.SaveChangesAsync() >= 0;
            }
        }

        public async Task<SaleDTO> GetById(int Id)
        {
            using(var context = new PhoneContext())
            {
                var models = await context.Sales.AsNoTracking().Where(z => z.IsActive != Convert.ToInt32(ActiveStatus.Deleted) && z.Id == Id)
                   .Select(z => new SaleDTO
                   {
                       Id = z.Id,
                       EndDate = z.EndDate,
                       IsActive = z.IsActive,
                       StartDate = z.StartDate,
                       Title = z.Title
                   }).FirstOrDefaultAsync();

                return models;
            }
        }

        public async Task<bool> Destroy(int Id)
        {
            using(var context = new PhoneContext())
            {
                var Sales = await context.Sales.FindAsync(Id);
                if(Sales == null)
                {
                    return false;
                }
                Sales.IsActive = Convert.ToInt32(ActiveStatus.Deleted);
                return await context.SaveChangesAsync() == 1;
            }
        }
    }
}
