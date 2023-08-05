// <copyright file="PortController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Controllers
{
    using FancyWebApp.Dtos;
    using FancyWebApp.Exceptions;
    using FancyWebApp.Interfaces.Services;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The port controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PortController : ControllerBase
    {
        private readonly IPortService portService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PortController"/> class.
        /// </summary>
        /// <param name="portService">The port service instance.</param>
        public PortController(IPortService portService)
        {
            this.portService = portService;
        }


        /// <summary>
        /// Executes the GET Request to fetch all available ports.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<ActionResult<List<PortDto>>> Get()
        {
            try
            {
                var ports = await this.portService.Get();
                return this.Ok(ports);
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
        /// Executes the GET Request o get a single port given its id.
        /// </summary>
        /// <param name="id">The port identifier.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<PortDto>> Get(Guid id)
        {
            try
            {
                var port = await this.portService.Get(id);
                return this.Ok(port);
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