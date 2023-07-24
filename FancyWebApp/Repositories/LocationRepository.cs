// <copyright file="LocationRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>using FancyWebApp.DataBase;

namespace FancyWebApp.Repositories
{
    using System.Data.Entity;
    using FancyWebApp.DataBase;
    using FancyWebApp.Interfaces.Repositories;
    using FancyWebApp.Models;

    /// <summary>
    /// The repository linked to Location entity.
    /// </summary>
    public class LocationRepository : ILocationRepository
    {
        /// <summary>
        /// The database instance.
        /// </summary>
        private readonly ShipmentDb db;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationRepository"/> class.
        /// </summary>
        /// <param name="db">The database instance.</param>
        public LocationRepository(ShipmentDb db)
        {
            this.db = db;
        }

        /// <summary>
        /// Fetches all available locations.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<List<Location>> Get()
        {
            return await this.db.Locations.ToListAsync();
        }

        /// <summary>
        /// Fetches a single location given its identifier.
        /// </summary>
        /// <param name="id">The location identifier.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<Location> Get(Guid id)
        {
            return await this.db.Locations.FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}
