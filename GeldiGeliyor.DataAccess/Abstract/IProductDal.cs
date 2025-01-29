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
    public interface IProductDal:IRepositoryBase<Product>
    {
        Task<Product> ProductWithPicturesAndSellerAsync(Expression<Func<Product, bool>> expression);
        Task<List<Product>> ProductsWithPicturesAndSellerAsync(Expression<Func<Product, bool>> expression = null);
        Task<List<Product>> ProductsWithPicturesAsync(Expression<Func<Product, bool>> expression=null);
        Task<Product> ProductWithPicturesAsync(Expression<Func<Product, bool>> expression);
    }
}
