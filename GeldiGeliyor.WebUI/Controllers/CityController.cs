using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.DataAccess.Abstract;
using GeldiGeliyor.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace GeldiGeliyor.WebUI.Controllers
{
    public class CityController(ICityService cityService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            IEnumerable<City> cities = await cityService.GetAllCityAsync();
            return View(cities);
        }

        [HttpGet]
        public async Task<IActionResult> Create( )
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(City city)
        {
           bool response  = await cityService.AddCityAsync(city);
            return response ? RedirectToAction("Index") : View();
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            City city = await cityService.GetCityByIdAsync(id);
            return View(city);
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {  
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(City city)
        {
            await cityService.UpdateCityAsync(city);
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
          await cityService.DeleteCityAsync(id);
            return View();
        }
        





    }
}
