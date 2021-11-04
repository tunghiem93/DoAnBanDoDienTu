using OA.Commons.Enums;
using OA.DTO.Orders;
using OA.Entity;
using OA.Entity.Orders;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DAL.Orders
{
    public class OrderDAL
    {
        public async Task<bool> CreateOrders(int UserId, float ShipCost)
        {
            using(var context = new PhoneContext())
            {
                var Carts = await context.Carts.Include(z => z.Product).Where(z => z.UserId == UserId).ToListAsync();
                if(Carts != null && Carts.Any())
                {
                    var Orders = new OrderEntities
                    {
                        OrderDate = DateTime.Now,
                        ShipCost = ShipCost,
                        Status = Convert.ToInt32(OrderStatus.InProgress),
                        UserId = UserId
                    };
                    foreach(var cart in Carts)
                    {
                        Orders.OrderProducts.Add(new OrderProductEntities
                        {
                            Prices = cart.Product.Prices,
                            ProductId = cart.ProductId,
                            Quantity = cart.Quantity,
                        });
                    }
                    context.Orders.Add(Orders);
                    var Result = await context.SaveChangesAsync();
                    return Result >= 1;
                }
                return false;
            }
        }

        public async Task<List<OrderDTO>> GetList()
        {
            using(var context = new PhoneContext())
            {
                var Entity = context.Orders.Include(z => z.OrderProducts).Include(z => z.Users).AsNoTracking();

                var models = await Entity.Select(z => new OrderDTO
                {
                    Id = z.Id,
                    OrderDate = z.OrderDate,
                    ShipCost = z.ShipCost,
                    Status = z.Status,
                    UserId = z.UserId,
                    Name = z.Users.Name,
                    Quantity = z.OrderProducts.Sum(m => m.Quantity),
                    TotalPrices = z.OrderProducts.Sum(m => m.Quantity * m.Prices)
                }).ToListAsync();

                return models;
            }
        }

        public async Task<OrderDetailViewDTO> GetById(int Id)
        {
            using(var context = new PhoneContext())
            {
                var Entity = context.Orders.Include(z => z.OrderProducts).Include(z => z.Users).Where(z => z.Id == Id).AsNoTracking();

                var models = await Entity.Select(z => new OrderDetailViewDTO
                {
                    Id = z.Id,
                    OrderDate = z.OrderDate,
                    ShipCost = z.ShipCost,
                    Status = z.Status,
                    UserId = z.UserId,
                    Name = z.Users.Name,
                    Quantity = z.OrderProducts.Sum(m => m.Quantity),
                    TotalPrices = z.OrderProducts.Sum(m => m.Quantity * m.Prices)
                }).FirstOrDefaultAsync();

                if(models != null)
                {
                    models.OrderProducts = await context.OrderProducts.Include(z => z.Products).Where(z => z.OrderId == Id)
                        .Select(z => new OrderProductDTO
                        {
                            Id = z.Id,
                            OrderId = z.OrderId,
                            Prices = z.Prices,
                            ProductId = z.ProductId,
                            Quantity = z.Quantity,
                            ProductImage = z.Products.ImageURL,
                            ProductName = z.Products.Name
                        }).ToListAsync();
                }

                return models;
            }
        }

        public async Task<bool> ChangeStatus(int Id, int Status)
        {
            using(var context = new PhoneContext())
            {
                var Orders = await context.Orders.FirstOrDefaultAsync(z => z.Id == Id);
                if(Orders == null)
                {
                    return false;
                }
                Orders.Status = Status;
                var Result = await context.SaveChangesAsync();
                return Result >= 0;
            }
        }
    }
}
