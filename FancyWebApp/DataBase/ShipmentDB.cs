using FancyWebApp.Models;
using FancyWebApp.Models.Common;
using Microsoft.EntityFrameworkCore;
using Object = FancyWebApp.Models.Object;

namespace FancyWebApp.DataBase;

public class ShipmentDB : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Object> Objects { get; set; }
    public DbSet<Box> Boxes { get; set; }
    public DbSet<Pallet> Pallets { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Airport> Airports { get; set; }
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<Content> Contents { get; set; }
    public DbSet<Scuderia> Scuderias { get; set; }
    public DbSet<Sigil> Sigils { get; set; }
    public DbSet<User> Users { get; set; }

    public ShipmentDB(DbContextOptions<ShipmentDB> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Object>().HasBaseType<Item>();
        modelBuilder.Entity<Box>().HasBaseType<Item>();
        modelBuilder.Entity<Pallet>().HasBaseType<Item>();

        modelBuilder.Entity<AirShipment>().HasBaseType<Shipment>();
        modelBuilder.Entity<FerryShipment>().HasBaseType<Shipment>();
        modelBuilder.Entity<GroundShipment>().HasBaseType<Shipment>();

        modelBuilder.Entity<Item>()
            .UseTptMappingStrategy()
            .HasDiscriminator(i => i.Type)
            .HasValue<Object>(ItemType.Object)
            .HasValue<Box>(ItemType.Box)
            .HasValue<Pallet>(ItemType.Pallet);
        
        modelBuilder.Entity<Shipment>()
            .UseTptMappingStrategy()
            .HasDiscriminator(s => s.Type)
            .HasValue<AirShipment>(ShipmentType.Air)
            .HasValue<FerryShipment>(ShipmentType.Ferry)
            .HasValue<GroundShipment>(ShipmentType.Ground);
    }
}