using System.ComponentModel.DataAnnotations;
using FancyWebApp.Models;

namespace FancyWebApp.DataBase;

public class GroundShipment : Shipment
{
    [Required]
    public string DriverName { get; set; }
}