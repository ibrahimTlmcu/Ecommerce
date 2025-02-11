using Ecommerce.Cargo.BusinessLayer.Absract;
using Ecommerce.Cargo.DataAccesLayer.Absract;
using Ecommerce.Cargo.EtitiyLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Cargo.BusinessLayer.Concrate
{
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerDal _cargoCustomerDal;
        public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
        {
            _cargoCustomerDal = cargoCustomerDal;
        }
        public void TDelete(int id)
        {
            _cargoCustomerDal.Delete(id);
        }
        public List<CargoCustomer> TGetAll()
        {
            return _cargoCustomerDal.GetAll();
        }
        public CargoCustomer TGetById(int id)
        {
            return _cargoCustomerDal.GetById(id);
        }
        public CargoCustomer TGetCargoCustomerById(string id)
        {
            return _cargoCustomerDal.GetCargoCustomerById(id);
        }
        public void TInsert(CargoCustomer entity)
        {
            _cargoCustomerDal.Insert(entity);
        }
        public void TUpdate(CargoCustomer entity)
        {
            _cargoCustomerDal.Update(entity);
        }
    }
}
