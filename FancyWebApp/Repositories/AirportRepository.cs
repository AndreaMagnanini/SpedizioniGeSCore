using System.Data.Entity;
using FancyWebApp.DataBase;
using FancyWebApp.Interfaces.Repositories;
using FancyWebApp.Models;

namespace FancyWebApp.Repositories
{
    public class AirportRepository : IAirportRepository
    {
        private readonly ShipmentDB _db;

        public AirportRepository(ShipmentDB db)
        {
            _db = db;
        }

        public async Task<List<Airport>> Get()
        {
            return await this._db.Airports.ToListAsync();
        }

        public async Task<Airport> Get(Guid id)
        {
            return await this._db.Airports.FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
