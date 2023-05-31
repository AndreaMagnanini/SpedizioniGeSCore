using FancyWebApp.Dtos;
using FancyWebApp.Models;

namespace FancyWebApp.Interfaces.Repositories;

public interface IShipmentRepository
{
    Task<List<Shipment>> Get();
    Task<List<Shipment>> GetByYear(int year);
    Task Post(Shipment shipment);
}