using AutoMapper;
using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.Business.Concrete.Dtos.ProductDtos;
using GeldiGeliyor.Business.Concrete.ResultModels;
using GeldiGeliyor.Business.Validations;
using GeldiGeliyor.DataAccess.Abstract;
using GeldiGeliyor.Entities.Concrete;


namespace GeldiGeliyor.Business.Concrete
{
    public class ProductManager(IProductDal productDal, IMapper mapper) : IProductService
    {
        ProductValidator productValidator = new ProductValidator();
        public async Task<ProductGetDto> GetProductByIdAsync(int id)
        {
            Product product = await productDal.GetAsync(x => x.Id == id);
            return mapper.Map<ProductGetDto>(product);
        }

        public async Task<List<ProductGetDto>> GetProductsAsync()
        {
            List<ProductGetDto> productGetDtos = new List<ProductGetDto>();
            IEnumerable<Product> products = await productDal.ProductsWithPicturesAndSellerAsync();
            foreach (Product product in products)
            {
                productGetDtos.Add(new ProductGetDto()
                {
                     Seller = product.Seller,
                      Id = product.Id,
                       UpdateDate = product.UpdateDate,
                        Category = product.Category,
                         CreateDate = product.CreateDate,
                          Description = product.Description,
                           Name = product.Name,
                            Price = product.Price,
                             StockAmount = product.StockAmount,

                });

            }
            return productGetDtos;
        }

        public async Task<IResponseResult> ProductAddAsync(ProductAddDto productAddDto)
        {
            IResponseResult responseResult = new ResponseResult();
            try
            {
                Product product = mapper.Map<Product>(productAddDto);
                var result = productValidator.Validate(product);    
                if(result.IsValid)
                await productDal.AddAsync(product);
                return responseResult;
            }
            catch (Exception ex)
            {
                responseResult.IsSuccessed = false;
                responseResult.Error = ex.Message;
                return responseResult;

            }
        }

        public async Task<IResponseResult> ProductRemoveAsync(int id)
        {
            IResponseResult responseResult = new ResponseResult();
            try
            {
                Product product = await productDal.GetAsync(x => x.Id == id);
                await productDal.DeleteAsync(product);
                return responseResult;

            }
            catch (Exception ex)
            {
                responseResult.IsSuccessed = false;
                responseResult.Error = ex.Message;
                return responseResult;
            }

        }

        public async Task<IResponseResult> ProductUpdateAsync(ProductUpdateDto productUpdateDto)
        {
            IResponseResult responseResult = new ResponseResult();
            try
            {
                Product product = mapper.Map<Product>(productUpdateDto);
                await productDal.UpdateAsync(product);
                return responseResult;
            }
            catch (Exception ex)
            {

                responseResult.IsSuccessed = false;
                responseResult.Error = ex.Message;
                return responseResult;
            }

        }
        // bakılacak
        public async Task<List<ProductGetDto>> ProductsWithPicturesAndSellerAsync()
        {

            List<ProductGetDto> productGetDtos = new List<ProductGetDto>();
            IEnumerable<Product> products = await productDal.ProductsWithPicturesAndSellerAsync();
            foreach (Product product in products)          
                productGetDtos.Add(mapper.Map<ProductGetDto>(product));
            return productGetDtos;

        }
        public async Task<ProductGetDto> ProductWithPicturesAndSellerAsync(int productId)
        {
            
            Product product = await productDal.ProductWithPicturesAndSellerAsync(x => x.Id == productId);
            return mapper.Map<ProductGetDto>(product);
            

        }

        
    }
}
