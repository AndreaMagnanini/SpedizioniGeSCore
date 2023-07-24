// <copyright file="ShipmentRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Repositories
{
    using System.Data.Entity;
    using FancyWebApp.DataBase;
    using FancyWebApp.Interfaces.Repositories;
    using FancyWebApp.Models;

    /// <summary>
    /// The repository linked to Shipment entity.
    /// </summary>
    public class ShipmentRepository : IShipmentRepository
    {
        /// <summary>
        /// The database instance.
        /// </summary>
        private readonly ShipmentDb db;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShipmentRepository"/> class.
        /// </summary>
        /// <param name="db">The database instance.</param>
        public ShipmentRepository(ShipmentDb db)
        {
            this.db = db;
        }

        /// <summary>
        /// Fetches all available shipments.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<List<Shipment>> Get() => await this.db.Shipments.ToListAsync();

        /// <summary>
        /// Fetches multiple shipments filtered by year.
        /// </summary>
        /// <param name="year">The filtering year.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<List<Shipment>> GetByYear(int year) =>
            await this.db.Shipments.Where(s => s.CreationDate.Date.Year == year).ToListAsync();

        /// <summary>
        /// Posts a new instance of shipment.
        /// </summary>
        /// <param name="shipment">The given shipment instance.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Post(Shipment shipment)
        {
            await this.db.Shipments.AddAsync(shipment);
            await this.db.SaveChangesAsync();
        }
    }
}