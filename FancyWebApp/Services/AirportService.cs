// <copyright file="AirportService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Services
{
    using AutoMapper;
    using FancyWebApp.Dtos;
    using FancyWebApp.Exceptions;

    /// <summary>
    /// The airport service.
    /// </summary>
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository airportRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AirportService"/> class.
        /// </summary>
        /// <param name="airportRepository">The airport repository instance.</param>
        /// <param name="mapper">The auto mapper instance.</param>
        public AirportService(IAirportRepository airportRepository, IMapper mapper)
        {
            this.airportRepository = airportRepository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<List<AirportDto>> Get()
        {
            var airports = await this.airportRepository.Get();
            return airports.Select(a => this.mapper.Map<AirportDto>(a)).ToList();
        }

        /// <inheritdoc/>
        public async Task<AirportDto> Get(Guid id)
        {
            var airport = await this.airportRepository.Get(id);

            return airport == null ? throw new NotFoundException($"Unknown airport with id {id}") : this.mapper.Map<AirportDto>(airport);
        }
    }
}