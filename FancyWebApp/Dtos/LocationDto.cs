namespace FancyWebApp.Dtos;
/// <summary>
/// Data Transfer Object for entity Location
/// </summary>
public class LocationDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Nation { get; set; }
    public string City { get; set; }
}