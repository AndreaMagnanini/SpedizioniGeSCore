using FancyWebApp.Models;

namespace FancyWebApp.Dtos;
/// <summary>
/// Data Transfer Object for entity Event
/// </summary>
public class EventDto
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public Guid LocationId { get; set; }
    public Location? Location { get; set; }
    public bool ExtraEU { get; set; }
    public string? Alias { get; set; }
    public int? EventNumber { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
}