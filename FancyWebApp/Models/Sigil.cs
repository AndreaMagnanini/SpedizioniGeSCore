using System.ComponentModel.DataAnnotations;
using FancyWebApp.Models.Common;

namespace FancyWebApp.Models;

/// <summary>
/// Represents the set of sigils used to close an item at the freight security zone
/// </summary>
public class Sigil : UserTrace
{
    [Key]
    public Guid Id { get; set; }
    public string Code { get; set; }
}