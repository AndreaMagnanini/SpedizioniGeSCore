using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FancyWebApp.Models;

/// <summary>
/// Represents a Box as a container of multiple objects belonging to the same category.
/// It may either be stored in a Pallet ora be floating
/// </summary>
public class Box : Item
{
    // [Key]
    //[Required]
    //public Guid BoxId { get; set; }
    [Required]
    public string BoxNumber { get; set; }
    //public string BoxDescription { get; set; }
}