// <copyright file="IShipmentRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Interfaces.Repositories
{
    using FancyWebApp.Models;

    /// <summary>
    /// The shipment repository interface.
    /// </summary>
    public interface IShipmentRepository
    {
        /// <summary>
        /// Fetches all the available shipments.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<List<Shipment>> Get();

        /// <summary>
        /// Fetches all the shipments created in a single year.
        /// </summary>
        /// <param name="year">The year for filtering existing shipments</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<List<Shipment>> GetByYear(int year);

        /// <summary>
        /// Posts a brand new created shipment.
        /// </summary>
        /// <param name="shipment">The created shipment</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task Post(Shipment shipment);
    }
}