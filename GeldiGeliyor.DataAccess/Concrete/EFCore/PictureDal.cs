using GeldiGeliyor.Core.DataAccess;
using GeldiGeliyor.DataAccess.Abstract;
using GeldiGeliyor.DataAccess.Concrete.EFCore.Context;
using GeldiGeliyor.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace GeldiGeliyor.DataAccess.Concrete.EFCore
{
    public class PictureDal : RepositoryBase<Picture>, IPictureDal
    {
        public PictureDal(GeldiGeliyorDbContext context): base(context)
        {
            
        }

        public async Task<List<Picture>> PicturesWithProductsAsync(Expression<Func<Picture, bool>> expression = null)
        { 
        return expression != null ? 
            await _set.Include(x => x.Product).Where(expression).ToListAsync() : await _set.Include(x => x.Product).ToListAsync();
        }

        public async Task<Picture> PictureWithProductsAsync(Expression<Func<Picture, bool>> expression)
        {
            return await _set.Include(x => x.Product).FirstOrDefaultAsync(expression);
        }

    }
}
