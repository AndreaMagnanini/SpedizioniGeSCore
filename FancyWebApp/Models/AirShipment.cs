using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FancyWebApp.DataBase;

namespace FancyWebApp.Models;

public class AirShipment : Shipment
{
    [Required]
    public string OriginAirportIATACode { get; set; }
    [ForeignKey("OriginAirportIATACode")]
    public Airport OriginAirport { get; set; }
    [Required]
    public string DestinationAirportIATACode { get; set; }
    [ForeignKey("DestinationAirportIATACode")]
    public Airport DestinationAirport { get; set; }
}