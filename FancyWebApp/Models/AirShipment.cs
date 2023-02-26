using System.ComponentModel.DataAnnotations.Schema;
using FancyWebApp.DataBase;

namespace FancyWebApp.Models;

public class AirShipment : Shipment
{
    public string OriginAirportIATACode { get; set; }
    [ForeignKey("OriginAirportIATACode")]
    public Airport OriginAirport { get; set; }
    public string DestinationAirportIATACode { get; set; }
    [ForeignKey("DestinationAirportIATACode")]
    public Airport DestinationAirport { get; set; }
}