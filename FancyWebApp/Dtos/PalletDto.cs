namespace FancyWebApp.Dtos;
/// <summary>
/// Data Transfer Object for entity Pallet
/// </summary>
public class PalletDto
{
    public Guid PalletId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float? Tare { get; set; }
}