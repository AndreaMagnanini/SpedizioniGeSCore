// <copyright file="LocationService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Services
{
    using AutoMapper;
    using FancyWebApp.Dtos;
    using FancyWebApp.Exceptions;
    using FancyWebApp.Interfaces.Repositories;
    using FancyWebApp.Interfaces.Services;

    /// <summary>
    /// The location service.
    /// </summary>
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository locationRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationService"/> class.
        /// </summary>
        /// <param name="locationRepository">The location repository instance.</param>
        /// <param name="mapper">The auto mapper instance.</param>
        public LocationService(ILocationRepository locationRepository, IMapper mapper)
        {
            this.locationRepository = locationRepository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<List<LocationDto>> Get()
        {
            var locations = await this.locationRepository.Get();
            return locations.Select(l => this.mapper.Map<LocationDto>(l)).ToList();
        }

        /// <inheritdoc/>
        public async Task<LocationDto> Get(Guid id)
        {
            var location = await this.locationRepository.Get(id);

            return location == null ? throw new NotFoundException($"Unknown location with id {id}") : this.mapper.Map<LocationDto>(location);
        }
    }
}