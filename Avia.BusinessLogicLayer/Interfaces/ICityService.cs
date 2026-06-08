using Avia.BusinessLogicLayer.Models;

namespace Avia.BusinessLogicLayer.Interfaces
{
    public interface ICityService
    {
        List<City> GetAllCities();
        City GetCityById(int id);
        List<City> GetCitiesByFilter(string name);
        Task<int> CreateCityAsync(City city);
        Task UpdateCityAsync(int id, City city);
        Task DeleteCityAsync(int id);
        void ValidateCity(City city);
    }
}
