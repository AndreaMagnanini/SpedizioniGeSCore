using FancyWebApp.Dtos;
using FancyWebApp.Exceptions;
using FancyWebApp.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FancyWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LocationDto>>> Get()
        {
            try
            {
                var locations = await this._locationService.Get();
                return this.Ok(locations);
            }
            catch (NotFoundException ex)
            {
                return this.NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return this.Problem(ex.Message);
            }
        }

        [HttpGet("{guid:id}")]
        public async Task<ActionResult<LocationDto>> Get(Guid id)
        {
            try
            {
                var location = await this._locationService.Get(id);
                return this.Ok(location);
            }
            catch (NotFoundException ex)
            {
                return this.NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return this.Problem(ex.Message);
            }
        }
    }
}
