using Ecommerce.Cargo.DataAccesLayer.Absract;
using Ecommerce.Cargo.DataAccesLayer.Concrate;
using Ecommerce.Cargo.DataAccesLayer.Repository;
using Ecommerce.Cargo.EtitiyLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Cargo.DataAccesLayer.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer> , ICargoCustomerDal
    {
        private readonly CargoContext _cargoContext;
        public EfCargoCustomerDal(CargoContext context, CargoContext cargoContext) : base(context)
        {
            _cargoContext = cargoContext;
        }
        public CargoCustomer GetCargoCustomerById(string id)
        {
            var values = _cargoContext.CargoCostumers.Where(x => x.UserCustomerId == id).FirstOrDefault();
            return values;
        }
    }
}
