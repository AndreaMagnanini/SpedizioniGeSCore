using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FancyWebApp.Models;
/// <summary>
/// Represents a single concrete collectible such as piece of Chassis, a Gear or more complex structures treated as single entity.
/// It may either be stored in a box with other objects, be placed inside a Pallet or stay floating.
/// </summary>
public class Object : Item
{
    // [Key] 
    //[Required]
    //public Guid ObjectId { get; set; }
    //[Required]
    //public string ObjectName { get; set; }
    //public string? ObjectDescription { get; set; }
    [Required]
    public string? Code { get; set; }
    [ForeignKey("Code")]
    public HsCode HsCode { get; set; }
    [Required]
    public int Value { get; set; }
}