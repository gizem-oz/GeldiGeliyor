using GeldiGeliyor.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GeldiGeliyor.Core.DataAccess
{
    public class RepositoryBase<T>(DbContext db) : IRepositoryBase<T> where T : class, IEntity, new()
    {
        protected DbSet<T> _set = db.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            await _set.AddAsync(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddRangeAsync(T[] entities)
        {
            await _set.AddRangeAsync(entities);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _set.Remove(entity);

            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteRangeAsync(T[] entities)
        {
            _set.RemoveRange(entities);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
          => expression == null ? _set : _set.Where(expression);


        public Task<T> GetAsync(Expression<Func<T, bool>> expression)
         => _set.FirstOrDefaultAsync(expression);


        public async Task<bool> UpdateAsync(T entity)
        {
            _set.Update(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateRangeAsync(T[] entities)
        {
            _set.UpdateRange(entities);
            return await db.SaveChangesAsync() > 0;
        }
    }
}
