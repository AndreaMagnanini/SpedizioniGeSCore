using System.ComponentModel.DataAnnotations;

namespace FancyWebApp.Models;
/// <summary>
/// Represents a single concrete collectible such as piece of Chassis, a Gear or more complex structures treated as single entity.
/// It may either be stored in a box with other objects, be placed inside a Pallet or stay floating.
/// </summary>
public class Object : Item
{
    [Key] public Guid? Id { get; set; }
    public string Description { get; set; }
    public string EnglishDescription { get; set; }
    public string FreightCode { get; set; }
    public int Value { get; set; }
    public Guid? ContainerId { get; set; }
}