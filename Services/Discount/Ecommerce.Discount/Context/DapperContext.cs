using Ecommerce.Discount.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ecommerce.Discount.Context
{
    public class DapperContext :DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        #region Iconfiguration Onemli Not ! 
        ///  
        /// IConfiguration: Bu, ASP.NET Core'da yapılandırma ayarlarına erişmek için 
        /// kullanılan bir arayüzdür. Örneğin, appsettings.json, environment variables,
        /// veya user secrets gibi yapılandırma kaynaklarına erişmek için kullanılır.    
        #endregion

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-521H4H9\\SQLEXPRESS;initial Catalog=EcommerceDiscountDb;" +
                "integrated Security=true");
        }

        public DbSet<Coupon> Coupons { get; set; }

        public IDbConnection CreateConnection() => new SqlConnection( _connectionString); 

    }
}
