using GeldiGeliyor.Core.DataAccess;
using GeldiGeliyor.Entities.Concrete;
using System.Linq.Expressions;


namespace GeldiGeliyor.DataAccess.Abstract
{
    public interface IOrderDetailDal : IRepositoryBase<OrderDetail>
    {
        Task<List<OrderDetail>> OrderDetailsWithProduct(Expression<Func<OrderDetail, bool>> expression = null);
        Task<OrderDetail> OrderDetailWithProduct(Expression<Func<OrderDetail, bool>> expression);
    }
}