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
    public class EfCargoOperationDal : GenericRepository<CargoOperation>, ICargoOperationDal
    {
        public EfCargoOperationDal(CargoContext context) : base(context)
        {
        }
    }
}
