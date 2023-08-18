// <copyright file="LocationRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>using FancyWebApp.DataBase;

namespace FancyWebApp.Repositories
{
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

        /// <inheritdoc/>
        public async Task<List<Location?>> Get()
        {
            return await this.db.Locations.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Location?> Get(Guid id)
        {
            return await this.db.Locations.FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}