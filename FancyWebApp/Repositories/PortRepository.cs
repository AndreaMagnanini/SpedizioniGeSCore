using System.Data.Entity;
using FancyWebApp.DataBase;
using FancyWebApp.Interfaces.Repositories;
using FancyWebApp.Models;

namespace FancyWebApp.Repositories
{
    public class PortRepository : IPortRepository
    {
        private readonly ShipmentDB _db;

        public PortRepository(ShipmentDB db)
        {
            _db = db;
        }

        public async Task<List<Port>> Get()
        {
            return await this._db.Ports.ToListAsync();
        }

        public async Task<Port> Get(Guid id)
        {
            return await this._db.Ports.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
