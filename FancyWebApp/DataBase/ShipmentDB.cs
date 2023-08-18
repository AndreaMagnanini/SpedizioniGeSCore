// <copyright file="ShipmentDB.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.DataBase
{
    using FancyWebApp.Models;
    using Object = FancyWebApp.Models.Object;

    /// <summary>
    /// Initializes a new instance of the <see cref="ShipmentDb"/> class.
    /// </summary>
    public class ShipmentDb : DbContext
    {
        /// <inheritdoc cref="DbContext"/>
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipmentDb"/> class.
        /// <param name="options">database initializer options.</param>
        /// </summary>
        public ShipmentDb(DbContextOptions<ShipmentDb> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets entity Items.
        /// </summary>
        public DbSet<Item> Items { get; set; }

        /// <summary>
        /// Gets or sets entity Objects.
        /// </summary>
        public DbSet<Object> Objects { get; set; }

        /// <summary>
        /// Gets or sets entity Boxes.
        /// </summary>
        public DbSet<Box> Boxes { get; set; }

        /// <summary>
        /// Gets or sets entity Pallets.
        /// </summary>
        public DbSet<Pallet> Pallets { get; set; }

        /// <summary>
        /// Gets or sets entity Events.
        /// </summary>
        public DbSet<Event> Events { get; set; }

        /// <summary>
        /// Gets or sets entity Locations.
        /// </summary>
        public DbSet<Location> Locations { get; set; }

        /// <summary>
        /// Gets or sets entity Airports.
        /// </summary>
        public DbSet<Airport> Airports { get; set; }

        /// <summary>
        /// Gets or sets entity Ports.
        /// </summary>
        public DbSet<Port> Ports { get; set; }

        /// <summary>
        /// Gets or sets entity Shipments.
        /// </summary>
        public DbSet<Shipment> Shipments { get; set; }

        /// <summary>
        /// Gets or sets entity AirShipments.
        /// </summary>
        public DbSet<AirShipment> AirShipments { get; set; }

        /// <summary>
        /// Gets or sets entity FerryShipments.
        /// </summary>
        public DbSet<FerryShipment> FerryShipments { get; set; }

        /// <summary>
        /// Gets or sets entity GroundShipments.
        /// </summary>
        public DbSet<GroundShipment> GroundShipments { get; set; }

        /// <summary>
        /// Gets or sets entity Contents.
        /// </summary>
        public DbSet<Content> Contents { get; set; }

        /// <summary>
        /// Gets or sets entity Scuderias.
        /// </summary>
        public DbSet<Scuderia> Scuderias { get; set; }

        /// <summary>
        /// Gets or sets entity Sigils.
        /// </summary>
        public DbSet<Sigil> Sigils { get; set; }

        /// <summary>
        /// Gets or sets entity Users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <inheritdoc cref="DbContext"/>
        /// <summary>
        /// Gets or sets entity items.
        /// <param name="modelBuilder"> The database model initializer.</param>
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                .HasForeignKey(s => s.OriginAirportId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<AirShipment>()
                .HasOne<Airport>(s => s.DestinationAirport)
                .WithMany()
                .HasForeignKey(s => s.DestinationAirportId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FerryShipment>()
                .HasOne<Port>(s => s.OriginPort)
                .WithMany()
                .HasForeignKey(s => s.OriginPortId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FerryShipment>()
                .HasOne<Port>(s => s.DestinationPort)
                .WithMany()
                .HasForeignKey(s => s.DestinationPortId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Shipment>()
                .UseTphMappingStrategy()
                .HasDiscriminator<ShipmentType>(s => s.Type)
                .HasValue<AirShipment>(ShipmentType.Air)
                .HasValue<FerryShipment>(ShipmentType.Ferry)
                .HasValue<GroundShipment>(ShipmentType.Ground);

            modelBuilder.Entity<Item>()
                .UseTphMappingStrategy()
                .HasDiscriminator<ItemType>(i => i.Type)
                .HasValue<Object>(ItemType.Object)
                .HasValue<Box>(ItemType.Box)
                .HasValue<Pallet>(ItemType.Pallet);

            modelBuilder.Entity<Object>().HasBaseType<Item>();
            modelBuilder.Entity<Box>().HasBaseType<Item>();
            modelBuilder.Entity<Pallet>().HasBaseType<Item>();

            modelBuilder.Entity<AirShipment>().HasBaseType<Shipment>();
            modelBuilder.Entity<FerryShipment>().HasBaseType<Shipment>();
            modelBuilder.Entity<GroundShipment>().HasBaseType<Shipment>();

            var locationGuid = Guid.NewGuid();

            modelBuilder.Entity<Scuderia>()
                .HasData(
                new Scuderia
                {
                    CreationDate = DateTime.Now,
                    CreationUser = "amagnanini",
                    UpdatingDate = null,
                    UpdatingUSer = null,
                    DeletionDate = null,
                    DeletionUser = null,
                    Id = Guid.NewGuid(),
                    Name = "Scuderia Ferrari",
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
                    Name = "Sauber Alfa Romeo Racing",
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
                    Name = "Haas F1 Team",
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
                ExtraEu = true,
                Alias = "BAH",
                EventNumber = 1,
                Start = DateTime.Parse("03/03/2023 00:00:00 +1:00"),
                End = DateTime.Parse("06/03/2023 00:00:00 +1:00"),
            });

            modelBuilder.Entity<Object>()
                .HasData(
                    new Object
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
                        Type = ItemType.Object,
                        Id = Guid.NewGuid(),
                        Description = "Gearbox #05",
                        Code = "10 15",
                        Value = 10000,
                    });

            modelBuilder.Entity<Box>()
                .HasData(
                    new Box
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
                        BoxNumber = "F-M05",
                        Description = "Alluminium and Magnesium Gearbox parts",
                    });
            modelBuilder.Entity<Pallet>()
                .HasData(
                    new Pallet
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
                        Id = Guid.NewGuid(),
                        PalletCode = "TSX 015",
                        Description = "Gearbox and related",
                    });

            modelBuilder.Entity<HsCode>()
                .HasData(new HsCode
                {
                    Code = "10 15",
                    Description = "Gearbox assemblies and components",
                });
        }
    }
}