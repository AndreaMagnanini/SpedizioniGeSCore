using FancyWebApp.Dtos;

namespace FancyWebApp.Interfaces.Services;

public interface IShipmentService
{
    Task<List<ShipmentDto>> Get();
    Task<ShipmentDto> Post(ShipmentDto shipmentDto);
}