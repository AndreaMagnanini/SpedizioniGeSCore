using FancyWebApp.Dtos;
using FancyWebApp.Exceptions;
using FancyWebApp.Interfaces.Services;
using FancyWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FancyWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipmentController : ControllerBase
{
    private readonly IShipmentService _shipmentService;

    private readonly List<ShipmentDto> _shipmentDtos = new ()
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
                    City = "Melburne"
                },
                ExtraEU = true,
                Alias = "AUSGP",
                EventNumber = 3,
                Start = new DateTime(2023, 3, 25),
                End = new DateTime(2023, 3, 27)
            },
            Origin = new LocationDto
            {
                Name = "Ferrari S.p.A.",
                Address = "Via Ascari 110",
                Nation = "Italy",
                City = "Maranello"
            },
            OriginPort = new PortDto
            {
                Name = "Genova International Port Area",
                City = "Genova",
                Description = null
            },
            DestinationPort = new PortDto()
            {
                Name = "Sidney Harbour Inc",
                City = "Sidney",
                Description = null
            },
            Destination = new LocationDto
            {
                Name = "Albert Park Street Circuit",
                Address = "Albert Park str 1",
                Nation = "Australia",
                City = "Melburne"
            },
            Departure = DateTime.Today,
            Arrive = DateTime.Today,
            Contents = new List<ContentDto>(),
            Type = ShipmentType.Ferry,
            Status = ShipmentStatus.Scheduled
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
                    City = "Melburne"
                },
                ExtraEU = true,
                Alias = "AUSGP",
                EventNumber = 3,
                Start = new DateTime(2023, 3, 25),
                End = new DateTime(2023, 3, 27)
            },
            Origin = new LocationDto
            {
                Name = "Ferrari S.p.A.",
                Address = "Via Ascari 110",
                Nation = "Italy",
                City = "Maranello"
            },
            OriginAirport = new AirportDto
            {
                IATACode = "BLQ",
                Name = "Guglielmo Marconi Airport",
                City = "Bologna",
                Description = null
            },
            DestinationAirport = new AirportDto
            {
                IATACode = "MQB",
                Name = "Melburne International Airport Oceania",
                City = "Melburne",
                Description = null
            },
            Destination = new LocationDto
            {
                Name = "Albert Park Street Circuit",
                Address = "Albert Park str 1",
                Nation = "Australia",
                City = "Melburne"
            },
            Departure = DateTime.Today,
            Arrive = DateTime.Today,
            Contents = new List<ContentDto>(),
            Type = ShipmentType.Ground,
            Status = ShipmentStatus.Scheduled
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
                    City = "Melburne"
                },
                ExtraEU = true,
                Alias = "AUSGP",
                EventNumber = 3,
                Start = new DateTime(2023, 3, 25),
                End = new DateTime(2023, 3, 27)
            },
            Origin = new LocationDto
            {
                Name = "Ferrari S.p.A.",
                Address = "Via Ascari 110",
                Nation = "Italy",
                City = "Maranello"
            },
            OriginAirport = new AirportDto
            {
                IATACode = "BLQ",
                Name = "Guglielmo Marconi Airport",
                City = "Bologna",
                Description = null
            },
            DestinationAirport = new AirportDto
            {
                IATACode = "MQB",
                Name = "Melburne International Airport Oceania",
                City = "Melburne",
                Description = null
            },
            Destination = new LocationDto
            {
                Name = "Albert Park Street Circuit",
                Address = "Albert Park str 1",
                Nation = "Australia",
                City = "Melburne"
            },
            Departure = DateTime.Today,
            Arrive = DateTime.Today,
            Contents = new List<ContentDto>(),
            Type = ShipmentType.Air,
            Status = ShipmentStatus.Scheduled
        }
    };

    public ShipmentController(IShipmentService shipmentService)
    {
        _shipmentService = shipmentService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ShipmentDto>>> Get()
    {
        try
        {
            // var shipments = await this._shipmentService.Get();
            // return this.Ok(shipments);
            return Ok(this._shipmentDtos);
        }
        catch (Exception ex)
        {
            return this.Problem(ex.Message);
        }
    }
    
    [Route(("{year:int}"))]
    public async Task<ActionResult<List<ShipmentDto>>> Get(int year)
    {
        try
        {
            // var shipments = await this._shipmentService.GetByYear(year);
            // return this.Ok(shipments);
            return Ok(this._shipmentDtos);
        }
        catch (Exception ex)
        {
            return this.Problem(ex.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<ShipmentDto>> Post([FromBody] ShipmentDto shipmentDto)
    {
        try
        {
            var shipment = await this._shipmentService.Post(shipmentDto);
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