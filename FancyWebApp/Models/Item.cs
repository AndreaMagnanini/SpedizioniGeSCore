using System.ComponentModel.DataAnnotations;
using FancyWebApp.Models.Common;

namespace FancyWebApp.Models;

/// <summary>
/// Represent a single and generic movable shipment unity
/// </summary>
public class Item : UserTrace
{
    [Key]
    [Required]
    public Guid Id { set; get; }
    public int? Height { get; set; }
    public int? Width { get; set; }
    public int? Depth { get; set; }
    public float? Weight { get; set; }
    public float? Tare { get; set; }
    [Required]
    public ItemType Type { get; set; }
}

public enum ItemType
{
    Object,
    Box,
    Pallet
}