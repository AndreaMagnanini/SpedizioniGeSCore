// <copyright file="EventController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Controllers
{
    using FancyWebApp.Dtos;
    using FancyWebApp.Exceptions;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The event controller.
    /// </summary>
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
                    City = null,
                },
                ExtraEu = true,
                Alias = "AUSGP",
                EventNumber = null,
                Start = DateTime.Today,
                End = DateTime.Today,
            },
            new EventDto
            {
                Description = "2023 Belgian GP",
                Location = new LocationDto
                {
                    Name = "Spa-Francorchamps",
                    Address = null,
                    Nation = null,
                    City = null,
                },
                ExtraEu = false,
                Alias = "BELGP",
                EventNumber = null,
                Start = DateTime.Today,
                End = DateTime.Today,

            },
            new EventDto
            {
                Description = "2023 Italian GP",
                Location = new LocationDto
                {
                    Name = "Monza",
                    Address = null,
                    Nation = null,
                    City = null,
                },
                ExtraEu = false,
                Alias = "ITAGP",
                EventNumber = null,
                Start = DateTime.Today,
                End = DateTime.Today,
            },
            new EventDto
            {
                Description = "2023 Saudi Arabia GP",
                Location = new LocationDto
                {
                    Name = "Jeddah",
                    Address = null,
                    Nation = null,
                    City = null,
                },
                ExtraEu = true,
                Alias = "SARGP",
                EventNumber = null,
                Start = DateTime.Today,
                End = DateTime.Today,
            },
            new EventDto
            {
                Description = "2023 Singapore GP",
                Location = null,
                ExtraEu = true,
                Alias = "SINGP",
                EventNumber = null,
                Start = DateTime.Today,
                End = DateTime.Today,
            },
        };

        /// <summary>
        /// Executes the GET request to fetch all available events.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
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

        /// <summary>
        /// Executes the GET request to fetch all events for a given year.
        /// </summary>
        /// <param name="year">The year used to filter events.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
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