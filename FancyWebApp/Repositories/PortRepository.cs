// <copyright file="PortRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Repositories
{
    using FancyWebApp.Models;

    /// <summary>
    /// The repository linked to port entity.
    /// </summary>
    public class PortRepository : IPortRepository
    {
        /// <summary>
        /// The shipment db instance.
        /// </summary>
        private readonly ShipmentDb db;

        /// <summary>
        /// Initializes a new instance of the <see cref="PortRepository"/> class.
        /// </summary>
        /// <param name="db">The shipment db instance.</param>
        public PortRepository(ShipmentDb db)
        {
            this.db = db;
        }

        /// <inheritdoc/>
        public async Task<List<Port>> Get()
        {
            return await this.db.Ports.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Port?> Get(Guid id)
        {
            return await this.db.Ports.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}