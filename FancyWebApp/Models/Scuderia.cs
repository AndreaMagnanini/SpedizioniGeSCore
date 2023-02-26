using System.ComponentModel.DataAnnotations;
using FancyWebApp.Models.Common;

namespace FancyWebApp.Models;

public class Scuderia : UserTrace
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
}