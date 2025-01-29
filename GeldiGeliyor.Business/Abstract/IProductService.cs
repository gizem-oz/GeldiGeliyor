using GeldiGeliyor.Business.Concrete.Dtos.ProductDtos;


namespace GeldiGeliyor.Business.Abstract
{
    public interface IProductService
    {
        
        Task<List<ProductGetDto>> ProductsWithPicturesAndSellerAsync();
       
        Task<ProductGetDto> ProductWithPicturesAndSellerAsync(int productId);
        Task<ProductGetDto> GetProductByIdAsync(int id);
        Task<List<ProductGetDto>> GetProductsAsync();
        Task<IResponseResult> ProductUpdateAsync(ProductUpdateDto productUpdateDto);
        Task<IResponseResult> ProductAddAsync(ProductAddDto productAddDto);
        Task<IResponseResult> ProductRemoveAsync(int id);//burayı sadece seller kaldırabilir şeklinde yetkilendirme verelim?
    }
}
