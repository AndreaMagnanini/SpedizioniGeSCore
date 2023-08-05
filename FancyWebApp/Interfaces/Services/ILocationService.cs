// <copyright file="ILocationService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Interfaces.Services
{
    using FancyWebApp.Dtos;

    /// <summary>
    /// The Location Service interface.
    /// </summary>
    public interface ILocationService
    {
        /// <summary>
        /// Fetches and performs operations on all available locations.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<List<LocationDto>> Get();
        /// <summary>
        /// Fetches and performs operation onto a single location, given its id.
        /// </summary>
        /// <param name="id">The location identifier.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<LocationDto> Get(Guid id);
    }
}
