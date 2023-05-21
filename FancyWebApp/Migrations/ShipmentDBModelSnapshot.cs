﻿// <auto-generated />
using System;
using FancyWebApp.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FancyWebApp.Migrations
{
    [DbContext(typeof(ShipmentDB))]
    partial class ShipmentDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FancyWebApp.Models.Airport", b =>
                {
                    b.Property<string>("IATACode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreationUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletionUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatingUSer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IATACode");

                    b.ToTable("Airports");

                    b.HasData(
                        new
                        {
                            IATACode = "BAH",
                            City = "Shaqir",
                            CreationDate = new DateTime(2023, 3, 3, 19, 23, 23, 985, DateTimeKind.Local).AddTicks(2615),
                            CreationUser = "amagnanini",
                            Description = "Airport nearby Saqir - Barahin",
                            Name = "Saqir International Airport"
                        });
                });

            modelBuilder.Entity("FancyWebApp.Models.Content", b =>
                {
                    b.Property<Guid>("ContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContainerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ShipmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SigilId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ContentId");

                    b.HasIndex("ItemId");

                    b.HasIndex("ShipmentId");

                    b.HasIndex("SigilId");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("FancyWebApp.Models.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreationUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletionUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EventNumber")
                        .HasColumnType("int");

                    b.Property<bool>("ExtraEU")
                        .HasColumnType("bit");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Start")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatingUSer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = new Guid("594aa0d8-ced2-4a35-8964-cf8ee234cfe7"),
                            Alias = "BAH",
                            CreationDate = new DateTime(2023, 3, 3, 19, 23, 23, 985, DateTimeKind.Local).AddTicks(2297),
                            CreationUser = "amagnanini",
                            Description = "Barahin GP",
                            End = new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Local),
                            EventNumber = 1,
                            ExtraEU = true,
                            LocationId = new Guid("6bffd0c7-98e1-46dd-bb84-b00fe20a13bf"),
                            Start = new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Local)
                        });
                });

            modelBuilder.Entity("FancyWebApp.Models.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreationUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletionUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Depth")
                        .HasColumnType("int");

                    b.Property<int?>("Height")
                        .HasColumnType("int");

                    b.Property<float?>("Tare")
                        .HasColumnType("real");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatingUSer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Weight")
                        .HasColumnType("real");

                    b.Property<int?>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("FancyWebApp.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreationUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletionUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatingUSer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ca2a0a2a-81ed-4297-ba1a-6827aea5bb17"),
                            Address = "Via Abetone 103",
                            City = "Maranello",
                            CreationDate = new DateTime(2023, 3, 3, 19, 23, 23, 985, DateTimeKind.Local).AddTicks(2255),
                            CreationUser = "amagnanini",
                            Name = "Ferrari Spa",
                            Nation = "Italy"
                        },
                        new
                        {
                            Id = new Guid("6bffd0c7-98e1-46dd-bb84-b00fe20a13bf"),
                            Address = "Shaqir Circuit street 109",
                            City = "Shaqir",
                            CreationDate = new DateTime(2023, 3, 3, 19, 23, 23, 985, DateTimeKind.Local).AddTicks(2271),
                            CreationUser = "amagnanini",
                            Name = "Barahin - Shaqir Circuit",
                            Nation = "Barahin"
                        });
                });

            modelBuilder.Entity("FancyWebApp.Models.Port", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.ToTable("Ports");

                    b.HasData(
                        new
                        {
                            Name = "Barahin International Port",
                            City = "Shaqir"
                        });
                });

            modelBuilder.Entity("FancyWebApp.Models.Scuderia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreationUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletionUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatingUSer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Scuderias");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5a1c681e-9007-4301-8286-cf3dbad05dde"),
                            CreationDate = new DateTime(2023, 3, 3, 19, 23, 23, 985, DateTimeKind.Local).AddTicks(1936),
                            CreationUser = "amagnanini",
                            Name = "Scuderia Ferrari"
                        },
                        new
                        {
                            Id = new Guid("c5f2af0d-935d-4138-9c2f-213504edeab1"),
                            CreationDate = new DateTime(2023, 3, 3, 19, 23, 23, 985, DateTimeKind.Local).AddTicks(1975),
                            CreationUser = "amagnanini",
                            Name = "Sauber Alfa Romeo Racing"
                        },
                        new
                        {
                            Id = new Guid("291f655e-c90c-4794-9477-fb174dbeaf16"),
                            CreationDate = new DateTime(2023, 3, 3, 19, 23, 23, 985, DateTimeKind.Local).AddTicks(1985),
                            CreationUser = "amagnanini",
                            Name = "Haas F1 Team"
                        });
                });

            modelBuilder.Entity("FancyWebApp.Models.Shipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Arrive")
                        .HasColumnType("datetime2");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreationUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletionUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Departure")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DestinationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OriginId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatingUSer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId");

                    b.HasIndex("EventId");

                    b.HasIndex("OriginId");

                    b.ToTable("Shipments");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("FancyWebApp.Models.Sigil", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreationUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletionUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatingUSer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sigils");
                });

            modelBuilder.Entity("FancyWebApp.Models.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserName");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserName = "amagnanini",
                            Email = "andrea.magnanini@ferrari.it",
                            ExpiryDate = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Local),
                            IssueDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "Andrea",
                            Surname = "Magnanini"
                        });
                });

            modelBuilder.Entity("FancyWebApp.Models.Box", b =>
                {
                    b.HasBaseType("FancyWebApp.Models.Item");

                    b.Property<Guid>("BoxId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BoxName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Boxes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e5abac55-8619-453e-b0ed-ecd6d3bbde0b"),
                            CreationDate = new DateTime(2023, 3, 3, 19, 23, 23, 985, DateTimeKind.Local).AddTicks(2543),
                            CreationUser = "amagnanini",
                            Depth = 20,
                            Height = 10,
                            Tare = 0f,
                            Type = 1,
                            Weight = 0.5f,
                            Width = 10,
                            BoxId = new Guid("f8ecaccf-2e56-4066-b914-1532eb00cfca"),
                            BoxName = "Box F-M05",
                            Description = "Alluminium and Magnesium Gearbox parts"
                        });
                });

            modelBuilder.Entity("FancyWebApp.Models.Object", b =>
                {
                    b.HasBaseType("FancyWebApp.Models.Item");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnglishDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FreightCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ObjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Value")
                        .HasColumnType("int");

                    b.ToTable("Objects");

                    b.HasData(
                        new
                        {
                            Id = new Guid("84a5400c-3ffb-4a11-95c7-16274eb450e2"),
                            CreationDate = new DateTime(2023, 3, 3, 19, 23, 23, 985, DateTimeKind.Local).AddTicks(2501),
                            CreationUser = "amagnanini",
                            Depth = 20,
                            Height = 10,
                            Tare = 0f,
                            Type = 0,
                            Weight = 0.5f,
                            Width = 10,
                            Description = "Elementi e assemblato per Cambio #05",
                            EnglishDescription = "Gearbox #05",
                            FreightCode = "10 15",
                            Name = "Cambio #05",
                            ObjectId = new Guid("d857bffd-e4f9-4c8e-a68c-ae8f901e5793"),
                            Value = 10000
                        });
                });

            modelBuilder.Entity("FancyWebApp.Models.Pallet", b =>
                {
                    b.HasBaseType("FancyWebApp.Models.Item");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PalletId")
                        .HasColumnType("uniqueidentifier");

                    b.ToTable("Pallets");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e9fb7be9-5739-4580-81f7-8c9c3d7d247c"),
                            CreationDate = new DateTime(2023, 3, 3, 19, 23, 23, 985, DateTimeKind.Local).AddTicks(2578),
                            CreationUser = "amagnanini",
                            Depth = 200,
                            Height = 100,
                            Type = 2,
                            Weight = 50f,
                            Width = 100,
                            Description = "Gearbox and related",
                            Name = "Pallet TSX 015",
                            PalletId = new Guid("0f2c31fb-4a56-466f-b166-ade081192a51")
                        });
                });

            modelBuilder.Entity("FancyWebApp.DataBase.GroundShipment", b =>
                {
                    b.HasBaseType("FancyWebApp.Models.Shipment");

                    b.Property<string>("DriverName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("GroundShipments");
                });

            modelBuilder.Entity("FancyWebApp.Models.AirShipment", b =>
                {
                    b.HasBaseType("FancyWebApp.Models.Shipment");

                    b.Property<string>("DestinationAirportIATACode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OriginAirportIATACode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("DestinationAirportIATACode");

                    b.HasIndex("OriginAirportIATACode");

                    b.ToTable("AirShipments");
                });

            modelBuilder.Entity("FancyWebApp.Models.FerryShipment", b =>
                {
                    b.HasBaseType("FancyWebApp.Models.Shipment");

                    b.Property<string>("DestinationPortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OriginPortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("DestinationPortName");

                    b.HasIndex("OriginPortName");

                    b.ToTable("FerryShipments");
                });

            modelBuilder.Entity("FancyWebApp.Models.Content", b =>
                {
                    b.HasOne("FancyWebApp.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FancyWebApp.Models.Shipment", "Shipment")
                        .WithMany()
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FancyWebApp.Models.Sigil", "Sigil")
                        .WithMany()
                        .HasForeignKey("SigilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Shipment");

                    b.Navigation("Sigil");
                });

            modelBuilder.Entity("FancyWebApp.Models.Event", b =>
                {
                    b.HasOne("FancyWebApp.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("FancyWebApp.Models.Shipment", b =>
                {
                    b.HasOne("FancyWebApp.Models.Location", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FancyWebApp.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FancyWebApp.Models.Location", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Destination");

                    b.Navigation("Event");

                    b.Navigation("Origin");
                });

            modelBuilder.Entity("FancyWebApp.Models.Box", b =>
                {
                    b.HasOne("FancyWebApp.Models.Item", null)
                        .WithOne()
                        .HasForeignKey("FancyWebApp.Models.Box", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FancyWebApp.Models.Object", b =>
                {
                    b.HasOne("FancyWebApp.Models.Item", null)
                        .WithOne()
                        .HasForeignKey("FancyWebApp.Models.Object", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FancyWebApp.Models.Pallet", b =>
                {
                    b.HasOne("FancyWebApp.Models.Item", null)
                        .WithOne()
                        .HasForeignKey("FancyWebApp.Models.Pallet", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FancyWebApp.DataBase.GroundShipment", b =>
                {
                    b.HasOne("FancyWebApp.Models.Shipment", null)
                        .WithOne()
                        .HasForeignKey("FancyWebApp.DataBase.GroundShipment", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FancyWebApp.Models.AirShipment", b =>
                {
                    b.HasOne("FancyWebApp.Models.Airport", "DestinationAirport")
                        .WithMany()
                        .HasForeignKey("DestinationAirportIATACode")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FancyWebApp.Models.Shipment", null)
                        .WithOne()
                        .HasForeignKey("FancyWebApp.Models.AirShipment", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FancyWebApp.Models.Airport", "OriginAirport")
                        .WithMany()
                        .HasForeignKey("OriginAirportIATACode")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DestinationAirport");

                    b.Navigation("OriginAirport");
                });

            modelBuilder.Entity("FancyWebApp.Models.FerryShipment", b =>
                {
                    b.HasOne("FancyWebApp.Models.Port", "DestinationPort")
                        .WithMany()
                        .HasForeignKey("DestinationPortName")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FancyWebApp.Models.Shipment", null)
                        .WithOne()
                        .HasForeignKey("FancyWebApp.Models.FerryShipment", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FancyWebApp.Models.Port", "OriginPort")
                        .WithMany()
                        .HasForeignKey("OriginPortName")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DestinationPort");

                    b.Navigation("OriginPort");
                });
#pragma warning restore 612, 618
        }
    }
}
