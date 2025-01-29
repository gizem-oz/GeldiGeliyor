using GeldiGeliyor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GeldiGeliyor.Core.DataAccess
{
    public interface IRepositoryBase<T> where T : class,IEntity,new()
    {
        Task<T> GetAsync(Expression<Func<T,bool>> expression);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T,bool>> expression=null);
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(T[] entities);
        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteRangeAsync(T[] entities);
        Task<bool> UpdateAsync(T entity);
        Task<bool> UpdateRangeAsync(T[] entities);
    }
}
