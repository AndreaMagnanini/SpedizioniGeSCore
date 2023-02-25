using System.ComponentModel.DataAnnotations;

namespace FancyWebApp.Models;
/// <summary>
/// Represents a known airport on a known locality
/// </summary>
public class Airport
{
    [Key] public string IATACode { get; set; }
    public string Description { get; set; }
}