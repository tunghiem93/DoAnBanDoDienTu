using OA.DTO.Products;
using OA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.Commons.Enums;
using System.Data.Entity;

namespace OA.DAL.Products
{
    public class ProductDAL
    {
        public async Task<List<ProductViewModels>> GetList()
        {
            using(var context = new PhoneContext())
            {
                var Entity = context.Products.Include("Categories").Where(z => z.IsActive != Convert.ToInt32(ActiveStatus.Deleted));

                var models = await Entity.Select(z => new ProductViewModels
                {
                    Id = z.Id,
                    CategoryId = z.CategoryId,
                    Description = z.Description,
                    ImageURL = z.ImageURL,
                    Name = z.Name,
                    Prices = z.Prices,
                    Quantity = z.Quantity,
                    CategoryName = z.Categories.Name
                }).ToListAsync();

                if(models != null && models.Any())
                {
                    models.ForEach(z =>
                    {
                        z.SaleProduct = GetProductSale(z.Id);
                    });
                }


                return models;
            }
        }

        public async Task<bool> Create(ProductDTO model)
        {
            using(var context = new PhoneContext())
            {
                context.Products.Add(new Entity.Products.ProductEntities
                {
                    CategoryId = model.CategoryId,
                    Description = model.Description,
                    ImageURL = model.ImageURL,
                    IsActive = model.IsActive,
                    Name = model.Name,
                    Prices = model.Prices,
                    Quantity = model.Quantity,
                });

                return await context.SaveChangesAsync() == 1;
            }
        }

        public async Task<ProductDTO> GetById(int Id)
        {
            using(var context = new PhoneContext())
            {
                var model = await context.Products.Where(z => z.Id == Id)
                    .Select(z => new ProductDTO
                    {
                        Id = z.Id,
                        CategoryId = z.CategoryId,
                        Description = z.Description,
                        ImageURL = z.ImageURL,
                        IsActive = z.IsActive,
                        Name = z.Name,
                        Prices = z.Prices,
                        Quantity = z.Quantity
                    }).FirstOrDefaultAsync();

                return model;
            }
        }

        public async Task<bool> Update(ProductDTO model)
        {
            using(var context = new PhoneContext())
            {
                var Products = await context.Products.FindAsync(model.Id);
                if(Products == null)
                {
                    return false;
                }
                Products.Name = model.Name;
                Products.ImageURL = model.ImageURL;
                Products.IsActive = model.IsActive;
                Products.Prices = model.Prices;
                Products.Quantity = model.Quantity;
                Products.CategoryId = model.CategoryId;
                Products.Description = model.Description;

                return await context.SaveChangesAsync() >= 0;
            }
        }

        public async Task<bool> Destroy(int Id)
        {
            using(var context = new PhoneContext())
            {
                var Products = await context.Products.FirstOrDefaultAsync(z => z.Id == Id);
                if(Products == null)
                {
                    return false;
                }
                context.Products.Remove(Products);
                return await context.SaveChangesAsync() == 1;
            }
        }

        private SaleProductViewDTO GetProductSale(int ProductId)
        {
            using(var context = new PhoneContext())
            {
                var SaleProduct = context.SaleProducts.Where(z => z.ProductId == ProductId)
                    .Select(z => new SaleProductViewDTO
                    { 
                        Id = z.Id,
                        ProductId = z.ProductId,
                        Quantity = z.Quantity,
                        SaleCost = z.SaleCost,
                        SaleId = z.SaleId
                    }).FirstOrDefault();
                if(SaleProduct != null)
                {
                    var Sale = context.Sales.AsNoTracking().FirstOrDefault(z => z.Id == SaleProduct.SaleId && DbFunctions.TruncateTime(z.StartDate) >= DbFunctions.TruncateTime(DateTime.Now)
                                                && DbFunctions.TruncateTime(z.EndDate) <= DbFunctions.TruncateTime(DateTime.Now) && z.IsActive == Convert.ToInt32(ActiveStatus.Actived));

                    if(Sale != null)
                    {
                        SaleProduct.Title = Sale.Title;

                        return SaleProduct;
                    }
                }
                return null;
            }
        }
    }
}
