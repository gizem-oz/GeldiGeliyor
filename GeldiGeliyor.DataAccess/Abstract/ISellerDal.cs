using GeldiGeliyor.Core.DataAccess;
using GeldiGeliyor.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace GeldiGeliyor.DataAccess.Abstract
{
    public interface ISellerDal:IRepositoryBase<Seller>
    {
        Task<Seller> SellerWithProductAsync(Expression<Func<Seller, bool>> expression);
        Task<List< Seller>> SellersWithProductAsync(Expression<Func<Seller, bool>> expression =null);
    }
}
