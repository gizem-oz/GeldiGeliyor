using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.Business.Concrete.Dtos.CategoryDtos;
using GeldiGeliyor.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace GeldiGeliyor.WebUI.Controllers
{
    public class CategoryController(ICategoryService categoryService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<CategoryGetDto> categories = await categoryService.GetCategoriesAsync();
            return View(categories);
        }

   

        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            IResponseResult result=await categoryService.CategoryAddAsync(categoryAddDto);
            
            return result.IsSuccessed ? RedirectToAction("Index") : View();
        }

        [HttpGet]
        public async Task< IActionResult> Update(int id)
        {
            CategoryGetDto categoryGetDto=await categoryService.GetCategoryByIdAsync(id);
            return View(categoryGetDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto) 
        {
            IResponseResult result = await categoryService.CategoryUpdateAsync(categoryUpdateDto);
            return result.IsSuccessed ? RedirectToAction("Index") : View();
        }
        [HttpGet]
        public async Task< IActionResult> Remove(int id)
        {
            IResponseResult result= await categoryService.CategoryRemoveByIdAsync(id);
            return RedirectToAction("Index");
        }

    }
}
