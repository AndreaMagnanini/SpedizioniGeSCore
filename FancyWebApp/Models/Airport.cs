using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FancyWebApp.Models.Common;

namespace FancyWebApp.Models;
/// <summary>
/// Represents a known airport in a known location
/// </summary>
public class Airport : UserTrace
{
    [Key] 
    [Required]
    public string IATACode { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string City { get; set; }
    public string Description { get; set; }
}