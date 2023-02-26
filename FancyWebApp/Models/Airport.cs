using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FancyWebApp.Models.Common;

namespace FancyWebApp.Models;
/// <summary>
/// Represents a known airport in a known location
/// </summary>
public class Airport : UserTrace
{
    [Key] public string IATACode { get; set; }
    public string Name { get; set; }
    public Guid LocationId { get; set; }
    [ForeignKey("LocationId")]
    public Location Location { get; set; }
    public string Description { get; set; }
}