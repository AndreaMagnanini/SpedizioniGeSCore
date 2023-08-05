// <copyright file="AirportController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Controllers
{
    using FancyWebApp.Dtos;
    using FancyWebApp.Exceptions;
    using FancyWebApp.Interfaces.Services;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The airport controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AirportController : ControllerBase
    {
        private readonly IAirportService airportService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AirportController"/> class.
        /// </summary>
        /// <param name="airportService">The airport service instance.</param>
        public AirportController(IAirportService airportService)
        {
            this.airportService = airportService;
        }

        /// <summary>
        /// Executes the GET request to fetch all available airports.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<ActionResult<List<AirportDto>>> Get()
        {
            try
            {
                var airports = await this.airportService.Get();
                return this.Ok(airports);
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
        /// Executes the GET request to fetch a single airport given its id.
        /// </summary>
        /// <param name="id">The airport identifier.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<AirportDto>> Get(Guid id)
        {
            try
            {
                var airport = await this.airportService.Get(id);
                return this.Ok(airport);
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