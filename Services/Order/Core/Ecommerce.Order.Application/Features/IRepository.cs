using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Order.Application.Features
{
    public  interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<T> CreatAsync(T entity);

        Task<T> UpdateAsync(T entity);
        
        Task<T> DeleteAsync(int id);

        Task<T> GetByFilterAsync(Expression<Func<T, bool>>filter);
        //T giriş değerim ve bool türünde true false gibi çıkış değerim var
        //filter içinde tutuyorum


    }
}
