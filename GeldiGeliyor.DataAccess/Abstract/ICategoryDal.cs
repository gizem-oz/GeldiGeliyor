

using GeldiGeliyor.Core.DataAccess;
using GeldiGeliyor.Entities.Concrete;
using System.Linq.Expressions;

namespace GeldiGeliyor.DataAccess.Abstract
{
    public interface ICategoryDal:IRepositoryBase<Category>
    {
        Task<Category> CategoryWithProductsAsync(Expression<Func<Category, bool>> expression);
        Task<List<Category>> CategoriesWithProductsAsync(Expression<Func<Category, bool>> expression = null);
    }
}
