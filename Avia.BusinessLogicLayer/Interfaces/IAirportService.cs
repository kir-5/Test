using Avia.BusinessLogicLayer.Models;

namespace Avia.BusinessLogicLayer.Interfaces
{
    public interface IAirportService
    {
        List<Airport> GetAllAirports();
        Airport GetAirportById(int id);
        List<Airport> GetAirportsByFilter(string name);
        Task<int> CreateAirportAsync(Airport airport);
        Task UpdateAirportAsync(int id, Airport airport);
        Task DeleteAirportAsync(int id);
        void ValidateAirport(Airport airport);
    }
}
