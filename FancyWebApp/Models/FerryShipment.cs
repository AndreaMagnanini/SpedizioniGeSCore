using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FancyWebApp.Models;

public class FerryShipment : Shipment
{
    [Required]
    public Guid OriginPortId { get; set; }
    [ForeignKey("OriginPortId")]
    public Port OriginPort { get; set; }
    [Required]
    public Guid DestinationPortId { get; set; }
    [ForeignKey("DestinationPortId")]
    public Port DestinationPort { get; set; }
}