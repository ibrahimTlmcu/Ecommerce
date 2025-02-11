using Ecommerce.Cargo.EtitiyLayer.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Cargo.DataAccesLayer.Concrate
{
    public class CargoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1441;initial Catalog=EcommerceShopCargoDb;User=Sa;Password=123456aA*");

        }

        public DbSet<CargoCompany> CargoCompanies { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoCustomer> CargoCostumers { get; set; }
        public DbSet<CargoOperation> CargoOperations { get; set; }


    }
}
