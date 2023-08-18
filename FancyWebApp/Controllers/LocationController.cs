// <copyright file="LocationController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Controllers
{
    using FancyWebApp.Dtos;
    using FancyWebApp.Exceptions;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The location controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService locationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationController"/> class.
        /// </summary>
        /// <param name="locationService">The location service instance.</param>
        public LocationController(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        /// <summary>
        /// Executes the GET Request to fetch all available locations.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<ActionResult<List<LocationDto>>> Get()
        {
            try
            {
                var locations = await this.locationService.Get();
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

        /// <summary>
        /// Executes the GET Request to fetch a single location given its id.
        /// </summary>
        /// <param name="id">The location identifier.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<LocationDto>> Get(Guid id)
        {
            try
            {
                var location = await this.locationService.Get(id);
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