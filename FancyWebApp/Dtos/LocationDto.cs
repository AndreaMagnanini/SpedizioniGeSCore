// <copyright file="LocationDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Dtos
{
    /// <summary>
    /// The location data transfer object.
    /// </summary>
    public class LocationDto
    {
        /// <summary>
        /// Gets or sets the location name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the location address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the location nation.
        /// </summary>
        public string Nation { get; set; }

        /// <summary>
        /// Gets or sets the location city.
        /// </summary>
        public string City { get; set; }
    }
}