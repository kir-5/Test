using Avia.BusinessLogicLayer.Interfaces;
using Avia.BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirportController : ControllerBase
    {
        private readonly IAirportService _airportService;

        public AirportController(IAirportService airportService)
        {
            _airportService = airportService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllAirports()
        {
            try
            {
                var listAirports = _airportService.GetAllAirports();
                return Ok(listAirports);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAirportById(int id)
        {
            try
            {
                var airport = _airportService.GetAirportById(id);
                return Ok(airport);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("filter/{name}")]
        public IActionResult GetAirportsByFilter(string name)
        {
            try
            {
                var airport = _airportService.GetAirportsByFilter(name);
                return Ok(airport);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAirport([FromBody] Airport airport)
        {
            try
            {
                _airportService.ValidateAirport(airport);
                var id = await _airportService.CreateAirportAsync(airport);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateAirport([FromBody] Airport airport, int id)
        {
            try
            {
                _airportService.ValidateAirport(airport);
                await _airportService.UpdateAirportAsync(id, airport);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteAirport(int id)
        {
            try
            {
                await _airportService.DeleteAirportAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
