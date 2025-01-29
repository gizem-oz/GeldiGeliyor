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
    public class OrderDal : RepositoryBase<Order>, IOrderDal
    {
        public OrderDal(GeldiGeliyorDbContext context):base(context)
        {
            
        }
        public async Task<List<Order>> OrdersWithAllAsync(Expression<Func<Order, bool>> expression = null)
        {
            return expression != null ? await _set.Include(x => x.OrderDetails).ThenInclude(x => x.Product).Include(x => x.Customer).Where(expression).ToListAsync() : await _set.Include(x => x.OrderDetails).ThenInclude(x => x.Product).Include(x => x.Customer).ToListAsync();
        }

        public async Task<Order> OrderWithAllAsync(Expression<Func<Order, bool>> expression)
        {
            return await _set.Include(x => x.OrderDetails).ThenInclude(x => x.Product).Include(x => x.Customer).FirstOrDefaultAsync(expression);
        }
    }
}
