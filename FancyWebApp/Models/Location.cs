// <copyright file="Location.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using FancyWebApp.Models.Common;

    /// <summary>
    /// Represents a known location in the world as target of a Formula 1 GP.
    /// </summary>
    public class Location : UserTrace
    {
        /// <summary>
        /// Gets or sets the location id.
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the location name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the location nation.
        /// </summary>
        [Required]
        public string Nation { get; set; }

        /// <summary>
        /// Gets or sets the location city.
        /// </summary>
        [Required]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the location address.
        /// </summary>
        public string Address { get; set; }
    }
}