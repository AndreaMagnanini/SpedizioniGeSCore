// <copyright file="IPortRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>using FancyWebApp.DataBase;

namespace FancyWebApp.Interfaces.Repositories
{
    using FancyWebApp.Models;

    /// <summary>
    /// The port repository interface.
    /// </summary>
    public interface IPortRepository
    {
        /// <summary>
        /// Fetches all available ports.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<Port>> Get();

        /// <summary>
        /// Fetches a single port given its identifier.
        /// </summary>
        /// <param name="id">The port identifier.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<Port?> Get(Guid id);
    }
}
