using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FancyWebApp.Models;

/// <summary>
/// Represents a Box as a container of multiple objects belonging to the same category.
/// It may either be stored in a Pallet ora be floating
/// </summary>
public class Box : Item
{
    [Key] public Guid? Id { get; set; }
    public string BoxName { get; set; }
    public string Description { get; set; }
}