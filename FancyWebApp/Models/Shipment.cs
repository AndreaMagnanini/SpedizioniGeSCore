using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FancyWebApp.Models.Common;

namespace FancyWebApp.Models;

/// <summary>
/// Represents a view over the set of items that need to be shipped for a specific event to a specific locality, in a specific way
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
    public Locality Origin { get; set; }
    public Guid DestinationId { get; set; }
    [ForeignKey("DestinationId")]
    public Locality Destination { get; set; }
    public DateTime Departure { get; set; }
    public DateTime Arrive { get; set; }
}