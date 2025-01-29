using GeldiGeliyor.Core.DataAccess;
using GeldiGeliyor.DataAccess.Abstract;
using GeldiGeliyor.DataAccess.Concrete.EFCore.Context;
using GeldiGeliyor.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GeldiGeliyor.DataAccess.Concrete.EFCore
{
    public class CityDal:RepositoryBase<City>,ICityDal
    {
        public CityDal(GeldiGeliyorDbContext context):base(context)
        {
            
        }

        public async Task<List<City>> CitiesWithCustomersAsync(Expression<Func<City, bool>> expression = null)
        {
            return expression != null ? await _set.Include(x => x.Customers).Where(expression).ToListAsync() : await
                _set.Include(x => x.Customers).ToListAsync();
        }

        public async Task<City> CityWithCustomersAsync(Expression<Func<City, bool>> expression )
        {
            return await _set.Include(x => x.Customers).FirstOrDefaultAsync(expression);
        }
    }
}
