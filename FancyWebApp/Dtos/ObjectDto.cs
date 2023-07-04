using FancyWebApp.Models;

namespace FancyWebApp.Dtos;
/// <summary>
/// Data Transfer Object for entity Object
/// </summary>
public class ObjectDto : ItemDto
{
    public string Description { get; set; }
    public string EnglishDescription { get; set; }
    public string Code { get; set; }
    public int Value { get; set; }
}