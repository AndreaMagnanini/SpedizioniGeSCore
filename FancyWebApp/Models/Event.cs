using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FancyWebApp.Models.Common;
/// <summary>
/// Represents a single Formula 1 Grand Prix
/// </summary>
public class Event : UserTrace
{
    [Key] public Guid? Id { get; set; }
    public string? Description { get; set; }
    public Guid LocalityId { get; set; }
    [ForeignKey("LocalityId")] public Locality? Locality { get; set; }
    public bool ExtraEU { get; set; }
    public string? Alias { get; set; }
    public int? EventNumber { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
}   