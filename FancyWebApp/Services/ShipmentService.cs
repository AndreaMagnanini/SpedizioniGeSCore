// <copyright file="ShipmentService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Services
{
    using AutoMapper;
    using FancyWebApp.Dtos;
    using FancyWebApp.Models;

    /// <summary>
    /// The shipment service.
    /// </summary>
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository shipmentRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShipmentService"/> class.
        /// </summary>
        /// <param name="shipmentRepository">The shipment repository instance.</param>
        /// <param name="mapper">The auto mapper instance.</param>
        public ShipmentService(IShipmentRepository shipmentRepository, IMapper mapper)
        {
            this.shipmentRepository = shipmentRepository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<List<ShipmentDto>> Get()
        {
            var shipments = await this.shipmentRepository.Get();
            var result = shipments.Select(s => this.mapper.Map<ShipmentDto>(s)).ToList();
            return result;
        }

        /// <inheritdoc/>
        public async Task<List<ShipmentDto>> GetByYear(int year)
        {
            var shipments = await this.shipmentRepository.GetByYear(year);
            var result = shipments.Select(s => this.mapper.Map<ShipmentDto>(s)).ToList();
            return result;
        }

        /// <inheritdoc/>
        public async Task<ShipmentDto> Post(ShipmentDto shipmentDto)
        {
            var shipment = this.mapper.Map<Shipment>(shipmentDto);
            shipment.Id = Guid.NewGuid();
            await this.shipmentRepository.Post(shipment);
            return shipmentDto;
        }
    }
}