using FancyWebApp.Models;

namespace FancyWebApp.Interfaces.Repositories
{
    public interface IPortRepository
    {
        Task<List<Port>> Get();
        Task<Port> Get(Guid id);
    }
}
