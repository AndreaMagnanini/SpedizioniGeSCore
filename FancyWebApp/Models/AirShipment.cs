using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FancyWebApp.DataBase;

namespace FancyWebApp.Models;

public class AirShipment : Shipment
{
    [Required]
    public Guid OriginAirportId { get; set; }
    [ForeignKey("OriginAirportId")]
    public Airport OriginAirport { get; set; }
    [Required]
    public Guid DestinationAirportId { get; set; }
    [ForeignKey("DestinationAirportId")]
    public Airport DestinationAirport { get; set; }
}