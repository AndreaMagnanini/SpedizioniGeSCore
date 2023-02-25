using System.ComponentModel.DataAnnotations;

namespace FancyWebApp.Models;
/// <summary>
/// Represents a user part of Ferrari GeS 
/// </summary>
public class User
{
    [Key] public string UserName { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public DateTime? IssueDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
}