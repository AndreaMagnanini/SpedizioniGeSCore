using System.Data.Entity;
using FancyWebApp.DataBase;
using FancyWebApp.Interfaces.Repositories;
using FancyWebApp.Models;

namespace FancyWebApp.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ShipmentDB _db;

        public LocationRepository(ShipmentDB db)
        {
            _db = db;
        }

        public async Task<List<Location>> Get()
        {
            return await this._db.Locations.ToListAsync();
        }

        public async Task<Location> Get(Guid id)
        { 
            return  await this._db.Locations.FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}
