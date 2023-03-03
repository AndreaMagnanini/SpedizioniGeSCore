using System.ComponentModel.DataAnnotations;
using FancyWebApp.Models.Common;

namespace FancyWebApp.Models;
/// <summary>
/// Represents a known location in the world as target of a Formula 1 GP
/// </summary>
public class Location : UserTrace
{
    [Key] 
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Nation { get; set; }
    [Required]
    public string City { get; set; }
    public string Address { get; set; }
}