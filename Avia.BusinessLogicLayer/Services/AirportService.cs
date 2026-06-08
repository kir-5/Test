using AutoMapper;
using Avia.BusinessLogicLayer.Interfaces;
using Avia.BusinessLogicLayer.Models;
using Avia.BusinessLogicLayer.Validator;
using Avia.DataAccessLayer.Entities;
using Avia.DataAccessLayer.Interfaces;

namespace Avia.BusinessLogicLayer.Services
{
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository _airportRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public AirportService(IAirportRepository airportRepository, ICityRepository cityRepository, IMapper mapper)
        {
            _airportRepository = airportRepository;
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public List<Airport> GetAllAirports()
        {
            var listAirportEntities = _airportRepository.GetAllAirports();
            var listAirports = _mapper.Map<List<AirportEntity>, List<Airport>>(listAirportEntities);
            return listAirports;
        }

        public Airport GetAirportById(int id)
        {
            var airportEntitie = _airportRepository.GetAirportById(id);
            var airport = _mapper.Map<AirportEntity, Airport>(airportEntitie);
            return airport;
        }

        public List<Airport> GetAirportsByFilter(string name)
        {
            var listAirportEntities = _airportRepository.GetAirportsByFilter(name);
            var listAirports = _mapper.Map<List<AirportEntity>, List<Airport>>(listAirportEntities);
            return listAirports;
        }

        public async Task<int> CreateAirportAsync(Airport airport)
        {
            var airportEntitie = _mapper.Map<Airport, AirportEntity>(airport);
            var city = _cityRepository.GetCityById(airport.CityId);
            if (city == null)
            {
                throw new Exception($"Аэропорт с идентификатором {airport.CityId} отсутствует");
            }
            var oldAirport = _airportRepository.GetAirportByName(airport.Name);
            if (oldAirport != null)
            {
                throw new Exception($"Аэропорт с именем {airport.Name} уже существует");
            }
            var id = await _airportRepository.CreateAirportAsync(airportEntitie);
            return id;
        }

        public async Task UpdateAirportAsync(int id, Airport airport)
        {
            var airportEntity = _mapper.Map<Airport, AirportEntity>(airport);
            var city = _cityRepository.GetCityById(airport.CityId);
            if (city == null)
            {
                throw new Exception($"Аэропорт с идентификатором {airport.CityId} отсутствует");
            }
            var oldAirport = _airportRepository.GetAirportByName(airport.Name);
            if (oldAirport != null)
            {
                throw new Exception($"Аэропорт с именем {airport.Name} уже существует");
            }
            await _airportRepository.UpdateAirportAsync(id, airportEntity);
        }

        public async Task DeleteAirportAsync(int id)
        {
            await _airportRepository.DeleteAirportAsync(id);
        }

        public void ValidateAirport(Airport airport)
        {
            var validator = new AirportValidator();
            var validatorResult = validator.Validate(airport);
            if (!validatorResult.IsValid)
            {
                throw new Exception(string.Join(", ", validatorResult.Errors));
            }
        }
    }
}
