using FancyWebApp.Models;
using FancyWebApp.Models.Common;

namespace FancyWebApp.Dtos;
/// <summary>
/// Data Transfer Object for entity Shipment
/// </summary>
public class ShipmentDto
{
    public string Code { get; set; }
    public string Description { get; set; }
    public EventDto Event { get; set; }
    public LocationDto Origin { get; set; }
    public AirportDto? OriginAirport { get; set; }
    public AirportDto? DestinationAirport { get; set; }
    public PortDto? OriginPort { get; set; }
    public PortDto? DestinationPort { get; set; }
    public LocationDto Destination { get; set; }
    public DateTime Departure { get; set; }
    public DateTime Arrive { get; set; }
    public List<ContentDto> Contents { get; set; }  // roots of the tree
    // public List<Object> FloatingObjects { get; set; }
    // public List<Box> Boxes { get; set; }
    // public List<Pallet> Pallets { get; set; }
    public ShipmentType Type { get; set; }
    public ShimpentStatus Status { get; set; }
}