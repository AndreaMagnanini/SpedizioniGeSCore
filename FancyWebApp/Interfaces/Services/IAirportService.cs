// <copyright file="IAirportService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Interfaces.Services
{
    using FancyWebApp.Dtos;

    /// <summary>
    /// The airport service repository.
    /// </summary>
    public interface IAirportService
    {
        /// <summary>
        /// Fetches and performs operations on all the available airports.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<List<AirportDto>> Get();

        /// <summary>
        /// Fetches and performs operations on a single airport given its identifier.
        /// </summary>
        /// <param name="id">The airport identifier.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<AirportDto> Get(Guid id);
    }
}