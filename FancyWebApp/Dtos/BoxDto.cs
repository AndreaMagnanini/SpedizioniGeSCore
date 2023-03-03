namespace FancyWebApp.Dtos;
/// <summary>
/// Data Transfer Object for entity Box
/// </summary>
public class BoxDto
{
    public Guid BoxId { get; set; }
    public string BoxName { get; set; }
    public string Description { get; set; }
}