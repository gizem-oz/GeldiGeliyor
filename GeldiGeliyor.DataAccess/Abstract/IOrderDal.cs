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
    public interface IOrderDal:IRepositoryBase<Order>
    {
        Task<Order> OrderWithAllAsync(Expression<Func<Order, bool>> expression);
        Task<List< Order>> OrdersWithAllAsync(Expression<Func<Order, bool>> expression=null);
    }
}
