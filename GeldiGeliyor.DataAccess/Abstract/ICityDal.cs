using GeldiGeliyor.Core.DataAccess;
using GeldiGeliyor.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GeldiGeliyor.DataAccess.Abstract
{
    public interface ICityDal:IRepositoryBase<City>
    {
        // sehiri müsteri ile getirecegiz
        Task<City> CityWithCustomersAsync(Expression<Func<City,bool>>expression);
        // sehirler müsteri ile getirecegiz

        Task<List<City>> CitiesWithCustomersAsync(Expression<Func<City, bool>> expression=null);
    }
}
