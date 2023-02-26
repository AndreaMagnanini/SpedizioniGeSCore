using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FancyWebApp.Models;

public class Port
{
    [Key] public string Name { get; set; }
    public Guid LocationId { get; set; }
    [ForeignKey("LocationId")]
    public Location Location { get; set; }
}