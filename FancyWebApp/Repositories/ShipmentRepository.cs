using System.Data.Entity;
using FancyWebApp.DataBase;
using FancyWebApp.Interfaces.Repositories;
using FancyWebApp.Models;

namespace FancyWebApp.Repositories;

public class ShipmentRepository : IShipmentRepository
{
    private readonly ShipmentDB _db;

    public ShipmentRepository(ShipmentDB db)
    {
        _db = db;
    }

    public async Task<List<Shipment>> Get() => await this._db.Shipments.ToListAsync();
    public async Task Post(Shipment shipment)
    {
        await this._db.Shipments.AddAsync(shipment);
        await this._db.SaveChangesAsync();
    }
}