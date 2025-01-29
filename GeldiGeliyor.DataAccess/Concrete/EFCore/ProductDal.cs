
using GeldiGeliyor.Core.DataAccess;
using GeldiGeliyor.DataAccess.Abstract;
using GeldiGeliyor.DataAccess.Concrete.EFCore.Context;
using GeldiGeliyor.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GeldiGeliyor.DataAccess.Concrete.EFCore
{
    public class ProductDal:RepositoryBase<Product>,IProductDal
    {
        public ProductDal(GeldiGeliyorDbContext context):base(context)
        {
            
        }
        
        public async Task<Product> ProductWithPicturesAndSellerAsync(Expression<Func<Product, bool>> expression)
        {
            return await _set.Include(x=>x.Pictures).Include(x=>x.Seller).FirstOrDefaultAsync(expression);
        }

        public async Task<List<Product>> ProductsWithPicturesAndSellerAsync(Expression<Func<Product, bool>> expression = null)
        {
            return expression!= null? await _set.Include(x=>x.Pictures).Include(x=>x.Seller).Include(x=>x.Category).Where(expression).ToListAsync():await _set.Include(x=>x.Pictures).Include(x=>x.Seller).Include(x=>x.Category).ToListAsync();
        }

        public async Task<List<Product>> ProductsWithPicturesAsync(Expression<Func<Product, bool>> expression=null)
        {
            return expression!= null? await _set.Include(x=>x.Pictures).Where(expression).ToListAsync():await _set.Include(x=>x.Pictures).ToListAsync();
        }

        public async Task<Product> ProductWithPicturesAsync(Expression<Func<Product, bool>> expression)
        {
            return await _set.Include(x => x.Pictures).FirstOrDefaultAsync(expression);
        }
    }
}
