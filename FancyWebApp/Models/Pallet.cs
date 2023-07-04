using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FancyWebApp.Models;

/// <summary>
/// Represents a Cargo Pallet, capable to contain both boxes and floating objects
/// </summary>
public class Pallet : Item
{
    // [Key] 
    //[Required]
    //public Guid PalletId { get; set; }
    [Required]
    public string PalletCode { get; set; }
    //public string? PalletDescription { get; set; }
}