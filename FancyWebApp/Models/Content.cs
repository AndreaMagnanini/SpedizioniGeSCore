using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FancyWebApp.Models;

public class Content
{
    [Key]
    [Required]
    public Guid ContentId { get; set; }
    [Required]
    public Guid ItemId { get; set; }
    [ForeignKey("ItemId")]
    public Item Item { get; set; }
    [Required]
    public int Quantity { get; set; }
    public Guid? SigilId { get; set; }
    [ForeignKey("SigilId")]
    public Sigil Sigil { get; set; }
    [Required]
    public Guid ShipmentId { get; set; }
    [ForeignKey("ShipmentId")] 
    public Shipment Shipment { get; set; }
    public Guid? ContainerId { get; set; }

}

public enum ContentType
{
    root,   // has ContainerId = null
    middle, // has both ContainerId != null and Contents.Count > 0
    leaf    // has Contents.Count = 0
}