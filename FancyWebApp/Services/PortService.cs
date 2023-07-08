using AutoMapper;
using FancyWebApp.Dtos;
using FancyWebApp.Exceptions;
using FancyWebApp.Interfaces.Repositories;
using FancyWebApp.Interfaces.Services;

namespace FancyWebApp.Services
{
    public class PortService : IPortService
    {
        private readonly IPortRepository _portRepository;
        private readonly IMapper _mapper;

        public PortService(IPortRepository portRepository)
        {
            _portRepository = portRepository;
        }

        public async Task<List<PortDto>> Get()
        {
            var ports = await this._portRepository.Get();
            return ports.Select(p => this._mapper.Map<PortDto>(p)).ToList();
        }

        public async Task<PortDto> Get(Guid id)
        {
            var port = await this._portRepository.Get(id);

            if (port == null) throw new NotFoundException($"Unknown port with id {id}");

            return this._mapper.Map<PortDto>(port);
        }
    }
}
