using System.ComponentModel.DataAnnotations.Schema;

namespace FancyWebApp.Models;

public class FerryShipment : Shipment
{
    public string OriginPortName { get; set; }
    [ForeignKey("OriginPortName")]
    public Port OriginPort { get; set; }
    public string DestinationPortName { get; set; }
    [ForeignKey("DestinationPortName")]
    public Port DestinationPort { get; set; }
}