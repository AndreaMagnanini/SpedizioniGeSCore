using AutoMapper;
using FancyWebApp.Dtos;
using FancyWebApp.Exceptions;
using FancyWebApp.Interfaces.Repositories;
using FancyWebApp.Interfaces.Services;

namespace FancyWebApp.Services
{
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IMapper _mapper;

        public AirportService(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        public async Task<List<AirportDto>> Get()
        {
            var airports = await this._airportRepository.Get();
            return airports.Select(a => this._mapper.Map<AirportDto>(a)).ToList();
        }

        public async Task<AirportDto> Get(Guid id)
        {
            var airport = await this._airportRepository.Get(id);

            if (airport == null) throw new NotFoundException($"Unknown airport with id {id}");

            return this._mapper.Map<AirportDto>(airport);
        }
    }
}
