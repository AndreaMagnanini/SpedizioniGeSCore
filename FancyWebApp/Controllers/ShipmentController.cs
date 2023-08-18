// <copyright file="ShipmentController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Controllers
{
    using FancyWebApp.Dtos;
    using FancyWebApp.Exceptions;
    using FancyWebApp.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The shipment controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentService shipmentService;

        private readonly List<ShipmentDto> shipmentDtos = new ()
        {
            new ShipmentDto
            {
                Code = "AUS",
                Description = "Air Shipment to Australian GP",
                Event = new EventDto
                {
                    Description = "Australian GP 2023",
                    Location = new LocationDto
                    {
                        Name = "Albert Park Street Circuit",
                        Address = "Albert Park str 1",
                        Nation = "Australia",
                        City = "Melburne",
                    },
                    ExtraEu = true,
                    Alias = "AUSGP",
                    EventNumber = 3,
                    Start = new DateTime(2023, 3, 25),
                    End = new DateTime(2023, 3, 27),
                },
                Origin = new LocationDto
                {
                    Name = "Ferrari S.p.A.",
                    Address = "Via Ascari 110",
                    Nation = "Italy",
                    City = "Maranello",
                },
                OriginPort = new PortDto
                {
                    Name = "Genova International Port Area",
                    City = "Genova",
                    Description = null,
                },
                DestinationPort = new PortDto()
                {
                    Name = "Sidney Harbour Inc",
                    City = "Sidney",
                    Description = null,
                },
                Destination = new LocationDto
                {
                    Name = "Albert Park Street Circuit",
                    Address = "Albert Park str 1",
                    Nation = "Australia",
                    City = "Melburne",
                },
                Departure = DateTime.Today,
                Arrive = DateTime.Today,
                Contents = new List<ContentDto>(),
                Type = ShipmentType.Ferry,
                Status = ShipmentStatus.Scheduled,
            },
            new ShipmentDto
            {
                Code = "AUS",
                Description = "Air Shipment to Australian GP",
                Event = new EventDto
                {
                    Description = "Australian GP 2023",
                    Location = new LocationDto
                    {
                        Name = "Albert Park Street Circuit",
                        Address = "Albert Park str 1",
                        Nation = "Australia",
                        City = "Melburne",
                    },
                    ExtraEu = true,
                    Alias = "AUSGP",
                    EventNumber = 3,
                    Start = new DateTime(2023, 3, 25),
                    End = new DateTime(2023, 3, 27),
                },
                Origin = new LocationDto
                {
                    Name = "Ferrari S.p.A.",
                    Address = "Via Ascari 110",
                    Nation = "Italy",
                    City = "Maranello",
                },
                OriginAirport = new AirportDto
                {
                    IataCode = "BLQ",
                    Name = "Guglielmo Marconi Airport",
                    City = "Bologna",
                    Description = null,
                },
                DestinationAirport = new AirportDto
                {
                    IataCode = "MQB",
                    Name = "Melburne International Airport Oceania",
                    City = "Melburne",
                    Description = null,
                },
                Destination = new LocationDto
                {
                    Name = "Albert Park Street Circuit",
                    Address = "Albert Park str 1",
                    Nation = "Australia",
                    City = "Melburne",
                },
                Departure = DateTime.Today,
                Arrive = DateTime.Today,
                Contents = new List<ContentDto>(),
                Type = ShipmentType.Ground,
                Status = ShipmentStatus.Scheduled,
            },
            new ShipmentDto
            {
                Code = "AUS",
                Description = "Air Shipment to Australian GP",
                Event = new EventDto
                {
                    Description = "Australian GP 2023",
                    Location = new LocationDto
                    {
                        Name = "Albert Park Street Circuit",
                        Address = "Albert Park str 1",
                        Nation = "Australia",
                        City = "Melburne",
                    },
                    ExtraEu = true,
                    Alias = "AUSGP",
                    EventNumber = 3,
                    Start = new DateTime(2023, 3, 25),
                    End = new DateTime(2023, 3, 27),
                },
                Origin = new LocationDto
                {
                    Name = "Ferrari S.p.A.",
                    Address = "Via Ascari 110",
                    Nation = "Italy",
                    City = "Maranello",
                },
                OriginAirport = new AirportDto
                {
                    IataCode = "BLQ",
                    Name = "Guglielmo Marconi Airport",
                    City = "Bologna",
                    Description = null,
                },
                DestinationAirport = new AirportDto
                {
                    IataCode = "MQB",
                    Name = "Melburne International Airport Oceania",
                    City = "Melburne",
                    Description = null,
                },
                Destination = new LocationDto
                {
                    Name = "Albert Park Street Circuit",
                    Address = "Albert Park str 1",
                    Nation = "Australia",
                    City = "Melburne",
                },
                Departure = DateTime.Today,
                Arrive = DateTime.Today,
                Contents = new List<ContentDto>(),
                Type = ShipmentType.Air,
                Status = ShipmentStatus.Scheduled,
            },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="ShipmentController"/> class.
        /// </summary>
        /// <param name="shipmentService">The shipment service instance.</param>
        public ShipmentController(IShipmentService shipmentService)
        {
            this.shipmentService = shipmentService;
        }

        /// <summary>
        /// Executes the GET Request to fetch all available shipments.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<ActionResult<List<ShipmentDto>>> Get()
        {
            try
            {
                // var shipments = await this._shipmentService.Get();
                // return this.Ok(shipments);
                return this.Ok(this.shipmentDtos);
            }
            catch (Exception ex)
            {
                return this.Problem(ex.Message);
            }
        }

        /// <summary>
        /// Executes the GET Request to fetch all shipments for a certain year.
        /// </summary>
        /// <param name="year">The yrar used to filter shipments.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [Route("{year:int}")]
        public async Task<ActionResult<List<ShipmentDto>>> Get(int year)
        {
            try
            {
                // var shipments = await this._shipmentService.GetByYear(year);
                // return this.Ok(shipments);
                return this.Ok(this.shipmentDtos);
            }
            catch (Exception ex)
            {
                return this.Problem(ex.Message);
            }
        }

        /// <summary>
        /// Executes the POST Request to add a new Shipment entry.
        /// </summary>
        /// <param name="shipmentDto">The new shipment data.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<ActionResult<ShipmentDto>> Post([FromBody] ShipmentDto shipmentDto)
        {
            try
            {
                var shipment = await this.shipmentService.Post(shipmentDto);
                return this.Ok(shipment);
            }
            catch (BadRequestException ex)
            {
                return this.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.Problem(ex.Message);
            }
        }
    }
}