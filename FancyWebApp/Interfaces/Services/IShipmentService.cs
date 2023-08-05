// <copyright file="IShipmentService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Interfaces.Services
{
    using FancyWebApp.Dtos;

    /// <summary>
    /// The shipment service interface.
    /// </summary>
    public interface IShipmentService
    {
        /// <summary>
        /// Fetches and performs operations on all the available shipments.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<List<ShipmentDto>> Get();

        /// <summary>
        /// Performs operations onto a new shipment before posting as new db entry.
        /// </summary>
        /// <param name="shipmentDto">The new shipment data.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<ShipmentDto> Post(ShipmentDto shipmentDto);

        /// <summary>
        /// Fetches and performs operations onto all shipment created within a certain year.
        /// </summary>
        /// <param name="year">The year used to filter shipments.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<List<ShipmentDto>> GetByYear(int year);
    }
}