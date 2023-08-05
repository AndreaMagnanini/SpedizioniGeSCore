// <copyright file="Profiles.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Mapper
{
    using AutoMapper;
    using FancyWebApp.Dtos;
    using FancyWebApp.Models;
    using Object = FancyWebApp.Models.Object;

    /// <summary>
    /// Mapping profile provided to AutoMapper for automated castings.
    /// </summary>
    public class Profiles : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Profiles"/> class.
        /// </summary>
        public Profiles()
        {
            this.CreateMap<Shipment, ShipmentDto>();
            this.CreateMap<ShipmentDto, Shipment>();
            this.CreateMap<Item, ItemDto>();
            this.CreateMap<ItemDto, Item>();
            this.CreateMap<Object, ObjectDto>();
            this.CreateMap<ObjectDto, Object>();
            this.CreateMap<Box, BoxDto>();
            this.CreateMap<BoxDto, Box>();
            this.CreateMap<Pallet, PalletDto>();
            this.CreateMap<PalletDto, Pallet>();
            this.CreateMap<Location, LocationDto>();
            this.CreateMap<LocationDto, Location>();
            this.CreateMap<Event, EventDto>();
            this.CreateMap<EventDto, Event>();
            this.CreateMap<Content, ContentDto>();
            this.CreateMap<ContentDto, Content>();
            this.CreateMap<Sigil, SigilDto>();
            this.CreateMap<SigilDto, Sigil>();
            this.CreateMap<Camion, CamionDto>();
            this.CreateMap<CamionDto, Camion>();
            this.CreateMap<Airport, AirportDto>();
            this.CreateMap<Port, PortDto>();
            this.CreateMap<HsCode, HsCodeDto>();
        }
    }
}