using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.Business.Concrete.Dtos.ProductDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeldiGeliyor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [Authorize(Roles = "Seller")]
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            List<ProductGetDto> products = await productService.GetProductsAsync();
            var x = products.Select(x => new
            {
                x.Name,
                x.Price,
                x.Description,
                x.CreateDate,
                x.UpdateDate
            });

            return products is not null ? Ok(x) : NotFound();
        }
    }
}
