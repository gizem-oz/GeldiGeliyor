using GeldiGeliyor.Business.Concrete.Dtos.CategoryDtos;
using GeldiGeliyor.DataAccess.Abstract;
using GeldiGeliyor.Entities.Concrete;

namespace GeldiGeliyor.Business.Abstract
{
    public interface ICategoryService
    {
        Task<CategoryGetDto> GetCategoryByIdAsync(int id);
        Task<List<CategoryGetDto>> GetCategoriesAsync();
        Task<CategoryWithProductsGetDto> GetCategoryWithProductsAsync(int categoryId);
        Task<List<CategoryWithProductsGetDto>> GetCategoriesWithProductsAsync();
        Task<IResponseResult> CategoryUpdateAsync(CategoryUpdateDto categoryUpdateDto);
        Task<IResponseResult> CategoryAddAsync(CategoryAddDto categoryAddDto);
        Task<IResponseResult> CategoryRemoveByIdAsync(int id);
    }
}
