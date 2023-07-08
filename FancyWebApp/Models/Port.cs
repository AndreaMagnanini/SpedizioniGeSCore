using System.ComponentModel.DataAnnotations;
using FancyWebApp.Models.Common;

namespace FancyWebApp.Models;

public class Port : UserTrace
{
    [Key]
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string LoCode { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Country { get; set; }
    public string? Description { get; set; }
}