using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FancyWebApp.Models;

public class Port
{
    [Key] 
    [Required]
    public string Name { get; set; }
    [Required] 
    public string City { get; set; }
}