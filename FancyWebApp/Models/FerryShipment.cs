using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FancyWebApp.Models;

public class FerryShipment : Shipment
{
    [Required]
    public string OriginPortName { get; set; }
    [ForeignKey("OriginPortName")]
    public Port OriginPort { get; set; }
    [Required]
    public string DestinationPortName { get; set; }
    [ForeignKey("DestinationPortName")]
    public Port DestinationPort { get; set; }
}