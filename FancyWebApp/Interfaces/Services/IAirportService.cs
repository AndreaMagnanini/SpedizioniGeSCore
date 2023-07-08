using FancyWebApp.Dtos;

namespace FancyWebApp.Interfaces.Services
{
    public interface IAirportService
    {
        Task<List<AirportDto>> Get();
        Task<AirportDto> Get(Guid id);
    }
}
