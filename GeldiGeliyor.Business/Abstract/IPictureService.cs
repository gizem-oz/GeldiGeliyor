using GeldiGeliyor.Business.Concrete.Dtos.CategoryDtos;

namespace GeldiGeliyor.Business.Abstract
{
    public interface IPictureService
    {
        Task<IResponseResult> PictureAddAsync(PictureAddDto pictureAddDto);
        Task<IResponseResult> PictureRemoveByIdAsync(int id);
        Task<IResponseResult> PictureUpdateAsync(PictureUpdateDto pictureUpdateDto);
        Task<List<PictureGetDto>> GetPicturesAsync();
        Task<PictureWithProductDto> GetPictureWithProductAsync(int productId);
        Task<PictureGetDto> GetPictureByIdAsync(int id);
        Task<List<PictureWithProductDto>> PicturesWithProductsAsync();
    }
}
