using FancyWebApp.Models;

namespace FancyWebApp.Interfaces.Repositories;

public interface IShipmentRepository
{
    Task<List<Shipment>> Get();
    Task Post(Shipment shipment);
}