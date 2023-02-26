using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FancyWebApp.Models;

/// <summary>
/// Represents a Cargo Pallet, capable to contain both boxes and floating objects
/// </summary>
public class Pallet : Item
{
    [Key] public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float? Tare { get; set; }
}