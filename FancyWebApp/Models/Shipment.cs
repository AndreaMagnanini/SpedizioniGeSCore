using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FancyWebApp.Models.Common;

namespace FancyWebApp.Models;

/// <summary>
/// Represents a view over the set of items that need to be shipped for a specific event to a specific location, in a specific way
/// </summary>
public class Shipment : UserTrace
{
    [Key]
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public Guid EventId { get; set; }
    [ForeignKey("EventId")]
    public Event Event { get; set; }
    public Guid OriginId { get; set; }
    [ForeignKey("OriginId")]
    public Location Origin { get; set; }
    public Guid DestinationId { get; set; }
    [ForeignKey("DestinationId")]
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
public enum ShipmentType
{
    Air,
    Ferry,
    Ground
}
public enum ShimpentStatus
{
    Scheduled,
    Departed,
    Arrived,
}