// <copyright file="IPortService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Interfaces.Services
{
    using FancyWebApp.Dtos;

    /// <summary>
    /// The port service interface.
    /// </summary>
    public interface IPortService
    {
        /// <summary>
        /// Fetches and performs operations on all the available ports.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<List<PortDto>> Get();

        /// <summary>
        /// Fetches and performs operations onto a single port given its id.
        /// </summary>
        /// <param name="id">The port identifier.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<PortDto> Get(Guid id);
    }
}
