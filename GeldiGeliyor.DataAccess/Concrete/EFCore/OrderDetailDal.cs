using GeldiGeliyor.Core.DataAccess;
using GeldiGeliyor.DataAccess.Abstract;
using GeldiGeliyor.DataAccess.Concrete.EFCore.Context;
using GeldiGeliyor.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GeldiGeliyor.DataAccess.Concrete.EFCore
{
    public class OrderDetailDal:RepositoryBase<OrderDetail>,IOrderDetailDal
    {
        public OrderDetailDal(GeldiGeliyorDbContext context):base(context)
        {
            
        }

        public Task<List<OrderDetail>> OrderDetailsWithProduct(Expression<Func<OrderDetail, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetail> OrderDetailWithProduct(Expression<Func<OrderDetail, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
