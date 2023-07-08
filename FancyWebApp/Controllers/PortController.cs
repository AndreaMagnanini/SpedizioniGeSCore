using FancyWebApp.Dtos;
using FancyWebApp.Exceptions;
using FancyWebApp.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FancyWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortController : ControllerBase
    {
        private readonly IPortService _portService;

        public PortController(IPortService portService)
        {
            _portService = portService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PortDto>>> Get()
        {
            try
            {
                var ports = await this._portService.Get();
                return Ok(ports);
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

        [HttpGet("{guid:id}")]
        public async Task<ActionResult<PortDto>> Get(Guid id)
        {
            try
            {
                var port = await this._portService.Get(id);
                return Ok(port);
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
