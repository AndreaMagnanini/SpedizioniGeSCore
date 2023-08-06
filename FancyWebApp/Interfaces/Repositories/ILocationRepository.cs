// <copyright file="ILocationRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Interfaces.Repositories
{
    using FancyWebApp.Models;

    /// <summary>
    /// The Location Repository interface.
    /// </summary>
    public interface ILocationRepository
    {
        /// <summary>
        /// Fetches from db all available locations.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<List<Location>> Get();

        /// <summary>
        /// Fetches a single location given its identifier.
        /// </summary>
        /// <param name="id">The Location identifier.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<Location> Get(Guid id);
    }
}