using GeldiGeliyor.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeldiGeliyor.Business.Abstract
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAllCityAsync();
        Task<City> GetCityByIdAsync(int id);

        Task<bool> AddCityAsync(City city);
        Task<bool> UpdateCityAsync(City city);
        Task<bool> DeleteCityAsync(int id);
    }
}
