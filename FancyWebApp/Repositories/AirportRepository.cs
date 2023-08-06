// <copyright file="AirportRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Repositories
{
    using FancyWebApp.DataBase;
    using FancyWebApp.Interfaces.Repositories;
    using FancyWebApp.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The repository linked to airport entity.
    /// </summary>
    public class AirportRepository : IAirportRepository
    {
        /// <summary>
        /// The shipment db instance.
        /// </summary>
        private readonly ShipmentDb db;

        /// <summary>
        /// Initializes a new instance of the <see cref="AirportRepository"/> class.
        /// </summary>
        /// <param name="db">The shipment db instance.</param>
        public AirportRepository(ShipmentDb db)
        {
            this.db = db;
        }

        /// <inheritdoc/>
        public async Task<List<Airport>> Get()
        {
            return await this.db.Airports.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Airport?> Get(Guid id)
        {
            return await this.db.Airports.FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}