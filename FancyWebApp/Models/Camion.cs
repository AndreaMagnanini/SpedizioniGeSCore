namespace FancyWebApp.Models;

public class Camion
{
    public Guid Id { get; set; }
    public string Society { get; set; }
    public string Model { get; set; }
    public string TargaCode { get; set; }
    public List<Content> Contents { get; set; }
}