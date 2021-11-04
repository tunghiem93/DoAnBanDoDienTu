using OA.DTO.Carts;
using OA.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DAL.Carts
{
    public class CartsDAL
    {
        public async Task<bool> CreateOrUpdateCart(CartsDTO request)
        {
            using(var context = new PhoneContext())
            {
                var Carts = await context.Carts.FirstOrDefaultAsync(z => z.ProductId == request.ProductId && z.UserId == request.UserId);
                if(Carts != null)
                {
                    Carts.Quantity = Carts.Quantity + request.Quantity;
                }
                else
                {
                    context.Carts.Add(new Entity.Carts.CartsEntities
                    {
                        ProductId = request.ProductId,
                        UserId = request.UserId,
                        Quantity = request.Quantity
                    });
                }
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> DeleteCarts(int UserId)
        {
            using(var context = new PhoneContext())
            {
                var Carts = context.Carts.Where(z => z.UserId == UserId);
                context.Carts.RemoveRange(Carts);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
