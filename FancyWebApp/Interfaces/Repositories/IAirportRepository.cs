// <copyright file="IAirportRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Interfaces.Repositories
{
    using FancyWebApp.Models;

    /// <summary>
    /// The airport repository interface.
    /// </summary>
    public interface IAirportRepository
    {
        /// <summary>
        /// Fetches all available airports.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<Airport>> Get();

        /// <summary>
        /// Fetches a single airport given its identifier.
        /// </summary>
        /// <param name="id">The airport identifier.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<Airport?> Get(Guid id);
    }
}
