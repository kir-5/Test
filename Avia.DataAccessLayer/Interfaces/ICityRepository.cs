using Avia.DataAccessLayer.Entities;

namespace Avia.DataAccessLayer.Interfaces
{
    public interface ICityRepository
    {
        List<CityEntity> GetAllCities();
        CityEntity GetCityById(int id);
        CityEntity GetCityByName(string name);
        List<CityEntity> GetCitiesByFilter(string name);
        Task<int> CreateCityAsync(CityEntity city);
        Task UpdateCityAsync(int id, CityEntity city);
        Task DeleteCityAsync(int id);
    }
}
