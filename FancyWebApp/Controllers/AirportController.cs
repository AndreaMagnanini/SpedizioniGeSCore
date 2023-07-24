using FancyWebApp.Dtos;
using FancyWebApp.Exceptions;
using FancyWebApp.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FancyWebApp.Controllers
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
        public async Task<ActionResult<List<AirportDto>>> Get()
        {
            try
            {
                var airports = await this._airportService.Get();
                return Ok(airports);
            }
            catch (NotFoundException ex)
            {
                return this.Problem(ex.Message);
            }
            catch (Exception ex)
            {
                return this.Problem(ex.Message);
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<AirportDto>> Get(Guid id)
        {
            try
            {
                var airport = await this._airportService.Get(id);
                return Ok(airport);
            }
            catch (NotFoundException ex)
            {
                return this.Problem(ex.Message);
            }
            catch (Exception ex)
            {
                return this.Problem(ex.Message);
            }
        }
    }
}
