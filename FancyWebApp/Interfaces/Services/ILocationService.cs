using FancyWebApp.Dtos;

namespace FancyWebApp.Interfaces.Services
{
    public interface ILocationService
    {
        Task<List<LocationDto>> Get();
        Task<LocationDto> Get(Guid id);
    }
}
