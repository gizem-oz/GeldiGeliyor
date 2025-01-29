using AutoMapper;
using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.Business.Concrete.Dtos.ProductDtos;
using GeldiGeliyor.Business.Concrete.ResultModels;
using GeldiGeliyor.DataAccess.Abstract;
using GeldiGeliyor.DataAccess.Concrete.EFCore;
using GeldiGeliyor.Entities.Concrete;

namespace GeldiGeliyor.Business.Concrete
{
    public class CityManager(ICityDal cityDal) : ICityService
    {
        public Task<bool> AddCityAsync(City city)
        {
            return cityDal.AddAsync(city);
        }

        public async Task<bool> DeleteCityAsync(int id)
        {
            City city = await cityDal.GetAsync(x => x.Id == id);
             bool deleteCity = await cityDal.DeleteAsync(city);
            return deleteCity;
            

        }

        public async Task<IEnumerable<City>> GetAllCityAsync()
        {
            List<City> cities = new List<City>();

            return   await cityDal.GetAllAsync();
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            return await cityDal.GetAsync(x=>x.Id==id);
        }

        public async Task<bool> UpdateCityAsync(City city)
        {
            return await cityDal.UpdateAsync(city);
        }
    }
}
