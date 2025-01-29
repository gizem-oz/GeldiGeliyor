using GeldiGeliyor.Core.DataAccess;
using GeldiGeliyor.Entities.Concrete;
using System.Linq.Expressions;


namespace GeldiGeliyor.DataAccess.Abstract
{
    public interface IPictureDal : IRepositoryBase<Picture>
    {
        Task<List<Picture>> PicturesWithProductsAsync(Expression<Func<Picture, bool>> expression = null);
        Task<Picture> PictureWithProductsAsync(Expression<Func<Picture, bool>> expression );
    }
}
