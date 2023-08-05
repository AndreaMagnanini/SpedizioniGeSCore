// <copyright file="AirportDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Dtos
{
    /// <summary>
    /// The airport data transfer object.
    /// </summary>
    public class AirportDto
    {
        /// <summary>
        /// Gets or sets the Airport IATA Code.
        /// </summary>
        public string? IataCode { get; set; }

        /// <summary>
        /// Gets or sets the Airport name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the Airport City.
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Gets or sets the Airport Description.
        /// </summary>
        public string? Description { get; set; }
    }
}