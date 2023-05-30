using AutoMapper;
using FancyWebApp.Dtos;
using FancyWebApp.Interfaces.Repositories;
using FancyWebApp.Interfaces.Services;
using FancyWebApp.Models;

namespace FancyWebApp.Services;

public class ShipmentService : IShipmentService
{
    private readonly IShipmentRepository _shipmentRepository;
    private readonly IMapper _mapper;

    public ShipmentService(IShipmentRepository shipmentRepository, IMapper mapper)
    {
        _shipmentRepository = shipmentRepository;
        _mapper = mapper;
    }

    public async Task<List<ShipmentDto>> Get()
    {
        var shipments = await this._shipmentRepository.Get();
        return shipments.Select(s => this._mapper.Map<ShipmentDto>(s)).ToList();
    }

    public async Task<ShipmentDto> Post(ShipmentDto shipmentDto)
    {
        var shipment = this._mapper.Map<Shipment>(shipmentDto);
        await this._shipmentRepository.Post(shipment);
        return shipmentDto;
    }
}