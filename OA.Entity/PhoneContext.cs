using OA.Entity.Carts;
using OA.Entity.Category;
using OA.Entity.ContactMethods;
using OA.Entity.Orders;
using OA.Entity.Products;
using OA.Entity.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entity
{
    public class PhoneContext : DbContext
    {
        public PhoneContext() : base("name=Phone_Context")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                                            .Where(type => !String.IsNullOrEmpty(type.Namespace))
                                            .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                                            type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            Database.SetInitializer<PhoneContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CartsEntities> Carts { get; set; }
        public DbSet<CategoryEntities> Categories { get; set; }
        public DbSet<ContactMethodEntities> ContactMethods { get; set; }
        public DbSet<OrderEntities> Orders { get; set; }
        public DbSet<OrderProductEntities> OrderProducts { get; set; }
        public DbSet<ProductEntities> Products { get; set; }
        public DbSet<SaleEntities> Sales { get; set; }
        public DbSet<SaleProductEntities> SaleProducts { get; set; }
        public DbSet<UsersEntities> Users { get; set; }
    }
}
