using FancyWebApp.Models;
using FancyWebApp.Models.Common;

namespace FancyWebApp.Dtos;
/// <summary>
/// Data Transfer Object for entity Shipment
/// </summary>
public class ShipmentDto
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public Event Event { get; set; }
    public Location Origin { get; set; }
    public Airport OriginAirport { get; set; }
    public Airport DestionationAiport { get; set; }
    public Location Destination { get; set; }
    public DateTime Departure { get; set; }
    public DateTime Arrive { get; set; }
    public List<Content> Contents { get; set; }  // roots of the tree
    // public List<Object> FloatingObjects { get; set; }
    // public List<Box> Boxes { get; set; }
    // public List<Pallet> Pallets { get; set; }
    public ShipmentType Type { get; set; }
    public ShimpentStatus Status { get; set; }
}