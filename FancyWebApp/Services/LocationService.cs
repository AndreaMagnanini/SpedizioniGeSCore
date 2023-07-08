using AutoMapper;
using FancyWebApp.Dtos;
using FancyWebApp.Exceptions;
using FancyWebApp.Interfaces.Repositories;
using FancyWebApp.Interfaces.Services;

namespace FancyWebApp.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<List<LocationDto>> Get()
        {
            var locations = await this._locationRepository.Get();
            return locations.Select(l => this._mapper.Map<LocationDto>(l)).ToList();
        }

        public async Task<LocationDto> Get(Guid id)
        {
            var location = await this._locationRepository.Get(id);

            if (location == null) throw new NotFoundException($"Unknown location with id {id}");

            return _mapper.Map<LocationDto>(location);
        }
    }
}
