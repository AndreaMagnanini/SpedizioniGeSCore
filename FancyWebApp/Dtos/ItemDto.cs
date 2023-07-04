using FancyWebApp.Models;

namespace FancyWebApp.Dtos;
/// <summary>
/// Data Transfer Object for entity Item
/// </summary>
public class ItemDto
{
    public string Description { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public int Depth { get; set; }
    public float Weight { get; set; }
    public float? Tare { get; set; }
    public ItemType Type { get; set; }
    public int Availability { get; set; }
}