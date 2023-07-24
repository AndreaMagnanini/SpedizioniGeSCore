using FancyWebApp.Dtos;
using FancyWebApp.Exceptions;
using FancyWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FancyWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        public List<EventDto> events = new List<EventDto>()
        {
            new EventDto
            {
                Description = "2023 Australian GP",
                Location = new LocationDto
                {
                    Name = "Melbourne",
                    Address = null,
                    Nation = null,
                    City = null
                },
                ExtraEU = true,
                Alias = "AUSGP",
                EventNumber = null,
                Start = DateTime.Today,
                End = DateTime.Today
            },
            new EventDto
            {
                Description =  "2023 Belgian GP",
                Location = new LocationDto
                {
                    Name = "Spa-Francorchamps",
                    Address = null,
                    Nation = null,
                    City = null
                },
                ExtraEU = false,
                Alias = "BELGP",
                EventNumber = null,
                Start = DateTime.Today,
                End = DateTime.Today

            },
            new EventDto
            {
                Description =  "2023 Italian GP",
                Location = new LocationDto
                {
                    Name = "Monza",
                    Address = null,
                    Nation = null,
                    City = null
                },
                ExtraEU = false,
                Alias = "ITAGP",
                EventNumber = null,
                Start = DateTime.Today,
                End = DateTime.Today
            },
            new EventDto
            {
                Description =  "2023 Saudi Arabia GP",
                Location = new LocationDto
                {
                    Name = "Jeddah",
                    Address = null,
                    Nation = null,
                    City = null
                },
                ExtraEU = true,
                Alias = "SARGP",
                EventNumber = null,
                Start = DateTime.Today,
                End = DateTime.Today
            },
            new EventDto
            {
                Description =  "2023 Singapore GP",
                Location = null,
                ExtraEU = true,
                Alias = "SINGP",
                EventNumber = null,
                Start = DateTime.Today,
                End = DateTime.Today
            },

        };

        [HttpGet]
        public async Task<ActionResult<List<EventDto>>> Get()
        {
            try
            {
                //var ports = await this._portService.Get();
                return Ok(events);
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

        [HttpGet("{year:int}")]
        public async Task<ActionResult<List<EventDto>>> Get(int year)
        {
            try
            {
                //var port = await this._portService.Get(id);
                return Ok(events);
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
