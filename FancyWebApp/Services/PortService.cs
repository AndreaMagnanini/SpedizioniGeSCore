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

        /// <summary>
        /// Fetches all available ports.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<List<PortDto>> Get()
        {
            var ports = await this.portRepository.Get();
            return ports.Select(p => this.mapper.Map<PortDto>(p)).ToList();
        }

        /// <summary>
        /// Fetches a single port given its identifier.
        /// </summary>
        /// <param name="id">The port identifier.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<PortDto> Get(Guid id)
        {
            var port = await this.portRepository.Get(id);

            if (port == null)
            {
                throw new NotFoundException($"Unknown port with id {id}");
            }

            return this.mapper.Map<PortDto>(port);
        }
    }
}
