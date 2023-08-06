// <copyright file="PortService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>using FancyWebApp.DataBase;

namespace FancyWebApp.Services
{
    using AutoMapper;
    using FancyWebApp.Dtos;
    using FancyWebApp.Exceptions;
    using FancyWebApp.Interfaces.Repositories;
    using FancyWebApp.Interfaces.Services;

    /// <summary>
    /// The service corresponding to Port entity.
    /// </summary>
    public class PortService : IPortService
    {
        private readonly IPortRepository portRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PortService"/> class.
        /// </summary>
        /// <param name="portRepository">the port repository instance.</param>
        /// <param name="mapper">the mapper instance.</param>
        public PortService(IPortRepository portRepository, IMapper mapper)
        {
            this.portRepository = portRepository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<List<PortDto>> Get()
        {
            var ports = await this.portRepository.Get();
            return ports.Select(p => this.mapper.Map<PortDto>(p)).ToList();
        }

        /// <inheritdoc/>
        public async Task<PortDto> Get(Guid id)
        {
            var port = await this.portRepository.Get(id);

            return port == null ? throw new NotFoundException($"Unknown port with id {id}") : this.mapper.Map<PortDto>(port);
        }
    }
}