using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FancyWebApp.Models.Common;

namespace FancyWebApp.Models;

/// <summary>
/// Represents a view over the set of items that need to be shipped for a specific event to a specific location, in a specific way
/// </summary>
public abstract class Shipment : UserTrace
{
    [Key]
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Code { get; set; }

    public string? Description { get; set; }

    [Required]
    public Guid EventId { get; set; }

    [ForeignKey("EventId")]
    public Event Event { get; set; }

    [Required]
    public Guid OriginId { get; set; }

    [ForeignKey("OriginId")]
    public Location Origin { get; set; }

    [Required]
    public Guid DestinationId { get; set; }

    [ForeignKey("DestinationId")]
    public Location Destination { get; set; }

    public DateTime? Departure { get; set; }

    public DateTime? Arrive { get; set; }

    [Required]
    public ShipmentType Type { get; set; }

    [Required]
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