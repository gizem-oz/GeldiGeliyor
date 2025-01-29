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
    public class CustomerDal : RepositoryBase<Customer>, ICustomerDal
    {
        public CustomerDal(GeldiGeliyorDbContext context):base(context)
        {
            
        }

        public async Task<List<Customer>> AllCustomerOrdersAsync(Expression<Func<Customer, bool>> expression = null)
        {
            return expression != null ? await _set.Include(x => x.Orders).ThenInclude(x => x.OrderDetails).ThenInclude(x => x.Product).Where(expression).ToListAsync() : await _set.Include(x => x.Orders).ThenInclude(x => x.OrderDetails).ThenInclude(x => x.Product).ToListAsync();
        }

        public async Task<Customer> CustomerOrdersAsync(Expression<Func<Customer, bool>> expression)
        {
            return await _set.Include(x => x.Orders).ThenInclude(x => x.OrderDetails).ThenInclude(x => x.Product).FirstOrDefaultAsync(expression);
        }
    }
}
