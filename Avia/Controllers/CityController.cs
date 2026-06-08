using Avia.BusinessLogicLayer.Interfaces;
using Avia.BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllCities()
        {
            try
            {
                var listCities = _cityService.GetAllCities();
                return Ok(listCities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("id/{id}")]
        public IActionResult GetCityById(int id)
        {
            try
            {
                var city = _cityService.GetCityById(id);
                return Ok(city);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("filter/{name}")]
        public IActionResult GetCitiesByFilter(string name)
        {
            try
            {
                var city = _cityService.GetCitiesByFilter(name);
                return Ok(city);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateCity([FromBody] City city)
        {
            try
            {
                _cityService.ValidateCity(city);
                var id = await _cityService.CreateCityAsync(city);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateCity([FromBody] City city, int id)
        {
            try
            {
                _cityService.ValidateCity(city);
                await _cityService.UpdateCityAsync(id, city);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            try
            {
                await _cityService.DeleteCityAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
