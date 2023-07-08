using FancyWebApp.Dtos;

namespace FancyWebApp.Interfaces.Services
{
    public interface IPortService
    {
        Task<List<PortDto>> Get();
        Task<PortDto> Get(Guid id);
    }
}
