using FancyWebApp.Models;
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
    public DbSet<Port> Ports { get; set; }
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<AirShipment> AirShipments { get; set; }
    public DbSet<FerryShipment> FerryShipments { get; set; }
    public DbSet<GroundShipment> GroundShipments { get; set; }
    public DbSet<Content> Contents { get; set; }
    public DbSet<Scuderia> Scuderias { get; set; }
    public DbSet<Sigil> Sigils { get; set; }
    public DbSet<User> Users { get; set; }

    public ShipmentDB(DbContextOptions<ShipmentDB> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>()
            .UseTptMappingStrategy();
            // .HasDiscriminator<ItemType>(i => i.Type)
            // .HasValue<Object>(ItemType.Object)
            // .HasValue<Box>(ItemType.Box)
            // .HasValue<Pallet>(ItemType.Pallet);

            modelBuilder.Entity<Shipment>()
                .HasOne<Location>(s => s.Origin)
                .WithMany()
                .HasForeignKey(s => s.OriginId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Shipment>()
                .HasOne<Location>(s => s.Destination)
                .WithMany()
                .HasForeignKey(s => s.DestinationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AirShipment>()
                .HasOne<Airport>(s => s.OriginAirport)
                .WithMany()
                .HasForeignKey(s => s.OriginAirportIATACode)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<AirShipment>()
                .HasOne<Airport>(s => s.DestinationAirport)
                .WithMany()
                .HasForeignKey(s => s.DestinationAirportIATACode)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FerryShipment>()
                .HasOne<Port>(s => s.OriginPort)
                .WithMany()
                .HasForeignKey(s => s.OriginPortName)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<FerryShipment>()
                .HasOne<Port>(s => s.DestinationPort)
                .WithMany()
                .HasForeignKey(s => s.DestinationPortName)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<Shipment>()
            .UseTptMappingStrategy();
            // .HasDiscriminator<ShipmentType>(s => s.Type)
            // .HasValue<AirShipment>(ShipmentType.Air)
            // .HasValue<FerryShipment>(ShipmentType.Ferry)
            // .HasValue<GroundShipment>(ShipmentType.Ground);
        
        modelBuilder.Entity<Object>().HasBaseType<Item>();
        modelBuilder.Entity<Box>().HasBaseType<Item>();
        modelBuilder.Entity<Pallet>().HasBaseType<Item>();

        modelBuilder.Entity<AirShipment>().HasBaseType<Shipment>();
        modelBuilder.Entity<FerryShipment>().HasBaseType<Shipment>();
        modelBuilder.Entity<GroundShipment>().HasBaseType<Shipment>();

        var locationGuid = Guid.NewGuid();
        
        modelBuilder.Entity<Scuderia>().HasData(
            new Scuderia
            {
                CreationDate = DateTime.Now,
                CreationUser = "amagnanini",
                UpdatingDate = null,
                UpdatingUSer = null,
                DeletionDate = null,
                DeletionUser = null,
                Id = Guid.NewGuid(),
                Name = "Scuderia Ferrari"
            },
            new Scuderia
            {
                CreationDate = DateTime.Now,
                CreationUser = "amagnanini",
                UpdatingDate = null,
                UpdatingUSer = null,
                DeletionDate = null,
                DeletionUser = null,
                Id = Guid.NewGuid(),
                Name = "Sauber Alfa Romeo Racing"
            },
            new Scuderia
            {
                CreationDate = DateTime.Now,
                CreationUser = "amagnanini",
                UpdatingDate = null,
                UpdatingUSer = null,
                DeletionDate = null,
                DeletionUser = null,
                Id = Guid.NewGuid(),
                Name = "Haas F1 Team"
            });

        modelBuilder.Entity<Location>().HasData(new Location
        {
            CreationDate = DateTime.Now,
            CreationUser = "amagnanini",
            UpdatingDate = null,
            UpdatingUSer = null,
            DeletionDate = null,
            DeletionUser = null,
            Id = Guid.NewGuid(),
            Name = "Ferrari Spa",
            Address = "Via Abetone 103",
            Nation = "Italy",
            City = "Maranello",
        },new Location
        {
            CreationDate = DateTime.Now,
            CreationUser = "amagnanini",
            UpdatingDate = null,
            UpdatingUSer = null,
            DeletionDate = null,
            DeletionUser = null,
            Id = locationGuid,
            Name = "Barahin - Shaqir Circuit",
            Address = "Shaqir Circuit street 109",
            Nation = "Barahin",
            City = "Shaqir",
        });
        modelBuilder.Entity<Event>().HasData(new Event
        {
            CreationDate = DateTime.Now,
            CreationUser = "amagnanini",
            UpdatingDate = null,
            UpdatingUSer = null,
            DeletionDate = null,
            DeletionUser = null, 
            Id = Guid.NewGuid(),
            Description = "Barahin GP",
            LocationId = locationGuid,
            ExtraEU = true,
            Alias = "BAH",
            EventNumber = 1,
            Start = DateTime.Parse("03/03/2023 00:00:00 +1:00"),
            End = DateTime.Parse("06/03/2023 00:00:00 +1:00")
        });
        
        modelBuilder.Entity<Object>().HasData(new Object
        {
            CreationDate = DateTime.Now,
            CreationUser = "amagnanini",
            UpdatingDate = null,
            UpdatingUSer = null,
            DeletionDate = null,
            DeletionUser = null,
            Name = "Cambio #05",
            Height = 10,
            Width = 10,
            Depth = 20,
            Weight = 0.5f,
            Tare = 0,
            Type = ItemType.Object,
            Id = Guid.NewGuid(),
            ObjectId = Guid.NewGuid(),
            Description = "Elementi e assemblato per Cambio #05",
            EnglishDescription = "Gearbox #05",
            FreightCode = "10 15",
            Value = 10000
        });
        modelBuilder.Entity<Box>().HasData(new Box
        {
            CreationDate = DateTime.Now,
            CreationUser = "amagnanini",
            UpdatingDate = null,
            UpdatingUSer = null,
            DeletionDate = null,
            DeletionUser = null,
            Height = 10,
            Width = 10,
            Depth = 20,
            Weight = 0.5f,
            Tare = 0,
            Type = ItemType.Box,
            Id = Guid.NewGuid(),
            BoxId = Guid.NewGuid(),
            BoxName = "Box F-M05",
            Description = "Alluminium and Magnesium Gearbox parts"
        });
        modelBuilder.Entity<Pallet>().HasData(new Pallet
        {
            CreationDate = DateTime.Now,
            CreationUser = "amagnanini",
            UpdatingDate = null,
            UpdatingUSer = null,
            DeletionDate = null,
            DeletionUser = null,
            Height = 100,
            Width = 100,
            Depth = 200,
            Weight = 50f,
            Tare = 0,
            Type = ItemType.Pallet,
            PalletId = Guid.NewGuid(),
            Id = Guid.NewGuid(),
            Name = "Pallet TSX 015",
            Description = "Gearbox and related",
        });

        modelBuilder.Entity<Airport>().HasData(new Airport
        {
            CreationDate = DateTime.Now,
            CreationUser = "amagnanini",
            UpdatingDate = null,
            UpdatingUSer = null,
            DeletionDate = null,
            DeletionUser = null,
            IATACode = "BAH",
            City= "Shaqir",
            Name = "Saqir International Airport",
            Description = "Airport nearby Saqir - Barahin"
        });
        
        modelBuilder.Entity<Port>().HasData(new Port
        {
            Name = "Barahin International Port",
            City = "Shaqir",
        });

        modelBuilder.Entity<User>().HasData(new User
        {
            UserName = "amagnanini",
            Name = "Andrea", 
            Surname = "Magnanini",
            Email = "andrea.magnanini@ferrari.it",
            IssueDate = DateTime.Parse("01/01/2023 00:00:00 +1:00"),
            ExpiryDate = DateTime.Parse("01/01/2024 00:00:00 +1:00")
        });
    }
}