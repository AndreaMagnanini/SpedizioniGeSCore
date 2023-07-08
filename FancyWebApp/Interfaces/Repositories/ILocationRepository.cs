using FancyWebApp.Models;

namespace FancyWebApp.Interfaces.Repositories
{
    public interface ILocationRepository
    {
        Task<List<Location>> Get();
        Task<Location> Get(Guid id);
    }
}
