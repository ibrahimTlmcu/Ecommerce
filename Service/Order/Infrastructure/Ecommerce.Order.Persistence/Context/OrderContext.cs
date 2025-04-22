using Ecommerce.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,1440;Database=EcommerceShopOrderDb;User=sa;Password=123456aA*;TrustServerCertificate=True");
            }
        }
    }
}
