using Avia.DataAccessLayer.Entities;

namespace Avia.DataAccessLayer.Interfaces
{
    public interface IAirportRepository
    {
        List<AirportEntity> GetAllAirports();
        AirportEntity GetAirportById(int id);
        AirportEntity GetAirportByName(string name);
        List<AirportEntity> GetAirportsByFilter(string name);
        Task<int> CreateAirportAsync(AirportEntity airport);
        Task UpdateAirportAsync(int id, AirportEntity airport);
        Task DeleteAirportAsync(int id);
    }
}
