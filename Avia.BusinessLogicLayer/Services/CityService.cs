using AutoMapper;
using Avia.BusinessLogicLayer.Interfaces;
using Avia.BusinessLogicLayer.Models;
using Avia.BusinessLogicLayer.Validator;
using Avia.DataAccessLayer.Entities;
using Avia.DataAccessLayer.Interfaces;

namespace Avia.BusinessLogicLayer.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public List<City> GetAllCities()
        {
            var listCityEntities = _cityRepository.GetAllCities();
            var listCities = _mapper.Map<List<CityEntity>, List<City>>(listCityEntities);
            return listCities;
        }

        public City GetCityById(int id)
        {
            var cityEntitie = _cityRepository.GetCityById(id);
            var city = _mapper.Map<CityEntity, City>(cityEntitie);
            return city;
        }

        public List<City> GetCitiesByFilter(string name)
        {
            var listCityEntities = _cityRepository.GetCitiesByFilter(name);
            var listCities = _mapper.Map<List<CityEntity>, List<City>>(listCityEntities);
            return listCities;
        }

        public async Task<int> CreateCityAsync(City city)
        {
            var cityEntitie = _mapper.Map<City, CityEntity>(city);
            var oldCity = _cityRepository.GetCityByName(city.Name);
            if (oldCity != null)
            {
                throw new Exception($"Город с названием {city.Name} уже существует");
            }
            var id = await _cityRepository.CreateCityAsync(cityEntitie);
            return id;
        }

        public async Task UpdateCityAsync(int id, City city)
        {
            var cityEntity = _mapper.Map<City, CityEntity>(city);
            var oldCity = _cityRepository.GetCityByName(city.Name);
            if (oldCity != null)
            {
                throw new Exception($"Город с названием {city.Name} уже существует");
            }
            await _cityRepository.UpdateCityAsync(id, cityEntity);
        }

        public async Task DeleteCityAsync(int id)
        {
            await _cityRepository.DeleteCityAsync(id);
        }

        public void ValidateCity(City city)
        {
            var validator = new CityValidator();
            var validatorResult = validator.Validate(city);
            if (!validatorResult.IsValid)
            {
                throw new Exception(string.Join(", ", validatorResult.Errors));
            }
        }
    }
}
