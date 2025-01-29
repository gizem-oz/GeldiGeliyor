using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.Business.Concrete.Dtos.ProductDtos;
using GeldiGeliyor.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace GeldiGeliyor.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController(IProductService productService,ICategoryService categoryService) : Controller
    {
        public async Task <IActionResult> Index()
        {
            List<ProductGetDto> products = await productService.GetProductsAsync();
            return View(products);
           
        }
        public async Task<IActionResult> Detail(int id)
        {
            ProductGetDto productGetDto = await productService.GetProductByIdAsync(id);
            return View(productGetDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ProductGetDto productGetDto = await productService.GetProductByIdAsync(id);
            return View(productGetDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            IResponseResult result = await productService.ProductUpdateAsync(productUpdateDto);
            if (result.IsSuccessed)
                return RedirectToAction("Detail", new { id = productUpdateDto.Id });
            return View(productUpdateDto);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await categoryService.GetCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductAddDto productAddDto, List<IFormFile> formFiles)
        {
            if (formFiles.Count > 0)
            {
                //base64 format
                foreach (var file in formFiles)
                {
                    string uzanti = Path.GetExtension(file.FileName);
                    if (uzanti == ".jpg" || uzanti == ".jpeg" || uzanti == ".png" || uzanti == ".svg" || uzanti == ".gif")
                    {
                        var stream = new MemoryStream();
                        file.CopyTo(stream);
                        byte[] bytes = stream.ToArray();
                        string resim = Convert.ToBase64String(bytes);
                        productAddDto.Pictures.Add(resim);

                    }
                }
            }


            //WWWROOT klasoru altına yollanılan tüm resimleri direkt alır.
            foreach (var file in formFiles)
            {
                //GetExtension : Uzantısıyla gelen dosya adı uzerinden uzantıyı noktada dahil olacak sekilde alır.
                string uzanti = Path.GetExtension(file.FileName);
                if (uzanti == ".jpg" || uzanti == ".jpeg" || uzanti == ".png" || uzanti == ".svg" || uzanti == ".gif")
                {
                    //combine : tum yolları birleştirir.x/y/z gibi
                    //GetCurrentDirectory : ana dizini temsil eder.
                    //Guid : benzersiz anahtar üretir.
                    //GetFileName : gelen dosyanın uzantısıyla birlikte adını alır.
                    //CopyTo: hafızadakini kopyalar ve kayıt eder.
                    string yol = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", Guid.NewGuid().ToString() + Path.GetFileName(file.FileName));
                    var stream = new FileStream(yol, FileMode.Create);
                    file.CopyTo(stream);

                }
            }


            var service = HttpContext.RequestServices.GetService<IAuthService>();
            productAddDto.SellerId = service.SellerGetDtoByUsernameAsync(User.Identity.Name).Result.Id;
            IResponseResult result = await productService.ProductAddAsync(productAddDto);
            if (result.IsSuccessed)
                return RedirectToAction("Index");
            return View(productAddDto);
        }

        [HttpGet]  
        public async Task<IActionResult> Remove(int id)
        {
            IResponseResult result = await productService.ProductRemoveAsync(id);
            return View(result);
        }
    }
}