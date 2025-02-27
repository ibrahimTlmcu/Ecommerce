using Ecommerce.Comment.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442;initial Catalog=EcommerceShopCommentDb;User=Sa;Password=123456aA*");

        }

        public DbSet<UserComment> UserComment { get; set; }
    }
}
