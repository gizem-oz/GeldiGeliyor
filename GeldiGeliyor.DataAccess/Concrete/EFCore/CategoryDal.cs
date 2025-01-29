using GeldiGeliyor.Core.DataAccess;
using GeldiGeliyor.DataAccess.Abstract;
using GeldiGeliyor.DataAccess.Concrete.EFCore.Context;
using GeldiGeliyor.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GeldiGeliyor.DataAccess.Concrete.EFCore
{
    public class CategoryDal : RepositoryBase<Category>, ICategoryDal
    {
        public CategoryDal(GeldiGeliyorDbContext context):base(context)
        {
            
        }

       

        public async Task<List<Category>> CategoriesWithProductsAsync(Expression<Func<Category, bool>> expression = null)
        {
            return  expression==null ? 
                await _set.Include(x=>x.Products).ToListAsync(): await _set.Include(x => x.Products).Where(expression).ToListAsync();
        }

        public async Task<Category> CategoryWithProductsAsync(Expression<Func<Category, bool>> expression)
        {
            return await _set.Include(x => x.Products).FirstOrDefaultAsync(expression);
        }
    }
}
