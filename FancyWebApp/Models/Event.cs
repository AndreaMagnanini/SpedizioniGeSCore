using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FancyWebApp.Models.Common;

namespace FancyWebApp.Models;
/// <summary>
/// Represents a single Formula 1 Grand Prix
/// </summary>
public class Event : UserTrace
{
    [Key] 
    [Required]
    public Guid Id { get; set; }
    public string? Description { get; set; }
    [Required]
    public Guid LocationId { get; set; }
    [ForeignKey("LocationId")] 
    public Location? Location { get; set; }
    [Required]
    public bool ExtraEU { get; set; }
    public string? Alias { get; set; }
    public int? EventNumber { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }

}   