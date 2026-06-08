using Avia.DataAccessLayer.Contexts;
using Avia.DataAccessLayer.Entities;
using Avia.DataAccessLayer.Interfaces;

namespace Avia.DataAccessLayer.Repositories
{
    public class CityRepository : ICityRepository
    {
        public List<CityEntity> GetAllCities()
        {
            try
            {
                using (var db = new AviaContext())
                {
                    var listCities = db.Cities.ToList();
                    return listCities;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CityEntity GetCityById(int id)
        {
            try
            {
                using (var db = new AviaContext())
                {
                    var city = db.Cities.Where(w => w.Id == id).FirstOrDefault();
                    return city;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CityEntity GetCityByName(string name)
        {
            try
            {
                using (var db = new AviaContext())
                {
                    var city = db.Cities.Where(w => w.Name == name).FirstOrDefault();
                    return city;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CityEntity> GetCitiesByFilter(string name)
        {
            try
            {
                using (var db = new AviaContext())
                {
                    var listCities = db.Cities.Where(w => w.Name.Contains(name)).ToList();
                    return listCities;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> CreateCityAsync(CityEntity city)
        {
            try
            {
                using (var db = new AviaContext())
                {
                    db.Cities.Add(city);
                    await db.SaveChangesAsync();
                    return city.Id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateCityAsync(int id, CityEntity city)
        {
            try
            {
                using (var db = new AviaContext())
                {
                    var cityResponse = db.Cities.Where(w => w.Id == id).FirstOrDefault();
                    cityResponse.Code = city.Code;
                    cityResponse.Name = city.Name;
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteCityAsync(int id)
        {
            try
            {
                using (var db = new AviaContext())
                {
                    var city = db.Cities.Where(w => w.Id == id).FirstOrDefault();
                    db.Cities.Remove(city);
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
