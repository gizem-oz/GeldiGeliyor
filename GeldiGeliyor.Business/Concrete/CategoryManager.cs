using AutoMapper;
using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.Business.Concrete.Dtos.CategoryDtos;
using GeldiGeliyor.Business.Concrete.ResultModels;
using GeldiGeliyor.Business.Validations;
using GeldiGeliyor.DataAccess.Abstract;
using GeldiGeliyor.Entities.Concrete;

namespace GeldiGeliyor.Business.Concrete
{
    public class CategoryManager(ICategoryDal categoryDal, IMapper mapper) : ICategoryService

    {
        CategoryValidator categoryValidator = new CategoryValidator();
        public async Task<IResponseResult> CategoryAddAsync(CategoryAddDto categoryAddDto)
        {
            IResponseResult responseResult = new ResponseResult();
            try
            {
                Category category = mapper.Map<Category>(categoryAddDto);
                //var result = categoryValidator.Validate(category);
                //if (result.IsValid) 
                await categoryDal.AddAsync(category);
                return responseResult;
            }
            catch (Exception ex)
            {
                responseResult.Error = ex.Message;
                responseResult.IsSuccessed = false;
                return responseResult;
            }
        }

        public async Task<IResponseResult> CategoryRemoveByIdAsync(int id)
        {
            IResponseResult responseResult = new ResponseResult();
            try
            {
                Category category = await categoryDal.GetAsync(x => x.Id == id);
                await categoryDal.DeleteAsync(category);
                return responseResult;
            }
            catch (Exception ex)
            {
                responseResult.IsSuccessed = false;
                responseResult.Error = ex.Message;
                return responseResult;
            }
        }

        public async Task<IResponseResult> CategoryUpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            IResponseResult responseResult = new ResponseResult();
            try
            {
                Category category = mapper.Map<Category>(categoryUpdateDto);
                await categoryDal.UpdateAsync(category);
                return responseResult;
            }
            catch (Exception ex)
            {
                responseResult.IsSuccessed = false;
                responseResult.Error = ex.Message;
                return responseResult;
            }
        }

        public async Task<List<CategoryGetDto>> GetCategoriesAsync()
        {
            List<CategoryGetDto> categoryGetDtos = new List<CategoryGetDto>();
            IEnumerable<Category> categories = await categoryDal.GetAllAsync();
            foreach (Category category in categories)           
                     categoryGetDtos.Add(mapper.Map<CategoryGetDto>(category));
            return categoryGetDtos;
        }

        public async Task<CategoryWithProductsGetDto> GetCategoryWithProductsAsync(int categoryId)
        {
            Category category = await categoryDal.CategoryWithProductsAsync(x => x.Id == categoryId);
            return mapper.Map<CategoryWithProductsGetDto>(category);
        }

        public async Task<CategoryGetDto> GetCategoryByIdAsync(int id)
        {
            Category category = await categoryDal.GetAsync(x => x.Id == id);
            CategoryGetDto categoryGetDto = new CategoryGetDto()
            {
                 CreateDate = category.CreateDate,               
                   Description = category.Description,
                    Id = category.Id,
                     Name = category.Name,
                      Status = category.Status,
                       
            };
            return categoryGetDto;
        }

        public async Task<List<CategoryWithProductsGetDto>> GetCategoriesWithProductsAsync()
        {
            List<CategoryWithProductsGetDto> categoryWithProductsGetDtos = new List<CategoryWithProductsGetDto>();
            IEnumerable<Category> categories = await categoryDal.GetAllAsync();
            foreach (var item in categories)
                categoryWithProductsGetDtos.Add(mapper.Map<CategoryWithProductsGetDto>(item));
            return categoryWithProductsGetDtos;
        }
    }
}
