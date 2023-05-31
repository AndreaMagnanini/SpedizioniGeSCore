namespace FancyWebApp.Dtos;
/// <summary>
/// Data Transfer Object for entity Pallet
/// </summary>
public class PalletDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public float? Tare { get; set; }
}