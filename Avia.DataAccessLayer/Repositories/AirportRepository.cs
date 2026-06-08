using Avia.DataAccessLayer.Contexts;
using Avia.DataAccessLayer.Entities;
using Avia.DataAccessLayer.Interfaces;

namespace Avia.DataAccessLayer.Repositories
{
    public class AirportRepository : IAirportRepository
    {
        public List<AirportEntity> GetAllAirports()
        {
            try
            {
                using (var db = new AviaContext())
                {
                    var listAirports = db.Airports.ToList();
                    return listAirports;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public AirportEntity GetAirportById(int id)
        {
            try
            {
                using (var db = new AviaContext())
                {
                    var airport = db.Airports.Where(w => w.Id == id).FirstOrDefault();
                    return airport;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public AirportEntity GetAirportByName(string name)
        {
            try
            {
                using (var db = new AviaContext())
                {
                    var airport = db.Airports.Where(w => w.Name == name).FirstOrDefault();
                    return airport;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<AirportEntity> GetAirportsByFilter(string name)
        {
            try
            {
                using (var db = new AviaContext())
                {
                    var listAirports = db.Airports.Where(w => w.Name.Contains(name)).ToList();
                    return listAirports;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> CreateAirportAsync(AirportEntity airport)
        {
            try
            {
                using (var db = new AviaContext())
                {
                    db.Airports.Add(airport);
                    await db.SaveChangesAsync();
                    return airport.Id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAirportAsync(int id, AirportEntity airport)
        {
            try
            {
                using (var db = new AviaContext())
                {
                    var airportResponse = db.Airports.Where(w => w.Id == id).FirstOrDefault();
                    airportResponse.Code = airport.Code;
                    airportResponse.Name = airport.Name;
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAirportAsync(int id)
        {
            try
            {
                using (var db = new AviaContext())
                {
                    var airport = db.Airports.Where(w => w.Id == id).FirstOrDefault();
                    db.Airports.Remove(airport);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
