using AutoMapper;
using FancyWebApp.DataBase;
using FancyWebApp.Dtos;
using FancyWebApp.Models;
using FancyWebApp.Models.Common;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;
using Object = FancyWebApp.Models.Object;

namespace FancyWebApp.Mapper;
/// <summary>
/// Mapping profile provided to AutoMapper for automated castings
/// </summary>
public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<Shipment, ShipmentDto>();
        CreateMap<ShipmentDto, Shipment>();
        CreateMap<Item, ItemDto>();
        CreateMap<ItemDto, Item>();
        CreateMap<Object, ObjectDto>();
        CreateMap<ObjectDto, Object>();
        CreateMap<Box, BoxDto>();
        CreateMap<BoxDto, Box>();
        CreateMap<Pallet, PalletDto>();
        CreateMap<PalletDto, Pallet>();
        CreateMap<Location, LocationDto>();
        CreateMap<LocationDto, Location>();
        CreateMap<Event, EventDto>();
        CreateMap<EventDto, Event>();
        CreateMap<Content, ContentDto>();
        CreateMap<ContentDto, Content>();
        CreateMap<Sigil, SigilDto>();
        CreateMap<SigilDto, Sigil>();
        CreateMap<Camion, CamionDto>();
        CreateMap<CamionDto, Camion>();
    }
}