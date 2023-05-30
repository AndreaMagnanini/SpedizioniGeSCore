using FancyWebApp.Dtos;
using FancyWebApp.Exceptions;
using FancyWebApp.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FancyWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipmentController : ControllerBase
{
    private readonly IShipmentService _shipmentService;

    public ShipmentController(IShipmentService shipmentService)
    {
        _shipmentService = shipmentService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ShipmentDto>>> Get()
    {
        try
        {
            var shipments = await this._shipmentService.Get();
            return this.Ok(shipments);
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