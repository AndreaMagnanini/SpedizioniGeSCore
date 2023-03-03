using FancyWebApp.Models;

namespace FancyWebApp.Dtos;
/// <summary>
/// Data Transfer Object for entity Content
/// </summary>
public class ContentDto
{
    public Guid ContentId { get; set; }
    public Item Item { get; set; }
    public Sigil Sigil { get; set; }
    public Guid ShipmentId { get; set; }
    public Shipment Shipment { get; set; }
    public Guid? ContainerId { get; set; }
    public ItemType ContentType { get; set; }
    public List<ContentDto>? Contents { get; set; }
}