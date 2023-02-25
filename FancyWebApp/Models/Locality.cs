using System.ComponentModel.DataAnnotations;
using FancyWebApp.Models.Common;

namespace FancyWebApp.Models;
/// <summary>
/// Represents a known place in the world as target of a Formula 1 GP
/// </summary>
public class Locality : UserTrace
{
    [Key] public Guid? Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Nation { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string City { get; set; }
    public string Zone { get; set; }
}