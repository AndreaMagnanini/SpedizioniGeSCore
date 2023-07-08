using FancyWebApp.Models;

namespace FancyWebApp.Interfaces.Repositories
{
    public interface IAirportRepository
    {
        Task<List<Airport>> Get();
        Task<Airport> Get(Guid id);
    }
}
