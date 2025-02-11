using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Cargo.BusinessLayer.Absract
{
  
        //Basinda T olan metotlar Businessdan
        //T olmayanlar DataAccesten geliyor.
        public interface IGenericService<T> where T : class
        {
            void TInsert(T entity);
            void TUpdate(T entity);
            void TDelete(int id);
            T TGetById(int id);
            List<T> TGetAll();
        }
    
}
